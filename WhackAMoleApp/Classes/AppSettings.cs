using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.ComponentModel;

namespace WhackAMoleApp
{
    public class AppSettings : BaseAppSettings<AppSettings>
    {
        [DefaultValue(GameDifficultyTypes.NORMAL)]
        public GameDifficultyTypes Difficulty { get; set; } = GameDifficultyTypes.NORMAL;

        [DefaultValue("Mole Whacker")]
        public string PlayerName { get; set; } = "Mole Whacker";

        [DefaultValue(50f)]
        public float Volume { get; set; } = 50f;
    }

    public abstract class BaseAppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
                t = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName), new JsonSerializerSettings() {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    // Just in case someone screws up with the settings, loads defaults instead.
                    Error = (o, e) =>
                    {
                        var currentError = e.ErrorContext.Error.Message;
                        e.ErrorContext.Handled = true;
                    }
                });
            return t;
        }
    }
}
