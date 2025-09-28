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


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class WindowsInputs
{
	internal unsafe static class Mouses
	{


	}
	internal unsafe static class Keyboards
	{


	}

	//Mouse 

	//Keyboard

	//Gampad ?
}
