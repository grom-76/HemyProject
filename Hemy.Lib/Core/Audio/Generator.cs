namespace Hemy.Lib.Core.Audio;

using Hemy.Lib.Core.Math;

public static partial class Generator 
{

    public static partial class WaveForm
    {
        //sine , 
        /// <summary>
        /// Creé un son sinusoidal en fonction de la fréquence 
        /// </summary>
        /// <param name="frequence"> audible 500 à 5000</param>
        /// <param name="sampleRate"> 44100 = 1sec </param>
        /// <param name="amplitude"> max 1.0f </param>
        /// <returns></returns>
        public static short[] SinusWave(float frequence = 1500/* */ , int durationInSec = 1, int sampleRate = 44100, float amplitude = 0.5f)
        {
            int _sampleRate = sampleRate;
            short[] buffer = new short[_sampleRate * durationInSec];
            float _amplitude = amplitude * short.MaxValue;
            float frequency = frequence;
            float dt = Math._2PIf / (float)_sampleRate;
            for (int n = 0; n < buffer.Length; n++)
            {
                buffer[n] = (short)(_amplitude * Math.Sin(n * dt * frequency));
            }
            return buffer;
        }
        //square, 

        //triangle, 

        //sawtooth
    
        // Pulse wave (includes Square wave)
    }

    public static class Noise{
            //white
            //pink
            //brownian
    }

  
   



}
