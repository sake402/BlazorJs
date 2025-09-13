using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Permissions;

class JSWriter
{
    LinkedList<StringWriter> lines = new LinkedList<StringWriter>([new StringWriter()]);
    //StringWriter writer = new StringWriter();
    int depth = 0;
    StringWriter currentWriter => lines.Last!.Value;
    void WriteTabs()
    {
        for (int i = 0; i < depth; i++)
            currentWriter.Write("    ");
    }

    public void InsertAbove(string line)
    {
        var writer = new StringWriter();
        writer.Write(line);
        lines.AddBefore(lines.Last, writer);
        //var raw = writer.ToString().Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries).ToList();
        //raw.Insert(Math.Max(0, raw.Count - 1), string.Join("", Enumerable.Range(1, depth).Select(e => "    ")) + line);
        //writer = new StringWriter();
        //int i = 0;
        //foreach (var _line in raw)
        //{
        //    if (i > 0)
        //        writer.Write("\r\n");
        //    writer.Write(_line);
        //    i++;
        //}
    }

    public class ClosureInfo
    {
        public required LinkedListNode<StringWriter> Start { get; set; }
        public int Inserts { get; set; }
    }
    Stack<ClosureInfo> closureStarts = new Stack<ClosureInfo>();
    public ClosureInfo CurrentClosure => closureStarts.Peek();
    public void InsertInCurrentClosure(string line, bool withTabs)
    {
        var writer = new StringWriter();
        if (withTabs)
        {
            for (int i = 0; i < depth; i++)
                writer.Write("    ");
        }
        writer.Write(line);
        var node = CurrentClosure.Start;
        int ix = 0;
        while (ix++ < CurrentClosure.Inserts)
        {
            node = node.Next;
        }
        lines.AddAfter(node, writer);
        CurrentClosure.Inserts++;
    }

    public void Write(string code, bool withTabs = false)
    {
        if (code == "System")
        {

        }
        if (withTabs)
        {
            if (code.StartsWith("}"))
            {
                closureStarts.Pop();
                depth--;
            }
            WriteTabs();
            if (code == "{")
            {
                closureStarts.Push(new ClosureInfo { Start = lines.Last! });
                depth++;
            }
        }
        currentWriter.Write(code);
    }

    public void WriteLine(string code, bool withTabs = false)
    {
        Write(code, withTabs);
        lines.AddLast(new StringWriter());
        //Write("\r\n");
    }

    public void EnsureNewLine()
    {
        if (currentWriter.ToString().Length > 0)
        {
            lines.AddLast(new StringWriter());
        }
        //if (!writer.ToString().EndsWith("\r\n"))
        //{
        //    Write("\r\n");
        //}
    }
    public override string ToString()
    {
        return string.Join("\r\n", lines.Select(l => l.ToString()));
        //return writer.ToString() ?? "";
    }
}

public class GlobalCompilationVisitor
{
    public CSharpCompilation Compilation { get; }
    public List<string> ProcessedTypeNodes { get; } = new List<string>();
    public Dictionary<SyntaxTree, CSToJSSyntaxVisitor> Visitors { get; } = new Dictionary<SyntaxTree, CSToJSSyntaxVisitor>();
    public List<SyntaxNode> AllNodes { get; }

    public GlobalCompilationVisitor(CSharpCompilation compilation)
    {
        Compilation = compilation;
        AllNodes = compilation.SyntaxTrees.SelectMany(c => c.GetRoot().DescendantNodes()).ToList();
    }
}

public class CSToJSSyntaxVisitor : CSharpSyntaxWalker
{
    GlobalCompilationVisitor global;
    SyntaxTree tree;
    SemanticModel semanticModel;
    List<string> importedNamespace = new List<string>();
    //string? currentNamespace;

    Stack<JSWriter> writers = new Stack<JSWriter>();
    JSWriter Writer => writers.Peek();

    public CSToJSSyntaxVisitor(GlobalCompilationVisitor compilation, SyntaxTree tree)
    {
        this.global = compilation;
        this.tree = tree;
        semanticModel = compilation.Compilation.GetSemanticModel(tree);
        writers.Push(new JSWriter());
    }

    static T? FindClosest<T>(SyntaxNode source)
    {
        var current = source;
        while (current != null)
        {
            if (current is T t)
                return t;
            current = current.Parent;
        }
        return default;
    }

    static bool ChildIsBlock(SyntaxNode node)
    {
        return node.ChildNodes().Count() == 1 && node.ChildNodes().Single() is BlockSyntax;
    }

    string ResolveIdentifierName(SyntaxToken token)
    {
        if (token.Text == "constructor")
            return "$constructor";
        if (token.Text == "function")
            return "$function";
        if (token.Text == "arguments")
            return "$arguments";
        return token.Text.Replace("@", "$");
    }

    string ResolveFullTypeName(SyntaxToken type)
    {
        var t = type.ToFullString().Trim().TrimEnd('?').Replace("@", "$");
        if (t.EndsWith("[]"))
        {
            return $"BlazorJs.TypeArray({t.Substring(0, t.Length - 2)})";
        }
        return t;
    }

    string ResolveFullTypeName(ISymbol type)
    {
        return type.ToDisplayString().Replace(".", "_").Replace("<", "(").Replace(">", ")").Replace("?", "").Trim();
    }

    string ResolveFullTypeName(NamespaceDeclarationSyntax type)
    {
        string? parent = null;
        if (type.Parent is NamespaceDeclarationSyntax ns)
        {
            parent = ResolveFullTypeName(ns);
        }
        return (parent + type.Name.ToFullString().Trim()).Replace(".", "_");
    }

    string ResolveFullTypeName(BaseTypeDeclarationSyntax type)
    {
        string? parent = null;
        if (type.Parent is TypeDeclarationSyntax ts)
        {
            parent = ResolveFullTypeName(ts) + ".";
        }
        else if (type.Parent is NamespaceDeclarationSyntax ns)
        {
            parent = ResolveFullTypeName(ns) + ".";
        }
        return (parent + type.Identifier.ValueText.Trim().TrimEnd('?')).Replace(".", "_");
    }

    string ResolveFullTypeName(TypeSyntax type, bool stripGenericName = false)
    {
        string t;
        //if (type is GenericNameSyntax g)
        //{
        //    t = g.Identifier.ToFullString() + $"({string.Join(", ", g.TypeArgumentList.Arguments.Select(a => ResolveFullTypeName(a)))})";
        //}
        //else
        //{
        if (stripGenericName)
        {
            t = type.ToFullString().Split('<')[0].Trim().TrimEnd('?');
        }
        else
        {
            t = type.ToFullString().Replace("<", "(").Replace(">", ")").Trim().TrimEnd('?');
        }
        //}
        if (t.EndsWith("[]"))
        {
            return $"BlazorJs.TypeArray({t.Substring(0, t.Length - 2)})";
        }
        return t;
    }

    string ResolveFullTypeName(TypeParameterSyntax type)
    {
        return type.Identifier.ToString().Replace("<", "(").Replace(">", ")");
    }

    string GetDefaultValue(TypeSyntax type)
    {
        if (type is IdentifierNameSyntax id)
        {
            switch (id.Identifier.ToFullString().Trim().TrimEnd('?'))
            {
                case "int":
                    return "0";
                case "double":
                    return "0";
                case "float":
                    return "0";
                case "bool":
                    return "false";
            }
        }
        return "null";
    }

    string CollectStatement(Action _continue)
    {
        var sb = new JSWriter();
        writers.Push(sb);
        _continue();
        writers.Pop();
        return sb.ToString();
    }

    string EmitStatement(StatementSyntax statement)
    {
        return "";
    }

    public override void VisitCompilationUnit(CompilationUnitSyntax node)
    {
        base.VisitCompilationUnit(node);
    }

