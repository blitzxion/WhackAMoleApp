using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMoleApp
{
    public static class MusicManager
    {
        static Mp3Sound _gameMusic { get; set; }
        static Mp3Sound _menuMusic { get; set; }

        static float _volume { get; set; }
        public static float Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = value;

                _gameMusic.Volume = _volume;
                _menuMusic.Volume = _volume;

            }
        }

        public static Mp3Sound MenuMusic {
            get {
                if (_menuMusic == null)
                {
                    _menuMusic = new Mp3Sound(new MemoryStream(Properties.Resources.menu))
                    {
                        EnableLoop = true,
                        Volume = (AppSettings.Load().Volume / 100)
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
                        Volume = (AppSettings.Load().Volume / 100)
                    };
                }

                return _gameMusic;
            }
        }

    }
}
