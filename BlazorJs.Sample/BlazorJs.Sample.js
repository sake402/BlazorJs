const BlazorJs_Sample_Interface1 = (Base) => class extends Base
{
    /*void*/ A()
    {
        /*int*/ let start = 0;
        while(start < 10)
        {
            start++;
        }
    }
}
class BlazorJs_Sample_Component1 extends BlazorJs_Sample_Interface1(Microsoft_AspNetCore_Components_ComponentBase)
{
    /*void*/ A()
    {
    }
    constructor(/*int*/ i)
    {
        super();
    }
    /*void*/ Add(T, { /*Action<T>*/ attributeBuilder = null})
    {
    }
    /*Task*/ async OnInitializedAsync()
    {
        descriptor = await Http.GetFromJsonAsync(BlazorWasmAppDescriptor, "https://sake.org.ng/wasm.app.json");
        html = await Http.GetStringAsync("https://google.com");
        await super.OnInitializedAsync();
    }
    /*void*/ DO(/*int*/ a)
    {
        field1 = field1 + 1;
        /*var*/ let ff = field1.ToString();
    }
    /*HTMLElement*/ input = null;
    /*int*/ field1 = null;
    /*int*/ field2 = null;
    /*RenderFragment*/ view = null;
    /*HttpClient*/ _http = null;
    /*HttpClient*/ get MHttp()
    {
        return _http;
    }
    /*HttpClient*/ set MHttp(value)
    {
        _http = value;
    }
    /*HttpClient*/ _backingField_Http = null;
    /*HttpClient*/ get Http()
    {
        return _backingField_Http;
    }
    /*HttpClient*/ set Http(value)
    {
        _backingField_Http = value;
    }
    /*string*/ _backingField_Property1 = null;
    /*string*/ get Property1()
    {
        return _backingField_Property1;
    }
    /*string*/ set Property1(value)
    {
        _backingField_Property1 = value;
    }
    /*void*/ Clicked1()
    {
        field1++;
    }
    /*void*/ Clicked()
    {
        field1++;
    }
    /*MarkupString*/ html = null;
    /*BlazorWasmAppDescriptor*/ descriptor = null;
    class BlazorJs_Sample_BlazorWasmAppFile extends object
    {
        constructor()
        {
            super();
        }
        /*string*/ _backingField_Path = null;
        /*string*/ get Path()
        {
            return _backingField_Path;
        }
        /*string*/ set Path(value)
        {
            _backingField_Path = value;
        }
        /*string*/ _backingField_Hash = null;
        /*string*/ get Hash()
        {
            return _backingField_Hash;
        }
        /*string*/ set Hash(value)
        {
            _backingField_Hash = value;
        }
        /*long*/ _backingField_Size = null;
        /*long*/ get Size()
        {
            return _backingField_Size;
        }
        /*long*/ set Size(value)
        {
            _backingField_Size = value;
        }
        /*DateTime*/ _backingField_DateModified = null;
        /*DateTime*/ get DateModified()
        {
            return _backingField_DateModified;
        }
        /*DateTime*/ set DateModified(value)
        {
            _backingField_DateModified = value;
        }
        /*string*/ ToString()
        {
            return Path;
        }
        /*int*/ GetHashCode()
        {
            return Path.GetHashCode();
        }
        /*bool*/ Equals(/*object*/ obj)
        {
            if (obj instanceof BlazorWasmAppFile, f = obj)
            {
                return f.Path  == Path;
            }
            return super.Equals(obj);
        }
    }
    class BlazorJs_Sample_BlazorWasmAppDescriptor extends object
    {
        constructor()
        {
            super();
        }
        /*string*/ _backingField_Version = null;
        /*string*/ get Version()
        {
            return _backingField_Version;
        }
        /*string*/ set Version(value)
        {
            _backingField_Version = value;
        }
        /*long*/ _backingField_Size = null;
        /*long*/ get Size()
        {
            return _backingField_Size;
        }
        /*long*/ set Size(value)
        {
            _backingField_Size = value;
        }
        /*IEnumerable<BlazorWasmAppFile>*/ _backingField_Files = null;
        /*IEnumerable<BlazorWasmAppFile>*/ get Files()
        {
            return _backingField_Files;
        }
        /*IEnumerable<BlazorWasmAppFile>*/ set Files(value)
        {
            _backingField_Files = value;
        }
    }
}

class BlazorJs_Sample_Component2 extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*int*/ field1 = null;
    /*int*/ field2 = null;
    /*RenderFragment*/ view = null;
    /*string*/ _backingField_Property1 = null;
    /*string*/ get Property1()
    {
        return _backingField_Property1;
    }
    /*string*/ set Property1(value)
    {
        _backingField_Property1 = value;
    }
    /*int*/ _backingField_Property2 = null;
    /*int*/ get Property2()
    {
        return _backingField_Property2;
    }
    /*int*/ set Property2(value)
    {
        _backingField_Property2 = value;
    }
    /*RenderFragment<string>*/ _backingField_ChildContent = null;
    /*RenderFragment<string>*/ get ChildContent()
    {
        return _backingField_ChildContent;
    }
    /*RenderFragment<string>*/ set ChildContent(value)
    {
        _backingField_ChildContent = value;
    }
    /*RenderFragment*/ _backingField_Property3 = null;
    /*RenderFragment*/ get Property3()
    {
        return _backingField_Property3;
    }
    /*RenderFragment*/ set Property3(value)
    {
        _backingField_Property3 = value;
    }
    /*RenderFragment<int>*/ _backingField_Property4 = null;
    /*RenderFragment<int>*/ get Property4()
    {
        return _backingField_Property4;
    }
    /*RenderFragment<int>*/ set Property4(value)
    {
        _backingField_Property4 = value;
    }
    /*Component1*/ _backingField_C1 = null;
    /*Component1*/ get C1()
    {
        return _backingField_C1;
    }
    /*Component1*/ set C1(value)
    {
        _backingField_C1 = value;
    }
}

const BlazorJs_Sample_GenericComponent1$_2 = (T1, T2) => class extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
        T1 = $_T1;
        T2 = $_T2;
    }
}
const BlazorJs_Sample_GenericComponent1Up$_2 = (T1, T2) => class extends BlazorJs_Sample_GenericComponent1(T1, T2)
{
    constructor()
    {
        super();
        T1 = $_T1;
        T2 = $_T2;
    }
}

const BlazorJs_Sample_GenericComponent2$_2 = (T1, T2) => class extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
        T1 = $_T1;
        T2 = $_T2;
    }
}

class BlazorJs_Sample_Program extends object
{
    constructor()
    {
        super();
    }
    /*void*/ Main(/*string[]*/ args)
    {
        GeneratedStartup.Run();
        BrowserApplicationBuilder.Create(Routes, function(/**/ app)
        {
        }, function(/**/ router)
        {
            {
            }
        });
    }
}




