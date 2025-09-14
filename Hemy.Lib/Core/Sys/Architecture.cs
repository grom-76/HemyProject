namespace Hemy.Lib.Core.Sys;
#if WINDOWS
/// <summary> ARchitecture system possible pour la platform selectionné </summary>
public enum Architecture : byte
{
	Unsupported,
	x86,
	x64,
	Arm,
	Arm64,
	Cortex,
	_8_bits,
	_16_bits,
}
