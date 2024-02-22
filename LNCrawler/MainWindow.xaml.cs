using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Threading;

namespace LNCrawler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Navigate to the first page
            MainNavigationFrame.NavigationService.Navigate(new Uri("Views/Home.xaml", UriKind.Relative));
        }

        // Add a method to access the NavigationService of the frame
        public NavigationService GetNavigationService()
        {
            return MainNavigationFrame.NavigationService;
        }
    }
}
