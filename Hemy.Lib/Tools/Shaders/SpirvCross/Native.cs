namespace Hemy.Lib.Tools.Shaders.SpirvCross;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using SpvcBool = System.Byte;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Context
{
}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class Native
{
    private const string LibraryName =
#if WINDOWS
    "Spriv_cross.dll";
#endif

/// <unmanaged>SPV_VERSION</unmanaged>
	public const uint SPV_VERSION = 0x10600;
	/// <unmanaged>SPV_REVISION</unmanaged>
	public const uint SPV_REVISION = 1;
	/// <unmanaged>SPVC_C_API_VERSION_MAJOR</unmanaged>
	public const uint SPVC_C_API_VERSION_MAJOR = 0;
	/// <unmanaged>SPVC_C_API_VERSION_MINOR</unmanaged>
	public const uint SPVC_C_API_VERSION_MINOR = 64;
	/// <unmanaged>SPVC_C_API_VERSION_PATCH</unmanaged>
	public const uint SPVC_C_API_VERSION_PATCH = 0;
	// public static SpvcBool SPVC_TRUE => new (1);
	// public static SpvcBool SPVC_FALSE => new (0);
	/// <unmanaged>SPVC_COMPILER_OPTION_COMMON_BIT</unmanaged>
	public const uint SPVC_COMPILER_OPTION_COMMON_BIT = 0x1000000;
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_BIT</unmanaged>
	public const uint SPVC_COMPILER_OPTION_GLSL_BIT = 0x2000000;
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_BIT</unmanaged>
	public const uint SPVC_COMPILER_OPTION_HLSL_BIT = 0x4000000;
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_BIT</unmanaged>
	public const uint SPVC_COMPILER_OPTION_MSL_BIT = 0x8000000;
	/// <unmanaged>SPVC_COMPILER_OPTION_LANG_BITS</unmanaged>
	public const uint SPVC_COMPILER_OPTION_LANG_BITS = 0x0f000000;
	/// <unmanaged>SPVC_COMPILER_OPTION_ENUM_BITS</unmanaged>
	public const float SPVC_COMPILER_OPTION_ENUM_BITS = 0xffffff;
	/// <unmanaged>SPVC_MSL_PUSH_CONSTANT_DESC_SET</unmanaged>
	public const uint SPVC_MSL_PUSH_CONSTANT_DESC_SET = ~0u;
	/// <unmanaged>SPVC_MSL_PUSH_CONSTANT_BINDING</unmanaged>
	public const uint SPVC_MSL_PUSH_CONSTANT_BINDING = 0;
	/// <unmanaged>SPVC_MSL_SWIZZLE_BUFFER_BINDING</unmanaged>
	public const uint SPVC_MSL_SWIZZLE_BUFFER_BINDING = ~1u;
	/// <unmanaged>SPVC_MSL_BUFFER_SIZE_BUFFER_BINDING</unmanaged>
	public const uint SPVC_MSL_BUFFER_SIZE_BUFFER_BINDING = ~2u;
	/// <unmanaged>SPVC_MSL_ARGUMENT_BUFFER_BINDING</unmanaged>
	public const uint SPVC_MSL_ARGUMENT_BUFFER_BINDING = ~3u;
	/// <unmanaged>SPVC_MSL_AUX_BUFFER_STRUCT_VERSION</unmanaged>
	public const uint SPVC_MSL_AUX_BUFFER_STRUCT_VERSION = 1;
	/// <unmanaged>SPVC_HLSL_PUSH_CONSTANT_DESC_SET</unmanaged>
	public const uint SPVC_HLSL_PUSH_CONSTANT_DESC_SET = ~0u;
	/// <unmanaged>SPVC_HLSL_PUSH_CONSTANT_BINDING</unmanaged>
	public const uint SPVC_HLSL_PUSH_CONSTANT_BINDING = 0;

	public const uint SpvMagicNumber = 0x07230203;
	public const uint SpvVersion = 0x00010600;
	public const uint SpvRevision = 1;
	public const uint SpvOpCodeMask = 0xffff;
	public const uint SpvWordCountShift = 16;
  

	public const uint MagicNumber = 0x07230203;
	public const uint Version = 0x00010600;
	public const uint Revision = 1;
	public const uint OpCodeMask = 0xffff;
	public const uint WordCountShift = 16;

    [LibraryImport(LibraryName, EntryPoint = "spvc_get_version")]
	public static partial void spvc_get_version(uint* major, uint* minor, uint* patch);

	[LibraryImport(LibraryName, EntryPoint = "spvc_get_commit_revision_and_timestamp")]
	public static partial byte* spvc_get_commit_revision_and_timestamp();

	[LibraryImport(LibraryName, EntryPoint = "spvc_msl_vertex_attribute_init")]
	public static partial void spvc_msl_vertex_attribute_init(spvc_msl_vertex_attribute* attr);

	[LibraryImport(LibraryName, EntryPoint = "spvc_msl_shader_interface_var_init")]
	public static partial void spvc_msl_shader_interface_var_init(spvc_msl_shader_interface_var* var);

	[LibraryImport(LibraryName, EntryPoint = "spvc_msl_shader_input_init")]
	public static partial void spvc_msl_shader_input_init(spvc_msl_shader_interface_var* input);

	[LibraryImport(LibraryName, EntryPoint = "spvc_msl_shader_interface_var_init_2")]
	public static partial void spvc_msl_shader_interface_var_init_2(spvc_msl_shader_interface_var_2* var);

	[LibraryImport(LibraryName, EntryPoint = "spvc_msl_resource_binding_init")]
	public static partial void spvc_msl_resource_binding_init(spvc_msl_resource_binding* binding);

	[LibraryImport(LibraryName, EntryPoint = "spvc_msl_resource_binding_init_2")]
	public static partial void spvc_msl_resource_binding_init_2(spvc_msl_resource_binding_2* binding);

	[LibraryImport(LibraryName, EntryPoint = "spvc_msl_get_aux_buffer_struct_version")]
	public static partial uint spvc_msl_get_aux_buffer_struct_version();

	[LibraryImport(LibraryName, EntryPoint = "spvc_msl_constexpr_sampler_init")]
	public static partial void spvc_msl_constexpr_sampler_init(spvc_msl_constexpr_sampler* sampler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_msl_sampler_ycbcr_conversion_init")]
	public static partial void spvc_msl_sampler_ycbcr_conversion_init(spvc_msl_sampler_ycbcr_conversion* conv);

	[LibraryImport(LibraryName, EntryPoint = "spvc_hlsl_resource_binding_init")]
	public static partial void spvc_hlsl_resource_binding_init(spvc_hlsl_resource_binding* binding);

	[LibraryImport(LibraryName, EntryPoint = "spvc_context_create")]
	public static partial Result spvc_context_create(spvc_context* context);

	[LibraryImport(LibraryName, EntryPoint = "spvc_context_create")]
	public static partial Result spvc_context_create(Context* context);

	[LibraryImport(LibraryName, EntryPoint = "spvc_context_destroy")]
	public static partial void spvc_context_destroy(spvc_context context);

	[LibraryImport(LibraryName, EntryPoint = "spvc_context_release_allocations")]
	public static partial void spvc_context_release_allocations(spvc_context context);

	[LibraryImport(LibraryName, EntryPoint = "spvc_context_get_last_error_string")]
	private static partial byte* spvc_context_get_last_error_stringPrivate(spvc_context context);

	[LibraryImport(LibraryName, EntryPoint = "spvc_context_parse_spirv")]
	public static partial Result spvc_context_parse_spirv(spvc_context context, uint* spirv, nuint word_count, spvc_parsed_ir* parsed_ir);

	

	[LibraryImport(LibraryName, EntryPoint = "spvc_context_create_compiler")]
	public static partial Result spvc_context_create_compiler(spvc_context context, Backend backend, spvc_parsed_ir parsed_ir, CaptureMode mode, spvc_compiler* compiler);

	
	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_current_id_bound")]
	public static partial uint spvc_compiler_get_current_id_bound(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_create_compiler_options")]
	public static partial Result spvc_compiler_create_compiler_options(spvc_compiler compiler, spvc_compiler_options* options);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_create_compiler_options")]
	public static partial Result spvc_compiler_create_compiler_options(spvc_compiler compiler, out spvc_compiler_options options);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_options_set_bool")]
	public static partial Result spvc_compiler_options_set_bool(spvc_compiler_options options, CompilerOption option, SpvcBool value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_options_set_uint")]
	public static partial Result spvc_compiler_options_set_uint(spvc_compiler_options options, CompilerOption option, uint value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_install_compiler_options")]
	public static partial Result spvc_compiler_install_compiler_options(spvc_compiler compiler, spvc_compiler_options options);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_compile")]
	public static partial Result spvc_compiler_compile(spvc_compiler compiler, byte** source);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_add_header_line")]
	public static partial Result spvc_compiler_add_header_line(spvc_compiler compiler, byte* line);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_require_extension")]
	public static partial Result spvc_compiler_require_extension(spvc_compiler compiler, byte* ext);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_num_required_extensions")]
	public static partial nuint spvc_compiler_get_num_required_extensions(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_required_extension")]
	public static partial byte* spvc_compiler_get_required_extension(spvc_compiler compiler, nuint index);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_flatten_buffer_block")]
	public static partial Result spvc_compiler_flatten_buffer_block(spvc_compiler compiler, uint id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_variable_is_depth_or_compare")]
	public static partial SpvcBool spvc_compiler_variable_is_depth_or_compare(spvc_compiler compiler, uint id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_mask_stage_output_by_location")]
	public static partial Result spvc_compiler_mask_stage_output_by_location(spvc_compiler compiler, uint location, uint component);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_mask_stage_output_by_builtin")]
	public static partial Result spvc_compiler_mask_stage_output_by_builtin(spvc_compiler compiler, SpvBuiltIn builtin);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_hlsl_set_root_constants_layout")]
	public static partial Result spvc_compiler_hlsl_set_root_constants_layout(spvc_compiler compiler, spvc_hlsl_root_constants* constant_info, nuint count);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_hlsl_add_vertex_attribute_remap")]
	public static partial Result spvc_compiler_hlsl_add_vertex_attribute_remap(spvc_compiler compiler, spvc_hlsl_vertex_attribute_remap* remap, nuint remaps);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_hlsl_remap_num_workgroups_builtin")]
	public static partial uint spvc_compiler_hlsl_remap_num_workgroups_builtin(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_hlsl_set_resource_binding_flags")]
	public static partial Result spvc_compiler_hlsl_set_resource_binding_flags(spvc_compiler compiler, HLSLBindingFlags flags);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_hlsl_add_resource_binding")]
	public static partial Result spvc_compiler_hlsl_add_resource_binding(spvc_compiler compiler, spvc_hlsl_resource_binding* binding);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_hlsl_is_resource_used")]
	public static partial SpvcBool spvc_compiler_hlsl_is_resource_used(spvc_compiler compiler, SpvExecutionModel model, uint set, uint binding);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_is_rasterization_disabled")]
	public static partial SpvcBool spvc_compiler_msl_is_rasterization_disabled(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_needs_aux_buffer")]
	public static partial SpvcBool spvc_compiler_msl_needs_aux_buffer(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_needs_swizzle_buffer")]
	public static partial SpvcBool spvc_compiler_msl_needs_swizzle_buffer(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_needs_buffer_size_buffer")]
	public static partial SpvcBool spvc_compiler_msl_needs_buffer_size_buffer(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_needs_output_buffer")]
	public static partial SpvcBool spvc_compiler_msl_needs_output_buffer(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_needs_patch_output_buffer")]
	public static partial SpvcBool spvc_compiler_msl_needs_patch_output_buffer(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_needs_input_threadgroup_mem")]
	public static partial SpvcBool spvc_compiler_msl_needs_input_threadgroup_mem(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_vertex_attribute")]
	public static partial Result spvc_compiler_msl_add_vertex_attribute(spvc_compiler compiler, spvc_msl_vertex_attribute* attrs);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_resource_binding")]
	public static partial Result spvc_compiler_msl_add_resource_binding(spvc_compiler compiler, spvc_msl_resource_binding* binding);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_resource_binding_2")]
	public static partial Result spvc_compiler_msl_add_resource_binding_2(spvc_compiler compiler, spvc_msl_resource_binding_2* binding);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_shader_input")]
	public static partial Result spvc_compiler_msl_add_shader_input(spvc_compiler compiler, spvc_msl_shader_interface_var* input);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_shader_input_2")]
	public static partial Result spvc_compiler_msl_add_shader_input_2(spvc_compiler compiler, spvc_msl_shader_interface_var_2* input);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_shader_output")]
	public static partial Result spvc_compiler_msl_add_shader_output(spvc_compiler compiler, spvc_msl_shader_interface_var* output);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_shader_output_2")]
	public static partial Result spvc_compiler_msl_add_shader_output_2(spvc_compiler compiler, spvc_msl_shader_interface_var_2* output);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_discrete_descriptor_set")]
	public static partial Result spvc_compiler_msl_add_discrete_descriptor_set(spvc_compiler compiler, uint desc_set);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_set_argument_buffer_device_address_space")]
	public static partial Result spvc_compiler_msl_set_argument_buffer_device_address_space(spvc_compiler compiler, uint desc_set, SpvcBool device_address);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_is_vertex_attribute_used")]
	public static partial SpvcBool spvc_compiler_msl_is_vertex_attribute_used(spvc_compiler compiler, uint location);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_is_shader_input_used")]
	public static partial SpvcBool spvc_compiler_msl_is_shader_input_used(spvc_compiler compiler, uint location);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_is_shader_output_used")]
	public static partial SpvcBool spvc_compiler_msl_is_shader_output_used(spvc_compiler compiler, uint location);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_is_resource_used")]
	public static partial SpvcBool spvc_compiler_msl_is_resource_used(spvc_compiler compiler, SpvExecutionModel model, uint set, uint binding);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_remap_constexpr_sampler")]
	public static partial Result spvc_compiler_msl_remap_constexpr_sampler(spvc_compiler compiler, uint id, spvc_msl_constexpr_sampler* sampler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_remap_constexpr_sampler_by_binding")]
	public static partial Result spvc_compiler_msl_remap_constexpr_sampler_by_binding(spvc_compiler compiler, uint desc_set, uint binding, spvc_msl_constexpr_sampler* sampler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_remap_constexpr_sampler_ycbcr")]
	public static partial Result spvc_compiler_msl_remap_constexpr_sampler_ycbcr(spvc_compiler compiler, uint id, spvc_msl_constexpr_sampler* sampler, spvc_msl_sampler_ycbcr_conversion* conv);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_remap_constexpr_sampler_by_binding_ycbcr")]
	public static partial Result spvc_compiler_msl_remap_constexpr_sampler_by_binding_ycbcr(spvc_compiler compiler, uint desc_set, uint binding, spvc_msl_constexpr_sampler* sampler, spvc_msl_sampler_ycbcr_conversion* conv);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_set_fragment_output_components")]
	public static partial Result spvc_compiler_msl_set_fragment_output_components(spvc_compiler compiler, uint location, uint components);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_get_automatic_resource_binding")]
	public static partial uint spvc_compiler_msl_get_automatic_resource_binding(spvc_compiler compiler, uint id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_get_automatic_resource_binding_secondary")]
	public static partial uint spvc_compiler_msl_get_automatic_resource_binding_secondary(spvc_compiler compiler, uint id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_dynamic_buffer")]
	public static partial Result spvc_compiler_msl_add_dynamic_buffer(spvc_compiler compiler, uint desc_set, uint binding, uint index);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_add_inline_uniform_block")]
	public static partial Result spvc_compiler_msl_add_inline_uniform_block(spvc_compiler compiler, uint desc_set, uint binding);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_set_combined_sampler_suffix")]
	public static partial Result spvc_compiler_msl_set_combined_sampler_suffix(spvc_compiler compiler, byte* suffix);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_msl_get_combined_sampler_suffix")]
	public static partial byte* spvc_compiler_msl_get_combined_sampler_suffix(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_active_interface_variables")]
	public static partial Result spvc_compiler_get_active_interface_variables(spvc_compiler compiler, spvc_set* set);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_enabled_interface_variables")]
	public static partial Result spvc_compiler_set_enabled_interface_variables(spvc_compiler compiler, spvc_set set);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_create_shader_resources")]
	public static partial Result spvc_compiler_create_shader_resources(spvc_compiler compiler, spvc_resources* resources);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_create_shader_resources")]
	public static partial Result spvc_compiler_create_shader_resources(spvc_compiler compiler, out spvc_resources resources);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_create_shader_resources_for_active_variables")]
	public static partial Result spvc_compiler_create_shader_resources_for_active_variables(spvc_compiler compiler, spvc_resources* resources, spvc_set active);

	[LibraryImport(LibraryName, EntryPoint = "spvc_resources_get_resource_list_for_type")]
	public static partial Result spvc_resources_get_resource_list_for_type(spvc_resources resources, ResourceType type, spvc_reflected_resource** resource_list, nuint* resource_size);

	[LibraryImport(LibraryName, EntryPoint = "spvc_resources_get_builtin_resource_list_for_type")]
	public static partial Result spvc_resources_get_builtin_resource_list_for_type(spvc_resources resources, BuiltinResourceType type, spvc_reflected_builtin_resource** resource_list, nuint* resource_size);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_decoration")]
	public static partial void spvc_compiler_set_decoration(spvc_compiler compiler, uint id, SpvDecoration decoration, uint argument);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_decoration_string")]
	public static partial void spvc_compiler_set_decoration_string(spvc_compiler compiler, uint id, SpvDecoration decoration, byte* argument);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_name")]
	public static partial void spvc_compiler_set_name(spvc_compiler compiler, uint id, byte* argument);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_member_decoration")]
	public static partial void spvc_compiler_set_member_decoration(spvc_compiler compiler, uint id, uint member_index, SpvDecoration decoration, uint argument);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_member_decoration_string")]
	public static partial void spvc_compiler_set_member_decoration_string(spvc_compiler compiler, uint id, uint member_index, SpvDecoration decoration, byte* argument);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_member_name")]
	public static partial void spvc_compiler_set_member_name(spvc_compiler compiler, uint id, uint member_index, byte* argument);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_unset_decoration")]
	public static partial void spvc_compiler_unset_decoration(spvc_compiler compiler, uint id, SpvDecoration decoration);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_unset_member_decoration")]
	public static partial void spvc_compiler_unset_member_decoration(spvc_compiler compiler, uint id, uint member_index, SpvDecoration decoration);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_has_decoration")]
	public static partial SpvcBool spvc_compiler_has_decoration(spvc_compiler compiler, uint id, SpvDecoration decoration);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_has_member_decoration")]
	public static partial SpvcBool spvc_compiler_has_member_decoration(spvc_compiler compiler, uint id, uint member_index, SpvDecoration decoration);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_name")]
	private static partial byte* spvc_compiler_get_namePrivate(spvc_compiler compiler, uint id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_decoration")]
	public static partial uint spvc_compiler_get_decoration(spvc_compiler compiler, uint id, SpvDecoration decoration);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_decoration_string")]
	public static partial byte* spvc_compiler_get_decoration_string(spvc_compiler compiler, uint id, SpvDecoration decoration);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_member_decoration")]
	public static partial uint spvc_compiler_get_member_decoration(spvc_compiler compiler, uint id, uint member_index, SpvDecoration decoration);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_member_decoration_string")]
	public static partial byte* spvc_compiler_get_member_decoration_string(spvc_compiler compiler, uint id, uint member_index, SpvDecoration decoration);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_member_name")]
	public static partial byte* spvc_compiler_get_member_name(spvc_compiler compiler, uint id, uint member_index);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_entry_points")]
	public static partial Result spvc_compiler_get_entry_points(spvc_compiler compiler, spvc_entry_point** entry_points, nuint* num_entry_points);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_entry_point")]
	public static partial Result spvc_compiler_set_entry_point(spvc_compiler compiler, byte* name, SpvExecutionModel model);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_rename_entry_point")]
	public static partial Result spvc_compiler_rename_entry_point(spvc_compiler compiler, byte* old_name, byte* new_name, SpvExecutionModel model);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_cleansed_entry_point_name")]
	public static partial byte* spvc_compiler_get_cleansed_entry_point_name(spvc_compiler compiler, byte* name, SpvExecutionModel model);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_execution_mode")]
	public static partial void spvc_compiler_set_execution_mode(spvc_compiler compiler, SpvExecutionMode mode);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_unset_execution_mode")]
	public static partial void spvc_compiler_unset_execution_mode(spvc_compiler compiler, SpvExecutionMode mode);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_set_execution_mode_with_arguments")]
	public static partial void spvc_compiler_set_execution_mode_with_arguments(spvc_compiler compiler, SpvExecutionMode mode, uint arg0, uint arg1, uint arg2);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_execution_modes")]
	public static partial Result spvc_compiler_get_execution_modes(spvc_compiler compiler, SpvExecutionMode** modes, nuint* num_modes);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_execution_mode_argument")]
	public static partial uint spvc_compiler_get_execution_mode_argument(spvc_compiler compiler, SpvExecutionMode mode);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_execution_mode_argument_by_index")]
	public static partial uint spvc_compiler_get_execution_mode_argument_by_index(spvc_compiler compiler, SpvExecutionMode mode, uint index);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_execution_model")]
	public static partial SpvExecutionModel spvc_compiler_get_execution_model(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_update_active_builtins")]
	public static partial void spvc_compiler_update_active_builtins(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_has_active_builtin")]
	public static partial SpvcBool spvc_compiler_has_active_builtin(spvc_compiler compiler, SpvBuiltIn builtin, SpvStorageClass storage);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_type_handle")]
	public static partial spvc_type spvc_compiler_get_type_handle(spvc_compiler compiler, uint id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_base_type_id")]
	public static partial uint spvc_type_get_base_type_id(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_basetype")]
	public static partial Basetype spvc_type_get_basetype(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_bit_width")]
	public static partial uint spvc_type_get_bit_width(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_vector_size")]
	public static partial uint spvc_type_get_vector_size(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_columns")]
	public static partial uint spvc_type_get_columns(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_num_array_dimensions")]
	public static partial uint spvc_type_get_num_array_dimensions(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_array_dimension_is_literal")]
	public static partial SpvcBool spvc_type_array_dimension_is_literal(spvc_type type, uint dimension);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_array_dimension")]
	public static partial uint spvc_type_get_array_dimension(spvc_type type, uint dimension);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_num_member_types")]
	public static partial uint spvc_type_get_num_member_types(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_member_type")]
	public static partial uint spvc_type_get_member_type(spvc_type type, uint index);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_storage_class")]
	public static partial SpvStorageClass spvc_type_get_storage_class(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_image_sampled_type")]
	public static partial uint spvc_type_get_image_sampled_type(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_image_dimension")]
	public static partial SpvDim spvc_type_get_image_dimension(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_image_is_depth")]
	public static partial SpvcBool spvc_type_get_image_is_depth(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_image_arrayed")]
	public static partial SpvcBool spvc_type_get_image_arrayed(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_image_multisampled")]
	public static partial SpvcBool spvc_type_get_image_multisampled(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_image_is_storage")]
	public static partial SpvcBool spvc_type_get_image_is_storage(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_image_storage_format")]
	public static partial SpvImageFormat spvc_type_get_image_storage_format(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_type_get_image_access_qualifier")]
	public static partial SpvAccessQualifier spvc_type_get_image_access_qualifier(spvc_type type);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_declared_struct_size")]
	public static partial Result spvc_compiler_get_declared_struct_size(spvc_compiler compiler, spvc_type struct_type, nuint* size);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_declared_struct_size_runtime_array")]
	public static partial Result spvc_compiler_get_declared_struct_size_runtime_array(spvc_compiler compiler, spvc_type struct_type, nuint array_size, nuint* size);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_declared_struct_member_size")]
	public static partial Result spvc_compiler_get_declared_struct_member_size(spvc_compiler compiler, spvc_type type, uint index, nuint* size);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_type_struct_member_offset")]
	public static partial Result spvc_compiler_type_struct_member_offset(spvc_compiler compiler, spvc_type type, uint index, uint* offset);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_type_struct_member_array_stride")]
	public static partial Result spvc_compiler_type_struct_member_array_stride(spvc_compiler compiler, spvc_type type, uint index, uint* stride);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_type_struct_member_matrix_stride")]
	public static partial Result spvc_compiler_type_struct_member_matrix_stride(spvc_compiler compiler, spvc_type type, uint index, uint* stride);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_build_dummy_sampler_for_combined_images")]
	public static partial Result spvc_compiler_build_dummy_sampler_for_combined_images(spvc_compiler compiler, uint* id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_build_combined_image_samplers")]
	public static partial Result spvc_compiler_build_combined_image_samplers(spvc_compiler compiler);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_combined_image_samplers")]
	public static partial Result spvc_compiler_get_combined_image_samplers(spvc_compiler compiler, spvc_combined_image_sampler** samplers, nuint* num_samplers);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_specialization_constants")]
	public static partial Result spvc_compiler_get_specialization_constants(spvc_compiler compiler, spvc_specialization_constant** constants, nuint* num_constants);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_constant_handle")]
	public static partial spvc_constant spvc_compiler_get_constant_handle(spvc_compiler compiler, uint id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_work_group_size_specialization_constants")]
	public static partial uint spvc_compiler_get_work_group_size_specialization_constants(spvc_compiler compiler, spvc_specialization_constant* x, spvc_specialization_constant* y, spvc_specialization_constant* z);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_active_buffer_ranges")]
	public static partial Result spvc_compiler_get_active_buffer_ranges(spvc_compiler compiler, uint id, spvc_buffer_range** ranges, nuint* num_ranges);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_fp16")]
	public static partial float spvc_constant_get_scalar_fp16(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_fp32")]
	public static partial float spvc_constant_get_scalar_fp32(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_fp64")]
	public static partial double spvc_constant_get_scalar_fp64(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_u32")]
	public static partial uint spvc_constant_get_scalar_u32(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_i32")]
	public static partial int spvc_constant_get_scalar_i32(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_u16")]
	public static partial uint spvc_constant_get_scalar_u16(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_i16")]
	public static partial int spvc_constant_get_scalar_i16(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_u8")]
	public static partial uint spvc_constant_get_scalar_u8(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_i8")]
	public static partial int spvc_constant_get_scalar_i8(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_subconstants")]
	public static partial void spvc_constant_get_subconstants(spvc_constant constant, uint** constituents, nuint* count);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_u64")]
	public static partial ulong spvc_constant_get_scalar_u64(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_scalar_i64")]
	public static partial long spvc_constant_get_scalar_i64(spvc_constant constant, uint column, uint row);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_get_type")]
	public static partial uint spvc_constant_get_type(spvc_constant constant);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_fp16")]
	public static partial void spvc_constant_set_scalar_fp16(spvc_constant constant, uint column, uint row, ushort value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_fp32")]
	public static partial void spvc_constant_set_scalar_fp32(spvc_constant constant, uint column, uint row, float value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_fp64")]
	public static partial void spvc_constant_set_scalar_fp64(spvc_constant constant, uint column, uint row, double value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_u32")]
	public static partial void spvc_constant_set_scalar_u32(spvc_constant constant, uint column, uint row, uint value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_i32")]
	public static partial void spvc_constant_set_scalar_i32(spvc_constant constant, uint column, uint row, int value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_u64")]
	public static partial void spvc_constant_set_scalar_u64(spvc_constant constant, uint column, uint row, ulong value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_i64")]
	public static partial void spvc_constant_set_scalar_i64(spvc_constant constant, uint column, uint row, long value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_u16")]
	public static partial void spvc_constant_set_scalar_u16(spvc_constant constant, uint column, uint row, ushort value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_i16")]
	public static partial void spvc_constant_set_scalar_i16(spvc_constant constant, uint column, uint row, short value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_u8")]
	public static partial void spvc_constant_set_scalar_u8(spvc_constant constant, uint column, uint row, byte value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_constant_set_scalar_i8")]
	public static partial void spvc_constant_set_scalar_i8(spvc_constant constant, uint column, uint row, byte value);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_binary_offset_for_decoration")]
	public static partial SpvcBool spvc_compiler_get_binary_offset_for_decoration(spvc_compiler compiler, uint id, SpvDecoration decoration, uint* word_offset);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_buffer_is_hlsl_counter_buffer")]
	public static partial SpvcBool spvc_compiler_buffer_is_hlsl_counter_buffer(spvc_compiler compiler, uint id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_buffer_get_hlsl_counter_buffer")]
	public static partial SpvcBool spvc_compiler_buffer_get_hlsl_counter_buffer(spvc_compiler compiler, uint id, uint* counter_id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_declared_capabilities")]
	public static partial Result spvc_compiler_get_declared_capabilities(spvc_compiler compiler, SpvCapability** capabilities, nuint* num_capabilities);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_declared_extensions")]
	public static partial Result spvc_compiler_get_declared_extensions(spvc_compiler compiler, byte*** extensions, nuint* num_extensions);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_remapped_declared_block_name")]
	public static partial byte* spvc_compiler_get_remapped_declared_block_name(spvc_compiler compiler, uint id);

	[LibraryImport(LibraryName, EntryPoint = "spvc_compiler_get_buffer_block_decorations")]
	public static partial Result spvc_compiler_get_buffer_block_decorations(spvc_compiler compiler, uint id, SpvDecoration** decorations, nuint* num_decorations);



}

#region Handles



public readonly partial struct spvc_context : IEquatable<spvc_context>
{
	public spvc_context(nint handle) { Handle = handle; }
	public nint Handle { get; }
	public bool IsNull => Handle == 0;
	public bool IsNotNull => Handle != 0;
	public static spvc_context Null => new(0);
	public static implicit operator spvc_context(nint handle) => new(handle);
	public static implicit operator nint(spvc_context handle) => handle.Handle;
	public static bool operator ==(spvc_context left, spvc_context right) => left.Handle == right.Handle;
	public static bool operator !=(spvc_context left, spvc_context right) => left.Handle != right.Handle;
	public static bool operator ==(spvc_context left, nint right) => left.Handle == right;
	public static bool operator !=(spvc_context left, nint right) => left.Handle != right;
	public bool Equals(spvc_context other) => Handle == other.Handle;
	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is spvc_context handle && Equals(handle);
	/// <inheritdoc/>
	public override int GetHashCode() => Handle.GetHashCode();
	private string DebuggerDisplay => $"{nameof(spvc_context)} [0x{Handle.ToString("X")}]";
}


public readonly partial struct spvc_parsed_ir : IEquatable<spvc_parsed_ir>
{
	public spvc_parsed_ir(nint handle) { Handle = handle; }
	public nint Handle { get; }
	public bool IsNull => Handle == 0;
	public bool IsNotNull => Handle != 0;
	public static spvc_parsed_ir Null => new(0);
	public static implicit operator spvc_parsed_ir(nint handle) => new(handle);
	public static implicit operator nint(spvc_parsed_ir handle) => handle.Handle;
	public static bool operator ==(spvc_parsed_ir left, spvc_parsed_ir right) => left.Handle == right.Handle;
	public static bool operator !=(spvc_parsed_ir left, spvc_parsed_ir right) => left.Handle != right.Handle;
	public static bool operator ==(spvc_parsed_ir left, nint right) => left.Handle == right;
	public static bool operator !=(spvc_parsed_ir left, nint right) => left.Handle != right;
	public bool Equals(spvc_parsed_ir other) => Handle == other.Handle;
	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is spvc_parsed_ir handle && Equals(handle);
	/// <inheritdoc/>
	public override int GetHashCode() => Handle.GetHashCode();
	private string DebuggerDisplay => $"{nameof(spvc_parsed_ir)} [0x{Handle.ToString("X")}]";
}


public readonly partial struct spvc_compiler : IEquatable<spvc_compiler>
{
	public spvc_compiler(nint handle) { Handle = handle; }
	public nint Handle { get; }
	public bool IsNull => Handle == 0;
	public bool IsNotNull => Handle != 0;
	public static spvc_compiler Null => new(0);
	public static implicit operator spvc_compiler(nint handle) => new(handle);
	public static implicit operator nint(spvc_compiler handle) => handle.Handle;
	public static bool operator ==(spvc_compiler left, spvc_compiler right) => left.Handle == right.Handle;
	public static bool operator !=(spvc_compiler left, spvc_compiler right) => left.Handle != right.Handle;
	public static bool operator ==(spvc_compiler left, nint right) => left.Handle == right;
	public static bool operator !=(spvc_compiler left, nint right) => left.Handle != right;
	public bool Equals(spvc_compiler other) => Handle == other.Handle;
	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is spvc_compiler handle && Equals(handle);
	/// <inheritdoc/>
	public override int GetHashCode() => Handle.GetHashCode();
	private string DebuggerDisplay => $"{nameof(spvc_compiler)} [0x{Handle.ToString("X")}]";
}


public readonly partial struct spvc_compiler_options : IEquatable<spvc_compiler_options>
{
	public spvc_compiler_options(nint handle) { Handle = handle; }
	public nint Handle { get; }
	public bool IsNull => Handle == 0;
	public bool IsNotNull => Handle != 0;
	public static spvc_compiler_options Null => new(0);
	public static implicit operator spvc_compiler_options(nint handle) => new(handle);
	public static implicit operator nint(spvc_compiler_options handle) => handle.Handle;
	public static bool operator ==(spvc_compiler_options left, spvc_compiler_options right) => left.Handle == right.Handle;
	public static bool operator !=(spvc_compiler_options left, spvc_compiler_options right) => left.Handle != right.Handle;
	public static bool operator ==(spvc_compiler_options left, nint right) => left.Handle == right;
	public static bool operator !=(spvc_compiler_options left, nint right) => left.Handle != right;
	public bool Equals(spvc_compiler_options other) => Handle == other.Handle;
	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is spvc_compiler_options handle && Equals(handle);
	/// <inheritdoc/>
	public override int GetHashCode() => Handle.GetHashCode();
	private string DebuggerDisplay => $"{nameof(spvc_compiler_options)} [0x{Handle.ToString("X")}]";
}


public readonly partial struct spvc_resources : IEquatable<spvc_resources>
{
	public spvc_resources(nint handle) { Handle = handle; }
	public nint Handle { get; }
	public bool IsNull => Handle == 0;
	public bool IsNotNull => Handle != 0;
	public static spvc_resources Null => new(0);
	public static implicit operator spvc_resources(nint handle) => new(handle);
	public static implicit operator nint(spvc_resources handle) => handle.Handle;
	public static bool operator ==(spvc_resources left, spvc_resources right) => left.Handle == right.Handle;
	public static bool operator !=(spvc_resources left, spvc_resources right) => left.Handle != right.Handle;
	public static bool operator ==(spvc_resources left, nint right) => left.Handle == right;
	public static bool operator !=(spvc_resources left, nint right) => left.Handle != right;
	public bool Equals(spvc_resources other) => Handle == other.Handle;
	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is spvc_resources handle && Equals(handle);
	/// <inheritdoc/>
	public override int GetHashCode() => Handle.GetHashCode();
	private string DebuggerDisplay => $"{nameof(spvc_resources)} [0x{Handle.ToString("X")}]";
}


public readonly partial struct spvc_type : IEquatable<spvc_type>
{
	public spvc_type(nint handle) { Handle = handle; }
	public nint Handle { get; }
	public bool IsNull => Handle == 0;
	public bool IsNotNull => Handle != 0;
	public static spvc_type Null => new(0);
	public static implicit operator spvc_type(nint handle) => new(handle);
	public static implicit operator nint(spvc_type handle) => handle.Handle;
	public static bool operator ==(spvc_type left, spvc_type right) => left.Handle == right.Handle;
	public static bool operator !=(spvc_type left, spvc_type right) => left.Handle != right.Handle;
	public static bool operator ==(spvc_type left, nint right) => left.Handle == right;
	public static bool operator !=(spvc_type left, nint right) => left.Handle != right;
	public bool Equals(spvc_type other) => Handle == other.Handle;
	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is spvc_type handle && Equals(handle);
	/// <inheritdoc/>
	public override int GetHashCode() => Handle.GetHashCode();
	private string DebuggerDisplay => $"{nameof(spvc_type)} [0x{Handle.ToString("X")}]";
}


public readonly partial struct spvc_constant : IEquatable<spvc_constant>
{
	public spvc_constant(nint handle) { Handle = handle; }
	public nint Handle { get; }
	public bool IsNull => Handle == 0;
	public bool IsNotNull => Handle != 0;
	public static spvc_constant Null => new(0);
	public static implicit operator spvc_constant(nint handle) => new(handle);
	public static implicit operator nint(spvc_constant handle) => handle.Handle;
	public static bool operator ==(spvc_constant left, spvc_constant right) => left.Handle == right.Handle;
	public static bool operator !=(spvc_constant left, spvc_constant right) => left.Handle != right.Handle;
	public static bool operator ==(spvc_constant left, nint right) => left.Handle == right;
	public static bool operator !=(spvc_constant left, nint right) => left.Handle != right;
	public bool Equals(spvc_constant other) => Handle == other.Handle;
	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is spvc_constant handle && Equals(handle);
	/// <inheritdoc/>
	public override int GetHashCode() => Handle.GetHashCode();
	private string DebuggerDisplay => $"{nameof(spvc_constant)} [0x{Handle.ToString("X")}]";
}


public readonly partial struct spvc_set : IEquatable<spvc_set>
{
	public spvc_set(nint handle) { Handle = handle; }
	public nint Handle { get; }
	public bool IsNull => Handle == 0;
	public bool IsNotNull => Handle != 0;
	public static spvc_set Null => new(0);
	public static implicit operator spvc_set(nint handle) => new(handle);
	public static implicit operator nint(spvc_set handle) => handle.Handle;
	public static bool operator ==(spvc_set left, spvc_set right) => left.Handle == right.Handle;
	public static bool operator !=(spvc_set left, spvc_set right) => left.Handle != right.Handle;
	public static bool operator ==(spvc_set left, nint right) => left.Handle == right;
	public static bool operator !=(spvc_set left, nint right) => left.Handle != right;
	public bool Equals(spvc_set other) => Handle == other.Handle;
	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is spvc_set handle && Equals(handle);
	/// <inheritdoc/>
	public override int GetHashCode() => Handle.GetHashCode();
	private string DebuggerDisplay => $"{nameof(spvc_set)} [0x{Handle.ToString("X")}]";
}

#endregion

#region Struct


public unsafe partial struct spvc_reflected_resource
{
    public uint id;
    public uint base_type_id;
    public uint type_id;
    public byte* name;
}

public partial struct spvc_reflected_builtin_resource
{
	public SpvBuiltIn builtin;
	public uint value_type_id;
	public spvc_reflected_resource resource;
}

public unsafe partial struct spvc_entry_point
{
	public SpvExecutionModel execution_model;
	public byte* name;
}

public partial struct spvc_combined_image_sampler
{
	public uint combined_id;
	public uint image_id;
	public uint sampler_id;
}

public partial struct spvc_specialization_constant
{
	public uint id;
	public uint constant_id;
}

public partial struct spvc_buffer_range
{
	public uint index;
	public nuint offset;
	public nuint range;
}

public partial struct spvc_hlsl_root_constants
{
	public uint start;
	public uint end;
	public uint binding;
	public uint space;
}

public unsafe partial struct spvc_hlsl_vertex_attribute_remap
{
	public uint location;
	public byte* semantic;
}

public partial struct spvc_msl_vertex_attribute
{
	public uint location;
	public uint msl_buffer;
	public uint msl_offset;
	public uint msl_stride;
	public SpvcBool per_instance;
	public MSLShaderVariableFormat format;
	public SpvBuiltIn builtin;
}

public partial struct spvc_msl_shader_interface_var
{
	public uint location;
	public MSLShaderVariableFormat format;
	public SpvBuiltIn builtin;
	public uint vecsize;
}

public partial struct spvc_msl_shader_interface_var_2
{
	public uint location;
	public MSLShaderVariableFormat format;
	public SpvBuiltIn builtin;
	public uint vecsize;
	public MSLShaderVariableRate rate;
}

public partial struct spvc_msl_resource_binding
{
	public SpvExecutionModel stage;
	public uint desc_set;
	public uint binding;
	public uint msl_buffer;
	public uint msl_texture;
	public uint msl_sampler;
}

public partial struct spvc_msl_resource_binding_2
{
	public SpvExecutionModel stage;
	public uint desc_set;
	public uint binding;
	public uint count;
	public uint msl_buffer;
	public uint msl_texture;
	public uint msl_sampler;
}

public partial struct spvc_msl_constexpr_sampler
{
	public MSLSamplerCoord coord;
	public MSLSamplerFilter min_filter;
	public MSLSamplerFilter mag_filter;
	public MSLSamplerMipFilter mip_filter;
	public MSLSamplerAddress s_address;
	public MSLSamplerAddress t_address;
	public MSLSamplerAddress r_address;
	public MSLSamplerCompareFunc compare_func;
	public MSLSamplerBorderColor border_color;
	public float lod_clamp_min;
	public float lod_clamp_max;
	public int max_anisotropy;
	public SpvcBool compare_enable;
	public SpvcBool lod_clamp_enable;
	public SpvcBool anisotropy_enable;
}

public partial struct spvc_msl_sampler_ycbcr_conversion
{
	public uint planes;
	public MSLFormatResolution resolution;
	public MSLSamplerFilter chroma_filter;
	public MSLChromaLocation x_chroma_offset;
	public MSLChromaLocation y_chroma_offset;
	public swizzle__FixedBuffer swizzle;

	[InlineArray(4)]
	public partial struct swizzle__FixedBuffer
	{
		public MSLComponentSwizzle e0;
	}
	public MSLSamplerYcbcrModelConversion ycbcr_model;
	public MSLSamplerYcbcrRange ycbcr_range;
	public uint bpc;
}

public partial struct spvc_hlsl_resource_binding_mapping
{
	public uint register_space;
	public uint register_binding;
}

public partial struct spvc_hlsl_resource_binding
{
	public SpvExecutionModel stage;
	public uint desc_set;
	public uint binding;
	public spvc_hlsl_resource_binding_mapping cbv;
	public spvc_hlsl_resource_binding_mapping uav;
	public spvc_hlsl_resource_binding_mapping srv;
	public spvc_hlsl_resource_binding_mapping sampler;
}

#endregion

#region ENUMS


public enum Result : int
{
	/// <unmanaged>SPVC_SUCCESS</unmanaged>
	Success = 0,
	/// <unmanaged>SPVC_ERROR_INVALID_SPIRV</unmanaged>
	InvalidSPIRV = -1,
	/// <unmanaged>SPVC_ERROR_UNSUPPORTED_SPIRV</unmanaged>
	UnsupportedSPIRV = -2,
	/// <unmanaged>SPVC_ERROR_OUT_OF_MEMORY</unmanaged>
	OutOfMemory = -3,
	/// <unmanaged>SPVC_ERROR_INVALID_ARGUMENT</unmanaged>
	InvalidArgument = -4,
}

public enum CaptureMode
{
	/// <unmanaged>SPVC_CAPTURE_MODE_COPY</unmanaged>
	Copy = 0,
	/// <unmanaged>SPVC_CAPTURE_MODE_TAKE_OWNERSHIP</unmanaged>
	TakeOwnership = 1,
}

public enum Backend
{
	/// <unmanaged>SPVC_BACKEND_NONE</unmanaged>
	None = 0,
	/// <unmanaged>SPVC_BACKEND_GLSL</unmanaged>
	GLSL = 1,
	/// <unmanaged>SPVC_BACKEND_HLSL</unmanaged>
	HLSL = 2,
	/// <unmanaged>SPVC_BACKEND_MSL</unmanaged>
	MSL = 3,
	/// <unmanaged>SPVC_BACKEND_CPP</unmanaged>
	Cpp = 4,
	/// <unmanaged>SPVC_BACKEND_JSON</unmanaged>
	JSON = 5,
}

public enum ResourceType
{
	/// <unmanaged>SPVC_RESOURCE_TYPE_UNKNOWN</unmanaged>
	Unknown = 0,
	/// <unmanaged>SPVC_RESOURCE_TYPE_UNIFORM_BUFFER</unmanaged>
	UniformBuffer = 1,
	/// <unmanaged>SPVC_RESOURCE_TYPE_STORAGE_BUFFER</unmanaged>
	StorageBuffer = 2,
	/// <unmanaged>SPVC_RESOURCE_TYPE_STAGE_INPUT</unmanaged>
	StageInput = 3,
	/// <unmanaged>SPVC_RESOURCE_TYPE_STAGE_OUTPUT</unmanaged>
	StageOutput = 4,
	/// <unmanaged>SPVC_RESOURCE_TYPE_SUBPASS_INPUT</unmanaged>
	SubpassInput = 5,
	/// <unmanaged>SPVC_RESOURCE_TYPE_STORAGE_IMAGE</unmanaged>
	StorageImage = 6,
	/// <unmanaged>SPVC_RESOURCE_TYPE_SAMPLED_IMAGE</unmanaged>
	SampledImage = 7,
	/// <unmanaged>SPVC_RESOURCE_TYPE_ATOMIC_COUNTER</unmanaged>
	AtomicCounter = 8,
	/// <unmanaged>SPVC_RESOURCE_TYPE_PUSH_CONSTANT</unmanaged>
	PushConstant = 9,
	/// <unmanaged>SPVC_RESOURCE_TYPE_SEPARATE_IMAGE</unmanaged>
	SeparateImage = 10,
	/// <unmanaged>SPVC_RESOURCE_TYPE_SEPARATE_SAMPLERS</unmanaged>
	SeparateSamplers = 11,
	/// <unmanaged>SPVC_RESOURCE_TYPE_ACCELERATION_STRUCTURE</unmanaged>
	AccelerationStructure = 12,
	/// <unmanaged>SPVC_RESOURCE_TYPE_RAY_QUERY</unmanaged>
	RayQuery = 13,
	/// <unmanaged>SPVC_RESOURCE_TYPE_SHADER_RECORD_BUFFER</unmanaged>
	ShaderRecordBuffer = 14,
	/// <unmanaged>SPVC_RESOURCE_TYPE_GL_PLAIN_UNIFORM</unmanaged>
	GlPlainUniform = 15,
}

public enum BuiltinResourceType
{
	/// <unmanaged>SPVC_BUILTIN_RESOURCE_TYPE_UNKNOWN</unmanaged>
	Unknown = 0,
	/// <unmanaged>SPVC_BUILTIN_RESOURCE_TYPE_STAGE_INPUT</unmanaged>
	StageInput = 1,
	/// <unmanaged>SPVC_BUILTIN_RESOURCE_TYPE_STAGE_OUTPUT</unmanaged>
	StageOutput = 2,
}

public enum Basetype
{
	/// <unmanaged>SPVC_BASETYPE_UNKNOWN</unmanaged>
	Unknown = 0,
	/// <unmanaged>SPVC_BASETYPE_VOID</unmanaged>
	Void = 1,
	/// <unmanaged>SPVC_BASETYPE_BOOLEAN</unmanaged>
	Boolean = 2,
	/// <unmanaged>SPVC_BASETYPE_INT8</unmanaged>
	Int8 = 3,
	/// <unmanaged>SPVC_BASETYPE_UINT8</unmanaged>
	Uint8 = 4,
	/// <unmanaged>SPVC_BASETYPE_INT16</unmanaged>
	Int16 = 5,
	/// <unmanaged>SPVC_BASETYPE_UINT16</unmanaged>
	Uint16 = 6,
	/// <unmanaged>SPVC_BASETYPE_INT32</unmanaged>
	Int32 = 7,
	/// <unmanaged>SPVC_BASETYPE_UINT32</unmanaged>
	Uint32 = 8,
	/// <unmanaged>SPVC_BASETYPE_INT64</unmanaged>
	Int64 = 9,
	/// <unmanaged>SPVC_BASETYPE_UINT64</unmanaged>
	Uint64 = 10,
	/// <unmanaged>SPVC_BASETYPE_ATOMIC_COUNTER</unmanaged>
	AtomicCounter = 11,
	/// <unmanaged>SPVC_BASETYPE_FP16</unmanaged>
	Fp16 = 12,
	/// <unmanaged>SPVC_BASETYPE_FP32</unmanaged>
	Fp32 = 13,
	/// <unmanaged>SPVC_BASETYPE_FP64</unmanaged>
	Fp64 = 14,
	/// <unmanaged>SPVC_BASETYPE_STRUCT</unmanaged>
	Struct = 15,
	/// <unmanaged>SPVC_BASETYPE_IMAGE</unmanaged>
	Image = 16,
	/// <unmanaged>SPVC_BASETYPE_SAMPLED_IMAGE</unmanaged>
	SampledImage = 17,
	/// <unmanaged>SPVC_BASETYPE_SAMPLER</unmanaged>
	Sampler = 18,
	/// <unmanaged>SPVC_BASETYPE_ACCELERATION_STRUCTURE</unmanaged>
	AccelerationStructure = 19,
}

public enum MSLPlatform
{
	/// <unmanaged>SPVC_MSL_PLATFORM_IOS</unmanaged>
	IOS = 0,
	/// <unmanaged>SPVC_MSL_PLATFORM_MACOS</unmanaged>
	MACOS = 1,
}

public enum MSLIndexType
{
	/// <unmanaged>SPVC_MSL_INDEX_TYPE_NONE</unmanaged>
	None = 0,
	/// <unmanaged>SPVC_MSL_INDEX_TYPE_UINT16</unmanaged>
	Uint16 = 1,
	/// <unmanaged>SPVC_MSL_INDEX_TYPE_UINT32</unmanaged>
	Uint32 = 2,
}

public enum MSLShaderVariableFormat
{
	/// <unmanaged>SPVC_MSL_SHADER_VARIABLE_FORMAT_OTHER</unmanaged>
	Other = 0,
	/// <unmanaged>SPVC_MSL_SHADER_VARIABLE_FORMAT_UINT8</unmanaged>
	Uint8 = 1,
	/// <unmanaged>SPVC_MSL_SHADER_VARIABLE_FORMAT_UINT16</unmanaged>
	Uint16 = 2,
	/// <unmanaged>SPVC_MSL_SHADER_VARIABLE_FORMAT_ANY16</unmanaged>
	Any16 = 3,
	/// <unmanaged>SPVC_MSL_SHADER_VARIABLE_FORMAT_ANY32</unmanaged>
	Any32 = 4,
}

public enum MSLShaderVariableRate
{
	/// <unmanaged>SPVC_MSL_SHADER_VARIABLE_RATE_PER_VERTEX</unmanaged>
	PerVertex = 0,
	/// <unmanaged>SPVC_MSL_SHADER_VARIABLE_RATE_PER_PRIMITIVE</unmanaged>
	PerPrimitive = 1,
	/// <unmanaged>SPVC_MSL_SHADER_VARIABLE_RATE_PER_PATCH</unmanaged>
	PerPatch = 2,
}

public enum MSLSamplerCoord
{
	/// <unmanaged>SPVC_MSL_SAMPLER_COORD_NORMALIZED</unmanaged>
	Normalized = 0,
	/// <unmanaged>SPVC_MSL_SAMPLER_COORD_PIXEL</unmanaged>
	Pixel = 1,
}

public enum MSLSamplerFilter
{
	/// <unmanaged>SPVC_MSL_SAMPLER_FILTER_NEAREST</unmanaged>
	Nearest = 0,
	/// <unmanaged>SPVC_MSL_SAMPLER_FILTER_LINEAR</unmanaged>
	Linear = 1,
}

public enum MSLSamplerMipFilter
{
	/// <unmanaged>SPVC_MSL_SAMPLER_MIP_FILTER_NONE</unmanaged>
	None = 0,
	/// <unmanaged>SPVC_MSL_SAMPLER_MIP_FILTER_NEAREST</unmanaged>
	Nearest = 1,
	/// <unmanaged>SPVC_MSL_SAMPLER_MIP_FILTER_LINEAR</unmanaged>
	Linear = 2,
}

public enum MSLSamplerAddress
{
	/// <unmanaged>SPVC_MSL_SAMPLER_ADDRESS_CLAMP_TO_ZERO</unmanaged>
	ClampToZero = 0,
	/// <unmanaged>SPVC_MSL_SAMPLER_ADDRESS_CLAMP_TO_EDGE</unmanaged>
	ClampToEdge = 1,
	/// <unmanaged>SPVC_MSL_SAMPLER_ADDRESS_CLAMP_TO_BORDER</unmanaged>
	ClampToBorder = 2,
	/// <unmanaged>SPVC_MSL_SAMPLER_ADDRESS_REPEAT</unmanaged>
	Repeat = 3,
	/// <unmanaged>SPVC_MSL_SAMPLER_ADDRESS_MIRRORED_REPEAT</unmanaged>
	MirroredRepeat = 4,
}

public enum MSLSamplerCompareFunc
{
	/// <unmanaged>SPVC_MSL_SAMPLER_COMPARE_FUNC_NEVER</unmanaged>
	Never = 0,
	/// <unmanaged>SPVC_MSL_SAMPLER_COMPARE_FUNC_LESS</unmanaged>
	Less = 1,
	/// <unmanaged>SPVC_MSL_SAMPLER_COMPARE_FUNC_LESS_EQUAL</unmanaged>
	LessEqual = 2,
	/// <unmanaged>SPVC_MSL_SAMPLER_COMPARE_FUNC_GREATER</unmanaged>
	Greater = 3,
	/// <unmanaged>SPVC_MSL_SAMPLER_COMPARE_FUNC_GREATER_EQUAL</unmanaged>
	GreaterEqual = 4,
	/// <unmanaged>SPVC_MSL_SAMPLER_COMPARE_FUNC_EQUAL</unmanaged>
	Equal = 5,
	/// <unmanaged>SPVC_MSL_SAMPLER_COMPARE_FUNC_NOT_EQUAL</unmanaged>
	NotEqual = 6,
	/// <unmanaged>SPVC_MSL_SAMPLER_COMPARE_FUNC_ALWAYS</unmanaged>
	Always = 7,
}

public enum MSLSamplerBorderColor
{
	/// <unmanaged>SPVC_MSL_SAMPLER_BORDER_COLOR_TRANSPARENT_BLACK</unmanaged>
	TransparentBlack = 0,
	/// <unmanaged>SPVC_MSL_SAMPLER_BORDER_COLOR_OPAQUE_BLACK</unmanaged>
	OpaqueBlack = 1,
	/// <unmanaged>SPVC_MSL_SAMPLER_BORDER_COLOR_OPAQUE_WHITE</unmanaged>
	OpaqueWhite = 2,
}

public enum MSLFormatResolution
{
	/// <unmanaged>SPVC_MSL_FORMAT_RESOLUTION_444</unmanaged>
	_444 = 0,
	/// <unmanaged>SPVC_MSL_FORMAT_RESOLUTION_422</unmanaged>
	_422 = 1,
	/// <unmanaged>SPVC_MSL_FORMAT_RESOLUTION_420</unmanaged>
	_420 = 2,
}

public enum MSLChromaLocation
{
	/// <unmanaged>SPVC_MSL_CHROMA_LOCATION_COSITED_EVEN</unmanaged>
	CositedEven = 0,
	/// <unmanaged>SPVC_MSL_CHROMA_LOCATION_MIDPOINT</unmanaged>
	Midpoint = 1,
}

public enum MSLComponentSwizzle
{
	/// <unmanaged>SPVC_MSL_COMPONENT_SWIZZLE_IDENTITY</unmanaged>
	Identity = 0,
	/// <unmanaged>SPVC_MSL_COMPONENT_SWIZZLE_ZERO</unmanaged>
	Zero = 1,
	/// <unmanaged>SPVC_MSL_COMPONENT_SWIZZLE_ONE</unmanaged>
	One = 2,
	/// <unmanaged>SPVC_MSL_COMPONENT_SWIZZLE_R</unmanaged>
	R = 3,
	/// <unmanaged>SPVC_MSL_COMPONENT_SWIZZLE_G</unmanaged>
	G = 4,
	/// <unmanaged>SPVC_MSL_COMPONENT_SWIZZLE_B</unmanaged>
	B = 5,
	/// <unmanaged>SPVC_MSL_COMPONENT_SWIZZLE_A</unmanaged>
	A = 6,
}

public enum MSLSamplerYcbcrModelConversion
{
	/// <unmanaged>SPVC_MSL_SAMPLER_YCBCR_MODEL_CONVERSION_RGB_IDENTITY</unmanaged>
	RgbIdentity = 0,
	/// <unmanaged>SPVC_MSL_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_IDENTITY</unmanaged>
	YcbcrIdentity = 1,
	/// <unmanaged>SPVC_MSL_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_BT_709</unmanaged>
	YcbcrBt709 = 2,
	/// <unmanaged>SPVC_MSL_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_BT_601</unmanaged>
	YcbcrBt601 = 3,
	/// <unmanaged>SPVC_MSL_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_BT_2020</unmanaged>
	YcbcrBt2020 = 4,
}

public enum MSLSamplerYcbcrRange
{
	/// <unmanaged>SPVC_MSL_SAMPLER_YCBCR_RANGE_ITU_FULL</unmanaged>
	ItuFull = 0,
	/// <unmanaged>SPVC_MSL_SAMPLER_YCBCR_RANGE_ITU_NARROW</unmanaged>
	ItuNarrow = 1,
}

[Flags]
public enum HLSLBindingFlags
{
	/// <unmanaged>SPVC_HLSL_BINDING_AUTO_NONE_BIT</unmanaged>
	None = 0,
	/// <unmanaged>SPVC_HLSL_BINDING_AUTO_PUSH_CONSTANT_BIT</unmanaged>
	PushConstant = 1 << 0,
	/// <unmanaged>SPVC_HLSL_BINDING_AUTO_CBV_BIT</unmanaged>
	Cbv = 1 << 1,
	/// <unmanaged>SPVC_HLSL_BINDING_AUTO_SRV_BIT</unmanaged>
	Srv = 1 << 2,
	/// <unmanaged>SPVC_HLSL_BINDING_AUTO_UAV_BIT</unmanaged>
	Uav = 1 << 3,
	/// <unmanaged>SPVC_HLSL_BINDING_AUTO_SAMPLER_BIT</unmanaged>
	Sampler = 1 << 4,
	/// <unmanaged>SPVC_HLSL_BINDING_AUTO_ALL</unmanaged>
	All = 0x7fffffff,
}

public enum CompilerOption
{
	/// <unmanaged>SPVC_COMPILER_OPTION_UNKNOWN</unmanaged>
	Unknown = 0,
	/// <unmanaged>SPVC_COMPILER_OPTION_FORCE_TEMPORARY</unmanaged>
	ForceTemporary = 16777217,
	/// <unmanaged>SPVC_COMPILER_OPTION_FLATTEN_MULTIDIMENSIONAL_ARRAYS</unmanaged>
	FlattenMultidimensionalArrays = 16777218,
	/// <unmanaged>SPVC_COMPILER_OPTION_FIXUP_DEPTH_CONVENTION</unmanaged>
	FixupDepthConvention = 16777219,
	/// <unmanaged>SPVC_COMPILER_OPTION_FLIP_VERTEX_Y</unmanaged>
	FlipVertexY = 16777220,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_SUPPORT_NONZERO_BASE_INSTANCE</unmanaged>
	GLSLSupportNonzeroBaseInstance = 33554437,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_SEPARATE_SHADER_OBJECTS</unmanaged>
	GLSLSeparateShaderObjects = 33554438,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_ENABLE_420PACK_EXTENSION</unmanaged>
	GLSLEnable420packExtension = 33554439,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_VERSION</unmanaged>
	GLSLVersion = 33554440,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_ES</unmanaged>
	GLSLES = 33554441,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_VULKAN_SEMANTICS</unmanaged>
	GLSLVulkanSemantics = 33554442,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_ES_DEFAULT_FLOAT_PRECISION_HIGHP</unmanaged>
	GLSLESDefaultFloatPrecisionHighp = 33554443,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_ES_DEFAULT_INT_PRECISION_HIGHP</unmanaged>
	GLSLESDefaultIntPrecisionHighp = 33554444,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_SHADER_MODEL</unmanaged>
	HLSLShaderModel = 67108877,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_POINT_SIZE_COMPAT</unmanaged>
	HLSLPointSizeCompat = 67108878,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_POINT_COORD_COMPAT</unmanaged>
	HLSLPointCoordCompat = 67108879,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_SUPPORT_NONZERO_BASE_VERTEX_BASE_INSTANCE</unmanaged>
	HLSLSupportNonzeroBaseVertexBaseInstance = 67108880,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_VERSION</unmanaged>
	MSLVersion = 134217745,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_TEXEL_BUFFER_TEXTURE_WIDTH</unmanaged>
	MSLTexelBufferTextureWidth = 134217746,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_AUX_BUFFER_INDEX</unmanaged>
	MSLAuxBufferIndex = 134217747,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SWIZZLE_BUFFER_INDEX</unmanaged>
	MSLSwizzleBufferIndex = 134217747,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_INDIRECT_PARAMS_BUFFER_INDEX</unmanaged>
	MSLIndirectParamsBufferIndex = 134217748,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SHADER_OUTPUT_BUFFER_INDEX</unmanaged>
	MSLShaderOutputBufferIndex = 134217749,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SHADER_PATCH_OUTPUT_BUFFER_INDEX</unmanaged>
	MSLShaderPatchOutputBufferIndex = 134217750,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SHADER_TESS_FACTOR_OUTPUT_BUFFER_INDEX</unmanaged>
	MSLShaderTessFactorOutputBufferIndex = 134217751,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SHADER_INPUT_WORKGROUP_INDEX</unmanaged>
	MSLShaderInputWorkgroupIndex = 134217752,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ENABLE_POINT_SIZE_BUILTIN</unmanaged>
	MSLEnablePointSizeBuiltin = 134217753,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_DISABLE_RASTERIZATION</unmanaged>
	MSLDisableRasterization = 134217754,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_CAPTURE_OUTPUT_TO_BUFFER</unmanaged>
	MSLCaptureOutputToBuffer = 134217755,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SWIZZLE_TEXTURE_SAMPLES</unmanaged>
	MSLSwizzleTextureSamples = 134217756,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_PAD_FRAGMENT_OUTPUT_COMPONENTS</unmanaged>
	MSLPadFragmentOutputComponents = 134217757,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_TESS_DOMAIN_ORIGIN_LOWER_LEFT</unmanaged>
	MSLTessDomainOriginLowerLeft = 134217758,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_PLATFORM</unmanaged>
	MSLPlatform = 134217759,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ARGUMENT_BUFFERS</unmanaged>
	MSLArgumentBuffers = 134217760,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_EMIT_PUSH_CONSTANT_AS_UNIFORM_BUFFER</unmanaged>
	GLSLEmitPushConstantAsUniformBuffer = 33554465,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_TEXTURE_BUFFER_NATIVE</unmanaged>
	MSLTextureBufferNative = 134217762,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_EMIT_UNIFORM_BUFFER_AS_PLAIN_UNIFORMS</unmanaged>
	GLSLEmitUniformBufferAsPlainUniforms = 33554467,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_BUFFER_SIZE_BUFFER_INDEX</unmanaged>
	MSLBufferSizeBufferIndex = 134217764,
	/// <unmanaged>SPVC_COMPILER_OPTION_EMIT_LINE_DIRECTIVES</unmanaged>
	EmitLineDirectives = 16777253,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_MULTIVIEW</unmanaged>
	MSLMultiview = 134217766,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_VIEW_MASK_BUFFER_INDEX</unmanaged>
	MSLViewMaskBufferIndex = 134217767,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_DEVICE_INDEX</unmanaged>
	MSLDeviceIndex = 134217768,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_VIEW_INDEX_FROM_DEVICE_INDEX</unmanaged>
	MSLViewIndexFromDeviceIndex = 134217769,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_DISPATCH_BASE</unmanaged>
	MSLDispatchBase = 134217770,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_DYNAMIC_OFFSETS_BUFFER_INDEX</unmanaged>
	MSLDynamicOffsetsBufferIndex = 134217771,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_TEXTURE_1D_AS_2D</unmanaged>
	MSLTexture1dAs2D = 134217772,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ENABLE_BASE_INDEX_ZERO</unmanaged>
	MSLEnableBaseIndexZero = 134217773,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_IOS_FRAMEBUFFER_FETCH_SUBPASS</unmanaged>
	MSLIOSFramebufferFetchSubpass = 134217774,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_FRAMEBUFFER_FETCH_SUBPASS</unmanaged>
	MSLFramebufferFetchSubpass = 134217774,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_INVARIANT_FP_MATH</unmanaged>
	MSLInvariantFpMath = 134217775,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_EMULATE_CUBEMAP_ARRAY</unmanaged>
	MSLEmulateCubemapArray = 134217776,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ENABLE_DECORATION_BINDING</unmanaged>
	MSLEnableDecorationBinding = 134217777,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_FORCE_ACTIVE_ARGUMENT_BUFFER_RESOURCES</unmanaged>
	MSLForceActiveArgumentBufferResources = 134217778,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_FORCE_NATIVE_ARRAYS</unmanaged>
	MSLForceNativeArrays = 134217779,
	/// <unmanaged>SPVC_COMPILER_OPTION_ENABLE_STORAGE_IMAGE_QUALIFIER_DEDUCTION</unmanaged>
	EnableStorageImageQualifierDeduction = 16777268,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_FORCE_STORAGE_BUFFER_AS_UAV</unmanaged>
	HLSLForceStorageBufferAsUav = 67108917,
	/// <unmanaged>SPVC_COMPILER_OPTION_FORCE_ZERO_INITIALIZED_VARIABLES</unmanaged>
	ForceZeroInitializedVariables = 16777270,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_NONWRITABLE_UAV_TEXTURE_AS_SRV</unmanaged>
	HLSLNonwritableUavTextureAsSrv = 67108919,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ENABLE_FRAG_OUTPUT_MASK</unmanaged>
	MSLEnableFragOutputMask = 134217784,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ENABLE_FRAG_DEPTH_BUILTIN</unmanaged>
	MSLEnableFragDepthBuiltin = 134217785,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ENABLE_FRAG_STENCIL_REF_BUILTIN</unmanaged>
	MSLEnableFragStencilRefBuiltin = 134217786,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ENABLE_CLIP_DISTANCE_USER_VARYING</unmanaged>
	MSLEnableClipDistanceUserVarying = 134217787,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_ENABLE_16BIT_TYPES</unmanaged>
	HLSLEnable16bitTypes = 67108924,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_MULTI_PATCH_WORKGROUP</unmanaged>
	MSLMultiPatchWorkgroup = 134217789,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SHADER_INPUT_BUFFER_INDEX</unmanaged>
	MSLShaderInputBufferIndex = 134217790,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SHADER_INDEX_BUFFER_INDEX</unmanaged>
	MSLShaderIndexBufferIndex = 134217791,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_VERTEX_FOR_TESSELLATION</unmanaged>
	MSLVertexForTessellation = 134217792,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_VERTEX_INDEX_TYPE</unmanaged>
	MSLVertexIndexType = 134217793,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_FORCE_FLATTENED_IO_BLOCKS</unmanaged>
	GLSLForceFlattenedIOBlocks = 33554498,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_MULTIVIEW_LAYERED_RENDERING</unmanaged>
	MSLMultiviewLayeredRendering = 134217795,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ARRAYED_SUBPASS_INPUT</unmanaged>
	MSLArrayedSubpassInput = 134217796,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_R32UI_LINEAR_TEXTURE_ALIGNMENT</unmanaged>
	MSLR32uiLinearTextureAlignment = 134217797,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_R32UI_ALIGNMENT_CONSTANT_ID</unmanaged>
	MSLR32uiAlignmentConstantID = 134217798,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_FLATTEN_MATRIX_VERTEX_INPUT_SEMANTICS</unmanaged>
	HLSLFlattenMatrixVertexInputSemantics = 67108935,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_IOS_USE_SIMDGROUP_FUNCTIONS</unmanaged>
	MSLIOSUseSimdgroupFunctions = 134217800,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_EMULATE_SUBGROUPS</unmanaged>
	MSLEmulateSubgroups = 134217801,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_FIXED_SUBGROUP_SIZE</unmanaged>
	MSLFixedSubgroupSize = 134217802,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_FORCE_SAMPLE_RATE_SHADING</unmanaged>
	MSLForceSampleRateShading = 134217803,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_IOS_SUPPORT_BASE_VERTEX_INSTANCE</unmanaged>
	MSLIOSSupportBaseVertexInstance = 134217804,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_OVR_MULTIVIEW_VIEW_COUNT</unmanaged>
	GLSLOvrMultiviewViewCount = 33554509,
	/// <unmanaged>SPVC_COMPILER_OPTION_RELAX_NAN_CHECKS</unmanaged>
	RelaxNanChecks = 16777294,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_RAW_BUFFER_TESE_INPUT</unmanaged>
	MSLRawBufferTeseInput = 134217807,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SHADER_PATCH_INPUT_BUFFER_INDEX</unmanaged>
	MSLShaderPatchInputBufferIndex = 134217808,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_MANUAL_HELPER_INVOCATION_UPDATES</unmanaged>
	MSLManualHelperInvocationUpdates = 134217809,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_CHECK_DISCARDED_FRAG_STORES</unmanaged>
	MSLCheckDiscardedFragStores = 134217810,
	/// <unmanaged>SPVC_COMPILER_OPTION_GLSL_ENABLE_ROW_MAJOR_LOAD_WORKAROUND</unmanaged>
	GLSLEnableRowMajorLoadWorkaround = 33554515,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_ARGUMENT_BUFFERS_TIER</unmanaged>
	MSLArgumentBuffersTier = 134217812,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_SAMPLE_DREF_LOD_ARRAY_AS_GRAD</unmanaged>
	MSLSampleDrefLodArrayAsGrad = 134217813,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_READWRITE_TEXTURE_FENCES</unmanaged>
	MSLReadwriteTextureFences = 134217814,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_REPLACE_RECURSIVE_INPUTS</unmanaged>
	MSLReplaceRecursiveInputs = 134217815,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_AGX_MANUAL_CUBE_GRAD_FIXUP</unmanaged>
	MSLAgxManualCubeGradFixup = 134217816,
	/// <unmanaged>SPVC_COMPILER_OPTION_MSL_FORCE_FRAGMENT_WITH_SIDE_EFFECTS_EXECUTION</unmanaged>
	MSLForceFragmentWithSideEffectsExecution = 134217817,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_USE_ENTRY_POINT_NAME</unmanaged>
	HLSLUseEntryPointName = 67108954,
	/// <unmanaged>SPVC_COMPILER_OPTION_HLSL_PRESERVE_STRUCTURED_BUFFERS</unmanaged>
	HLSLPreserveStructuredBuffers = 67108955,
}




#endregion