    public override void VisitUsingStatement(UsingStatementSyntax node)
    {
        int foundVariables = 0;
        if (node.Declaration != null)
        {
            foreach (var variable in node.Declaration.Variables)
            {
                Writer.WriteLine($"const {variable.Identifier.ValueText} = null", true);
                foundVariables++;
            }
        }
        if (foundVariables == 0)
        {
            Writer.WriteLine("const $disposable = null", true);
        }
        Writer.WriteLine("try", true);
        Writer.WriteLine("{", true);
        if (foundVariables == 0)
        {
            Writer.WriteLine("$disposable = ", true);
        }
        Writer.Write("", true);
        Visit(node.Declaration);
        Writer.WriteLine(";");
        if (node.Expression != null)
        {
            VisitChildren(node.Expression.ChildNodes());
        }
        if (node.Statement != null)
        {
            if (node.Statement is BlockSyntax block)
                VisitChildren(block.ChildNodes());
            else
                Visit(node.Statement);
        }
        //base.VisitUsingStatement(node);
        Writer.WriteLine("}", true);
        Writer.WriteLine("finally", true);
        Writer.WriteLine("{", true);
        if (foundVariables == 0)
        {
            Writer.WriteLine("$disposable?.Dispose();", true);
        }
        else if (node.Declaration != null)
        {
            foreach (var variable in node.Declaration.Variables)
            {
                Writer.WriteLine($"{variable.Identifier.ValueText}?.Dispose();", true);
            }
        }
        Writer.WriteLine("}", true);
    }

    public override void VisitUsingDirective(UsingDirectiveSyntax node)
    {
        var name = node.Name!.ToFullString().Trim();
        if (!importedNamespace.Contains(name))
            importedNamespace.Add(name);
        //using declaration already fully handled
        //base.VisitUsingDirective(node);
    }

    void VisitChildren(IEnumerable<SyntaxNode> nodes)
    {
        foreach (var node in nodes)
        {
            Visit(node);
        }
    }

    public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
    {
        //var addedName = node.Name!.ToFullString().Trim();
        //if (addedName?.Length > 0)
        //{
        //    addedName += ".";
        //}
        //currentNamespace += addedName;
        VisitChildren(node.ChildNodes().Where(e => e is not QualifiedNameSyntax && e is not IdentifierNameSyntax));
        //base.VisitNamespaceDeclaration(node);
        //currentNamespace = currentNamespace.Substring(0, currentNamespace.Length - (addedName?.Length ?? 0));
    }

    void WriteMethodInvocation(ExpressionSyntax node, ArgumentListSyntax? arguments)
    {
        Writer.Write("(");
        if (node is InvocationExpressionSyntax)
        {
            IEnumerable<GenericNameSyntax> genericNames =
            [
                .. node.ChildNodes().Where(m => m is GenericNameSyntax).Cast<GenericNameSyntax>(),
                .. node.ChildNodes().Where(e => e is MemberAccessExpressionSyntax).Cast<MemberAccessExpressionSyntax>().Select(m => m.Name).Where(m => m is GenericNameSyntax).Cast<GenericNameSyntax>()
            ];
            if (genericNames.Any())
            {
                var genericArguments = string.Join(",", genericNames.Select(a =>
                {
                    return string.Join(", ", a.TypeArgumentList.Arguments.Select(a => ResolveFullTypeName(a)));
                }));
                Writer.Write(genericArguments);
                if (arguments?.Arguments.Any() ?? false)
                    Writer.Write(", ");
            }
        }
        if (arguments != null)
        {
            int ix = 0;
            foreach (var arg in arguments.Arguments.Where(e => e.NameColon == null))
            {
                if (ix > 0)
                    Writer.Write(", ");
                Visit(arg);
                ix++;
            }
            if (arguments.Arguments.Any(e => e.NameColon != null))
            {
                if (ix > 0)
                    Writer.Write(", ");
                Writer.Write("{ ");
                int ix2 = 0;
                foreach (var arg in arguments.Arguments.Where(e => e.NameColon != null))
                {
                    if (ix2 > 0)
                        Writer.Write(", ");
                    Visit(arg);
                    ix2++;
                    ix++;
                }
                Writer.Write(" }");
            }
        }
        Writer.Write(")");
    }

    public void VisitTypeDeclaration(BaseTypeDeclarationSyntax node)
    {
        bool _static = node.Modifiers.Any(m => m.ValueText == "static") || node is EnumDeclarationSyntax;
        var fullTypeName = ResolveFullTypeName(node);
        IEnumerable<SyntaxNode> childNodes = node.ChildNodes();
        if (node.Modifiers.Any(m => m.ValueText == "partial"))
        {
            var type = node.GetType();
            var partialTypes = global.AllNodes.Where(e => e is TypeDeclarationSyntax t && e.GetType() == type && ResolveFullTypeName(t) == fullTypeName);
            if (partialTypes.Count() > 1)
            {
                if (global.ProcessedTypeNodes.Contains(fullTypeName))
                    return;
                childNodes = partialTypes.SelectMany(c => c.ChildNodes()).ToList();
                global.ProcessedTypeNodes.Add(fullTypeName);
            }
        }
        INamedTypeSymbol? symbol = semanticModel.GetDeclaredSymbol(node);
        string? _base = null;
        string? implementedInterfaces = null;
        IEnumerable<INamedTypeSymbol> GetInterfaces(INamedTypeSymbol _interface)
        {
            foreach (var _innerInterface in _interface.Interfaces)
            {
                yield return _innerInterface;
                foreach (var _minnerInterface in GetInterfaces(_innerInterface))
                {
                    yield return _minnerInterface;
                }
            }
        }
        if (symbol != null)
        {
            var interfaces = GetInterfaces(symbol);
            foreach (var _interface in interfaces.Distinct(SymbolEqualityComparer.Default))
            {
                if (implementedInterfaces == null)
                    implementedInterfaces = "{0}";
                implementedInterfaces = $"{_interface!.ToString()?.Replace(".", "_").Replace("<", "(").Replace(">", ")")}({implementedInterfaces})";
            }
        }
        if (!_static)
        {
            if (symbol?.BaseType != null)
            {
                if (implementedInterfaces != null)
                {
                    //split discard the generic parameters
                    _base = $" extends {string.Format(implementedInterfaces, ResolveFullTypeName(symbol.BaseType))}";
                }
                else if (symbol.BaseType.Arity > 0)
                {
                    string genericTypes = string.Join(", ", symbol.BaseType.TypeArguments.Select(t => ResolveFullTypeName(t)));
                    _base = $" extends {ResolveFullTypeName(symbol.BaseType)}({genericTypes})";
                }
                else
                {
                    _base = $" extends {ResolveFullTypeName(symbol.BaseType)}";
                }
            }
            else if (node is ClassDeclarationSyntax)
            {
                if (implementedInterfaces != null)
                {
                    _base = $" extends {string.Format(implementedInterfaces, "System_Object")}";
                }
                else
                {
                    _base = $" extends System_Object";
                }
            }
        }
        string? classDefinition = null;
        if (node is InterfaceDeclarationSyntax || (node is TypeDeclarationSyntax t && t.Arity > 0))
        {
            string? genericArgs = string.Join(", ", (node as TypeDeclarationSyntax)?.TypeParameterList?.Parameters.Select(t => $"{(t.VarianceKeyword.ValueText?.Length > 0 ? $"/*{t.VarianceKeyword.ValueText}*/ " : "")}{t.Identifier.ToFullString()}") ?? Enumerable.Empty<string>());
            if (node is InterfaceDeclarationSyntax)
                classDefinition = $"{(node.Parent is TypeDeclarationSyntax ? "static" : "const")} {ResolveFullTypeName(node)} = ({genericArgs}{(genericArgs?.Length > 0 ? ", " : "")}Base) => class extends Base";
            else
                classDefinition = $"{(node.Parent is TypeDeclarationSyntax ? "static" : "const")} {ResolveFullTypeName(node)} = ({genericArgs}) => class{_base}";
        }
        else
        {
            if (node.Parent is TypeDeclarationSyntax)
            {
                //inner class definition
                classDefinition = $"static {ResolveFullTypeName(node)} = class{_base}";
            }
            else
            {
                classDefinition = $"{(_static ? "static " : "")}class {ResolveFullTypeName(node)}{_base}";
            }
        }
        Writer.WriteLine(classDefinition, true);
        Writer.WriteLine("{", true);
        if (!_static && node is not InterfaceDeclarationSyntax)
        {
            var methods = childNodes.Where(e => e is ConstructorDeclarationSyntax).Cast<ConstructorDeclarationSyntax>();
            if (!methods.Any()) //define default constructor
            {
                string? parameters = null;
                //if (node.TypeParameterList != null && node.Arity > 0)
                //{
                //    var genericParameters = string.Join(", ", node.TypeParameterList.Parameters.Select(p => $"/*{p.ToFullString()}*/ $_{p.ToFullString()}"));
                //    parameters = genericParameters;
                //    foreach (var t in node.TypeParameterList.Parameters)
                //    {
                //        Writer.WriteLine($"{t.ToFullString()} = null;", true);
                //    }
                //}
                Writer.WriteLine($"constructor({parameters})", true);
                Writer.WriteLine("{", true);
                string? superParameters = null;
                //if (symbol?.BaseType?.Arity > 0)
                //{
                //    superParameters = string.Join(", ", symbol.TypeArguments.Select(t => $"$_{t}"));
                //}
                Writer.WriteLine($"super({superParameters});", true);
                //if (node.TypeParameterList != null && node.Arity > 0)
                //{
                //    int i = 0;
                //    foreach (var t in node.TypeParameterList.Parameters)
                //    {
                //        Writer.WriteLine($"{t.ToFullString()} = $_{t.ToFullString()};", true);
                //        i++;
                //    }
                //}
                Writer.WriteLine("}", true);
            }
        }
        VisitChildren(childNodes.Where(e =>
        {
            if (node is InterfaceDeclarationSyntax)
            {
                if (e is PropertyDeclarationSyntax property)
                    return property.ExpressionBody != null || (property.AccessorList?.Accessors.Any() ?? false);
                else if (e is MethodDeclarationSyntax method)
                    return method.ExpressionBody != null || method.Body != null;
            }
            return e is not BaseListSyntax && e is not TypeParameterConstraintClauseSyntax;
        }));
        if (symbol?.Interfaces.Any() ?? false)
        {
            foreach (var i in symbol.Interfaces)
            {
                foreach (var ii in i.DeclaringSyntaxReferences)
                {
                    //Visit((SyntaxNode)ii.SyntaxTree.);
                }
            }
        }
        Writer.WriteLine("}", true);
    }

