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
            _waveOutDevice = new WaveOut();
            _waveOutDevice.Init(_waveReader);
        }

        public void Play()
        {
            _waveReader.Position = 0;
            _waveOutDevice.Play();
        }

    }

}
