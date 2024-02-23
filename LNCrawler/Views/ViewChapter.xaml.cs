using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using LNCrawler.ViewModels;

namespace LNCrawler.Views
{

    public partial class ViewChapter : Page
    {
        public ViewChapter()
        {
            InitializeComponent();

            // Subscribe to the Loaded event
            this.Loaded += ViewChapter_Loaded;

        }

        private void ViewChapter_Loaded(object sender, RoutedEventArgs e)
        {
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

            var vm = new VMChapterPage(novelSlug, sourceSlug);
            DataContext = vm;

            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.Title = "LNCrawler - " + vm.CurrentChapter?.Source?.Novel?.Title + " - " + vm.CurrentChapter?.Content?.Title;
            }
        }
    }
}
