// namespace Hemy.Lib.Tools.Shaders.ShaderCompiler;

// using System;
// using System.Runtime.InteropServices;
// using System.Text;

<<<<<<< HEAD
using Bool32 = System.Int32; 

internal static unsafe partial class Native
{
    private const string LibraryName =
#if WINDOWS
     "shaderc_shared.dll";
#elif LINUX
"libshaderc_shared.so" ;
#elif MAC
"libshaderc_shared.dylib"
#elif ANDROID
 "libshaderc_shared.so"
#endif

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 268, Column 35 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compiler_initialize")]
    public unsafe static partial Compiler* CompilerInitialize();

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 273, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compiler_release")]
    public unsafe static partial void CompilerRelease(Compiler* arg0);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 285, Column 5 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_initialize")]
    public unsafe static partial CompileOptions* CompileOptionsInitialize();

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 290, Column 42 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_clone")]
    public unsafe static partial CompileOptions* CompileOptionsClone(CompileOptions* options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 296, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_release")]
    public unsafe static partial void CompileOptionsRelease(CompileOptions* options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 310, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_add_macro_definition")]
    public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/ byte* value, nuint value_length);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 310, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_add_macro_definition")]
    public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/  in byte value, nuint value_length);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 310, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName,EntryPoint = "shaderc_compile_options_add_macro_definition")]
    // public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* name, nuint name_length, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string value, nuint value_length);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 310, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_add_macro_definition")]
    public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/ byte* value, nuint value_length);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 310, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_add_macro_definition")]
    public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/ in byte value, nuint value_length);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 310, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName,EntryPoint = "shaderc_compile_options_add_macro_definition")]
    // public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte name, nuint name_length, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string value, nuint value_length);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 310, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName,EntryPoint = "shaderc_compile_options_add_macro_definition")]
    // public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/ byte* value, nuint value_length);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 310, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName,EntryPoint = "shaderc_compile_options_add_macro_definition")]
    // public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string name, nuint name_length, /*[Flow(Native.FlowDirection.In)]*/ in byte value, nuint value_length);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 310, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName,EntryPoint = "shaderc_compile_options_add_macro_definition")]
    // public unsafe static partial void CompileOptionsAddMacroDefinition(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string name, nuint name_length, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string value, nuint value_length);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 315, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_source_language")]
    public unsafe static partial void CompileOptionsSetSourceLanguage(CompileOptions* options, SourceLanguage lang);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 319, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_generate_debug_info")]
    public unsafe static partial void CompileOptionsSetGenerateDebugInfo(CompileOptions* options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 324, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_optimization_level")]
    public unsafe static partial void CompileOptionsSetOptimizationLevel(CompileOptions* options, OptimizationLevel level);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 332, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_forced_version_profile")]
    public unsafe static partial void CompileOptionsSetForcedVersionProfile(CompileOptions* options, int version, Profile profile);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 384, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_include_callbacks")]
    public unsafe static partial void CompileOptionsSetIncludeCallbacks(CompileOptions* options, PfnIncludeResolveFn resolver, PfnIncludeResultReleaseFn result_releaser, void* user_data);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 384, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName,EntryPoint = "shaderc_compile_options_set_include_callbacks")]
    // public unsafe static partial void CompileOptionsSetIncludeCallbacks<T0>(CompileOptions* options, PfnIncludeResolveFn resolver, PfnIncludeResultReleaseFn result_releaser, ref T0 user_data) where T0 : unmanaged;

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 392, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_suppress_warnings")]
    public unsafe static partial void CompileOptionsSetSuppressWarnings(CompileOptions* options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 400, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_target_env")]
    public unsafe static partial void CompileOptionsSetTargetEnv(CompileOptions* options, TargetEnv target, uint version);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 410, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_target_spirv")]
    public unsafe static partial void CompileOptionsSetTargetSpirv(CompileOptions* options, SpirvVersion version);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 417, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_warnings_as_errors")]
    public unsafe static partial void CompileOptionsSetWarningsAsErrors(CompileOptions* options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 421, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_limit")]
    public unsafe static partial void CompileOptionsSetLimit(CompileOptions* options, Limit limit, int value);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 426, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_auto_bind_uniforms")]
    public unsafe static partial void CompileOptionsSetAutoBindUniforms(CompileOptions* options, Bool32 auto_bind);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 431, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_auto_combined_image_sampler")]
    public unsafe static partial void CompileOptionsSetAutoCombinedImageSampler(CompileOptions* options, Bool32 upgrade);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 436, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_io_mapping")]
    public unsafe static partial void CompileOptionsSetHlslIoMapping(CompileOptions* options, Bool32 hlsl_iomap);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 442, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_offsets")]
    public unsafe static partial void CompileOptionsSetHlslOffsets(CompileOptions* options, Bool32 hlsl_offsets);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 449, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_binding_base")]
    public unsafe static partial void CompileOptionsSetBindingBase(CompileOptions* options, UniformKind kind, uint @base);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 457, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_binding_base_for_stage")]
    public unsafe static partial void CompileOptionsSetBindingBaseForStage(CompileOptions* options, ShaderKind shader_kind, UniformKind kind, uint @base);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 463, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_preserve_bindings")]
    public unsafe static partial void CompileOptionsSetPreserveBindings(CompileOptions* options, Bool32 preserve_bindings);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 468, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_auto_map_locations")]
    public unsafe static partial void CompileOptionsSetAutoMapLocations(CompileOptions* options, Bool32 auto_map);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 473, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBindingForStage(CompileOptions* options, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ byte* reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, /*[Flow(Native.FlowDirection.In)]*/ in byte reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ byte* set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, /*[Flow(Native.FlowDirection.In)]*/ in byte set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ byte* binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, /*[Flow(Native.FlowDirection.In)]*/ in byte binding);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 479, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_register_set_and_binding")]
    // public unsafe static partial void CompileOptionsSetHlslRegisterSetAndBinding(CompileOptions* options, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string reg, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string set, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string binding);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 485, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_functionality1")]
    public unsafe static partial void CompileOptionsSetHlslFunctionality1(CompileOptions* options, Bool32 enable);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 489, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_hlsl_16bit_types")]
    public unsafe static partial void CompileOptionsSetHlsl16bitTypes(CompileOptions* options, Bool32 enable);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 495, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_vulkan_rules_relaxed")]
    public unsafe static partial void CompileOptionsSetVulkanRulesRelaxed(CompileOptions* options, Bool32 enable);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 499, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_invert_y")]
    public unsafe static partial void CompileOptionsSetInvertY(CompileOptions* options, Bool32 enable);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 506, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_options_set_nan_clamp")]
    public unsafe static partial void CompileOptionsSetNanClamp(CompileOptions* options, Bool32 enable);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 532, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv")]
    // public unsafe static partial CompilationResult* CompileIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 541, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_spv_assembly")]
    // public unsafe static partial CompilationResult* CompileIntoSpvAssembly(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ byte* input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, /*[Flow(Native.FlowDirection.In)]*/ in byte input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ byte* entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, /*[Flow(Native.FlowDirection.In)]*/ in byte entry_point_name, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 549, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_compile_into_preprocessed_text")]
    // public unsafe static partial CompilationResult* CompileIntoPreprocessedText(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_text, nuint source_text_size, ShaderKind shader_kind, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string input_file_name, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string entry_point_name, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 564, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_assemble_into_spv")]
    public unsafe static partial CompilationResult* AssembleIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ byte* source_assembly, nuint source_assembly_size, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 564, Column 45 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_assemble_into_spv")]
    public unsafe static partial CompilationResult* AssembleIntoSpv(Compiler* compiler, /*[Flow(Native.FlowDirection.In)]*/ in byte source_assembly, nuint source_assembly_size, CompileOptions* additional_options);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 564, Column 45 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_assemble_into_spv")]
    // public unsafe static partial CompilationResult* AssembleIntoSpv(Compiler* compiler, [Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string source_assembly, nuint source_assembly_size, CompileOptions* additional_options);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 574, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_release")]
    public unsafe static partial void ResultRelease(CompilationResult* result);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 578, Column 23 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_length")]
    public unsafe static partial nuint ResultGetLength(CompilationResult* result);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 581, Column 23 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_num_warnings")]
    public unsafe static partial nuint ResultGetNumWarnings(CompilationResult* result);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 585, Column 23 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_num_errors")]
    public unsafe static partial nuint ResultGetNumErrors(CompilationResult* result);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 590, Column 43 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_compilation_status")]
    public unsafe static partial CompilationStatus ResultGetCompilationStatus(CompilationResult* arg0);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 598, Column 28 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_bytes")]
    public unsafe static partial byte* ResultGetBytes(CompilationResult* result);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 598, Column 28 in shaderc.h")]
    // [return: UnmanagedType(Native.UnmanagedType.LPUTF8Str)]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_bytes")]
    // public unsafe static partial string ResultGetBytesS(CompilationResult* result);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 602, Column 28 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_error_message")]
    public unsafe static partial byte* ResultGetErrorMessage(CompilationResult* result);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 602, Column 28 in shaderc.h")]
    // [return: UnmanagedType(Native.UnmanagedType.LPUTF8Str)]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_result_get_error_message")]
    // public unsafe static partial string ResultGetErrorMessageS(CompilationResult* result);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 606, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_get_spv_version")]
    public unsafe static partial void GetSpvVersion(uint* version, uint* revision);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 606, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_get_spv_version")]
    public unsafe static partial void GetSpvVersion(uint* version, ref uint revision);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 606, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_get_spv_version")]
    public unsafe static partial void GetSpvVersion(ref uint version, uint* revision);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 606, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_get_spv_version")]
    public static partial void GetSpvVersion(ref uint version, ref uint revision);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ byte* str, int* version, Profile* profile);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ byte* str, int* version, ref Profile profile);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ byte* str, ref int version, Profile* profile);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ byte* str, ref int version, ref Profile profile);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ in byte str, int* version, Profile* profile);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ in byte str, int* version, ref Profile profile);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public unsafe static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ in byte str, ref int version, Profile* profile);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    public static partial Bool32 ParseVersionProfile(/*[Flow(Native.FlowDirection.In)]*/ in byte str, ref int version, ref Profile profile);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    // public unsafe static partial Bool32 ParseVersionProfile([Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string str, int* version, Profile* profile);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    // public unsafe static partial Bool32 ParseVersionProfile([Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string str, int* version, ref Profile profile);

    // /// <summary>To be documented.</summary>
    // // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    // public unsafe static partial Bool32 ParseVersionProfile([Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string str, ref int version, Profile* profile);

    /// <summary>To be documented.</summary>
    // [NativeName     ("Src", "Line 612, Column 21 in shaderc.h")]
    // [LibraryImport(LibraryName, EntryPoint = "shaderc_parse_version_profile")]
    // public static partial Bool32 ParseVersionProfile([Flow(Native.FlowDirection.In), UnmanagedType(Native.UnmanagedType.LPUTF8Str)] string str, ref int version, ref Profile profile);



}