class H5_Core_webgl2 extends object
{
    constructor()
    {
        super();
    }
    /*webgl2.WebGL2RenderingContextTypeConfig*/ _backingField_WebGL2RenderingContextType = null;
    /*webgl2.WebGL2RenderingContextTypeConfig*/ get WebGL2RenderingContextType()
    {
        return _backingField_WebGL2RenderingContextType;
    }
    /*webgl2.WebGL2RenderingContextTypeConfig*/ set WebGL2RenderingContextType(value)
    {
        _backingField_WebGL2RenderingContextType = value;
    }
    /*webgl2.WebGLQueryTypeConfig*/ _backingField_WebGLQueryType = null;
    /*webgl2.WebGLQueryTypeConfig*/ get WebGLQueryType()
    {
        return _backingField_WebGLQueryType;
    }
    /*webgl2.WebGLQueryTypeConfig*/ set WebGLQueryType(value)
    {
        _backingField_WebGLQueryType = value;
    }
    /*webgl2.WebGLSamplerTypeConfig*/ _backingField_WebGLSamplerType = null;
    /*webgl2.WebGLSamplerTypeConfig*/ get WebGLSamplerType()
    {
        return _backingField_WebGLSamplerType;
    }
    /*webgl2.WebGLSamplerTypeConfig*/ set WebGLSamplerType(value)
    {
        _backingField_WebGLSamplerType = value;
    }
    /*webgl2.WebGLSyncTypeConfig*/ _backingField_WebGLSyncType = null;
    /*webgl2.WebGLSyncTypeConfig*/ get WebGLSyncType()
    {
        return _backingField_WebGLSyncType;
    }
    /*webgl2.WebGLSyncTypeConfig*/ set WebGLSyncType(value)
    {
        _backingField_WebGLSyncType = value;
    }
    /*webgl2.WebGLTransformFeedbackTypeConfig*/ _backingField_WebGLTransformFeedbackType = null;
    /*webgl2.WebGLTransformFeedbackTypeConfig*/ get WebGLTransformFeedbackType()
    {
        return _backingField_WebGLTransformFeedbackType;
    }
    /*webgl2.WebGLTransformFeedbackTypeConfig*/ set WebGLTransformFeedbackType(value)
    {
        _backingField_WebGLTransformFeedbackType = value;
    }
    /*webgl2.WebGLVertexArrayObjectTypeConfig*/ _backingField_WebGLVertexArrayObjectType = null;
    /*webgl2.WebGLVertexArrayObjectTypeConfig*/ get WebGLVertexArrayObjectType()
    {
        return _backingField_WebGLVertexArrayObjectType;
    }
    /*webgl2.WebGLVertexArrayObjectTypeConfig*/ set WebGLVertexArrayObjectType(value)
    {
        _backingField_WebGLVertexArrayObjectType = value;
    }
    class H5_Core_HTMLCanvasElement extends H5_Core_IObject(H5_Core_dom_ElementCSSInlineStyle_Interface(H5_Core_dom_HTMLCanvasElement))
    {
        constructor()
        {
            super();
        }
    }
    class H5_Core_ImageBitmap extends H5_Core_dom_ImageBitmap
    {
        constructor()
        {
            super();
        }
    }
    class H5_Core_WebGL2RenderingContext extends H5_Core_dom_WebGLRenderingContext
    {
        constructor()
        {
            super();
        }
        /*webgl2.WebGL2RenderingContext*/ _backingField_prototype = null;
        /*webgl2.WebGL2RenderingContext*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGL2RenderingContext*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
        /*double*/ _backingField_ACTIVE_ATTRIBUTES = null;
        /*double*/ get ACTIVE_ATTRIBUTES()
        {
            return _backingField_ACTIVE_ATTRIBUTES;
        }
        /*double*/ _backingField_ACTIVE_TEXTURE = null;
        /*double*/ get ACTIVE_TEXTURE()
        {
            return _backingField_ACTIVE_TEXTURE;
        }
        /*double*/ _backingField_ACTIVE_UNIFORMS = null;
        /*double*/ get ACTIVE_UNIFORMS()
        {
            return _backingField_ACTIVE_UNIFORMS;
        }
        /*double*/ _backingField_ALIASED_LINE_WIDTH_RANGE = null;
        /*double*/ get ALIASED_LINE_WIDTH_RANGE()
        {
            return _backingField_ALIASED_LINE_WIDTH_RANGE;
        }
        /*double*/ _backingField_ALIASED_POINT_SIZE_RANGE = null;
        /*double*/ get ALIASED_POINT_SIZE_RANGE()
        {
            return _backingField_ALIASED_POINT_SIZE_RANGE;
        }
        /*double*/ _backingField_ALPHA = null;
        /*double*/ get ALPHA()
        {
            return _backingField_ALPHA;
        }
        /*double*/ _backingField_ALPHA_BITS = null;
        /*double*/ get ALPHA_BITS()
        {
            return _backingField_ALPHA_BITS;
        }
        /*double*/ _backingField_ALWAYS = null;
        /*double*/ get ALWAYS()
        {
            return _backingField_ALWAYS;
        }
        /*double*/ _backingField_ARRAY_BUFFER = null;
        /*double*/ get ARRAY_BUFFER()
        {
            return _backingField_ARRAY_BUFFER;
        }
        /*double*/ _backingField_ARRAY_BUFFER_BINDING = null;
        /*double*/ get ARRAY_BUFFER_BINDING()
        {
            return _backingField_ARRAY_BUFFER_BINDING;
        }
        /*double*/ _backingField_ATTACHED_SHADERS = null;
        /*double*/ get ATTACHED_SHADERS()
        {
            return _backingField_ATTACHED_SHADERS;
        }
        /*double*/ _backingField_BACK = null;
        /*double*/ get BACK()
        {
            return _backingField_BACK;
        }
        /*double*/ _backingField_BLEND = null;
        /*double*/ get BLEND()
        {
            return _backingField_BLEND;
        }
        /*double*/ _backingField_BLEND_COLOR = null;
        /*double*/ get BLEND_COLOR()
        {
            return _backingField_BLEND_COLOR;
        }
        /*double*/ _backingField_BLEND_DST_ALPHA = null;
        /*double*/ get BLEND_DST_ALPHA()
        {
            return _backingField_BLEND_DST_ALPHA;
        }
        /*double*/ _backingField_BLEND_DST_RGB = null;
        /*double*/ get BLEND_DST_RGB()
        {
            return _backingField_BLEND_DST_RGB;
        }
        /*double*/ _backingField_BLEND_EQUATION = null;
        /*double*/ get BLEND_EQUATION()
        {
            return _backingField_BLEND_EQUATION;
        }
        /*double*/ _backingField_BLEND_EQUATION_ALPHA = null;
        /*double*/ get BLEND_EQUATION_ALPHA()
        {
            return _backingField_BLEND_EQUATION_ALPHA;
        }
        /*double*/ _backingField_BLEND_EQUATION_RGB = null;
        /*double*/ get BLEND_EQUATION_RGB()
        {
            return _backingField_BLEND_EQUATION_RGB;
        }
        /*double*/ _backingField_BLEND_SRC_ALPHA = null;
        /*double*/ get BLEND_SRC_ALPHA()
        {
            return _backingField_BLEND_SRC_ALPHA;
        }
        /*double*/ _backingField_BLEND_SRC_RGB = null;
        /*double*/ get BLEND_SRC_RGB()
        {
            return _backingField_BLEND_SRC_RGB;
        }
        /*double*/ _backingField_BLUE_BITS = null;
        /*double*/ get BLUE_BITS()
        {
            return _backingField_BLUE_BITS;
        }
        /*double*/ _backingField_BOOL = null;
        /*double*/ get BOOL()
        {
            return _backingField_BOOL;
        }
        /*double*/ _backingField_BOOL_VEC2 = null;
        /*double*/ get BOOL_VEC2()
        {
            return _backingField_BOOL_VEC2;
        }
        /*double*/ _backingField_BOOL_VEC3 = null;
        /*double*/ get BOOL_VEC3()
        {
            return _backingField_BOOL_VEC3;
        }
        /*double*/ _backingField_BOOL_VEC4 = null;
        /*double*/ get BOOL_VEC4()
        {
            return _backingField_BOOL_VEC4;
        }
        /*double*/ _backingField_BROWSER_DEFAULT_WEBGL = null;
        /*double*/ get BROWSER_DEFAULT_WEBGL()
        {
            return _backingField_BROWSER_DEFAULT_WEBGL;
        }
        /*double*/ _backingField_BUFFER_SIZE = null;
        /*double*/ get BUFFER_SIZE()
        {
            return _backingField_BUFFER_SIZE;
        }
        /*double*/ _backingField_BUFFER_USAGE = null;
        /*double*/ get BUFFER_USAGE()
        {
            return _backingField_BUFFER_USAGE;
        }
        /*double*/ _backingField_BYTE = null;
        /*double*/ get BYTE()
        {
            return _backingField_BYTE;
        }
        /*double*/ _backingField_CCW = null;
        /*double*/ get CCW()
        {
            return _backingField_CCW;
        }
        /*double*/ _backingField_CLAMP_TO_EDGE = null;
        /*double*/ get CLAMP_TO_EDGE()
        {
            return _backingField_CLAMP_TO_EDGE;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT0 = null;
        /*double*/ get COLOR_ATTACHMENT0()
        {
            return _backingField_COLOR_ATTACHMENT0;
        }
        /*double*/ _backingField_COLOR_BUFFER_BIT = null;
        /*double*/ get COLOR_BUFFER_BIT()
        {
            return _backingField_COLOR_BUFFER_BIT;
        }
        /*double*/ _backingField_COLOR_CLEAR_VALUE = null;
        /*double*/ get COLOR_CLEAR_VALUE()
        {
            return _backingField_COLOR_CLEAR_VALUE;
        }
        /*double*/ _backingField_COLOR_WRITEMASK = null;
        /*double*/ get COLOR_WRITEMASK()
        {
            return _backingField_COLOR_WRITEMASK;
        }
        /*double*/ _backingField_COMPILE_STATUS = null;
        /*double*/ get COMPILE_STATUS()
        {
            return _backingField_COMPILE_STATUS;
        }
        /*double*/ _backingField_COMPRESSED_TEXTURE_FORMATS = null;
        /*double*/ get COMPRESSED_TEXTURE_FORMATS()
        {
            return _backingField_COMPRESSED_TEXTURE_FORMATS;
        }
        /*double*/ _backingField_CONSTANT_ALPHA = null;
        /*double*/ get CONSTANT_ALPHA()
        {
            return _backingField_CONSTANT_ALPHA;
        }
        /*double*/ _backingField_CONSTANT_COLOR = null;
        /*double*/ get CONSTANT_COLOR()
        {
            return _backingField_CONSTANT_COLOR;
        }
        /*double*/ _backingField_CONTEXT_LOST_WEBGL = null;
        /*double*/ get CONTEXT_LOST_WEBGL()
        {
            return _backingField_CONTEXT_LOST_WEBGL;
        }
        /*double*/ _backingField_CULL_FACE = null;
        /*double*/ get CULL_FACE()
        {
            return _backingField_CULL_FACE;
        }
        /*double*/ _backingField_CULL_FACE_MODE = null;
        /*double*/ get CULL_FACE_MODE()
        {
            return _backingField_CULL_FACE_MODE;
        }
        /*double*/ _backingField_CURRENT_PROGRAM = null;
        /*double*/ get CURRENT_PROGRAM()
        {
            return _backingField_CURRENT_PROGRAM;
        }
        /*double*/ _backingField_CURRENT_VERTEX_ATTRIB = null;
        /*double*/ get CURRENT_VERTEX_ATTRIB()
        {
            return _backingField_CURRENT_VERTEX_ATTRIB;
        }
        /*double*/ _backingField_CW = null;
        /*double*/ get CW()
        {
            return _backingField_CW;
        }
        /*double*/ _backingField_DECR = null;
        /*double*/ get DECR()
        {
            return _backingField_DECR;
        }
        /*double*/ _backingField_DECR_WRAP = null;
        /*double*/ get DECR_WRAP()
        {
            return _backingField_DECR_WRAP;
        }
        /*double*/ _backingField_DELETE_STATUS = null;
        /*double*/ get DELETE_STATUS()
        {
            return _backingField_DELETE_STATUS;
        }
        /*double*/ _backingField_DEPTH_ATTACHMENT = null;
        /*double*/ get DEPTH_ATTACHMENT()
        {
            return _backingField_DEPTH_ATTACHMENT;
        }
        /*double*/ _backingField_DEPTH_BITS = null;
        /*double*/ get DEPTH_BITS()
        {
            return _backingField_DEPTH_BITS;
        }
        /*double*/ _backingField_DEPTH_BUFFER_BIT = null;
        /*double*/ get DEPTH_BUFFER_BIT()
        {
            return _backingField_DEPTH_BUFFER_BIT;
        }
        /*double*/ _backingField_DEPTH_CLEAR_VALUE = null;
        /*double*/ get DEPTH_CLEAR_VALUE()
        {
            return _backingField_DEPTH_CLEAR_VALUE;
        }
        /*double*/ _backingField_DEPTH_COMPONENT = null;
        /*double*/ get DEPTH_COMPONENT()
        {
            return _backingField_DEPTH_COMPONENT;
        }
        /*double*/ _backingField_DEPTH_COMPONENT16 = null;
        /*double*/ get DEPTH_COMPONENT16()
        {
            return _backingField_DEPTH_COMPONENT16;
        }
        /*double*/ _backingField_DEPTH_FUNC = null;
        /*double*/ get DEPTH_FUNC()
        {
            return _backingField_DEPTH_FUNC;
        }
        /*double*/ _backingField_DEPTH_RANGE = null;
        /*double*/ get DEPTH_RANGE()
        {
            return _backingField_DEPTH_RANGE;
        }
        /*double*/ _backingField_DEPTH_STENCIL = null;
        /*double*/ get DEPTH_STENCIL()
        {
            return _backingField_DEPTH_STENCIL;
        }
        /*double*/ _backingField_DEPTH_STENCIL_ATTACHMENT = null;
        /*double*/ get DEPTH_STENCIL_ATTACHMENT()
        {
            return _backingField_DEPTH_STENCIL_ATTACHMENT;
        }
        /*double*/ _backingField_DEPTH_TEST = null;
        /*double*/ get DEPTH_TEST()
        {
            return _backingField_DEPTH_TEST;
        }
        /*double*/ _backingField_DEPTH_WRITEMASK = null;
        /*double*/ get DEPTH_WRITEMASK()
        {
            return _backingField_DEPTH_WRITEMASK;
        }
        /*double*/ _backingField_DITHER = null;
        /*double*/ get DITHER()
        {
            return _backingField_DITHER;
        }
        /*double*/ _backingField_DONT_CARE = null;
        /*double*/ get DONT_CARE()
        {
            return _backingField_DONT_CARE;
        }
        /*double*/ _backingField_DST_ALPHA = null;
        /*double*/ get DST_ALPHA()
        {
            return _backingField_DST_ALPHA;
        }
        /*double*/ _backingField_DST_COLOR = null;
        /*double*/ get DST_COLOR()
        {
            return _backingField_DST_COLOR;
        }
        /*double*/ _backingField_DYNAMIC_DRAW = null;
        /*double*/ get DYNAMIC_DRAW()
        {
            return _backingField_DYNAMIC_DRAW;
        }
        /*double*/ _backingField_ELEMENT_ARRAY_BUFFER = null;
        /*double*/ get ELEMENT_ARRAY_BUFFER()
        {
            return _backingField_ELEMENT_ARRAY_BUFFER;
        }
        /*double*/ _backingField_ELEMENT_ARRAY_BUFFER_BINDING = null;
        /*double*/ get ELEMENT_ARRAY_BUFFER_BINDING()
        {
            return _backingField_ELEMENT_ARRAY_BUFFER_BINDING;
        }
        /*double*/ _backingField_EQUAL = null;
        /*double*/ get EQUAL()
        {
            return _backingField_EQUAL;
        }
        /*double*/ _backingField_FASTEST = null;
        /*double*/ get FASTEST()
        {
            return _backingField_FASTEST;
        }
        /*double*/ _backingField_FLOAT = null;
        /*double*/ get FLOAT()
        {
            return _backingField_FLOAT;
        }
        /*double*/ _backingField_FLOAT_MAT2 = null;
        /*double*/ get FLOAT_MAT2()
        {
            return _backingField_FLOAT_MAT2;
        }
        /*double*/ _backingField_FLOAT_MAT3 = null;
        /*double*/ get FLOAT_MAT3()
        {
            return _backingField_FLOAT_MAT3;
        }
        /*double*/ _backingField_FLOAT_MAT4 = null;
        /*double*/ get FLOAT_MAT4()
        {
            return _backingField_FLOAT_MAT4;
        }
        /*double*/ _backingField_FLOAT_VEC2 = null;
        /*double*/ get FLOAT_VEC2()
        {
            return _backingField_FLOAT_VEC2;
        }
        /*double*/ _backingField_FLOAT_VEC3 = null;
        /*double*/ get FLOAT_VEC3()
        {
            return _backingField_FLOAT_VEC3;
        }
        /*double*/ _backingField_FLOAT_VEC4 = null;
        /*double*/ get FLOAT_VEC4()
        {
            return _backingField_FLOAT_VEC4;
        }
        /*double*/ _backingField_FRAGMENT_SHADER = null;
        /*double*/ get FRAGMENT_SHADER()
        {
            return _backingField_FRAGMENT_SHADER;
        }
        /*double*/ _backingField_FRAMEBUFFER = null;
        /*double*/ get FRAMEBUFFER()
        {
            return _backingField_FRAMEBUFFER;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_OBJECT_NAME()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL;
        }
        /*double*/ _backingField_FRAMEBUFFER_BINDING = null;
        /*double*/ get FRAMEBUFFER_BINDING()
        {
            return _backingField_FRAMEBUFFER_BINDING;
        }
        /*double*/ _backingField_FRAMEBUFFER_COMPLETE = null;
        /*double*/ get FRAMEBUFFER_COMPLETE()
        {
            return _backingField_FRAMEBUFFER_COMPLETE;
        }
        /*double*/ _backingField_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = null;
        /*double*/ get FRAMEBUFFER_INCOMPLETE_ATTACHMENT()
        {
            return _backingField_FRAMEBUFFER_INCOMPLETE_ATTACHMENT;
        }
        /*double*/ _backingField_FRAMEBUFFER_INCOMPLETE_DIMENSIONS = null;
        /*double*/ get FRAMEBUFFER_INCOMPLETE_DIMENSIONS()
        {
            return _backingField_FRAMEBUFFER_INCOMPLETE_DIMENSIONS;
        }
        /*double*/ _backingField_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = null;
        /*double*/ get FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT()
        {
            return _backingField_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT;
        }
        /*double*/ _backingField_FRAMEBUFFER_UNSUPPORTED = null;
        /*double*/ get FRAMEBUFFER_UNSUPPORTED()
        {
            return _backingField_FRAMEBUFFER_UNSUPPORTED;
        }
        /*double*/ _backingField_FRONT = null;
        /*double*/ get FRONT()
        {
            return _backingField_FRONT;
        }
        /*double*/ _backingField_FRONT_AND_BACK = null;
        /*double*/ get FRONT_AND_BACK()
        {
            return _backingField_FRONT_AND_BACK;
        }
        /*double*/ _backingField_FRONT_FACE = null;
        /*double*/ get FRONT_FACE()
        {
            return _backingField_FRONT_FACE;
        }
        /*double*/ _backingField_FUNC_ADD = null;
        /*double*/ get FUNC_ADD()
        {
            return _backingField_FUNC_ADD;
        }
        /*double*/ _backingField_FUNC_REVERSE_SUBTRACT = null;
        /*double*/ get FUNC_REVERSE_SUBTRACT()
        {
            return _backingField_FUNC_REVERSE_SUBTRACT;
        }
        /*double*/ _backingField_FUNC_SUBTRACT = null;
        /*double*/ get FUNC_SUBTRACT()
        {
            return _backingField_FUNC_SUBTRACT;
        }
        /*double*/ _backingField_GENERATE_MIPMAP_HINT = null;
        /*double*/ get GENERATE_MIPMAP_HINT()
        {
            return _backingField_GENERATE_MIPMAP_HINT;
        }
        /*double*/ _backingField_GEQUAL = null;
        /*double*/ get GEQUAL()
        {
            return _backingField_GEQUAL;
        }
        /*double*/ _backingField_GREATER = null;
        /*double*/ get GREATER()
        {
            return _backingField_GREATER;
        }
        /*double*/ _backingField_GREEN_BITS = null;
        /*double*/ get GREEN_BITS()
        {
            return _backingField_GREEN_BITS;
        }
        /*double*/ _backingField_HIGH_FLOAT = null;
        /*double*/ get HIGH_FLOAT()
        {
            return _backingField_HIGH_FLOAT;
        }
        /*double*/ _backingField_HIGH_INT = null;
        /*double*/ get HIGH_INT()
        {
            return _backingField_HIGH_INT;
        }
        /*double*/ _backingField_IMPLEMENTATION_COLOR_READ_FORMAT = null;
        /*double*/ get IMPLEMENTATION_COLOR_READ_FORMAT()
        {
            return _backingField_IMPLEMENTATION_COLOR_READ_FORMAT;
        }
        /*double*/ _backingField_IMPLEMENTATION_COLOR_READ_TYPE = null;
        /*double*/ get IMPLEMENTATION_COLOR_READ_TYPE()
        {
            return _backingField_IMPLEMENTATION_COLOR_READ_TYPE;
        }
        /*double*/ _backingField_INCR = null;
        /*double*/ get INCR()
        {
            return _backingField_INCR;
        }
        /*double*/ _backingField_INCR_WRAP = null;
        /*double*/ get INCR_WRAP()
        {
            return _backingField_INCR_WRAP;
        }
        /*double*/ _backingField_INT = null;
        /*double*/ get INT()
        {
            return _backingField_INT;
        }
        /*double*/ _backingField_INT_VEC2 = null;
        /*double*/ get INT_VEC2()
        {
            return _backingField_INT_VEC2;
        }
        /*double*/ _backingField_INT_VEC3 = null;
        /*double*/ get INT_VEC3()
        {
            return _backingField_INT_VEC3;
        }
        /*double*/ _backingField_INT_VEC4 = null;
        /*double*/ get INT_VEC4()
        {
            return _backingField_INT_VEC4;
        }
        /*double*/ _backingField_INVALID_ENUM = null;
        /*double*/ get INVALID_ENUM()
        {
            return _backingField_INVALID_ENUM;
        }
        /*double*/ _backingField_INVALID_FRAMEBUFFER_OPERATION = null;
        /*double*/ get INVALID_FRAMEBUFFER_OPERATION()
        {
            return _backingField_INVALID_FRAMEBUFFER_OPERATION;
        }
        /*double*/ _backingField_INVALID_OPERATION = null;
        /*double*/ get INVALID_OPERATION()
        {
            return _backingField_INVALID_OPERATION;
        }
        /*double*/ _backingField_INVALID_VALUE = null;
        /*double*/ get INVALID_VALUE()
        {
            return _backingField_INVALID_VALUE;
        }
        /*double*/ _backingField_INVERT = null;
        /*double*/ get INVERT()
        {
            return _backingField_INVERT;
        }
        /*double*/ _backingField_KEEP = null;
        /*double*/ get KEEP()
        {
            return _backingField_KEEP;
        }
        /*double*/ _backingField_LEQUAL = null;
        /*double*/ get LEQUAL()
        {
            return _backingField_LEQUAL;
        }
        /*double*/ _backingField_LESS = null;
        /*double*/ get LESS()
        {
            return _backingField_LESS;
        }
        /*double*/ _backingField_LINEAR = null;
        /*double*/ get LINEAR()
        {
            return _backingField_LINEAR;
        }
        /*double*/ _backingField_LINEAR_MIPMAP_LINEAR = null;
        /*double*/ get LINEAR_MIPMAP_LINEAR()
        {
            return _backingField_LINEAR_MIPMAP_LINEAR;
        }
        /*double*/ _backingField_LINEAR_MIPMAP_NEAREST = null;
        /*double*/ get LINEAR_MIPMAP_NEAREST()
        {
            return _backingField_LINEAR_MIPMAP_NEAREST;
        }
        /*double*/ _backingField_LINES = null;
        /*double*/ get LINES()
        {
            return _backingField_LINES;
        }
        /*double*/ _backingField_LINE_LOOP = null;
        /*double*/ get LINE_LOOP()
        {
            return _backingField_LINE_LOOP;
        }
        /*double*/ _backingField_LINE_STRIP = null;
        /*double*/ get LINE_STRIP()
        {
            return _backingField_LINE_STRIP;
        }
        /*double*/ _backingField_LINE_WIDTH = null;
        /*double*/ get LINE_WIDTH()
        {
            return _backingField_LINE_WIDTH;
        }
        /*double*/ _backingField_LINK_STATUS = null;
        /*double*/ get LINK_STATUS()
        {
            return _backingField_LINK_STATUS;
        }
        /*double*/ _backingField_LOW_FLOAT = null;
        /*double*/ get LOW_FLOAT()
        {
            return _backingField_LOW_FLOAT;
        }
        /*double*/ _backingField_LOW_INT = null;
        /*double*/ get LOW_INT()
        {
            return _backingField_LOW_INT;
        }
        /*double*/ _backingField_LUMINANCE = null;
        /*double*/ get LUMINANCE()
        {
            return _backingField_LUMINANCE;
        }
        /*double*/ _backingField_LUMINANCE_ALPHA = null;
        /*double*/ get LUMINANCE_ALPHA()
        {
            return _backingField_LUMINANCE_ALPHA;
        }
        /*double*/ _backingField_MAX_COMBINED_TEXTURE_IMAGE_UNITS = null;
        /*double*/ get MAX_COMBINED_TEXTURE_IMAGE_UNITS()
        {
            return _backingField_MAX_COMBINED_TEXTURE_IMAGE_UNITS;
        }
        /*double*/ _backingField_MAX_CUBE_MAP_TEXTURE_SIZE = null;
        /*double*/ get MAX_CUBE_MAP_TEXTURE_SIZE()
        {
            return _backingField_MAX_CUBE_MAP_TEXTURE_SIZE;
        }
        /*double*/ _backingField_MAX_FRAGMENT_UNIFORM_VECTORS = null;
        /*double*/ get MAX_FRAGMENT_UNIFORM_VECTORS()
        {
            return _backingField_MAX_FRAGMENT_UNIFORM_VECTORS;
        }
        /*double*/ _backingField_MAX_RENDERBUFFER_SIZE = null;
        /*double*/ get MAX_RENDERBUFFER_SIZE()
        {
            return _backingField_MAX_RENDERBUFFER_SIZE;
        }
        /*double*/ _backingField_MAX_TEXTURE_IMAGE_UNITS = null;
        /*double*/ get MAX_TEXTURE_IMAGE_UNITS()
        {
            return _backingField_MAX_TEXTURE_IMAGE_UNITS;
        }
        /*double*/ _backingField_MAX_TEXTURE_SIZE = null;
        /*double*/ get MAX_TEXTURE_SIZE()
        {
            return _backingField_MAX_TEXTURE_SIZE;
        }
        /*double*/ _backingField_MAX_VARYING_VECTORS = null;
        /*double*/ get MAX_VARYING_VECTORS()
        {
            return _backingField_MAX_VARYING_VECTORS;
        }
        /*double*/ _backingField_MAX_VERTEX_ATTRIBS = null;
        /*double*/ get MAX_VERTEX_ATTRIBS()
        {
            return _backingField_MAX_VERTEX_ATTRIBS;
        }
        /*double*/ _backingField_MAX_VERTEX_TEXTURE_IMAGE_UNITS = null;
        /*double*/ get MAX_VERTEX_TEXTURE_IMAGE_UNITS()
        {
            return _backingField_MAX_VERTEX_TEXTURE_IMAGE_UNITS;
        }
        /*double*/ _backingField_MAX_VERTEX_UNIFORM_VECTORS = null;
        /*double*/ get MAX_VERTEX_UNIFORM_VECTORS()
        {
            return _backingField_MAX_VERTEX_UNIFORM_VECTORS;
        }
        /*double*/ _backingField_MAX_VIEWPORT_DIMS = null;
        /*double*/ get MAX_VIEWPORT_DIMS()
        {
            return _backingField_MAX_VIEWPORT_DIMS;
        }
        /*double*/ _backingField_MEDIUM_FLOAT = null;
        /*double*/ get MEDIUM_FLOAT()
        {
            return _backingField_MEDIUM_FLOAT;
        }
        /*double*/ _backingField_MEDIUM_INT = null;
        /*double*/ get MEDIUM_INT()
        {
            return _backingField_MEDIUM_INT;
        }
        /*double*/ _backingField_MIRRORED_REPEAT = null;
        /*double*/ get MIRRORED_REPEAT()
        {
            return _backingField_MIRRORED_REPEAT;
        }
        /*double*/ _backingField_NEAREST = null;
        /*double*/ get NEAREST()
        {
            return _backingField_NEAREST;
        }
        /*double*/ _backingField_NEAREST_MIPMAP_LINEAR = null;
        /*double*/ get NEAREST_MIPMAP_LINEAR()
        {
            return _backingField_NEAREST_MIPMAP_LINEAR;
        }
        /*double*/ _backingField_NEAREST_MIPMAP_NEAREST = null;
        /*double*/ get NEAREST_MIPMAP_NEAREST()
        {
            return _backingField_NEAREST_MIPMAP_NEAREST;
        }
        /*double*/ _backingField_NEVER = null;
        /*double*/ get NEVER()
        {
            return _backingField_NEVER;
        }
        /*double*/ _backingField_NICEST = null;
        /*double*/ get NICEST()
        {
            return _backingField_NICEST;
        }
        /*double*/ _backingField_NONE = null;
        /*double*/ get NONE()
        {
            return _backingField_NONE;
        }
        /*double*/ _backingField_NOTEQUAL = null;
        /*double*/ get NOTEQUAL()
        {
            return _backingField_NOTEQUAL;
        }
        /*double*/ _backingField_NO_ERROR = null;
        /*double*/ get NO_ERROR()
        {
            return _backingField_NO_ERROR;
        }
        /*double*/ _backingField_ONE = null;
        /*double*/ get ONE()
        {
            return _backingField_ONE;
        }
        /*double*/ _backingField_ONE_MINUS_CONSTANT_ALPHA = null;
        /*double*/ get ONE_MINUS_CONSTANT_ALPHA()
        {
            return _backingField_ONE_MINUS_CONSTANT_ALPHA;
        }
        /*double*/ _backingField_ONE_MINUS_CONSTANT_COLOR = null;
        /*double*/ get ONE_MINUS_CONSTANT_COLOR()
        {
            return _backingField_ONE_MINUS_CONSTANT_COLOR;
        }
        /*double*/ _backingField_ONE_MINUS_DST_ALPHA = null;
        /*double*/ get ONE_MINUS_DST_ALPHA()
        {
            return _backingField_ONE_MINUS_DST_ALPHA;
        }
        /*double*/ _backingField_ONE_MINUS_DST_COLOR = null;
        /*double*/ get ONE_MINUS_DST_COLOR()
        {
            return _backingField_ONE_MINUS_DST_COLOR;
        }
        /*double*/ _backingField_ONE_MINUS_SRC_ALPHA = null;
        /*double*/ get ONE_MINUS_SRC_ALPHA()
        {
            return _backingField_ONE_MINUS_SRC_ALPHA;
        }
        /*double*/ _backingField_ONE_MINUS_SRC_COLOR = null;
        /*double*/ get ONE_MINUS_SRC_COLOR()
        {
            return _backingField_ONE_MINUS_SRC_COLOR;
        }
        /*double*/ _backingField_OUT_OF_MEMORY = null;
        /*double*/ get OUT_OF_MEMORY()
        {
            return _backingField_OUT_OF_MEMORY;
        }
        /*double*/ _backingField_PACK_ALIGNMENT = null;
        /*double*/ get PACK_ALIGNMENT()
        {
            return _backingField_PACK_ALIGNMENT;
        }
        /*double*/ _backingField_POINTS = null;
        /*double*/ get POINTS()
        {
            return _backingField_POINTS;
        }
        /*double*/ _backingField_POLYGON_OFFSET_FACTOR = null;
        /*double*/ get POLYGON_OFFSET_FACTOR()
        {
            return _backingField_POLYGON_OFFSET_FACTOR;
        }
        /*double*/ _backingField_POLYGON_OFFSET_FILL = null;
        /*double*/ get POLYGON_OFFSET_FILL()
        {
            return _backingField_POLYGON_OFFSET_FILL;
        }
        /*double*/ _backingField_POLYGON_OFFSET_UNITS = null;
        /*double*/ get POLYGON_OFFSET_UNITS()
        {
            return _backingField_POLYGON_OFFSET_UNITS;
        }
        /*double*/ _backingField_RED_BITS = null;
        /*double*/ get RED_BITS()
        {
            return _backingField_RED_BITS;
        }
        /*double*/ _backingField_RENDERBUFFER = null;
        /*double*/ get RENDERBUFFER()
        {
            return _backingField_RENDERBUFFER;
        }
        /*double*/ _backingField_RENDERBUFFER_ALPHA_SIZE = null;
        /*double*/ get RENDERBUFFER_ALPHA_SIZE()
        {
            return _backingField_RENDERBUFFER_ALPHA_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_BINDING = null;
        /*double*/ get RENDERBUFFER_BINDING()
        {
            return _backingField_RENDERBUFFER_BINDING;
        }
        /*double*/ _backingField_RENDERBUFFER_BLUE_SIZE = null;
        /*double*/ get RENDERBUFFER_BLUE_SIZE()
        {
            return _backingField_RENDERBUFFER_BLUE_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_DEPTH_SIZE = null;
        /*double*/ get RENDERBUFFER_DEPTH_SIZE()
        {
            return _backingField_RENDERBUFFER_DEPTH_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_GREEN_SIZE = null;
        /*double*/ get RENDERBUFFER_GREEN_SIZE()
        {
            return _backingField_RENDERBUFFER_GREEN_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_HEIGHT = null;
        /*double*/ get RENDERBUFFER_HEIGHT()
        {
            return _backingField_RENDERBUFFER_HEIGHT;
        }
        /*double*/ _backingField_RENDERBUFFER_INTERNAL_FORMAT = null;
        /*double*/ get RENDERBUFFER_INTERNAL_FORMAT()
        {
            return _backingField_RENDERBUFFER_INTERNAL_FORMAT;
        }
        /*double*/ _backingField_RENDERBUFFER_RED_SIZE = null;
        /*double*/ get RENDERBUFFER_RED_SIZE()
        {
            return _backingField_RENDERBUFFER_RED_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_STENCIL_SIZE = null;
        /*double*/ get RENDERBUFFER_STENCIL_SIZE()
        {
            return _backingField_RENDERBUFFER_STENCIL_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_WIDTH = null;
        /*double*/ get RENDERBUFFER_WIDTH()
        {
            return _backingField_RENDERBUFFER_WIDTH;
        }
        /*double*/ _backingField_RENDERER = null;
        /*double*/ get RENDERER()
        {
            return _backingField_RENDERER;
        }
        /*double*/ _backingField_REPEAT = null;
        /*double*/ get REPEAT()
        {
            return _backingField_REPEAT;
        }
        /*double*/ _backingField_REPLACE = null;
        /*double*/ get REPLACE()
        {
            return _backingField_REPLACE;
        }
        /*double*/ _backingField_RGB = null;
        /*double*/ get RGB()
        {
            return _backingField_RGB;
        }
        /*double*/ _backingField_RGB565 = null;
        /*double*/ get RGB565()
        {
            return _backingField_RGB565;
        }
        /*double*/ _backingField_RGB5_A1 = null;
        /*double*/ get RGB5_A1()
        {
            return _backingField_RGB5_A1;
        }
        /*double*/ _backingField_RGBA = null;
        /*double*/ get RGBA()
        {
            return _backingField_RGBA;
        }
        /*double*/ _backingField_RGBA4 = null;
        /*double*/ get RGBA4()
        {
            return _backingField_RGBA4;
        }
        /*double*/ _backingField_SAMPLER_2D = null;
        /*double*/ get SAMPLER_2D()
        {
            return _backingField_SAMPLER_2D;
        }
        /*double*/ _backingField_SAMPLER_CUBE = null;
        /*double*/ get SAMPLER_CUBE()
        {
            return _backingField_SAMPLER_CUBE;
        }
        /*double*/ _backingField_SAMPLES = null;
        /*double*/ get SAMPLES()
        {
            return _backingField_SAMPLES;
        }
        /*double*/ _backingField_SAMPLE_ALPHA_TO_COVERAGE = null;
        /*double*/ get SAMPLE_ALPHA_TO_COVERAGE()
        {
            return _backingField_SAMPLE_ALPHA_TO_COVERAGE;
        }
        /*double*/ _backingField_SAMPLE_BUFFERS = null;
        /*double*/ get SAMPLE_BUFFERS()
        {
            return _backingField_SAMPLE_BUFFERS;
        }
        /*double*/ _backingField_SAMPLE_COVERAGE = null;
        /*double*/ get SAMPLE_COVERAGE()
        {
            return _backingField_SAMPLE_COVERAGE;
        }
        /*double*/ _backingField_SAMPLE_COVERAGE_INVERT = null;
        /*double*/ get SAMPLE_COVERAGE_INVERT()
        {
            return _backingField_SAMPLE_COVERAGE_INVERT;
        }
        /*double*/ _backingField_SAMPLE_COVERAGE_VALUE = null;
        /*double*/ get SAMPLE_COVERAGE_VALUE()
        {
            return _backingField_SAMPLE_COVERAGE_VALUE;
        }
        /*double*/ _backingField_SCISSOR_BOX = null;
        /*double*/ get SCISSOR_BOX()
        {
            return _backingField_SCISSOR_BOX;
        }
        /*double*/ _backingField_SCISSOR_TEST = null;
        /*double*/ get SCISSOR_TEST()
        {
            return _backingField_SCISSOR_TEST;
        }
        /*double*/ _backingField_SHADER_TYPE = null;
        /*double*/ get SHADER_TYPE()
        {
            return _backingField_SHADER_TYPE;
        }
        /*double*/ _backingField_SHADING_LANGUAGE_VERSION = null;
        /*double*/ get SHADING_LANGUAGE_VERSION()
        {
            return _backingField_SHADING_LANGUAGE_VERSION;
        }
        /*double*/ _backingField_SHORT = null;
        /*double*/ get SHORT()
        {
            return _backingField_SHORT;
        }
        /*double*/ _backingField_SRC_ALPHA = null;
        /*double*/ get SRC_ALPHA()
        {
            return _backingField_SRC_ALPHA;
        }
        /*double*/ _backingField_SRC_ALPHA_SATURATE = null;
        /*double*/ get SRC_ALPHA_SATURATE()
        {
            return _backingField_SRC_ALPHA_SATURATE;
        }
        /*double*/ _backingField_SRC_COLOR = null;
        /*double*/ get SRC_COLOR()
        {
            return _backingField_SRC_COLOR;
        }
        /*double*/ _backingField_STATIC_DRAW = null;
        /*double*/ get STATIC_DRAW()
        {
            return _backingField_STATIC_DRAW;
        }
        /*double*/ _backingField_STENCIL_ATTACHMENT = null;
        /*double*/ get STENCIL_ATTACHMENT()
        {
            return _backingField_STENCIL_ATTACHMENT;
        }
        /*double*/ _backingField_STENCIL_BACK_FAIL = null;
        /*double*/ get STENCIL_BACK_FAIL()
        {
            return _backingField_STENCIL_BACK_FAIL;
        }
        /*double*/ _backingField_STENCIL_BACK_FUNC = null;
        /*double*/ get STENCIL_BACK_FUNC()
        {
            return _backingField_STENCIL_BACK_FUNC;
        }
        /*double*/ _backingField_STENCIL_BACK_PASS_DEPTH_FAIL = null;
        /*double*/ get STENCIL_BACK_PASS_DEPTH_FAIL()
        {
            return _backingField_STENCIL_BACK_PASS_DEPTH_FAIL;
        }
        /*double*/ _backingField_STENCIL_BACK_PASS_DEPTH_PASS = null;
        /*double*/ get STENCIL_BACK_PASS_DEPTH_PASS()
        {
            return _backingField_STENCIL_BACK_PASS_DEPTH_PASS;
        }
        /*double*/ _backingField_STENCIL_BACK_REF = null;
        /*double*/ get STENCIL_BACK_REF()
        {
            return _backingField_STENCIL_BACK_REF;
        }
        /*double*/ _backingField_STENCIL_BACK_VALUE_MASK = null;
        /*double*/ get STENCIL_BACK_VALUE_MASK()
        {
            return _backingField_STENCIL_BACK_VALUE_MASK;
        }
        /*double*/ _backingField_STENCIL_BACK_WRITEMASK = null;
        /*double*/ get STENCIL_BACK_WRITEMASK()
        {
            return _backingField_STENCIL_BACK_WRITEMASK;
        }
        /*double*/ _backingField_STENCIL_BITS = null;
        /*double*/ get STENCIL_BITS()
        {
            return _backingField_STENCIL_BITS;
        }
        /*double*/ _backingField_STENCIL_BUFFER_BIT = null;
        /*double*/ get STENCIL_BUFFER_BIT()
        {
            return _backingField_STENCIL_BUFFER_BIT;
        }
        /*double*/ _backingField_STENCIL_CLEAR_VALUE = null;
        /*double*/ get STENCIL_CLEAR_VALUE()
        {
            return _backingField_STENCIL_CLEAR_VALUE;
        }
        /*double*/ _backingField_STENCIL_FAIL = null;
        /*double*/ get STENCIL_FAIL()
        {
            return _backingField_STENCIL_FAIL;
        }
        /*double*/ _backingField_STENCIL_FUNC = null;
        /*double*/ get STENCIL_FUNC()
        {
            return _backingField_STENCIL_FUNC;
        }
        /*double*/ _backingField_STENCIL_INDEX = null;
        /*double*/ get STENCIL_INDEX()
        {
            return _backingField_STENCIL_INDEX;
        }
        /*double*/ _backingField_STENCIL_INDEX8 = null;
        /*double*/ get STENCIL_INDEX8()
        {
            return _backingField_STENCIL_INDEX8;
        }
        /*double*/ _backingField_STENCIL_PASS_DEPTH_FAIL = null;
        /*double*/ get STENCIL_PASS_DEPTH_FAIL()
        {
            return _backingField_STENCIL_PASS_DEPTH_FAIL;
        }
        /*double*/ _backingField_STENCIL_PASS_DEPTH_PASS = null;
        /*double*/ get STENCIL_PASS_DEPTH_PASS()
        {
            return _backingField_STENCIL_PASS_DEPTH_PASS;
        }
        /*double*/ _backingField_STENCIL_REF = null;
        /*double*/ get STENCIL_REF()
        {
            return _backingField_STENCIL_REF;
        }
        /*double*/ _backingField_STENCIL_TEST = null;
        /*double*/ get STENCIL_TEST()
        {
            return _backingField_STENCIL_TEST;
        }
        /*double*/ _backingField_STENCIL_VALUE_MASK = null;
        /*double*/ get STENCIL_VALUE_MASK()
        {
            return _backingField_STENCIL_VALUE_MASK;
        }
        /*double*/ _backingField_STENCIL_WRITEMASK = null;
        /*double*/ get STENCIL_WRITEMASK()
        {
            return _backingField_STENCIL_WRITEMASK;
        }
        /*double*/ _backingField_STREAM_DRAW = null;
        /*double*/ get STREAM_DRAW()
        {
            return _backingField_STREAM_DRAW;
        }
        /*double*/ _backingField_SUBPIXEL_BITS = null;
        /*double*/ get SUBPIXEL_BITS()
        {
            return _backingField_SUBPIXEL_BITS;
        }
        /*double*/ _backingField_TEXTURE = null;
        /*double*/ get TEXTURE()
        {
            return _backingField_TEXTURE;
        }
        /*double*/ _backingField_TEXTURE0 = null;
        /*double*/ get TEXTURE0()
        {
            return _backingField_TEXTURE0;
        }
        /*double*/ _backingField_TEXTURE1 = null;
        /*double*/ get TEXTURE1()
        {
            return _backingField_TEXTURE1;
        }
        /*double*/ _backingField_TEXTURE10 = null;
        /*double*/ get TEXTURE10()
        {
            return _backingField_TEXTURE10;
        }
        /*double*/ _backingField_TEXTURE11 = null;
        /*double*/ get TEXTURE11()
        {
            return _backingField_TEXTURE11;
        }
        /*double*/ _backingField_TEXTURE12 = null;
        /*double*/ get TEXTURE12()
        {
            return _backingField_TEXTURE12;
        }
        /*double*/ _backingField_TEXTURE13 = null;
        /*double*/ get TEXTURE13()
        {
            return _backingField_TEXTURE13;
        }
        /*double*/ _backingField_TEXTURE14 = null;
        /*double*/ get TEXTURE14()
        {
            return _backingField_TEXTURE14;
        }
        /*double*/ _backingField_TEXTURE15 = null;
        /*double*/ get TEXTURE15()
        {
            return _backingField_TEXTURE15;
        }
        /*double*/ _backingField_TEXTURE16 = null;
        /*double*/ get TEXTURE16()
        {
            return _backingField_TEXTURE16;
        }
        /*double*/ _backingField_TEXTURE17 = null;
        /*double*/ get TEXTURE17()
        {
            return _backingField_TEXTURE17;
        }
        /*double*/ _backingField_TEXTURE18 = null;
        /*double*/ get TEXTURE18()
        {
            return _backingField_TEXTURE18;
        }
        /*double*/ _backingField_TEXTURE19 = null;
        /*double*/ get TEXTURE19()
        {
            return _backingField_TEXTURE19;
        }
        /*double*/ _backingField_TEXTURE2 = null;
        /*double*/ get TEXTURE2()
        {
            return _backingField_TEXTURE2;
        }
        /*double*/ _backingField_TEXTURE20 = null;
        /*double*/ get TEXTURE20()
        {
            return _backingField_TEXTURE20;
        }
        /*double*/ _backingField_TEXTURE21 = null;
        /*double*/ get TEXTURE21()
        {
            return _backingField_TEXTURE21;
        }
        /*double*/ _backingField_TEXTURE22 = null;
        /*double*/ get TEXTURE22()
        {
            return _backingField_TEXTURE22;
        }
        /*double*/ _backingField_TEXTURE23 = null;
        /*double*/ get TEXTURE23()
        {
            return _backingField_TEXTURE23;
        }
        /*double*/ _backingField_TEXTURE24 = null;
        /*double*/ get TEXTURE24()
        {
            return _backingField_TEXTURE24;
        }
        /*double*/ _backingField_TEXTURE25 = null;
        /*double*/ get TEXTURE25()
        {
            return _backingField_TEXTURE25;
        }
        /*double*/ _backingField_TEXTURE26 = null;
        /*double*/ get TEXTURE26()
        {
            return _backingField_TEXTURE26;
        }
        /*double*/ _backingField_TEXTURE27 = null;
        /*double*/ get TEXTURE27()
        {
            return _backingField_TEXTURE27;
        }
        /*double*/ _backingField_TEXTURE28 = null;
        /*double*/ get TEXTURE28()
        {
            return _backingField_TEXTURE28;
        }
        /*double*/ _backingField_TEXTURE29 = null;
        /*double*/ get TEXTURE29()
        {
            return _backingField_TEXTURE29;
        }
        /*double*/ _backingField_TEXTURE3 = null;
        /*double*/ get TEXTURE3()
        {
            return _backingField_TEXTURE3;
        }
        /*double*/ _backingField_TEXTURE30 = null;
        /*double*/ get TEXTURE30()
        {
            return _backingField_TEXTURE30;
        }
        /*double*/ _backingField_TEXTURE31 = null;
        /*double*/ get TEXTURE31()
        {
            return _backingField_TEXTURE31;
        }
        /*double*/ _backingField_TEXTURE4 = null;
        /*double*/ get TEXTURE4()
        {
            return _backingField_TEXTURE4;
        }
        /*double*/ _backingField_TEXTURE5 = null;
        /*double*/ get TEXTURE5()
        {
            return _backingField_TEXTURE5;
        }
        /*double*/ _backingField_TEXTURE6 = null;
        /*double*/ get TEXTURE6()
        {
            return _backingField_TEXTURE6;
        }
        /*double*/ _backingField_TEXTURE7 = null;
        /*double*/ get TEXTURE7()
        {
            return _backingField_TEXTURE7;
        }
        /*double*/ _backingField_TEXTURE8 = null;
        /*double*/ get TEXTURE8()
        {
            return _backingField_TEXTURE8;
        }
        /*double*/ _backingField_TEXTURE9 = null;
        /*double*/ get TEXTURE9()
        {
            return _backingField_TEXTURE9;
        }
        /*double*/ _backingField_TEXTURE_2D = null;
        /*double*/ get TEXTURE_2D()
        {
            return _backingField_TEXTURE_2D;
        }
        /*double*/ _backingField_TEXTURE_BINDING_2D = null;
        /*double*/ get TEXTURE_BINDING_2D()
        {
            return _backingField_TEXTURE_BINDING_2D;
        }
        /*double*/ _backingField_TEXTURE_BINDING_CUBE_MAP = null;
        /*double*/ get TEXTURE_BINDING_CUBE_MAP()
        {
            return _backingField_TEXTURE_BINDING_CUBE_MAP;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP = null;
        /*double*/ get TEXTURE_CUBE_MAP()
        {
            return _backingField_TEXTURE_CUBE_MAP;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_NEGATIVE_X = null;
        /*double*/ get TEXTURE_CUBE_MAP_NEGATIVE_X()
        {
            return _backingField_TEXTURE_CUBE_MAP_NEGATIVE_X;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_NEGATIVE_Y = null;
        /*double*/ get TEXTURE_CUBE_MAP_NEGATIVE_Y()
        {
            return _backingField_TEXTURE_CUBE_MAP_NEGATIVE_Y;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_NEGATIVE_Z = null;
        /*double*/ get TEXTURE_CUBE_MAP_NEGATIVE_Z()
        {
            return _backingField_TEXTURE_CUBE_MAP_NEGATIVE_Z;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_POSITIVE_X = null;
        /*double*/ get TEXTURE_CUBE_MAP_POSITIVE_X()
        {
            return _backingField_TEXTURE_CUBE_MAP_POSITIVE_X;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_POSITIVE_Y = null;
        /*double*/ get TEXTURE_CUBE_MAP_POSITIVE_Y()
        {
            return _backingField_TEXTURE_CUBE_MAP_POSITIVE_Y;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_POSITIVE_Z = null;
        /*double*/ get TEXTURE_CUBE_MAP_POSITIVE_Z()
        {
            return _backingField_TEXTURE_CUBE_MAP_POSITIVE_Z;
        }
        /*double*/ _backingField_TEXTURE_MAG_FILTER = null;
        /*double*/ get TEXTURE_MAG_FILTER()
        {
            return _backingField_TEXTURE_MAG_FILTER;
        }
        /*double*/ _backingField_TEXTURE_MIN_FILTER = null;
        /*double*/ get TEXTURE_MIN_FILTER()
        {
            return _backingField_TEXTURE_MIN_FILTER;
        }
        /*double*/ _backingField_TEXTURE_WRAP_S = null;
        /*double*/ get TEXTURE_WRAP_S()
        {
            return _backingField_TEXTURE_WRAP_S;
        }
        /*double*/ _backingField_TEXTURE_WRAP_T = null;
        /*double*/ get TEXTURE_WRAP_T()
        {
            return _backingField_TEXTURE_WRAP_T;
        }
        /*double*/ _backingField_TRIANGLES = null;
        /*double*/ get TRIANGLES()
        {
            return _backingField_TRIANGLES;
        }
        /*double*/ _backingField_TRIANGLE_FAN = null;
        /*double*/ get TRIANGLE_FAN()
        {
            return _backingField_TRIANGLE_FAN;
        }
        /*double*/ _backingField_TRIANGLE_STRIP = null;
        /*double*/ get TRIANGLE_STRIP()
        {
            return _backingField_TRIANGLE_STRIP;
        }
        /*double*/ _backingField_UNPACK_ALIGNMENT = null;
        /*double*/ get UNPACK_ALIGNMENT()
        {
            return _backingField_UNPACK_ALIGNMENT;
        }
        /*double*/ _backingField_UNPACK_COLORSPACE_CONVERSION_WEBGL = null;
        /*double*/ get UNPACK_COLORSPACE_CONVERSION_WEBGL()
        {
            return _backingField_UNPACK_COLORSPACE_CONVERSION_WEBGL;
        }
        /*double*/ _backingField_UNPACK_FLIP_Y_WEBGL = null;
        /*double*/ get UNPACK_FLIP_Y_WEBGL()
        {
            return _backingField_UNPACK_FLIP_Y_WEBGL;
        }
        /*double*/ _backingField_UNPACK_PREMULTIPLY_ALPHA_WEBGL = null;
        /*double*/ get UNPACK_PREMULTIPLY_ALPHA_WEBGL()
        {
            return _backingField_UNPACK_PREMULTIPLY_ALPHA_WEBGL;
        }
        /*double*/ _backingField_UNSIGNED_BYTE = null;
        /*double*/ get UNSIGNED_BYTE()
        {
            return _backingField_UNSIGNED_BYTE;
        }
        /*double*/ _backingField_UNSIGNED_INT = null;
        /*double*/ get UNSIGNED_INT()
        {
            return _backingField_UNSIGNED_INT;
        }
        /*double*/ _backingField_UNSIGNED_SHORT = null;
        /*double*/ get UNSIGNED_SHORT()
        {
            return _backingField_UNSIGNED_SHORT;
        }
        /*double*/ _backingField_UNSIGNED_SHORT_4_4_4_4 = null;
        /*double*/ get UNSIGNED_SHORT_4_4_4_4()
        {
            return _backingField_UNSIGNED_SHORT_4_4_4_4;
        }
        /*double*/ _backingField_UNSIGNED_SHORT_5_5_5_1 = null;
        /*double*/ get UNSIGNED_SHORT_5_5_5_1()
        {
            return _backingField_UNSIGNED_SHORT_5_5_5_1;
        }
        /*double*/ _backingField_UNSIGNED_SHORT_5_6_5 = null;
        /*double*/ get UNSIGNED_SHORT_5_6_5()
        {
            return _backingField_UNSIGNED_SHORT_5_6_5;
        }
        /*double*/ _backingField_VALIDATE_STATUS = null;
        /*double*/ get VALIDATE_STATUS()
        {
            return _backingField_VALIDATE_STATUS;
        }
        /*double*/ _backingField_VENDOR = null;
        /*double*/ get VENDOR()
        {
            return _backingField_VENDOR;
        }
        /*double*/ _backingField_VERSION = null;
        /*double*/ get VERSION()
        {
            return _backingField_VERSION;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_BUFFER_BINDING()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_ENABLED = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_ENABLED()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_ENABLED;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_NORMALIZED = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_NORMALIZED()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_NORMALIZED;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_POINTER = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_POINTER()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_POINTER;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_SIZE = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_SIZE()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_SIZE;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_STRIDE = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_STRIDE()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_STRIDE;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_TYPE = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_TYPE()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_TYPE;
        }
        /*double*/ _backingField_VERTEX_SHADER = null;
        /*double*/ get VERTEX_SHADER()
        {
            return _backingField_VERTEX_SHADER;
        }
        /*double*/ _backingField_VIEWPORT = null;
        /*double*/ get VIEWPORT()
        {
            return _backingField_VIEWPORT;
        }
        /*double*/ _backingField_ZERO = null;
        /*double*/ get ZERO()
        {
            return _backingField_ZERO;
        }
        /*double*/ _backingField_READ_BUFFER_Static = null;
        /*double*/ get READ_BUFFER_Static()
        {
            return _backingField_READ_BUFFER_Static;
        }
        /*double*/ _backingField_UNPACK_ROW_LENGTH_Static = null;
        /*double*/ get UNPACK_ROW_LENGTH_Static()
        {
            return _backingField_UNPACK_ROW_LENGTH_Static;
        }
        /*double*/ _backingField_UNPACK_SKIP_ROWS_Static = null;
        /*double*/ get UNPACK_SKIP_ROWS_Static()
        {
            return _backingField_UNPACK_SKIP_ROWS_Static;
        }
        /*double*/ _backingField_UNPACK_SKIP_PIXELS_Static = null;
        /*double*/ get UNPACK_SKIP_PIXELS_Static()
        {
            return _backingField_UNPACK_SKIP_PIXELS_Static;
        }
        /*double*/ _backingField_PACK_ROW_LENGTH_Static = null;
        /*double*/ get PACK_ROW_LENGTH_Static()
        {
            return _backingField_PACK_ROW_LENGTH_Static;
        }
        /*double*/ _backingField_PACK_SKIP_ROWS_Static = null;
        /*double*/ get PACK_SKIP_ROWS_Static()
        {
            return _backingField_PACK_SKIP_ROWS_Static;
        }
        /*double*/ _backingField_PACK_SKIP_PIXELS_Static = null;
        /*double*/ get PACK_SKIP_PIXELS_Static()
        {
            return _backingField_PACK_SKIP_PIXELS_Static;
        }
        /*double*/ _backingField_COLOR_Static = null;
        /*double*/ get COLOR_Static()
        {
            return _backingField_COLOR_Static;
        }
        /*double*/ _backingField_DEPTH_Static = null;
        /*double*/ get DEPTH_Static()
        {
            return _backingField_DEPTH_Static;
        }
        /*double*/ _backingField_STENCIL_Static = null;
        /*double*/ get STENCIL_Static()
        {
            return _backingField_STENCIL_Static;
        }
        /*double*/ _backingField_RED_Static = null;
        /*double*/ get RED_Static()
        {
            return _backingField_RED_Static;
        }
        /*double*/ _backingField_RGB8_Static = null;
        /*double*/ get RGB8_Static()
        {
            return _backingField_RGB8_Static;
        }
        /*double*/ _backingField_RGBA8_Static = null;
        /*double*/ get RGBA8_Static()
        {
            return _backingField_RGBA8_Static;
        }
        /*double*/ _backingField_RGB10_A2_Static = null;
        /*double*/ get RGB10_A2_Static()
        {
            return _backingField_RGB10_A2_Static;
        }
        /*double*/ _backingField_TEXTURE_BINDING_3D_Static = null;
        /*double*/ get TEXTURE_BINDING_3D_Static()
        {
            return _backingField_TEXTURE_BINDING_3D_Static;
        }
        /*double*/ _backingField_UNPACK_SKIP_IMAGES_Static = null;
        /*double*/ get UNPACK_SKIP_IMAGES_Static()
        {
            return _backingField_UNPACK_SKIP_IMAGES_Static;
        }
        /*double*/ _backingField_UNPACK_IMAGE_HEIGHT_Static = null;
        /*double*/ get UNPACK_IMAGE_HEIGHT_Static()
        {
            return _backingField_UNPACK_IMAGE_HEIGHT_Static;
        }
        /*double*/ _backingField_TEXTURE_3D_Static = null;
        /*double*/ get TEXTURE_3D_Static()
        {
            return _backingField_TEXTURE_3D_Static;
        }
        /*double*/ _backingField_TEXTURE_WRAP_R_Static = null;
        /*double*/ get TEXTURE_WRAP_R_Static()
        {
            return _backingField_TEXTURE_WRAP_R_Static;
        }
        /*double*/ _backingField_MAX_3D_TEXTURE_SIZE_Static = null;
        /*double*/ get MAX_3D_TEXTURE_SIZE_Static()
        {
            return _backingField_MAX_3D_TEXTURE_SIZE_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_2_10_10_10_REV_Static = null;
        /*double*/ get UNSIGNED_INT_2_10_10_10_REV_Static()
        {
            return _backingField_UNSIGNED_INT_2_10_10_10_REV_Static;
        }
        /*double*/ _backingField_MAX_ELEMENTS_VERTICES_Static = null;
        /*double*/ get MAX_ELEMENTS_VERTICES_Static()
        {
            return _backingField_MAX_ELEMENTS_VERTICES_Static;
        }
        /*double*/ _backingField_MAX_ELEMENTS_INDICES_Static = null;
        /*double*/ get MAX_ELEMENTS_INDICES_Static()
        {
            return _backingField_MAX_ELEMENTS_INDICES_Static;
        }
        /*double*/ _backingField_TEXTURE_MIN_LOD_Static = null;
        /*double*/ get TEXTURE_MIN_LOD_Static()
        {
            return _backingField_TEXTURE_MIN_LOD_Static;
        }
        /*double*/ _backingField_TEXTURE_MAX_LOD_Static = null;
        /*double*/ get TEXTURE_MAX_LOD_Static()
        {
            return _backingField_TEXTURE_MAX_LOD_Static;
        }
        /*double*/ _backingField_TEXTURE_BASE_LEVEL_Static = null;
        /*double*/ get TEXTURE_BASE_LEVEL_Static()
        {
            return _backingField_TEXTURE_BASE_LEVEL_Static;
        }
        /*double*/ _backingField_TEXTURE_MAX_LEVEL_Static = null;
        /*double*/ get TEXTURE_MAX_LEVEL_Static()
        {
            return _backingField_TEXTURE_MAX_LEVEL_Static;
        }
        /*double*/ _backingField_MIN_Static = null;
        /*double*/ get MIN_Static()
        {
            return _backingField_MIN_Static;
        }
        /*double*/ _backingField_MAX_Static = null;
        /*double*/ get MAX_Static()
        {
            return _backingField_MAX_Static;
        }
        /*double*/ _backingField_DEPTH_COMPONENT24_Static = null;
        /*double*/ get DEPTH_COMPONENT24_Static()
        {
            return _backingField_DEPTH_COMPONENT24_Static;
        }
        /*double*/ _backingField_MAX_TEXTURE_LOD_BIAS_Static = null;
        /*double*/ get MAX_TEXTURE_LOD_BIAS_Static()
        {
            return _backingField_MAX_TEXTURE_LOD_BIAS_Static;
        }
        /*double*/ _backingField_TEXTURE_COMPARE_MODE_Static = null;
        /*double*/ get TEXTURE_COMPARE_MODE_Static()
        {
            return _backingField_TEXTURE_COMPARE_MODE_Static;
        }
        /*double*/ _backingField_TEXTURE_COMPARE_FUNC_Static = null;
        /*double*/ get TEXTURE_COMPARE_FUNC_Static()
        {
            return _backingField_TEXTURE_COMPARE_FUNC_Static;
        }
        /*double*/ _backingField_CURRENT_QUERY_Static = null;
        /*double*/ get CURRENT_QUERY_Static()
        {
            return _backingField_CURRENT_QUERY_Static;
        }
        /*double*/ _backingField_QUERY_RESULT_Static = null;
        /*double*/ get QUERY_RESULT_Static()
        {
            return _backingField_QUERY_RESULT_Static;
        }
        /*double*/ _backingField_QUERY_RESULT_AVAILABLE_Static = null;
        /*double*/ get QUERY_RESULT_AVAILABLE_Static()
        {
            return _backingField_QUERY_RESULT_AVAILABLE_Static;
        }
        /*double*/ _backingField_STREAM_READ_Static = null;
        /*double*/ get STREAM_READ_Static()
        {
            return _backingField_STREAM_READ_Static;
        }
        /*double*/ _backingField_STREAM_COPY_Static = null;
        /*double*/ get STREAM_COPY_Static()
        {
            return _backingField_STREAM_COPY_Static;
        }
        /*double*/ _backingField_STATIC_READ_Static = null;
        /*double*/ get STATIC_READ_Static()
        {
            return _backingField_STATIC_READ_Static;
        }
        /*double*/ _backingField_STATIC_COPY_Static = null;
        /*double*/ get STATIC_COPY_Static()
        {
            return _backingField_STATIC_COPY_Static;
        }
        /*double*/ _backingField_DYNAMIC_READ_Static = null;
        /*double*/ get DYNAMIC_READ_Static()
        {
            return _backingField_DYNAMIC_READ_Static;
        }
        /*double*/ _backingField_DYNAMIC_COPY_Static = null;
        /*double*/ get DYNAMIC_COPY_Static()
        {
            return _backingField_DYNAMIC_COPY_Static;
        }
        /*double*/ _backingField_MAX_DRAW_BUFFERS_Static = null;
        /*double*/ get MAX_DRAW_BUFFERS_Static()
        {
            return _backingField_MAX_DRAW_BUFFERS_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER0_Static = null;
        /*double*/ get DRAW_BUFFER0_Static()
        {
            return _backingField_DRAW_BUFFER0_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER1_Static = null;
        /*double*/ get DRAW_BUFFER1_Static()
        {
            return _backingField_DRAW_BUFFER1_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER2_Static = null;
        /*double*/ get DRAW_BUFFER2_Static()
        {
            return _backingField_DRAW_BUFFER2_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER3_Static = null;
        /*double*/ get DRAW_BUFFER3_Static()
        {
            return _backingField_DRAW_BUFFER3_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER4_Static = null;
        /*double*/ get DRAW_BUFFER4_Static()
        {
            return _backingField_DRAW_BUFFER4_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER5_Static = null;
        /*double*/ get DRAW_BUFFER5_Static()
        {
            return _backingField_DRAW_BUFFER5_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER6_Static = null;
        /*double*/ get DRAW_BUFFER6_Static()
        {
            return _backingField_DRAW_BUFFER6_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER7_Static = null;
        /*double*/ get DRAW_BUFFER7_Static()
        {
            return _backingField_DRAW_BUFFER7_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER8_Static = null;
        /*double*/ get DRAW_BUFFER8_Static()
        {
            return _backingField_DRAW_BUFFER8_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER9_Static = null;
        /*double*/ get DRAW_BUFFER9_Static()
        {
            return _backingField_DRAW_BUFFER9_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER10_Static = null;
        /*double*/ get DRAW_BUFFER10_Static()
        {
            return _backingField_DRAW_BUFFER10_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER11_Static = null;
        /*double*/ get DRAW_BUFFER11_Static()
        {
            return _backingField_DRAW_BUFFER11_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER12_Static = null;
        /*double*/ get DRAW_BUFFER12_Static()
        {
            return _backingField_DRAW_BUFFER12_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER13_Static = null;
        /*double*/ get DRAW_BUFFER13_Static()
        {
            return _backingField_DRAW_BUFFER13_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER14_Static = null;
        /*double*/ get DRAW_BUFFER14_Static()
        {
            return _backingField_DRAW_BUFFER14_Static;
        }
        /*double*/ _backingField_DRAW_BUFFER15_Static = null;
        /*double*/ get DRAW_BUFFER15_Static()
        {
            return _backingField_DRAW_BUFFER15_Static;
        }
        /*double*/ _backingField_MAX_FRAGMENT_UNIFORM_COMPONENTS_Static = null;
        /*double*/ get MAX_FRAGMENT_UNIFORM_COMPONENTS_Static()
        {
            return _backingField_MAX_FRAGMENT_UNIFORM_COMPONENTS_Static;
        }
        /*double*/ _backingField_MAX_VERTEX_UNIFORM_COMPONENTS_Static = null;
        /*double*/ get MAX_VERTEX_UNIFORM_COMPONENTS_Static()
        {
            return _backingField_MAX_VERTEX_UNIFORM_COMPONENTS_Static;
        }
        /*double*/ _backingField_SAMPLER_3D_Static = null;
        /*double*/ get SAMPLER_3D_Static()
        {
            return _backingField_SAMPLER_3D_Static;
        }
        /*double*/ _backingField_SAMPLER_2D_SHADOW_Static = null;
        /*double*/ get SAMPLER_2D_SHADOW_Static()
        {
            return _backingField_SAMPLER_2D_SHADOW_Static;
        }
        /*double*/ _backingField_FRAGMENT_SHADER_DERIVATIVE_HINT_Static = null;
        /*double*/ get FRAGMENT_SHADER_DERIVATIVE_HINT_Static()
        {
            return _backingField_FRAGMENT_SHADER_DERIVATIVE_HINT_Static;
        }
        /*double*/ _backingField_PIXEL_PACK_BUFFER_Static = null;
        /*double*/ get PIXEL_PACK_BUFFER_Static()
        {
            return _backingField_PIXEL_PACK_BUFFER_Static;
        }
        /*double*/ _backingField_PIXEL_UNPACK_BUFFER_Static = null;
        /*double*/ get PIXEL_UNPACK_BUFFER_Static()
        {
            return _backingField_PIXEL_UNPACK_BUFFER_Static;
        }
        /*double*/ _backingField_PIXEL_PACK_BUFFER_BINDING_Static = null;
        /*double*/ get PIXEL_PACK_BUFFER_BINDING_Static()
        {
            return _backingField_PIXEL_PACK_BUFFER_BINDING_Static;
        }
        /*double*/ _backingField_PIXEL_UNPACK_BUFFER_BINDING_Static = null;
        /*double*/ get PIXEL_UNPACK_BUFFER_BINDING_Static()
        {
            return _backingField_PIXEL_UNPACK_BUFFER_BINDING_Static;
        }
        /*double*/ _backingField_FLOAT_MAT2x3_Static = null;
        /*double*/ get FLOAT_MAT2x3_Static()
        {
            return _backingField_FLOAT_MAT2x3_Static;
        }
        /*double*/ _backingField_FLOAT_MAT2x4_Static = null;
        /*double*/ get FLOAT_MAT2x4_Static()
        {
            return _backingField_FLOAT_MAT2x4_Static;
        }
        /*double*/ _backingField_FLOAT_MAT3x2_Static = null;
        /*double*/ get FLOAT_MAT3x2_Static()
        {
            return _backingField_FLOAT_MAT3x2_Static;
        }
        /*double*/ _backingField_FLOAT_MAT3x4_Static = null;
        /*double*/ get FLOAT_MAT3x4_Static()
        {
            return _backingField_FLOAT_MAT3x4_Static;
        }
        /*double*/ _backingField_FLOAT_MAT4x2_Static = null;
        /*double*/ get FLOAT_MAT4x2_Static()
        {
            return _backingField_FLOAT_MAT4x2_Static;
        }
        /*double*/ _backingField_FLOAT_MAT4x3_Static = null;
        /*double*/ get FLOAT_MAT4x3_Static()
        {
            return _backingField_FLOAT_MAT4x3_Static;
        }
        /*double*/ _backingField_SRGB_Static = null;
        /*double*/ get SRGB_Static()
        {
            return _backingField_SRGB_Static;
        }
        /*double*/ _backingField_SRGB8_Static = null;
        /*double*/ get SRGB8_Static()
        {
            return _backingField_SRGB8_Static;
        }
        /*double*/ _backingField_SRGB8_ALPHA8_Static = null;
        /*double*/ get SRGB8_ALPHA8_Static()
        {
            return _backingField_SRGB8_ALPHA8_Static;
        }
        /*double*/ _backingField_COMPARE_REF_TO_TEXTURE_Static = null;
        /*double*/ get COMPARE_REF_TO_TEXTURE_Static()
        {
            return _backingField_COMPARE_REF_TO_TEXTURE_Static;
        }
        /*double*/ _backingField_RGBA32F_Static = null;
        /*double*/ get RGBA32F_Static()
        {
            return _backingField_RGBA32F_Static;
        }
        /*double*/ _backingField_RGB32F_Static = null;
        /*double*/ get RGB32F_Static()
        {
            return _backingField_RGB32F_Static;
        }
        /*double*/ _backingField_RGBA16F_Static = null;
        /*double*/ get RGBA16F_Static()
        {
            return _backingField_RGBA16F_Static;
        }
        /*double*/ _backingField_RGB16F_Static = null;
        /*double*/ get RGB16F_Static()
        {
            return _backingField_RGB16F_Static;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_INTEGER_Static = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_INTEGER_Static()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_INTEGER_Static;
        }
        /*double*/ _backingField_MAX_ARRAY_TEXTURE_LAYERS_Static = null;
        /*double*/ get MAX_ARRAY_TEXTURE_LAYERS_Static()
        {
            return _backingField_MAX_ARRAY_TEXTURE_LAYERS_Static;
        }
        /*double*/ _backingField_MIN_PROGRAM_TEXEL_OFFSET_Static = null;
        /*double*/ get MIN_PROGRAM_TEXEL_OFFSET_Static()
        {
            return _backingField_MIN_PROGRAM_TEXEL_OFFSET_Static;
        }
        /*double*/ _backingField_MAX_PROGRAM_TEXEL_OFFSET_Static = null;
        /*double*/ get MAX_PROGRAM_TEXEL_OFFSET_Static()
        {
            return _backingField_MAX_PROGRAM_TEXEL_OFFSET_Static;
        }
        /*double*/ _backingField_MAX_VARYING_COMPONENTS_Static = null;
        /*double*/ get MAX_VARYING_COMPONENTS_Static()
        {
            return _backingField_MAX_VARYING_COMPONENTS_Static;
        }
        /*double*/ _backingField_TEXTURE_2D_ARRAY_Static = null;
        /*double*/ get TEXTURE_2D_ARRAY_Static()
        {
            return _backingField_TEXTURE_2D_ARRAY_Static;
        }
        /*double*/ _backingField_TEXTURE_BINDING_2D_ARRAY_Static = null;
        /*double*/ get TEXTURE_BINDING_2D_ARRAY_Static()
        {
            return _backingField_TEXTURE_BINDING_2D_ARRAY_Static;
        }
        /*double*/ _backingField_R11F_G11F_B10F_Static = null;
        /*double*/ get R11F_G11F_B10F_Static()
        {
            return _backingField_R11F_G11F_B10F_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_10F_11F_11F_REV_Static = null;
        /*double*/ get UNSIGNED_INT_10F_11F_11F_REV_Static()
        {
            return _backingField_UNSIGNED_INT_10F_11F_11F_REV_Static;
        }
        /*double*/ _backingField_RGB9_E5_Static = null;
        /*double*/ get RGB9_E5_Static()
        {
            return _backingField_RGB9_E5_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_5_9_9_9_REV_Static = null;
        /*double*/ get UNSIGNED_INT_5_9_9_9_REV_Static()
        {
            return _backingField_UNSIGNED_INT_5_9_9_9_REV_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_MODE_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_MODE_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_MODE_Static;
        }
        /*double*/ _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_Static = null;
        /*double*/ get MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_Static()
        {
            return _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_VARYINGS_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_VARYINGS_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_VARYINGS_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_START_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_START_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_START_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_SIZE_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_SIZE_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_SIZE_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN_Static;
        }
        /*double*/ _backingField_RASTERIZER_DISCARD_Static = null;
        /*double*/ get RASTERIZER_DISCARD_Static()
        {
            return _backingField_RASTERIZER_DISCARD_Static;
        }
        /*double*/ _backingField_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS_Static = null;
        /*double*/ get MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS_Static()
        {
            return _backingField_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS_Static;
        }
        /*double*/ _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_Static = null;
        /*double*/ get MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_Static()
        {
            return _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS_Static;
        }
        /*double*/ _backingField_INTERLEAVED_ATTRIBS_Static = null;
        /*double*/ get INTERLEAVED_ATTRIBS_Static()
        {
            return _backingField_INTERLEAVED_ATTRIBS_Static;
        }
        /*double*/ _backingField_SEPARATE_ATTRIBS_Static = null;
        /*double*/ get SEPARATE_ATTRIBS_Static()
        {
            return _backingField_SEPARATE_ATTRIBS_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_BINDING_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_BINDING_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_BINDING_Static;
        }
        /*double*/ _backingField_RGBA32UI_Static = null;
        /*double*/ get RGBA32UI_Static()
        {
            return _backingField_RGBA32UI_Static;
        }
        /*double*/ _backingField_RGB32UI_Static = null;
        /*double*/ get RGB32UI_Static()
        {
            return _backingField_RGB32UI_Static;
        }
        /*double*/ _backingField_RGBA16UI_Static = null;
        /*double*/ get RGBA16UI_Static()
        {
            return _backingField_RGBA16UI_Static;
        }
        /*double*/ _backingField_RGB16UI_Static = null;
        /*double*/ get RGB16UI_Static()
        {
            return _backingField_RGB16UI_Static;
        }
        /*double*/ _backingField_RGBA8UI_Static = null;
        /*double*/ get RGBA8UI_Static()
        {
            return _backingField_RGBA8UI_Static;
        }
        /*double*/ _backingField_RGB8UI_Static = null;
        /*double*/ get RGB8UI_Static()
        {
            return _backingField_RGB8UI_Static;
        }
        /*double*/ _backingField_RGBA32I_Static = null;
        /*double*/ get RGBA32I_Static()
        {
            return _backingField_RGBA32I_Static;
        }
        /*double*/ _backingField_RGB32I_Static = null;
        /*double*/ get RGB32I_Static()
        {
            return _backingField_RGB32I_Static;
        }
        /*double*/ _backingField_RGBA16I_Static = null;
        /*double*/ get RGBA16I_Static()
        {
            return _backingField_RGBA16I_Static;
        }
        /*double*/ _backingField_RGB16I_Static = null;
        /*double*/ get RGB16I_Static()
        {
            return _backingField_RGB16I_Static;
        }
        /*double*/ _backingField_RGBA8I_Static = null;
        /*double*/ get RGBA8I_Static()
        {
            return _backingField_RGBA8I_Static;
        }
        /*double*/ _backingField_RGB8I_Static = null;
        /*double*/ get RGB8I_Static()
        {
            return _backingField_RGB8I_Static;
        }
        /*double*/ _backingField_RED_INTEGER_Static = null;
        /*double*/ get RED_INTEGER_Static()
        {
            return _backingField_RED_INTEGER_Static;
        }
        /*double*/ _backingField_RGB_INTEGER_Static = null;
        /*double*/ get RGB_INTEGER_Static()
        {
            return _backingField_RGB_INTEGER_Static;
        }
        /*double*/ _backingField_RGBA_INTEGER_Static = null;
        /*double*/ get RGBA_INTEGER_Static()
        {
            return _backingField_RGBA_INTEGER_Static;
        }
        /*double*/ _backingField_SAMPLER_2D_ARRAY_Static = null;
        /*double*/ get SAMPLER_2D_ARRAY_Static()
        {
            return _backingField_SAMPLER_2D_ARRAY_Static;
        }
        /*double*/ _backingField_SAMPLER_2D_ARRAY_SHADOW_Static = null;
        /*double*/ get SAMPLER_2D_ARRAY_SHADOW_Static()
        {
            return _backingField_SAMPLER_2D_ARRAY_SHADOW_Static;
        }
        /*double*/ _backingField_SAMPLER_CUBE_SHADOW_Static = null;
        /*double*/ get SAMPLER_CUBE_SHADOW_Static()
        {
            return _backingField_SAMPLER_CUBE_SHADOW_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_VEC2_Static = null;
        /*double*/ get UNSIGNED_INT_VEC2_Static()
        {
            return _backingField_UNSIGNED_INT_VEC2_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_VEC3_Static = null;
        /*double*/ get UNSIGNED_INT_VEC3_Static()
        {
            return _backingField_UNSIGNED_INT_VEC3_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_VEC4_Static = null;
        /*double*/ get UNSIGNED_INT_VEC4_Static()
        {
            return _backingField_UNSIGNED_INT_VEC4_Static;
        }
        /*double*/ _backingField_INT_SAMPLER_2D_Static = null;
        /*double*/ get INT_SAMPLER_2D_Static()
        {
            return _backingField_INT_SAMPLER_2D_Static;
        }
        /*double*/ _backingField_INT_SAMPLER_3D_Static = null;
        /*double*/ get INT_SAMPLER_3D_Static()
        {
            return _backingField_INT_SAMPLER_3D_Static;
        }
        /*double*/ _backingField_INT_SAMPLER_CUBE_Static = null;
        /*double*/ get INT_SAMPLER_CUBE_Static()
        {
            return _backingField_INT_SAMPLER_CUBE_Static;
        }
        /*double*/ _backingField_INT_SAMPLER_2D_ARRAY_Static = null;
        /*double*/ get INT_SAMPLER_2D_ARRAY_Static()
        {
            return _backingField_INT_SAMPLER_2D_ARRAY_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_2D_Static = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_2D_Static()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_2D_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_3D_Static = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_3D_Static()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_3D_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_CUBE_Static = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_CUBE_Static()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_CUBE_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_2D_ARRAY_Static = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_2D_ARRAY_Static()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_2D_ARRAY_Static;
        }
        /*double*/ _backingField_DEPTH_COMPONENT32F_Static = null;
        /*double*/ get DEPTH_COMPONENT32F_Static()
        {
            return _backingField_DEPTH_COMPONENT32F_Static;
        }
        /*double*/ _backingField_DEPTH32F_STENCIL8_Static = null;
        /*double*/ get DEPTH32F_STENCIL8_Static()
        {
            return _backingField_DEPTH32F_STENCIL8_Static;
        }
        /*double*/ _backingField_FLOAT_32_UNSIGNED_INT_24_8_REV_Static = null;
        /*double*/ get FLOAT_32_UNSIGNED_INT_24_8_REV_Static()
        {
            return _backingField_FLOAT_32_UNSIGNED_INT_24_8_REV_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING_Static = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING_Static()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE_Static = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE_Static()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_RED_SIZE_Static = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_RED_SIZE_Static()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_RED_SIZE_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE_Static = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_GREEN_SIZE_Static()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE_Static = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_BLUE_SIZE_Static()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE_Static = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE_Static()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE_Static = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE_Static()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE_Static = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE_Static()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_DEFAULT_Static = null;
        /*double*/ get FRAMEBUFFER_DEFAULT_Static()
        {
            return _backingField_FRAMEBUFFER_DEFAULT_Static;
        }
        /*double*/ _backingField_UNSIGNED_INT_24_8_Static = null;
        /*double*/ get UNSIGNED_INT_24_8_Static()
        {
            return _backingField_UNSIGNED_INT_24_8_Static;
        }
        /*double*/ _backingField_DEPTH24_STENCIL8_Static = null;
        /*double*/ get DEPTH24_STENCIL8_Static()
        {
            return _backingField_DEPTH24_STENCIL8_Static;
        }
        /*double*/ _backingField_UNSIGNED_NORMALIZED_Static = null;
        /*double*/ get UNSIGNED_NORMALIZED_Static()
        {
            return _backingField_UNSIGNED_NORMALIZED_Static;
        }
        /*double*/ _backingField_DRAW_FRAMEBUFFER_BINDING_Static = null;
        /*double*/ get DRAW_FRAMEBUFFER_BINDING_Static()
        {
            return _backingField_DRAW_FRAMEBUFFER_BINDING_Static;
        }
        /*double*/ _backingField_READ_FRAMEBUFFER_Static = null;
        /*double*/ get READ_FRAMEBUFFER_Static()
        {
            return _backingField_READ_FRAMEBUFFER_Static;
        }
        /*double*/ _backingField_DRAW_FRAMEBUFFER_Static = null;
        /*double*/ get DRAW_FRAMEBUFFER_Static()
        {
            return _backingField_DRAW_FRAMEBUFFER_Static;
        }
        /*double*/ _backingField_READ_FRAMEBUFFER_BINDING_Static = null;
        /*double*/ get READ_FRAMEBUFFER_BINDING_Static()
        {
            return _backingField_READ_FRAMEBUFFER_BINDING_Static;
        }
        /*double*/ _backingField_RENDERBUFFER_SAMPLES_Static = null;
        /*double*/ get RENDERBUFFER_SAMPLES_Static()
        {
            return _backingField_RENDERBUFFER_SAMPLES_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_Static = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_Static()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER_Static;
        }
        /*double*/ _backingField_MAX_COLOR_ATTACHMENTS_Static = null;
        /*double*/ get MAX_COLOR_ATTACHMENTS_Static()
        {
            return _backingField_MAX_COLOR_ATTACHMENTS_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT1_Static = null;
        /*double*/ get COLOR_ATTACHMENT1_Static()
        {
            return _backingField_COLOR_ATTACHMENT1_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT2_Static = null;
        /*double*/ get COLOR_ATTACHMENT2_Static()
        {
            return _backingField_COLOR_ATTACHMENT2_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT3_Static = null;
        /*double*/ get COLOR_ATTACHMENT3_Static()
        {
            return _backingField_COLOR_ATTACHMENT3_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT4_Static = null;
        /*double*/ get COLOR_ATTACHMENT4_Static()
        {
            return _backingField_COLOR_ATTACHMENT4_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT5_Static = null;
        /*double*/ get COLOR_ATTACHMENT5_Static()
        {
            return _backingField_COLOR_ATTACHMENT5_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT6_Static = null;
        /*double*/ get COLOR_ATTACHMENT6_Static()
        {
            return _backingField_COLOR_ATTACHMENT6_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT7_Static = null;
        /*double*/ get COLOR_ATTACHMENT7_Static()
        {
            return _backingField_COLOR_ATTACHMENT7_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT8_Static = null;
        /*double*/ get COLOR_ATTACHMENT8_Static()
        {
            return _backingField_COLOR_ATTACHMENT8_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT9_Static = null;
        /*double*/ get COLOR_ATTACHMENT9_Static()
        {
            return _backingField_COLOR_ATTACHMENT9_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT10_Static = null;
        /*double*/ get COLOR_ATTACHMENT10_Static()
        {
            return _backingField_COLOR_ATTACHMENT10_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT11_Static = null;
        /*double*/ get COLOR_ATTACHMENT11_Static()
        {
            return _backingField_COLOR_ATTACHMENT11_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT12_Static = null;
        /*double*/ get COLOR_ATTACHMENT12_Static()
        {
            return _backingField_COLOR_ATTACHMENT12_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT13_Static = null;
        /*double*/ get COLOR_ATTACHMENT13_Static()
        {
            return _backingField_COLOR_ATTACHMENT13_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT14_Static = null;
        /*double*/ get COLOR_ATTACHMENT14_Static()
        {
            return _backingField_COLOR_ATTACHMENT14_Static;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT15_Static = null;
        /*double*/ get COLOR_ATTACHMENT15_Static()
        {
            return _backingField_COLOR_ATTACHMENT15_Static;
        }
        /*double*/ _backingField_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE_Static = null;
        /*double*/ get FRAMEBUFFER_INCOMPLETE_MULTISAMPLE_Static()
        {
            return _backingField_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE_Static;
        }
        /*double*/ _backingField_MAX_SAMPLES_Static = null;
        /*double*/ get MAX_SAMPLES_Static()
        {
            return _backingField_MAX_SAMPLES_Static;
        }
        /*double*/ _backingField_HALF_FLOAT_Static = null;
        /*double*/ get HALF_FLOAT_Static()
        {
            return _backingField_HALF_FLOAT_Static;
        }
        /*double*/ _backingField_RG_Static = null;
        /*double*/ get RG_Static()
        {
            return _backingField_RG_Static;
        }
        /*double*/ _backingField_RG_INTEGER_Static = null;
        /*double*/ get RG_INTEGER_Static()
        {
            return _backingField_RG_INTEGER_Static;
        }
        /*double*/ _backingField_R8_Static = null;
        /*double*/ get R8_Static()
        {
            return _backingField_R8_Static;
        }
        /*double*/ _backingField_RG8_Static = null;
        /*double*/ get RG8_Static()
        {
            return _backingField_RG8_Static;
        }
        /*double*/ _backingField_R16F_Static = null;
        /*double*/ get R16F_Static()
        {
            return _backingField_R16F_Static;
        }
        /*double*/ _backingField_R32F_Static = null;
        /*double*/ get R32F_Static()
        {
            return _backingField_R32F_Static;
        }
        /*double*/ _backingField_RG16F_Static = null;
        /*double*/ get RG16F_Static()
        {
            return _backingField_RG16F_Static;
        }
        /*double*/ _backingField_RG32F_Static = null;
        /*double*/ get RG32F_Static()
        {
            return _backingField_RG32F_Static;
        }
        /*double*/ _backingField_R8I_Static = null;
        /*double*/ get R8I_Static()
        {
            return _backingField_R8I_Static;
        }
        /*double*/ _backingField_R8UI_Static = null;
        /*double*/ get R8UI_Static()
        {
            return _backingField_R8UI_Static;
        }
        /*double*/ _backingField_R16I_Static = null;
        /*double*/ get R16I_Static()
        {
            return _backingField_R16I_Static;
        }
        /*double*/ _backingField_R16UI_Static = null;
        /*double*/ get R16UI_Static()
        {
            return _backingField_R16UI_Static;
        }
        /*double*/ _backingField_R32I_Static = null;
        /*double*/ get R32I_Static()
        {
            return _backingField_R32I_Static;
        }
        /*double*/ _backingField_R32UI_Static = null;
        /*double*/ get R32UI_Static()
        {
            return _backingField_R32UI_Static;
        }
        /*double*/ _backingField_RG8I_Static = null;
        /*double*/ get RG8I_Static()
        {
            return _backingField_RG8I_Static;
        }
        /*double*/ _backingField_RG8UI_Static = null;
        /*double*/ get RG8UI_Static()
        {
            return _backingField_RG8UI_Static;
        }
        /*double*/ _backingField_RG16I_Static = null;
        /*double*/ get RG16I_Static()
        {
            return _backingField_RG16I_Static;
        }
        /*double*/ _backingField_RG16UI_Static = null;
        /*double*/ get RG16UI_Static()
        {
            return _backingField_RG16UI_Static;
        }
        /*double*/ _backingField_RG32I_Static = null;
        /*double*/ get RG32I_Static()
        {
            return _backingField_RG32I_Static;
        }
        /*double*/ _backingField_RG32UI_Static = null;
        /*double*/ get RG32UI_Static()
        {
            return _backingField_RG32UI_Static;
        }
        /*double*/ _backingField_VERTEX_ARRAY_BINDING_Static = null;
        /*double*/ get VERTEX_ARRAY_BINDING_Static()
        {
            return _backingField_VERTEX_ARRAY_BINDING_Static;
        }
        /*double*/ _backingField_R8_SNORM_Static = null;
        /*double*/ get R8_SNORM_Static()
        {
            return _backingField_R8_SNORM_Static;
        }
        /*double*/ _backingField_RG8_SNORM_Static = null;
        /*double*/ get RG8_SNORM_Static()
        {
            return _backingField_RG8_SNORM_Static;
        }
        /*double*/ _backingField_RGB8_SNORM_Static = null;
        /*double*/ get RGB8_SNORM_Static()
        {
            return _backingField_RGB8_SNORM_Static;
        }
        /*double*/ _backingField_RGBA8_SNORM_Static = null;
        /*double*/ get RGBA8_SNORM_Static()
        {
            return _backingField_RGBA8_SNORM_Static;
        }
        /*double*/ _backingField_SIGNED_NORMALIZED_Static = null;
        /*double*/ get SIGNED_NORMALIZED_Static()
        {
            return _backingField_SIGNED_NORMALIZED_Static;
        }
        /*double*/ _backingField_COPY_READ_BUFFER_Static = null;
        /*double*/ get COPY_READ_BUFFER_Static()
        {
            return _backingField_COPY_READ_BUFFER_Static;
        }
        /*double*/ _backingField_COPY_WRITE_BUFFER_Static = null;
        /*double*/ get COPY_WRITE_BUFFER_Static()
        {
            return _backingField_COPY_WRITE_BUFFER_Static;
        }
        /*double*/ _backingField_COPY_READ_BUFFER_BINDING_Static = null;
        /*double*/ get COPY_READ_BUFFER_BINDING_Static()
        {
            return _backingField_COPY_READ_BUFFER_BINDING_Static;
        }
        /*double*/ _backingField_COPY_WRITE_BUFFER_BINDING_Static = null;
        /*double*/ get COPY_WRITE_BUFFER_BINDING_Static()
        {
            return _backingField_COPY_WRITE_BUFFER_BINDING_Static;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_Static = null;
        /*double*/ get UNIFORM_BUFFER_Static()
        {
            return _backingField_UNIFORM_BUFFER_Static;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_BINDING_Static = null;
        /*double*/ get UNIFORM_BUFFER_BINDING_Static()
        {
            return _backingField_UNIFORM_BUFFER_BINDING_Static;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_START_Static = null;
        /*double*/ get UNIFORM_BUFFER_START_Static()
        {
            return _backingField_UNIFORM_BUFFER_START_Static;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_SIZE_Static = null;
        /*double*/ get UNIFORM_BUFFER_SIZE_Static()
        {
            return _backingField_UNIFORM_BUFFER_SIZE_Static;
        }
        /*double*/ _backingField_MAX_VERTEX_UNIFORM_BLOCKS_Static = null;
        /*double*/ get MAX_VERTEX_UNIFORM_BLOCKS_Static()
        {
            return _backingField_MAX_VERTEX_UNIFORM_BLOCKS_Static;
        }
        /*double*/ _backingField_MAX_FRAGMENT_UNIFORM_BLOCKS_Static = null;
        /*double*/ get MAX_FRAGMENT_UNIFORM_BLOCKS_Static()
        {
            return _backingField_MAX_FRAGMENT_UNIFORM_BLOCKS_Static;
        }
        /*double*/ _backingField_MAX_COMBINED_UNIFORM_BLOCKS_Static = null;
        /*double*/ get MAX_COMBINED_UNIFORM_BLOCKS_Static()
        {
            return _backingField_MAX_COMBINED_UNIFORM_BLOCKS_Static;
        }
        /*double*/ _backingField_MAX_UNIFORM_BUFFER_BINDINGS_Static = null;
        /*double*/ get MAX_UNIFORM_BUFFER_BINDINGS_Static()
        {
            return _backingField_MAX_UNIFORM_BUFFER_BINDINGS_Static;
        }
        /*double*/ _backingField_MAX_UNIFORM_BLOCK_SIZE_Static = null;
        /*double*/ get MAX_UNIFORM_BLOCK_SIZE_Static()
        {
            return _backingField_MAX_UNIFORM_BLOCK_SIZE_Static;
        }
        /*double*/ _backingField_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS_Static = null;
        /*double*/ get MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS_Static()
        {
            return _backingField_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS_Static;
        }
        /*double*/ _backingField_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS_Static = null;
        /*double*/ get MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS_Static()
        {
            return _backingField_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS_Static;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_OFFSET_ALIGNMENT_Static = null;
        /*double*/ get UNIFORM_BUFFER_OFFSET_ALIGNMENT_Static()
        {
            return _backingField_UNIFORM_BUFFER_OFFSET_ALIGNMENT_Static;
        }
        /*double*/ _backingField_ACTIVE_UNIFORM_BLOCKS_Static = null;
        /*double*/ get ACTIVE_UNIFORM_BLOCKS_Static()
        {
            return _backingField_ACTIVE_UNIFORM_BLOCKS_Static;
        }
        /*double*/ _backingField_UNIFORM_TYPE_Static = null;
        /*double*/ get UNIFORM_TYPE_Static()
        {
            return _backingField_UNIFORM_TYPE_Static;
        }
        /*double*/ _backingField_UNIFORM_SIZE_Static = null;
        /*double*/ get UNIFORM_SIZE_Static()
        {
            return _backingField_UNIFORM_SIZE_Static;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_INDEX_Static = null;
        /*double*/ get UNIFORM_BLOCK_INDEX_Static()
        {
            return _backingField_UNIFORM_BLOCK_INDEX_Static;
        }
        /*double*/ _backingField_UNIFORM_OFFSET_Static = null;
        /*double*/ get UNIFORM_OFFSET_Static()
        {
            return _backingField_UNIFORM_OFFSET_Static;
        }
        /*double*/ _backingField_UNIFORM_ARRAY_STRIDE_Static = null;
        /*double*/ get UNIFORM_ARRAY_STRIDE_Static()
        {
            return _backingField_UNIFORM_ARRAY_STRIDE_Static;
        }
        /*double*/ _backingField_UNIFORM_MATRIX_STRIDE_Static = null;
        /*double*/ get UNIFORM_MATRIX_STRIDE_Static()
        {
            return _backingField_UNIFORM_MATRIX_STRIDE_Static;
        }
        /*double*/ _backingField_UNIFORM_IS_ROW_MAJOR_Static = null;
        /*double*/ get UNIFORM_IS_ROW_MAJOR_Static()
        {
            return _backingField_UNIFORM_IS_ROW_MAJOR_Static;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_BINDING_Static = null;
        /*double*/ get UNIFORM_BLOCK_BINDING_Static()
        {
            return _backingField_UNIFORM_BLOCK_BINDING_Static;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_DATA_SIZE_Static = null;
        /*double*/ get UNIFORM_BLOCK_DATA_SIZE_Static()
        {
            return _backingField_UNIFORM_BLOCK_DATA_SIZE_Static;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORMS_Static = null;
        /*double*/ get UNIFORM_BLOCK_ACTIVE_UNIFORMS_Static()
        {
            return _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORMS_Static;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES_Static = null;
        /*double*/ get UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES_Static()
        {
            return _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES_Static;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER_Static = null;
        /*double*/ get UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER_Static()
        {
            return _backingField_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER_Static;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER_Static = null;
        /*double*/ get UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER_Static()
        {
            return _backingField_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER_Static;
        }
        /*double*/ _backingField_INVALID_INDEX_Static = null;
        /*double*/ get INVALID_INDEX_Static()
        {
            return _backingField_INVALID_INDEX_Static;
        }
        /*double*/ _backingField_MAX_VERTEX_OUTPUT_COMPONENTS_Static = null;
        /*double*/ get MAX_VERTEX_OUTPUT_COMPONENTS_Static()
        {
            return _backingField_MAX_VERTEX_OUTPUT_COMPONENTS_Static;
        }
        /*double*/ _backingField_MAX_FRAGMENT_INPUT_COMPONENTS_Static = null;
        /*double*/ get MAX_FRAGMENT_INPUT_COMPONENTS_Static()
        {
            return _backingField_MAX_FRAGMENT_INPUT_COMPONENTS_Static;
        }
        /*double*/ _backingField_MAX_SERVER_WAIT_TIMEOUT_Static = null;
        /*double*/ get MAX_SERVER_WAIT_TIMEOUT_Static()
        {
            return _backingField_MAX_SERVER_WAIT_TIMEOUT_Static;
        }
        /*double*/ _backingField_OBJECT_TYPE_Static = null;
        /*double*/ get OBJECT_TYPE_Static()
        {
            return _backingField_OBJECT_TYPE_Static;
        }
        /*double*/ _backingField_SYNC_CONDITION_Static = null;
        /*double*/ get SYNC_CONDITION_Static()
        {
            return _backingField_SYNC_CONDITION_Static;
        }
        /*double*/ _backingField_SYNC_STATUS_Static = null;
        /*double*/ get SYNC_STATUS_Static()
        {
            return _backingField_SYNC_STATUS_Static;
        }
        /*double*/ _backingField_SYNC_FLAGS_Static = null;
        /*double*/ get SYNC_FLAGS_Static()
        {
            return _backingField_SYNC_FLAGS_Static;
        }
        /*double*/ _backingField_SYNC_FENCE_Static = null;
        /*double*/ get SYNC_FENCE_Static()
        {
            return _backingField_SYNC_FENCE_Static;
        }
        /*double*/ _backingField_SYNC_GPU_COMMANDS_COMPLETE_Static = null;
        /*double*/ get SYNC_GPU_COMMANDS_COMPLETE_Static()
        {
            return _backingField_SYNC_GPU_COMMANDS_COMPLETE_Static;
        }
        /*double*/ _backingField_UNSIGNALED_Static = null;
        /*double*/ get UNSIGNALED_Static()
        {
            return _backingField_UNSIGNALED_Static;
        }
        /*double*/ _backingField_SIGNALED_Static = null;
        /*double*/ get SIGNALED_Static()
        {
            return _backingField_SIGNALED_Static;
        }
        /*double*/ _backingField_ALREADY_SIGNALED_Static = null;
        /*double*/ get ALREADY_SIGNALED_Static()
        {
            return _backingField_ALREADY_SIGNALED_Static;
        }
        /*double*/ _backingField_TIMEOUT_EXPIRED_Static = null;
        /*double*/ get TIMEOUT_EXPIRED_Static()
        {
            return _backingField_TIMEOUT_EXPIRED_Static;
        }
        /*double*/ _backingField_CONDITION_SATISFIED_Static = null;
        /*double*/ get CONDITION_SATISFIED_Static()
        {
            return _backingField_CONDITION_SATISFIED_Static;
        }
        /*double*/ _backingField_WAIT_FAILED_Static = null;
        /*double*/ get WAIT_FAILED_Static()
        {
            return _backingField_WAIT_FAILED_Static;
        }
        /*double*/ _backingField_SYNC_FLUSH_COMMANDS_BIT_Static = null;
        /*double*/ get SYNC_FLUSH_COMMANDS_BIT_Static()
        {
            return _backingField_SYNC_FLUSH_COMMANDS_BIT_Static;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_DIVISOR_Static = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_DIVISOR_Static()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_DIVISOR_Static;
        }
        /*double*/ _backingField_ANY_SAMPLES_PASSED_Static = null;
        /*double*/ get ANY_SAMPLES_PASSED_Static()
        {
            return _backingField_ANY_SAMPLES_PASSED_Static;
        }
        /*double*/ _backingField_ANY_SAMPLES_PASSED_CONSERVATIVE_Static = null;
        /*double*/ get ANY_SAMPLES_PASSED_CONSERVATIVE_Static()
        {
            return _backingField_ANY_SAMPLES_PASSED_CONSERVATIVE_Static;
        }
        /*double*/ _backingField_SAMPLER_BINDING_Static = null;
        /*double*/ get SAMPLER_BINDING_Static()
        {
            return _backingField_SAMPLER_BINDING_Static;
        }
        /*double*/ _backingField_RGB10_A2UI_Static = null;
        /*double*/ get RGB10_A2UI_Static()
        {
            return _backingField_RGB10_A2UI_Static;
        }
        /*double*/ _backingField_INT_2_10_10_10_REV_Static = null;
        /*double*/ get INT_2_10_10_10_REV_Static()
        {
            return _backingField_INT_2_10_10_10_REV_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_PAUSED_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_PAUSED_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_PAUSED_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_ACTIVE_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_ACTIVE_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_ACTIVE_Static;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BINDING_Static = null;
        /*double*/ get TRANSFORM_FEEDBACK_BINDING_Static()
        {
            return _backingField_TRANSFORM_FEEDBACK_BINDING_Static;
        }
        /*double*/ _backingField_TEXTURE_IMMUTABLE_FORMAT_Static = null;
        /*double*/ get TEXTURE_IMMUTABLE_FORMAT_Static()
        {
            return _backingField_TEXTURE_IMMUTABLE_FORMAT_Static;
        }
        /*double*/ _backingField_MAX_ELEMENT_INDEX_Static = null;
        /*double*/ get MAX_ELEMENT_INDEX_Static()
        {
            return _backingField_MAX_ELEMENT_INDEX_Static;
        }
        /*double*/ _backingField_TEXTURE_IMMUTABLE_LEVELS_Static = null;
        /*double*/ get TEXTURE_IMMUTABLE_LEVELS_Static()
        {
            return _backingField_TEXTURE_IMMUTABLE_LEVELS_Static;
        }
        /*double*/ _backingField_TIMEOUT_IGNORED_Static = null;
        /*double*/ get TIMEOUT_IGNORED_Static()
        {
            return _backingField_TIMEOUT_IGNORED_Static;
        }
        /*double*/ _backingField_MAX_CLIENT_WAIT_TIMEOUT_WEBGL_Static = null;
        /*double*/ get MAX_CLIENT_WAIT_TIMEOUT_WEBGL_Static()
        {
            return _backingField_MAX_CLIENT_WAIT_TIMEOUT_WEBGL_Static;
        }
        /*double*/ _backingField_READ_BUFFER = null;
        /*double*/ get READ_BUFFER()
        {
            return _backingField_READ_BUFFER;
        }
        /*double*/ _backingField_UNPACK_ROW_LENGTH = null;
        /*double*/ get UNPACK_ROW_LENGTH()
        {
            return _backingField_UNPACK_ROW_LENGTH;
        }
        /*double*/ _backingField_UNPACK_SKIP_ROWS = null;
        /*double*/ get UNPACK_SKIP_ROWS()
        {
            return _backingField_UNPACK_SKIP_ROWS;
        }
        /*double*/ _backingField_UNPACK_SKIP_PIXELS = null;
        /*double*/ get UNPACK_SKIP_PIXELS()
        {
            return _backingField_UNPACK_SKIP_PIXELS;
        }
        /*double*/ _backingField_PACK_ROW_LENGTH = null;
        /*double*/ get PACK_ROW_LENGTH()
        {
            return _backingField_PACK_ROW_LENGTH;
        }
        /*double*/ _backingField_PACK_SKIP_ROWS = null;
        /*double*/ get PACK_SKIP_ROWS()
        {
            return _backingField_PACK_SKIP_ROWS;
        }
        /*double*/ _backingField_PACK_SKIP_PIXELS = null;
        /*double*/ get PACK_SKIP_PIXELS()
        {
            return _backingField_PACK_SKIP_PIXELS;
        }
        /*double*/ _backingField_COLOR = null;
        /*double*/ get COLOR()
        {
            return _backingField_COLOR;
        }
        /*double*/ _backingField_DEPTH = null;
        /*double*/ get DEPTH()
        {
            return _backingField_DEPTH;
        }
        /*double*/ _backingField_STENCIL = null;
        /*double*/ get STENCIL()
        {
            return _backingField_STENCIL;
        }
        /*double*/ _backingField_RED = null;
        /*double*/ get RED()
        {
            return _backingField_RED;
        }
        /*double*/ _backingField_RGB8 = null;
        /*double*/ get RGB8()
        {
            return _backingField_RGB8;
        }
        /*double*/ _backingField_RGBA8 = null;
        /*double*/ get RGBA8()
        {
            return _backingField_RGBA8;
        }
        /*double*/ _backingField_RGB10_A2 = null;
        /*double*/ get RGB10_A2()
        {
            return _backingField_RGB10_A2;
        }
        /*double*/ _backingField_TEXTURE_BINDING_3D = null;
        /*double*/ get TEXTURE_BINDING_3D()
        {
            return _backingField_TEXTURE_BINDING_3D;
        }
        /*double*/ _backingField_UNPACK_SKIP_IMAGES = null;
        /*double*/ get UNPACK_SKIP_IMAGES()
        {
            return _backingField_UNPACK_SKIP_IMAGES;
        }
        /*double*/ _backingField_UNPACK_IMAGE_HEIGHT = null;
        /*double*/ get UNPACK_IMAGE_HEIGHT()
        {
            return _backingField_UNPACK_IMAGE_HEIGHT;
        }
        /*double*/ _backingField_TEXTURE_3D = null;
        /*double*/ get TEXTURE_3D()
        {
            return _backingField_TEXTURE_3D;
        }
        /*double*/ _backingField_TEXTURE_WRAP_R = null;
        /*double*/ get TEXTURE_WRAP_R()
        {
            return _backingField_TEXTURE_WRAP_R;
        }
        /*double*/ _backingField_MAX_3D_TEXTURE_SIZE = null;
        /*double*/ get MAX_3D_TEXTURE_SIZE()
        {
            return _backingField_MAX_3D_TEXTURE_SIZE;
        }
        /*double*/ _backingField_UNSIGNED_INT_2_10_10_10_REV = null;
        /*double*/ get UNSIGNED_INT_2_10_10_10_REV()
        {
            return _backingField_UNSIGNED_INT_2_10_10_10_REV;
        }
        /*double*/ _backingField_MAX_ELEMENTS_VERTICES = null;
        /*double*/ get MAX_ELEMENTS_VERTICES()
        {
            return _backingField_MAX_ELEMENTS_VERTICES;
        }
        /*double*/ _backingField_MAX_ELEMENTS_INDICES = null;
        /*double*/ get MAX_ELEMENTS_INDICES()
        {
            return _backingField_MAX_ELEMENTS_INDICES;
        }
        /*double*/ _backingField_TEXTURE_MIN_LOD = null;
        /*double*/ get TEXTURE_MIN_LOD()
        {
            return _backingField_TEXTURE_MIN_LOD;
        }
        /*double*/ _backingField_TEXTURE_MAX_LOD = null;
        /*double*/ get TEXTURE_MAX_LOD()
        {
            return _backingField_TEXTURE_MAX_LOD;
        }
        /*double*/ _backingField_TEXTURE_BASE_LEVEL = null;
        /*double*/ get TEXTURE_BASE_LEVEL()
        {
            return _backingField_TEXTURE_BASE_LEVEL;
        }
        /*double*/ _backingField_TEXTURE_MAX_LEVEL = null;
        /*double*/ get TEXTURE_MAX_LEVEL()
        {
            return _backingField_TEXTURE_MAX_LEVEL;
        }
        /*double*/ _backingField_MIN = null;
        /*double*/ get MIN()
        {
            return _backingField_MIN;
        }
        /*double*/ _backingField_MAX = null;
        /*double*/ get MAX()
        {
            return _backingField_MAX;
        }
        /*double*/ _backingField_DEPTH_COMPONENT24 = null;
        /*double*/ get DEPTH_COMPONENT24()
        {
            return _backingField_DEPTH_COMPONENT24;
        }
        /*double*/ _backingField_MAX_TEXTURE_LOD_BIAS = null;
        /*double*/ get MAX_TEXTURE_LOD_BIAS()
        {
            return _backingField_MAX_TEXTURE_LOD_BIAS;
        }
        /*double*/ _backingField_TEXTURE_COMPARE_MODE = null;
        /*double*/ get TEXTURE_COMPARE_MODE()
        {
            return _backingField_TEXTURE_COMPARE_MODE;
        }
        /*double*/ _backingField_TEXTURE_COMPARE_FUNC = null;
        /*double*/ get TEXTURE_COMPARE_FUNC()
        {
            return _backingField_TEXTURE_COMPARE_FUNC;
        }
        /*double*/ _backingField_CURRENT_QUERY = null;
        /*double*/ get CURRENT_QUERY()
        {
            return _backingField_CURRENT_QUERY;
        }
        /*double*/ _backingField_QUERY_RESULT = null;
        /*double*/ get QUERY_RESULT()
        {
            return _backingField_QUERY_RESULT;
        }
        /*double*/ _backingField_QUERY_RESULT_AVAILABLE = null;
        /*double*/ get QUERY_RESULT_AVAILABLE()
        {
            return _backingField_QUERY_RESULT_AVAILABLE;
        }
        /*double*/ _backingField_STREAM_READ = null;
        /*double*/ get STREAM_READ()
        {
            return _backingField_STREAM_READ;
        }
        /*double*/ _backingField_STREAM_COPY = null;
        /*double*/ get STREAM_COPY()
        {
            return _backingField_STREAM_COPY;
        }
        /*double*/ _backingField_STATIC_READ = null;
        /*double*/ get STATIC_READ()
        {
            return _backingField_STATIC_READ;
        }
        /*double*/ _backingField_STATIC_COPY = null;
        /*double*/ get STATIC_COPY()
        {
            return _backingField_STATIC_COPY;
        }
        /*double*/ _backingField_DYNAMIC_READ = null;
        /*double*/ get DYNAMIC_READ()
        {
            return _backingField_DYNAMIC_READ;
        }
        /*double*/ _backingField_DYNAMIC_COPY = null;
        /*double*/ get DYNAMIC_COPY()
        {
            return _backingField_DYNAMIC_COPY;
        }
        /*double*/ _backingField_MAX_DRAW_BUFFERS = null;
        /*double*/ get MAX_DRAW_BUFFERS()
        {
            return _backingField_MAX_DRAW_BUFFERS;
        }
        /*double*/ _backingField_DRAW_BUFFER0 = null;
        /*double*/ get DRAW_BUFFER0()
        {
            return _backingField_DRAW_BUFFER0;
        }
        /*double*/ _backingField_DRAW_BUFFER1 = null;
        /*double*/ get DRAW_BUFFER1()
        {
            return _backingField_DRAW_BUFFER1;
        }
        /*double*/ _backingField_DRAW_BUFFER2 = null;
        /*double*/ get DRAW_BUFFER2()
        {
            return _backingField_DRAW_BUFFER2;
        }
        /*double*/ _backingField_DRAW_BUFFER3 = null;
        /*double*/ get DRAW_BUFFER3()
        {
            return _backingField_DRAW_BUFFER3;
        }
        /*double*/ _backingField_DRAW_BUFFER4 = null;
        /*double*/ get DRAW_BUFFER4()
        {
            return _backingField_DRAW_BUFFER4;
        }
        /*double*/ _backingField_DRAW_BUFFER5 = null;
        /*double*/ get DRAW_BUFFER5()
        {
            return _backingField_DRAW_BUFFER5;
        }
        /*double*/ _backingField_DRAW_BUFFER6 = null;
        /*double*/ get DRAW_BUFFER6()
        {
            return _backingField_DRAW_BUFFER6;
        }
        /*double*/ _backingField_DRAW_BUFFER7 = null;
        /*double*/ get DRAW_BUFFER7()
        {
            return _backingField_DRAW_BUFFER7;
        }
        /*double*/ _backingField_DRAW_BUFFER8 = null;
        /*double*/ get DRAW_BUFFER8()
        {
            return _backingField_DRAW_BUFFER8;
        }
        /*double*/ _backingField_DRAW_BUFFER9 = null;
        /*double*/ get DRAW_BUFFER9()
        {
            return _backingField_DRAW_BUFFER9;
        }
        /*double*/ _backingField_DRAW_BUFFER10 = null;
        /*double*/ get DRAW_BUFFER10()
        {
            return _backingField_DRAW_BUFFER10;
        }
        /*double*/ _backingField_DRAW_BUFFER11 = null;
        /*double*/ get DRAW_BUFFER11()
        {
            return _backingField_DRAW_BUFFER11;
        }
        /*double*/ _backingField_DRAW_BUFFER12 = null;
        /*double*/ get DRAW_BUFFER12()
        {
            return _backingField_DRAW_BUFFER12;
        }
        /*double*/ _backingField_DRAW_BUFFER13 = null;
        /*double*/ get DRAW_BUFFER13()
        {
            return _backingField_DRAW_BUFFER13;
        }
        /*double*/ _backingField_DRAW_BUFFER14 = null;
        /*double*/ get DRAW_BUFFER14()
        {
            return _backingField_DRAW_BUFFER14;
        }
        /*double*/ _backingField_DRAW_BUFFER15 = null;
        /*double*/ get DRAW_BUFFER15()
        {
            return _backingField_DRAW_BUFFER15;
        }
        /*double*/ _backingField_MAX_FRAGMENT_UNIFORM_COMPONENTS = null;
        /*double*/ get MAX_FRAGMENT_UNIFORM_COMPONENTS()
        {
            return _backingField_MAX_FRAGMENT_UNIFORM_COMPONENTS;
        }
        /*double*/ _backingField_MAX_VERTEX_UNIFORM_COMPONENTS = null;
        /*double*/ get MAX_VERTEX_UNIFORM_COMPONENTS()
        {
            return _backingField_MAX_VERTEX_UNIFORM_COMPONENTS;
        }
        /*double*/ _backingField_SAMPLER_3D = null;
        /*double*/ get SAMPLER_3D()
        {
            return _backingField_SAMPLER_3D;
        }
        /*double*/ _backingField_SAMPLER_2D_SHADOW = null;
        /*double*/ get SAMPLER_2D_SHADOW()
        {
            return _backingField_SAMPLER_2D_SHADOW;
        }
        /*double*/ _backingField_FRAGMENT_SHADER_DERIVATIVE_HINT = null;
        /*double*/ get FRAGMENT_SHADER_DERIVATIVE_HINT()
        {
            return _backingField_FRAGMENT_SHADER_DERIVATIVE_HINT;
        }
        /*double*/ _backingField_PIXEL_PACK_BUFFER = null;
        /*double*/ get PIXEL_PACK_BUFFER()
        {
            return _backingField_PIXEL_PACK_BUFFER;
        }
        /*double*/ _backingField_PIXEL_UNPACK_BUFFER = null;
        /*double*/ get PIXEL_UNPACK_BUFFER()
        {
            return _backingField_PIXEL_UNPACK_BUFFER;
        }
        /*double*/ _backingField_PIXEL_PACK_BUFFER_BINDING = null;
        /*double*/ get PIXEL_PACK_BUFFER_BINDING()
        {
            return _backingField_PIXEL_PACK_BUFFER_BINDING;
        }
        /*double*/ _backingField_PIXEL_UNPACK_BUFFER_BINDING = null;
        /*double*/ get PIXEL_UNPACK_BUFFER_BINDING()
        {
            return _backingField_PIXEL_UNPACK_BUFFER_BINDING;
        }
        /*double*/ _backingField_FLOAT_MAT2x3 = null;
        /*double*/ get FLOAT_MAT2x3()
        {
            return _backingField_FLOAT_MAT2x3;
        }
        /*double*/ _backingField_FLOAT_MAT2x4 = null;
        /*double*/ get FLOAT_MAT2x4()
        {
            return _backingField_FLOAT_MAT2x4;
        }
        /*double*/ _backingField_FLOAT_MAT3x2 = null;
        /*double*/ get FLOAT_MAT3x2()
        {
            return _backingField_FLOAT_MAT3x2;
        }
        /*double*/ _backingField_FLOAT_MAT3x4 = null;
        /*double*/ get FLOAT_MAT3x4()
        {
            return _backingField_FLOAT_MAT3x4;
        }
        /*double*/ _backingField_FLOAT_MAT4x2 = null;
        /*double*/ get FLOAT_MAT4x2()
        {
            return _backingField_FLOAT_MAT4x2;
        }
        /*double*/ _backingField_FLOAT_MAT4x3 = null;
        /*double*/ get FLOAT_MAT4x3()
        {
            return _backingField_FLOAT_MAT4x3;
        }
        /*double*/ _backingField_SRGB = null;
        /*double*/ get SRGB()
        {
            return _backingField_SRGB;
        }
        /*double*/ _backingField_SRGB8 = null;
        /*double*/ get SRGB8()
        {
            return _backingField_SRGB8;
        }
        /*double*/ _backingField_SRGB8_ALPHA8 = null;
        /*double*/ get SRGB8_ALPHA8()
        {
            return _backingField_SRGB8_ALPHA8;
        }
        /*double*/ _backingField_COMPARE_REF_TO_TEXTURE = null;
        /*double*/ get COMPARE_REF_TO_TEXTURE()
        {
            return _backingField_COMPARE_REF_TO_TEXTURE;
        }
        /*double*/ _backingField_RGBA32F = null;
        /*double*/ get RGBA32F()
        {
            return _backingField_RGBA32F;
        }
        /*double*/ _backingField_RGB32F = null;
        /*double*/ get RGB32F()
        {
            return _backingField_RGB32F;
        }
        /*double*/ _backingField_RGBA16F = null;
        /*double*/ get RGBA16F()
        {
            return _backingField_RGBA16F;
        }
        /*double*/ _backingField_RGB16F = null;
        /*double*/ get RGB16F()
        {
            return _backingField_RGB16F;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_INTEGER = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_INTEGER()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_INTEGER;
        }
        /*double*/ _backingField_MAX_ARRAY_TEXTURE_LAYERS = null;
        /*double*/ get MAX_ARRAY_TEXTURE_LAYERS()
        {
            return _backingField_MAX_ARRAY_TEXTURE_LAYERS;
        }
        /*double*/ _backingField_MIN_PROGRAM_TEXEL_OFFSET = null;
        /*double*/ get MIN_PROGRAM_TEXEL_OFFSET()
        {
            return _backingField_MIN_PROGRAM_TEXEL_OFFSET;
        }
        /*double*/ _backingField_MAX_PROGRAM_TEXEL_OFFSET = null;
        /*double*/ get MAX_PROGRAM_TEXEL_OFFSET()
        {
            return _backingField_MAX_PROGRAM_TEXEL_OFFSET;
        }
        /*double*/ _backingField_MAX_VARYING_COMPONENTS = null;
        /*double*/ get MAX_VARYING_COMPONENTS()
        {
            return _backingField_MAX_VARYING_COMPONENTS;
        }
        /*double*/ _backingField_TEXTURE_2D_ARRAY = null;
        /*double*/ get TEXTURE_2D_ARRAY()
        {
            return _backingField_TEXTURE_2D_ARRAY;
        }
        /*double*/ _backingField_TEXTURE_BINDING_2D_ARRAY = null;
        /*double*/ get TEXTURE_BINDING_2D_ARRAY()
        {
            return _backingField_TEXTURE_BINDING_2D_ARRAY;
        }
        /*double*/ _backingField_R11F_G11F_B10F = null;
        /*double*/ get R11F_G11F_B10F()
        {
            return _backingField_R11F_G11F_B10F;
        }
        /*double*/ _backingField_UNSIGNED_INT_10F_11F_11F_REV = null;
        /*double*/ get UNSIGNED_INT_10F_11F_11F_REV()
        {
            return _backingField_UNSIGNED_INT_10F_11F_11F_REV;
        }
        /*double*/ _backingField_RGB9_E5 = null;
        /*double*/ get RGB9_E5()
        {
            return _backingField_RGB9_E5;
        }
        /*double*/ _backingField_UNSIGNED_INT_5_9_9_9_REV = null;
        /*double*/ get UNSIGNED_INT_5_9_9_9_REV()
        {
            return _backingField_UNSIGNED_INT_5_9_9_9_REV;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_MODE = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_MODE()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_MODE;
        }
        /*double*/ _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = null;
        /*double*/ get MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS()
        {
            return _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_VARYINGS = null;
        /*double*/ get TRANSFORM_FEEDBACK_VARYINGS()
        {
            return _backingField_TRANSFORM_FEEDBACK_VARYINGS;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_START = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_START()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_START;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_SIZE = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_SIZE()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_SIZE;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = null;
        /*double*/ get TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN()
        {
            return _backingField_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN;
        }
        /*double*/ _backingField_RASTERIZER_DISCARD = null;
        /*double*/ get RASTERIZER_DISCARD()
        {
            return _backingField_RASTERIZER_DISCARD;
        }
        /*double*/ _backingField_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = null;
        /*double*/ get MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS()
        {
            return _backingField_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS;
        }
        /*double*/ _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = null;
        /*double*/ get MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS()
        {
            return _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS;
        }
        /*double*/ _backingField_INTERLEAVED_ATTRIBS = null;
        /*double*/ get INTERLEAVED_ATTRIBS()
        {
            return _backingField_INTERLEAVED_ATTRIBS;
        }
        /*double*/ _backingField_SEPARATE_ATTRIBS = null;
        /*double*/ get SEPARATE_ATTRIBS()
        {
            return _backingField_SEPARATE_ATTRIBS;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_BINDING = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_BINDING()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_BINDING;
        }
        /*double*/ _backingField_RGBA32UI = null;
        /*double*/ get RGBA32UI()
        {
            return _backingField_RGBA32UI;
        }
        /*double*/ _backingField_RGB32UI = null;
        /*double*/ get RGB32UI()
        {
            return _backingField_RGB32UI;
        }
        /*double*/ _backingField_RGBA16UI = null;
        /*double*/ get RGBA16UI()
        {
            return _backingField_RGBA16UI;
        }
        /*double*/ _backingField_RGB16UI = null;
        /*double*/ get RGB16UI()
        {
            return _backingField_RGB16UI;
        }
        /*double*/ _backingField_RGBA8UI = null;
        /*double*/ get RGBA8UI()
        {
            return _backingField_RGBA8UI;
        }
        /*double*/ _backingField_RGB8UI = null;
        /*double*/ get RGB8UI()
        {
            return _backingField_RGB8UI;
        }
        /*double*/ _backingField_RGBA32I = null;
        /*double*/ get RGBA32I()
        {
            return _backingField_RGBA32I;
        }
        /*double*/ _backingField_RGB32I = null;
        /*double*/ get RGB32I()
        {
            return _backingField_RGB32I;
        }
        /*double*/ _backingField_RGBA16I = null;
        /*double*/ get RGBA16I()
        {
            return _backingField_RGBA16I;
        }
        /*double*/ _backingField_RGB16I = null;
        /*double*/ get RGB16I()
        {
            return _backingField_RGB16I;
        }
        /*double*/ _backingField_RGBA8I = null;
        /*double*/ get RGBA8I()
        {
            return _backingField_RGBA8I;
        }
        /*double*/ _backingField_RGB8I = null;
        /*double*/ get RGB8I()
        {
            return _backingField_RGB8I;
        }
        /*double*/ _backingField_RED_INTEGER = null;
        /*double*/ get RED_INTEGER()
        {
            return _backingField_RED_INTEGER;
        }
        /*double*/ _backingField_RGB_INTEGER = null;
        /*double*/ get RGB_INTEGER()
        {
            return _backingField_RGB_INTEGER;
        }
        /*double*/ _backingField_RGBA_INTEGER = null;
        /*double*/ get RGBA_INTEGER()
        {
            return _backingField_RGBA_INTEGER;
        }
        /*double*/ _backingField_SAMPLER_2D_ARRAY = null;
        /*double*/ get SAMPLER_2D_ARRAY()
        {
            return _backingField_SAMPLER_2D_ARRAY;
        }
        /*double*/ _backingField_SAMPLER_2D_ARRAY_SHADOW = null;
        /*double*/ get SAMPLER_2D_ARRAY_SHADOW()
        {
            return _backingField_SAMPLER_2D_ARRAY_SHADOW;
        }
        /*double*/ _backingField_SAMPLER_CUBE_SHADOW = null;
        /*double*/ get SAMPLER_CUBE_SHADOW()
        {
            return _backingField_SAMPLER_CUBE_SHADOW;
        }
        /*double*/ _backingField_UNSIGNED_INT_VEC2 = null;
        /*double*/ get UNSIGNED_INT_VEC2()
        {
            return _backingField_UNSIGNED_INT_VEC2;
        }
        /*double*/ _backingField_UNSIGNED_INT_VEC3 = null;
        /*double*/ get UNSIGNED_INT_VEC3()
        {
            return _backingField_UNSIGNED_INT_VEC3;
        }
        /*double*/ _backingField_UNSIGNED_INT_VEC4 = null;
        /*double*/ get UNSIGNED_INT_VEC4()
        {
            return _backingField_UNSIGNED_INT_VEC4;
        }
        /*double*/ _backingField_INT_SAMPLER_2D = null;
        /*double*/ get INT_SAMPLER_2D()
        {
            return _backingField_INT_SAMPLER_2D;
        }
        /*double*/ _backingField_INT_SAMPLER_3D = null;
        /*double*/ get INT_SAMPLER_3D()
        {
            return _backingField_INT_SAMPLER_3D;
        }
        /*double*/ _backingField_INT_SAMPLER_CUBE = null;
        /*double*/ get INT_SAMPLER_CUBE()
        {
            return _backingField_INT_SAMPLER_CUBE;
        }
        /*double*/ _backingField_INT_SAMPLER_2D_ARRAY = null;
        /*double*/ get INT_SAMPLER_2D_ARRAY()
        {
            return _backingField_INT_SAMPLER_2D_ARRAY;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_2D = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_2D()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_2D;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_3D = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_3D()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_3D;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_CUBE = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_CUBE()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_CUBE;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_2D_ARRAY = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_2D_ARRAY()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_2D_ARRAY;
        }
        /*double*/ _backingField_DEPTH_COMPONENT32F = null;
        /*double*/ get DEPTH_COMPONENT32F()
        {
            return _backingField_DEPTH_COMPONENT32F;
        }
        /*double*/ _backingField_DEPTH32F_STENCIL8 = null;
        /*double*/ get DEPTH32F_STENCIL8()
        {
            return _backingField_DEPTH32F_STENCIL8;
        }
        /*double*/ _backingField_FLOAT_32_UNSIGNED_INT_24_8_REV = null;
        /*double*/ get FLOAT_32_UNSIGNED_INT_24_8_REV()
        {
            return _backingField_FLOAT_32_UNSIGNED_INT_24_8_REV;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_RED_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_RED_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_RED_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_GREEN_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_BLUE_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_DEFAULT = null;
        /*double*/ get FRAMEBUFFER_DEFAULT()
        {
            return _backingField_FRAMEBUFFER_DEFAULT;
        }
        /*double*/ _backingField_UNSIGNED_INT_24_8 = null;
        /*double*/ get UNSIGNED_INT_24_8()
        {
            return _backingField_UNSIGNED_INT_24_8;
        }
        /*double*/ _backingField_DEPTH24_STENCIL8 = null;
        /*double*/ get DEPTH24_STENCIL8()
        {
            return _backingField_DEPTH24_STENCIL8;
        }
        /*double*/ _backingField_UNSIGNED_NORMALIZED = null;
        /*double*/ get UNSIGNED_NORMALIZED()
        {
            return _backingField_UNSIGNED_NORMALIZED;
        }
        /*double*/ _backingField_DRAW_FRAMEBUFFER_BINDING = null;
        /*double*/ get DRAW_FRAMEBUFFER_BINDING()
        {
            return _backingField_DRAW_FRAMEBUFFER_BINDING;
        }
        /*double*/ _backingField_READ_FRAMEBUFFER = null;
        /*double*/ get READ_FRAMEBUFFER()
        {
            return _backingField_READ_FRAMEBUFFER;
        }
        /*double*/ _backingField_DRAW_FRAMEBUFFER = null;
        /*double*/ get DRAW_FRAMEBUFFER()
        {
            return _backingField_DRAW_FRAMEBUFFER;
        }
        /*double*/ _backingField_READ_FRAMEBUFFER_BINDING = null;
        /*double*/ get READ_FRAMEBUFFER_BINDING()
        {
            return _backingField_READ_FRAMEBUFFER_BINDING;
        }
        /*double*/ _backingField_RENDERBUFFER_SAMPLES = null;
        /*double*/ get RENDERBUFFER_SAMPLES()
        {
            return _backingField_RENDERBUFFER_SAMPLES;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER;
        }
        /*double*/ _backingField_MAX_COLOR_ATTACHMENTS = null;
        /*double*/ get MAX_COLOR_ATTACHMENTS()
        {
            return _backingField_MAX_COLOR_ATTACHMENTS;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT1 = null;
        /*double*/ get COLOR_ATTACHMENT1()
        {
            return _backingField_COLOR_ATTACHMENT1;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT2 = null;
        /*double*/ get COLOR_ATTACHMENT2()
        {
            return _backingField_COLOR_ATTACHMENT2;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT3 = null;
        /*double*/ get COLOR_ATTACHMENT3()
        {
            return _backingField_COLOR_ATTACHMENT3;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT4 = null;
        /*double*/ get COLOR_ATTACHMENT4()
        {
            return _backingField_COLOR_ATTACHMENT4;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT5 = null;
        /*double*/ get COLOR_ATTACHMENT5()
        {
            return _backingField_COLOR_ATTACHMENT5;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT6 = null;
        /*double*/ get COLOR_ATTACHMENT6()
        {
            return _backingField_COLOR_ATTACHMENT6;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT7 = null;
        /*double*/ get COLOR_ATTACHMENT7()
        {
            return _backingField_COLOR_ATTACHMENT7;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT8 = null;
        /*double*/ get COLOR_ATTACHMENT8()
        {
            return _backingField_COLOR_ATTACHMENT8;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT9 = null;
        /*double*/ get COLOR_ATTACHMENT9()
        {
            return _backingField_COLOR_ATTACHMENT9;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT10 = null;
        /*double*/ get COLOR_ATTACHMENT10()
        {
            return _backingField_COLOR_ATTACHMENT10;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT11 = null;
        /*double*/ get COLOR_ATTACHMENT11()
        {
            return _backingField_COLOR_ATTACHMENT11;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT12 = null;
        /*double*/ get COLOR_ATTACHMENT12()
        {
            return _backingField_COLOR_ATTACHMENT12;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT13 = null;
        /*double*/ get COLOR_ATTACHMENT13()
        {
            return _backingField_COLOR_ATTACHMENT13;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT14 = null;
        /*double*/ get COLOR_ATTACHMENT14()
        {
            return _backingField_COLOR_ATTACHMENT14;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT15 = null;
        /*double*/ get COLOR_ATTACHMENT15()
        {
            return _backingField_COLOR_ATTACHMENT15;
        }
        /*double*/ _backingField_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = null;
        /*double*/ get FRAMEBUFFER_INCOMPLETE_MULTISAMPLE()
        {
            return _backingField_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE;
        }
        /*double*/ _backingField_MAX_SAMPLES = null;
        /*double*/ get MAX_SAMPLES()
        {
            return _backingField_MAX_SAMPLES;
        }
        /*double*/ _backingField_HALF_FLOAT = null;
        /*double*/ get HALF_FLOAT()
        {
            return _backingField_HALF_FLOAT;
        }
        /*double*/ _backingField_RG = null;
        /*double*/ get RG()
        {
            return _backingField_RG;
        }
        /*double*/ _backingField_RG_INTEGER = null;
        /*double*/ get RG_INTEGER()
        {
            return _backingField_RG_INTEGER;
        }
        /*double*/ _backingField_R8 = null;
        /*double*/ get R8()
        {
            return _backingField_R8;
        }
        /*double*/ _backingField_RG8 = null;
        /*double*/ get RG8()
        {
            return _backingField_RG8;
        }
        /*double*/ _backingField_R16F = null;
        /*double*/ get R16F()
        {
            return _backingField_R16F;
        }
        /*double*/ _backingField_R32F = null;
        /*double*/ get R32F()
        {
            return _backingField_R32F;
        }
        /*double*/ _backingField_RG16F = null;
        /*double*/ get RG16F()
        {
            return _backingField_RG16F;
        }
        /*double*/ _backingField_RG32F = null;
        /*double*/ get RG32F()
        {
            return _backingField_RG32F;
        }
        /*double*/ _backingField_R8I = null;
        /*double*/ get R8I()
        {
            return _backingField_R8I;
        }
        /*double*/ _backingField_R8UI = null;
        /*double*/ get R8UI()
        {
            return _backingField_R8UI;
        }
        /*double*/ _backingField_R16I = null;
        /*double*/ get R16I()
        {
            return _backingField_R16I;
        }
        /*double*/ _backingField_R16UI = null;
        /*double*/ get R16UI()
        {
            return _backingField_R16UI;
        }
        /*double*/ _backingField_R32I = null;
        /*double*/ get R32I()
        {
            return _backingField_R32I;
        }
        /*double*/ _backingField_R32UI = null;
        /*double*/ get R32UI()
        {
            return _backingField_R32UI;
        }
        /*double*/ _backingField_RG8I = null;
        /*double*/ get RG8I()
        {
            return _backingField_RG8I;
        }
        /*double*/ _backingField_RG8UI = null;
        /*double*/ get RG8UI()
        {
            return _backingField_RG8UI;
        }
        /*double*/ _backingField_RG16I = null;
        /*double*/ get RG16I()
        {
            return _backingField_RG16I;
        }
        /*double*/ _backingField_RG16UI = null;
        /*double*/ get RG16UI()
        {
            return _backingField_RG16UI;
        }
        /*double*/ _backingField_RG32I = null;
        /*double*/ get RG32I()
        {
            return _backingField_RG32I;
        }
        /*double*/ _backingField_RG32UI = null;
        /*double*/ get RG32UI()
        {
            return _backingField_RG32UI;
        }
        /*double*/ _backingField_VERTEX_ARRAY_BINDING = null;
        /*double*/ get VERTEX_ARRAY_BINDING()
        {
            return _backingField_VERTEX_ARRAY_BINDING;
        }
        /*double*/ _backingField_R8_SNORM = null;
        /*double*/ get R8_SNORM()
        {
            return _backingField_R8_SNORM;
        }
        /*double*/ _backingField_RG8_SNORM = null;
        /*double*/ get RG8_SNORM()
        {
            return _backingField_RG8_SNORM;
        }
        /*double*/ _backingField_RGB8_SNORM = null;
        /*double*/ get RGB8_SNORM()
        {
            return _backingField_RGB8_SNORM;
        }
        /*double*/ _backingField_RGBA8_SNORM = null;
        /*double*/ get RGBA8_SNORM()
        {
            return _backingField_RGBA8_SNORM;
        }
        /*double*/ _backingField_SIGNED_NORMALIZED = null;
        /*double*/ get SIGNED_NORMALIZED()
        {
            return _backingField_SIGNED_NORMALIZED;
        }
        /*double*/ _backingField_COPY_READ_BUFFER = null;
        /*double*/ get COPY_READ_BUFFER()
        {
            return _backingField_COPY_READ_BUFFER;
        }
        /*double*/ _backingField_COPY_WRITE_BUFFER = null;
        /*double*/ get COPY_WRITE_BUFFER()
        {
            return _backingField_COPY_WRITE_BUFFER;
        }
        /*double*/ _backingField_COPY_READ_BUFFER_BINDING = null;
        /*double*/ get COPY_READ_BUFFER_BINDING()
        {
            return _backingField_COPY_READ_BUFFER_BINDING;
        }
        /*double*/ _backingField_COPY_WRITE_BUFFER_BINDING = null;
        /*double*/ get COPY_WRITE_BUFFER_BINDING()
        {
            return _backingField_COPY_WRITE_BUFFER_BINDING;
        }
        /*double*/ _backingField_UNIFORM_BUFFER = null;
        /*double*/ get UNIFORM_BUFFER()
        {
            return _backingField_UNIFORM_BUFFER;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_BINDING = null;
        /*double*/ get UNIFORM_BUFFER_BINDING()
        {
            return _backingField_UNIFORM_BUFFER_BINDING;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_START = null;
        /*double*/ get UNIFORM_BUFFER_START()
        {
            return _backingField_UNIFORM_BUFFER_START;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_SIZE = null;
        /*double*/ get UNIFORM_BUFFER_SIZE()
        {
            return _backingField_UNIFORM_BUFFER_SIZE;
        }
        /*double*/ _backingField_MAX_VERTEX_UNIFORM_BLOCKS = null;
        /*double*/ get MAX_VERTEX_UNIFORM_BLOCKS()
        {
            return _backingField_MAX_VERTEX_UNIFORM_BLOCKS;
        }
        /*double*/ _backingField_MAX_FRAGMENT_UNIFORM_BLOCKS = null;
        /*double*/ get MAX_FRAGMENT_UNIFORM_BLOCKS()
        {
            return _backingField_MAX_FRAGMENT_UNIFORM_BLOCKS;
        }
        /*double*/ _backingField_MAX_COMBINED_UNIFORM_BLOCKS = null;
        /*double*/ get MAX_COMBINED_UNIFORM_BLOCKS()
        {
            return _backingField_MAX_COMBINED_UNIFORM_BLOCKS;
        }
        /*double*/ _backingField_MAX_UNIFORM_BUFFER_BINDINGS = null;
        /*double*/ get MAX_UNIFORM_BUFFER_BINDINGS()
        {
            return _backingField_MAX_UNIFORM_BUFFER_BINDINGS;
        }
        /*double*/ _backingField_MAX_UNIFORM_BLOCK_SIZE = null;
        /*double*/ get MAX_UNIFORM_BLOCK_SIZE()
        {
            return _backingField_MAX_UNIFORM_BLOCK_SIZE;
        }
        /*double*/ _backingField_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = null;
        /*double*/ get MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS()
        {
            return _backingField_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS;
        }
        /*double*/ _backingField_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = null;
        /*double*/ get MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS()
        {
            return _backingField_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_OFFSET_ALIGNMENT = null;
        /*double*/ get UNIFORM_BUFFER_OFFSET_ALIGNMENT()
        {
            return _backingField_UNIFORM_BUFFER_OFFSET_ALIGNMENT;
        }
        /*double*/ _backingField_ACTIVE_UNIFORM_BLOCKS = null;
        /*double*/ get ACTIVE_UNIFORM_BLOCKS()
        {
            return _backingField_ACTIVE_UNIFORM_BLOCKS;
        }
        /*double*/ _backingField_UNIFORM_TYPE = null;
        /*double*/ get UNIFORM_TYPE()
        {
            return _backingField_UNIFORM_TYPE;
        }
        /*double*/ _backingField_UNIFORM_SIZE = null;
        /*double*/ get UNIFORM_SIZE()
        {
            return _backingField_UNIFORM_SIZE;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_INDEX = null;
        /*double*/ get UNIFORM_BLOCK_INDEX()
        {
            return _backingField_UNIFORM_BLOCK_INDEX;
        }
        /*double*/ _backingField_UNIFORM_OFFSET = null;
        /*double*/ get UNIFORM_OFFSET()
        {
            return _backingField_UNIFORM_OFFSET;
        }
        /*double*/ _backingField_UNIFORM_ARRAY_STRIDE = null;
        /*double*/ get UNIFORM_ARRAY_STRIDE()
        {
            return _backingField_UNIFORM_ARRAY_STRIDE;
        }
        /*double*/ _backingField_UNIFORM_MATRIX_STRIDE = null;
        /*double*/ get UNIFORM_MATRIX_STRIDE()
        {
            return _backingField_UNIFORM_MATRIX_STRIDE;
        }
        /*double*/ _backingField_UNIFORM_IS_ROW_MAJOR = null;
        /*double*/ get UNIFORM_IS_ROW_MAJOR()
        {
            return _backingField_UNIFORM_IS_ROW_MAJOR;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_BINDING = null;
        /*double*/ get UNIFORM_BLOCK_BINDING()
        {
            return _backingField_UNIFORM_BLOCK_BINDING;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_DATA_SIZE = null;
        /*double*/ get UNIFORM_BLOCK_DATA_SIZE()
        {
            return _backingField_UNIFORM_BLOCK_DATA_SIZE;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORMS = null;
        /*double*/ get UNIFORM_BLOCK_ACTIVE_UNIFORMS()
        {
            return _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORMS;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = null;
        /*double*/ get UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES()
        {
            return _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = null;
        /*double*/ get UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER()
        {
            return _backingField_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = null;
        /*double*/ get UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER()
        {
            return _backingField_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER;
        }
        /*double*/ _backingField_INVALID_INDEX = null;
        /*double*/ get INVALID_INDEX()
        {
            return _backingField_INVALID_INDEX;
        }
        /*double*/ _backingField_MAX_VERTEX_OUTPUT_COMPONENTS = null;
        /*double*/ get MAX_VERTEX_OUTPUT_COMPONENTS()
        {
            return _backingField_MAX_VERTEX_OUTPUT_COMPONENTS;
        }
        /*double*/ _backingField_MAX_FRAGMENT_INPUT_COMPONENTS = null;
        /*double*/ get MAX_FRAGMENT_INPUT_COMPONENTS()
        {
            return _backingField_MAX_FRAGMENT_INPUT_COMPONENTS;
        }
        /*double*/ _backingField_MAX_SERVER_WAIT_TIMEOUT = null;
        /*double*/ get MAX_SERVER_WAIT_TIMEOUT()
        {
            return _backingField_MAX_SERVER_WAIT_TIMEOUT;
        }
        /*double*/ _backingField_OBJECT_TYPE = null;
        /*double*/ get OBJECT_TYPE()
        {
            return _backingField_OBJECT_TYPE;
        }
        /*double*/ _backingField_SYNC_CONDITION = null;
        /*double*/ get SYNC_CONDITION()
        {
            return _backingField_SYNC_CONDITION;
        }
        /*double*/ _backingField_SYNC_STATUS = null;
        /*double*/ get SYNC_STATUS()
        {
            return _backingField_SYNC_STATUS;
        }
        /*double*/ _backingField_SYNC_FLAGS = null;
        /*double*/ get SYNC_FLAGS()
        {
            return _backingField_SYNC_FLAGS;
        }
        /*double*/ _backingField_SYNC_FENCE = null;
        /*double*/ get SYNC_FENCE()
        {
            return _backingField_SYNC_FENCE;
        }
        /*double*/ _backingField_SYNC_GPU_COMMANDS_COMPLETE = null;
        /*double*/ get SYNC_GPU_COMMANDS_COMPLETE()
        {
            return _backingField_SYNC_GPU_COMMANDS_COMPLETE;
        }
        /*double*/ _backingField_UNSIGNALED = null;
        /*double*/ get UNSIGNALED()
        {
            return _backingField_UNSIGNALED;
        }
        /*double*/ _backingField_SIGNALED = null;
        /*double*/ get SIGNALED()
        {
            return _backingField_SIGNALED;
        }
        /*double*/ _backingField_ALREADY_SIGNALED = null;
        /*double*/ get ALREADY_SIGNALED()
        {
            return _backingField_ALREADY_SIGNALED;
        }
        /*double*/ _backingField_TIMEOUT_EXPIRED = null;
        /*double*/ get TIMEOUT_EXPIRED()
        {
            return _backingField_TIMEOUT_EXPIRED;
        }
        /*double*/ _backingField_CONDITION_SATISFIED = null;
        /*double*/ get CONDITION_SATISFIED()
        {
            return _backingField_CONDITION_SATISFIED;
        }
        /*double*/ _backingField_WAIT_FAILED = null;
        /*double*/ get WAIT_FAILED()
        {
            return _backingField_WAIT_FAILED;
        }
        /*double*/ _backingField_SYNC_FLUSH_COMMANDS_BIT = null;
        /*double*/ get SYNC_FLUSH_COMMANDS_BIT()
        {
            return _backingField_SYNC_FLUSH_COMMANDS_BIT;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_DIVISOR = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_DIVISOR()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_DIVISOR;
        }
        /*double*/ _backingField_ANY_SAMPLES_PASSED = null;
        /*double*/ get ANY_SAMPLES_PASSED()
        {
            return _backingField_ANY_SAMPLES_PASSED;
        }
        /*double*/ _backingField_ANY_SAMPLES_PASSED_CONSERVATIVE = null;
        /*double*/ get ANY_SAMPLES_PASSED_CONSERVATIVE()
        {
            return _backingField_ANY_SAMPLES_PASSED_CONSERVATIVE;
        }
        /*double*/ _backingField_SAMPLER_BINDING = null;
        /*double*/ get SAMPLER_BINDING()
        {
            return _backingField_SAMPLER_BINDING;
        }
        /*double*/ _backingField_RGB10_A2UI = null;
        /*double*/ get RGB10_A2UI()
        {
            return _backingField_RGB10_A2UI;
        }
        /*double*/ _backingField_INT_2_10_10_10_REV = null;
        /*double*/ get INT_2_10_10_10_REV()
        {
            return _backingField_INT_2_10_10_10_REV;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK = null;
        /*double*/ get TRANSFORM_FEEDBACK()
        {
            return _backingField_TRANSFORM_FEEDBACK;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_PAUSED = null;
        /*double*/ get TRANSFORM_FEEDBACK_PAUSED()
        {
            return _backingField_TRANSFORM_FEEDBACK_PAUSED;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_ACTIVE = null;
        /*double*/ get TRANSFORM_FEEDBACK_ACTIVE()
        {
            return _backingField_TRANSFORM_FEEDBACK_ACTIVE;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BINDING = null;
        /*double*/ get TRANSFORM_FEEDBACK_BINDING()
        {
            return _backingField_TRANSFORM_FEEDBACK_BINDING;
        }
        /*double*/ _backingField_TEXTURE_IMMUTABLE_FORMAT = null;
        /*double*/ get TEXTURE_IMMUTABLE_FORMAT()
        {
            return _backingField_TEXTURE_IMMUTABLE_FORMAT;
        }
        /*double*/ _backingField_MAX_ELEMENT_INDEX = null;
        /*double*/ get MAX_ELEMENT_INDEX()
        {
            return _backingField_MAX_ELEMENT_INDEX;
        }
        /*double*/ _backingField_TEXTURE_IMMUTABLE_LEVELS = null;
        /*double*/ get TEXTURE_IMMUTABLE_LEVELS()
        {
            return _backingField_TEXTURE_IMMUTABLE_LEVELS;
        }
        /*double*/ _backingField_TIMEOUT_IGNORED = null;
        /*double*/ get TIMEOUT_IGNORED()
        {
            return _backingField_TIMEOUT_IGNORED;
        }
        /*double*/ _backingField_MAX_CLIENT_WAIT_TIMEOUT_WEBGL = null;
        /*double*/ get MAX_CLIENT_WAIT_TIMEOUT_WEBGL()
        {
            return _backingField_MAX_CLIENT_WAIT_TIMEOUT_WEBGL;
        }
        /*void*/ bufferData(/*double*/ target, /*Union<es5.ArrayBuffer, es5.ArrayBufferView, Null>*/ srcData, /*double*/ usage)
        /*void*/ bufferData(/*double*/ target, /*es5.ArrayBufferView*/ srcData, /*double*/ usage)
        /*void*/ bufferSubData(/*double*/ target, /*double*/ dstByteOffset, /*Union<es5.ArrayBuffer, es5.ArrayBufferView, Null>*/ srcData)
        /*void*/ bufferSubData(/*double*/ target, /*double*/ dstByteOffset, /*es5.ArrayBufferView*/ srcData)
        /*void*/ bufferData(/*double*/ target, /*es5.ArrayBufferView*/ srcData, /*double*/ usage, /*double*/ srcOffset)
        /*void*/ bufferData(/*double*/ target, /*es5.ArrayBufferView*/ srcData, /*double*/ usage, /*double*/ srcOffset, /*double*/ length)
        /*void*/ bufferSubData(/*double*/ target, /*double*/ dstByteOffset, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset)
        /*void*/ bufferSubData(/*double*/ target, /*double*/ dstByteOffset, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset, /*double*/ length)
        /*void*/ copyBufferSubData(/*double*/ readTarget, /*double*/ writeTarget, /*double*/ readOffset, /*double*/ writeOffset, /*double*/ size)
        /*void*/ getBufferSubData(/*double*/ target, /*double*/ srcByteOffset, /*es5.ArrayBufferView*/ dstBuffer)
        /*void*/ getBufferSubData(/*double*/ target, /*double*/ srcByteOffset, /*es5.ArrayBufferView*/ dstBuffer, /*double*/ dstOffset)
        /*void*/ getBufferSubData(/*double*/ target, /*double*/ srcByteOffset, /*es5.ArrayBufferView*/ dstBuffer, /*double*/ dstOffset, /*double*/ length)
        /*void*/ blitFramebuffer(/*double*/ srcX0, /*double*/ srcY0, /*double*/ srcX1, /*double*/ srcY1, /*double*/ dstX0, /*double*/ dstY0, /*double*/ dstX1, /*double*/ dstY1, /*double*/ mask, /*double*/ filter)
        /*void*/ framebufferTextureLayer(/*double*/ target, /*double*/ attachment, /*dom.WebGLTexture*/ texture, /*double*/ level, /*double*/ layer)
        /*void*/ invalidateFramebuffer(/*double*/ target, /*double[]*/ attachments)
        /*void*/ invalidateSubFramebuffer(/*double*/ target, /*double[]*/ attachments, /*double*/ x, /*double*/ y, /*double*/ width, /*double*/ height)
        /*void*/ readBuffer(/*double*/ src)
        /*object*/ getInternalformatParameter(/*double*/ target, /*double*/ internalformat, /*double*/ pname)
        /*void*/ renderbufferStorageMultisample(/*double*/ target, /*double*/ samples, /*double*/ internalformat, /*double*/ width, /*double*/ height)
        /*void*/ texStorage2D(/*double*/ target, /*double*/ levels, /*double*/ internalformat, /*double*/ width, /*double*/ height)
        /*void*/ texStorage3D(/*double*/ target, /*double*/ levels, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ format, /*double*/ type)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ format, /*double*/ type, /*Union<dom.ImageData, dom.HTMLImageElement, webgl2.HTMLCanvasElement, dom.HTMLVideoElement>*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ format, /*double*/ type, /*webgl2.HTMLCanvasElement*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ format, /*double*/ type, /*Union<webgl2.ImageBitmap, dom.ImageData, dom.HTMLImageElement, webgl2.HTMLCanvasElement, dom.HTMLVideoElement>*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ format, /*double*/ type, /*webgl2.ImageBitmap*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ format, /*double*/ type, /*Union<dom.ImageData, dom.HTMLImageElement, webgl2.HTMLCanvasElement, dom.HTMLVideoElement>*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ format, /*double*/ type, /*webgl2.HTMLCanvasElement*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ format, /*double*/ type, /*Union<webgl2.ImageBitmap, dom.ImageData, dom.HTMLImageElement, webgl2.HTMLCanvasElement, dom.HTMLVideoElement>*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ format, /*double*/ type, /*webgl2.ImageBitmap*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ format, /*double*/ type, /*double*/ pboOffset)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ format, /*double*/ type, /*Union<webgl2.ImageBitmap, dom.ImageData, dom.HTMLImageElement, webgl2.HTMLCanvasElement, dom.HTMLVideoElement>*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ format, /*double*/ type, /*webgl2.ImageBitmap*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ format, /*double*/ type, /*dom.ImageData*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ format, /*double*/ type, /*dom.HTMLImageElement*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ format, /*double*/ type, /*webgl2.HTMLCanvasElement*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ format, /*double*/ type, /*dom.HTMLVideoElement*/ source)
        /*void*/ texImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ format, /*double*/ type, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset)
        /*void*/ texImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ format, /*double*/ type, /*double*/ pboOffset)
        /*void*/ texImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ format, /*double*/ type, /*Union<webgl2.ImageBitmap, dom.ImageData, dom.HTMLImageElement, webgl2.HTMLCanvasElement, dom.HTMLVideoElement>*/ source)
        /*void*/ texImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ format, /*double*/ type, /*webgl2.ImageBitmap*/ source)
        /*void*/ texImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ format, /*double*/ type, /*dom.ImageData*/ source)
        /*void*/ texImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ format, /*double*/ type, /*dom.HTMLImageElement*/ source)
        /*void*/ texImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ format, /*double*/ type, /*webgl2.HTMLCanvasElement*/ source)
        /*void*/ texImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ format, /*double*/ type, /*dom.HTMLVideoElement*/ source)
        /*void*/ texImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ format, /*double*/ type, /*es5.ArrayBufferView*/ srcData)
        /*void*/ texImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ format, /*double*/ type, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*double*/ pboOffset)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*Union<webgl2.ImageBitmap, dom.ImageData, dom.HTMLImageElement, webgl2.HTMLCanvasElement, dom.HTMLVideoElement>*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*webgl2.ImageBitmap*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*dom.ImageData*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*dom.HTMLImageElement*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*webgl2.HTMLCanvasElement*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*dom.HTMLVideoElement*/ source)
        /*void*/ texSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset)
        /*void*/ texSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ type, /*double*/ pboOffset)
        /*void*/ texSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ type, /*Union<webgl2.ImageBitmap, dom.ImageData, dom.HTMLImageElement, webgl2.HTMLCanvasElement, dom.HTMLVideoElement>*/ source)
        /*void*/ texSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ type, /*webgl2.ImageBitmap*/ source)
        /*void*/ texSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ type, /*dom.ImageData*/ source)
        /*void*/ texSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ type, /*dom.HTMLImageElement*/ source)
        /*void*/ texSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ type, /*webgl2.HTMLCanvasElement*/ source)
        /*void*/ texSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ type, /*dom.HTMLVideoElement*/ source)
        /*void*/ texSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ type, /*es5.ArrayBufferView*/ srcData)
        /*void*/ texSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ type, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset)
        /*void*/ copyTexSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ x, /*double*/ y, /*double*/ width, /*double*/ height)
        /*void*/ compressedTexImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*double*/ imageSize, /*double*/ offset)
        /*void*/ compressedTexImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*es5.ArrayBufferView*/ srcData)
        /*void*/ compressedTexImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset)
        /*void*/ compressedTexImage2D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ border, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset, /*double*/ srcLengthOverride)
        /*void*/ compressedTexImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*double*/ imageSize, /*double*/ offset)
        /*void*/ compressedTexImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*es5.ArrayBufferView*/ srcData)
        /*void*/ compressedTexImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset)
        /*void*/ compressedTexImage3D(/*double*/ target, /*double*/ level, /*double*/ internalformat, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ border, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset, /*double*/ srcLengthOverride)
        /*void*/ compressedTexSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ imageSize, /*double*/ offset)
        /*void*/ compressedTexSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*es5.ArrayBufferView*/ srcData)
        /*void*/ compressedTexSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset)
        /*void*/ compressedTexSubImage2D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ width, /*double*/ height, /*double*/ format, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset, /*double*/ srcLengthOverride)
        /*void*/ compressedTexSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*double*/ imageSize, /*double*/ offset)
        /*void*/ compressedTexSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*es5.ArrayBufferView*/ srcData)
        /*void*/ compressedTexSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset)
        /*void*/ compressedTexSubImage3D(/*double*/ target, /*double*/ level, /*double*/ xoffset, /*double*/ yoffset, /*double*/ zoffset, /*double*/ width, /*double*/ height, /*double*/ depth, /*double*/ format, /*es5.ArrayBufferView*/ srcData, /*double*/ srcOffset, /*double*/ srcLengthOverride)
        /*double*/ getFragDataLocation(/*dom.WebGLProgram*/ program, /*string*/ name)
        /*void*/ uniform1ui(/*dom.WebGLUniformLocation*/ location, /*double*/ v0)
        /*void*/ uniform2ui(/*dom.WebGLUniformLocation*/ location, /*double*/ v0, /*double*/ v1)
        /*void*/ uniform3ui(/*dom.WebGLUniformLocation*/ location, /*double*/ v0, /*double*/ v1, /*double*/ v2)
        /*void*/ uniform4ui(/*dom.WebGLUniformLocation*/ location, /*double*/ v0, /*double*/ v1, /*double*/ v2, /*double*/ v3)
        /*void*/ uniform1fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniform1fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform1fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform1fv(/*dom.WebGLUniformLocation*/ location, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform1fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform1fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform1fv(/*dom.WebGLUniformLocation*/ location, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform1fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform2fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniform2fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform2fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform2fv(/*dom.WebGLUniformLocation*/ location, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform2fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform2fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform2fv(/*dom.WebGLUniformLocation*/ location, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform2fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform3fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniform3fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform3fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform3fv(/*dom.WebGLUniformLocation*/ location, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform3fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform3fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform3fv(/*dom.WebGLUniformLocation*/ location, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform3fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform4fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniform4fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform4fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform4fv(/*dom.WebGLUniformLocation*/ location, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform4fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform4fv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform4fv(/*dom.WebGLUniformLocation*/ location, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform4fv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform1iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data)
        /*void*/ uniform1iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform1iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform1iv(/*dom.WebGLUniformLocation*/ location, /*es5.Int32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform1iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform1iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform1iv(/*dom.WebGLUniformLocation*/ location, /*es5.Int32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform1iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform2iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data)
        /*void*/ uniform2iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform2iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform2iv(/*dom.WebGLUniformLocation*/ location, /*es5.Int32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform2iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform2iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform2iv(/*dom.WebGLUniformLocation*/ location, /*es5.Int32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform2iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform3iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data)
        /*void*/ uniform3iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform3iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform3iv(/*dom.WebGLUniformLocation*/ location, /*es5.Int32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform3iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform3iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform3iv(/*dom.WebGLUniformLocation*/ location, /*es5.Int32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform3iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform4iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data)
        /*void*/ uniform4iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform4iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform4iv(/*dom.WebGLUniformLocation*/ location, /*es5.Int32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform4iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform4iv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Int32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform4iv(/*dom.WebGLUniformLocation*/ location, /*es5.Int32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform4iv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform1uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data)
        /*void*/ uniform1uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data)
        /*void*/ uniform1uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform1uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform1uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform1uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform1uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform1uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform1uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform2uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data)
        /*void*/ uniform2uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data)
        /*void*/ uniform2uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform2uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform2uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform2uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform2uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform2uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform2uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform3uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data)
        /*void*/ uniform3uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data)
        /*void*/ uniform3uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform3uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform3uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform3uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform3uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform3uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform3uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform4uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data)
        /*void*/ uniform4uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data)
        /*void*/ uniform4uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data)
        /*void*/ uniform4uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniform4uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniform4uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniform4uiv(/*dom.WebGLUniformLocation*/ location, /*Union<es5.Uint32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform4uiv(/*dom.WebGLUniformLocation*/ location, /*es5.Uint32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniform4uiv(/*dom.WebGLUniformLocation*/ location, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniformMatrix2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data)
        /*void*/ uniformMatrix2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix3x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniformMatrix3x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data)
        /*void*/ uniformMatrix3x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data)
        /*void*/ uniformMatrix3x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix3x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix3x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix3x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix3x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix3x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix4x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniformMatrix4x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data)
        /*void*/ uniformMatrix4x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data)
        /*void*/ uniformMatrix4x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix4x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix4x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix4x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix4x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix4x2fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix2x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniformMatrix2x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data)
        /*void*/ uniformMatrix2x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data)
        /*void*/ uniformMatrix2x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix2x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix2x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix2x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix2x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix2x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniformMatrix3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data)
        /*void*/ uniformMatrix3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix4x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniformMatrix4x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data)
        /*void*/ uniformMatrix4x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data)
        /*void*/ uniformMatrix4x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix4x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix4x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix4x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix4x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix4x3fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix2x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniformMatrix2x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data)
        /*void*/ uniformMatrix2x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data)
        /*void*/ uniformMatrix2x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix2x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix2x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix2x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix2x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix2x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix3x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniformMatrix3x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data)
        /*void*/ uniformMatrix3x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data)
        /*void*/ uniformMatrix3x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix3x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix3x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix3x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix3x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix3x4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data)
        /*void*/ uniformMatrix4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data)
        /*void*/ uniformMatrix4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset)
        /*void*/ uniformMatrix4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*Union<es5.Float32Array, double[]>*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*es5.Float32Array*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ uniformMatrix4fv(/*dom.WebGLUniformLocation*/ location, /*bool*/ transpose, /*double[]*/ data, /*double*/ srcOffset, /*double*/ srcLength)
        /*void*/ vertexAttribI4i(/*double*/ index, /*double*/ x, /*double*/ y, /*double*/ z, /*double*/ w)
        /*void*/ vertexAttribI4iv(/*double*/ index, /*Union<es5.Int32Array, double[]>*/ values)
        /*void*/ vertexAttribI4iv(/*double*/ index, /*es5.Int32Array*/ values)
        /*void*/ vertexAttribI4iv(/*double*/ index, /*double[]*/ values)
        /*void*/ vertexAttribI4ui(/*double*/ index, /*double*/ x, /*double*/ y, /*double*/ z, /*double*/ w)
        /*void*/ vertexAttribI4uiv(/*double*/ index, /*Union<es5.Uint32Array, double[]>*/ values)
        /*void*/ vertexAttribI4uiv(/*double*/ index, /*es5.Uint32Array*/ values)
        /*void*/ vertexAttribI4uiv(/*double*/ index, /*double[]*/ values)
        /*void*/ vertexAttribIPointer(/*double*/ index, /*double*/ size, /*double*/ type, /*double*/ stride, /*double*/ offset)
        /*void*/ vertexAttribDivisor(/*double*/ index, /*double*/ divisor)
        /*void*/ drawArraysInstanced(/*double*/ mode, /*double*/ first, /*double*/ count, /*double*/ instanceCount)
        /*void*/ drawElementsInstanced(/*double*/ mode, /*double*/ count, /*double*/ type, /*double*/ offset, /*double*/ instanceCount)
        /*void*/ drawRangeElements(/*double*/ mode, /*double*/ start, /*double*/ end, /*double*/ count, /*double*/ type, /*double*/ offset)
        /*void*/ readPixels(/*double*/ x, /*double*/ y, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*es5.ArrayBufferView*/ dstData)
        /*void*/ readPixels(/*double*/ x, /*double*/ y, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*double*/ offset)
        /*void*/ readPixels(/*double*/ x, /*double*/ y, /*double*/ width, /*double*/ height, /*double*/ format, /*double*/ type, /*es5.ArrayBufferView*/ dstData, /*double*/ dstOffset)
        /*void*/ drawBuffers(/*double[]*/ buffers)
        /*void*/ clearBufferfv(/*double*/ buffer, /*double*/ drawbuffer, /*Union<es5.Float32Array, double[]>*/ values)
        /*void*/ clearBufferfv(/*double*/ buffer, /*double*/ drawbuffer, /*es5.Float32Array*/ values)
        /*void*/ clearBufferfv(/*double*/ buffer, /*double*/ drawbuffer, /*double[]*/ values)
        /*void*/ clearBufferfv(/*double*/ buffer, /*double*/ drawbuffer, /*Union<es5.Float32Array, double[]>*/ values, /*double*/ srcOffset)
        /*void*/ clearBufferfv(/*double*/ buffer, /*double*/ drawbuffer, /*es5.Float32Array*/ values, /*double*/ srcOffset)
        /*void*/ clearBufferfv(/*double*/ buffer, /*double*/ drawbuffer, /*double[]*/ values, /*double*/ srcOffset)
        /*void*/ clearBufferiv(/*double*/ buffer, /*double*/ drawbuffer, /*Union<es5.Int32Array, double[]>*/ values)
        /*void*/ clearBufferiv(/*double*/ buffer, /*double*/ drawbuffer, /*es5.Int32Array*/ values)
        /*void*/ clearBufferiv(/*double*/ buffer, /*double*/ drawbuffer, /*double[]*/ values)
        /*void*/ clearBufferiv(/*double*/ buffer, /*double*/ drawbuffer, /*Union<es5.Int32Array, double[]>*/ values, /*double*/ srcOffset)
        /*void*/ clearBufferiv(/*double*/ buffer, /*double*/ drawbuffer, /*es5.Int32Array*/ values, /*double*/ srcOffset)
        /*void*/ clearBufferiv(/*double*/ buffer, /*double*/ drawbuffer, /*double[]*/ values, /*double*/ srcOffset)
        /*void*/ clearBufferuiv(/*double*/ buffer, /*double*/ drawbuffer, /*Union<es5.Uint32Array, double[]>*/ values)
        /*void*/ clearBufferuiv(/*double*/ buffer, /*double*/ drawbuffer, /*es5.Uint32Array*/ values)
        /*void*/ clearBufferuiv(/*double*/ buffer, /*double*/ drawbuffer, /*double[]*/ values)
        /*void*/ clearBufferuiv(/*double*/ buffer, /*double*/ drawbuffer, /*Union<es5.Uint32Array, double[]>*/ values, /*double*/ srcOffset)
        /*void*/ clearBufferuiv(/*double*/ buffer, /*double*/ drawbuffer, /*es5.Uint32Array*/ values, /*double*/ srcOffset)
        /*void*/ clearBufferuiv(/*double*/ buffer, /*double*/ drawbuffer, /*double[]*/ values, /*double*/ srcOffset)
        /*void*/ clearBufferfi(/*double*/ buffer, /*double*/ drawbuffer, /*double*/ depth, /*double*/ stencil)
        /*webgl2.WebGLQuery*/ createQuery()
        /*void*/ deleteQuery(/*webgl2.WebGLQuery*/ query)
        /*bool*/ isQuery(/*webgl2.WebGLQuery*/ query)
        /*void*/ beginQuery(/*double*/ target, /*webgl2.WebGLQuery*/ query)
        /*void*/ endQuery(/*double*/ target)
        /*webgl2.WebGLQuery*/ getQuery(/*double*/ target, /*double*/ pname)
        /*object*/ getQueryParameter(/*webgl2.WebGLQuery*/ query, /*double*/ pname)
        /*webgl2.WebGLSampler*/ createSampler()
        /*void*/ deleteSampler(/*webgl2.WebGLSampler*/ sampler)
        /*bool*/ isSampler(/*webgl2.WebGLSampler*/ sampler)
        /*void*/ bindSampler(/*double*/ unit, /*webgl2.WebGLSampler*/ sampler)
        /*void*/ samplerParameteri(/*webgl2.WebGLSampler*/ sampler, /*double*/ pname, /*double*/ param)
        /*void*/ samplerParameterf(/*webgl2.WebGLSampler*/ sampler, /*double*/ pname, /*double*/ param)
        /*object*/ getSamplerParameter(/*webgl2.WebGLSampler*/ sampler, /*double*/ pname)
        /*webgl2.WebGLSync*/ fenceSync(/*double*/ condition, /*double*/ flags)
        /*bool*/ isSync(/*webgl2.WebGLSync*/ sync)
        /*void*/ deleteSync(/*webgl2.WebGLSync*/ sync)
        /*double*/ clientWaitSync(/*webgl2.WebGLSync*/ sync, /*double*/ flags, /*double*/ timeout)
        /*void*/ waitSync(/*webgl2.WebGLSync*/ sync, /*double*/ flags, /*double*/ timeout)
        /*object*/ getSyncParameter(/*webgl2.WebGLSync*/ sync, /*double*/ pname)
        /*webgl2.WebGLTransformFeedback*/ createTransformFeedback()
        /*void*/ deleteTransformFeedback(/*webgl2.WebGLTransformFeedback*/ tf)
        /*bool*/ isTransformFeedback(/*webgl2.WebGLTransformFeedback*/ tf)
        /*void*/ bindTransformFeedback(/*double*/ target, /*webgl2.WebGLTransformFeedback*/ tf)
        /*void*/ beginTransformFeedback(/*double*/ primitiveMode)
        /*void*/ endTransformFeedback()
        /*void*/ transformFeedbackVaryings(/*dom.WebGLProgram*/ program, /*string[]*/ varyings, /*double*/ bufferMode)
        /*dom.WebGLActiveInfo*/ getTransformFeedbackVarying(/*dom.WebGLProgram*/ program, /*double*/ index)
        /*void*/ pauseTransformFeedback()
        /*void*/ resumeTransformFeedback()
        /*void*/ bindBufferBase(/*double*/ target, /*double*/ index, /*dom.WebGLBuffer*/ buffer)
        /*void*/ bindBufferRange(/*double*/ target, /*double*/ index, /*dom.WebGLBuffer*/ buffer, /*double*/ offset, /*double*/ size)
        /*object*/ getIndexedParameter(/*double*/ target, /*double*/ index)
        /*double[]*/ getUniformIndices(/*dom.WebGLProgram*/ program, /*string[]*/ uniformNames)
        /*object*/ getActiveUniforms(/*dom.WebGLProgram*/ program, /*double[]*/ uniformIndices, /*double*/ pname)
        /*double*/ getUniformBlockIndex(/*dom.WebGLProgram*/ program, /*string*/ uniformBlockName)
        /*object*/ getActiveUniformBlockParameter(/*dom.WebGLProgram*/ program, /*double*/ uniformBlockIndex, /*double*/ pname)
        /*string*/ getActiveUniformBlockName(/*dom.WebGLProgram*/ program, /*double*/ uniformBlockIndex)
        /*void*/ uniformBlockBinding(/*dom.WebGLProgram*/ program, /*double*/ uniformBlockIndex, /*double*/ uniformBlockBinding)
        /*webgl2.WebGLVertexArrayObject*/ createVertexArray()
        /*void*/ deleteVertexArray(/*webgl2.WebGLVertexArrayObject*/ vertexArray)
        /*bool*/ isVertexArray(/*webgl2.WebGLVertexArrayObject*/ vertexArray)
        /*void*/ bindVertexArray(/*webgl2.WebGLVertexArrayObject*/ array)
    }
    class H5_Core_WebGLQuery extends H5_Core_dom_WebGLObject
    {
        constructor()
        {
            super();
        }
        /*webgl2.WebGLQuery*/ _backingField_prototype = null;
        /*webgl2.WebGLQuery*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLQuery*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
    }
    class H5_Core_WebGLSampler extends H5_Core_dom_WebGLObject
    {
        constructor()
        {
            super();
        }
        /*webgl2.WebGLSampler*/ _backingField_prototype = null;
        /*webgl2.WebGLSampler*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLSampler*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
    }
    class H5_Core_WebGLSync extends H5_Core_dom_WebGLObject
    {
        constructor()
        {
            super();
        }
        /*webgl2.WebGLSync*/ _backingField_prototype = null;
        /*webgl2.WebGLSync*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLSync*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
    }
    class H5_Core_WebGLTransformFeedback extends H5_Core_dom_WebGLObject
    {
        constructor()
        {
            super();
        }
        /*webgl2.WebGLTransformFeedback*/ _backingField_prototype = null;
        /*webgl2.WebGLTransformFeedback*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLTransformFeedback*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
    }
    class H5_Core_WebGLVertexArrayObject extends H5_Core_dom_WebGLObject
    {
        constructor()
        {
            super();
        }
        /*webgl2.WebGLVertexArrayObject*/ _backingField_prototype = null;
        /*webgl2.WebGLVertexArrayObject*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLVertexArrayObject*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
    }
    class H5_Core_WebGL2RenderingContextTypeConfig extends H5_Core_IObject(object)
    {
        /*webgl2.WebGL2RenderingContext*/ _backingField_prototype = null;
        /*webgl2.WebGL2RenderingContext*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGL2RenderingContext*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
        /*double*/ _backingField_ACTIVE_ATTRIBUTES = null;
        /*double*/ get ACTIVE_ATTRIBUTES()
        {
            return _backingField_ACTIVE_ATTRIBUTES;
        }
        /*double*/ _backingField_ACTIVE_TEXTURE = null;
        /*double*/ get ACTIVE_TEXTURE()
        {
            return _backingField_ACTIVE_TEXTURE;
        }
        /*double*/ _backingField_ACTIVE_UNIFORMS = null;
        /*double*/ get ACTIVE_UNIFORMS()
        {
            return _backingField_ACTIVE_UNIFORMS;
        }
        /*double*/ _backingField_ALIASED_LINE_WIDTH_RANGE = null;
        /*double*/ get ALIASED_LINE_WIDTH_RANGE()
        {
            return _backingField_ALIASED_LINE_WIDTH_RANGE;
        }
        /*double*/ _backingField_ALIASED_POINT_SIZE_RANGE = null;
        /*double*/ get ALIASED_POINT_SIZE_RANGE()
        {
            return _backingField_ALIASED_POINT_SIZE_RANGE;
        }
        /*double*/ _backingField_ALPHA = null;
        /*double*/ get ALPHA()
        {
            return _backingField_ALPHA;
        }
        /*double*/ _backingField_ALPHA_BITS = null;
        /*double*/ get ALPHA_BITS()
        {
            return _backingField_ALPHA_BITS;
        }
        /*double*/ _backingField_ALWAYS = null;
        /*double*/ get ALWAYS()
        {
            return _backingField_ALWAYS;
        }
        /*double*/ _backingField_ARRAY_BUFFER = null;
        /*double*/ get ARRAY_BUFFER()
        {
            return _backingField_ARRAY_BUFFER;
        }
        /*double*/ _backingField_ARRAY_BUFFER_BINDING = null;
        /*double*/ get ARRAY_BUFFER_BINDING()
        {
            return _backingField_ARRAY_BUFFER_BINDING;
        }
        /*double*/ _backingField_ATTACHED_SHADERS = null;
        /*double*/ get ATTACHED_SHADERS()
        {
            return _backingField_ATTACHED_SHADERS;
        }
        /*double*/ _backingField_BACK = null;
        /*double*/ get BACK()
        {
            return _backingField_BACK;
        }
        /*double*/ _backingField_BLEND = null;
        /*double*/ get BLEND()
        {
            return _backingField_BLEND;
        }
        /*double*/ _backingField_BLEND_COLOR = null;
        /*double*/ get BLEND_COLOR()
        {
            return _backingField_BLEND_COLOR;
        }
        /*double*/ _backingField_BLEND_DST_ALPHA = null;
        /*double*/ get BLEND_DST_ALPHA()
        {
            return _backingField_BLEND_DST_ALPHA;
        }
        /*double*/ _backingField_BLEND_DST_RGB = null;
        /*double*/ get BLEND_DST_RGB()
        {
            return _backingField_BLEND_DST_RGB;
        }
        /*double*/ _backingField_BLEND_EQUATION = null;
        /*double*/ get BLEND_EQUATION()
        {
            return _backingField_BLEND_EQUATION;
        }
        /*double*/ _backingField_BLEND_EQUATION_ALPHA = null;
        /*double*/ get BLEND_EQUATION_ALPHA()
        {
            return _backingField_BLEND_EQUATION_ALPHA;
        }
        /*double*/ _backingField_BLEND_EQUATION_RGB = null;
        /*double*/ get BLEND_EQUATION_RGB()
        {
            return _backingField_BLEND_EQUATION_RGB;
        }
        /*double*/ _backingField_BLEND_SRC_ALPHA = null;
        /*double*/ get BLEND_SRC_ALPHA()
        {
            return _backingField_BLEND_SRC_ALPHA;
        }
        /*double*/ _backingField_BLEND_SRC_RGB = null;
        /*double*/ get BLEND_SRC_RGB()
        {
            return _backingField_BLEND_SRC_RGB;
        }
        /*double*/ _backingField_BLUE_BITS = null;
        /*double*/ get BLUE_BITS()
        {
            return _backingField_BLUE_BITS;
        }
        /*double*/ _backingField_BOOL = null;
        /*double*/ get BOOL()
        {
            return _backingField_BOOL;
        }
        /*double*/ _backingField_BOOL_VEC2 = null;
        /*double*/ get BOOL_VEC2()
        {
            return _backingField_BOOL_VEC2;
        }
        /*double*/ _backingField_BOOL_VEC3 = null;
        /*double*/ get BOOL_VEC3()
        {
            return _backingField_BOOL_VEC3;
        }
        /*double*/ _backingField_BOOL_VEC4 = null;
        /*double*/ get BOOL_VEC4()
        {
            return _backingField_BOOL_VEC4;
        }
        /*double*/ _backingField_BROWSER_DEFAULT_WEBGL = null;
        /*double*/ get BROWSER_DEFAULT_WEBGL()
        {
            return _backingField_BROWSER_DEFAULT_WEBGL;
        }
        /*double*/ _backingField_BUFFER_SIZE = null;
        /*double*/ get BUFFER_SIZE()
        {
            return _backingField_BUFFER_SIZE;
        }
        /*double*/ _backingField_BUFFER_USAGE = null;
        /*double*/ get BUFFER_USAGE()
        {
            return _backingField_BUFFER_USAGE;
        }
        /*double*/ _backingField_BYTE = null;
        /*double*/ get BYTE()
        {
            return _backingField_BYTE;
        }
        /*double*/ _backingField_CCW = null;
        /*double*/ get CCW()
        {
            return _backingField_CCW;
        }
        /*double*/ _backingField_CLAMP_TO_EDGE = null;
        /*double*/ get CLAMP_TO_EDGE()
        {
            return _backingField_CLAMP_TO_EDGE;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT0 = null;
        /*double*/ get COLOR_ATTACHMENT0()
        {
            return _backingField_COLOR_ATTACHMENT0;
        }
        /*double*/ _backingField_COLOR_BUFFER_BIT = null;
        /*double*/ get COLOR_BUFFER_BIT()
        {
            return _backingField_COLOR_BUFFER_BIT;
        }
        /*double*/ _backingField_COLOR_CLEAR_VALUE = null;
        /*double*/ get COLOR_CLEAR_VALUE()
        {
            return _backingField_COLOR_CLEAR_VALUE;
        }
        /*double*/ _backingField_COLOR_WRITEMASK = null;
        /*double*/ get COLOR_WRITEMASK()
        {
            return _backingField_COLOR_WRITEMASK;
        }
        /*double*/ _backingField_COMPILE_STATUS = null;
        /*double*/ get COMPILE_STATUS()
        {
            return _backingField_COMPILE_STATUS;
        }
        /*double*/ _backingField_COMPRESSED_TEXTURE_FORMATS = null;
        /*double*/ get COMPRESSED_TEXTURE_FORMATS()
        {
            return _backingField_COMPRESSED_TEXTURE_FORMATS;
        }
        /*double*/ _backingField_CONSTANT_ALPHA = null;
        /*double*/ get CONSTANT_ALPHA()
        {
            return _backingField_CONSTANT_ALPHA;
        }
        /*double*/ _backingField_CONSTANT_COLOR = null;
        /*double*/ get CONSTANT_COLOR()
        {
            return _backingField_CONSTANT_COLOR;
        }
        /*double*/ _backingField_CONTEXT_LOST_WEBGL = null;
        /*double*/ get CONTEXT_LOST_WEBGL()
        {
            return _backingField_CONTEXT_LOST_WEBGL;
        }
        /*double*/ _backingField_CULL_FACE = null;
        /*double*/ get CULL_FACE()
        {
            return _backingField_CULL_FACE;
        }
        /*double*/ _backingField_CULL_FACE_MODE = null;
        /*double*/ get CULL_FACE_MODE()
        {
            return _backingField_CULL_FACE_MODE;
        }
        /*double*/ _backingField_CURRENT_PROGRAM = null;
        /*double*/ get CURRENT_PROGRAM()
        {
            return _backingField_CURRENT_PROGRAM;
        }
        /*double*/ _backingField_CURRENT_VERTEX_ATTRIB = null;
        /*double*/ get CURRENT_VERTEX_ATTRIB()
        {
            return _backingField_CURRENT_VERTEX_ATTRIB;
        }
        /*double*/ _backingField_CW = null;
        /*double*/ get CW()
        {
            return _backingField_CW;
        }
        /*double*/ _backingField_DECR = null;
        /*double*/ get DECR()
        {
            return _backingField_DECR;
        }
        /*double*/ _backingField_DECR_WRAP = null;
        /*double*/ get DECR_WRAP()
        {
            return _backingField_DECR_WRAP;
        }
        /*double*/ _backingField_DELETE_STATUS = null;
        /*double*/ get DELETE_STATUS()
        {
            return _backingField_DELETE_STATUS;
        }
        /*double*/ _backingField_DEPTH_ATTACHMENT = null;
        /*double*/ get DEPTH_ATTACHMENT()
        {
            return _backingField_DEPTH_ATTACHMENT;
        }
        /*double*/ _backingField_DEPTH_BITS = null;
        /*double*/ get DEPTH_BITS()
        {
            return _backingField_DEPTH_BITS;
        }
        /*double*/ _backingField_DEPTH_BUFFER_BIT = null;
        /*double*/ get DEPTH_BUFFER_BIT()
        {
            return _backingField_DEPTH_BUFFER_BIT;
        }
        /*double*/ _backingField_DEPTH_CLEAR_VALUE = null;
        /*double*/ get DEPTH_CLEAR_VALUE()
        {
            return _backingField_DEPTH_CLEAR_VALUE;
        }
        /*double*/ _backingField_DEPTH_COMPONENT = null;
        /*double*/ get DEPTH_COMPONENT()
        {
            return _backingField_DEPTH_COMPONENT;
        }
        /*double*/ _backingField_DEPTH_COMPONENT16 = null;
        /*double*/ get DEPTH_COMPONENT16()
        {
            return _backingField_DEPTH_COMPONENT16;
        }
        /*double*/ _backingField_DEPTH_FUNC = null;
        /*double*/ get DEPTH_FUNC()
        {
            return _backingField_DEPTH_FUNC;
        }
        /*double*/ _backingField_DEPTH_RANGE = null;
        /*double*/ get DEPTH_RANGE()
        {
            return _backingField_DEPTH_RANGE;
        }
        /*double*/ _backingField_DEPTH_STENCIL = null;
        /*double*/ get DEPTH_STENCIL()
        {
            return _backingField_DEPTH_STENCIL;
        }
        /*double*/ _backingField_DEPTH_STENCIL_ATTACHMENT = null;
        /*double*/ get DEPTH_STENCIL_ATTACHMENT()
        {
            return _backingField_DEPTH_STENCIL_ATTACHMENT;
        }
        /*double*/ _backingField_DEPTH_TEST = null;
        /*double*/ get DEPTH_TEST()
        {
            return _backingField_DEPTH_TEST;
        }
        /*double*/ _backingField_DEPTH_WRITEMASK = null;
        /*double*/ get DEPTH_WRITEMASK()
        {
            return _backingField_DEPTH_WRITEMASK;
        }
        /*double*/ _backingField_DITHER = null;
        /*double*/ get DITHER()
        {
            return _backingField_DITHER;
        }
        /*double*/ _backingField_DONT_CARE = null;
        /*double*/ get DONT_CARE()
        {
            return _backingField_DONT_CARE;
        }
        /*double*/ _backingField_DST_ALPHA = null;
        /*double*/ get DST_ALPHA()
        {
            return _backingField_DST_ALPHA;
        }
        /*double*/ _backingField_DST_COLOR = null;
        /*double*/ get DST_COLOR()
        {
            return _backingField_DST_COLOR;
        }
        /*double*/ _backingField_DYNAMIC_DRAW = null;
        /*double*/ get DYNAMIC_DRAW()
        {
            return _backingField_DYNAMIC_DRAW;
        }
        /*double*/ _backingField_ELEMENT_ARRAY_BUFFER = null;
        /*double*/ get ELEMENT_ARRAY_BUFFER()
        {
            return _backingField_ELEMENT_ARRAY_BUFFER;
        }
        /*double*/ _backingField_ELEMENT_ARRAY_BUFFER_BINDING = null;
        /*double*/ get ELEMENT_ARRAY_BUFFER_BINDING()
        {
            return _backingField_ELEMENT_ARRAY_BUFFER_BINDING;
        }
        /*double*/ _backingField_EQUAL = null;
        /*double*/ get EQUAL()
        {
            return _backingField_EQUAL;
        }
        /*double*/ _backingField_FASTEST = null;
        /*double*/ get FASTEST()
        {
            return _backingField_FASTEST;
        }
        /*double*/ _backingField_FLOAT = null;
        /*double*/ get FLOAT()
        {
            return _backingField_FLOAT;
        }
        /*double*/ _backingField_FLOAT_MAT2 = null;
        /*double*/ get FLOAT_MAT2()
        {
            return _backingField_FLOAT_MAT2;
        }
        /*double*/ _backingField_FLOAT_MAT3 = null;
        /*double*/ get FLOAT_MAT3()
        {
            return _backingField_FLOAT_MAT3;
        }
        /*double*/ _backingField_FLOAT_MAT4 = null;
        /*double*/ get FLOAT_MAT4()
        {
            return _backingField_FLOAT_MAT4;
        }
        /*double*/ _backingField_FLOAT_VEC2 = null;
        /*double*/ get FLOAT_VEC2()
        {
            return _backingField_FLOAT_VEC2;
        }
        /*double*/ _backingField_FLOAT_VEC3 = null;
        /*double*/ get FLOAT_VEC3()
        {
            return _backingField_FLOAT_VEC3;
        }
        /*double*/ _backingField_FLOAT_VEC4 = null;
        /*double*/ get FLOAT_VEC4()
        {
            return _backingField_FLOAT_VEC4;
        }
        /*double*/ _backingField_FRAGMENT_SHADER = null;
        /*double*/ get FRAGMENT_SHADER()
        {
            return _backingField_FRAGMENT_SHADER;
        }
        /*double*/ _backingField_FRAMEBUFFER = null;
        /*double*/ get FRAMEBUFFER()
        {
            return _backingField_FRAMEBUFFER;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_OBJECT_NAME()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_OBJECT_NAME;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_CUBE_MAP_FACE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LEVEL;
        }
        /*double*/ _backingField_FRAMEBUFFER_BINDING = null;
        /*double*/ get FRAMEBUFFER_BINDING()
        {
            return _backingField_FRAMEBUFFER_BINDING;
        }
        /*double*/ _backingField_FRAMEBUFFER_COMPLETE = null;
        /*double*/ get FRAMEBUFFER_COMPLETE()
        {
            return _backingField_FRAMEBUFFER_COMPLETE;
        }
        /*double*/ _backingField_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = null;
        /*double*/ get FRAMEBUFFER_INCOMPLETE_ATTACHMENT()
        {
            return _backingField_FRAMEBUFFER_INCOMPLETE_ATTACHMENT;
        }
        /*double*/ _backingField_FRAMEBUFFER_INCOMPLETE_DIMENSIONS = null;
        /*double*/ get FRAMEBUFFER_INCOMPLETE_DIMENSIONS()
        {
            return _backingField_FRAMEBUFFER_INCOMPLETE_DIMENSIONS;
        }
        /*double*/ _backingField_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = null;
        /*double*/ get FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT()
        {
            return _backingField_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT;
        }
        /*double*/ _backingField_FRAMEBUFFER_UNSUPPORTED = null;
        /*double*/ get FRAMEBUFFER_UNSUPPORTED()
        {
            return _backingField_FRAMEBUFFER_UNSUPPORTED;
        }
        /*double*/ _backingField_FRONT = null;
        /*double*/ get FRONT()
        {
            return _backingField_FRONT;
        }
        /*double*/ _backingField_FRONT_AND_BACK = null;
        /*double*/ get FRONT_AND_BACK()
        {
            return _backingField_FRONT_AND_BACK;
        }
        /*double*/ _backingField_FRONT_FACE = null;
        /*double*/ get FRONT_FACE()
        {
            return _backingField_FRONT_FACE;
        }
        /*double*/ _backingField_FUNC_ADD = null;
        /*double*/ get FUNC_ADD()
        {
            return _backingField_FUNC_ADD;
        }
        /*double*/ _backingField_FUNC_REVERSE_SUBTRACT = null;
        /*double*/ get FUNC_REVERSE_SUBTRACT()
        {
            return _backingField_FUNC_REVERSE_SUBTRACT;
        }
        /*double*/ _backingField_FUNC_SUBTRACT = null;
        /*double*/ get FUNC_SUBTRACT()
        {
            return _backingField_FUNC_SUBTRACT;
        }
        /*double*/ _backingField_GENERATE_MIPMAP_HINT = null;
        /*double*/ get GENERATE_MIPMAP_HINT()
        {
            return _backingField_GENERATE_MIPMAP_HINT;
        }
        /*double*/ _backingField_GEQUAL = null;
        /*double*/ get GEQUAL()
        {
            return _backingField_GEQUAL;
        }
        /*double*/ _backingField_GREATER = null;
        /*double*/ get GREATER()
        {
            return _backingField_GREATER;
        }
        /*double*/ _backingField_GREEN_BITS = null;
        /*double*/ get GREEN_BITS()
        {
            return _backingField_GREEN_BITS;
        }
        /*double*/ _backingField_HIGH_FLOAT = null;
        /*double*/ get HIGH_FLOAT()
        {
            return _backingField_HIGH_FLOAT;
        }
        /*double*/ _backingField_HIGH_INT = null;
        /*double*/ get HIGH_INT()
        {
            return _backingField_HIGH_INT;
        }
        /*double*/ _backingField_IMPLEMENTATION_COLOR_READ_FORMAT = null;
        /*double*/ get IMPLEMENTATION_COLOR_READ_FORMAT()
        {
            return _backingField_IMPLEMENTATION_COLOR_READ_FORMAT;
        }
        /*double*/ _backingField_IMPLEMENTATION_COLOR_READ_TYPE = null;
        /*double*/ get IMPLEMENTATION_COLOR_READ_TYPE()
        {
            return _backingField_IMPLEMENTATION_COLOR_READ_TYPE;
        }
        /*double*/ _backingField_INCR = null;
        /*double*/ get INCR()
        {
            return _backingField_INCR;
        }
        /*double*/ _backingField_INCR_WRAP = null;
        /*double*/ get INCR_WRAP()
        {
            return _backingField_INCR_WRAP;
        }
        /*double*/ _backingField_INT = null;
        /*double*/ get INT()
        {
            return _backingField_INT;
        }
        /*double*/ _backingField_INT_VEC2 = null;
        /*double*/ get INT_VEC2()
        {
            return _backingField_INT_VEC2;
        }
        /*double*/ _backingField_INT_VEC3 = null;
        /*double*/ get INT_VEC3()
        {
            return _backingField_INT_VEC3;
        }
        /*double*/ _backingField_INT_VEC4 = null;
        /*double*/ get INT_VEC4()
        {
            return _backingField_INT_VEC4;
        }
        /*double*/ _backingField_INVALID_ENUM = null;
        /*double*/ get INVALID_ENUM()
        {
            return _backingField_INVALID_ENUM;
        }
        /*double*/ _backingField_INVALID_FRAMEBUFFER_OPERATION = null;
        /*double*/ get INVALID_FRAMEBUFFER_OPERATION()
        {
            return _backingField_INVALID_FRAMEBUFFER_OPERATION;
        }
        /*double*/ _backingField_INVALID_OPERATION = null;
        /*double*/ get INVALID_OPERATION()
        {
            return _backingField_INVALID_OPERATION;
        }
        /*double*/ _backingField_INVALID_VALUE = null;
        /*double*/ get INVALID_VALUE()
        {
            return _backingField_INVALID_VALUE;
        }
        /*double*/ _backingField_INVERT = null;
        /*double*/ get INVERT()
        {
            return _backingField_INVERT;
        }
        /*double*/ _backingField_KEEP = null;
        /*double*/ get KEEP()
        {
            return _backingField_KEEP;
        }
        /*double*/ _backingField_LEQUAL = null;
        /*double*/ get LEQUAL()
        {
            return _backingField_LEQUAL;
        }
        /*double*/ _backingField_LESS = null;
        /*double*/ get LESS()
        {
            return _backingField_LESS;
        }
        /*double*/ _backingField_LINEAR = null;
        /*double*/ get LINEAR()
        {
            return _backingField_LINEAR;
        }
        /*double*/ _backingField_LINEAR_MIPMAP_LINEAR = null;
        /*double*/ get LINEAR_MIPMAP_LINEAR()
        {
            return _backingField_LINEAR_MIPMAP_LINEAR;
        }
        /*double*/ _backingField_LINEAR_MIPMAP_NEAREST = null;
        /*double*/ get LINEAR_MIPMAP_NEAREST()
        {
            return _backingField_LINEAR_MIPMAP_NEAREST;
        }
        /*double*/ _backingField_LINES = null;
        /*double*/ get LINES()
        {
            return _backingField_LINES;
        }
        /*double*/ _backingField_LINE_LOOP = null;
        /*double*/ get LINE_LOOP()
        {
            return _backingField_LINE_LOOP;
        }
        /*double*/ _backingField_LINE_STRIP = null;
        /*double*/ get LINE_STRIP()
        {
            return _backingField_LINE_STRIP;
        }
        /*double*/ _backingField_LINE_WIDTH = null;
        /*double*/ get LINE_WIDTH()
        {
            return _backingField_LINE_WIDTH;
        }
        /*double*/ _backingField_LINK_STATUS = null;
        /*double*/ get LINK_STATUS()
        {
            return _backingField_LINK_STATUS;
        }
        /*double*/ _backingField_LOW_FLOAT = null;
        /*double*/ get LOW_FLOAT()
        {
            return _backingField_LOW_FLOAT;
        }
        /*double*/ _backingField_LOW_INT = null;
        /*double*/ get LOW_INT()
        {
            return _backingField_LOW_INT;
        }
        /*double*/ _backingField_LUMINANCE = null;
        /*double*/ get LUMINANCE()
        {
            return _backingField_LUMINANCE;
        }
        /*double*/ _backingField_LUMINANCE_ALPHA = null;
        /*double*/ get LUMINANCE_ALPHA()
        {
            return _backingField_LUMINANCE_ALPHA;
        }
        /*double*/ _backingField_MAX_COMBINED_TEXTURE_IMAGE_UNITS = null;
        /*double*/ get MAX_COMBINED_TEXTURE_IMAGE_UNITS()
        {
            return _backingField_MAX_COMBINED_TEXTURE_IMAGE_UNITS;
        }
        /*double*/ _backingField_MAX_CUBE_MAP_TEXTURE_SIZE = null;
        /*double*/ get MAX_CUBE_MAP_TEXTURE_SIZE()
        {
            return _backingField_MAX_CUBE_MAP_TEXTURE_SIZE;
        }
        /*double*/ _backingField_MAX_FRAGMENT_UNIFORM_VECTORS = null;
        /*double*/ get MAX_FRAGMENT_UNIFORM_VECTORS()
        {
            return _backingField_MAX_FRAGMENT_UNIFORM_VECTORS;
        }
        /*double*/ _backingField_MAX_RENDERBUFFER_SIZE = null;
        /*double*/ get MAX_RENDERBUFFER_SIZE()
        {
            return _backingField_MAX_RENDERBUFFER_SIZE;
        }
        /*double*/ _backingField_MAX_TEXTURE_IMAGE_UNITS = null;
        /*double*/ get MAX_TEXTURE_IMAGE_UNITS()
        {
            return _backingField_MAX_TEXTURE_IMAGE_UNITS;
        }
        /*double*/ _backingField_MAX_TEXTURE_SIZE = null;
        /*double*/ get MAX_TEXTURE_SIZE()
        {
            return _backingField_MAX_TEXTURE_SIZE;
        }
        /*double*/ _backingField_MAX_VARYING_VECTORS = null;
        /*double*/ get MAX_VARYING_VECTORS()
        {
            return _backingField_MAX_VARYING_VECTORS;
        }
        /*double*/ _backingField_MAX_VERTEX_ATTRIBS = null;
        /*double*/ get MAX_VERTEX_ATTRIBS()
        {
            return _backingField_MAX_VERTEX_ATTRIBS;
        }
        /*double*/ _backingField_MAX_VERTEX_TEXTURE_IMAGE_UNITS = null;
        /*double*/ get MAX_VERTEX_TEXTURE_IMAGE_UNITS()
        {
            return _backingField_MAX_VERTEX_TEXTURE_IMAGE_UNITS;
        }
        /*double*/ _backingField_MAX_VERTEX_UNIFORM_VECTORS = null;
        /*double*/ get MAX_VERTEX_UNIFORM_VECTORS()
        {
            return _backingField_MAX_VERTEX_UNIFORM_VECTORS;
        }
        /*double*/ _backingField_MAX_VIEWPORT_DIMS = null;
        /*double*/ get MAX_VIEWPORT_DIMS()
        {
            return _backingField_MAX_VIEWPORT_DIMS;
        }
        /*double*/ _backingField_MEDIUM_FLOAT = null;
        /*double*/ get MEDIUM_FLOAT()
        {
            return _backingField_MEDIUM_FLOAT;
        }
        /*double*/ _backingField_MEDIUM_INT = null;
        /*double*/ get MEDIUM_INT()
        {
            return _backingField_MEDIUM_INT;
        }
        /*double*/ _backingField_MIRRORED_REPEAT = null;
        /*double*/ get MIRRORED_REPEAT()
        {
            return _backingField_MIRRORED_REPEAT;
        }
        /*double*/ _backingField_NEAREST = null;
        /*double*/ get NEAREST()
        {
            return _backingField_NEAREST;
        }
        /*double*/ _backingField_NEAREST_MIPMAP_LINEAR = null;
        /*double*/ get NEAREST_MIPMAP_LINEAR()
        {
            return _backingField_NEAREST_MIPMAP_LINEAR;
        }
        /*double*/ _backingField_NEAREST_MIPMAP_NEAREST = null;
        /*double*/ get NEAREST_MIPMAP_NEAREST()
        {
            return _backingField_NEAREST_MIPMAP_NEAREST;
        }
        /*double*/ _backingField_NEVER = null;
        /*double*/ get NEVER()
        {
            return _backingField_NEVER;
        }
        /*double*/ _backingField_NICEST = null;
        /*double*/ get NICEST()
        {
            return _backingField_NICEST;
        }
        /*double*/ _backingField_NONE = null;
        /*double*/ get NONE()
        {
            return _backingField_NONE;
        }
        /*double*/ _backingField_NOTEQUAL = null;
        /*double*/ get NOTEQUAL()
        {
            return _backingField_NOTEQUAL;
        }
        /*double*/ _backingField_NO_ERROR = null;
        /*double*/ get NO_ERROR()
        {
            return _backingField_NO_ERROR;
        }
        /*double*/ _backingField_ONE = null;
        /*double*/ get ONE()
        {
            return _backingField_ONE;
        }
        /*double*/ _backingField_ONE_MINUS_CONSTANT_ALPHA = null;
        /*double*/ get ONE_MINUS_CONSTANT_ALPHA()
        {
            return _backingField_ONE_MINUS_CONSTANT_ALPHA;
        }
        /*double*/ _backingField_ONE_MINUS_CONSTANT_COLOR = null;
        /*double*/ get ONE_MINUS_CONSTANT_COLOR()
        {
            return _backingField_ONE_MINUS_CONSTANT_COLOR;
        }
        /*double*/ _backingField_ONE_MINUS_DST_ALPHA = null;
        /*double*/ get ONE_MINUS_DST_ALPHA()
        {
            return _backingField_ONE_MINUS_DST_ALPHA;
        }
        /*double*/ _backingField_ONE_MINUS_DST_COLOR = null;
        /*double*/ get ONE_MINUS_DST_COLOR()
        {
            return _backingField_ONE_MINUS_DST_COLOR;
        }
        /*double*/ _backingField_ONE_MINUS_SRC_ALPHA = null;
        /*double*/ get ONE_MINUS_SRC_ALPHA()
        {
            return _backingField_ONE_MINUS_SRC_ALPHA;
        }
        /*double*/ _backingField_ONE_MINUS_SRC_COLOR = null;
        /*double*/ get ONE_MINUS_SRC_COLOR()
        {
            return _backingField_ONE_MINUS_SRC_COLOR;
        }
        /*double*/ _backingField_OUT_OF_MEMORY = null;
        /*double*/ get OUT_OF_MEMORY()
        {
            return _backingField_OUT_OF_MEMORY;
        }
        /*double*/ _backingField_PACK_ALIGNMENT = null;
        /*double*/ get PACK_ALIGNMENT()
        {
            return _backingField_PACK_ALIGNMENT;
        }
        /*double*/ _backingField_POINTS = null;
        /*double*/ get POINTS()
        {
            return _backingField_POINTS;
        }
        /*double*/ _backingField_POLYGON_OFFSET_FACTOR = null;
        /*double*/ get POLYGON_OFFSET_FACTOR()
        {
            return _backingField_POLYGON_OFFSET_FACTOR;
        }
        /*double*/ _backingField_POLYGON_OFFSET_FILL = null;
        /*double*/ get POLYGON_OFFSET_FILL()
        {
            return _backingField_POLYGON_OFFSET_FILL;
        }
        /*double*/ _backingField_POLYGON_OFFSET_UNITS = null;
        /*double*/ get POLYGON_OFFSET_UNITS()
        {
            return _backingField_POLYGON_OFFSET_UNITS;
        }
        /*double*/ _backingField_RED_BITS = null;
        /*double*/ get RED_BITS()
        {
            return _backingField_RED_BITS;
        }
        /*double*/ _backingField_RENDERBUFFER = null;
        /*double*/ get RENDERBUFFER()
        {
            return _backingField_RENDERBUFFER;
        }
        /*double*/ _backingField_RENDERBUFFER_ALPHA_SIZE = null;
        /*double*/ get RENDERBUFFER_ALPHA_SIZE()
        {
            return _backingField_RENDERBUFFER_ALPHA_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_BINDING = null;
        /*double*/ get RENDERBUFFER_BINDING()
        {
            return _backingField_RENDERBUFFER_BINDING;
        }
        /*double*/ _backingField_RENDERBUFFER_BLUE_SIZE = null;
        /*double*/ get RENDERBUFFER_BLUE_SIZE()
        {
            return _backingField_RENDERBUFFER_BLUE_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_DEPTH_SIZE = null;
        /*double*/ get RENDERBUFFER_DEPTH_SIZE()
        {
            return _backingField_RENDERBUFFER_DEPTH_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_GREEN_SIZE = null;
        /*double*/ get RENDERBUFFER_GREEN_SIZE()
        {
            return _backingField_RENDERBUFFER_GREEN_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_HEIGHT = null;
        /*double*/ get RENDERBUFFER_HEIGHT()
        {
            return _backingField_RENDERBUFFER_HEIGHT;
        }
        /*double*/ _backingField_RENDERBUFFER_INTERNAL_FORMAT = null;
        /*double*/ get RENDERBUFFER_INTERNAL_FORMAT()
        {
            return _backingField_RENDERBUFFER_INTERNAL_FORMAT;
        }
        /*double*/ _backingField_RENDERBUFFER_RED_SIZE = null;
        /*double*/ get RENDERBUFFER_RED_SIZE()
        {
            return _backingField_RENDERBUFFER_RED_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_STENCIL_SIZE = null;
        /*double*/ get RENDERBUFFER_STENCIL_SIZE()
        {
            return _backingField_RENDERBUFFER_STENCIL_SIZE;
        }
        /*double*/ _backingField_RENDERBUFFER_WIDTH = null;
        /*double*/ get RENDERBUFFER_WIDTH()
        {
            return _backingField_RENDERBUFFER_WIDTH;
        }
        /*double*/ _backingField_RENDERER = null;
        /*double*/ get RENDERER()
        {
            return _backingField_RENDERER;
        }
        /*double*/ _backingField_REPEAT = null;
        /*double*/ get REPEAT()
        {
            return _backingField_REPEAT;
        }
        /*double*/ _backingField_REPLACE = null;
        /*double*/ get REPLACE()
        {
            return _backingField_REPLACE;
        }
        /*double*/ _backingField_RGB = null;
        /*double*/ get RGB()
        {
            return _backingField_RGB;
        }
        /*double*/ _backingField_RGB565 = null;
        /*double*/ get RGB565()
        {
            return _backingField_RGB565;
        }
        /*double*/ _backingField_RGB5_A1 = null;
        /*double*/ get RGB5_A1()
        {
            return _backingField_RGB5_A1;
        }
        /*double*/ _backingField_RGBA = null;
        /*double*/ get RGBA()
        {
            return _backingField_RGBA;
        }
        /*double*/ _backingField_RGBA4 = null;
        /*double*/ get RGBA4()
        {
            return _backingField_RGBA4;
        }
        /*double*/ _backingField_SAMPLER_2D = null;
        /*double*/ get SAMPLER_2D()
        {
            return _backingField_SAMPLER_2D;
        }
        /*double*/ _backingField_SAMPLER_CUBE = null;
        /*double*/ get SAMPLER_CUBE()
        {
            return _backingField_SAMPLER_CUBE;
        }
        /*double*/ _backingField_SAMPLES = null;
        /*double*/ get SAMPLES()
        {
            return _backingField_SAMPLES;
        }
        /*double*/ _backingField_SAMPLE_ALPHA_TO_COVERAGE = null;
        /*double*/ get SAMPLE_ALPHA_TO_COVERAGE()
        {
            return _backingField_SAMPLE_ALPHA_TO_COVERAGE;
        }
        /*double*/ _backingField_SAMPLE_BUFFERS = null;
        /*double*/ get SAMPLE_BUFFERS()
        {
            return _backingField_SAMPLE_BUFFERS;
        }
        /*double*/ _backingField_SAMPLE_COVERAGE = null;
        /*double*/ get SAMPLE_COVERAGE()
        {
            return _backingField_SAMPLE_COVERAGE;
        }
        /*double*/ _backingField_SAMPLE_COVERAGE_INVERT = null;
        /*double*/ get SAMPLE_COVERAGE_INVERT()
        {
            return _backingField_SAMPLE_COVERAGE_INVERT;
        }
        /*double*/ _backingField_SAMPLE_COVERAGE_VALUE = null;
        /*double*/ get SAMPLE_COVERAGE_VALUE()
        {
            return _backingField_SAMPLE_COVERAGE_VALUE;
        }
        /*double*/ _backingField_SCISSOR_BOX = null;
        /*double*/ get SCISSOR_BOX()
        {
            return _backingField_SCISSOR_BOX;
        }
        /*double*/ _backingField_SCISSOR_TEST = null;
        /*double*/ get SCISSOR_TEST()
        {
            return _backingField_SCISSOR_TEST;
        }
        /*double*/ _backingField_SHADER_TYPE = null;
        /*double*/ get SHADER_TYPE()
        {
            return _backingField_SHADER_TYPE;
        }
        /*double*/ _backingField_SHADING_LANGUAGE_VERSION = null;
        /*double*/ get SHADING_LANGUAGE_VERSION()
        {
            return _backingField_SHADING_LANGUAGE_VERSION;
        }
        /*double*/ _backingField_SHORT = null;
        /*double*/ get SHORT()
        {
            return _backingField_SHORT;
        }
        /*double*/ _backingField_SRC_ALPHA = null;
        /*double*/ get SRC_ALPHA()
        {
            return _backingField_SRC_ALPHA;
        }
        /*double*/ _backingField_SRC_ALPHA_SATURATE = null;
        /*double*/ get SRC_ALPHA_SATURATE()
        {
            return _backingField_SRC_ALPHA_SATURATE;
        }
        /*double*/ _backingField_SRC_COLOR = null;
        /*double*/ get SRC_COLOR()
        {
            return _backingField_SRC_COLOR;
        }
        /*double*/ _backingField_STATIC_DRAW = null;
        /*double*/ get STATIC_DRAW()
        {
            return _backingField_STATIC_DRAW;
        }
        /*double*/ _backingField_STENCIL_ATTACHMENT = null;
        /*double*/ get STENCIL_ATTACHMENT()
        {
            return _backingField_STENCIL_ATTACHMENT;
        }
        /*double*/ _backingField_STENCIL_BACK_FAIL = null;
        /*double*/ get STENCIL_BACK_FAIL()
        {
            return _backingField_STENCIL_BACK_FAIL;
        }
        /*double*/ _backingField_STENCIL_BACK_FUNC = null;
        /*double*/ get STENCIL_BACK_FUNC()
        {
            return _backingField_STENCIL_BACK_FUNC;
        }
        /*double*/ _backingField_STENCIL_BACK_PASS_DEPTH_FAIL = null;
        /*double*/ get STENCIL_BACK_PASS_DEPTH_FAIL()
        {
            return _backingField_STENCIL_BACK_PASS_DEPTH_FAIL;
        }
        /*double*/ _backingField_STENCIL_BACK_PASS_DEPTH_PASS = null;
        /*double*/ get STENCIL_BACK_PASS_DEPTH_PASS()
        {
            return _backingField_STENCIL_BACK_PASS_DEPTH_PASS;
        }
        /*double*/ _backingField_STENCIL_BACK_REF = null;
        /*double*/ get STENCIL_BACK_REF()
        {
            return _backingField_STENCIL_BACK_REF;
        }
        /*double*/ _backingField_STENCIL_BACK_VALUE_MASK = null;
        /*double*/ get STENCIL_BACK_VALUE_MASK()
        {
            return _backingField_STENCIL_BACK_VALUE_MASK;
        }
        /*double*/ _backingField_STENCIL_BACK_WRITEMASK = null;
        /*double*/ get STENCIL_BACK_WRITEMASK()
        {
            return _backingField_STENCIL_BACK_WRITEMASK;
        }
        /*double*/ _backingField_STENCIL_BITS = null;
        /*double*/ get STENCIL_BITS()
        {
            return _backingField_STENCIL_BITS;
        }
        /*double*/ _backingField_STENCIL_BUFFER_BIT = null;
        /*double*/ get STENCIL_BUFFER_BIT()
        {
            return _backingField_STENCIL_BUFFER_BIT;
        }
        /*double*/ _backingField_STENCIL_CLEAR_VALUE = null;
        /*double*/ get STENCIL_CLEAR_VALUE()
        {
            return _backingField_STENCIL_CLEAR_VALUE;
        }
        /*double*/ _backingField_STENCIL_FAIL = null;
        /*double*/ get STENCIL_FAIL()
        {
            return _backingField_STENCIL_FAIL;
        }
        /*double*/ _backingField_STENCIL_FUNC = null;
        /*double*/ get STENCIL_FUNC()
        {
            return _backingField_STENCIL_FUNC;
        }
        /*double*/ _backingField_STENCIL_INDEX = null;
        /*double*/ get STENCIL_INDEX()
        {
            return _backingField_STENCIL_INDEX;
        }
        /*double*/ _backingField_STENCIL_INDEX8 = null;
        /*double*/ get STENCIL_INDEX8()
        {
            return _backingField_STENCIL_INDEX8;
        }
        /*double*/ _backingField_STENCIL_PASS_DEPTH_FAIL = null;
        /*double*/ get STENCIL_PASS_DEPTH_FAIL()
        {
            return _backingField_STENCIL_PASS_DEPTH_FAIL;
        }
        /*double*/ _backingField_STENCIL_PASS_DEPTH_PASS = null;
        /*double*/ get STENCIL_PASS_DEPTH_PASS()
        {
            return _backingField_STENCIL_PASS_DEPTH_PASS;
        }
        /*double*/ _backingField_STENCIL_REF = null;
        /*double*/ get STENCIL_REF()
        {
            return _backingField_STENCIL_REF;
        }
        /*double*/ _backingField_STENCIL_TEST = null;
        /*double*/ get STENCIL_TEST()
        {
            return _backingField_STENCIL_TEST;
        }
        /*double*/ _backingField_STENCIL_VALUE_MASK = null;
        /*double*/ get STENCIL_VALUE_MASK()
        {
            return _backingField_STENCIL_VALUE_MASK;
        }
        /*double*/ _backingField_STENCIL_WRITEMASK = null;
        /*double*/ get STENCIL_WRITEMASK()
        {
            return _backingField_STENCIL_WRITEMASK;
        }
        /*double*/ _backingField_STREAM_DRAW = null;
        /*double*/ get STREAM_DRAW()
        {
            return _backingField_STREAM_DRAW;
        }
        /*double*/ _backingField_SUBPIXEL_BITS = null;
        /*double*/ get SUBPIXEL_BITS()
        {
            return _backingField_SUBPIXEL_BITS;
        }
        /*double*/ _backingField_TEXTURE = null;
        /*double*/ get TEXTURE()
        {
            return _backingField_TEXTURE;
        }
        /*double*/ _backingField_TEXTURE0 = null;
        /*double*/ get TEXTURE0()
        {
            return _backingField_TEXTURE0;
        }
        /*double*/ _backingField_TEXTURE1 = null;
        /*double*/ get TEXTURE1()
        {
            return _backingField_TEXTURE1;
        }
        /*double*/ _backingField_TEXTURE10 = null;
        /*double*/ get TEXTURE10()
        {
            return _backingField_TEXTURE10;
        }
        /*double*/ _backingField_TEXTURE11 = null;
        /*double*/ get TEXTURE11()
        {
            return _backingField_TEXTURE11;
        }
        /*double*/ _backingField_TEXTURE12 = null;
        /*double*/ get TEXTURE12()
        {
            return _backingField_TEXTURE12;
        }
        /*double*/ _backingField_TEXTURE13 = null;
        /*double*/ get TEXTURE13()
        {
            return _backingField_TEXTURE13;
        }
        /*double*/ _backingField_TEXTURE14 = null;
        /*double*/ get TEXTURE14()
        {
            return _backingField_TEXTURE14;
        }
        /*double*/ _backingField_TEXTURE15 = null;
        /*double*/ get TEXTURE15()
        {
            return _backingField_TEXTURE15;
        }
        /*double*/ _backingField_TEXTURE16 = null;
        /*double*/ get TEXTURE16()
        {
            return _backingField_TEXTURE16;
        }
        /*double*/ _backingField_TEXTURE17 = null;
        /*double*/ get TEXTURE17()
        {
            return _backingField_TEXTURE17;
        }
        /*double*/ _backingField_TEXTURE18 = null;
        /*double*/ get TEXTURE18()
        {
            return _backingField_TEXTURE18;
        }
        /*double*/ _backingField_TEXTURE19 = null;
        /*double*/ get TEXTURE19()
        {
            return _backingField_TEXTURE19;
        }
        /*double*/ _backingField_TEXTURE2 = null;
        /*double*/ get TEXTURE2()
        {
            return _backingField_TEXTURE2;
        }
        /*double*/ _backingField_TEXTURE20 = null;
        /*double*/ get TEXTURE20()
        {
            return _backingField_TEXTURE20;
        }
        /*double*/ _backingField_TEXTURE21 = null;
        /*double*/ get TEXTURE21()
        {
            return _backingField_TEXTURE21;
        }
        /*double*/ _backingField_TEXTURE22 = null;
        /*double*/ get TEXTURE22()
        {
            return _backingField_TEXTURE22;
        }
        /*double*/ _backingField_TEXTURE23 = null;
        /*double*/ get TEXTURE23()
        {
            return _backingField_TEXTURE23;
        }
        /*double*/ _backingField_TEXTURE24 = null;
        /*double*/ get TEXTURE24()
        {
            return _backingField_TEXTURE24;
        }
        /*double*/ _backingField_TEXTURE25 = null;
        /*double*/ get TEXTURE25()
        {
            return _backingField_TEXTURE25;
        }
        /*double*/ _backingField_TEXTURE26 = null;
        /*double*/ get TEXTURE26()
        {
            return _backingField_TEXTURE26;
        }
        /*double*/ _backingField_TEXTURE27 = null;
        /*double*/ get TEXTURE27()
        {
            return _backingField_TEXTURE27;
        }
        /*double*/ _backingField_TEXTURE28 = null;
        /*double*/ get TEXTURE28()
        {
            return _backingField_TEXTURE28;
        }
        /*double*/ _backingField_TEXTURE29 = null;
        /*double*/ get TEXTURE29()
        {
            return _backingField_TEXTURE29;
        }
        /*double*/ _backingField_TEXTURE3 = null;
        /*double*/ get TEXTURE3()
        {
            return _backingField_TEXTURE3;
        }
        /*double*/ _backingField_TEXTURE30 = null;
        /*double*/ get TEXTURE30()
        {
            return _backingField_TEXTURE30;
        }
        /*double*/ _backingField_TEXTURE31 = null;
        /*double*/ get TEXTURE31()
        {
            return _backingField_TEXTURE31;
        }
        /*double*/ _backingField_TEXTURE4 = null;
        /*double*/ get TEXTURE4()
        {
            return _backingField_TEXTURE4;
        }
        /*double*/ _backingField_TEXTURE5 = null;
        /*double*/ get TEXTURE5()
        {
            return _backingField_TEXTURE5;
        }
        /*double*/ _backingField_TEXTURE6 = null;
        /*double*/ get TEXTURE6()
        {
            return _backingField_TEXTURE6;
        }
        /*double*/ _backingField_TEXTURE7 = null;
        /*double*/ get TEXTURE7()
        {
            return _backingField_TEXTURE7;
        }
        /*double*/ _backingField_TEXTURE8 = null;
        /*double*/ get TEXTURE8()
        {
            return _backingField_TEXTURE8;
        }
        /*double*/ _backingField_TEXTURE9 = null;
        /*double*/ get TEXTURE9()
        {
            return _backingField_TEXTURE9;
        }
        /*double*/ _backingField_TEXTURE_2D = null;
        /*double*/ get TEXTURE_2D()
        {
            return _backingField_TEXTURE_2D;
        }
        /*double*/ _backingField_TEXTURE_BINDING_2D = null;
        /*double*/ get TEXTURE_BINDING_2D()
        {
            return _backingField_TEXTURE_BINDING_2D;
        }
        /*double*/ _backingField_TEXTURE_BINDING_CUBE_MAP = null;
        /*double*/ get TEXTURE_BINDING_CUBE_MAP()
        {
            return _backingField_TEXTURE_BINDING_CUBE_MAP;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP = null;
        /*double*/ get TEXTURE_CUBE_MAP()
        {
            return _backingField_TEXTURE_CUBE_MAP;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_NEGATIVE_X = null;
        /*double*/ get TEXTURE_CUBE_MAP_NEGATIVE_X()
        {
            return _backingField_TEXTURE_CUBE_MAP_NEGATIVE_X;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_NEGATIVE_Y = null;
        /*double*/ get TEXTURE_CUBE_MAP_NEGATIVE_Y()
        {
            return _backingField_TEXTURE_CUBE_MAP_NEGATIVE_Y;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_NEGATIVE_Z = null;
        /*double*/ get TEXTURE_CUBE_MAP_NEGATIVE_Z()
        {
            return _backingField_TEXTURE_CUBE_MAP_NEGATIVE_Z;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_POSITIVE_X = null;
        /*double*/ get TEXTURE_CUBE_MAP_POSITIVE_X()
        {
            return _backingField_TEXTURE_CUBE_MAP_POSITIVE_X;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_POSITIVE_Y = null;
        /*double*/ get TEXTURE_CUBE_MAP_POSITIVE_Y()
        {
            return _backingField_TEXTURE_CUBE_MAP_POSITIVE_Y;
        }
        /*double*/ _backingField_TEXTURE_CUBE_MAP_POSITIVE_Z = null;
        /*double*/ get TEXTURE_CUBE_MAP_POSITIVE_Z()
        {
            return _backingField_TEXTURE_CUBE_MAP_POSITIVE_Z;
        }
        /*double*/ _backingField_TEXTURE_MAG_FILTER = null;
        /*double*/ get TEXTURE_MAG_FILTER()
        {
            return _backingField_TEXTURE_MAG_FILTER;
        }
        /*double*/ _backingField_TEXTURE_MIN_FILTER = null;
        /*double*/ get TEXTURE_MIN_FILTER()
        {
            return _backingField_TEXTURE_MIN_FILTER;
        }
        /*double*/ _backingField_TEXTURE_WRAP_S = null;
        /*double*/ get TEXTURE_WRAP_S()
        {
            return _backingField_TEXTURE_WRAP_S;
        }
        /*double*/ _backingField_TEXTURE_WRAP_T = null;
        /*double*/ get TEXTURE_WRAP_T()
        {
            return _backingField_TEXTURE_WRAP_T;
        }
        /*double*/ _backingField_TRIANGLES = null;
        /*double*/ get TRIANGLES()
        {
            return _backingField_TRIANGLES;
        }
        /*double*/ _backingField_TRIANGLE_FAN = null;
        /*double*/ get TRIANGLE_FAN()
        {
            return _backingField_TRIANGLE_FAN;
        }
        /*double*/ _backingField_TRIANGLE_STRIP = null;
        /*double*/ get TRIANGLE_STRIP()
        {
            return _backingField_TRIANGLE_STRIP;
        }
        /*double*/ _backingField_UNPACK_ALIGNMENT = null;
        /*double*/ get UNPACK_ALIGNMENT()
        {
            return _backingField_UNPACK_ALIGNMENT;
        }
        /*double*/ _backingField_UNPACK_COLORSPACE_CONVERSION_WEBGL = null;
        /*double*/ get UNPACK_COLORSPACE_CONVERSION_WEBGL()
        {
            return _backingField_UNPACK_COLORSPACE_CONVERSION_WEBGL;
        }
        /*double*/ _backingField_UNPACK_FLIP_Y_WEBGL = null;
        /*double*/ get UNPACK_FLIP_Y_WEBGL()
        {
            return _backingField_UNPACK_FLIP_Y_WEBGL;
        }
        /*double*/ _backingField_UNPACK_PREMULTIPLY_ALPHA_WEBGL = null;
        /*double*/ get UNPACK_PREMULTIPLY_ALPHA_WEBGL()
        {
            return _backingField_UNPACK_PREMULTIPLY_ALPHA_WEBGL;
        }
        /*double*/ _backingField_UNSIGNED_BYTE = null;
        /*double*/ get UNSIGNED_BYTE()
        {
            return _backingField_UNSIGNED_BYTE;
        }
        /*double*/ _backingField_UNSIGNED_INT = null;
        /*double*/ get UNSIGNED_INT()
        {
            return _backingField_UNSIGNED_INT;
        }
        /*double*/ _backingField_UNSIGNED_SHORT = null;
        /*double*/ get UNSIGNED_SHORT()
        {
            return _backingField_UNSIGNED_SHORT;
        }
        /*double*/ _backingField_UNSIGNED_SHORT_4_4_4_4 = null;
        /*double*/ get UNSIGNED_SHORT_4_4_4_4()
        {
            return _backingField_UNSIGNED_SHORT_4_4_4_4;
        }
        /*double*/ _backingField_UNSIGNED_SHORT_5_5_5_1 = null;
        /*double*/ get UNSIGNED_SHORT_5_5_5_1()
        {
            return _backingField_UNSIGNED_SHORT_5_5_5_1;
        }
        /*double*/ _backingField_UNSIGNED_SHORT_5_6_5 = null;
        /*double*/ get UNSIGNED_SHORT_5_6_5()
        {
            return _backingField_UNSIGNED_SHORT_5_6_5;
        }
        /*double*/ _backingField_VALIDATE_STATUS = null;
        /*double*/ get VALIDATE_STATUS()
        {
            return _backingField_VALIDATE_STATUS;
        }
        /*double*/ _backingField_VENDOR = null;
        /*double*/ get VENDOR()
        {
            return _backingField_VENDOR;
        }
        /*double*/ _backingField_VERSION = null;
        /*double*/ get VERSION()
        {
            return _backingField_VERSION;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_BUFFER_BINDING()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_ENABLED = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_ENABLED()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_ENABLED;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_NORMALIZED = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_NORMALIZED()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_NORMALIZED;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_POINTER = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_POINTER()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_POINTER;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_SIZE = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_SIZE()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_SIZE;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_STRIDE = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_STRIDE()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_STRIDE;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_TYPE = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_TYPE()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_TYPE;
        }
        /*double*/ _backingField_VERTEX_SHADER = null;
        /*double*/ get VERTEX_SHADER()
        {
            return _backingField_VERTEX_SHADER;
        }
        /*double*/ _backingField_VIEWPORT = null;
        /*double*/ get VIEWPORT()
        {
            return _backingField_VIEWPORT;
        }
        /*double*/ _backingField_ZERO = null;
        /*double*/ get ZERO()
        {
            return _backingField_ZERO;
        }
        /*double*/ _backingField_READ_BUFFER = null;
        /*double*/ get READ_BUFFER()
        {
            return _backingField_READ_BUFFER;
        }
        /*double*/ _backingField_UNPACK_ROW_LENGTH = null;
        /*double*/ get UNPACK_ROW_LENGTH()
        {
            return _backingField_UNPACK_ROW_LENGTH;
        }
        /*double*/ _backingField_UNPACK_SKIP_ROWS = null;
        /*double*/ get UNPACK_SKIP_ROWS()
        {
            return _backingField_UNPACK_SKIP_ROWS;
        }
        /*double*/ _backingField_UNPACK_SKIP_PIXELS = null;
        /*double*/ get UNPACK_SKIP_PIXELS()
        {
            return _backingField_UNPACK_SKIP_PIXELS;
        }
        /*double*/ _backingField_PACK_ROW_LENGTH = null;
        /*double*/ get PACK_ROW_LENGTH()
        {
            return _backingField_PACK_ROW_LENGTH;
        }
        /*double*/ _backingField_PACK_SKIP_ROWS = null;
        /*double*/ get PACK_SKIP_ROWS()
        {
            return _backingField_PACK_SKIP_ROWS;
        }
        /*double*/ _backingField_PACK_SKIP_PIXELS = null;
        /*double*/ get PACK_SKIP_PIXELS()
        {
            return _backingField_PACK_SKIP_PIXELS;
        }
        /*double*/ _backingField_COLOR = null;
        /*double*/ get COLOR()
        {
            return _backingField_COLOR;
        }
        /*double*/ _backingField_DEPTH = null;
        /*double*/ get DEPTH()
        {
            return _backingField_DEPTH;
        }
        /*double*/ _backingField_STENCIL = null;
        /*double*/ get STENCIL()
        {
            return _backingField_STENCIL;
        }
        /*double*/ _backingField_RED = null;
        /*double*/ get RED()
        {
            return _backingField_RED;
        }
        /*double*/ _backingField_RGB8 = null;
        /*double*/ get RGB8()
        {
            return _backingField_RGB8;
        }
        /*double*/ _backingField_RGBA8 = null;
        /*double*/ get RGBA8()
        {
            return _backingField_RGBA8;
        }
        /*double*/ _backingField_RGB10_A2 = null;
        /*double*/ get RGB10_A2()
        {
            return _backingField_RGB10_A2;
        }
        /*double*/ _backingField_TEXTURE_BINDING_3D = null;
        /*double*/ get TEXTURE_BINDING_3D()
        {
            return _backingField_TEXTURE_BINDING_3D;
        }
        /*double*/ _backingField_UNPACK_SKIP_IMAGES = null;
        /*double*/ get UNPACK_SKIP_IMAGES()
        {
            return _backingField_UNPACK_SKIP_IMAGES;
        }
        /*double*/ _backingField_UNPACK_IMAGE_HEIGHT = null;
        /*double*/ get UNPACK_IMAGE_HEIGHT()
        {
            return _backingField_UNPACK_IMAGE_HEIGHT;
        }
        /*double*/ _backingField_TEXTURE_3D = null;
        /*double*/ get TEXTURE_3D()
        {
            return _backingField_TEXTURE_3D;
        }
        /*double*/ _backingField_TEXTURE_WRAP_R = null;
        /*double*/ get TEXTURE_WRAP_R()
        {
            return _backingField_TEXTURE_WRAP_R;
        }
        /*double*/ _backingField_MAX_3D_TEXTURE_SIZE = null;
        /*double*/ get MAX_3D_TEXTURE_SIZE()
        {
            return _backingField_MAX_3D_TEXTURE_SIZE;
        }
        /*double*/ _backingField_UNSIGNED_INT_2_10_10_10_REV = null;
        /*double*/ get UNSIGNED_INT_2_10_10_10_REV()
        {
            return _backingField_UNSIGNED_INT_2_10_10_10_REV;
        }
        /*double*/ _backingField_MAX_ELEMENTS_VERTICES = null;
        /*double*/ get MAX_ELEMENTS_VERTICES()
        {
            return _backingField_MAX_ELEMENTS_VERTICES;
        }
        /*double*/ _backingField_MAX_ELEMENTS_INDICES = null;
        /*double*/ get MAX_ELEMENTS_INDICES()
        {
            return _backingField_MAX_ELEMENTS_INDICES;
        }
        /*double*/ _backingField_TEXTURE_MIN_LOD = null;
        /*double*/ get TEXTURE_MIN_LOD()
        {
            return _backingField_TEXTURE_MIN_LOD;
        }
        /*double*/ _backingField_TEXTURE_MAX_LOD = null;
        /*double*/ get TEXTURE_MAX_LOD()
        {
            return _backingField_TEXTURE_MAX_LOD;
        }
        /*double*/ _backingField_TEXTURE_BASE_LEVEL = null;
        /*double*/ get TEXTURE_BASE_LEVEL()
        {
            return _backingField_TEXTURE_BASE_LEVEL;
        }
        /*double*/ _backingField_TEXTURE_MAX_LEVEL = null;
        /*double*/ get TEXTURE_MAX_LEVEL()
        {
            return _backingField_TEXTURE_MAX_LEVEL;
        }
        /*double*/ _backingField_MIN = null;
        /*double*/ get MIN()
        {
            return _backingField_MIN;
        }
        /*double*/ _backingField_MAX = null;
        /*double*/ get MAX()
        {
            return _backingField_MAX;
        }
        /*double*/ _backingField_DEPTH_COMPONENT24 = null;
        /*double*/ get DEPTH_COMPONENT24()
        {
            return _backingField_DEPTH_COMPONENT24;
        }
        /*double*/ _backingField_MAX_TEXTURE_LOD_BIAS = null;
        /*double*/ get MAX_TEXTURE_LOD_BIAS()
        {
            return _backingField_MAX_TEXTURE_LOD_BIAS;
        }
        /*double*/ _backingField_TEXTURE_COMPARE_MODE = null;
        /*double*/ get TEXTURE_COMPARE_MODE()
        {
            return _backingField_TEXTURE_COMPARE_MODE;
        }
        /*double*/ _backingField_TEXTURE_COMPARE_FUNC = null;
        /*double*/ get TEXTURE_COMPARE_FUNC()
        {
            return _backingField_TEXTURE_COMPARE_FUNC;
        }
        /*double*/ _backingField_CURRENT_QUERY = null;
        /*double*/ get CURRENT_QUERY()
        {
            return _backingField_CURRENT_QUERY;
        }
        /*double*/ _backingField_QUERY_RESULT = null;
        /*double*/ get QUERY_RESULT()
        {
            return _backingField_QUERY_RESULT;
        }
        /*double*/ _backingField_QUERY_RESULT_AVAILABLE = null;
        /*double*/ get QUERY_RESULT_AVAILABLE()
        {
            return _backingField_QUERY_RESULT_AVAILABLE;
        }
        /*double*/ _backingField_STREAM_READ = null;
        /*double*/ get STREAM_READ()
        {
            return _backingField_STREAM_READ;
        }
        /*double*/ _backingField_STREAM_COPY = null;
        /*double*/ get STREAM_COPY()
        {
            return _backingField_STREAM_COPY;
        }
        /*double*/ _backingField_STATIC_READ = null;
        /*double*/ get STATIC_READ()
        {
            return _backingField_STATIC_READ;
        }
        /*double*/ _backingField_STATIC_COPY = null;
        /*double*/ get STATIC_COPY()
        {
            return _backingField_STATIC_COPY;
        }
        /*double*/ _backingField_DYNAMIC_READ = null;
        /*double*/ get DYNAMIC_READ()
        {
            return _backingField_DYNAMIC_READ;
        }
        /*double*/ _backingField_DYNAMIC_COPY = null;
        /*double*/ get DYNAMIC_COPY()
        {
            return _backingField_DYNAMIC_COPY;
        }
        /*double*/ _backingField_MAX_DRAW_BUFFERS = null;
        /*double*/ get MAX_DRAW_BUFFERS()
        {
            return _backingField_MAX_DRAW_BUFFERS;
        }
        /*double*/ _backingField_DRAW_BUFFER0 = null;
        /*double*/ get DRAW_BUFFER0()
        {
            return _backingField_DRAW_BUFFER0;
        }
        /*double*/ _backingField_DRAW_BUFFER1 = null;
        /*double*/ get DRAW_BUFFER1()
        {
            return _backingField_DRAW_BUFFER1;
        }
        /*double*/ _backingField_DRAW_BUFFER2 = null;
        /*double*/ get DRAW_BUFFER2()
        {
            return _backingField_DRAW_BUFFER2;
        }
        /*double*/ _backingField_DRAW_BUFFER3 = null;
        /*double*/ get DRAW_BUFFER3()
        {
            return _backingField_DRAW_BUFFER3;
        }
        /*double*/ _backingField_DRAW_BUFFER4 = null;
        /*double*/ get DRAW_BUFFER4()
        {
            return _backingField_DRAW_BUFFER4;
        }
        /*double*/ _backingField_DRAW_BUFFER5 = null;
        /*double*/ get DRAW_BUFFER5()
        {
            return _backingField_DRAW_BUFFER5;
        }
        /*double*/ _backingField_DRAW_BUFFER6 = null;
        /*double*/ get DRAW_BUFFER6()
        {
            return _backingField_DRAW_BUFFER6;
        }
        /*double*/ _backingField_DRAW_BUFFER7 = null;
        /*double*/ get DRAW_BUFFER7()
        {
            return _backingField_DRAW_BUFFER7;
        }
        /*double*/ _backingField_DRAW_BUFFER8 = null;
        /*double*/ get DRAW_BUFFER8()
        {
            return _backingField_DRAW_BUFFER8;
        }
        /*double*/ _backingField_DRAW_BUFFER9 = null;
        /*double*/ get DRAW_BUFFER9()
        {
            return _backingField_DRAW_BUFFER9;
        }
        /*double*/ _backingField_DRAW_BUFFER10 = null;
        /*double*/ get DRAW_BUFFER10()
        {
            return _backingField_DRAW_BUFFER10;
        }
        /*double*/ _backingField_DRAW_BUFFER11 = null;
        /*double*/ get DRAW_BUFFER11()
        {
            return _backingField_DRAW_BUFFER11;
        }
        /*double*/ _backingField_DRAW_BUFFER12 = null;
        /*double*/ get DRAW_BUFFER12()
        {
            return _backingField_DRAW_BUFFER12;
        }
        /*double*/ _backingField_DRAW_BUFFER13 = null;
        /*double*/ get DRAW_BUFFER13()
        {
            return _backingField_DRAW_BUFFER13;
        }
        /*double*/ _backingField_DRAW_BUFFER14 = null;
        /*double*/ get DRAW_BUFFER14()
        {
            return _backingField_DRAW_BUFFER14;
        }
        /*double*/ _backingField_DRAW_BUFFER15 = null;
        /*double*/ get DRAW_BUFFER15()
        {
            return _backingField_DRAW_BUFFER15;
        }
        /*double*/ _backingField_MAX_FRAGMENT_UNIFORM_COMPONENTS = null;
        /*double*/ get MAX_FRAGMENT_UNIFORM_COMPONENTS()
        {
            return _backingField_MAX_FRAGMENT_UNIFORM_COMPONENTS;
        }
        /*double*/ _backingField_MAX_VERTEX_UNIFORM_COMPONENTS = null;
        /*double*/ get MAX_VERTEX_UNIFORM_COMPONENTS()
        {
            return _backingField_MAX_VERTEX_UNIFORM_COMPONENTS;
        }
        /*double*/ _backingField_SAMPLER_3D = null;
        /*double*/ get SAMPLER_3D()
        {
            return _backingField_SAMPLER_3D;
        }
        /*double*/ _backingField_SAMPLER_2D_SHADOW = null;
        /*double*/ get SAMPLER_2D_SHADOW()
        {
            return _backingField_SAMPLER_2D_SHADOW;
        }
        /*double*/ _backingField_FRAGMENT_SHADER_DERIVATIVE_HINT = null;
        /*double*/ get FRAGMENT_SHADER_DERIVATIVE_HINT()
        {
            return _backingField_FRAGMENT_SHADER_DERIVATIVE_HINT;
        }
        /*double*/ _backingField_PIXEL_PACK_BUFFER = null;
        /*double*/ get PIXEL_PACK_BUFFER()
        {
            return _backingField_PIXEL_PACK_BUFFER;
        }
        /*double*/ _backingField_PIXEL_UNPACK_BUFFER = null;
        /*double*/ get PIXEL_UNPACK_BUFFER()
        {
            return _backingField_PIXEL_UNPACK_BUFFER;
        }
        /*double*/ _backingField_PIXEL_PACK_BUFFER_BINDING = null;
        /*double*/ get PIXEL_PACK_BUFFER_BINDING()
        {
            return _backingField_PIXEL_PACK_BUFFER_BINDING;
        }
        /*double*/ _backingField_PIXEL_UNPACK_BUFFER_BINDING = null;
        /*double*/ get PIXEL_UNPACK_BUFFER_BINDING()
        {
            return _backingField_PIXEL_UNPACK_BUFFER_BINDING;
        }
        /*double*/ _backingField_FLOAT_MAT2x3 = null;
        /*double*/ get FLOAT_MAT2x3()
        {
            return _backingField_FLOAT_MAT2x3;
        }
        /*double*/ _backingField_FLOAT_MAT2x4 = null;
        /*double*/ get FLOAT_MAT2x4()
        {
            return _backingField_FLOAT_MAT2x4;
        }
        /*double*/ _backingField_FLOAT_MAT3x2 = null;
        /*double*/ get FLOAT_MAT3x2()
        {
            return _backingField_FLOAT_MAT3x2;
        }
        /*double*/ _backingField_FLOAT_MAT3x4 = null;
        /*double*/ get FLOAT_MAT3x4()
        {
            return _backingField_FLOAT_MAT3x4;
        }
        /*double*/ _backingField_FLOAT_MAT4x2 = null;
        /*double*/ get FLOAT_MAT4x2()
        {
            return _backingField_FLOAT_MAT4x2;
        }
        /*double*/ _backingField_FLOAT_MAT4x3 = null;
        /*double*/ get FLOAT_MAT4x3()
        {
            return _backingField_FLOAT_MAT4x3;
        }
        /*double*/ _backingField_SRGB = null;
        /*double*/ get SRGB()
        {
            return _backingField_SRGB;
        }
        /*double*/ _backingField_SRGB8 = null;
        /*double*/ get SRGB8()
        {
            return _backingField_SRGB8;
        }
        /*double*/ _backingField_SRGB8_ALPHA8 = null;
        /*double*/ get SRGB8_ALPHA8()
        {
            return _backingField_SRGB8_ALPHA8;
        }
        /*double*/ _backingField_COMPARE_REF_TO_TEXTURE = null;
        /*double*/ get COMPARE_REF_TO_TEXTURE()
        {
            return _backingField_COMPARE_REF_TO_TEXTURE;
        }
        /*double*/ _backingField_RGBA32F = null;
        /*double*/ get RGBA32F()
        {
            return _backingField_RGBA32F;
        }
        /*double*/ _backingField_RGB32F = null;
        /*double*/ get RGB32F()
        {
            return _backingField_RGB32F;
        }
        /*double*/ _backingField_RGBA16F = null;
        /*double*/ get RGBA16F()
        {
            return _backingField_RGBA16F;
        }
        /*double*/ _backingField_RGB16F = null;
        /*double*/ get RGB16F()
        {
            return _backingField_RGB16F;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_INTEGER = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_INTEGER()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_INTEGER;
        }
        /*double*/ _backingField_MAX_ARRAY_TEXTURE_LAYERS = null;
        /*double*/ get MAX_ARRAY_TEXTURE_LAYERS()
        {
            return _backingField_MAX_ARRAY_TEXTURE_LAYERS;
        }
        /*double*/ _backingField_MIN_PROGRAM_TEXEL_OFFSET = null;
        /*double*/ get MIN_PROGRAM_TEXEL_OFFSET()
        {
            return _backingField_MIN_PROGRAM_TEXEL_OFFSET;
        }
        /*double*/ _backingField_MAX_PROGRAM_TEXEL_OFFSET = null;
        /*double*/ get MAX_PROGRAM_TEXEL_OFFSET()
        {
            return _backingField_MAX_PROGRAM_TEXEL_OFFSET;
        }
        /*double*/ _backingField_MAX_VARYING_COMPONENTS = null;
        /*double*/ get MAX_VARYING_COMPONENTS()
        {
            return _backingField_MAX_VARYING_COMPONENTS;
        }
        /*double*/ _backingField_TEXTURE_2D_ARRAY = null;
        /*double*/ get TEXTURE_2D_ARRAY()
        {
            return _backingField_TEXTURE_2D_ARRAY;
        }
        /*double*/ _backingField_TEXTURE_BINDING_2D_ARRAY = null;
        /*double*/ get TEXTURE_BINDING_2D_ARRAY()
        {
            return _backingField_TEXTURE_BINDING_2D_ARRAY;
        }
        /*double*/ _backingField_R11F_G11F_B10F = null;
        /*double*/ get R11F_G11F_B10F()
        {
            return _backingField_R11F_G11F_B10F;
        }
        /*double*/ _backingField_UNSIGNED_INT_10F_11F_11F_REV = null;
        /*double*/ get UNSIGNED_INT_10F_11F_11F_REV()
        {
            return _backingField_UNSIGNED_INT_10F_11F_11F_REV;
        }
        /*double*/ _backingField_RGB9_E5 = null;
        /*double*/ get RGB9_E5()
        {
            return _backingField_RGB9_E5;
        }
        /*double*/ _backingField_UNSIGNED_INT_5_9_9_9_REV = null;
        /*double*/ get UNSIGNED_INT_5_9_9_9_REV()
        {
            return _backingField_UNSIGNED_INT_5_9_9_9_REV;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_MODE = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_MODE()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_MODE;
        }
        /*double*/ _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS = null;
        /*double*/ get MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS()
        {
            return _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_VARYINGS = null;
        /*double*/ get TRANSFORM_FEEDBACK_VARYINGS()
        {
            return _backingField_TRANSFORM_FEEDBACK_VARYINGS;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_START = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_START()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_START;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_SIZE = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_SIZE()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_SIZE;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN = null;
        /*double*/ get TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN()
        {
            return _backingField_TRANSFORM_FEEDBACK_PRIMITIVES_WRITTEN;
        }
        /*double*/ _backingField_RASTERIZER_DISCARD = null;
        /*double*/ get RASTERIZER_DISCARD()
        {
            return _backingField_RASTERIZER_DISCARD;
        }
        /*double*/ _backingField_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS = null;
        /*double*/ get MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS()
        {
            return _backingField_MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS;
        }
        /*double*/ _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS = null;
        /*double*/ get MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS()
        {
            return _backingField_MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS;
        }
        /*double*/ _backingField_INTERLEAVED_ATTRIBS = null;
        /*double*/ get INTERLEAVED_ATTRIBS()
        {
            return _backingField_INTERLEAVED_ATTRIBS;
        }
        /*double*/ _backingField_SEPARATE_ATTRIBS = null;
        /*double*/ get SEPARATE_ATTRIBS()
        {
            return _backingField_SEPARATE_ATTRIBS;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BUFFER_BINDING = null;
        /*double*/ get TRANSFORM_FEEDBACK_BUFFER_BINDING()
        {
            return _backingField_TRANSFORM_FEEDBACK_BUFFER_BINDING;
        }
        /*double*/ _backingField_RGBA32UI = null;
        /*double*/ get RGBA32UI()
        {
            return _backingField_RGBA32UI;
        }
        /*double*/ _backingField_RGB32UI = null;
        /*double*/ get RGB32UI()
        {
            return _backingField_RGB32UI;
        }
        /*double*/ _backingField_RGBA16UI = null;
        /*double*/ get RGBA16UI()
        {
            return _backingField_RGBA16UI;
        }
        /*double*/ _backingField_RGB16UI = null;
        /*double*/ get RGB16UI()
        {
            return _backingField_RGB16UI;
        }
        /*double*/ _backingField_RGBA8UI = null;
        /*double*/ get RGBA8UI()
        {
            return _backingField_RGBA8UI;
        }
        /*double*/ _backingField_RGB8UI = null;
        /*double*/ get RGB8UI()
        {
            return _backingField_RGB8UI;
        }
        /*double*/ _backingField_RGBA32I = null;
        /*double*/ get RGBA32I()
        {
            return _backingField_RGBA32I;
        }
        /*double*/ _backingField_RGB32I = null;
        /*double*/ get RGB32I()
        {
            return _backingField_RGB32I;
        }
        /*double*/ _backingField_RGBA16I = null;
        /*double*/ get RGBA16I()
        {
            return _backingField_RGBA16I;
        }
        /*double*/ _backingField_RGB16I = null;
        /*double*/ get RGB16I()
        {
            return _backingField_RGB16I;
        }
        /*double*/ _backingField_RGBA8I = null;
        /*double*/ get RGBA8I()
        {
            return _backingField_RGBA8I;
        }
        /*double*/ _backingField_RGB8I = null;
        /*double*/ get RGB8I()
        {
            return _backingField_RGB8I;
        }
        /*double*/ _backingField_RED_INTEGER = null;
        /*double*/ get RED_INTEGER()
        {
            return _backingField_RED_INTEGER;
        }
        /*double*/ _backingField_RGB_INTEGER = null;
        /*double*/ get RGB_INTEGER()
        {
            return _backingField_RGB_INTEGER;
        }
        /*double*/ _backingField_RGBA_INTEGER = null;
        /*double*/ get RGBA_INTEGER()
        {
            return _backingField_RGBA_INTEGER;
        }
        /*double*/ _backingField_SAMPLER_2D_ARRAY = null;
        /*double*/ get SAMPLER_2D_ARRAY()
        {
            return _backingField_SAMPLER_2D_ARRAY;
        }
        /*double*/ _backingField_SAMPLER_2D_ARRAY_SHADOW = null;
        /*double*/ get SAMPLER_2D_ARRAY_SHADOW()
        {
            return _backingField_SAMPLER_2D_ARRAY_SHADOW;
        }
        /*double*/ _backingField_SAMPLER_CUBE_SHADOW = null;
        /*double*/ get SAMPLER_CUBE_SHADOW()
        {
            return _backingField_SAMPLER_CUBE_SHADOW;
        }
        /*double*/ _backingField_UNSIGNED_INT_VEC2 = null;
        /*double*/ get UNSIGNED_INT_VEC2()
        {
            return _backingField_UNSIGNED_INT_VEC2;
        }
        /*double*/ _backingField_UNSIGNED_INT_VEC3 = null;
        /*double*/ get UNSIGNED_INT_VEC3()
        {
            return _backingField_UNSIGNED_INT_VEC3;
        }
        /*double*/ _backingField_UNSIGNED_INT_VEC4 = null;
        /*double*/ get UNSIGNED_INT_VEC4()
        {
            return _backingField_UNSIGNED_INT_VEC4;
        }
        /*double*/ _backingField_INT_SAMPLER_2D = null;
        /*double*/ get INT_SAMPLER_2D()
        {
            return _backingField_INT_SAMPLER_2D;
        }
        /*double*/ _backingField_INT_SAMPLER_3D = null;
        /*double*/ get INT_SAMPLER_3D()
        {
            return _backingField_INT_SAMPLER_3D;
        }
        /*double*/ _backingField_INT_SAMPLER_CUBE = null;
        /*double*/ get INT_SAMPLER_CUBE()
        {
            return _backingField_INT_SAMPLER_CUBE;
        }
        /*double*/ _backingField_INT_SAMPLER_2D_ARRAY = null;
        /*double*/ get INT_SAMPLER_2D_ARRAY()
        {
            return _backingField_INT_SAMPLER_2D_ARRAY;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_2D = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_2D()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_2D;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_3D = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_3D()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_3D;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_CUBE = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_CUBE()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_CUBE;
        }
        /*double*/ _backingField_UNSIGNED_INT_SAMPLER_2D_ARRAY = null;
        /*double*/ get UNSIGNED_INT_SAMPLER_2D_ARRAY()
        {
            return _backingField_UNSIGNED_INT_SAMPLER_2D_ARRAY;
        }
        /*double*/ _backingField_DEPTH_COMPONENT32F = null;
        /*double*/ get DEPTH_COMPONENT32F()
        {
            return _backingField_DEPTH_COMPONENT32F;
        }
        /*double*/ _backingField_DEPTH32F_STENCIL8 = null;
        /*double*/ get DEPTH32F_STENCIL8()
        {
            return _backingField_DEPTH32F_STENCIL8;
        }
        /*double*/ _backingField_FLOAT_32_UNSIGNED_INT_24_8_REV = null;
        /*double*/ get FLOAT_32_UNSIGNED_INT_24_8_REV()
        {
            return _backingField_FLOAT_32_UNSIGNED_INT_24_8_REV;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_COMPONENT_TYPE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_RED_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_RED_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_RED_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_GREEN_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_GREEN_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_BLUE_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_BLUE_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_ALPHA_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_DEPTH_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_STENCIL_SIZE;
        }
        /*double*/ _backingField_FRAMEBUFFER_DEFAULT = null;
        /*double*/ get FRAMEBUFFER_DEFAULT()
        {
            return _backingField_FRAMEBUFFER_DEFAULT;
        }
        /*double*/ _backingField_UNSIGNED_INT_24_8 = null;
        /*double*/ get UNSIGNED_INT_24_8()
        {
            return _backingField_UNSIGNED_INT_24_8;
        }
        /*double*/ _backingField_DEPTH24_STENCIL8 = null;
        /*double*/ get DEPTH24_STENCIL8()
        {
            return _backingField_DEPTH24_STENCIL8;
        }
        /*double*/ _backingField_UNSIGNED_NORMALIZED = null;
        /*double*/ get UNSIGNED_NORMALIZED()
        {
            return _backingField_UNSIGNED_NORMALIZED;
        }
        /*double*/ _backingField_DRAW_FRAMEBUFFER_BINDING = null;
        /*double*/ get DRAW_FRAMEBUFFER_BINDING()
        {
            return _backingField_DRAW_FRAMEBUFFER_BINDING;
        }
        /*double*/ _backingField_READ_FRAMEBUFFER = null;
        /*double*/ get READ_FRAMEBUFFER()
        {
            return _backingField_READ_FRAMEBUFFER;
        }
        /*double*/ _backingField_DRAW_FRAMEBUFFER = null;
        /*double*/ get DRAW_FRAMEBUFFER()
        {
            return _backingField_DRAW_FRAMEBUFFER;
        }
        /*double*/ _backingField_READ_FRAMEBUFFER_BINDING = null;
        /*double*/ get READ_FRAMEBUFFER_BINDING()
        {
            return _backingField_READ_FRAMEBUFFER_BINDING;
        }
        /*double*/ _backingField_RENDERBUFFER_SAMPLES = null;
        /*double*/ get RENDERBUFFER_SAMPLES()
        {
            return _backingField_RENDERBUFFER_SAMPLES;
        }
        /*double*/ _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER = null;
        /*double*/ get FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER()
        {
            return _backingField_FRAMEBUFFER_ATTACHMENT_TEXTURE_LAYER;
        }
        /*double*/ _backingField_MAX_COLOR_ATTACHMENTS = null;
        /*double*/ get MAX_COLOR_ATTACHMENTS()
        {
            return _backingField_MAX_COLOR_ATTACHMENTS;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT1 = null;
        /*double*/ get COLOR_ATTACHMENT1()
        {
            return _backingField_COLOR_ATTACHMENT1;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT2 = null;
        /*double*/ get COLOR_ATTACHMENT2()
        {
            return _backingField_COLOR_ATTACHMENT2;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT3 = null;
        /*double*/ get COLOR_ATTACHMENT3()
        {
            return _backingField_COLOR_ATTACHMENT3;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT4 = null;
        /*double*/ get COLOR_ATTACHMENT4()
        {
            return _backingField_COLOR_ATTACHMENT4;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT5 = null;
        /*double*/ get COLOR_ATTACHMENT5()
        {
            return _backingField_COLOR_ATTACHMENT5;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT6 = null;
        /*double*/ get COLOR_ATTACHMENT6()
        {
            return _backingField_COLOR_ATTACHMENT6;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT7 = null;
        /*double*/ get COLOR_ATTACHMENT7()
        {
            return _backingField_COLOR_ATTACHMENT7;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT8 = null;
        /*double*/ get COLOR_ATTACHMENT8()
        {
            return _backingField_COLOR_ATTACHMENT8;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT9 = null;
        /*double*/ get COLOR_ATTACHMENT9()
        {
            return _backingField_COLOR_ATTACHMENT9;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT10 = null;
        /*double*/ get COLOR_ATTACHMENT10()
        {
            return _backingField_COLOR_ATTACHMENT10;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT11 = null;
        /*double*/ get COLOR_ATTACHMENT11()
        {
            return _backingField_COLOR_ATTACHMENT11;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT12 = null;
        /*double*/ get COLOR_ATTACHMENT12()
        {
            return _backingField_COLOR_ATTACHMENT12;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT13 = null;
        /*double*/ get COLOR_ATTACHMENT13()
        {
            return _backingField_COLOR_ATTACHMENT13;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT14 = null;
        /*double*/ get COLOR_ATTACHMENT14()
        {
            return _backingField_COLOR_ATTACHMENT14;
        }
        /*double*/ _backingField_COLOR_ATTACHMENT15 = null;
        /*double*/ get COLOR_ATTACHMENT15()
        {
            return _backingField_COLOR_ATTACHMENT15;
        }
        /*double*/ _backingField_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = null;
        /*double*/ get FRAMEBUFFER_INCOMPLETE_MULTISAMPLE()
        {
            return _backingField_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE;
        }
        /*double*/ _backingField_MAX_SAMPLES = null;
        /*double*/ get MAX_SAMPLES()
        {
            return _backingField_MAX_SAMPLES;
        }
        /*double*/ _backingField_HALF_FLOAT = null;
        /*double*/ get HALF_FLOAT()
        {
            return _backingField_HALF_FLOAT;
        }
        /*double*/ _backingField_RG = null;
        /*double*/ get RG()
        {
            return _backingField_RG;
        }
        /*double*/ _backingField_RG_INTEGER = null;
        /*double*/ get RG_INTEGER()
        {
            return _backingField_RG_INTEGER;
        }
        /*double*/ _backingField_R8 = null;
        /*double*/ get R8()
        {
            return _backingField_R8;
        }
        /*double*/ _backingField_RG8 = null;
        /*double*/ get RG8()
        {
            return _backingField_RG8;
        }
        /*double*/ _backingField_R16F = null;
        /*double*/ get R16F()
        {
            return _backingField_R16F;
        }
        /*double*/ _backingField_R32F = null;
        /*double*/ get R32F()
        {
            return _backingField_R32F;
        }
        /*double*/ _backingField_RG16F = null;
        /*double*/ get RG16F()
        {
            return _backingField_RG16F;
        }
        /*double*/ _backingField_RG32F = null;
        /*double*/ get RG32F()
        {
            return _backingField_RG32F;
        }
        /*double*/ _backingField_R8I = null;
        /*double*/ get R8I()
        {
            return _backingField_R8I;
        }
        /*double*/ _backingField_R8UI = null;
        /*double*/ get R8UI()
        {
            return _backingField_R8UI;
        }
        /*double*/ _backingField_R16I = null;
        /*double*/ get R16I()
        {
            return _backingField_R16I;
        }
        /*double*/ _backingField_R16UI = null;
        /*double*/ get R16UI()
        {
            return _backingField_R16UI;
        }
        /*double*/ _backingField_R32I = null;
        /*double*/ get R32I()
        {
            return _backingField_R32I;
        }
        /*double*/ _backingField_R32UI = null;
        /*double*/ get R32UI()
        {
            return _backingField_R32UI;
        }
        /*double*/ _backingField_RG8I = null;
        /*double*/ get RG8I()
        {
            return _backingField_RG8I;
        }
        /*double*/ _backingField_RG8UI = null;
        /*double*/ get RG8UI()
        {
            return _backingField_RG8UI;
        }
        /*double*/ _backingField_RG16I = null;
        /*double*/ get RG16I()
        {
            return _backingField_RG16I;
        }
        /*double*/ _backingField_RG16UI = null;
        /*double*/ get RG16UI()
        {
            return _backingField_RG16UI;
        }
        /*double*/ _backingField_RG32I = null;
        /*double*/ get RG32I()
        {
            return _backingField_RG32I;
        }
        /*double*/ _backingField_RG32UI = null;
        /*double*/ get RG32UI()
        {
            return _backingField_RG32UI;
        }
        /*double*/ _backingField_VERTEX_ARRAY_BINDING = null;
        /*double*/ get VERTEX_ARRAY_BINDING()
        {
            return _backingField_VERTEX_ARRAY_BINDING;
        }
        /*double*/ _backingField_R8_SNORM = null;
        /*double*/ get R8_SNORM()
        {
            return _backingField_R8_SNORM;
        }
        /*double*/ _backingField_RG8_SNORM = null;
        /*double*/ get RG8_SNORM()
        {
            return _backingField_RG8_SNORM;
        }
        /*double*/ _backingField_RGB8_SNORM = null;
        /*double*/ get RGB8_SNORM()
        {
            return _backingField_RGB8_SNORM;
        }
        /*double*/ _backingField_RGBA8_SNORM = null;
        /*double*/ get RGBA8_SNORM()
        {
            return _backingField_RGBA8_SNORM;
        }
        /*double*/ _backingField_SIGNED_NORMALIZED = null;
        /*double*/ get SIGNED_NORMALIZED()
        {
            return _backingField_SIGNED_NORMALIZED;
        }
        /*double*/ _backingField_COPY_READ_BUFFER = null;
        /*double*/ get COPY_READ_BUFFER()
        {
            return _backingField_COPY_READ_BUFFER;
        }
        /*double*/ _backingField_COPY_WRITE_BUFFER = null;
        /*double*/ get COPY_WRITE_BUFFER()
        {
            return _backingField_COPY_WRITE_BUFFER;
        }
        /*double*/ _backingField_COPY_READ_BUFFER_BINDING = null;
        /*double*/ get COPY_READ_BUFFER_BINDING()
        {
            return _backingField_COPY_READ_BUFFER_BINDING;
        }
        /*double*/ _backingField_COPY_WRITE_BUFFER_BINDING = null;
        /*double*/ get COPY_WRITE_BUFFER_BINDING()
        {
            return _backingField_COPY_WRITE_BUFFER_BINDING;
        }
        /*double*/ _backingField_UNIFORM_BUFFER = null;
        /*double*/ get UNIFORM_BUFFER()
        {
            return _backingField_UNIFORM_BUFFER;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_BINDING = null;
        /*double*/ get UNIFORM_BUFFER_BINDING()
        {
            return _backingField_UNIFORM_BUFFER_BINDING;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_START = null;
        /*double*/ get UNIFORM_BUFFER_START()
        {
            return _backingField_UNIFORM_BUFFER_START;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_SIZE = null;
        /*double*/ get UNIFORM_BUFFER_SIZE()
        {
            return _backingField_UNIFORM_BUFFER_SIZE;
        }
        /*double*/ _backingField_MAX_VERTEX_UNIFORM_BLOCKS = null;
        /*double*/ get MAX_VERTEX_UNIFORM_BLOCKS()
        {
            return _backingField_MAX_VERTEX_UNIFORM_BLOCKS;
        }
        /*double*/ _backingField_MAX_FRAGMENT_UNIFORM_BLOCKS = null;
        /*double*/ get MAX_FRAGMENT_UNIFORM_BLOCKS()
        {
            return _backingField_MAX_FRAGMENT_UNIFORM_BLOCKS;
        }
        /*double*/ _backingField_MAX_COMBINED_UNIFORM_BLOCKS = null;
        /*double*/ get MAX_COMBINED_UNIFORM_BLOCKS()
        {
            return _backingField_MAX_COMBINED_UNIFORM_BLOCKS;
        }
        /*double*/ _backingField_MAX_UNIFORM_BUFFER_BINDINGS = null;
        /*double*/ get MAX_UNIFORM_BUFFER_BINDINGS()
        {
            return _backingField_MAX_UNIFORM_BUFFER_BINDINGS;
        }
        /*double*/ _backingField_MAX_UNIFORM_BLOCK_SIZE = null;
        /*double*/ get MAX_UNIFORM_BLOCK_SIZE()
        {
            return _backingField_MAX_UNIFORM_BLOCK_SIZE;
        }
        /*double*/ _backingField_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = null;
        /*double*/ get MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS()
        {
            return _backingField_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS;
        }
        /*double*/ _backingField_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = null;
        /*double*/ get MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS()
        {
            return _backingField_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS;
        }
        /*double*/ _backingField_UNIFORM_BUFFER_OFFSET_ALIGNMENT = null;
        /*double*/ get UNIFORM_BUFFER_OFFSET_ALIGNMENT()
        {
            return _backingField_UNIFORM_BUFFER_OFFSET_ALIGNMENT;
        }
        /*double*/ _backingField_ACTIVE_UNIFORM_BLOCKS = null;
        /*double*/ get ACTIVE_UNIFORM_BLOCKS()
        {
            return _backingField_ACTIVE_UNIFORM_BLOCKS;
        }
        /*double*/ _backingField_UNIFORM_TYPE = null;
        /*double*/ get UNIFORM_TYPE()
        {
            return _backingField_UNIFORM_TYPE;
        }
        /*double*/ _backingField_UNIFORM_SIZE = null;
        /*double*/ get UNIFORM_SIZE()
        {
            return _backingField_UNIFORM_SIZE;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_INDEX = null;
        /*double*/ get UNIFORM_BLOCK_INDEX()
        {
            return _backingField_UNIFORM_BLOCK_INDEX;
        }
        /*double*/ _backingField_UNIFORM_OFFSET = null;
        /*double*/ get UNIFORM_OFFSET()
        {
            return _backingField_UNIFORM_OFFSET;
        }
        /*double*/ _backingField_UNIFORM_ARRAY_STRIDE = null;
        /*double*/ get UNIFORM_ARRAY_STRIDE()
        {
            return _backingField_UNIFORM_ARRAY_STRIDE;
        }
        /*double*/ _backingField_UNIFORM_MATRIX_STRIDE = null;
        /*double*/ get UNIFORM_MATRIX_STRIDE()
        {
            return _backingField_UNIFORM_MATRIX_STRIDE;
        }
        /*double*/ _backingField_UNIFORM_IS_ROW_MAJOR = null;
        /*double*/ get UNIFORM_IS_ROW_MAJOR()
        {
            return _backingField_UNIFORM_IS_ROW_MAJOR;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_BINDING = null;
        /*double*/ get UNIFORM_BLOCK_BINDING()
        {
            return _backingField_UNIFORM_BLOCK_BINDING;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_DATA_SIZE = null;
        /*double*/ get UNIFORM_BLOCK_DATA_SIZE()
        {
            return _backingField_UNIFORM_BLOCK_DATA_SIZE;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORMS = null;
        /*double*/ get UNIFORM_BLOCK_ACTIVE_UNIFORMS()
        {
            return _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORMS;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES = null;
        /*double*/ get UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES()
        {
            return _backingField_UNIFORM_BLOCK_ACTIVE_UNIFORM_INDICES;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER = null;
        /*double*/ get UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER()
        {
            return _backingField_UNIFORM_BLOCK_REFERENCED_BY_VERTEX_SHADER;
        }
        /*double*/ _backingField_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER = null;
        /*double*/ get UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER()
        {
            return _backingField_UNIFORM_BLOCK_REFERENCED_BY_FRAGMENT_SHADER;
        }
        /*double*/ _backingField_INVALID_INDEX = null;
        /*double*/ get INVALID_INDEX()
        {
            return _backingField_INVALID_INDEX;
        }
        /*double*/ _backingField_MAX_VERTEX_OUTPUT_COMPONENTS = null;
        /*double*/ get MAX_VERTEX_OUTPUT_COMPONENTS()
        {
            return _backingField_MAX_VERTEX_OUTPUT_COMPONENTS;
        }
        /*double*/ _backingField_MAX_FRAGMENT_INPUT_COMPONENTS = null;
        /*double*/ get MAX_FRAGMENT_INPUT_COMPONENTS()
        {
            return _backingField_MAX_FRAGMENT_INPUT_COMPONENTS;
        }
        /*double*/ _backingField_MAX_SERVER_WAIT_TIMEOUT = null;
        /*double*/ get MAX_SERVER_WAIT_TIMEOUT()
        {
            return _backingField_MAX_SERVER_WAIT_TIMEOUT;
        }
        /*double*/ _backingField_OBJECT_TYPE = null;
        /*double*/ get OBJECT_TYPE()
        {
            return _backingField_OBJECT_TYPE;
        }
        /*double*/ _backingField_SYNC_CONDITION = null;
        /*double*/ get SYNC_CONDITION()
        {
            return _backingField_SYNC_CONDITION;
        }
        /*double*/ _backingField_SYNC_STATUS = null;
        /*double*/ get SYNC_STATUS()
        {
            return _backingField_SYNC_STATUS;
        }
        /*double*/ _backingField_SYNC_FLAGS = null;
        /*double*/ get SYNC_FLAGS()
        {
            return _backingField_SYNC_FLAGS;
        }
        /*double*/ _backingField_SYNC_FENCE = null;
        /*double*/ get SYNC_FENCE()
        {
            return _backingField_SYNC_FENCE;
        }
        /*double*/ _backingField_SYNC_GPU_COMMANDS_COMPLETE = null;
        /*double*/ get SYNC_GPU_COMMANDS_COMPLETE()
        {
            return _backingField_SYNC_GPU_COMMANDS_COMPLETE;
        }
        /*double*/ _backingField_UNSIGNALED = null;
        /*double*/ get UNSIGNALED()
        {
            return _backingField_UNSIGNALED;
        }
        /*double*/ _backingField_SIGNALED = null;
        /*double*/ get SIGNALED()
        {
            return _backingField_SIGNALED;
        }
        /*double*/ _backingField_ALREADY_SIGNALED = null;
        /*double*/ get ALREADY_SIGNALED()
        {
            return _backingField_ALREADY_SIGNALED;
        }
        /*double*/ _backingField_TIMEOUT_EXPIRED = null;
        /*double*/ get TIMEOUT_EXPIRED()
        {
            return _backingField_TIMEOUT_EXPIRED;
        }
        /*double*/ _backingField_CONDITION_SATISFIED = null;
        /*double*/ get CONDITION_SATISFIED()
        {
            return _backingField_CONDITION_SATISFIED;
        }
        /*double*/ _backingField_WAIT_FAILED = null;
        /*double*/ get WAIT_FAILED()
        {
            return _backingField_WAIT_FAILED;
        }
        /*double*/ _backingField_SYNC_FLUSH_COMMANDS_BIT = null;
        /*double*/ get SYNC_FLUSH_COMMANDS_BIT()
        {
            return _backingField_SYNC_FLUSH_COMMANDS_BIT;
        }
        /*double*/ _backingField_VERTEX_ATTRIB_ARRAY_DIVISOR = null;
        /*double*/ get VERTEX_ATTRIB_ARRAY_DIVISOR()
        {
            return _backingField_VERTEX_ATTRIB_ARRAY_DIVISOR;
        }
        /*double*/ _backingField_ANY_SAMPLES_PASSED = null;
        /*double*/ get ANY_SAMPLES_PASSED()
        {
            return _backingField_ANY_SAMPLES_PASSED;
        }
        /*double*/ _backingField_ANY_SAMPLES_PASSED_CONSERVATIVE = null;
        /*double*/ get ANY_SAMPLES_PASSED_CONSERVATIVE()
        {
            return _backingField_ANY_SAMPLES_PASSED_CONSERVATIVE;
        }
        /*double*/ _backingField_SAMPLER_BINDING = null;
        /*double*/ get SAMPLER_BINDING()
        {
            return _backingField_SAMPLER_BINDING;
        }
        /*double*/ _backingField_RGB10_A2UI = null;
        /*double*/ get RGB10_A2UI()
        {
            return _backingField_RGB10_A2UI;
        }
        /*double*/ _backingField_INT_2_10_10_10_REV = null;
        /*double*/ get INT_2_10_10_10_REV()
        {
            return _backingField_INT_2_10_10_10_REV;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK = null;
        /*double*/ get TRANSFORM_FEEDBACK()
        {
            return _backingField_TRANSFORM_FEEDBACK;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_PAUSED = null;
        /*double*/ get TRANSFORM_FEEDBACK_PAUSED()
        {
            return _backingField_TRANSFORM_FEEDBACK_PAUSED;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_ACTIVE = null;
        /*double*/ get TRANSFORM_FEEDBACK_ACTIVE()
        {
            return _backingField_TRANSFORM_FEEDBACK_ACTIVE;
        }
        /*double*/ _backingField_TRANSFORM_FEEDBACK_BINDING = null;
        /*double*/ get TRANSFORM_FEEDBACK_BINDING()
        {
            return _backingField_TRANSFORM_FEEDBACK_BINDING;
        }
        /*double*/ _backingField_TEXTURE_IMMUTABLE_FORMAT = null;
        /*double*/ get TEXTURE_IMMUTABLE_FORMAT()
        {
            return _backingField_TEXTURE_IMMUTABLE_FORMAT;
        }
        /*double*/ _backingField_MAX_ELEMENT_INDEX = null;
        /*double*/ get MAX_ELEMENT_INDEX()
        {
            return _backingField_MAX_ELEMENT_INDEX;
        }
        /*double*/ _backingField_TEXTURE_IMMUTABLE_LEVELS = null;
        /*double*/ get TEXTURE_IMMUTABLE_LEVELS()
        {
            return _backingField_TEXTURE_IMMUTABLE_LEVELS;
        }
        /*double*/ _backingField_TIMEOUT_IGNORED = null;
        /*double*/ get TIMEOUT_IGNORED()
        {
            return _backingField_TIMEOUT_IGNORED;
        }
        /*double*/ _backingField_MAX_CLIENT_WAIT_TIMEOUT_WEBGL = null;
        /*double*/ get MAX_CLIENT_WAIT_TIMEOUT_WEBGL()
        {
            return _backingField_MAX_CLIENT_WAIT_TIMEOUT_WEBGL;
        }
        constructor()
        {
            super();
        }
    }
    class H5_Core_WebGLQueryTypeConfig extends H5_Core_IObject(object)
    {
        /*webgl2.WebGLQuery*/ _backingField_prototype = null;
        /*webgl2.WebGLQuery*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLQuery*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
        constructor()
        {
            super();
        }
    }
    class H5_Core_WebGLSamplerTypeConfig extends H5_Core_IObject(object)
    {
        /*webgl2.WebGLSampler*/ _backingField_prototype = null;
        /*webgl2.WebGLSampler*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLSampler*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
        constructor()
        {
            super();
        }
    }
    class H5_Core_WebGLSyncTypeConfig extends H5_Core_IObject(object)
    {
        /*webgl2.WebGLSync*/ _backingField_prototype = null;
        /*webgl2.WebGLSync*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLSync*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
        constructor()
        {
            super();
        }
    }
    class H5_Core_WebGLTransformFeedbackTypeConfig extends H5_Core_IObject(object)
    {
        /*webgl2.WebGLTransformFeedback*/ _backingField_prototype = null;
        /*webgl2.WebGLTransformFeedback*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLTransformFeedback*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
        constructor()
        {
            super();
        }
    }
    class H5_Core_WebGLVertexArrayObjectTypeConfig extends H5_Core_IObject(object)
    {
        /*webgl2.WebGLVertexArrayObject*/ _backingField_prototype = null;
        /*webgl2.WebGLVertexArrayObject*/ get prototype()
        {
            return _backingField_prototype;
        }
        /*webgl2.WebGLVertexArrayObject*/ set prototype(value)
        {
            _backingField_prototype = value;
        }
        constructor()
        {
            super();
        }
    }
    class H5_Core_Literals extends object
    {
        constructor()
        {
            super();
        }
        /*webgl2.Literals.Types.webgl2*/ webgl2 = null;
        /*webgl2.Literals.Types.experimental_webgl2*/ experimental_webgl2 = null;
        class H5_Core_Types extends object
        {
            constructor()
            {
                super();
            }
            class H5_Core_webgl2 extends H5_Core_LiteralType(string)
            {
                constructor()
                {
                    super();
                }
            }
            class H5_Core_experimental_webgl2 extends H5_Core_LiteralType(string)
            {
                constructor()
                {
                    super();
                }
            }
        }
        class H5_Core_Options extends object
        {
            constructor()
            {
                super();
            }
            class H5_Core_contextId extends H5_Core_LiteralType(string)
            {
                /*webgl2.Literals.Types.webgl2*/ webgl2 = null;
                /*webgl2.Literals.Types.experimental_webgl2*/ experimental_webgl2 = null;
                constructor()
                {
                    super();
                }
webgl2LiteralsOptionscontextIdwebgl2LiteralsTypeswebgl2webgl2LiteralsOptionscontextIdwebgl2LiteralsTypesexperimental_webgl2            }
        }
    }
}

class BlazorJs_Sample_Pages_Breakout extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*HTMLElement*/ world = null;
    /*CanvasRenderingContext2D*/ context = null;
    /*bool*/ disposed = null;
    /*int*/ x = null;
    /*int*/ y = null;
    /*void*/ Render(/*double*/ time)
    {
        context.beginPath();
        context.clearRect(x - 1, y - 1, 10, 10);
        context.rect(x, x, 10, 10);
        context.fillStyle  = "red";
        context.fill();
        context.closePath();
        x++;
        y++;
        if (disposed)
        {
            window.requestAnimationFrame(Render);
        }
    }
    /*Task*/ OnAfterRenderAsync(/*bool*/ firstRender)
    {
        if (firstRender)
        {
            window.requestAnimationFrame(Render);
            context = HTMLCanvasElementworld.getContext("2d").As(CanvasRenderingContext2D);
        }
        return super.OnAfterRenderAsync(firstRender);
    }
    /*void*/ Dispose()
    {
        disposed = true;
        super.Dispose();
    }
}

class BlazorJs_Sample_Pages_Counter extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*object*/ a = null;
    /*int*/ currentCount = 0;
    /*dynamic*/ ab = null;
    /*void*/ IncrementCount()
    {
        //ab = currentCount;
            //ab.ToString();
            currentCount += 1;
    }
    /*void*/ DecrementCount()
    {
        currentCount -= 1;
    }
}

class BlazorJs_Sample_Pages_SudokuCell extends object
{
    constructor()
    {
        super();
    }
    /*int?*/ _backingField_Entry = null;
    /*int?*/ get Entry()
    {
        return _backingField_Entry;
    }
    /*int?*/ set Entry(value)
    {
        _backingField_Entry = value;
    }
    /*bool*/ _backingField_IsFixed = null;
    /*bool*/ get IsFixed()
    {
        return _backingField_IsFixed;
    }
    /*bool*/ set IsFixed(value)
    {
        _backingField_IsFixed = value;
    }
    /*bool*/ _backingField_HasError = null;
    /*bool*/ get HasError()
    {
        return _backingField_HasError;
    }
    /*bool*/ set HasError(value)
    {
        _backingField_HasError = value;
    }
}
class BlazorJs_Sample_Pages_Sudoku extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*int*/ size = null;
    /*SudokuCell[,]*/ boards = null;
    /*DateTime*/ startTime = null;
    /*Random*/ random = new Random();
    /*bool*/ valid = null;
    /*DateTime*/ start = null;
    /*int*/ score = null;
    /*CancellationTokenSource*/ cts = new CancellationTokenSource();
    /*bool*/ ValidateBoard()
    {
        /*bool*/ let valid = true;
        for(/*int*/ let y = 0; y < size; y++)
        {
            /*List<int>*/ let seen = new List_$1(int, size);
            for(/*int*/ let x = 0; x < size; x++)
            {
                /*var*/ let cell = boardsyx;
                if (cell.Entry  != null)
                {
                    if (cell.Entry  == 0 || cell.Entry  > size || seen.Contains(cell.Entry.Value))
                    {
                        boardsyx.HasError  = true;
                        valid = false;
                    }
                    else 
                    {
                        boardsyx.HasError  = false;
                    }
                    seen.Add(cell.Entry.Value);
                }
            });
        });
        for(/*int*/ let x = 0; x < size; x++)
        {
            /*List<int>*/ let seen = new List_$1(int, size);
            for(/*int*/ let y = 0; y < size; y++)
            {
                /*var*/ let cell = boardsyx;
                if (cell.Entry  != null)
                {
                    if (cell.Entry  == 0 || cell.Entry  > size || seen.Contains(cell.Entry.Value))
                    {
                        boardsyx.HasError  = true;
                        valid = false;
                    }
                    else 
                    {
                        boardsyx.HasError  = false;
                    }
                    seen.Add(cell.Entry.Value);
                }
            });
        });
        return valid;
    }
    /*void*/ CreateBoard()
    {
        if (size == 0)
        return ;
        boards = [  ];
        for(/*int*/ let y = 0; y < size; y++)
        {
            for(/*int*/ let x = 0; x < size; x++)
            {
                boardsyx = new SudokuCell();
            });
        });
        for(/*int*/ let i = 0; i < size * size / 8; i++)
        {
            /*int*/ let x = random.Next(1, size);
            /*int*/ let y = random.Next(1, size);
            while(boardsyx.Entry  != null)
            {
                x = random.Next(1, size);
                y = random.Next(1, size);
            }
            boardsyx.Entry  = random.Next(1, size);
            boardsyx.IsFixed  = true;
            while(ValidateBoard())
            {
                boardsyx.Entry  = random.Next(1, size);
            }
        });
        start = DateTime.Now;
        cts.Cancel();
    }
    /*void*/ Validate(/*int*/ x, /*int*/ y)
    {
        valid = ValidateBoard();
        boardsyx.HasError  = valid;
    }
    /*void*/ Dispose()
    {
        cts.Cancel();
        super.Dispose();
    }
}

class BlazorJs_Sample_Pages_Weather extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*WeatherForecast[]*/ forecasts = null;
    /*Task*/ async OnInitializedAsync()
    {
        await Task.Delay(500);
        /*var*/ let startDate = DateTime.Now;
        /*var*/ let summaries = "Freezing""Bracing""Chilly""Cool""Mild""Warm""Balmy""Hot""Sweltering""Scorching";
        forecasts = Enumerable.Range(1, 5).Select(function(/**/ index)
        {
new WeatherForecast()Date = startDate.AddDays(index)TemperatureC = new Random().Next(20, 55)Summary = summariesnew Random().Next(summaries.Length)        }).ToArray();
    }
    class BlazorJs_Sample_Pages_WeatherForecast extends object
    {
        constructor()
        {
            super();
        }
        /*DateTime*/ _backingField_Date = null;
        /*DateTime*/ get Date()
        {
            return _backingField_Date;
        }
        /*DateTime*/ set Date(value)
        {
            _backingField_Date = value;
        }
        /*int*/ _backingField_TemperatureC = null;
        /*int*/ get TemperatureC()
        {
            return _backingField_TemperatureC;
        }
        /*int*/ set TemperatureC(value)
        {
            _backingField_TemperatureC = value;
        }
        /*string*/ _backingField_Summary = null;
        /*string*/ get Summary()
        {
            return _backingField_Summary;
        }
        /*string*/ set Summary(value)
        {
            _backingField_Summary = value;
        }
        /*int*/ get TemperatureF()
        {
            return 32 + TemperatureC / 0.5556;
        }
    }
}

class BlazorJs_Sample_Component1 extends BlazorJs_Sample_Interface1(Microsoft_AspNetCore_Components_ComponentBase)
{
    constructor()
    {
        super();
    }
    /*void*/ RegisterRoute()
    {
        RouteTableFactory.Register(Component1, "/C1", { layout : MainLayout });
        RouteTableFactory.Register(Component1, "/C1/{Property1}", { layout : MainLayout, routeParameterSetter : function(/**/ component, /**/ name, /**/ value)
        {
            switch(name.ToLower())
            {
                case "property1":
                {
                    component.Property1  = value;
                    break;
                }
            }
        } });
    }
    /*void*/ InjectServices(/*IServiceProvider*/ provider)
    {
        MHttp = provider.GetRequiredService(System.Net.Http.HttpClient);
        Http = provider.GetRequiredService(System.Net.Http.HttpClient);
    }
    /*int*/ prope = null;
    /*RenderFragment*/ V1()
    {
        return function(/**/ __frame0, /**/ __key0)
        {
            __frame0.Element("span", null, function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Content(prope, { key : __key1, sequenceNumber : 1332912352 });
            }, { sequenceNumber : 1332912353 });
        };
    }
    /*RenderFragment*/ V2()
    {
        return function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Element("span", null, function(/**/ __frame2, /**/ __key2)
            {
                __frame2.Content(prope, { key : __key2, sequenceNumber : 1332912354 });
            }, { key : __key1, sequenceNumber : 1332912355 });
        };
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Markup("<div>ShoudUseMarkup</div>", { sequenceNumber : 1332912284 });
        __frame0.Element("a", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("href", "C2");
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Markup("<span>Goto \r\n        \"\r\n        C2</span>", { key : __key1, sequenceNumber : 1332912285 });
            __frame1.Content(field2, { key : __key1, sequenceNumber : 1332912286 });
            __frame1.Text(" DEF", { key : __key1, sequenceNumber : 1332912287 });
        }, { sequenceNumber : 1332912288 });
        __frame0.Element("div", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("@attributes", .As(Dictionary<string, object>));
        }, null, { sequenceNumber : 1332912289 });
        __frame0.Component(GenericComponent1<int, string>, function(/**/ __component0)
        {
            __component0.Set("@attributes", .As(Dictionary<string, object>));
        }, { sequenceNumber : 1332912290 });
        __frame0.Component(CascadingValue<Component1>, function(/**/ __component0)
        {
            __component0.Name  = "C1";
            __component0.Value  = ;
            __component0.IsFixed  = true;
            __component0.ChildContent  = function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Component(Component2, function(/**/ __component1)
                {
                    __component1.Property1  = "1";
                    __component1.Property2  = 1;
                    __component1.ChildContent  = function(/**/ a)
                    {
                        return function(/**/ __frame2, /**/ __key2)
                        {
                            __frame2.Text("Component2.1 ", { key : __key2, sequenceNumber : 1332912291 });
                            __frame2.Content(a, { key : __key2, sequenceNumber : 1332912292 });
                            __frame2.Text("        ", { key : __key2, sequenceNumber : 1332912293 });
                            __frame2.Component(Component2, function(/**/ __component2)
                            {
                                __component2.Property1  = "1";
                                __component2.Property2  = 1;
                                __component2.ChildContent  = function(/**/ aa)
                                {
                                    return function(/**/ __frame3, /**/ __key3)
                                    {
                                        __frame3.Text("Component2.Component2 ", { key : __key3, sequenceNumber : 1332912294 });
                                        __frame3.Content(a, { key : __key3, sequenceNumber : 1332912295 });
                                        __frame3.Text(" ", { key : __key3, sequenceNumber : 1332912296 });
                                        __frame3.Content(aa, { key : __key3, sequenceNumber : 1332912297 });
                                        __frame3.Text(" DEF\r\n        ", { key : __key3, sequenceNumber : 1332912298 });
                                    };
                                };
                            }, { key : __key2, sequenceNumber : 1332912299 });
                        };
                    };
                }, { key : __key1, sequenceNumber : 1332912300 });
            };
        }, { sequenceNumber : 1332912301 });
        __frame0.Component(Component2, function(/**/ __component0)
        {
            __component0.Property1  = "1";
            __component0.Property2  = 1;
            __component0.ChildContent  = function(/**/ i)
            {
                return function(/**/ __frame1, /**/ __key1)
                {
                    __frame1.Text("Component2.2\r\n    ", { key : __key1, sequenceNumber : 1332912302 });
                };
            };
            __component0.Property3  = function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Text("Component2.Property3\r\n    ", { key : __key1, sequenceNumber : 1332912303 });
            };
            __component0.Property4  = function(/**/ i)
            {
                return function(/**/ __frame1, /**/ __key1)
                {
                    __frame1.Text("Component2.Property4\r\n    ", { key : __key1, sequenceNumber : 1332912304 });
                };
            };
        }, { sequenceNumber : 1332912305 });
        if (field1 & 1 == 0)
        {
            input = __frame0.Element("input", function(/*UIElementAttribute*/ __attribute)
            {
                /*var*/ let bindGetValue1 = field2;
                __attribute.Set("value", bindGetValue1);
                __attribute.Set("@onchange", EventCallback.Factory.CreateBinder(, function(/**/ __value)
                {
field2 = __value                }, bindGetValue1));
            }, null, { sequenceNumber : 1332912306 });
        }
        __frame0.Element("button", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("@onclick", EventCallback.Factory.Create(, ActionClicked, EventCallbackFlags.StopPropagation  | EventCallbackFlags.PreventDefault));
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Text("Click Me", { key : __key1, sequenceNumber : 1332912307 });
        }, { sequenceNumber : 1332912308 });
        for(/*int*/ let _i = 0; _i < 10; _i++)
        {
            __frame0.Frame(function(/**/ __frame1, /**/ __key1)
            {
                __frame0.Content(_i, { sequenceNumber : 1332912309 });
            }, { key : _i, sequenceNumber : 1332912310 });
            /*var*/ let i = _i;
            __frame0.Element("div", function(/*UIElementAttribute*/ __attribute)
            {
                __attribute.Set("class", field1field2i);
            }, function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Content(i + ".", { key : __key1, sequenceNumber : 1332912311 });
                __frame1.Text(" ABC ", { key : __key1, sequenceNumber : 1332912312 });
                __frame1.Content(i, { key : __key1, sequenceNumber : 1332912313 });
                __frame1.Text(" ", { key : __key1, sequenceNumber : 1332912314 });
                __frame1.Content(field1, { key : __key1, sequenceNumber : 1332912315 });
                __frame1.Text(" ", { key : __key1, sequenceNumber : 1332912316 });
                __frame1.Content(field2, { key : __key1, sequenceNumber : 1332912317 });
                __frame1.Text("    ", { key : __key1, sequenceNumber : 1332912318 });
            }, { key : i, sequenceNumber : 1332912319 });
        });
        __frame0.Element("div", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("class", "def");
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Text("ABC ", { key : __key1, sequenceNumber : 1332912320 });
            __frame1.Content(field1, { key : __key1, sequenceNumber : 1332912321 });
            __frame1.Text("    ", { key : __key1, sequenceNumber : 1332912322 });
            __frame1.Content(view, { key : __key1, sequenceNumber : 1332912323 });
            __frame1.Text("    ", { key : __key1, sequenceNumber : 1332912324 });
            for(/*int*/ let _i = 0; _i < 10; _i++)
            {
                /*var*/ let i = _i;
                __frame1.Element("div", function(/*UIElementAttribute*/ __attribute)
                {
                    __attribute.Set("class", field1field2i);
                }, function(/**/ __frame2, /**/ __key2)
                {
                    __frame2.Content(i, { key : __key2, sequenceNumber : 1332912325 });
                    __frame2.Text(" . ABC ", { key : __key2, sequenceNumber : 1332912326 });
                    __frame2.Content(i, { key : __key2, sequenceNumber : 1332912327 });
                    __frame2.Text(" ", { key : __key2, sequenceNumber : 1332912328 });
                    __frame2.Content(field1, { key : __key2, sequenceNumber : 1332912329 });
                    __frame2.Text(" ", { key : __key2, sequenceNumber : 1332912330 });
                    __frame2.Content(field2, { key : __key2, sequenceNumber : 1332912331 });
                    __frame2.Text("        ", { key : __key2, sequenceNumber : 1332912332 });
                }, { key : i, sequenceNumber : 1332912333 });
            });
        }, { sequenceNumber : 1332912334 });
        for(/*int*/ let _i = 0; _i < 10; _i++)
        {
            /*var*/ let i = _i;
            __frame0.Element("div", function(/*UIElementAttribute*/ __attribute)
            {
                __attribute.Set("class", field1field2i);
            }, function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Content(i, { key : __key1, sequenceNumber : 1332912335 });
                __frame1.Text(" . DEF ", { key : __key1, sequenceNumber : 1332912336 });
                __frame1.Content(field1, { key : __key1, sequenceNumber : 1332912337 });
                __frame1.Text(" ", { key : __key1, sequenceNumber : 1332912338 });
                __frame1.Content(field2, { key : __key1, sequenceNumber : 1332912339 });
                __frame1.Text("    ", { key : __key1, sequenceNumber : 1332912340 });
            }, { key : i, sequenceNumber : 1332912341 });
        });
        /*RenderFragment*/ let view2 = function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Element("span", null, function(/**/ __frame2, /**/ __key2)
            {
                __frame2.Content(prope, { key : __key2, sequenceNumber : 1332912342 });
            }, { key : __key1, sequenceNumber : 1332912343 });
        };
        __frame0.Content(view2, { sequenceNumber : 1332912344 });
        if (descriptor != null)
        {
            __frame0.Element("h1", null, function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Text("Version: ", { key : __key1, sequenceNumber : 1332912345 });
                __frame1.Content(descriptor.Version, { key : __key1, sequenceNumber : 1332912346 });
            }, { sequenceNumber : 1332912347 });
            __frame0.Element("h1", null, function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Text("Size: ", { key : __key1, sequenceNumber : 1332912348 });
                __frame1.Content(descriptor.Size, { key : __key1, sequenceNumber : 1332912349 });
            }, { sequenceNumber : 1332912350 });
        }
        __frame0.Content(html, { sequenceNumber : 1332912351 });
    }
}

class BlazorJs_Sample_Component2 extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*void*/ RegisterRoute()
    {
        RouteTableFactory.Register(Component2, "/C2");
    }
    /*void*/ CascadeParameters()
    {
        RequestCascadingParameter_$1(BlazorJs.Sample.Component1, function(/**/ e)
        {
C1 = e        }, { cascadingParameterName : "C1" });
        super.CascadeParameters();
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Markup("<a href=\"/\">Component2</a>", { sequenceNumber : 930143511 });
        __frame0.Element("div", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("class", "def");
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Content(Property1, { key : __key1, sequenceNumber : 930143510 });
            __frame1.Text("    ", { key : __key1, sequenceNumber : 930143509 });
            __frame1.Element("span", function(/*UIElementAttribute*/ __attribute)
            {
                __attribute.Set("class", "def");
            }, function(/**/ __frame2, /**/ __key2)
            {
                __frame2.Content(Property2, { key : __key2, sequenceNumber : 930143508 });
                __frame2.Text("    ", { key : __key2, sequenceNumber : 930143507 });
            }, { key : __key1, sequenceNumber : 930143506 });
            __frame1.Content(ChildContentInvoke("abc"), { key : __key1, sequenceNumber : 930143505 });
        }, { sequenceNumber : 930143504 });
        __frame0.Content(Property3, { sequenceNumber : 930143503 });
        __frame0.Content(Property4, { sequenceNumber : 930143502 });
    }
}

const BlazorJs_Sample_GenericComponent1$_2 = (T1, T2) => class extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
        T1 = $_T1;
        T2 = $_T2;
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Component(GenericComponent2<T2, double>, null, { sequenceNumber : 1453956044 });
    }
}

const BlazorJs_Sample_GenericComponent2$_2 = (T1, T2) => class extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
        T1 = $_T1;
        T2 = $_T2;
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
    }
}

class BlazorJs_Sample_Routes extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Component(Router, function(/**/ __component0)
        {
            __component0.AppAssembly  = Routes.Assembly;
            __component0.Found  = function(/**/ routeData)
            {
                return function(/**/ __frame1, /**/ __key1)
                {
                    __frame1.Component(RouteView, function(/**/ __component1)
                    {
                        __component1.RouteData  = routeData;
                        __component1.DefaultLayout  = LayoutMainLayout;
                    }, { key : __key1, sequenceNumber : 1437594150 });
                    __frame1.Component(FocusOnNavigate, function(/**/ __component1)
                    {
                        __component1.RouteData  = routeData;
                        __component1.Selector  = "h1";
                    }, { key : __key1, sequenceNumber : 1437594151 });
                };
            };
        }, { sequenceNumber : 1437594152 });
    }
}


class BlazorJs_Sample_GeneratedStartup extends object
{
    constructor()
    {
        super();
    }
    /*void*/ Run()
    {
        BlazorJs.Sample.Component1.RegisterRoute();
        BlazorJs.Sample.Component2.RegisterRoute();
        BlazorJs.Sample.Pages.Breakout.RegisterRoute();
        BlazorJs.Sample.Pages.Counter.RegisterRoute();
        BlazorJs.Sample.Pages.Home.RegisterRoute();
        BlazorJs.Sample.Pages.Sudoku.RegisterRoute();
        BlazorJs.Sample.Pages.Weather.RegisterRoute();
    }
}

class BlazorJs_Sample_Layout_MainLayout extends Microsoft_AspNetCore_Components_LayoutComponentBase
{
    constructor()
    {
        super();
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Element("div", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("class", "page");
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Element("div", function(/*UIElementAttribute*/ __attribute)
            {
                __attribute.Set("class", "sidebar");
            }, function(/**/ __frame2, /**/ __key2)
            {
                __frame2.Component(NavMenu, null, { key : __key2, sequenceNumber : 102760593 });
            }, { key : __key1, sequenceNumber : 102760592 });
            __frame1.Element("main", null, function(/**/ __frame2, /**/ __key2)
            {
                __frame2.Markup("<div class=\"top-row px-4\">\r\n            <a href=\"https://learn.microsoft.com/aspnet/core/\" target=\"_blank\">About</a>\r\n        </div>", { key : __key2, sequenceNumber : 102760591 });
                __frame2.Element("article", function(/*UIElementAttribute*/ __attribute)
                {
                    __attribute.Set("class", "content px-4");
                }, function(/**/ __frame3, /**/ __key3)
                {
                    __frame3.Content(Body, { key : __key3, sequenceNumber : 102760590 });
                    __frame3.Text("        ", { key : __key3, sequenceNumber : 102760589 });
                }, { key : __key2, sequenceNumber : 102760588 });
            }, { key : __key1, sequenceNumber : 102760587 });
        }, { sequenceNumber : 102760586 });
        __frame0.Markup("<div id=\"blazor-error-ui\">\r\n    An unhandled error has occurred.\r\n    <a href=\"\" class=\"reload\">Reload</a>\r\n    <a class=\"dismiss\">🗙</a>\r\n</div>", { sequenceNumber : 102760585 });
    }
}

class BlazorJs_Sample_Layout_NavMenu extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Markup("<div class=\"top-row ps-3 navbar navbar-dark\">\r\n    <div class=\"container-fluid\">\r\n        <a class=\"navbar-brand\" href=\"\">MyBlazorWeb</a>\r\n    </div>\r\n</div>", { sequenceNumber : 436277312 });
        __frame0.Markup("<input type=\"checkbox\" title=\"Navigation menu\" class=\"navbar-toggler\" />", { sequenceNumber : 436277311 });
        __frame0.Element("div", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("class", "nav-scrollable");
            __attribute.Set("onclick", "document.querySelector('.navbar-toggler').click()");
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Element("nav", function(/*UIElementAttribute*/ __attribute)
            {
                __attribute.Set("class", "flex-column");
            }, function(/**/ __frame2, /**/ __key2)
            {
                __frame2.Element("div", function(/*UIElementAttribute*/ __attribute)
                {
                    __attribute.Set("class", "nav-item px-3");
                }, function(/**/ __frame3, /**/ __key3)
                {
                    __frame3.Component(NavLink, function(/**/ __component3)
                    {
                        __component3"class" = "nav-link";
                        __component3"href" = "/";
                        __component3.Match  = NavLinkMatch.All;
                        __component3.ChildContent  = function(/**/ __frame4, /**/ __key4)
                        {
                            __frame4.Markup("<span class=\"bi bi-house-door-fill\" aria-hidden=\"true\"></span>", { key : __key4, sequenceNumber : 436277310 });
                            __frame4.Text("Home\r\n            ", { key : __key4, sequenceNumber : 436277309 });
                        };
                    }, { key : __key3, sequenceNumber : 436277308 });
                }, { key : __key2, sequenceNumber : 436277307 });
                __frame2.Element("div", function(/*UIElementAttribute*/ __attribute)
                {
                    __attribute.Set("class", "nav-item px-3");
                }, function(/**/ __frame3, /**/ __key3)
                {
                    __frame3.Component(NavLink, function(/**/ __component3)
                    {
                        __component3"class" = "nav-link";
                        __component3"href" = "counter";
                        __component3.ChildContent  = function(/**/ __frame4, /**/ __key4)
                        {
                            __frame4.Markup("<span class=\"bi bi-plus-square-fill\" aria-hidden=\"true\"></span>", { key : __key4, sequenceNumber : 436277306 });
                            __frame4.Text("Counter\r\n            ", { key : __key4, sequenceNumber : 436277305 });
                        };
                    }, { key : __key3, sequenceNumber : 436277304 });
                }, { key : __key2, sequenceNumber : 436277303 });
                __frame2.Element("div", function(/*UIElementAttribute*/ __attribute)
                {
                    __attribute.Set("class", "nav-item px-3");
                }, function(/**/ __frame3, /**/ __key3)
                {
                    __frame3.Component(NavLink, function(/**/ __component3)
                    {
                        __component3"class" = "nav-link";
                        __component3"href" = "weather";
                        __component3.ChildContent  = function(/**/ __frame4, /**/ __key4)
                        {
                            __frame4.Markup("<span class=\"bi bi-list-nested\" aria-hidden=\"true\"></span>", { key : __key4, sequenceNumber : 436277302 });
                            __frame4.Text("Weather\r\n            ", { key : __key4, sequenceNumber : 436277301 });
                        };
                    }, { key : __key3, sequenceNumber : 436277300 });
                }, { key : __key2, sequenceNumber : 436277299 });
                __frame2.Element("div", function(/*UIElementAttribute*/ __attribute)
                {
                    __attribute.Set("class", "nav-item px-3");
                }, function(/**/ __frame3, /**/ __key3)
                {
                    __frame3.Component(NavLink, function(/**/ __component3)
                    {
                        __component3"class" = "nav-link";
                        __component3"href" = "Sudoku";
                        __component3.ChildContent  = function(/**/ __frame4, /**/ __key4)
                        {
                            __frame4.Markup("<span class=\"bi bi-list-nested\" aria-hidden=\"true\"></span>", { key : __key4, sequenceNumber : 436277298 });
                            __frame4.Text("Sudoku\r\n            ", { key : __key4, sequenceNumber : 436277297 });
                        };
                    }, { key : __key3, sequenceNumber : 436277296 });
                }, { key : __key2, sequenceNumber : 436277295 });
                __frame2.Element("div", function(/*UIElementAttribute*/ __attribute)
                {
                    __attribute.Set("class", "nav-item px-3");
                }, function(/**/ __frame3, /**/ __key3)
                {
                    __frame3.Component(NavLink, function(/**/ __component3)
                    {
                        __component3"class" = "nav-link";
                        __component3"href" = "Breakout";
                        __component3.ChildContent  = function(/**/ __frame4, /**/ __key4)
                        {
                            __frame4.Markup("<span class=\"bi bi-list-nested\" aria-hidden=\"true\"></span>", { key : __key4, sequenceNumber : 436277294 });
                            __frame4.Text("Breakout\r\n            ", { key : __key4, sequenceNumber : 436277293 });
                        };
                    }, { key : __key3, sequenceNumber : 436277292 });
                }, { key : __key2, sequenceNumber : 436277291 });
            }, { key : __key1, sequenceNumber : 436277290 });
        }, { sequenceNumber : 436277289 });
    }
}

class BlazorJs_Sample_Pages_Breakout extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*void*/ RegisterRoute()
    {
        RouteTableFactory.Register(Breakout, "/Breakout");
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        world = __frame0.Element("canvas", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("width", "480");
            __attribute.Set("height", "320");
        }, null, { sequenceNumber : 440508743 });
    }
}

class BlazorJs_Sample_Pages_Counter extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*void*/ RegisterRoute()
    {
        RouteTableFactory.Register(Counter, "/counter");
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Component(PageTitle, function(/**/ __component0)
        {
            __component0.ChildContent  = function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Text("Counter", { key : __key1, sequenceNumber : 159059258 });
            };
        }, { sequenceNumber : 159059257 });
        __frame0.Markup("<h1>Counter</h1>", { sequenceNumber : 159059256 });
        __frame0.Element("p", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("role", "status");
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Text("Current count: ", { key : __key1, sequenceNumber : 159059255 });
            __frame1.Content(currentCount, { key : __key1, sequenceNumber : 159059254 });
        }, { sequenceNumber : 159059253 });
        __frame0.Element("button", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("class", "btn btn-primary");
            __attribute.Set("@onclick", EventCallback.Factory.Create(, ActionIncrementCount));
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Text("Click me +", { key : __key1, sequenceNumber : 159059252 });
        }, { sequenceNumber : 159059251 });
        __frame0.Markup("<br>", { sequenceNumber : 159059250 });
        __frame0.Element("button", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("class", "btn btn-primary");
            __attribute.Set("@onclick", EventCallback.Factory.Create(, ActionDecrementCount));
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Text("Click me -", { key : __key1, sequenceNumber : 159059249 });
        }, { sequenceNumber : 159059248 });
    }
}

class BlazorJs_Sample_Pages_Home extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*void*/ RegisterRoute()
    {
        RouteTableFactory.Register(Home, "/");
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Component(PageTitle, function(/**/ __component0)
        {
            __component0.ChildContent  = function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Text("Home", { key : __key1, sequenceNumber : 92866813 });
            };
        }, { sequenceNumber : 92866812 });
        __frame0.Markup("<h1>Hello, worlds!</h1>", { sequenceNumber : 92866811 });
        __frame0.Text("Welcome to your new app.", { sequenceNumber : 92866810 });
        __frame0.Component(Counter, null, { sequenceNumber : 92866809 });
    }
}

class BlazorJs_Sample_Pages_Sudoku extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*void*/ RegisterRoute()
    {
        RouteTableFactory.Register(Sudoku, "/Sudoku");
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Element("div", function(/*UIElementAttribute*/ __attribute)
        {
            __attribute.Set("class", "ltroot flex");
        }, function(/**/ __frame1, /**/ __key1)
        {
            __frame1.Component(EditForm, function(/**/ __component1)
            {
                __component1.Model  = ;
                __component1"class" = "bg-card mg-a";
                __component1.OnSubmit  = EventCallback.Factory.Create(Microsoft.AspNetCore.Components.Forms.EditContext, , ActionCreateBoard);
                __component1.ChildContent  = function(/**/ context)
                {
                    return function(/**/ __frame2, /**/ __key2)
                    {
                        if (size == 0 || boards == null)
                        {
                            __frame2.Markup("<h3>Enter board size</h3>", { key : __key2, sequenceNumber : 14927692 });
                            __frame2.Component(InputNumber<int>, function(/**/ __component2)
                            {
                                /*var*/ let bindGetValue2 = size;
                                __component2.Value  = bindGetValue2;
                                __component2.ValueChanged  = EventCallback.Factory.CreateInferred(, function(/**/ __value)
                                {
size = __value                                }, bindGetValue2);
                                __component2.ValueExpression  = function()
                                {
                                    return size;
                                };
                            }, { key : __key2, sequenceNumber : 14927693 });
                            __frame2.Element("button", function(/*UIElementAttribute*/ __attribute)
                            {
                                __attribute.Set("type", "submit");
                                __attribute.Set("class", "mgx bg-primary");
                                __attribute.Set("@onclick", EventCallback.Factory.Create(, ActionCreateBoard));
                            }, function(/**/ __frame3, /**/ __key3)
                            {
                                __frame3.Text("Continue", { key : __key3, sequenceNumber : 14927694 });
                            }, { key : __key2, sequenceNumber : 14927695 });
                        }
                        else 
                        {
                            __frame2.Element("table", null, function(/**/ __frame3, /**/ __key3)
                            {
                                for(/*int*/ let _y = 0; _y < size; _y++)
                                {
                                    /*var*/ let y = _y;
                                    __frame3.Element("tr", null, function(/**/ __frame4, /**/ __key4)
                                    {
                                        for(/*int*/ let _x = 0; _x < size; _x++)
                                        {
                                            /*var*/ let x = _x;
                                            /*var*/ let board = boardsyx;
                                            __frame4.Element("td", null, function(/**/ __frame5, /**/ __key5)
                                            {
                                                __frame5.Component(InputNumber<int?>, function(/**/ __component5)
                                                {
                                                    /*var*/ let bindGetValue5 = board.Entry;
                                                    __component5.Value  = bindGetValue5;
                                                    __component5.ValueChanged  = EventCallback.Factory.CreateInferred(, function(/**/ __value)
                                                    {
                                                        board.Entry  = __value;
                                                        Validate(x, y);
                                                    }, bindGetValue5);
                                                    __component5.ValueExpression  = function()
                                                    {
                                                        return board.Entry;
                                                    };
                                                    __component5"readonly" = board.IsFixed;
                                                    __component5"class" = board.IsFixed " bg-dark-01"board.HasError " bg-error-01"board.Entry  > 0" bg-success-01"" bg-primary-01";
                                                }, { key : __key5, sequenceNumber : 14927696 });
                                            }, { key : x, sequenceNumber : 14927697 });
                                        });
                                    }, { key : y, sequenceNumber : 14927698 });
                                });
                            }, { key : __key2, sequenceNumber : 14927699 });
                        }
                    };
                };
            }, { key : __key1, sequenceNumber : 14927700 });
        }, { sequenceNumber : 14927701 });
    }
}

class BlazorJs_Sample_Pages_Weather extends Microsoft_AspNetCore_Components_ComponentBase
{
    constructor()
    {
        super();
    }
    /*void*/ RegisterRoute()
    {
        RouteTableFactory.Register(Weather, "/weather");
    }
    /*void*/ BuildRenderTree(/*IUIFrame*/ __frame0, { /*object*/ __key = null})
    {
        __frame0.Component(PageTitle, function(/**/ __component0)
        {
            __component0.ChildContent  = function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Text("Weather", { key : __key1, sequenceNumber : 761485674 });
            };
        }, { sequenceNumber : 761485673 });
        __frame0.Markup("<h1>Weather</h1>", { sequenceNumber : 761485672 });
        __frame0.Markup("<p>This component demonstrates showing data from the server.</p>", { sequenceNumber : 761485671 });
        if (forecasts == null)
        {
            __frame0.Markup("<p><em>Loading...</em></p>", { sequenceNumber : 761485670 });
        }
        else 
        {
            __frame0.Element("table", function(/*UIElementAttribute*/ __attribute)
            {
                __attribute.Set("class", "table");
            }, function(/**/ __frame1, /**/ __key1)
            {
                __frame1.Markup("<thead>\r\n            <tr>\r\n                <th>Date</th>\r\n                <th>Temp. (C)</th>\r\n                <th>Temp. (F)</th>\r\n                <th>Summary</th>\r\n            </tr>\r\n        </thead>", { key : __key1, sequenceNumber : 761485669 });
                __frame1.Element("tbody", null, function(/**/ __frame2, /**/ __key2)
                {
                    BlazorJs.forEach(forecasts, function(forecast, $_i)
                    {
                        __frame2.Element("tr", null, function(/**/ __frame3, /**/ __key3)
                        {
                            __frame3.Element("td", null, function(/**/ __frame4, /**/ __key4)
                            {
                                __frame4.Content(forecast.Date.ToShortDateString(), { key : __key4, sequenceNumber : 761485668 });
                            }, { key : __key3, sequenceNumber : 761485667 });
                            __frame3.Element("td", null, function(/**/ __frame4, /**/ __key4)
                            {
                                __frame4.Content(forecast.TemperatureC, { key : __key4, sequenceNumber : 761485666 });
                            }, { key : __key3, sequenceNumber : 761485665 });
                            __frame3.Element("td", null, function(/**/ __frame4, /**/ __key4)
                            {
                                __frame4.Content(forecast.TemperatureF, { key : __key4, sequenceNumber : 761485664 });
                            }, { key : __key3, sequenceNumber : 761485663 });
                            __frame3.Element("td", null, function(/**/ __frame4, /**/ __key4)
                            {
                                __frame4.Content(forecast.Summary, { key : __key4, sequenceNumber : 761485662 });
                            }, { key : __key3, sequenceNumber : 761485661 });
                        }, { key : forecast, sequenceNumber : 761485660 });
                    });
                }, { key : __key1, sequenceNumber : 761485659 });
            }, { sequenceNumber : 761485658 });
        }
    }
}