    public override void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
    {
        var siblings = node.Parent!.ChildNodes().Where(e => e is EnumMemberDeclarationSyntax).ToArray();
        Writer.WriteLine($"{node.Identifier.ValueText} = {(node.EqualsValue?.Value.ToFullString() ?? Array.IndexOf(siblings, node).ToString())};", true);
        //base.VisitEnumMemberDeclaration(node);
    }

    public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
    {
        VisitTypeDeclaration(node);
        //base.VisitEnumDeclaration(node);
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        VisitTypeDeclaration(node);
        //base.VisitClassDeclaration(node);
    }

    public override void VisitStructDeclaration(StructDeclarationSyntax node)
    {
        VisitTypeDeclaration(node);
        //base.VisitStructDeclaration(node);
    }

    public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
    {
        VisitTypeDeclaration(node);
        //base.VisitInterfaceDeclaration(node);
    }

    public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
    {
        //base.VisitDelegateDeclaration(node);
    }

    public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
    {
        var parameters = string.Join(", ", node.ParameterList.Parameters.Select(p => $"/*{p.Type?.ToFullString().Trim()}*/ {ResolveIdentifierName(p.Identifier)}"));
        //if (node.Parent is TypeDeclarationSyntax _type && _type.TypeParameterList != null && _type.Arity > 0)
        //{
        //    var genericParameters = string.Join(", ", _type.TypeParameterList.Parameters.Select(p => $"/*{p.ToFullString()}*/ $_{p.ToFullString()}"));
        //    parameters = genericParameters + ", " + parameters;
        //    foreach (var t in _type.TypeParameterList.Parameters)
        //    {
        //        Writer.WriteLine($"{t.ToFullString()} = null;", true);
        //    }
        //}
        string? modifier = null;
        if (node.Modifiers.Any(e => e.ValueText == "async"))
        {
            modifier += "async ";
        }
        Writer.WriteLine($"{modifier}constructor({parameters})", true);
        Writer.WriteLine("{", true);
        Writer.Write("super(", true);
        if (node.Initializer != null)
        {
            int ix = 0;
            foreach (var arg in node.Initializer.ArgumentList.Arguments.Where(e => e.NameColon == null))
            {
                if (ix > 0)
                    Writer.Write(", ");
                Visit(arg);
                ix++;
            }
            if (node.Initializer.ArgumentList.Arguments.Any(e => e.NameColon != null))
            {
                if (ix > 0)
                    Writer.Write(", ");
                Writer.Write("{");
                int ixx = 0;
                foreach (var v in node.Initializer.ArgumentList.Arguments.Where(e => e.NameColon != null))
                {
                    if (ixx > 0)
                        Writer.Write(", ");
                    Visit(v);
                    ixx++;
                }
                Writer.Write("}");
            }
        }
        Writer.WriteLine(");");
        //if (node.Parent is TypeDeclarationSyntax _mtype && _mtype.TypeParameterList != null && _mtype.Arity > 0)
        //{
        //    int i = 0;
        //    foreach (var t in _mtype.TypeParameterList.Parameters)
        //    {
        //        Writer.WriteLine($"{t.ToFullString()} = $_{t.ToFullString()};", true);
        //        i++;
        //    }
        //}
        if (node.Body != null)
            VisitChildren(node.Body.ChildNodes());
        Writer.WriteLine("}", true);
    }

    void WriteMethodParameters(SeparatedSyntaxList<ParameterSyntax> parameters)
    {
        int i = 0;
        foreach (var p in parameters.Where(e => e.Default == null))
        {
            if (i > 0)
                Writer.Write(", ");
            Writer.Write($"/*{string.Join(" ", p.Modifiers.Select(m => m.ToFullString().Trim()))}{(p.Modifiers.Count > 0 ? " " : "")}{p.Type?.ToFullString().Trim()}*/ {ResolveIdentifierName(p.Identifier)}");
            i++;
        }
        if (parameters.Where(e => e.Default != null).Any())
        {
            if (i > 0)
                Writer.Write(", ");
            int ix = 0;
            Writer.Write("{ ");
            foreach (var p in parameters.Where(e => e.Default != null))
            {
                if (ix > 0)
                    Writer.Write(", ");
                Writer.Write($"/*{p.Type?.ToFullString().Trim()}*/ {p.Identifier.Text}");
                Visit(p.Default);
                i++;
                ix++;
            }
            Writer.Write("}");
        }
    }

    void WriteMethodBody(BaseMethodDeclarationSyntax node, TypeSyntax? returnType)
    {
        if (node.ExpressionBody != null)
        {
            Writer.WriteLine("{", true);
        }
        VisitChildren(node.ChildNodes().Where(e => e is not IdentifierNameSyntax && e is not ParameterListSyntax && e is not TypeParameterConstraintClauseSyntax && e is not ExplicitInterfaceSpecifierSyntax).Except(returnType != null ? [returnType] : []));
        if (node.ExpressionBody != null)
        {
            Writer.WriteLine("}", true);
        }
    }

    void WriteMethodParameters(SeparatedSyntaxList<ArgumentSyntax> parameters)
    {
        int i = 0;
        foreach (var p in parameters)
        {
            if (i > 0)
                Writer.Write(", ");
            //Writer.Write($"/*{string.Join(" ", p.Modifiers.Select(m => m.ToFullString().Trim()))}{(p.Modifiers.Count > 0 ? " " : "")}{p.Type?.ToFullString().Trim()}*/ {p.Identifier.Text}");
            i++;
        }
    }

