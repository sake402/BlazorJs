using BlazorJs.Compiler;
using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUglify;
using System.Linq;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using BlazorJs.Compiler.Razor;
using System.Diagnostics;
using System.Reflection;

var result = await $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/h5.exe check-if-online".CLI();
if (result.ExitCode != 0)
{
    Console.WriteLine("Starting h5 as server...");
    _ = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/h5.exe server".CLI();
}
else
{
    Console.WriteLine("h5 server is running!");
}

string dotnetPath = (await "where dotnet".CLI()).StdOut.Trim();
string dotnetVersion = (await "dotnet --version".CLI()).StdOut.Trim();
var dotnetSDKs = (await "dotnet --list-sdks".CLI()).StdOut.Trim();
var sdks = dotnetSDKs.Split('\r').Last().Split(' ');
var sdkVersion = sdks[0].Trim();
var sdkPath = sdks[1].Trim('[', ']', ' ');
var dotnetFolder = Path.GetDirectoryName(dotnetPath) + "\\";

Console.WriteLine($"Using dotnet {dotnetVersion} @ {dotnetPath}. SDK {sdkVersion} @ {sdkPath}");

var directory = Directory.GetCurrentDirectory();

Console.WriteLine($"Scanning for h5 projects in \"{directory}\"..."); ;
var h5Projects = Directory.EnumerateFiles(directory, "*.csproj", SearchOption.AllDirectories)
    .Select(path => BlazorJs.Compiler.ProjectInfo.GetProjectDefinition(path))
    .Where(project => project?.SDK?.StartsWith("h5.Target/") ?? false)
    .ToList();

Console.WriteLine($"\r\n{h5Projects.Count} h5 projects found in {directory}!");
foreach (var project in h5Projects)
{
    Console.WriteLine($"{project!.Path}");
}

//var projectFolders = new string[] { @"E:\Apps\LivingThing\KitchenSink\BlazorJs.Core", @"E:\Apps\LivingThing\KitchenSink\BlazorJs.Sample", };

var compiler = new CodeCompiler(dotnetFolder, dotnetVersion, sdkVersion);
Dictionary<BlazorJs.Compiler.ProjectInfo, ProjectContext> contexts = new Dictionary<BlazorJs.Compiler.ProjectInfo, ProjectContext>();

foreach (var _project in h5Projects)
{
    var project = _project;
    FileSystemWatcher razorWatcher = new FileSystemWatcher(Path.GetDirectoryName(project!.Path)!);
    razorWatcher.NotifyFilter =
         NotifyFilters.Attributes
         | NotifyFilters.CreationTime
         | NotifyFilters.DirectoryName
         | NotifyFilters.FileName
         | NotifyFilters.LastAccess
         | NotifyFilters.LastWrite
        | NotifyFilters.Security
        | NotifyFilters.Size
        ;
    razorWatcher.Filter = "*.razor";
    razorWatcher.IncludeSubdirectories = true;
    razorWatcher.EnableRaisingEvents = true;
    razorWatcher.Changed += (s, e) =>
    {
        TryProcessProject(project);
    };
    razorWatcher.Created += (s, e) =>
    {
        TryProcessProject(project);
    };
    razorWatcher.Renamed += (s, e) =>
    {
        TryProcessProject(project);
    };

    FileSystemWatcher csWatcher = new FileSystemWatcher(Path.GetDirectoryName(project.Path)!);
    csWatcher.NotifyFilter =
         NotifyFilters.Attributes
         | NotifyFilters.CreationTime
         | NotifyFilters.DirectoryName
         | NotifyFilters.FileName
         | NotifyFilters.LastAccess
         | NotifyFilters.LastWrite
        | NotifyFilters.Security
        | NotifyFilters.Size
        ;
    csWatcher.Filter = "*.cs";
    csWatcher.IncludeSubdirectories = true;
    csWatcher.EnableRaisingEvents = true;
    csWatcher.Changed += (s, e) =>
    {
        TryProcessProject(project);
    };
    csWatcher.Created += (s, e) =>
    {
        TryProcessProject(project);
    };
    csWatcher.Renamed += (s, e) =>
    {
        TryProcessProject(project);
    };

    contexts[project] = new ProjectContext(razorWatcher, csWatcher);
}

Console.WriteLine("\r\nWaiting for changes...");
Thread.Sleep(Timeout.InfiniteTimeSpan);

