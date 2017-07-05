using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMoleApp
{
    public static class MusicManager
    {
        static Mp3Sound _gameMusic { get; set; }
        static Mp3Sound _menuMusic { get; set; }

        static float _bgmVolume { get; set; }
        public static float BGMVolume
        {
            get
            {
                return _bgmVolume;
            }
            set
            {
                _bgmVolume = value;
                MenuMusic.Volume = _bgmVolume;
                GameMusic.Volume = _bgmVolume;
            }
        }

        static float? _sfxVolume { get; set; }
        public static float SFXVolume
        {
            get
            {
                if (!_sfxVolume.HasValue)
                    _sfxVolume = AppSettings.Load().SFXVolume / 100f;

                return _sfxVolume.Value;
            }
            set
            {
                _sfxVolume = value;
            }
        }

        public static Mp3Sound MenuMusic {
            get {
                if (_menuMusic == null)
                {
                    _menuMusic = new Mp3Sound(new MemoryStream(Properties.Resources.menu))
                    {
                        EnableLoop = true,
                        Volume = (AppSettings.Load().BGMVolume / 100)
                    };
                }

                return _menuMusic;
            }
        }

        public static Mp3Sound GameMusic
        {
            get
            {
                if (_gameMusic == null)
                {
                    _gameMusic = new Mp3Sound(new MemoryStream(Properties.Resources.gameplay))
                    {
                        EnableLoop = true,
                        Volume = (AppSettings.Load().BGMVolume / 100)
                    };
                }

                return _gameMusic;
            }
        }


        public static WaveSound GetSound(Stream sound)
        {
            var newSound = new MemoryStream();
            var selectedSound = sound;

            // Copy the sound to the selected sound
            selectedSound.CopyTo(newSound);

            // Must reset this, otherwise, reuse of the sound causes no playback to happen.
            newSound.Position = 0;
            selectedSound.Position = 0;

            var wave = new WaveSound(newSound) { Volume = SFXVolume };
            wave.OnPlaybackStopped += () => { wave.Dispose(); };

            return wave;
        }

        public static void Shutdown()
        {
            GameMusic.Stop();
            MenuMusic.Stop();

            GameMusic.Dispose();
            MenuMusic.Dispose();

        }

    }

}
