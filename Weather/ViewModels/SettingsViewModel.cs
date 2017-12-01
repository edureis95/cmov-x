using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Weather
{
    public class SettingsViewModel : BaseViewModel
    {
        public List<KeyValuePair<string, bool>> settings;
        public SettingsViewModel()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "Settings");

            if (File.Exists(filename))
            {
                using (var streamReader = new StreamReader(filename))
                {
                    string content = streamReader.ReadToEnd();
                    settings = JsonConvert.DeserializeObject<List<KeyValuePair<string, bool>>>(content);
                }
            }
            else
            {
                settings = new List<KeyValuePair<string, bool>>()
                {
                    new KeyValuePair<string, bool>("fahrenheit", false),
                    new KeyValuePair<string, bool>("celcius", true),
                    new KeyValuePair<string, bool>("kph", true),
                    new KeyValuePair<string, bool>("mph", false)
                };
            }
        }

        public void SaveSettings()
        {
            var itemsJSON = JsonConvert.SerializeObject(settings);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "Settings");

            using (var streamWriter = new StreamWriter(filename))
            {
                streamWriter.WriteLine(itemsJSON);
            }
        }

        public bool GetSettingsValueByName(string name)
        {
            return settings.Find(pair => pair.Key == name).Value;
        }

        public void ChangeSettingsValueByName(string name, bool value)
        {
            settings.RemoveAll(pair => pair.Key == name);
            settings.Add(new KeyValuePair<string, bool>(name, value));
        }

        public void SetCelcius(bool value)
        {
            IsCelsius = value;
        }

        public void SetKph(bool value)
        {
            IsKph = value;
        }
    }
}
