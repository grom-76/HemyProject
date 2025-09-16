

namespace Hemy.Lib.Core.Audio;

using Hemy.Lib.Core.Math;

/// <summary>
/// persone ou objet ou autre qui emet un son( source dans openal)
/// </summary>
public class Emiter // = source
{

    public uint Id;
    public Vector3 Position;// position de départ en 3D
    public Vector3 Velocity;// vitesse deplacement de la source en 3D
    public float Pitch = 1.0f; // vitesse play
    public float Gain = 1.0f; // egal volume
    public bool Loop = false;// repeat
    public bool IsBufferAttached = false;
    public uint BufferID = 0;
    
    //         public uint Order;
    //         public int Id;
    //         public bool IsPlayable;//indique si l'emitter n'est pas disparu/mort => mise en cache en cas de réutilisation
    //         public bool IsPlaying;
    //         public long Loop;
    //         public float Volume;
    //         public float Pitch;
    //         public float Pan;
    //         public float Reverb;//For effects
    // private Source[] Sources = null!;

    // private Buffers[] Buffers = null!;
    // void Play();                                    // Play a sound
    // void Stop(Sound sound);                                    // Stop playing a sound
    // void Pause(Sound sound);                                   // Pause a sound
    // void Resume(Sound sound);                                  // Resume a paused sound
    // all functions add effects .....
    // Create, Cache , dispose , 
}
