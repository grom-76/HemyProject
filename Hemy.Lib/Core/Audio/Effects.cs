

namespace Hemy.Lib.Core.Audio;



/*
 //https://github.com/piRepos/pEngine-del/blob/master/pEngine/Audio/Mixing/Mixer.cs

    //see https://github.com/raysan5/rfxgen/blob/master/src/rfxgen.h

 Différens format de sons

    public static class OGG { }
    public static class WAV{}
    public static class MP3 {}
    public static class FLAC{}
    public static class XM{}
    public static class Midi{}
    public static class OPUS{}
    public static class MOD{}

    Filters/ see miniaudio engine???             
  
// see  AudioEmitter  :  https://www.maxicours.com/se/cours/caracteristiques-des-sons-musicaux/

    AudioEngine.cs(Need AudioDevice )
        Init( ILoader? AudioConfig )
        AudioDevice.cs ( load() ,init() , release() , config , capabilities/infos , data )
        AudioRender
        
        => SetMasterVolume(0.0 to1.0f log );
        => var sound = ImportSound2D(waveFile) [ use struct Sound ]
        => var source = CreateSound2D(source) [ use struct Source ]
        => PlaySound2D(source, loop, volume) 
        => advanced system for game 
        => sttream music , load many sources ...


  RitaEngine.Audio ( need SystemsDevice ; Math ; IO )

USE NAUDIO => no longer maintien https://github.com/naudio/NAudio
 For effect and other // https://github.com/piRepos/pEngine-del/
  Render => need SystemDevice Graphic Init
  Listenr
  Source / Emiters
  Buffer
  Capture
  Encode/Decoder
  Effects
  Filters
  Generators ( noise)
  Mixer / Equalizer 
  DSP
  FastFourierTransform ( see math)
  SoundEnveloppe
      Attaque
      Declin
      Maintien 
      Extincion
      Hauteur
      RaylibBindings  https://github.com/raysan5/rfxgen
      Need MAth Rand ( Xoshiro128** SplitMix64)
      BaseType WaveParams 
          // Random seed used to generate the wave => int randSeed;
          // Wave type (square, sawtooth, sine, noise)    int waveTypeValue;
          // Wave envelope parameters   float attackTimeValue; float sustainTimeValue;  float sustainPunchValue;  float decayTimeValue;
          // Frequency parameters   float startFrequencyValue;   float minFrequencyValue;   float slideValue;    float deltaSlideValue;   float vibratoDepthValue;   float vibratoSpeedValue;//float vibratoPhaseDelayValue;
          // Tone change parameters    float changeAmountValue;    float changeSpeedValue;    
          // Square wave parameters    float squareDutyValue;    float dutySweepValue;
          // Repeat parameters    float repeatSpeedValue;
          // Phaser parameters    float phaserOffsetValue;    float phaserSweepValue;
          // Filter parameters    float lpfCutoffValue;    float lpfCutoffSweepValue;    float lpfResonanceValue;    float hpfCutoffValue;    float hpfCutoffSweepValue;
          // Sound generation functions
              WaveParams GenPickupCoin(void);      // Generate sound: Pickup/Coin
              WaveParams GenLaserShoot(void);      // Generate sound: Laser shoot
              WaveParams GenExplosion(void);       // Generate sound: Explosion
              WaveParams GenPowerup(void);         // Generate sound: Powerup
              WaveParams GenHitHurt(void);         // Generate sound: Hit/Hurt
              WaveParams GenJump(void);            // Generate sound: Jump
              WaveParams GenBlipSelect(void);      // Generate sound: Blip/Select
              WaveParams GenRandomize(void);       // Generate random sound
              void WaveMutate(WaveParams *params); // Mutate current sound
              */






/// <summary>
/// Applique un effets que pour les buffers ? 
/// </summary>
public class Effects
{
    //BarGates , Chorus Flanger Glitcher WahWah

   
   // Echo reverb delay
}

  


  