namespace Hemy.Lib.Tools.Shaders.ShaderCompiler;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Hemy.Lib.Core;
using Hemy.Lib.Core.Memory;
using Hemy.Lib.Core.Platform.Vulkan;
using Hemy.Lib.Core.Platform.Windows.Graphic;
using static Hemy.Lib.Tools.Shaders.ShaderCompiler.Native;


public unsafe static class ShadercImpl
{
    
    public static void CompilVertx(GraphicData* graphicData, GraphicDescriptorData* descriptor)
    {
        // code : https://github.com/google/shaderc/blob/main/examples/online-compile/main.cc

        var compiler = Native.CompilerInitialize();

        byte* shaderSource = Memory.NewStr(VertexBaseShader());
        uint shaderSourceLength = Str.Length(shaderSource);


        byte* filename = Memory.NewStr("shaderSourceVert");

        var result = Native.CompileIntoSpv(compiler, shaderSource, shaderSourceLength, ShaderKind.VertexShader, filename, descriptor->Entrypoint, null);

        var status = Native.ResultGetCompilationStatus(result);

        if (status != CompilationStatus.Success)
        {
            var error = Native.ResultGetErrorMessage(result);
        }
        else
        {
            var length = Native.ResultGetLength(result);
            var bytecode = Native.ResultGetBytes(result); // use in shader compil ?????? ( )

            VkShaderModuleCreateInfo* createInfoVert = stackalloc VkShaderModuleCreateInfo[1];

            createInfoVert[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
            createInfoVert[0].codeSize = length;
            createInfoVert[0].pCode = (uint*)bytecode;
            createInfoVert[0].pNext = null;
            createInfoVert[0].flags = 0;

            VkShaderModule shaderModule = VkShaderModule.Null;
            var Vertresult = Vk.vkCreateShaderModule(graphicData->Device, &createInfoVert[0], null, &shaderModule);
            if (Vertresult != VkResult.VK_SUCCESS) Log.Error("Vertex ShaderModule ");

            descriptor->ShaderModulesVertex = shaderModule;
        }

        Memory.DisposeStr(shaderSource);

        Memory.DisposeStr(filename);

        Native.ResultRelease(result);
        Native.CompilerRelease(compiler);
    }

    public static void CompilFrag(GraphicData* graphicData, GraphicDescriptorData* descriptor)
    {
        // code : https://github.com/google/shaderc/blob/main/examples/online-compile/main.cc

        var compiler = Native.CompilerInitialize();

        byte* shaderSource = Memory.NewStr(FragmentBaseShader());
        uint shaderSourceLength = Str.Length(shaderSource);

        
        byte* filename = Memory.NewStr("shaderSourceFrag");

        var result = Native.CompileIntoSpv(compiler, shaderSource, shaderSourceLength, ShaderKind.FragmentShader, filename, descriptor->Entrypoint, null);

        var status = Native.ResultGetCompilationStatus(result);

        if (status != CompilationStatus.Success)
        {
            var error = Native.ResultGetErrorMessage(result);
        }
        else
        {
            var length = Native.ResultGetLength(result);
            var bytecode = Native.ResultGetBytes(result); // use in shader compil ?????? ( )

            VkShaderModuleCreateInfo* createInfoVert = stackalloc VkShaderModuleCreateInfo[1];

            createInfoVert[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
            createInfoVert[0].codeSize = length;
            createInfoVert[0].pCode = (uint*)bytecode;
            createInfoVert[0].pNext = null;
            createInfoVert[0].flags = 0;

            VkShaderModule shaderModule = VkShaderModule.Null;
            var Fragresult = Vk.vkCreateShaderModule(graphicData->Device, &createInfoVert[0], null, &shaderModule);
            if (Fragresult != VkResult.VK_SUCCESS) Log.Error("Frag ShaderModule ");

            descriptor->ShaderModulesFragment = shaderModule;
        }

        Memory.DisposeStr(shaderSource);
     
        Memory.DisposeStr(filename);

        Native.ResultRelease(result);
        Native.CompilerRelease(compiler);
    }

    internal static string VertexBaseShader()
    {
        return @"
#version 450

layout(location = 0) out vec3 fragColor;

vec2 positions[3] = vec2[]
(
    vec2(0.0, -0.5),
    vec2(0.5, 0.5),
    vec2(-0.5, 0.5)
);

vec3 colors[3] = vec3[]
(
    vec3(1.0, 0.0, 0.0),
    vec3(0.0, 1.0, 0.0),
    vec3(0.0, 0.0, 1.0)
);

void main() 
{
    gl_Position = vec4(positions[gl_VertexIndex], 0.0, 1.0);
    fragColor = colors[gl_VertexIndex];
}
";

    }

    internal static string FragmentBaseShader()
    {
        return @"#version 450

layout(location = 0) in vec3 fragColor;

layout(location = 0) out vec4 outColor;

void main()
{
    outColor = vec4(fragColor, 1.0);
}
";
    }
}

// /// <summary>
// /// Defines a shader macro.
// /// </summary>
// /// <remarks>
// /// Creates a new instance of <see cref="ShaderMacro"/>.
// /// </remarks>
// /// <param name="key">The key of the macro.</param>
// /// <param name="value">The optional value.</param>
// public readonly struct ShaderMacro(string key, string value)
// {

//     /// <summary>  Gets the key of the macro. </summary>
//     public string Key { get; } = key;

//     /// <summary> Gets the optional value of the macro. </summary>
//     public string Value { get; } = value;
// }

// /// <summary>
// /// Defines a binding base.
// /// </summary>
// public class BindingBase
// {
//     /// <summary>
//     /// Creates a new instance of <see cref="BindingBase"/>.
//     /// </summary>
//     public BindingBase(UniformKind kind, uint @base)
//     {
//         Kind = kind;
//         Base = @base;   
//     }

//     /// <summary>
//     /// Creates a new instance of <see cref="HLSLRegisterSetAndBinding"/>.
//     /// </summary>
//     public BindingBase(ShaderKind stage, UniformKind kind, uint @base)
//         : this(kind, @base)
//     {
//         ShaderStage = stage;
//     }

//     public ShaderKind? ShaderStage { get; set; }

//     /// <summary>
//     /// Gets the uniform kind.
//     /// </summary>
//     public UniformKind Kind { get; }

//     /// <summary>
//     /// Gets the base.
//     /// </summary>
//     public uint Base { get; }
// }

// /// <summary>
// /// Defines a HLSL register set and binding.
// /// </summary>
// public class HLSLRegisterSetAndBinding
// {
//     /// <summary>
//     /// Creates a new instance of <see cref="HLSLRegisterSetAndBinding"/>.
//     /// </summary>
//     public HLSLRegisterSetAndBinding(string register, string set, string binding)
//     {
//         Register = register;
//         Set = set;
//         Binding = binding;
//     }

//     /// <summary>
//     /// Creates a new instance of <see cref="HLSLRegisterSetAndBinding"/>.
//     /// </summary>
//     public HLSLRegisterSetAndBinding(ShaderKind stage, string register, string set, string binding)
//         : this(register, set, binding)
//     {
//         ShaderStage = stage;
//     }

//     public ShaderKind? ShaderStage { get; set; }

//     /// <summary>
//     /// Gets the register.
//     /// </summary>
//     public string Register { get; }

//     /// <summary>
//     /// Gets the set.
//     /// </summary>
//     public string Set { get; }

//     /// <summary>
//     /// Gets the binding.
//     /// </summary>
//     public string Binding { get; }
// }

// public sealed class CompilerOptions : IDisposable
// {
//     public string EntryPoint { get; set; } = "main";

//     public List<string> IncludeDirectories { get; } = [];

//     /// <summary>
//     /// Gets the list of defines.
//     /// </summary>
//     public List<ShaderMacro> Defines { get; } = [];

//     public OptimizationLevel OptimizationLevel { get; set; } = OptimizationLevel.Performance;

//     public SourceLanguage? SourceLanguage { get; set; }

//     /// <summary>
//     /// Gets or sets whether to invert Y
//     /// </summary>
//     public bool? InvertY { get; set; }

//     /// <summary>
//     /// Gets or sets whether to generate debug information.
//     /// </summary>
//     public bool? GeneratedDebug { get; set; }

//     /// <summary>
//     /// Gets or sets whether should suppress compiler warnings.
//     /// </summary>
//     public bool? SuppressWarnings { get; set; }

//     /// <summary>
//     /// Sets the compiler mode to treat all warnings as errors. Note the
//     /// suppress-warnings mode overrides this option, i.e. if both
//     /// warning-as-errors and suppress-warnings modes are set, warnings will not
//     /// be emitted as error messages.
//     /// </summary>
//     public bool? WarningsAsErrors { get; set; }

//     /// <summary>
//     /// Gets or sets the target environment (vulkan, opengl...)
//     /// </summary>
//     public TargetEnvironmentVersion? TargetEnv { get; set; }

//     /// <summary>
//     /// Gets or sets the shader stage (vertex, fragment, compute...)
//     /// </summary>
//     public ShaderKind? ShaderStage { get; set; }

//     /// <summary>
//     /// Gets or sets the target SPIR-V version.
//     /// </summary>
//     public SpirVVersion? TargetSpv { get; set; }

//     /// <summary>
//     /// Sets whether the compiler generates code for max and min builtins which,
//     /// if given a NaN operand, will return the other operand. Similarly, the clamp
//     /// builtin will favour the non-NaN operands, as if clamp were implemented
//     /// as a composition of max and min.
//     /// </summary>
//     public bool? NaNClamp { get; set; }

//     /// <summary>
//     /// Sets whether the compiler should automatically assign locations to uniform variables that don't have explicit locations in the shader source.
//     /// </summary>
//     public bool? AutoMapLocations { get; set; }

//     /// <summary>
//     /// Sets whether the compiler should automatically assign bindings to uniforms that aren't already explicitly bound in the shader source.
//     /// </summary>
//     public bool? AutoBindUniforms { get; set; }

//     /// <summary>
//     /// Gets the limits.
//     /// </summary>
//     public Dictionary<Limit, int> Limits { get; } = [];

//     /// <summary>
//     /// Gets the uniform kind base bindings.
//     /// </summary>
//     public List<BindingBase> Bindings { get; } = [];

//     public int? GLSL_Version { get; set; }
//     public Profile? GLSL_Profile { get; set; }

//     #region HLSL options
//     public bool? HlslOffsets { get; set; }
//     public bool? HlslFunctionality1 { get; set; }
//     public bool? HLSLIoMapping { get; set; }
//     public bool? Hlsl16BitTypes { get; set; }

//     /// <summary>
//     /// Gets the hlsl register sets and bindings.
//     /// </summary>
//     public List<HLSLRegisterSetAndBinding> HLSLRegisterSetAndBindings { get; } = [];

//     public void Dispose()
//     {
//         GC.SuppressFinalize(this);
//     }
//     #endregion
// }

// public sealed partial class CompileResult
// {
//     internal unsafe CompileResult(nint native_result, string inputFileName)
//     {
//         Status = Native.shaderc_result_get_compilation_status(native_result);
//         WarningsCount = (uint)Native.shaderc_result_get_num_warnings(native_result);
//         ErrorsCount = (uint)Native.shaderc_result_get_num_errors(native_result);

//         if (Status != CompilationStatus.Success)
//         {
//             string[] lines;
//             if (Status == CompilationStatus.InvalidStage)
//             {
//                 var errorMessage = $"{Path.GetFullPath(inputFileName)}(1,1): error: Stage not specified by #pragma or not inferred from file extension";
//                 lines = [errorMessage];
//             }
//             else
//             {
//                 string errorMessage = Marshal.PtrToStringAnsi(Native.shaderc_result_get_error_message(native_result));
//                 if (!string.IsNullOrEmpty(errorMessage))
//                 {
//                     lines = ParseLines(errorMessage, Status == CompilationStatus.CompilationError);
//                 }
//                 else
//                 {
//                     lines = [$"Error: {Status}"];
//                 }
//             }

//             var builder = new StringBuilder();
//             foreach (var line in lines)
//             {
//                 builder.AppendLine(line);
//             }
//             ErrorMessage = builder.ToString();
//         }
//         else
//         {
//             // byte* data = Native.shaderc_result_get_bytes(native_result);
//             Bytes = Native.shaderc_result_get_bytes(native_result);
//             BytesSize = Native.shaderc_result_get_length(native_result);
//             // Span<byte> span = new(data, (int)size);
//             // Bytecode = span.ToArray();
//             // Bytes = data;
//             // BytesSize = (uint)size;
//         }
//     }

//     public CompilationStatus Status { get; }
//     public byte[] Bytecode { get; }

//     public unsafe byte* Bytes { get; }
//     public unsafe nuint BytesSize { get; }
//     public uint WarningsCount { get; }
//     public uint ErrorsCount { get; }

//     /// <summary>
//     /// Returns a null-terminated string that contains any error messages generated
//     /// during the compilation.
//     /// </summary>
//     public string ErrorMessage { get; }

//     [GeneratedRegex(@"(?<path>.*?)(:(?<line>\d+))?: (?<kind>error|warning): (?<message>.*)")]
//     private static partial Regex RegexMatchLine();

//     private static string[] ParseLines(string text, bool replaceErrorToVisualStudioFormat)
//     {
//         string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

//         if (replaceErrorToVisualStudioFormat)
//         {
//             Regex regex = RegexMatchLine();
//             for (int i = 0; i < lines.Length; i++)
//             {
//                 string line = lines[i];

//                 Match match = regex.Match(line);
//                 if (match.Success)
//                 {
//                     string path = match.Groups["path"].Value;
//                     Group lineText = match.Groups["line"];
//                     int lineNo = 1;
//                     if (!string.IsNullOrEmpty(lineText.Value))
//                     {
//                         lineNo = int.Parse(lineText.Value);
//                     }
//                     if (string.IsNullOrEmpty(path))
//                     {
//                         path = "1";
//                     }

//                     string kind = match.Groups["kind"].Value;
//                     string message = match.Groups["message"].Value;

//                     lines[i] = $"{path}({lineNo}): {kind}: {message}";
//                 }
//             }
//         }

//         return lines;
//     }

// }

// public sealed unsafe class Compiler : IDisposable
// {
//     private nint _compiler;
//     private GCHandle _handle;
//     private readonly HashSet<string> _includedFiles = [];
//     private readonly List<string> _allIncludeDirectories = [];

//     public CompilerOptions Options = new();

//     public Compiler()
//     {
//         _compiler = shaderc_compiler_initialize();
//         if (_compiler == 0)
//         {
//             throw new Exception("Cannot initialize native handle");
//         }

//         _handle = GCHandle.Alloc(this);
//     }

//     public void Dispose()
//     {
//         if (_compiler == 0)
//             return;

//         if (_handle.IsAllocated)
//         {
//             _handle.Free();
//         }

//         shaderc_compiler_release(_compiler);

//         _compiler = 0;
//     }

//     public static void GetSpvVersion(out uint version, out uint revision) => shaderc_get_spv_version(out version, out revision);

//     // public CompileResult Compile(string fileName /*, CompilerOptions options = default*/)
//     // {
//     //     if (!File.Exists(fileName))
//     //         throw new FileNotFoundException(fileName);

//     //     return Compile(File.ReadAllText(fileName), fileName, Options);
//     // }


//     public CompileResult Compile(string source, string fileName /*, CompilerOptions options = default*/)
//     {
//         // options ??= new CompilerOptions();

//         _allIncludeDirectories.Clear();
//         _allIncludeDirectories.AddRange(Options.IncludeDirectories);
//         _allIncludeDirectories.Add(Environment.CurrentDirectory);

//         // Clear the list of included files
//         _includedFiles.Clear();

//         // Setup options now
//         nint native_options = shaderc_compile_options_initialize();

//         try
//         {
//             // Add macro definitions
//             foreach (ShaderMacro define in Options.Defines)
//             {
//                 shaderc_compile_options_add_macro_definition(native_options, define.Key, define.Value ?? string.Empty);
//             }

//             shaderc_compile_options_set_optimization_level(native_options, Options.OptimizationLevel);

//             bool hasHlslFileName = fileName.EndsWith(".hlsl");
//             SourceLanguage sourceLanguage = SourceLanguage.GLSL;
//             if (Options.SourceLanguage.HasValue)
//             {
//                 sourceLanguage = Options.SourceLanguage.Value;
//             }
//             else
//             {
//                 sourceLanguage = hasHlslFileName ? SourceLanguage.HLSL : SourceLanguage.GLSL;
//             }
//             shaderc_compile_options_set_source_language(native_options, sourceLanguage);

//             if (Options.TargetEnv.HasValue)
//             {
//                 uint version = 0;
//                 TargetEnvironment targetEnv = TargetEnvironment.Default;
//                 switch (Options.TargetEnv.Value)
//                 {
//                     case TargetEnvironmentVersion.Vulkan_1_0:
//                         version = (uint)Options.TargetEnv.Value;
//                         targetEnv = TargetEnvironment.Vulkan;
//                         break;
//                     case TargetEnvironmentVersion.Vulkan_1_1:
//                         version = (uint)Options.TargetEnv.Value;
//                         targetEnv = TargetEnvironment.Vulkan;
//                         break;
//                     case TargetEnvironmentVersion.Vulkan_1_2:
//                         version = (uint)Options.TargetEnv.Value;
//                         targetEnv = TargetEnvironment.Vulkan;
//                         break;
//                     case TargetEnvironmentVersion.Vulkan_1_3:
//                         version = (uint)Options.TargetEnv.Value;
//                         targetEnv = TargetEnvironment.Vulkan;
//                         break;
//                     case TargetEnvironmentVersion.OpenGL_4_5:
//                         version = (uint)Options.TargetEnv.Value;
//                         targetEnv = TargetEnvironment.OpenGL;
//                         break;
//                 }

//                 shaderc_compile_options_set_target_env(native_options, targetEnv, version);
//             }

//             if (Options.TargetSpv.HasValue)
//             {
//                 shaderc_compile_options_set_target_spirv(native_options, Options.TargetSpv.Value);
//             }

//             if (Options.InvertY.HasValue)
//             {
//                 shaderc_compile_options_set_invert_y(native_options, Options.InvertY.Value);
//             }

//             if (Options.GeneratedDebug.HasValue && Options.GeneratedDebug.Value)
//             {
//                 shaderc_compile_options_set_generate_debug_info(native_options);
//             }

//             if (Options.SuppressWarnings.HasValue && Options.SuppressWarnings.Value)
//             {
//                 shaderc_compile_options_set_suppress_warnings(native_options);
//             }

//             if (Options.WarningsAsErrors.HasValue && Options.WarningsAsErrors.Value)
//             {
//                 shaderc_compile_options_set_warnings_as_errors(native_options);
//             }

//             if (Options.NaNClamp.HasValue)
//             {
//                 shaderc_compile_options_set_nan_clamp(native_options, Options.NaNClamp.Value);
//             }

//             if (Options.AutoMapLocations.HasValue)
//             {
//                 shaderc_compile_options_set_auto_map_locations(native_options, Options.AutoMapLocations.Value);
//             }

//             if (Options.AutoBindUniforms.HasValue)
//             {
//                 shaderc_compile_options_set_auto_bind_uniforms(native_options, Options.AutoBindUniforms.Value);
//             }

//             if (Options.GLSL_Version.HasValue && Options.GLSL_Profile.HasValue)
//             {
//                 shaderc_compile_options_set_forced_version_profile(native_options, Options.GLSL_Version.Value, Options.GLSL_Profile.Value);
//             }


//             foreach (var limit in Options.Limits)
//             {
//                 shaderc_compile_options_set_limit(native_options, limit.Key, limit.Value);
//             }

//             foreach (BindingBase binding in Options.Bindings)
//             {
//                 if (binding.ShaderStage.HasValue)
//                 {
//                     shaderc_compile_options_set_binding_base_for_stage(native_options, binding.ShaderStage.Value, binding.Kind, binding.Base);
//                 }
//                 else
//                 {
//                     shaderc_compile_options_set_binding_base(native_options, binding.Kind, binding.Base);
//                 }
//             }

//             if (sourceLanguage == SourceLanguage.HLSL)
//             {
//                 if (Options.HlslOffsets.HasValue)
//                 {
//                     shaderc_compile_options_set_hlsl_offsets(native_options, Options.HlslOffsets.Value);
//                 }

//                 if (Options.HlslFunctionality1.HasValue)
//                 {
//                     shaderc_compile_options_set_hlsl_functionality1(native_options, Options.HlslFunctionality1.Value);
//                 }

//                 if (Options.HLSLIoMapping.HasValue)
//                 {
//                     shaderc_compile_options_set_hlsl_io_mapping(native_options, Options.HLSLIoMapping.Value);
//                 }

//                 if (Options.Hlsl16BitTypes.HasValue)
//                 {
//                     shaderc_compile_options_set_hlsl_16bit_types(native_options, Options.Hlsl16BitTypes.Value);
//                 }

//                 foreach (HLSLRegisterSetAndBinding binding in Options.HLSLRegisterSetAndBindings)
//                 {
//                     if (binding.ShaderStage.HasValue)
//                     {
//                         fixed (byte* regPtr = binding.Register.GetUtf8Span())
//                         fixed (byte* setPtr = binding.Set.GetUtf8Span())
//                         fixed (byte* bindingPtr = binding.Binding.GetUtf8Span())
//                             shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage(native_options, binding.ShaderStage.Value, regPtr, setPtr, bindingPtr);
//                     }
//                     else
//                     {
//                         fixed (byte* regPtr = binding.Register.GetUtf8Span())
//                         fixed (byte* setPtr = binding.Set.GetUtf8Span())
//                         fixed (byte* bindingPtr = binding.Binding.GetUtf8Span())
//                             shaderc_compile_options_set_hlsl_register_set_and_binding(native_options, regPtr, setPtr, bindingPtr);
//                     }
//                 }
//             }

//             shaderc_compile_options_set_include_callbacks(native_options, &shaderc_include_resolve, &shaderc_include_result_release, GCHandle.ToIntPtr(_handle));

//             ShaderKind shaderKind;

//             if (Options.ShaderStage.HasValue)
//             {
//                 shaderKind = Options.ShaderStage.Value;
//             }
//             else
//             {
//                 shaderKind = ShaderKind.GLSL_InferFromSource;
//                 if (fileName.EndsWith(".vert.hlsl") || fileName.EndsWith(".vert"))
//                 {
//                     shaderKind = ShaderKind.VertexShader;
//                 }
//                 else if (fileName.EndsWith(".frag.hlsl") || fileName.EndsWith(".frag"))
//                 {
//                     shaderKind = ShaderKind.FragmentShader;
//                 }
//                 else if (fileName.EndsWith(".comp.hlsl") || fileName.EndsWith(".comp"))
//                 {
//                     shaderKind = ShaderKind.ComputeShader;
//                 }
//                 else if (fileName.EndsWith(".geom.hlsl") || fileName.EndsWith(".geom"))
//                 {
//                     shaderKind = ShaderKind.GeometryShader;
//                 }
//                 else if (fileName.EndsWith(".tesc.hlsl") || fileName.EndsWith(".tesc"))
//                 {
//                     shaderKind = ShaderKind.TessControlShader;
//                 }
//                 else if (fileName.EndsWith(".tese.hlsl") || fileName.EndsWith(".tese"))
//                 {
//                     shaderKind = ShaderKind.TessEvaluationShader;
//                 }
//             }

//             nint result = shaderc_compile_into_spv(_compiler, source, shaderKind, fileName, Options.EntryPoint, native_options);
//             CompileResult compileResult = new(result, fileName);
//             shaderc_result_release(result);
//             return compileResult;
//         }
//         finally
//         {
//             shaderc_compile_options_release(native_options);
//         }
//     }

//     [UnmanagedCallersOnly]
//     private static shaderc_include_result* shaderc_include_resolve(nint user_data,
//         byte* requested_source,
//         int type,
//         byte* requesting_source,
//         nuint include_depth)
//     {
//         Compiler context = (Compiler)GCHandle.FromIntPtr((IntPtr)user_data).Target!;

//         string requestedSource = Marshal.PtrToStringUTF8((nint)requested_source)!;
//         string requestingSource = Marshal.PtrToStringUTF8((nint)requesting_source)!;
//         shaderc_include_result* includeResult = (shaderc_include_result*)NativeMemory.AllocZeroed((nuint)sizeof(shaderc_include_result));

//         try
//         {
//             if ((shaderc_include_type)type == shaderc_include_type.shaderc_include_type_relative)
//             {
//                 string includeDirectory = Path.GetDirectoryName(requestingSource);
//                 if (string.IsNullOrEmpty(includeDirectory))
//                 {
//                     includeDirectory = Environment.CurrentDirectory;
//                 }

//                 {
//                     string includeFile = Path.GetFullPath(Path.Combine(includeDirectory, requestedSource));
//                     if (File.Exists(includeFile))
//                     {
//                         var content = File.ReadAllText(includeFile);
//                         includeResult->content = AllocateString(content, out includeResult->content_length);
//                         includeResult->source_name = AllocateString(includeFile, out includeResult->source_name_length);
//                         context._includedFiles.Add(includeFile);
//                         goto include_found;
//                     }
//                 }
//             }

//             foreach (string includeDirectory in context._allIncludeDirectories)
//             {
//                 // Make sure that we support relative include directories
//                 string includeFile = Path.GetFullPath(Path.Combine(includeDirectory, requestedSource));
//                 if (File.Exists(includeFile))
//                 {
//                     string content = File.ReadAllText(includeFile);
//                     includeResult->content = AllocateString(content, out includeResult->content_length);
//                     includeResult->source_name = AllocateString(includeFile, out includeResult->source_name_length);
//                     context._includedFiles.Add(includeFile);
//                     break;
//                 }
//             }

//             include_found:
//             return includeResult;
//         }
//         catch
//         {
//             // ignore
//         }

//         return includeResult;
//     }

//     [UnmanagedCallersOnly]
//     private static void shaderc_include_result_release(nint user_data, shaderc_include_result* include_result)
//     {
//         if (include_result == null)
//             return;

//         if (include_result->content != null)
//         {
//             NativeMemory.Free((void*)include_result->content);
//         }

//         if (include_result->source_name != null)
//         {
//             NativeMemory.Free((void*)include_result->source_name);
//         }

//         NativeMemory.Free((void*)include_result);
//     }

//     private static byte* AllocateString(string content, out nuint length)
//     {
//         length = (nuint)Encoding.UTF8.GetByteCount(content);
//         byte* byteContent = (byte*)NativeMemory.Alloc((nuint)length + 1);
//         fixed (char* pContent = content)
//         {
//             Encoding.UTF8.GetBytes(pContent, content.Length, byteContent, (int)length);
//         }
//         byteContent[length] = 0;
//         return byteContent;
//     }
// }
