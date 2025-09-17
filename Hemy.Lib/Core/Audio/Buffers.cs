namespace Hemy.Lib.Core.Audio;

using System.Runtime.InteropServices;


// [StructLayout(LayoutKind.Explicit)]
// public unsafe struct Buffer
// {
//     // public enum BufferState { Compressed, stream, normal, fixe, circular, ring }

//      /// <summary> Number of Bytes</summary>
//     [FieldOffset(0)]
//     public int numberOfBytes;
//     [FieldOffset(8)]
//     private byte[] byteBuffer;
//     [FieldOffset(8)]
//     private float[] floatBuffer;
//     [FieldOffset(8)]
//     private short[] shortBuffer;
//     [FieldOffset(8)]
//     private int[] intBuffer;

   

//     public void RingBuffer() { }// Or circular 

//     public void CreatePool()
//     {
//         //Size
//         //id or name
//         //used
//         // sample, format ,...
//         // length
//     }
//     public struct AudioBuffer<TDataFormat>
//     {
//         // Buffer sound
//         public uint Id = 0;// TODO : ALL Id Are GUID 
//         public TDataFormat[] data = null!;
//         public int Frequence = 0;
//         //         public int BufferId;//Pool stream size  name, crop  +>start  end  size
//         //         public long SizeKBytes;
//         //         public int SampleRate;
//         //         public int SampleSize;
//         //         public int CurrentPosition;
//         //         public int Channel ; //always 1 MOno for 3D sound

//         public AudioBuffer()
//         {
//         }

//         // public AudioFormat Format = 0;

//         /// <summary>
//         /// Tailledu buffer en byte
//         /// </summary>
//         public int Length => data == null ? 0 : data.Length;
//     }


//         public enum BufferState { Compressed, stream, normal, fixe, circle }

  

// }

  