void TryProcessProject(BlazorJs.Compiler.ProjectInfo project)
{
    var context = contexts[project];
    if (context.LastProcessed == DateTime.MinValue || DateTime.Now - context.LastProcessed > TimeSpan.FromSeconds(5))
    {
        context.LastProcessed = DateTime.Now;
        try
        {
            ProcessProject(project);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
        Console.WriteLine("\r\nWaiting for changes...");
    }
}

const string GeneratedFolderName = "__BlazorJs";

void ProcessProject(BlazorJs.Compiler.ProjectInfo project)
{
    var projectFolder = Path.GetDirectoryName(project.Path)!;
    Console.WriteLine($"\r\nProcessing in {projectFolder}...");
    var outputPath = Path.Combine(projectFolder, GeneratedFolderName);
    if (!Directory.Exists(outputPath))
        Directory.CreateDirectory(outputPath);
    //var projectInfo = ProjectInfo.GetProjectDefinition(projectFolder);
    var razorFiles = Directory.EnumerateFiles(projectFolder, "*.razor", SearchOption.AllDirectories)
        .Where(f => Path.GetFileName(f) != "_Imports.razor");

    var csFiles = Directory.EnumerateFiles(projectFolder, "*.cs", SearchOption.AllDirectories).Where(f => !f.Contains(GeneratedFolderName)).ToList();
    Console.WriteLine($"Compiling {csFiles.Count} files...");
    var compilation = compiler.GenerateCode(project, csFiles.ToArray());

    Dictionary<string, ComponentCodeGenerationContext> components = new Dictionary<string, ComponentCodeGenerationContext>();

    List<string> outStartupCodes = new List<string>();

    var referencedAssemblySymbols = compilation.ExternalReferences.Select(r => (IAssemblySymbol?)compilation.GetAssemblyOrModuleSymbol(r));

    //var types = compilation.GetSymbolsWithName(e =>
    //{
    //    return true;
    //}, SymbolFilter.Type);

    static bool InheritsFromComponentBase(ITypeSymbol ts)
    {
        if (ts.Name == "ComponentBase")
            return true;
        if (ts.BaseType != null)
            return InheritsFromComponentBase(ts.BaseType);
        return false;
    }

    static IEnumerable<T> GetSymbolsDeep<T>(ISymbol source)
        where T : ITypeSymbol
    {
        if (source is INamespaceOrTypeSymbol nsource)
        {
            var symbols = nsource.GetMembers();
            foreach (var t in symbols.OfType<T>())
                yield return t;
            foreach (var t in symbols)
            {
                var inner = GetSymbolsDeep<T>(t);
                foreach (var i in inner)
                    yield return i;
            }
        }
    }
    foreach (var assembly in referencedAssemblySymbols)
    {
        if (assembly == null)
            continue;
        var types = GetSymbolsDeep<ITypeSymbol>(assembly.GlobalNamespace);
        foreach (var type in types)
        {
            if (type is INamedTypeSymbol ts && InheritsFromComponentBase(ts))
            {
                //if (ts.ContainingAssembly.Name==projectInfo.AssemblyName)
                //continue;
                var componentClassName = ts.Name;
                var context = new ComponentCodeGenerationContext(outStartupCodes)
                {
                    Project = project,
                    //GlobalUsing = imports,
                    //RazorFile = razorFile,
                    //Namespace = projectInfo.Namespace + (relativePath != "." ? ("." + relativePath.Replace("/", ".").Replace("\\", ".")) : ""),
                    ClassName = componentClassName,
                    //SequenceNumber = Random.Shared.Next(int.MinValue + 200000, int.MaxValue - 200000), //make sure the sequnce number wont overflow when incrmented
                    ComponentClassSymbol = ts,
                    //ComponentClassCompilationUnit = ts.Sy
                    KnownComponents = components
                };
                components.Add(componentClassName, context);
            }
        }
    }

    foreach (var razorFile in razorFiles)
    {
        var componentClassName = Path.GetFileNameWithoutExtension(razorFile);
        INamedTypeSymbol? _componentClassSymbol = null;
        CompilationUnitSyntax? componentClassCompilationSyntax = null;
        var csFilePath = Path.ChangeExtension(razorFile, "razor.cs");
        if (File.Exists(csFilePath))
        {
            var codeBehindSyntaxTree = compilation.SyntaxTrees.SingleOrDefault(s => s.FilePath == csFilePath);// compiler.GetSyntaxTrees(csFilePath).First();
            if (codeBehindSyntaxTree != null)
            {
                var compilationSemanticModel = compilation.GetSemanticModel(codeBehindSyntaxTree);
                componentClassCompilationSyntax = (CompilationUnitSyntax)codeBehindSyntaxTree.GetRoot();
                var _namespace = (NamespaceDeclarationSyntax?)componentClassCompilationSyntax.Members.FirstOrDefault(m => m is NamespaceDeclarationSyntax);
                if (_namespace != null)
                {
                    var _class = _namespace.Members.FirstOrDefault(m => m is ClassDeclarationSyntax c && compilationSemanticModel.GetDeclaredSymbol(c)?.Name == componentClassName);
                    if (_class != null)
                        _componentClassSymbol = (INamedTypeSymbol?)compilationSemanticModel.GetDeclaredSymbol(_class);
                }
            }
        }

        var razorFolder = Path.GetDirectoryName(razorFile)!;
        var relativePath = Path.GetRelativePath(projectFolder, razorFolder);
        string? GetRazorImports(string directory)
        {
            if (File.Exists(directory + "/_Imports.razor"))
            {
                return File.ReadAllText(directory + "/_Imports.razor");
            }
            if (directory == projectFolder)
                return null;
            var upperDirectory = Path.GetFullPath(directory + "/..");
            return GetRazorImports(upperDirectory);
        }
        var imports = GetRazorImports(razorFolder);
        var context = new ComponentCodeGenerationContext(outStartupCodes)
        {
            Project = project,
            RazorImports = imports,
            RazorFile = razorFile,
            CsFile = csFilePath,
            Namespace = project.Namespace + (relativePath != "." ? ("." + relativePath.Replace("/", ".").Replace("\\", ".")) : ""),
            ClassName = componentClassName,
            RazorSequenceNumber = Random.Shared.Next(int.MinValue + 200000, int.MaxValue - 200000), //make sure the sequnce number wont overflow when incrmented
            ComponentClassSymbol = _componentClassSymbol,
            ComponentClassCompilationUnit = componentClassCompilationSyntax,
            KnownComponents = components
        };
        components[componentClassName] = context;
    }

    foreach (var csComponent in compilation.SyntaxTrees)
    {
        if (components.Any(c => c.Value.CsFile == csComponent.FilePath))
            continue;
        var componentClassName = Path.GetFileNameWithoutExtension(csComponent.FilePath);
        INamedTypeSymbol? _componentClassSymbol = null;
        var compilationSemanticModel = compilation.GetSemanticModel(csComponent);
        var componentClassCompilationSyntax = (CompilationUnitSyntax)csComponent.GetRoot();
        var _namespace = (NamespaceDeclarationSyntax?)componentClassCompilationSyntax.Members.FirstOrDefault(m => m is NamespaceDeclarationSyntax);
        if (_namespace != null)
        {
            var _class = _namespace.Members.FirstOrDefault(m => m is ClassDeclarationSyntax c && compilationSemanticModel.GetDeclaredSymbol(c)?.Name == componentClassName);
            if (_class != null)
                _componentClassSymbol = (INamedTypeSymbol?)compilationSemanticModel.GetDeclaredSymbol(_class);
        }

        if (_componentClassSymbol == null || _componentClassSymbol.Name == "ComponentBase" || !InheritsFromComponentBase(_componentClassSymbol))
            continue;
        var csFolder = Path.GetDirectoryName(csComponent.FilePath);
        var relativePath = Path.GetRelativePath(projectFolder, csComponent.FilePath);

        var context = new ComponentCodeGenerationContext(outStartupCodes)
        {
            Project = project,
            CsFile = csComponent.FilePath,
            Namespace = _namespace!.Name.ToString(),
            ClassName = componentClassName,
            RazorSequenceNumber = Random.Shared.Next(int.MinValue + 200000, int.MaxValue - 200000), //make sure the sequnce number wont overflow when incremented
            ComponentClassSymbol = _componentClassSymbol,
            ComponentClassCompilationUnit = componentClassCompilationSyntax,
            KnownComponents = components
        };
        components[componentClassName] = context;
    }

    Console.WriteLine($"Generating codes...");

    foreach (var component in components.Where(c => c.Value.RazorFile != null || c.Value.CsFile != null))
    {
        if (component.Value.RazorFile != null)
        {
            var parser = new RazorComponentParser(component.Value.RazorImports + "\r\n" + File.ReadAllText(component.Value.RazorFile!));
            var parseResult = parser.Parse();
            component.Value.RazorComponentSymbol = parseResult;
        }
        var code = component.Value.GenerateCode();
        var csFileName = (component.Value.RazorFile ?? component.Value.CsFile!.Replace(".cs", ""));
        csFileName = Path.Combine(outputPath, Path.GetRelativePath(projectFolder, csFileName) + ".g.cs");
        var folder = Path.GetDirectoryName(csFileName)!;
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);
        File.WriteAllText(csFileName, code);
    }

    if (outStartupCodes.Any())
    {
        File.WriteAllText(Path.Combine(outputPath, "__Startup.g.cs"), @$"
namespace {project.Namespace}
{{
    public static class GeneratedStartup
    {{
        public static void Run()
        {{
{string.Join("\r\n", outStartupCodes.Select(r => "            " + r))}
        }}
    }}
}}
");
    }

    var shortNames = GenerateShortNames(compilation);
    File.WriteAllText(Path.Combine(outputPath, "__ShortNames.g.cs"), shortNames);
}

static IEnumerable<string> SplitByCamelCase(string str)
{
    if (str.Length <= 2)
        yield return str;
    int start = 0;
    for (int i = 0; i < str.Length; i++)
    {
        if (i >= 2 && char.IsUpper(str[i]) && char.IsLower(str[i - 1]))
        {
            yield return str.Substring(start, i - start);
            start = i;
        }
        else if (i >= 2 && char.IsUpper(str[i]) && char.IsUpper(str[i - 1]) && i + 1 < str.Length && char.IsLower(str[i + 1]))
        {
            yield return str.Substring(start, i - start);
            start = i;
        }
    }
    if (start < str.Length)
        yield return str.Substring(start, str.Length - start);
}

string GenerateShortNames(Compilation compilation)
{
    string GetShortName(TypeDeclarationSyntax _class, List<string> takenNames, out NamespaceDeclarationSyntax? _namespace, bool addToTaken = true)
    {
        string? parentName = null;
        if (_class.Parent is TypeDeclarationSyntax pClass)
        {
            parentName = GetShortName(pClass, takenNames, out _namespace, false);
        }
        else
        {
            _namespace = (NamespaceDeclarationSyntax?)_class.Parent;
            var mnamespace = _namespace?.Name.ToString();
            parentName = mnamespace != null ? string.Join("", mnamespace.Split('.').Select(p => p[0])) : null;
        }
        var _className = _class.Identifier.ToString();
        var classNameTokens = SplitByCamelCase(_className).ToArray();
        var shortName = parentName + "_" + string.Join("", classNameTokens.Select(c => c[0]));
        if (_class.TypeParameterList?.Parameters.Any() ?? false)
        {
            shortName += "$" + _class.TypeParameterList.Parameters.Count;
        }
        //int classN_i = 0;
        //while (takenNames.Contains(shortName) && classN_i < classNameTokens.Length)
        //{
        //    shortName += classNameTokens[classN_i][0];
        //    classN_i++;
        //}
        if (addToTaken && takenNames.Contains(shortName))
        {
            var likes = takenNames.Count(t => t.StartsWith(shortName));
            shortName += "$" + (likes + 1);
        }
        if (addToTaken)
            takenNames.Add(shortName);
        return shortName;
    }
    List<string> takenNames = new List<string>();
    string ConvertClass(TypeDeclarationSyntax type, int depth)
    {
        var shortName = GetShortName(type, takenNames, out _);
        var innerClasses = string.Join("\r\n", type.ChildNodes()
            .Where(d => d is TypeDeclarationSyntax)
            .Cast<TypeDeclarationSyntax>()
            .Select(i => ConvertClass(i, depth + 1)));
        var tab = string.Join("", Enumerable.Range(1, depth + 1).Select(t => "    "));
        var modifiers = type.Modifiers.ToString();
        if (!modifiers.Contains("partial"))
            modifiers += " partial";
        return $@"{tab}[Name(""{shortName.ToLower()}"")]
{tab}{modifiers} {(type is StructDeclarationSyntax ? "struct" : type is ClassDeclarationSyntax ? "class" : "interface")} {type.Identifier}{((type.TypeParameterList?.Parameters.Any() ?? false) ? $"<{string.Join(", ", type.TypeParameterList.Parameters.Select(p => p.Identifier))}>" : "")}
{tab}{{
{tab}{innerClasses}
{tab}}}";
    }
    var shortNames = @"
#if RELEASE
using H5;
" + string.Join("\r\n\r\n", compilation.SyntaxTrees.SelectMany(syntax =>
    {
        var compilationSemanticModel = compilation.GetSemanticModel(syntax);
        var componentClassCompilationSyntax = (CompilationUnitSyntax)syntax.GetRoot();
        var _classes = componentClassCompilationSyntax.DescendantNodes().Where(d => d is TypeDeclarationSyntax).Where(t => t.Parent is NamespaceDeclarationSyntax).Cast<TypeDeclarationSyntax>();
        return _classes;
    }).DistinctBy(c => c.Identifier.ToString())
    .Select(type =>
{
    var _namespace = ((NamespaceDeclarationSyntax?)type.Parent)?.Name.ToString();
    var code = $@"
namespace {_namespace}
{{
{ConvertClass(type, 0)}
}}";
    return code;
})) + "\r\n\r\n#endif";
    return shortNames;
}


