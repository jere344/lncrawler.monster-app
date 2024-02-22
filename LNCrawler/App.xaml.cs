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
        }


        private void SetLanguageDictionary()
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
    }
}