public unsafe readonly struct PfnIncludeResultReleaseFn : IDisposable
{
    private readonly void* _handle;
    public delegate* unmanaged[Cdecl]<void*, IncludeResult*, void> Handle => (delegate* unmanaged[Cdecl]<void*, IncludeResult*, void>) _handle;
    public PfnIncludeResultReleaseFn
    (
        delegate* unmanaged[Cdecl]<void*, IncludeResult*, void> ptr
    ) => _handle = ptr;

    public PfnIncludeResultReleaseFn
    (
            IncludeResultReleaseFn proc
    ) => _handle = (void*) Marshal.GetFunctionPointerForDelegate(proc);

    public static PfnIncludeResultReleaseFn From(IncludeResultReleaseFn proc) => new PfnIncludeResultReleaseFn(proc);
    public void Dispose() => NativeMemory.Free( _handle);

    public static implicit operator nint(PfnIncludeResultReleaseFn pfn) => (nint) pfn.Handle;
    public static explicit operator PfnIncludeResultReleaseFn(nint pfn)
        => new PfnIncludeResultReleaseFn((delegate* unmanaged[Cdecl]<void*, IncludeResult*, void>) pfn);

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


// [NativeName     ("Name", "shaderc_include_result")]
public unsafe  partial struct IncludeResult
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


    // [NativeName     ("Type", "const char *")]
    // [NativeName     ("Type.Name", "const char *")]
    // [NativeName     ("Name", "source_name")]
    public byte* SourceName;

    // [NativeName     ("Type", "size_t")]
    // [NativeName     ("Type.Name", "size_t")]
    // [NativeName     ("Name", "source_name_length")]
    public nuint SourceNameLength;

    // [NativeName     ("Type", "const char *")]
    // [NativeName     ("Type.Name", "const char *")]
    // [NativeName     ("Name", "content")]
    public byte* Content;

    // [NativeName     ("Type", "size_t")]
    // [NativeName     ("Type.Name", "size_t")]
    // [NativeName     ("Name", "content_length")]
    public nuint ContentLength;

    // [NativeName     ("Type", "void *")]
    // [NativeName     ("Type.Name", "void *")]
    // [NativeName     ("Name", "user_data")]
    public void* UserData;
}
// [NativeName     ("Name", "shaderc_compilation_result")]
public unsafe  partial struct CompilationResult
{
}

