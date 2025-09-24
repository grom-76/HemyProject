namespace Hemy.Lib.Tools.Shaders.SpirvCross;


using static Native;

public unsafe static class Helper
{

    public static void GLSLCompiler()
    {
        byte[] vertexBytecode = null;
        Context* context = null;
        var result = spvc_context_create( context );


        spvc_context_parse_spirv(context, vertexBytecode,  spvc_parsed_ir parsedIr);

        spvc_context_create_compiler(context, Backend.GLSL, parsedIr, CaptureMode.TakeOwnership,  spvc_compiler compiler);


        spvc_compiler_create_compiler_options(compiler, out spvc_compiler_options options);

        spvc_compiler_options_set_uint(options, CompilerOption.GLSLVersion,450);
        
        spvc_compiler_install_compiler_options(compiler, options);

        spvc_compiler_compile(compiler,  glsl);


        spvc_context_release_allocations(context);
        spvc_context_destroy(context);
    }


}