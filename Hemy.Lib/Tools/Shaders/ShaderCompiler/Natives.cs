// namespace Hemy.Lib.Tools.Shaders.ShaderCompiler;

// using System;
// using System.Runtime.InteropServices;
// using System.Text;

// internal static unsafe partial class Native
// {
//     private const string LibraryName =
// #if WINDOWS
//     "shaderc_shared";
// #endif

//     [LibraryImport(LibraryName)]
//     public static partial nint shaderc_compiler_initialize();

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compiler_release(nint handle);

//     [LibraryImport(LibraryName)]
//     public static partial nint shaderc_compile_options_initialize();

//     [LibraryImport(LibraryName)]
//     public static partial nint shaderc_compile_options_clone(nint handle);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_release(nint handle);

//     [LibraryImport(LibraryName)]
//     public static partial nint shaderc_compile_options_add_macro_definition(nint options, byte* name, nuint name_length, byte* value, nuint value_length);

//     public static void shaderc_compile_options_add_macro_definition(nint options, string name, string value)
//     {
//         fixed (byte* namePtr = name.GetUtf8Span())
//         fixed (byte* valuePtr = value.GetUtf8Span())
//             shaderc_compile_options_add_macro_definition(options, namePtr, (nuint)name.Length, valuePtr, string.IsNullOrEmpty(value) ? 0 : (nuint)value!.Length);
//     }

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_source_language(nint options, SourceLanguage lang);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_generate_debug_info(nint options);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_optimization_level(nint options, OptimizationLevel level);

//     [LibraryImport(LibraryName)]
//     public static partial nint shaderc_compile_into_spv(nint compiler, byte* source, nuint source_size, uint shader_kind, byte* input_file, byte* entry_point, nint additional_options);

//     public static nint shaderc_compile_into_spv(nint compiler, string source, ShaderKind shaderKind, string inputFile, string entryPoint, nint additional_options)
//     {
//         fixed (byte* sourcePtr = source.GetUtf8Span())
//         fixed (byte* inputFilePtr = inputFile.GetUtf8Span())
//         fixed (byte* entryPointPtr = entryPoint.GetUtf8Span())
//             return shaderc_compile_into_spv(compiler, sourcePtr, (nuint)source.Length, (uint)shaderKind, inputFilePtr, entryPointPtr, additional_options);
//     }

//     [LibraryImport(LibraryName)]
//     public static partial nint shaderc_compile_into_spv_assembly(nint compiler, byte* source_text, nuint source_text_size, uint shader_kind, byte* input_file_name, byte* entry_point_name, nint additional_options);

//     // public static nint shaderc_compile_into_spv_assembly(nint compiler, string source, ShaderKind shaderKind, string inputFile, string entryPoint, nint additional_options)
//     // {
//     //     fixed (byte* sourcePtr = source.GetUtf8Span())
//     //     fixed (byte* inputFilePtr = inputFile.GetUtf8Span())
//     //     fixed (byte* entryPointPtr = entryPoint.GetUtf8Span())
//     //         return shaderc_compile_into_spv_assembly(compiler, sourcePtr, (nuint)source.Length, (uint)shaderKind, inputFilePtr, entryPointPtr, additional_options);
//     // }
    
//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_forced_version_profile(nint options, int version, Profile profile);

