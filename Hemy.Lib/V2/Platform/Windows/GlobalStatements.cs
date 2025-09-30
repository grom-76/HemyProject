#if WINDOWS

global using System;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Security;
global using System.Threading;


// https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types
global using const_char = System.Byte;
global using BOOL = System.Int32;

global using size_t = System.UIntPtr;
global using uint32_t = System.UInt32;
global using uint64_t = System.UInt64;
global using uint8_t = System.Byte;
global using int32_t = System.Int32;
global using int64_t = System.Int64;
global using uint16_t = System.UInt16;

global using VkBool32 = System.UInt32;
global using VkDeviceAddress = System.UInt64;
global using VkDeviceSize = System.UInt64;
global using Flag = System.Int32;

using HRESULT = System.Int32;

#endif