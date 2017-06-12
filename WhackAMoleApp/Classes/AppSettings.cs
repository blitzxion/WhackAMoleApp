using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace WhackAMoleApp
{
    public class AppSettings : BaseAppSettings<AppSettings>
    {
        public GameDifficultyTypes Difficulty { get; set; } = GameDifficultyTypes.NORMAL;
        public string PlayerName { get; set; } = "Mole Whacker";
        public float Volume { get; set; } = 50;
    }

    public abstract class BaseAppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        //public static event Action<T> OnSaving;
        //public static event Action<T> OnSaved;
        //public static event Action OnLoading;
        //public static event Action<T> OnLoaded;


        public void Save(string fileName = DEFAULT_FILENAME)
        {
            //OnSaving?.Invoke((T)Convert.ChangeType(this, typeof(T)));
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
            //OnSaved?.Invoke((T)Convert.ChangeType(this, typeof(T)));
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            //OnSaving?.Invoke(pSettings);
            File.WriteAllText(fileName, JsonConvert.SerializeObject(pSettings));
            //OnSaved?.Invoke(pSettings);
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            //OnLoading?.Invoke();

            T t = new T();
            if (File.Exists(fileName))
                t = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));

            //OnLoaded?.Invoke(t);

            return t;
        }
    }
}