//     /// <summary>An include result. https://github.com/google/shaderc/blob/c42db5815fad0424f0f1311de1eec92cdd77203d/libshaderc/include/shaderc/shaderc.h#L325</summary>
//     [StructLayout(LayoutKind.Sequential, Pack = 0)]
//     public struct shaderc_include_result
//     {
//         /// <summary>
//         /// The name of the source file.  The name should be fully resolved
//         /// in the sense that it should be a unique name in the context of the
//         /// includer.  For example, if the includer maps source names to files in
//         /// a filesystem, then this name should be the absolute path of the file.
//         /// For a failed inclusion, this string is empty.
//         /// </summary>
//         public byte* source_name;
//         public nuint source_name_length;
//         /// <summary>
//         /// The text contents of the source file in the normal case.
//         /// For a failed inclusion, this contains the error message.
//         /// </summary>
//         public byte* content;
//         public nuint content_length;
//         /// <summary>
//         /// User data to be passed along with this request.
//         /// </summary>
//         public nint user_data;
//     }

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_include_callbacks(nint options,
//         delegate* unmanaged<nint, byte*, int, byte*, nuint, shaderc_include_result*> resolver,
//         delegate* unmanaged<nint, shaderc_include_result*, void> result_releaser, nint user_data);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_suppress_warnings(nint options);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_target_env(nint options, TargetEnvironment target, uint version);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_target_spirv(nint options, SpirVVersion version);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_warnings_as_errors(nint options);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_limit(nint options, Limit limit, int value);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_auto_bind_uniforms(nint options, [MarshalAs(UnmanagedType.U1)] bool auto_bind);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_hlsl_io_mapping(nint options, [MarshalAs(UnmanagedType.U1)] bool hlsl_iomap);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_hlsl_offsets(nint options, [MarshalAs(UnmanagedType.U1)] bool hlsl_offsets);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_binding_base(nint options, UniformKind kind, uint _base);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_binding_base_for_stage(nint options, ShaderKind shader_kind, UniformKind kind, uint _base);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_auto_map_locations(nint options, [MarshalAs(UnmanagedType.U1)] bool auto_map);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage(nint options, ShaderKind shader_kind, byte* reg, byte* set, byte* binding);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_hlsl_register_set_and_binding(nint options, byte* reg, byte* set, byte* binding);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_hlsl_functionality1(nint options, [MarshalAs(UnmanagedType.U1)] bool enable);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_hlsl_16bit_types(nint options, [MarshalAs(UnmanagedType.U1)] bool enable);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_invert_y(nint options, [MarshalAs(UnmanagedType.U1)] bool enable);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_compile_options_set_nan_clamp(nint options, [MarshalAs(UnmanagedType.U1)] bool enable);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_result_release(nint handle);

//     [LibraryImport(LibraryName)]
//     public static partial nuint shaderc_result_get_length(nint result);

//     [LibraryImport(LibraryName)]
//     public static partial nuint shaderc_result_get_num_warnings(nint result);

//     [LibraryImport(LibraryName)]
//     public static partial nuint shaderc_result_get_num_errors(nint result);

//     [LibraryImport(LibraryName)]
//     public static partial CompilationStatus shaderc_result_get_compilation_status(nint result);

//     [LibraryImport(LibraryName)]
//     public static partial byte* shaderc_result_get_bytes(nint result);

//     [LibraryImport(LibraryName)]
//     public static partial nint shaderc_result_get_error_message(nint result);

//     [LibraryImport(LibraryName)]
//     public static partial void shaderc_get_spv_version(out uint version, out uint revision);

//     [LibraryImport(LibraryName)]
//     public static partial byte shaderc_parse_version_profile(byte* str, int* version, Profile* profile);

//     // public static void shaderc_parse_version_profile(string str, int* version, Profile* profile)
//     // {
//     //     fixed (byte* dataPtr = str.GetUtf8Span())
//     //     {
//     //         shaderc_parse_version_profile(dataPtr, version, profile);
//     //     }
//     // }

  

//     public static ReadOnlySpan<byte> GetUtf8Span(this string source)
//     {
//         ReadOnlySpan<byte> result;

//         if (source is not null)
//         {
//             int maxLength = Encoding.UTF8.GetMaxByteCount(source.Length);
//             byte[] bytes = new byte[maxLength + 1];

//             int length = Encoding.UTF8.GetBytes(source, bytes);
//             result = bytes.AsSpan(0, length);
//         }
//         else
//         {
//             result = null;
//         }

//         return result;
//     }
// }

// public enum UniformKind
// {
//     /// <summary>
//     /// Image and image buffer.
//     /// </summary>
//     Image,
//     /// <summary>
//     /// Pure sampler.
//     /// </summary>
//     Sampler,
//     /// <summary>
//     /// Sampled texture in GLSL, and Shader Resource View in HLSL.
//     /// </summary>
//     Texture,
//     /// <summary>
//     /// Uniform Buffer Object (UBO) in GLSL.  Cbuffer in HLSL.
//     /// </summary>
//     Buffer,
//     /// <summary>
//     /// Shader Storage Buffer Object (SSBO) in GLSL.
//     /// </summary>
//     StorageBuffer,
//     /// <summary>
//     /// Unordered Access View, in HLSL.  (Writable storage image or storage buffer.)
//     /// </summary>
//     UnorderedAccessView,
// }

// public enum TargetEnvironmentVersion : uint
// {
//     /// <summary>
//     /// For Vulkan, use Vulkan's mapping of version numbers to integers.
//     /// See vulkan.h
//     /// </summary>
//     Vulkan_1_0 = ((1u << 22)),

//     /// <summary>
//     /// For Vulkan, use Vulkan's mapping of version numbers to integers.
//     /// See vulkan.h
//     /// </summary>
//     Vulkan_1_1 = ((1u << 22) | (1 << 12)),

//     /// <summary>
//     /// For Vulkan, use Vulkan's mapping of version numbers to integers.
//     /// See vulkan.h
//     /// </summary>
//     Vulkan_1_2 = ((1u << 22) | (2 << 12)),

//     /// <summary>
//     /// For Vulkan, use Vulkan's mapping of version numbers to integers.
//     /// See vulkan.h
//     /// </summary>
//     Vulkan_1_3 = ((1u << 22) | (3 << 12)),

//     /// <summary>
//     /// For Vulkan, use Vulkan's mapping of version numbers to integers.
//     /// See vulkan.h
//     /// </summary>
//     Vulkan_1_4 = ((1u << 22) | (4 << 12)),

//     /// <summary>
//     /// For OpenGL, use the number from #version in shaders.
//     /// TODO(dneto): Currently no difference between OpenGL 4.5 and 4.6.
//     /// See glslang/Standalone/Standalone.cpp
//     /// TODO(dneto): Glslang doesn't accept a OpenGL client version of 460.
//     /// </summary>
//     OpenGL_4_5 = 450,

//     /// <summary>
//     /// Deprecated, WebGPU env never defined versions
//     /// </summary>
//     WebGpu,
// }

// public enum TargetEnvironment : uint
// {
//     /// <summary>
//     /// SPIR-V under Vulkan semantics.
//     /// </summary>
//     Vulkan,
//     /// <summary>
//     /// SPIR-V under OpenGL semantics.
//     /// NOTE: SPIR-V code generation is not supported for shaders under OpenGL compatibility profile.
//     /// </summary>
//     OpenGL,
//     /// <summary>
//     /// SPIR-V under OpenGL semantics, including compatibility profile functions
//     /// </summary>
//     OpenGLCompat,
//     /// <summary>
//     /// Deprecated, SPIR-V under WebGPU semantics.
//     /// </summary>
//     WebGPU,
//     Default = Vulkan
// }

// public enum SpirVVersion : int
// {
//     Version_1_0 = 0x10000,
//     Version_1_1 = 0x10100,
//     Version_1_2 = 0x10200,
//     Version_1_3 = 0x10300,
//     Version_1_4 = 0x10400,
//     Version_1_5 = 0x10500,
//     Version_1_6 = 0x10600,
// }

// public enum SourceLanguage : int
// {
//     GLSL = 0,
//     HLSL = 1
// }

// public enum Profile : int
// {
//     None = 0,
//     Core,
//     Compatibility,
//     Es,
// }

// public enum OptimizationLevel : uint
// {
//     /// <summary>
//     /// No optimization
//     /// </summary>
//     Zero,
//     /// <summary>
//     /// Optimize towards reducing code size
//     /// </summary>
//     Size,
//     /// <summary>
//     /// Optimize towards performance.
//     /// </summary>
//     Performance,
// }

// public enum CompilationStatus : int
// {
//     Success = 0,
//     InvalidStage = 1,  // error stage deduction
//     CompilationError = 2,
//     InternalError = 3,  // unexpected failure
//     NullResultObject = 4,
//     InvalidAssembly = 5,
//     ValidationError = 6,
//     TransformationError = 7,
//     ConfigurationError = 8,
// }

// public enum Limit : int
// {
//     MaxLights = 0,
//     MaxClipPlanes,
//     MaxTextureUnits,
//     MaxTextureCoords,
//     MaxVertexAttribs,
//     MaxVertexUniformComponents,
//     MaxVaryingFloats,
//     MaxVertexTextureImageUnits,
//     MaxCombinedTextureImageUnits,
//     MaxTextureImageUnits,
//     MaxFragmentUniformComponents,
//     MaxDrawBuffers,
//     MaxVertexUniformVectors,
//     MaxVaryingVectors,
//     MaxFragmentUniformVectors,
//     MaxVertexOutputVectors,
//     MaxFragmentInputVectors,
//     MinProgramTeelOffset,
//     MaxProgramTeelOffset,
//     MaxClipDistances,
//     MaxComputeWorkGroupCountX,
//     MaxComputeWorkGroupCountY,
//     MaxComputeWorkGroupCountZ,
//     MaxComputeWorkGroupSizeX,
//     MaxComputeWorkGroupSizeY,
//     MaxComputeWorkGroupSizeZ,
//     MaxComputeUniformComponents,
//     MaxComputeTextureImageUnits,
//     MaxComputeImageUniforms,
//     MaxComputeAtomicCounters,
//     MaxComputeAtomicCounterBuffers,
//     MaxVaryingComponents,
//     MaxVertexOutputComponents,
//     MaxGeometryInputComponents,
//     MaxGeometryOutputComponents,
//     MaxFragmentInputComponents,
//     MaxImageUnits,
//     MaxCombinedImageUnitsAndFragmentoutputs,
//     MaxCombinedShaderOutputResources,
//     MaxImageSamples,
//     MaxVertexImageUniforms,
//     MaxTessControlImageUniforms,
//     MaxTessEvaluationImageUniforms,
//     MaxGeometryImageUniforms,
//     MaxFragmentImageUniforms,
//     MaxCombinedImageUniforms,
//     MaxGeometryTextureImageUnits,
//     MaxGeometryOutputVertices,
//     MaxGeometryTotalOutputComponents,
//     MaxGeometryUniformComponents,
//     MaxGeometryVaryingComponents,
//     MaxTessControlInputComponents,
//     MaxTessControlOutputComponents,
//     MaxTessControlTextureImageUnits,
//     MaxTessControlUniformComponents,
//     MaxTessControlTotalOutputComponents,
//     MaxTessEvaluationInputComponents,
//     MaxTessEvaluationOutputComponents,
//     MaxTessEvaluationTextureImageUnits,
//     MaxTessEvaluationUniformComponents,
//     MaxTessPatchComponents,
//     MaxPatchVertices,
//     MaxTessGenLevel,
//     MaxViewports,
//     MaxVertexAtomicCounters,
//     MaxTessControlAtomicCounters,
//     MaxTessEvaluationAtomicCounters,
//     MaxGeometryAtomicCounters,
//     MaxFragmentAtomicCounters,
//     MaxCombinedAtomicCounters,
//     MaxAtomicCounterBindings,
//     MaxVertexAtomicCounterBuffers,
//     MaxTessControlAtomicCounterBuffers,
//     MaxTessEvaluationAtomicCounterBuffers,
//     MaxGeometryAtomicCounterBuffers,
//     MaxFragmentAtomicCounterBuffers,
//     MaxCombinedAtomicCounterBuffers,
//     MaxAtomicCounterBufferSize,
//     MaxTransformFeedbackBuffers,
//     MaxTransformFeedbackInterleavedComponents,
//     MaxCullDistances,
//     MaxCombinedClipAndCullDistances,
//     MaxSamples,
// }

// public enum ShaderKind : int
// {
//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     VertexShader = 0,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     FragmentShader = 1,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     ComputeShader = 2,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     GeometryShader = 3,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     TessControlShader = 4,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     TessEvaluationShader = 5,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     GLSL_VertexShader = 0,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     GLSL_FragmentShader = 1,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     GLSL_ComputeShader = 2,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     GLSL_GeometryShader = 3,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     GLSL_TessControlShader = 4,

//     /// <summary>
//     /// Forced shader kinds. These shader kinds force the compiler to compile the
//     /// source code as the specified kind of shader.
//     /// </summary>
//     GLSL_TessEvaluationShader = 5,

//     /// <summary>
//     /// Deduce the shader kind from #pragma annotation in the source code. Compiler
//     /// will emit error if #pragma annotation is not found.
//     /// </summary>
//     GLSL_InferFromSource = 6,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultVertexShader = 7,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultFragmentShader = 8,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultComputeShader = 9,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultGeometryShader = 10,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultTessControlShader = 11,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultTessEvaluationShader = 12,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     SPIRVAssembly = 13,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     RaygenShader = 14,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     AnyHitShader = 15,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     ClosestHitShader = 16,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     MissShader = 17,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     IntersectionShader = 18,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     CallableShader = 19,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_RaygenShader = 14,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_AnyHitShader = 15,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_ClosestHitShader = 16,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_MissShader = 17,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_IntersectionShader = 18,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_CallableShader = 19,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     shaderc_glsl_default_raygen_shader = 20,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultAnyHitShader = 21,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultClosestHitShader = 22,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultMissShader = 23,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultIntersectionShader = 24,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultCallableShader = 25,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     TaskShader = 26,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     MeshShader = 27,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_TaskShader = 26,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_MeshShader = 27,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultTaskShader = 28,

//     /// <summary>
//     /// Default shader kinds. Compiler will fall back to compile the source code as
//     /// the specified kind of shader when #pragma annotation is not found in the
//     /// source code.
//     /// </summary>
//     GLSL_DefaultMeshShader = 29,
// }

// /// <summary> The kinds of include requests. </summary>
// public enum shaderc_include_type : uint
// {
//     /// <summary>
//     /// E.g. #include "source"
//     /// </summary>
//     shaderc_include_type_relative = 0,

//     /// <summary>
//     /// E.g. #include 
//     /// &lt;source
//     /// &gt;
//     /// </summary>
//     shaderc_include_type_standard = 1,
// }