    string? GetMethodModifier(SyntaxTokenList modifiers, TypeSyntax? methodReturnType)
    {
        string? modifier = null;
        if (methodReturnType != null)
        {
            var returnType = methodReturnType.ToFullString().Trim();
            modifier += $"/*{returnType}*/ ";
        }
        if (modifiers.Any(e => e.ValueText == "static"))
        {
            modifier += "static ";
        }
        if (modifiers.Any(e => e.ValueText == "async"))
        {
            modifier += "async ";
        }
        return modifier;
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        if (node.Modifiers.Any(e => e.ValueText == "abstract"))
            return;
        if (node.Modifiers.Any(e => e.ValueText == "extern"))
            return;
        if (node.Modifiers.Any(e => e.ValueText == "partial") && node.Body == null && node.ExpressionBody == null)
            return;
        string? modifier = GetMethodModifier(node.Modifiers, node.ReturnType);
        //Writer.WriteLine($"{modifier}{node.Identifier.Text.Trim()}({requiredParameters}{(requiredParameters.Length > 0 ? ", " : "")}{optionalParameters})", true);
        Writer.Write($"{modifier}{node.Identifier.Text.Trim()}(", true);
        int i = 0;
        if (node.Arity > 0 && (node.TypeParameterList?.Parameters.Any() ?? false))
        {
            foreach (var p in node.TypeParameterList.Parameters)
            {
                if (i > 0)
                    Writer.Write(", ");
                Writer.Write($"{ResolveFullTypeName(p)}");
                i++;
            }
        }
        if (i > 0 && node.ParameterList.Parameters.Any())
            Writer.Write(", ");
        WriteMethodParameters(node.ParameterList.Parameters);
        Writer.WriteLine($")");
        WriteMethodBody(node, node.ReturnType);
        //base.VisitMethodDeclaration(node);
    }

    public override void VisitImplicitObjectCreationExpression(ImplicitObjectCreationExpressionSyntax node)
    {
        base.VisitImplicitObjectCreationExpression(node);
    }

    public override void VisitOperatorDeclaration(OperatorDeclarationSyntax node)
    {
        string? modifier = GetMethodModifier(node.Modifiers, node.ReturnType);
        string operatorName = "Unknown";
        switch (node.OperatorToken.ValueText)
        {
            case "==":
                operatorName = "IsEqual";
                break;
            case "!=":
                operatorName = "IsNotEqual";
                break;
            case "+=":
                operatorName = "Add";
                break;
            case "-=":
                operatorName = "Subtract";
                break;
            default:
                break;
        }
        Writer.Write($"{modifier}$op_{operatorName}(", true);
        WriteMethodParameters(node.ParameterList.Parameters);
        Writer.WriteLine($")");
        WriteMethodBody(node, node.ReturnType);
        //base.VisitOperatorDeclaration(node);
    }

    public override void VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
    {
        string? modifier = GetMethodModifier(node.Modifiers, node.Type);
        Writer.Write($"{modifier}$op_Implicit_{ResolveFullTypeName(node.Type, stripGenericName: true)}(", true);
        WriteMethodParameters(node.ParameterList.Parameters);
        Writer.WriteLine($")");
        WriteMethodBody(node, node.Type);
        //base.VisitConversionOperatorDeclaration(node);
    }

    public override void VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
    {
        string? modifier = GetMethodModifier(node.Modifiers, node.ReturnType);
        Writer.Write($"{modifier}function {node.Identifier.Text.Trim()}(", true);
        WriteMethodParameters(node.ParameterList.Parameters);
        Writer.WriteLine($")");
        //WriteMethodBody(node);
        if (node.ExpressionBody != null)
        {
            Writer.WriteLine("{", true);
        }
        VisitChildren(node.ChildNodes().Where(e => e is not IdentifierNameSyntax && e is not ParameterListSyntax && e is not TypeParameterConstraintClauseSyntax && e is not ExplicitInterfaceSpecifierSyntax).Except(node.ReturnType != null ? [node.ReturnType] : []));
        //base.VisitMethodDeclaration(node);
        if (node.ExpressionBody != null)
        {
            Writer.WriteLine("}", true);
        }
        //base.VisitLocalFunctionStatement(node);
    }

    void WriteField(BaseFieldDeclarationSyntax node)
    {
        string? modifier = null;
        if (node.Modifiers.Any(e => e.ValueText == "static"))
        {
            modifier += "static ";
        }
        foreach (var var in node.Declaration.Variables)
        {
            var value = GetDefaultValue(node.Declaration.Type);
            Writer.Write($"/*{node.Declaration.Type.ToFullString().Trim()}*/ {modifier}{ResolveIdentifierName(var.Identifier)}", true);
            if (var.Initializer != null)
            {
                Visit(var.Initializer);
            }
            else
            {
                Writer.Write(" = ");
                Writer.Write(GetDefaultValue(node.Declaration.Type));
            }
            Writer.WriteLine($";");
        }
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        WriteField(node);
        //base.VisitFieldDeclaration(node);
    }

    public override void VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
    {
        WriteField(node);
        //base.VisitEventFieldDeclaration(node);
    }

    void WritePropertyGetAccessor(SyntaxToken propertyName, AccessorDeclarationSyntax accessor)
    {
        Writer.WriteLine("{", true);
        if (accessor.ExpressionBody != null)
        {
            if (accessor.ExpressionBody.Expression is not ThrowExpressionSyntax)
                Writer.Write($"return ", true);
            else
                Writer.Write($"", true);
            Visit(accessor.ExpressionBody.Expression);
            Writer.WriteLine($";");
        }
        else if (accessor.Body != null)
        {
            VisitChildren(accessor.Body.Statements);
        }
        else
        {
            Writer.WriteLine($"return _backingField_{propertyName.ValueText.Trim()};", true);
        }
        Writer.WriteLine("}", true);
    }

    void WritePropertySetAccessor(SyntaxToken propertyName, AccessorDeclarationSyntax accessor)
    {
        Writer.WriteLine("{", true);
        if (accessor.ExpressionBody != null)
        {
            Writer.Write("", true);
            Visit(accessor.ExpressionBody.Expression);
            Writer.WriteLine(";");
        }
        else if (accessor.Body != null)
        {
            VisitChildren(accessor.Body.Statements);
        }
        else
        {
            Writer.WriteLine($"_backingField_{propertyName.ValueText.Trim()} = value;", true);
        }
        Writer.WriteLine("}", true);
    }

    public override void VisitEventDeclaration(EventDeclarationSyntax node)
    {
        if (node.AccessorList != null)
        {
            bool backingFieldWritten = false;
            void EnsureWriteBackingField()
            {
                if (!backingFieldWritten)
                    Writer.WriteLine($"/*{node.Type.ToFullString().Trim()}*/ _backingField_{node.Identifier.ValueText.Trim()} = {GetDefaultValue(node.Type)};", true);
                backingFieldWritten = true;
            }
            foreach (var accessor in node.AccessorList.Accessors)
            {
                if (accessor.ExpressionBody == null && accessor.Body == null)
                    EnsureWriteBackingField();
                if (accessor.IsKind(SyntaxKind.AddAccessorDeclaration))
                {
                    Writer.WriteLine($"/*{ResolveFullTypeName(node.Type)}*/ $add_{ResolveIdentifierName(node.Identifier)}(value)", true);
                    WritePropertyGetAccessor(node.Identifier, accessor);
                }
                else if (accessor.IsKind(SyntaxKind.RemoveAccessorDeclaration))
                {
                    Writer.WriteLine($"/*{ResolveFullTypeName(node.Type)}*/ $remove_{ResolveIdentifierName(node.Identifier)}(value)", true);
                    WritePropertySetAccessor(node.Identifier, accessor);
                }
            }
        }
        else
        {

        }
        //base.VisitEventDeclaration(node);
    }

