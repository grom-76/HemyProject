namespace Hemy.Lib.V2.Platform.Windows;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

using const_char = System.Byte;
using BOOL = System.Int32;

// https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types
using size_t = System.UIntPtr;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;
using int32_t = System.Int32;
using int64_t = System.Int64;
using uint16_t = System.UInt16;

using VkBool32 = System.UInt32;
using VkDeviceAddress = System.UInt64;
using VkDeviceSize = System.UInt64;
using Flag = System.Int32;

using HRESULT = System.Int32;

using static Hemy.Lib.V2.Platform.Windows.WindowsGraphicCommon;
using static Hemy.Lib.V2.Platform.Windows.WindowsWindowCommon;
using Hemy.Lib.V2.Core;
using Bool32 = System.Int32; 

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class ShaderCompiler
{
    internal static void DisposeShaderCompil(byte* entrypointName, size_t length, const_char* bytescode)
    {
        
    }

    public static void CompilShader(string shaderSrc, byte* entrypointName, size_t length, const_char* bytescode)
    {
        // code : https://github.com/google/shaderc/blob/main/examples/online-compile/main.cc

        var compiler = CompilerInitialize();

        byte* shaderSource = WindowsMemory.New(shaderSrc);
        uint shaderSourceLength = (uint)shaderSrc.Length + 1U;

        byte* filename = WindowsMemory.New("shaderSourceName");

        var result = CompileIntoSpv(compiler, shaderSource, shaderSourceLength, ShaderKind.VertexShader, filename, entrypointName, null);

        var status = ResultGetCompilationStatus(result);

        if (status != CompilationStatus.Success)
        {
            var error = ResultGetErrorMessage(result);
        }
        else
        {
            length = ResultGetLength(result);
            bytescode = ResultGetBytes(result); // use in shader compil ?????? ( )

            // VkShaderModuleCreateInfo* createInfoVert = stackalloc VkShaderModuleCreateInfo[1];

            // createInfoVert[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
            // createInfoVert[0].codeSize = length;
            // createInfoVert[0].pCode = (uint*)bytecode;
            // createInfoVert[0].pNext = null;
            // createInfoVert[0].flags = 0;

            // VkShaderModule shaderModule = VkShaderModule.Null;
            // var Vertresult = Vk.vkCreateShaderModule(graphicData->Device, &createInfoVert[0], null, &shaderModule);
            // if (Vertresult != VkResult.VK_SUCCESS) Log.Error("Vertex ShaderModule ");

            // descriptor->ShaderModulesVertex = shaderModule;
        }

        WindowsMemory.Dispose(shaderSource);
        WindowsMemory.Dispose(filename);

        ResultRelease(result);
        CompilerRelease(compiler);
    }
    
    private const string LibraryName = "shaderc_shared.dll";

   
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compiler_initialize")]
    public unsafe static partial Compiler* CompilerInitialize();

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compiler_release")]
    public unsafe static partial void CompilerRelease(Compiler* arg0);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_initialize")]
    public unsafe static partial CompileOptions* CompileOptionsInitialize();

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_clone")]
    public unsafe static partial CompileOptions* CompileOptionsClone(CompileOptions* options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_release")]
    public unsafe static partial void CompileOptionsRelease(CompileOptions* options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_add_macro_definition")]
    public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/ byte* value, nuint value_length);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_add_macro_definition")]
    public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/  in byte value, nuint value_length);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_add_macro_definition")]
    public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/ byte* value, nuint value_length);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_add_macro_definition")]
    public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/ in byte value, nuint value_length);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_source_language")]
    public unsafe static partial void CompileOptionsSetSourceLanguage(CompileOptions* options, SourceLanguage lang);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_generate_debug_info")]
    public unsafe static partial void CompileOptionsSetGenerateDebugInfo(CompileOptions* options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_optimization_level")]
    public unsafe static partial void CompileOptionsSetOptimizationLevel(CompileOptions* options, OptimizationLevel level);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_forced_version_profile")]
    public unsafe static partial void CompileOptionsSetForcedVersionProfile(CompileOptions* options, int version, Profile profile);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_include_callbacks")]
    public unsafe static partial void CompileOptionsSetIncludeCallbacks(CompileOptions* options, PfnIncludeResolveFn resolver, PfnIncludeResultReleaseFn result_releaser, void* user_data);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_suppress_warnings")]
    public unsafe static partial void CompileOptionsSetSuppressWarnings(CompileOptions* options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_target_env")]
    public unsafe static partial void CompileOptionsSetTargetEnv(CompileOptions* options, TargetEnv target, uint version);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_target_spirv")]
    public unsafe static partial void CompileOptionsSetTargetSpirv(CompileOptions* options, SpirvVersion version);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_warnings_as_errors")]
    public unsafe static partial void CompileOptionsSetWarningsAsErrors(CompileOptions* options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_limit")]
    public unsafe static partial void CompileOptionsSetLimit(CompileOptions* options, Limit limit, int value);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_auto_bind_uniforms")]
    public unsafe static partial void CompileOptionsSetAutoBindUniforms(CompileOptions* options, Bool32 auto_bind);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_auto_combined_image_sampler")]
    public unsafe static partial void CompileOptionsSetAutoCombinedImageSampler(CompileOptions* options, Bool32 upgrade);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_io_mapping")]
    public unsafe static partial void CompileOptionsSetHlslIoMapping(CompileOptions* options, Bool32 hlsl_iomap);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_offsets")]
    public unsafe static partial void CompileOptionsSetHlslOffsets(CompileOptions* options, Bool32 hlsl_offsets);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_binding_base")]
    public unsafe static partial void CompileOptionsSetBindingBase(CompileOptions* options, UniformKind kind, uint @base);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_binding_base_for_stage")]
    public unsafe static partial void CompileOptionsSetBindingBaseForStage(CompileOptions* options, ShaderKind shader_kind, UniformKind kind, uint @base);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_preserve_bindings")]
    public unsafe static partial void CompileOptionsSetPreserveBindings(CompileOptions* options, Bool32 preserve_bindings);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_auto_map_locations")]
    public unsafe static partial void CompileOptionsSetAutoMapLocations(CompileOptions* options, Bool32 auto_map);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_functionality1")]
    public unsafe static partial void CompileOptionsSetHlslFunctionality1(CompileOptions* options, Bool32 enable);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_16bit_types")]
    public unsafe static partial void CompileOptionsSetHlsl16bitTypes(CompileOptions* options, Bool32 enable);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_vulkan_rules_relaxed")]
    public unsafe static partial void CompileOptionsSetVulkanRulesRelaxed(CompileOptions* options, Bool32 enable);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_invert_y")]
    public unsafe static partial void CompileOptionsSetInvertY(CompileOptions* options, Bool32 enable);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_nan_clamp")]
    public unsafe static partial void CompileOptionsSetNanClamp(CompileOptions* options, Bool32 enable);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_assemble_into_spv")]
    public unsafe static partial CompilationResult* AssembleIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_assembly, nuint source_assembly_size, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_assemble_into_spv")]
    public unsafe static partial CompilationResult* AssembleIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_assembly, nuint source_assembly_size, CompileOptions* additional_options);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_release")]
    public unsafe static partial void ResultRelease(CompilationResult* result);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_length")]
    public unsafe static partial nuint ResultGetLength(CompilationResult* result);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_num_warnings")]
    public unsafe static partial nuint ResultGetNumWarnings(CompilationResult* result);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_num_errors")]
    public unsafe static partial nuint ResultGetNumErrors(CompilationResult* result);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_compilation_status")]
    public unsafe static partial CompilationStatus ResultGetCompilationStatus(CompilationResult* arg0);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_bytes")]
    public unsafe static partial byte* ResultGetBytes(CompilationResult* result);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_error_message")]
    public unsafe static partial byte* ResultGetErrorMessage(CompilationResult* result);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_get_spv_version")]
    public unsafe static partial void GetSpvVersion(uint* version, uint* revision);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_get_spv_version")]
    public unsafe static partial void GetSpvVersion(uint* version, ref uint revision);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_get_spv_version")]
    public unsafe static partial void GetSpvVersion(ref uint version, uint* revision);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_get_spv_version")]
    public static partial void GetSpvVersion(ref uint version, ref uint revision);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ byte* str, int* version, Profile* profile);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ byte* str, int* version, ref Profile profile);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ byte* str, ref int version, Profile* profile);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ byte* str, ref int version, ref Profile profile);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ in byte str, int* version, Profile* profile);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ in byte str, int* version, ref Profile profile);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ in byte str, ref int version, Profile* profile);

    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ in byte str, ref int version, ref Profile profile);


    public unsafe readonly struct PfnIncludeResultReleaseFn : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<void*, IncludeResult*, void> Handle => (delegate* unmanaged[Cdecl]<void*, IncludeResult*, void>)_handle;
        public PfnIncludeResultReleaseFn
        (
            delegate* unmanaged[Cdecl]<void*, IncludeResult*, void> ptr
        ) => _handle = ptr;

        public PfnIncludeResultReleaseFn
        (
                IncludeResultReleaseFn proc
        ) => _handle = (void*)Marshal.GetFunctionPointerForDelegate(proc);

        public static PfnIncludeResultReleaseFn From(IncludeResultReleaseFn proc) => new PfnIncludeResultReleaseFn(proc);
        public void Dispose() => NativeMemory.Free(_handle);

        public static implicit operator nint(PfnIncludeResultReleaseFn pfn) => (nint)pfn.Handle;
        public static explicit operator PfnIncludeResultReleaseFn(nint pfn)
            => new PfnIncludeResultReleaseFn((delegate* unmanaged[Cdecl]<void*, IncludeResult*, void>)pfn);

        public static implicit operator PfnIncludeResultReleaseFn(IncludeResultReleaseFn proc)
            => new PfnIncludeResultReleaseFn(proc);

        // public static explicit operator IncludeResultReleaseFn(PfnIncludeResultReleaseFn pfn)
        //     => Marshal.GetFunctionPointerForDelegate<IncludeResultReleaseFn>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<void*, IncludeResult*, void>(PfnIncludeResultReleaseFn pfn) => pfn.Handle;
        public static implicit operator PfnIncludeResultReleaseFn(delegate* unmanaged[Cdecl]<void*, IncludeResult*, void> ptr) => new PfnIncludeResultReleaseFn(ptr);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void IncludeResultReleaseFn(void* arg0, IncludeResult* arg1);

    public unsafe readonly struct PfnIncludeResolveFn : IDisposable
    {
        private readonly void* _handle;
        public delegate* unmanaged[Cdecl]<void*, byte*, int, byte*, nuint, IncludeResult*> Handle => (delegate* unmanaged[Cdecl]<void*, byte*, int, byte*, nuint, IncludeResult*>)_handle;
        public PfnIncludeResolveFn
        (
            delegate* unmanaged[Cdecl]<void*, byte*, int, byte*, nuint, IncludeResult*> ptr
        ) => _handle = ptr;

        public PfnIncludeResolveFn
        (
                IncludeResolveFn proc
        ) => _handle = (void*)Marshal.GetFunctionPointerForDelegate(proc);

        public static PfnIncludeResolveFn From(IncludeResolveFn proc) => new PfnIncludeResolveFn(proc);
        public void Dispose() => NativeMemory.Free(_handle);

        public static implicit operator nint(PfnIncludeResolveFn pfn) => (nint)pfn.Handle;
        public static explicit operator PfnIncludeResolveFn(nint pfn)
            => new PfnIncludeResolveFn((delegate* unmanaged[Cdecl]<void*, byte*, int, byte*, nuint, IncludeResult*>)pfn);

        public static implicit operator PfnIncludeResolveFn(IncludeResolveFn proc)
            => new PfnIncludeResolveFn(proc);

        // public static explicit operator IncludeResolveFn(PfnIncludeResolveFn pfn)
        //     => Marshal.GetFunctionPointerForDelegate<IncludeResolveFn>(pfn);

        public static implicit operator delegate* unmanaged[Cdecl]<void*, byte*, int, byte*, nuint, IncludeResult*>(PfnIncludeResolveFn pfn) => pfn.Handle;
        public static implicit operator PfnIncludeResolveFn(delegate* unmanaged[Cdecl]<void*, byte*, int, byte*, nuint, IncludeResult*> ptr) => new PfnIncludeResolveFn(ptr);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate IncludeResult* IncludeResolveFn(void* arg0, byte* arg1, int arg2, byte* arg3, nuint arg4);

    public unsafe partial struct IncludeResult
    {
        public IncludeResult
        (
            byte* sourceName = null,
            nuint? sourceNameLength = null,
            byte* content = null,
            nuint? contentLength = null,
            void* userData = null
        ) : this()
        {
            if (sourceName is not null)
            {
                SourceName = sourceName;
            }

            if (sourceNameLength is not null)
            {
                SourceNameLength = sourceNameLength.Value;
            }

            if (content is not null)
            {
                Content = content;
            }

            if (contentLength is not null)
            {
                ContentLength = contentLength.Value;
            }

            if (userData is not null)
            {
                UserData = userData;
            }
        }

        public byte* SourceName;
        public nuint SourceNameLength;
        public byte* Content;
        public nuint ContentLength;
        public void* UserData;
    }

    public unsafe partial struct CompilationResult
    {
    }

    public unsafe partial struct CompileOptions
    {
    }

    public unsafe partial struct Compiler;

    public enum CompilationStatus : int
    {
        Success = 0x0,
        InvalidStage = 0x1,
        CompilationError = 0x2,
        InternalError = 0x3,
        NullResultObject = 0x4,
        InvalidAssembly = 0x5,
        ValidationError = 0x6,
        TransformationError = 0x7,
        ConfigurationError = 0x8,
    }

    public enum EnvVersion : int
    {
        Vulkan10 = 0x400000,
        Vulkan11 = 0x401000,
        Vulkan12 = 0x402000,
        Vulkan13 = 0x403000,
        Opengl45 = 0x1C2,
        Webgpu = 0x1C3,
    }

    public enum IncludeType : int
    {
        Relative = 0x0,
        Standard = 0x1,
    }

    public enum Limit : int
    {
        MaxLights = 0x0,
        MaxClipPlanes = 0x1,
        MaxTextureUnits = 0x2,
        MaxTextureCoords = 0x3,
        MaxVertexAttribs = 0x4,
        MaxVertexUniformComponents = 0x5,
        MaxVaryingFloats = 0x6,
        MaxVertexTextureImageUnits = 0x7,
        MaxCombinedTextureImageUnits = 0x8,
        MaxTextureImageUnits = 0x9,
        MaxFragmentUniformComponents = 0xA,
        MaxDrawBuffers = 0xB,
        MaxVertexUniformVectors = 0xC,
        MaxVaryingVectors = 0xD,
        MaxFragmentUniformVectors = 0xE,
        MaxVertexOutputVectors = 0xF,
        MaxFragmentInputVectors = 0x10,
        MinProgramTexelOffset = 0x11,
        MaxProgramTexelOffset = 0x12,
        MaxClipDistances = 0x13,
        MaxComputeWorkGroupCountX = 0x14,
        MaxComputeWorkGroupCountY = 0x15,
        MaxComputeWorkGroupCountZ = 0x16,
        MaxComputeWorkGroupSizeX = 0x17,
        MaxComputeWorkGroupSizeY = 0x18,
        MaxComputeWorkGroupSizeZ = 0x19,
        MaxComputeUniformComponents = 0x1A,
        MaxComputeTextureImageUnits = 0x1B,
        MaxComputeImageUniforms = 0x1C,
        MaxComputeAtomicCounters = 0x1D,
        MaxComputeAtomicCounterBuffers = 0x1E,
        MaxVaryingComponents = 0x1F,
        MaxVertexOutputComponents = 0x20,
        MaxGeometryInputComponents = 0x21,
        MaxGeometryOutputComponents = 0x22,
        MaxFragmentInputComponents = 0x23,
        MaxImageUnits = 0x24,
        MaxCombinedImageUnitsAndFragmentOutputs = 0x25,
        MaxCombinedShaderOutputResources = 0x26,
        MaxImageSamples = 0x27,
        MaxVertexImageUniforms = 0x28,
        MaxTessControlImageUniforms = 0x29,
        MaxTessEvaluationImageUniforms = 0x2A,
        MaxGeometryImageUniforms = 0x2B,
        MaxFragmentImageUniforms = 0x2C,
        MaxCombinedImageUniforms = 0x2D,
        MaxGeometryTextureImageUnits = 0x2E,
        MaxGeometryOutputVertices = 0x2F,
        MaxGeometryTotalOutputComponents = 0x30,
        MaxGeometryUniformComponents = 0x31,
        MaxGeometryVaryingComponents = 0x32,
        MaxTessControlInputComponents = 0x33,
        MaxTessControlOutputComponents = 0x34,
        MaxTessControlTextureImageUnits = 0x35,
        MaxTessControlUniformComponents = 0x36,
        MaxTessControlTotalOutputComponents = 0x37,
        MaxTessEvaluationInputComponents = 0x38,
        MaxTessEvaluationOutputComponents = 0x39,
        MaxTessEvaluationTextureImageUnits = 0x3A,
        MaxTessEvaluationUniformComponents = 0x3B,
        MaxTessPatchComponents = 0x3C,
        MaxPatchVertices = 0x3D,
        MaxTessGenLevel = 0x3E,
        MaxViewports = 0x3F,
        MaxVertexAtomicCounters = 0x40,
        MaxTessControlAtomicCounters = 0x41,
        MaxTessEvaluationAtomicCounters = 0x42,
        MaxGeometryAtomicCounters = 0x43,
        MaxFragmentAtomicCounters = 0x44,
        MaxCombinedAtomicCounters = 0x45,
        MaxAtomicCounterBindings = 0x46,
        MaxVertexAtomicCounterBuffers = 0x47,
        MaxTessControlAtomicCounterBuffers = 0x48,
        MaxTessEvaluationAtomicCounterBuffers = 0x49,
        MaxGeometryAtomicCounterBuffers = 0x4A,
        MaxFragmentAtomicCounterBuffers = 0x4B,
        MaxCombinedAtomicCounterBuffers = 0x4C,
        MaxAtomicCounterBufferSize = 0x4D,
        MaxTransformFeedbackBuffers = 0x4E,
        MaxTransformFeedbackInterleavedComponents = 0x4F,
        MaxCullDistances = 0x50,
        MaxCombinedClipAndCullDistances = 0x51,
        MaxSamples = 0x52,
        MaxMeshOutputVerticesNv = 0x53,
        MaxMeshOutputPrimitivesNv = 0x54,
        MaxMeshWorkGroupSizeXNv = 0x55,
        MaxMeshWorkGroupSizeYNv = 0x56,
        MaxMeshWorkGroupSizeZNv = 0x57,
        MaxTaskWorkGroupSizeXNv = 0x58,
        MaxTaskWorkGroupSizeYNv = 0x59,
        MaxTaskWorkGroupSizeZNv = 0x5A,
        MaxMeshViewCountNv = 0x5B,
        MaxMeshOutputVerticesExt = 0x5C,
        MaxMeshOutputPrimitivesExt = 0x5D,
        MaxMeshWorkGroupSizeXExt = 0x5E,
        MaxMeshWorkGroupSizeYExt = 0x5F,
        MaxMeshWorkGroupSizeZExt = 0x60,
        MaxTaskWorkGroupSizeXExt = 0x61,
        MaxTaskWorkGroupSizeYExt = 0x62,
        MaxTaskWorkGroupSizeZExt = 0x63,
        MaxMeshViewCountExt = 0x64,
        MaxDualSourceDrawBuffersExt = 0x65,
    }

    public enum OptimizationLevel : int
    {
        Zero = 0x0,
        Size = 0x1,
        Performance = 0x2,
    }

    public enum Profile : int
    {
        None = 0x0,
        Core = 0x1,
        Compatibility = 0x2,
        Es = 0x3,
    }

    public enum ShaderKind : int
    {
        VertexShader = 0x0,
        FragmentShader = 0x1,
        ComputeShader = 0x2,
        GeometryShader = 0x3,
        TessControlShader = 0x4,
        TessEvaluationShader = 0x5,
        GlslVertexShader = 0x0,
        GlslFragmentShader = 0x1,
        GlslComputeShader = 0x2,
        GlslGeometryShader = 0x3,
        GlslTessControlShader = 0x4,
        GlslTessEvaluationShader = 0x5,
        GlslInferFromSource = 0x6,
        GlslDefaultVertexShader = 0x7,
        GlslDefaultFragmentShader = 0x8,
        GlslDefaultComputeShader = 0x9,
        GlslDefaultGeometryShader = 0xA,
        GlslDefaultTessControlShader = 0xB,
        GlslDefaultTessEvaluationShader = 0xC,
        SpirvAssembly = 0xD,
        RaygenShader = 0xE,
        AnyhitShader = 0xF,
        ClosesthitShader = 0x10,
        MissShader = 0x11,
        IntersectionShader = 0x12,
        CallableShader = 0x13,
        GlslRaygenShader = 0xE,
        GlslAnyhitShader = 0xF,
        GlslClosesthitShader = 0x10,
        GlslMissShader = 0x11,
        GlslIntersectionShader = 0x12,
        GlslCallableShader = 0x13,
        GlslDefaultRaygenShader = 0x14,
        GlslDefaultAnyhitShader = 0x15,
        GlslDefaultClosesthitShader = 0x16,
        GlslDefaultMissShader = 0x17,
        GlslDefaultIntersectionShader = 0x18,
        GlslDefaultCallableShader = 0x19,
        TaskShader = 0x1A,
        MeshShader = 0x1B,
        GlslTaskShader = 0x1A,
        GlslMeshShader = 0x1B,
        GlslDefaultTaskShader = 0x1C,
        GlslDefaultMeshShader = 0x1D,
    }

    public enum SourceLanguage : int
    {
        Glsl = 0x0,
        Hlsl = 0x1,
    }

    public enum SpirvVersion : int
    {
        Shaderc10 = 0x10000,
        Shaderc11 = 0x10100,
        Shaderc12 = 0x10200,
        Shaderc13 = 0x10300,
        Shaderc14 = 0x10400,
        Shaderc15 = 0x10500,
        Shaderc16 = 0x10600,
    }

    public enum TargetEnv : int
    {
        Vulkan = 0x0,
        Opengl = 0x1,
        OpenglCompat = 0x2,
        Webgpu = 0x3,
        Default = 0x0,
    }

    public enum UniformKind : int
    {
        Image = 0x0,
        Sampler = 0x1,
        Texture = 0x2,
        Buffer = 0x3,
        StorageBuffer = 0x4,
        UnorderedAccessView = 0x5,
    }


}