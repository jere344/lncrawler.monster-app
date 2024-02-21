using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using LNCrawler.ViewModels;

namespace LNCrawler.Views
{

    public partial class ViewNovelInfo : Page
    {
        public ViewNovelInfo()
        {
            InitializeComponent();

            // Subscribe to the Loaded event to set the title and size of the window
            this.Loaded += ViewNovelInfo_Loaded;
 
        }

        /// <summary>
        /// Set the title and size of the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewNovelInfo_Loaded(object sender, RoutedEventArgs e)
        {
            // Get a reference to the parent window, we can't call Window.GetWindow(this) in the constructor because the window is not yet created
            Window window = Window.GetWindow(this);

            if (window != null)
            {
                window.Title = "ViewNovelInfo";
            }


            // get parameters from the URL
            var navigationService = ((MainWindow)Application.Current.MainWindow)?.GetNavigationService();
            if (navigationService == null)
            {
                throw new Exception("Navigation service not found");            
            }
            // after the ?  
            //      after the wanted parameter
            //             before the next parameter
            string novelSlug = navigationService.CurrentSource.OriginalString.Split("?")[1].Split("novelSlug=")[1].Split("&")[0];
            string sourceSlug = navigationService.CurrentSource.OriginalString.Split("?")[1].Split("sourceSlug=")[1];

            var vm = new VMNovelInfoPage(novelSlug, sourceSlug);
            DataContext = vm;
        }

        private void OpenUrlInBrowser(string url)
        {
           Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void OpenSourceWebsite(object sender, RoutedEventArgs e)
        {
            if (DataContext is VMNovelInfoPage vm)
            {
                if (vm.Novel != null)
                {
                    OpenUrlInBrowser(vm.Novel.Url);
                    e.Handled = true;
                }
            }
        }

        private void OpenInLNCrawlerWebsite(object sender, RoutedEventArgs e)
        {
            if (DataContext is VMNovelInfoPage vm)
            {
                if (vm.Novel != null)
                {
                    OpenUrlInBrowser(vm.Novel.LNCrawlerUrl);
                    e.Handled = true;
                }
            }
        }
    }
}