// [NativeName     ("Name", "shaderc_compile_options")]
public unsafe  partial struct CompileOptions
{
}

// [NativeName     ("Name", "shaderc_compiler")]
public unsafe  partial struct Compiler
{
}

// [NativeName     ("Name", "shaderc_compilation_status")]
public enum CompilationStatus : int
{
// [NativeName     ("Name", "shaderc_compilation_status_success")]
Success = 0x0,
// [NativeName     ("Name", "shaderc_compilation_status_invalid_stage")]
InvalidStage = 0x1,
// [NativeName     ("Name", "shaderc_compilation_status_compilation_error")]
CompilationError = 0x2,
// [NativeName     ("Name", "shaderc_compilation_status_internal_error")]
InternalError = 0x3,
// [NativeName     ("Name", "shaderc_compilation_status_null_result_object")]
NullResultObject = 0x4,
// [NativeName     ("Name", "shaderc_compilation_status_invalid_assembly")]
InvalidAssembly = 0x5,
// [NativeName     ("Name", "shaderc_compilation_status_validation_error")]
ValidationError = 0x6,
// [NativeName     ("Name", "shaderc_compilation_status_transformation_error")]
TransformationError = 0x7,
// [NativeName     ("Name", "shaderc_compilation_status_configuration_error")]
ConfigurationError = 0x8,
}

