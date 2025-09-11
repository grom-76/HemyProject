#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Common;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static class LibrariesName
{
    //All function is in list at : https://learn.microsoft.com/en-us/cpp/c-runtime-library/reference/crt-alphabetical-function-reference?view=msvc-170
    internal const string Ucrt = "ucrtbase";
    internal const string Kernel = "kernel32";// https://www.geoffchappell.com/studies/windows/win32/kernel32/api/index.htm
    internal const string User = "user32";// https://learn.microsoft.com/en-us/windows/win32/api/winuser/
    internal const string Gdi = "gdi32";
    internal const string SHCore = "shcore";
    internal const string XInput = "xinput1_4";
    internal const string Vulkan = "vulkan-1";
    internal const string XAudio2_9 = "XAudio2_9";
    internal const string XAudio2_8 = "XAudio2_8";
    internal const string XAudio1_7 = "XAudio1_7";

    // internal const string WinHttp = "winhttp.dll";
    // internal const string WinMM = "winmm.dll";
    // internal const string Wldap32 = "wldap32.dll";
    // internal const string Ws2_32 = "ws2_32.dll";
    internal const string WebSocket = "websocket.dll";
    internal const string HttpApi = "httpapi.dll";

    // internal const string Wtsapi32 = "wtsapi32.dll";

    // internal const string ShaderCompiler = "shaderc_shared";
}


internal unsafe static class Consts
{
	public const uint HRESULT_S_OK = 0;
	public const uint VK_FALSE = 0U;
	public const uint VK_TRUE = 1U;

	// 0x00000000	S_OK	Operation successful
	// 0x80004001	E_NOTIMPL	Not implemented
	// 0x80004002	E_NOINTERFACE	No such interface supported
	// 0x80004003	E_POINTER	Pointer that is not valid
	// 0x80004004	E_ABORT	Operation aborted
	// 0x80004005	E_FAIL	Unspecified failure
	// 0x8000FFFF	E_UNEXPECTED	Unexpected failure
	// 0x80070005	E_ACCESSDENIED	General access denied error
	// 0x80070006	E_HANDLE	Handle that is not valid
	// 0x8007000E	E_OUTOFMEMORY	Failed to allocate necessary memory
	// 0x80070057	E_INVALIDARG	One or more arguments are not valid
	//  #define __HRESULT_FROM_WIN32(x) ((HRESULT)(x) <= 0 ? ((HRESULT)(x)) : ((HRESULT) (((x) & 0x0000FFFF) | (FACILITY_WIN32 << 16) | 0x80000000)))

	// src : https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-erref/0c0bcf55-277e-4120-b5dc-f6115fc8dc38
	// list : https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-erref/705fb797-2175-4a90-b5a3-3918024b10b8
	// WIN 32 ERROR CODES https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-erref/18d8fbe8-a967-4f1c-ae50-99ca8e491d2d


}

#endif
