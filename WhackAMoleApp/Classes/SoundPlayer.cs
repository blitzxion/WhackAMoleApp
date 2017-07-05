using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace WhackAMoleApp
{
    public abstract class SoundPlayer<TSoundReader> : IDisposable
        where TSoundReader : WaveStream
    {
        protected Stream _soundStream { get; set; }
        protected TSoundReader _soundReader { get; set; }

        protected WasapiOut _outDevice { get; set; }

        public virtual bool EnableLoop { get; set; } = false;

        public event Action OnPlaybackStopped;

        protected virtual float _volume { get; set; } = 1f;
        public virtual float Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = value;
                if (_outDevice != null)
                    SetVolumeInternal();
            }
        }

        protected SoundPlayer()
        {
            _outDevice = new WasapiOut();
            _outDevice.PlaybackStopped += (o, e) => {
                OnPlaybackStopped?.Invoke();
                if (EnableLoop) Play(EnableLoop);
            };
        }

        public virtual void Pause()
        {
            if (_outDevice != null)
            {
                _outDevice.Pause();
            }
        }

        public virtual void Play(bool loop = false)
        {
            EnableLoop = loop;

            if (_soundReader != null && _outDevice != null)
            {
                // Only place it back to the start if we're in a stopped state.
                if (_outDevice.PlaybackState == PlaybackState.Stopped)
                    _soundReader.Position = 0;

                _outDevice.Play();
            }
        }

        public virtual void Stop()
        {
            if (_outDevice != null)
            {
                EnableLoop = false;
                _outDevice.Stop();
            }
        }

        protected virtual void SetVolumeInternal()
        {
            if (_outDevice != null)
            {
                // Only for WasapiOut
                var vols = _outDevice.AudioStreamVolume.GetAllVolumes();
                vols = vols.Select(x => x = Volume).ToArray();
                _outDevice.AudioStreamVolume.SetAllVolumes(vols);

                // Generic Volumne Setting
                //_outDevice.Volume = Volume;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _outDevice.Dispose();
                    _soundReader.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }

    public class WaveSound : SoundPlayer<WaveFileReader>
    {
        public WaveSound(Stream soundStream)
        {
            _soundStream = soundStream;
            _soundReader = new WaveFileReader(_soundStream);

            _outDevice.Init(_soundReader);

            _outDevice.PlaybackStopped += (o, e) => {
                if (EnableLoop) Play(EnableLoop);
            };
        }
    }

    public class Mp3Sound : SoundPlayer<Mp3FileReader>
    {
        public Mp3Sound(Stream soundStream)
        {
            _soundStream = soundStream;
            _soundReader = new Mp3FileReader(_soundStream);
            
            _outDevice.Init(_soundReader);

            _outDevice.PlaybackStopped += (o, e) => { if (EnableLoop) Play(EnableLoop); };
        }
    }

}
