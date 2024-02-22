using System.Windows;
using System.Windows.Controls;
using System;
using LNCrawler.ViewModels;
using LNCrawler.API.Models;
using System.Windows.Navigation;
using System.Threading;

namespace LNCrawler.Views
{
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();

            var vm = new VMHomePage();
            DataContext = vm;

            // Subscribe to the Loaded event to set the title and size of the window
            this.Loaded += Home_Loaded;
            SetLanguageDictionary();
        }

        /// <summary>
        /// Set the title and size of the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Loaded(object sender, RoutedEventArgs e)
        {
            // Get a reference to the parent window, we can't call Window.GetWindow(this) in the constructor because the window is not yet created
            Window window = Window.GetWindow(this);

            if (window != null)
            {
                window.Title = "Accueil";
            }
        }

        private void OpenSearchPage(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow)?.GetNavigationService().Navigate(new Uri("Views/Search.xaml", UriKind.Relative));
        }

        private void _OpenNovelPage(Novel novel)
        {
            ((MainWindow)Application.Current.MainWindow)?.GetNavigationService().Navigate(new Uri("Views/ViewNovelInfo.xaml?novelSlug=" + novel.Slug + "&sourceSlug=" + novel.PreferedSource, UriKind.Relative));
        }

        private void OpenNovelPage(object sender, RoutedEventArgs e)
        {
            _OpenNovelPage((Novel)((Button)sender).DataContext);
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