// [NativeName     ("Name", "shaderc_env_version")]
public enum EnvVersion : int
{
    // [NativeName     ("Name", "shaderc_env_version_vulkan_1_0")]
    Vulkan10 = 0x400000,
    // [NativeName     ("Name", "shaderc_env_version_vulkan_1_1")]
    Vulkan11 = 0x401000,
    // [NativeName     ("Name", "shaderc_env_version_vulkan_1_2")]
    Vulkan12 = 0x402000,
    // [NativeName     ("Name", "shaderc_env_version_vulkan_1_3")]
    Vulkan13 = 0x403000,
    // [NativeName     ("Name", "shaderc_env_version_opengl_4_5")]
    Opengl45 = 0x1C2,
    // [NativeName     ("Name", "shaderc_env_version_webgpu")]
    Webgpu = 0x1C3,
}

// [NativeName     ("Name", "shaderc_include_type")]
public enum IncludeType : int
{
    // [NativeName     ("Name", "shaderc_include_type_relative")]
    Relative = 0x0,
    // [NativeName     ("Name", "shaderc_include_type_standard")]
    Standard = 0x1,
}

    // [NativeName     ("Name", "shaderc_limit")]
public enum Limit : int
{
    // [NativeName     ("Name", "shaderc_limit_max_lights")]
    MaxLights = 0x0,
    // [NativeName     ("Name", "shaderc_limit_max_clip_planes")]
    MaxClipPlanes = 0x1,
    // [NativeName     ("Name", "shaderc_limit_max_texture_units")]
    MaxTextureUnits = 0x2,
    // [NativeName     ("Name", "shaderc_limit_max_texture_coords")]
    MaxTextureCoords = 0x3,
    // [NativeName     ("Name", "shaderc_limit_max_vertex_attribs")]
    MaxVertexAttribs = 0x4,
    // [NativeName     ("Name", "shaderc_limit_max_vertex_uniform_components")]
    MaxVertexUniformComponents = 0x5,
    // [NativeName     ("Name", "shaderc_limit_max_varying_floats")]
    MaxVaryingFloats = 0x6,
    // [NativeName     ("Name", "shaderc_limit_max_vertex_texture_image_units")]
    MaxVertexTextureImageUnits = 0x7,
    // [NativeName     ("Name", "shaderc_limit_max_combined_texture_image_units")]
    MaxCombinedTextureImageUnits = 0x8,
    // [NativeName     ("Name", "shaderc_limit_max_texture_image_units")]
    MaxTextureImageUnits = 0x9,
    // [NativeName     ("Name", "shaderc_limit_max_fragment_uniform_components")]
    MaxFragmentUniformComponents = 0xA,
    // [NativeName     ("Name", "shaderc_limit_max_draw_buffers")]
    MaxDrawBuffers = 0xB,
    // [NativeName     ("Name", "shaderc_limit_max_vertex_uniform_vectors")]
    MaxVertexUniformVectors = 0xC,
    // [NativeName     ("Name", "shaderc_limit_max_varying_vectors")]
    MaxVaryingVectors = 0xD,
    // [NativeName     ("Name", "shaderc_limit_max_fragment_uniform_vectors")]
    MaxFragmentUniformVectors = 0xE,
    // [NativeName     ("Name", "shaderc_limit_max_vertex_output_vectors")]
    MaxVertexOutputVectors = 0xF,
    // [NativeName     ("Name", "shaderc_limit_max_fragment_input_vectors")]
    MaxFragmentInputVectors = 0x10,
    // [NativeName     ("Name", "shaderc_limit_min_program_texel_offset")]
    MinProgramTexelOffset = 0x11,
    // [NativeName     ("Name", "shaderc_limit_max_program_texel_offset")]
    MaxProgramTexelOffset = 0x12,
    // [NativeName     ("Name", "shaderc_limit_max_clip_distances")]
    MaxClipDistances = 0x13,
    // [NativeName     ("Name", "shaderc_limit_max_compute_work_group_count_x")]
    MaxComputeWorkGroupCountX = 0x14,
    // [NativeName     ("Name", "shaderc_limit_max_compute_work_group_count_y")]
    MaxComputeWorkGroupCountY = 0x15,
    // [NativeName     ("Name", "shaderc_limit_max_compute_work_group_count_z")]
    MaxComputeWorkGroupCountZ = 0x16,
    // [NativeName     ("Name", "shaderc_limit_max_compute_work_group_size_x")]
    MaxComputeWorkGroupSizeX = 0x17,
    // [NativeName     ("Name", "shaderc_limit_max_compute_work_group_size_y")]
    MaxComputeWorkGroupSizeY = 0x18,
    // [NativeName     ("Name", "shaderc_limit_max_compute_work_group_size_z")]
    MaxComputeWorkGroupSizeZ = 0x19,
    // [NativeName     ("Name", "shaderc_limit_max_compute_uniform_components")]
    MaxComputeUniformComponents = 0x1A,
    // [NativeName     ("Name", "shaderc_limit_max_compute_texture_image_units")]
    MaxComputeTextureImageUnits = 0x1B,
    // [NativeName     ("Name", "shaderc_limit_max_compute_image_uniforms")]
    MaxComputeImageUniforms = 0x1C,
    // [NativeName     ("Name", "shaderc_limit_max_compute_atomic_counters")]
    MaxComputeAtomicCounters = 0x1D,
    // [NativeName     ("Name", "shaderc_limit_max_compute_atomic_counter_buffers")]
    MaxComputeAtomicCounterBuffers = 0x1E,
    // [NativeName     ("Name", "shaderc_limit_max_varying_components")]
    MaxVaryingComponents = 0x1F,
    // [NativeName     ("Name", "shaderc_limit_max_vertex_output_components")]
    MaxVertexOutputComponents = 0x20,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_input_components")]
    MaxGeometryInputComponents = 0x21,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_output_components")]
    MaxGeometryOutputComponents = 0x22,
    // [NativeName     ("Name", "shaderc_limit_max_fragment_input_components")]
    MaxFragmentInputComponents = 0x23,
    // [NativeName     ("Name", "shaderc_limit_max_image_units")]
    MaxImageUnits = 0x24,
    // [NativeName     ("Name", "shaderc_limit_max_combined_image_units_and_fragment_outputs")]
    MaxCombinedImageUnitsAndFragmentOutputs = 0x25,
    // [NativeName     ("Name", "shaderc_limit_max_combined_shader_output_resources")]
    MaxCombinedShaderOutputResources = 0x26,
    // [NativeName     ("Name", "shaderc_limit_max_image_samples")]
    MaxImageSamples = 0x27,
    // [NativeName     ("Name", "shaderc_limit_max_vertex_image_uniforms")]
    MaxVertexImageUniforms = 0x28,
    // [NativeName     ("Name", "shaderc_limit_max_tess_control_image_uniforms")]
    MaxTessControlImageUniforms = 0x29,
    // [NativeName     ("Name", "shaderc_limit_max_tess_evaluation_image_uniforms")]
    MaxTessEvaluationImageUniforms = 0x2A,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_image_uniforms")]
    MaxGeometryImageUniforms = 0x2B,
    // [NativeName     ("Name", "shaderc_limit_max_fragment_image_uniforms")]
    MaxFragmentImageUniforms = 0x2C,
    // [NativeName     ("Name", "shaderc_limit_max_combined_image_uniforms")]
    MaxCombinedImageUniforms = 0x2D,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_texture_image_units")]
    MaxGeometryTextureImageUnits = 0x2E,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_output_vertices")]
    MaxGeometryOutputVertices = 0x2F,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_total_output_components")]
    MaxGeometryTotalOutputComponents = 0x30,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_uniform_components")]
    MaxGeometryUniformComponents = 0x31,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_varying_components")]
    MaxGeometryVaryingComponents = 0x32,
    // [NativeName     ("Name", "shaderc_limit_max_tess_control_input_components")]
    MaxTessControlInputComponents = 0x33,
    // [NativeName     ("Name", "shaderc_limit_max_tess_control_output_components")]
    MaxTessControlOutputComponents = 0x34,
    // [NativeName     ("Name", "shaderc_limit_max_tess_control_texture_image_units")]
    MaxTessControlTextureImageUnits = 0x35,
    // [NativeName     ("Name", "shaderc_limit_max_tess_control_uniform_components")]
    MaxTessControlUniformComponents = 0x36,
    // [NativeName     ("Name", "shaderc_limit_max_tess_control_total_output_components")]
    MaxTessControlTotalOutputComponents = 0x37,
    // [NativeName     ("Name", "shaderc_limit_max_tess_evaluation_input_components")]
    MaxTessEvaluationInputComponents = 0x38,
    // [NativeName     ("Name", "shaderc_limit_max_tess_evaluation_output_components")]
    MaxTessEvaluationOutputComponents = 0x39,
    // [NativeName     ("Name", "shaderc_limit_max_tess_evaluation_texture_image_units")]
    MaxTessEvaluationTextureImageUnits = 0x3A,
    // [NativeName     ("Name", "shaderc_limit_max_tess_evaluation_uniform_components")]
    MaxTessEvaluationUniformComponents = 0x3B,
    // [NativeName     ("Name", "shaderc_limit_max_tess_patch_components")]
    MaxTessPatchComponents = 0x3C,
    // [NativeName     ("Name", "shaderc_limit_max_patch_vertices")]
    MaxPatchVertices = 0x3D,
    // [NativeName     ("Name", "shaderc_limit_max_tess_gen_level")]
    MaxTessGenLevel = 0x3E,
    // [NativeName     ("Name", "shaderc_limit_max_viewports")]
    MaxViewports = 0x3F,
    // [NativeName     ("Name", "shaderc_limit_max_vertex_atomic_counters")]
    MaxVertexAtomicCounters = 0x40,
    // [NativeName     ("Name", "shaderc_limit_max_tess_control_atomic_counters")]
    MaxTessControlAtomicCounters = 0x41,
    // [NativeName     ("Name", "shaderc_limit_max_tess_evaluation_atomic_counters")]
    MaxTessEvaluationAtomicCounters = 0x42,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_atomic_counters")]
    MaxGeometryAtomicCounters = 0x43,
    // [NativeName     ("Name", "shaderc_limit_max_fragment_atomic_counters")]
    MaxFragmentAtomicCounters = 0x44,
    // [NativeName     ("Name", "shaderc_limit_max_combined_atomic_counters")]
    MaxCombinedAtomicCounters = 0x45,
    // [NativeName     ("Name", "shaderc_limit_max_atomic_counter_bindings")]
    MaxAtomicCounterBindings = 0x46,
    // [NativeName     ("Name", "shaderc_limit_max_vertex_atomic_counter_buffers")]
    MaxVertexAtomicCounterBuffers = 0x47,
    // [NativeName     ("Name", "shaderc_limit_max_tess_control_atomic_counter_buffers")]
    MaxTessControlAtomicCounterBuffers = 0x48,
    // [NativeName     ("Name", "shaderc_limit_max_tess_evaluation_atomic_counter_buffers")]
    MaxTessEvaluationAtomicCounterBuffers = 0x49,
    // [NativeName     ("Name", "shaderc_limit_max_geometry_atomic_counter_buffers")]
    MaxGeometryAtomicCounterBuffers = 0x4A,
    // [NativeName     ("Name", "shaderc_limit_max_fragment_atomic_counter_buffers")]
    MaxFragmentAtomicCounterBuffers = 0x4B,
    // [NativeName     ("Name", "shaderc_limit_max_combined_atomic_counter_buffers")]
    MaxCombinedAtomicCounterBuffers = 0x4C,
    // [NativeName     ("Name", "shaderc_limit_max_atomic_counter_buffer_size")]
    MaxAtomicCounterBufferSize = 0x4D,
    // [NativeName     ("Name", "shaderc_limit_max_transform_feedback_buffers")]
    MaxTransformFeedbackBuffers = 0x4E,
    // [NativeName     ("Name", "shaderc_limit_max_transform_feedback_interleaved_components")]
    MaxTransformFeedbackInterleavedComponents = 0x4F,
    // [NativeName     ("Name", "shaderc_limit_max_cull_distances")]
    MaxCullDistances = 0x50,
    // [NativeName     ("Name", "shaderc_limit_max_combined_clip_and_cull_distances")]
    MaxCombinedClipAndCullDistances = 0x51,
    // [NativeName     ("Name", "shaderc_limit_max_samples")]
    MaxSamples = 0x52,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_output_vertices_nv")]
    MaxMeshOutputVerticesNv = 0x53,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_output_primitives_nv")]
    MaxMeshOutputPrimitivesNv = 0x54,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_work_group_size_x_nv")]
    MaxMeshWorkGroupSizeXNv = 0x55,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_work_group_size_y_nv")]
    MaxMeshWorkGroupSizeYNv = 0x56,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_work_group_size_z_nv")]
    MaxMeshWorkGroupSizeZNv = 0x57,
    // [NativeName     ("Name", "shaderc_limit_max_task_work_group_size_x_nv")]
    MaxTaskWorkGroupSizeXNv = 0x58,
    // [NativeName     ("Name", "shaderc_limit_max_task_work_group_size_y_nv")]
    MaxTaskWorkGroupSizeYNv = 0x59,
    // [NativeName     ("Name", "shaderc_limit_max_task_work_group_size_z_nv")]
    MaxTaskWorkGroupSizeZNv = 0x5A,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_view_count_nv")]
    MaxMeshViewCountNv = 0x5B,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_output_vertices_ext")]
    MaxMeshOutputVerticesExt = 0x5C,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_output_primitives_ext")]
    MaxMeshOutputPrimitivesExt = 0x5D,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_work_group_size_x_ext")]
    MaxMeshWorkGroupSizeXExt = 0x5E,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_work_group_size_y_ext")]
    MaxMeshWorkGroupSizeYExt = 0x5F,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_work_group_size_z_ext")]
    MaxMeshWorkGroupSizeZExt = 0x60,
    // [NativeName     ("Name", "shaderc_limit_max_task_work_group_size_x_ext")]
    MaxTaskWorkGroupSizeXExt = 0x61,
    // [NativeName     ("Name", "shaderc_limit_max_task_work_group_size_y_ext")]
    MaxTaskWorkGroupSizeYExt = 0x62,
    // [NativeName     ("Name", "shaderc_limit_max_task_work_group_size_z_ext")]
    MaxTaskWorkGroupSizeZExt = 0x63,
    // [NativeName     ("Name", "shaderc_limit_max_mesh_view_count_ext")]
    MaxMeshViewCountExt = 0x64,
    // [NativeName     ("Name", "shaderc_limit_max_dual_source_draw_buffers_ext")]
    MaxDualSourceDrawBuffersExt = 0x65,
}