    public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        string? modifier = null;
        if (node.Modifiers.Any(e => e.ValueText == "static"))
        {
            modifier += "static ";
        }
        if (node.AccessorList != null)
        {
            bool backingFieldWritten = false;
            void EnsureWriteBackingField()
            {
                if (!backingFieldWritten)
                    Writer.WriteLine($"/*{node.Type.ToFullString().Trim()}*/ _backingField_{node.Identifier.ValueText.Trim()} = {GetDefaultValue(node.Type)};", true);
                backingFieldWritten = true;
            }
            foreach (var accessor in node.AccessorList.Accessors)
            {
                if (accessor.ExpressionBody == null && accessor.Body == null)
                    EnsureWriteBackingField();
                if (accessor.IsKind(SyntaxKind.GetAccessorDeclaration))
                {
                    Writer.WriteLine($"/*{node.Type.ToFullString().Trim()}*/ {modifier}get {node.Identifier.ValueText.Trim()}()", true);
                    WritePropertyGetAccessor(node.Identifier, accessor);
                }
                else if (accessor.IsKind(SyntaxKind.SetAccessorDeclaration))
                {
                    Writer.WriteLine($"/*{node.Type.ToFullString().Trim()}*/ {modifier}set {node.Identifier.ValueText.Trim()}(value)", true);
                    WritePropertySetAccessor(node.Identifier, accessor);
                }
            }
        }
        else if (node.ExpressionBody != null)
        {
            Writer.WriteLine($"/*{node.Type.ToFullString().Trim()}*/ {modifier}get {node.Identifier.ValueText.Trim()}()", true);
            Writer.WriteLine("{", true);
            if (node.ExpressionBody.Expression is not ThrowExpressionSyntax)
                Writer.Write($"return ", true);
            else
                Writer.Write($"", true);
            Visit(node.ExpressionBody.Expression);
            Writer.WriteLine($";");
            Writer.WriteLine("}", true);
        }
        else
        {
            Writer.WriteLine($"/*{node.Type.ToFullString().Trim()}*/ {modifier}_backingField_{node.Identifier.ValueText.Trim()} = {GetDefaultValue(node.Type)};");
            Writer.WriteLine($"/*{node.Type.ToFullString().Trim()}*/ {modifier}get_{node.Identifier.ValueText.Trim()}()");
            Writer.WriteLine($"{{");
            Writer.WriteLine($"return _backingField_{node.Identifier.ValueText.Trim()};");
            Writer.WriteLine($"}}");
            Writer.WriteLine($"/*{node.Type.ToFullString().Trim()}*/ {modifier}set_{node.Identifier.ValueText.Trim()}(value)");
            Writer.WriteLine($"{{");
            Writer.WriteLine($"return _backingField_{node.Identifier.ValueText.Trim()} = value;");
            Writer.WriteLine($"}}");
        }
    }

    public override void VisitIndexerDeclaration(IndexerDeclarationSyntax node)
    {
        string? modifier = null;
        if (node.Modifiers.Any(e => e.ValueText == "static"))
        {
            modifier += "static ";
        }
        if (node.AccessorList != null)
        {
            foreach (var accessor in node.AccessorList.Accessors)
            {
                if (accessor.IsKind(SyntaxKind.GetAccessorDeclaration))
                {
                    Writer.Write($"/*{node.Type.ToFullString().Trim()}*/ {modifier}getItem(", true);
                    WriteMethodParameters(node.ParameterList.Parameters);
                    Writer.WriteLine($")");
                    Writer.WriteLine("{", true);
                    if (accessor.ExpressionBody != null)
                    {
                        Writer.Write($"return ", true);
                        Visit(accessor.ExpressionBody.Expression);
                        Writer.WriteLine($";");
                    }
                    else if (accessor.Body != null)
                    {
                        VisitChildren(accessor.Body.Statements);
                    }
                    Writer.WriteLine("}", true);
                }
                else if (accessor.IsKind(SyntaxKind.SetAccessorDeclaration))
                {
                    Writer.Write($"/*void*/ {modifier}setItem(", true);
                    WriteMethodParameters(node.ParameterList.Parameters);
                    if (node.ParameterList.Parameters.Any())
                        Writer.Write(", ");
                    Writer.Write($"/*{node.Type.ToFullString().Trim()}*/ value");
                    Writer.WriteLine($")");
                    Writer.WriteLine("{", true);
                    if (accessor.ExpressionBody != null)
                    {
                        Writer.Write("", true);
                        Visit(accessor.ExpressionBody.Expression);
                        Writer.WriteLine(";");
                    }
                    else if (accessor.Body != null)
                    {
                        VisitChildren(accessor.Body.Statements);
                    }
                    Writer.WriteLine("}", true);
                }
            }
        }
        else if (node.ExpressionBody != null)
        {
            Writer.Write($"/*{node.Type.ToFullString().Trim()}*/ {modifier}getItem(", true);
            WriteMethodParameters(node.ParameterList.Parameters);
            Writer.WriteLine($")");
            Writer.WriteLine("{", true);
            Writer.Write($"return ", true);
            Visit(node.ExpressionBody.Expression);
            Writer.WriteLine($";");
            Writer.WriteLine("}", true);
        }
        else
        {

        }
        //base.VisitIndexerDeclaration(node);
    }

    public override void VisitAccessorDeclaration(AccessorDeclarationSyntax node)
    {
        base.VisitAccessorDeclaration(node);
    }

    public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
    {
        Writer.Write($"/*{node.Type.ToFullString().Trim()}*/ let ");
        VisitChildren(node.Variables);
        //base.VisitVariableDeclaration(node);
    }

    public override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
    {
        Writer.Write(node.Identifier.Text);
        base.VisitVariableDeclarator(node);
    }

    public override void VisitExpressionStatement(ExpressionStatementSyntax node)
    {
        Writer.Write("", true);
        base.VisitExpressionStatement(node);
        Writer.WriteLine(";");
    }

    public override void VisitLiteralExpression(LiteralExpressionSyntax node)
    {
        var txt = node.Token.Text.Trim();
        if (txt == "default")
        {
            txt = "BlazorJs.getDefault()";
        }
        else if (txt.StartsWith("@") && txt[1] == '\"' && txt.EndsWith("\"")) //handless @"jsdd" string 
        {
            txt = txt.Substring(1);
        }
        else if (txt.EndsWith("L") && int.TryParse(txt.Substring(0, txt.Length - 1), out _)) //handle 10L
        {
            txt = txt.Substring(0, txt.Length - 1);
        }
        else if (txt.EndsWith("f") && float.TryParse(txt.Substring(0, txt.Length - 1), out _)) //handle 10.0f
        {
            txt = txt.Substring(0, txt.Length - 1);
        }
        Writer.Write(txt);
        base.VisitLiteralExpression(node);
    }

    public override void VisitIdentifierName(IdentifierNameSyntax node)
    {
        Writer.Write(ResolveIdentifierName(node.Identifier));
        base.VisitIdentifierName(node);
    }

    public override void VisitPredefinedType(PredefinedTypeSyntax node)
    {
        Writer.Write(ResolveFullTypeName(node));
        base.VisitPredefinedType(node);
    }

    public override void VisitGenericName(GenericNameSyntax node)
    {
        Writer.Write(node.Identifier.ValueText);
        Writer.Write("(");
        int i = 0;
        foreach (var n in node.TypeArgumentList.Arguments)
        {
            if (i > 0)
                Writer.Write(", ");
            Visit(n);
            i++;
        }
        Writer.Write(")");
        //Writer.Write($"{ResolveFullTypeName(node.Identifier)}");
        //foreach (var n in node.TypeArgumentList.Arguments)
        //{
        //    Visit(n);
        //}
        //Writer.Write($">");
        //base.VisitGenericName(node);
    }

    public override void VisitQualifiedName(QualifiedNameSyntax node)
    {
        Visit(node.Left);
        Writer.Write("_");
        Visit(node.Right);
        //base.VisitQualifiedName(node);
    }

    public override void VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
    {
        Visit(node.Operand);
        Writer.Write($"{node.OperatorToken.ToFullString().Trim()}");
    }

    public override void VisitBinaryExpression(BinaryExpressionSyntax node)
    {
        var op = node.OperatorToken.ValueText.Trim();
        if (op == "??" && node.Right is ThrowExpressionSyntax)
        {
            Writer.Write("BlazorJs.FirstOf(");
            Visit(node.Left);
            Writer.Write(", function(){ ");
            Visit(node.Right);
            Writer.Write(" })");
        }
        else if (op == "as")
        {
            Writer.Write("BlazorJs.As(");
            Visit(node.Left);
            Writer.Write(", ");
            Visit(node.Right);
            Writer.Write(")");
        }
        else
        {
            Visit(node.Left);
            if (op == "is")
            {
                if (node.Right is LiteralExpressionSyntax)
                {
                    op = "==";
                }
                else
                {
                    op = "instanceof";
                }
            }
            else if (op == "==")
            {
                op = "===";
            }
            else if (op == "!=")
            {
                op = "!==";
            }
            Writer.Write($" {op} ");
            Visit(node.Right);
        }
        //base.VisitBinaryExpression(node);
    }

    public override void VisitAssignmentExpression(AssignmentExpressionSyntax node)
    {
        Visit(node.Left);
        Writer.Write($" {node.OperatorToken.ValueText.Trim()} ");
        if (node.Left is DeclarationExpressionSyntax)
        {
            Writer.Write("BlazorJs.Destructure(");
        }
        Visit(node.Right);
        if (node.Left is DeclarationExpressionSyntax)
        {
            Writer.Write(")");
        }
    }

    public override void VisitAwaitExpression(AwaitExpressionSyntax node)
    {
        Writer.Write($"await ");
        base.VisitAwaitExpression(node);
    }

    public override void VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
    {
        Visit(node.Expression);
        Writer.Write(".");
        if (node.Name is GenericNameSyntax gn)
        {
            Writer.Write(gn.Identifier.Text);
        }
        else
        {
            Writer.Write(node.Name.ToFullString());
        }
        //base.VisitMemberAccessExpression(node);
    }

    public override void VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
    {
        Writer.Write("(");
        base.VisitParenthesizedExpression(node);
        Writer.Write(")");
    }

    public override void VisitInvocationExpression(InvocationExpressionSyntax node)
    {
        //base.VisitInvocationExpression(node);
        VisitChildren(node.ChildNodes().Where(e => e is not ArgumentListSyntax));
        WriteMethodInvocation(node, (ArgumentListSyntax?)node.ChildNodes().FirstOrDefault(e => e is ArgumentListSyntax));
    }

    public override void VisitBlock(BlockSyntax node)
    {
        Writer.WriteLine("{", true);
        base.VisitBlock(node);
        Writer.WriteLine("}", true);
    }

    public override void VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
    {
        if (node.Expression is ThrowExpressionSyntax)
            Writer.Write("", true);
        else
            Writer.Write("return ", true);
        base.VisitArrowExpressionClause(node);
        Writer.WriteLine(";");
    }

    public override void VisitEqualsValueClause(EqualsValueClauseSyntax node)
    {
        Writer.Write(" = ");
        Visit(node.Value);
        //base.VisitEqualsValueClause(node);
    }

    public override void VisitReturnStatement(ReturnStatementSyntax node)
    {
        Writer.Write("return ", true);
        base.VisitReturnStatement(node);
        Writer.WriteLine(";");
    }

    public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
    {
        Writer.Write("", true);
        base.VisitLocalDeclarationStatement(node);
        Writer.WriteLine(";");
    }

    public override void VisitIfStatement(IfStatementSyntax node)
    {
        Writer.Write($"if (", node.Parent is not ElseClauseSyntax);
        Visit(node.Condition);
        Writer.WriteLine($")");
        Visit(node.Statement);
        if (node.Else != null)
        {
            if (node.Else.Statement is IfStatementSyntax)
            {
                Writer.Write("else ", true);
            }
            else
            {
                Writer.WriteLine("else ", true);
            }
            Visit(node.Else);
        }
        //base.VisitIfStatement(node);
    }

    public override void VisitIfDirectiveTrivia(IfDirectiveTriviaSyntax node)
    {
        base.VisitIfDirectiveTrivia(node);
    }

    public override void VisitElifDirectiveTrivia(ElifDirectiveTriviaSyntax node)
    {
        base.VisitElifDirectiveTrivia(node);
    }

    public override void VisitElseDirectiveTrivia(ElseDirectiveTriviaSyntax node)
    {
        base.VisitElseDirectiveTrivia(node);
    }

    public override void VisitIsPatternExpression(IsPatternExpressionSyntax node)
    {
        Visit(node.Expression);
        if (node.Pattern is DeclarationPatternSyntax dp)
        {
            Writer.Write($" instanceof ");
            Visit(dp.Type);
            if (node.Expression is IdentifierNameSyntax id && dp.Designation is SingleVariableDesignationSyntax svd)
            {
                Writer.Write($", {svd.Identifier} = {id}");
            }
            //Visit(d.Pattern);
        }
        //base.VisitIsPatternExpression(node);
    }

    public override void VisitForEachStatement(ForEachStatementSyntax node)
    {
        Writer.Write($"BlazorJs.forEach(", true);
        Visit(node.Expression);
        Writer.WriteLine($", function({node.Identifier.ToFullString().Trim()}, $_i)");
        Writer.WriteLine("{", true);
        VisitChildren(node.Statement.ChildNodes());
        //base.VisitForEachStatement(node);
        Writer.WriteLine("});", true);
    }

    public override void VisitForEachVariableStatement(ForEachVariableStatementSyntax node)
    {
        base.VisitForEachVariableStatement(node);
    }

    public override void VisitForStatement(ForStatementSyntax node)
    {
        Writer.Write("for(", true);
        if (node.Declaration != null)
            Visit(node.Declaration);
        Writer.Write("; ");
        if (node.Condition != null)
            Visit(node.Condition);
        Writer.Write("; ");
        int i = 0;
        foreach (var inc in node.Incrementors)
        {
            if (i > 0)
                Writer.Write(", ");
            Visit(inc);
            i++;
        }
        Writer.WriteLine(")");
        Writer.WriteLine("{", true);
        VisitChildren(node.Statement.ChildNodes());
        Writer.WriteLine("}", true);
    }

    public override void VisitWhileStatement(WhileStatementSyntax node)
    {
        Writer.Write("while(", true);
        Visit(node.Condition);
        Writer.WriteLine(")");
        Writer.WriteLine("{", true);
        if (node.Statement is BlockSyntax)
            VisitChildren(node.Statement.ChildNodes());
        else
            VisitChildren(node.ChildNodes().Except([node.Condition]));
        Writer.WriteLine("}", true);
        //base.VisitWhileStatement(node);
    }

    public override void VisitDoStatement(DoStatementSyntax node)
    {
        Writer.WriteLine("do", true);
        Writer.WriteLine("{", true);
        VisitChildren(node.Statement.ChildNodes());
        Writer.Write("} while(", true);
        Visit(node.Condition);
        Writer.WriteLine(");");
        //base.VisitDoStatement(node);
    }

    public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
    {
        bool isLiteralObject = false;
        bool hasInitializer = node.Initializer?.Expressions != null;
        if (!isLiteralObject)
        {
            Writer.Write($"{(hasInitializer ? "BlazorJs.PopulateProperty(" : "")}new ");
            Visit(node.Type);
            WriteMethodInvocation(node, (ArgumentListSyntax?)node.ChildNodes().FirstOrDefault(e => e is ArgumentListSyntax));
            if (hasInitializer)
            {
                Writer.WriteLine($", function(/*{ResolveFullTypeName(node.Type)}*/ $obj)");
                Writer.WriteLine("{", true);
                foreach (var e in node.Initializer!.Expressions)
                {
                    Writer.Write($"$obj.", true);
                    Visit(e);
                    Writer.WriteLine(";");
                }
                Writer.Write("})", true);
            }
            VisitChildren(node.ChildNodes().Where((e => e is not ArgumentListSyntax && e is not InitializerExpressionSyntax)).Except([node.Type]));
        }
        else
        {
            Writer.Write("{", true);
            if (hasInitializer)
            {
                int i = 0;
                foreach (var e in node.Initializer!.Expressions)
                {
                    if (i > 0)
                        Writer.Write(", ");
                    Visit(e);
                    i++;
                }
            }
            Writer.Write("}");
        }
        //base.VisitObjectCreationExpression(node);
    }

    //public override void VisitDeclarationPattern(DeclarationPatternSyntax node)
    //{
    //    base.VisitDeclarationPattern(node);
    //    if (node.Designation != null)
    //    {
    //        Writer.Write($", ");
    //        Visit(node.Designation);
    //    }
    //}

    public override void VisitArgument(ArgumentSyntax node)
    {
        if (node.RefKindKeyword.ValueText == "out" || node.RefKindKeyword.ValueText == "ref")
        {
            string? identifierName = null;
            if (node.Expression is DeclarationExpressionSyntax dec && dec.Designation is SingleVariableDesignationSyntax sv)
            {
                identifierName = sv.Identifier.ValueText;
                Writer.InsertInCurrentClosure($"let {identifierName} = null;", true);
            }
            else
            {
                var exp = node.ToFullString().Trim().Substring(4);
                identifierName = exp;
            }
            var i = Writer.CurrentClosure.Inserts;
            Writer.InsertInCurrentClosure($"let $ref{i} = {{ set value(v){{ {identifierName} = v }} }};", true);
            Writer.Write($"$ref{i}");
        }
        else if (node.RefKindKeyword.ValueText == "in")
        {
        }
        else
            base.VisitArgument(node);
    }

    public override void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignationSyntax node)
    {
        Writer.Write(" [ ");
        int i = 0;
        foreach (var v in node.Variables)
        {
            if (i > 0)
                Writer.Write(", ");
            Visit(v);
            i++;
        }
        Writer.Write(" ]");
        //base.VisitParenthesizedVariableDesignation(node);
    }

    public override void VisitDeclarationExpression(DeclarationExpressionSyntax node)
    {
        base.VisitDeclarationExpression(node);
    }

    public override void VisitSingleVariableDesignation(SingleVariableDesignationSyntax node)
    {
        Writer.Write(ResolveIdentifierName(node.Identifier));
        //base.VisitSingleVariableDesignation(node);
    }

    public override void VisitBaseExpression(BaseExpressionSyntax node)
    {
        Writer.Write("super");
        base.VisitBaseExpression(node);
    }

    void VisitLambdaExpression(CSharpSyntaxNode node, IEnumerable<ParameterSyntax>? lamdaParameters)
    {
        var parameters = string.Join(", ", lamdaParameters?.Select(p => $"/*{p.Type?.ToFullString().Trim()}*/ {p.Identifier.Text}") ?? Enumerable.Empty<string>());
        Writer.WriteLine($"function({parameters})");
        Writer.WriteLine("{", true);
        var child = node.ChildNodes().Where(t => t is not ParameterListSyntax && t is not ParameterSyntax);
        bool implicitReturn = false;
        if (child.Count() == 1 && child.Single() is BlockSyntax block)
        {
            child = block.Statements;
        }
        else
        {
            implicitReturn = child.Count() == 1 && child.Single() is not ReturnStatementSyntax;
        }
        if (implicitReturn)
        {
            Writer.Write("return ", true);
        }
        VisitChildren(child);
        if (implicitReturn)
        {
            Writer.WriteLine(";");
        }
        else
        {
            Writer.EnsureNewLine();
        }
        Writer.Write("}", true);
    }

    public override void VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
    {
        VisitLambdaExpression(node, node.ParameterList?.Parameters);
        //base.VisitAnonymousMethodExpression(node);
    }

    public override void VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
    {
        VisitLambdaExpression(node, node.ParameterList.Parameters);
        //base.VisitParenthesizedLambdaExpression(node);
    }

    public override void VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
    {
        VisitLambdaExpression(node, [node.Parameter]);
        //base.VisitSimpleLambdaExpression(node);
    }

    public override void VisitNameColon(NameColonSyntax node)
    {
        base.VisitNameColon(node);
        Writer.Write($" {node.ColonToken.ValueText} ");
    }

    public override void VisitInitializerExpression(InitializerExpressionSyntax node)
    {
        int i = 0;
        foreach (var n in node.Expressions)
        {
            if (i > 0)
                Writer.Write(", ");
            Visit(n);
            i++;
        }
        //base.VisitInitializerExpression(node);
    }

    public override void VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
    {
        if (node.Type.RankSpecifiers.Count == 1)
        {
            var singleRank = node.Type.RankSpecifiers.First();
            if (node.Initializer == null && singleRank.Sizes.Count == 1)
            {
                var size = singleRank.Sizes.First();
                Writer.Write($"new Array(");
                Visit(size);
                Writer.Write($")");
            }
            else
            {
                Writer.Write("[ ");
                Visit(node.Initializer);
                //base.VisitArrayCreationExpression(node);
                Writer.Write(" ]");
            }
        }
        else
        {
            Writer.Write("[ ");
            Writer.Write(" ]");
            //throw new NotImplementedException();
        }
    }

    public override void VisitArrayType(ArrayTypeSyntax node)
    {
        base.VisitArrayType(node);
    }

    public override void VisitThrowExpression(ThrowExpressionSyntax node)
    {
        Writer.Write($"throw ");
        base.VisitThrowExpression(node);
    }


    public override void VisitThrowStatement(ThrowStatementSyntax node)
    {
        Writer.Write($"throw ", true);
        base.VisitThrowStatement(node);
        if (node.Expression == null) //we must have being inside a catch if throw has no exception
        {
            var _catch = FindClosest<CatchClauseSyntax>(node);
            Writer.Write(_catch?.Declaration?.Identifier.ValueText ?? "$e");
        }
        Writer.WriteLine($";");
    }

    public override void VisitBreakStatement(BreakStatementSyntax node)
    {
        Writer.WriteLine("break;", true);
        base.VisitBreakStatement(node);
    }

    public override void VisitContinueStatement(ContinueStatementSyntax node)
    {
        Writer.WriteLine("continue;", true);
        base.VisitContinueStatement(node);
    }

    public override void VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
    {
        Writer.Write("case ", true);
        Visit(node.Value);
        Writer.WriteLine(":");
        //base.VisitCaseSwitchLabel(node);
    }

    public override void VisitCasePatternSwitchLabel(CasePatternSwitchLabelSyntax node)
    {
        Writer.Write("case ", true);
        if (node.Pattern is DeclarationPatternSyntax dps)
        {
            Visit(dps.Designation);
            Writer.Write(" = ");
            Visit(dps.Type);
        }
        else
        {
            Visit(node.Pattern);
        }
        Writer.WriteLine(":");
        //base.VisitCasePatternSwitchLabel(node);
    }

    public override void VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
    {
        Writer.WriteLine("default:", true);
        //base.VisitDefaultSwitchLabel(node);
    }

    public override void VisitSwitchSection(SwitchSectionSyntax node)
    {
        foreach (var label in node.Labels)
        {
            Visit(label);
        }
        bool childIsBlock = ChildIsBlock(node);
        if (!childIsBlock)
        {
            Writer.WriteLine("{", true);
        }
        VisitChildren(node.ChildNodes().Except(node.Labels));
        //base.VisitSwitchSection(node);
        if (!childIsBlock)
        {
            Writer.WriteLine("}", true);
        }
    }

    public override void VisitSwitchStatement(SwitchStatementSyntax node)
    {
        //if any of the case is a CasePatternSwitchLabelSyntax, use.GetType()
        bool isTypeSwitch = node.ChildNodes().Any(c => c is CasePatternSwitchLabelSyntax || (c is SwitchSectionSyntax cc && cc.Labels.Any(l => l is CasePatternSwitchLabelSyntax)));
        Writer.Write("switch(", true);
        Visit(node.Expression);
        if (isTypeSwitch)
        {
            Writer.Write("?.GetType()");
        }
        Writer.WriteLine(")");
        Writer.WriteLine("{", true);
        VisitChildren(node.ChildNodes().Except([node.Expression]));
        //base.VisitSwitchStatement(node);
        Writer.WriteLine("}", true);
    }

    public override void VisitConditionalExpression(ConditionalExpressionSyntax node)
    {
        Visit(node.Condition);
        Writer.Write(" ? ");
        if (node.WhenTrue is ThrowExpressionSyntax)
        {
            Writer.Write("BlazorJs.Execute(");
            Writer.Write("function(){ ");
            Visit(node.WhenTrue);
            Writer.Write(" })");
        }
        else
        {
            Visit(node.WhenTrue);
        }
        Writer.Write(" : ");
        if (node.WhenFalse is ThrowExpressionSyntax)
        {
            Writer.Write("BlazorJs.Execute(");
            Writer.Write("function(){ ");
            Visit(node.WhenFalse);
            Writer.Write(" })");
        }
        else
        {
            Visit(node.WhenFalse);
        }
        //base.VisitConditionalExpression(node);
    }
    public override void VisitElementAccessExpression(ElementAccessExpressionSyntax node)
    {
        Visit(node.Expression);
        Writer.Write("[");
        foreach (var a in node.ArgumentList.Arguments)
        {
            Visit(a);
        }
        Writer.Write("]");
        //base.VisitElementAccessExpression(node);
    }

    public override void VisitFinallyClause(FinallyClauseSyntax node)
    {
        Writer.WriteLine("finally", true);
        Writer.WriteLine("{", true);
        Visit(node.Block);
        Writer.WriteLine("}", true);
        //base.VisitFinallyClause(node);
    }

    public override void VisitCatchClause(CatchClauseSyntax node)
    {
        Writer.Write("catch(", true);
        if (!string.IsNullOrEmpty(node.Declaration?.Identifier.ValueText))
            Writer.Write(node.Declaration.Identifier.ValueText);
        else
            Writer.Write("$e");
        //Visit(node.Declaration);
        Writer.WriteLine(")");
        Visit(node.Block);
        //base.VisitCatchClause(node);
    }

    public override void VisitTryStatement(TryStatementSyntax node)
    {
        Writer.WriteLine("try", true);
        Visit(node.Block);
        var catches = node.ChildNodes().Where(e => e is CatchClauseSyntax).Cast<CatchClauseSyntax>();
        if (catches.Count() > 1)
        {
            Writer.WriteLine("catch($e)", true);
            Writer.WriteLine("{", true);
            foreach (var _catch in catches.Where(e => e.Declaration != null))
            {
                Writer.Write($"if($e instanceof ", true);
                Writer.Write(ResolveFullTypeName(_catch.Declaration!.Type));
                if (!string.IsNullOrEmpty(_catch.Declaration!.Identifier.ValueText))
                {
                    Writer.Write($", {_catch.Declaration!.Identifier.ValueText} = $e");
                }
                Writer.WriteLine($")");
                Visit(_catch.Block);
            }
            foreach (var _catch in catches.Where(e => e.Declaration == null))
            {
                Visit(_catch.Block);
            }
            Writer.WriteLine("}", true);
            VisitChildren(node.ChildNodes().Except([node.Block, .. catches]));
        }
        else
        {
            VisitChildren(node.ChildNodes().Except([node.Block]));
        }
        //base.VisitTryStatement(node);
    }

    public override void VisitThisExpression(ThisExpressionSyntax node)
    {
        Writer.Write("this");
        //base.VisitThisExpression(node);
    }

    public override void VisitDefaultExpression(DefaultExpressionSyntax node)
    {
        if (node.Type != null)
        {
            Visit(node.Type);
            Writer.Write($"?.default() ?? null");
        }
        else
        {
            Writer.Write("null");
        }
        //base.VisitDefaultExpression(node);
    }

    public override void VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
    {
        Writer.Write("`");
        foreach (var token in node.Contents)
        {
            if (token is InterpolatedStringTextSyntax str)
            {
                Writer.Write(str.ToFullString());
            }
            else if (token is InterpolationSyntax format)
            {
                Writer.Write("${");
                Visit(format.Expression);
                Writer.Write("}");
            }
            else
            {

            }
        }
        Writer.Write("`");
        //base.VisitInterpolatedStringExpression(node);
    }

    public override void VisitCastExpression(CastExpressionSyntax node)
    {
        Writer.Write("BlazorJs.Cast(");
        Visit(node.Expression);
        Writer.Write(", ");
        Visit(node.Type);
        Writer.Write(")");
        //base.VisitCastExpression(node);
    }

    public override void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
    {
        Visit(node.Expression);
        Writer.Write(node.OperatorToken.ToFullString());
        Visit(node.WhenNotNull);
        //base.VisitConditionalAccessExpression(node);
    }

    public override void VisitTupleExpression(TupleExpressionSyntax node)
    {
        Writer.Write("BlazorJs.TupleValue({ ");
        int i = 0;
        foreach (var e in node.Arguments)
        {
            if (i > 0)
                Writer.Write(", ");
            if (e.NameColon == null)
            {
                Writer.Write($"Item{i + 1}: ");
            }
            Visit(e);
            i++;
        }
        Writer.Write(" })");
        //base.VisitTupleExpression(node);
    }

    public override void VisitTupleType(TupleTypeSyntax node)
    {
        Writer.Write($"BlazorJs.TupleType(");
        int i = 0;
        foreach (var e in node.Elements)
        {
            if (i > 0)
                Writer.Write(", ");
            Visit(e);
            i++;
        }
        Writer.Write($")");
        //base.VisitTupleType(node);
    }

    public override void VisitLockStatement(LockStatementSyntax node)
    {
        //skip lock, js is single threaded anyway
        Writer.WriteLine("//lock", true);
        Visit(node.Statement);
        //base.VisitLockStatement(node);
    }

    public override void VisitBracketedArgumentList(BracketedArgumentListSyntax node)
    {
        Writer.Write(node.OpenBracketToken.ValueText);
        if (node.Arguments.Count > 1)
        {
            Writer.Write("getItem(");
            int i = 0;
            foreach (var a in node.Arguments)
            {
                if (i > 0)
                    Writer.Write(", ");
                Visit(a);
                i++;
            }
            Writer.Write(")");
        }
        else
        {
            int i = 0;
            foreach (var a in node.Arguments)
            {
                if (i > 0)
                    Writer.Write(", ");
                Visit(a);
                i++;
            }
        }
        Writer.Write(node.CloseBracketToken.ValueText);
        //base.VisitBracketedArgumentList(node);
    }

    public override void VisitMemberBindingExpression(MemberBindingExpressionSyntax node)
    {
        Writer.Write(node.OperatorToken.ValueText);
        Visit(node.Name);
        //base.VisitMemberBindingExpression(node);
    }

    public override void VisitQueryExpression(QueryExpressionSyntax node)
    {
        base.VisitQueryExpression(node);
    }

    public override void VisitElementBindingExpression(ElementBindingExpressionSyntax node)
    {
        base.VisitElementBindingExpression(node);
    }

    public override void VisitInterpolatedStringText(InterpolatedStringTextSyntax node)
    {
        base.VisitInterpolatedStringText(node);
    }

    public override void VisitTypeConstraint(TypeConstraintSyntax node)
    {
        //base.VisitTypeConstraint(node);
    }

    public override void VisitAttribute(AttributeSyntax node)
    {
        //base.VisitAttribute(node);
    }

    public override string ToString()
    {
        return Writer.ToString();
    }
}