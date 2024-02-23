using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Threading;

namespace LNCrawler
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetLanguageDictionary();
            LoadSettings();
        }


        public void SetLanguageDictionary()
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "en":
                    dict.Source = new Uri(".\\Resources\\StringResources.en.xaml", UriKind.Relative);
                    break;
                case "fr":
                    dict.Source = new Uri(".\\Resources\\StringResources.fr.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri(".\\Resources\\StringResources.en.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dict);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            SaveSettings();
        }

        public static void SaveSettings()
        {
            // we save Application.Current.Properties in settings.json
            // we can load it at startup
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(Application.Current.Properties);
            System.IO.File.WriteAllText("settings.json", json);
        }

        public static void LoadSettings()
        {
            // we load Application.Current.Properties from settings.json
            // we can load it at startup
            if (System.IO.File.Exists("settings.json"))
            {
                string json = System.IO.File.ReadAllText("settings.json");
                var values = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.IDictionary>(json);
                if (values == null)
                {
                    return;
                }
                foreach (var key in values.Keys)
                {
                    var str_key = key.ToString();
                    if (str_key == null)
                    {
                        continue;
                    }
                    Application.Current.Properties[str_key] = values[key];
                }

            }
        }
    }
}