// [NativeName     ("Name", "shaderc_optimization_level")]
public enum OptimizationLevel : int
{
    // [NativeName     ("Name", "shaderc_optimization_level_zero")]
    Zero = 0x0,
    // [NativeName     ("Name", "shaderc_optimization_level_size")]
    Size = 0x1,
    // [NativeName     ("Name", "shaderc_optimization_level_performance")]
    Performance = 0x2,
}

    // [NativeName     ("Name", "shaderc_profile")]
public enum Profile : int
{
    // [NativeName     ("Name", "shaderc_profile_none")]
    None = 0x0,
    // [NativeName     ("Name", "shaderc_profile_core")]
    Core = 0x1,
    // [NativeName     ("Name", "shaderc_profile_compatibility")]
    Compatibility = 0x2,
    // [NativeName     ("Name", "shaderc_profile_es")]
    Es = 0x3,
}


    // [NativeName     ("Name", "shaderc_shader_kind")]
public enum ShaderKind : int
{
    // [NativeName     ("Name", "shaderc_vertex_shader")]
    VertexShader = 0x0,
    // [NativeName     ("Name", "shaderc_fragment_shader")]
    FragmentShader = 0x1,
    // [NativeName     ("Name", "shaderc_compute_shader")]
    ComputeShader = 0x2,
    // [NativeName     ("Name", "shaderc_geometry_shader")]
    GeometryShader = 0x3,
    // [NativeName     ("Name", "shaderc_tess_control_shader")]
    TessControlShader = 0x4,
    // [NativeName     ("Name", "shaderc_tess_evaluation_shader")]
    TessEvaluationShader = 0x5,
    // [NativeName     ("Name", "shaderc_glsl_vertex_shader")]
    GlslVertexShader = 0x0,
    // [NativeName     ("Name", "shaderc_glsl_fragment_shader")]
    GlslFragmentShader = 0x1,
    // [NativeName     ("Name", "shaderc_glsl_compute_shader")]
    GlslComputeShader = 0x2,
    // [NativeName     ("Name", "shaderc_glsl_geometry_shader")]
    GlslGeometryShader = 0x3,
    // [NativeName     ("Name", "shaderc_glsl_tess_control_shader")]
    GlslTessControlShader = 0x4,
    // [NativeName     ("Name", "shaderc_glsl_tess_evaluation_shader")]
    GlslTessEvaluationShader = 0x5,
    // [NativeName     ("Name", "shaderc_glsl_infer_from_source")]
    GlslInferFromSource = 0x6,
    // [NativeName     ("Name", "shaderc_glsl_default_vertex_shader")]
    GlslDefaultVertexShader = 0x7,
    // [NativeName     ("Name", "shaderc_glsl_default_fragment_shader")]
    GlslDefaultFragmentShader = 0x8,
    // [NativeName     ("Name", "shaderc_glsl_default_compute_shader")]
    GlslDefaultComputeShader = 0x9,
    // [NativeName     ("Name", "shaderc_glsl_default_geometry_shader")]
    GlslDefaultGeometryShader = 0xA,
    // [NativeName     ("Name", "shaderc_glsl_default_tess_control_shader")]
    GlslDefaultTessControlShader = 0xB,
    // [NativeName     ("Name", "shaderc_glsl_default_tess_evaluation_shader")]
    GlslDefaultTessEvaluationShader = 0xC,
    // [NativeName     ("Name", "shaderc_spirv_assembly")]
    SpirvAssembly = 0xD,
    // [NativeName     ("Name", "shaderc_raygen_shader")]
    RaygenShader = 0xE,
    // [NativeName     ("Name", "shaderc_anyhit_shader")]
    AnyhitShader = 0xF,
    // [NativeName     ("Name", "shaderc_closesthit_shader")]
    ClosesthitShader = 0x10,
    // [NativeName     ("Name", "shaderc_miss_shader")]
    MissShader = 0x11,
    // [NativeName     ("Name", "shaderc_intersection_shader")]
    IntersectionShader = 0x12,
    // [NativeName     ("Name", "shaderc_callable_shader")]
    CallableShader = 0x13,
    // [NativeName     ("Name", "shaderc_glsl_raygen_shader")]
    GlslRaygenShader = 0xE,
    // [NativeName     ("Name", "shaderc_glsl_anyhit_shader")]
    GlslAnyhitShader = 0xF,
    // [NativeName     ("Name", "shaderc_glsl_closesthit_shader")]
    GlslClosesthitShader = 0x10,
    // [NativeName     ("Name", "shaderc_glsl_miss_shader")]
    GlslMissShader = 0x11,
    // [NativeName     ("Name", "shaderc_glsl_intersection_shader")]
    GlslIntersectionShader = 0x12,
    // [NativeName     ("Name", "shaderc_glsl_callable_shader")]
    GlslCallableShader = 0x13,
    // [NativeName     ("Name", "shaderc_glsl_default_raygen_shader")]
    GlslDefaultRaygenShader = 0x14,
    // [NativeName     ("Name", "shaderc_glsl_default_anyhit_shader")]
    GlslDefaultAnyhitShader = 0x15,
    // [NativeName     ("Name", "shaderc_glsl_default_closesthit_shader")]
    GlslDefaultClosesthitShader = 0x16,
    // [NativeName     ("Name", "shaderc_glsl_default_miss_shader")]
    GlslDefaultMissShader = 0x17,
    // [NativeName     ("Name", "shaderc_glsl_default_intersection_shader")]
    GlslDefaultIntersectionShader = 0x18,
    // [NativeName     ("Name", "shaderc_glsl_default_callable_shader")]
    GlslDefaultCallableShader = 0x19,
    // [NativeName     ("Name", "shaderc_task_shader")]
    TaskShader = 0x1A,
    // [NativeName     ("Name", "shaderc_mesh_shader")]
    MeshShader = 0x1B,
    // [NativeName     ("Name", "shaderc_glsl_task_shader")]
    GlslTaskShader = 0x1A,
    // [NativeName     ("Name", "shaderc_glsl_mesh_shader")]
    GlslMeshShader = 0x1B,
    // [NativeName     ("Name", "shaderc_glsl_default_task_shader")]
    GlslDefaultTaskShader = 0x1C,
    // [NativeName     ("Name", "shaderc_glsl_default_mesh_shader")]
    GlslDefaultMeshShader = 0x1D,
}

