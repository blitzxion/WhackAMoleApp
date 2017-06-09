using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio;
using NAudio.Wave;

namespace WhackAMoleApp
{
    public class WaveSound
    {
        Stream _soundBytes { get; set; }
        WaveFileReader _waveReader { get; set; }
        IWavePlayer _waveOutDevice { get; set; }

        public WaveSound(Stream bytes)
        {
            _soundBytes = bytes;
            _waveReader = new WaveFileReader(_soundBytes);
        }

        public void Play()
        {
            _waveReader.Position = 0;

            _waveOutDevice = new WaveOut();
            _waveOutDevice.Init(_waveReader);
            _waveOutDevice.Play();
        }

    }

    public static class SoundPlayer
    {
        public static void PlaySound(this Stream stream)
        {
            var wod = new WaveOut();
        }

        public static void PlaySound(this UnmanagedMemoryStream stream)
        {
            using (var wfr = new WaveFileReader(stream))
            {
                using (WaveChannel32 wc = new WaveChannel32(wfr) { PadWithZeroes = false })
                {
                    using (var audioOutput = new DirectSoundOut())
                    {
                        audioOutput.Init(wc);
                        audioOutput.Play();
                    }
                }
            }
        }

        public static void PlaySound(this DirectSoundOut sound)
        {
            sound.Play();
        }

        public static DirectSoundOut LoadSound(this UnmanagedMemoryStream stream)
        {
            var wfr = new WaveFileReader(stream);
            var wc = new WaveChannel32(wfr);
            var dso = new DirectSoundOut();
            dso.Init(wc);
            return dso;
        }

        

    }
}