// [NativeName     ("Name", "shaderc_source_language")]
public enum SourceLanguage : int
{
    // [NativeName     ("Name", "shaderc_source_language_glsl")]
    Glsl = 0x0,
    // [NativeName     ("Name", "shaderc_source_language_hlsl")]
    Hlsl = 0x1,
}

// [NativeName     ("Name", "shaderc_spirv_version")]
public enum SpirvVersion : int
{
    // [NativeName     ("Name", "shaderc_spirv_version_1_0")]
    Shaderc10 = 0x10000,
    // [NativeName     ("Name", "shaderc_spirv_version_1_1")]
    Shaderc11 = 0x10100,
    // [NativeName     ("Name", "shaderc_spirv_version_1_2")]
    Shaderc12 = 0x10200,
    // [NativeName     ("Name", "shaderc_spirv_version_1_3")]
    Shaderc13 = 0x10300,
    // [NativeName     ("Name", "shaderc_spirv_version_1_4")]
    Shaderc14 = 0x10400,
    // [NativeName     ("Name", "shaderc_spirv_version_1_5")]
    Shaderc15 = 0x10500,
    // [NativeName     ("Name", "shaderc_spirv_version_1_6")]
    Shaderc16 = 0x10600,
}

    // [NativeName     ("Name", "shaderc_target_env")]
public enum TargetEnv : int
{
    // [NativeName     ("Name", "shaderc_target_env_vulkan")]
    Vulkan = 0x0,
    // [NativeName     ("Name", "shaderc_target_env_opengl")]
    Opengl = 0x1,
    // [NativeName     ("Name", "shaderc_target_env_opengl_compat")]
    OpenglCompat = 0x2,
    // [NativeName     ("Name", "shaderc_target_env_webgpu")]
    Webgpu = 0x3,
    // [NativeName     ("Name", "shaderc_target_env_default")]
    Default = 0x0,
}

    // [NativeName     ("Name", "shaderc_uniform_kind")]
public enum UniformKind : int
{
    // [NativeName     ("Name", "shaderc_uniform_kind_image")]
    Image = 0x0,
    // [NativeName     ("Name", "shaderc_uniform_kind_sampler")]
    Sampler = 0x1,
    // [NativeName     ("Name", "shaderc_uniform_kind_texture")]
    Texture = 0x2,
    // [NativeName     ("Name", "shaderc_uniform_kind_buffer")]
    Buffer = 0x3,
    // [NativeName     ("Name", "shaderc_uniform_kind_storage_buffer")]
    StorageBuffer = 0x4,
    // [NativeName     ("Name", "shaderc_uniform_kind_unordered_access_view")]
    UnorderedAccessView = 0x5,
}


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

=======
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

>>>>>>> 967f3b556f834c6fd256466ef90406598ab60b35
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
