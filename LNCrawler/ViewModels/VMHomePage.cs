using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LNCrawler.Models;
using LNCrawler.API.Models;
using System.Windows;
using System;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace LNCrawler.ViewModels;

public class VMHomePage : ObservableObject
{
    private readonly ModelHome _modelHome;
    public Novel Novel1
    {
        get => _modelHome.Pages[_modelHome.CurrentPage.ToString()][0];
    }
    public Novel Novel2
    {
        get => _modelHome.Pages[_modelHome.CurrentPage.ToString()][1];
    }
    public Novel Novel3
    {
        get => _modelHome.Pages[_modelHome.CurrentPage.ToString()][2];
    }
    public Novel Novel4
    {
        get => _modelHome.Pages[_modelHome.CurrentPage.ToString()][3];
    }
    public Novel Novel5
    {
        get => _modelHome.Pages[_modelHome.CurrentPage.ToString()][4];
    }
    public Novel Novel6
    {
        get => _modelHome.Pages[_modelHome.CurrentPage.ToString()][5];
    }

    public int NovelPerPage => _modelHome.NovelPerPage;
    public int CurrentPage
    {
        get => _modelHome.CurrentPage;
    }
    public ICommand LoadPageCommand { get; set; }
    public ICommand LoadNextPageCommand { get; set; }
    public ICommand LoadPreviousPageCommand { get; set; }

    public bool CanLoadPreviousPage
    {
        get => _modelHome.CurrentPage >= 1;
    }


    public bool CanLoadNextPage
    {
        get => _modelHome.CurrentPage < _modelHome.TotalPages;
    }

    public VMHomePage()
    {
        _modelHome = new ModelHome();
        LoadPageCommand = new RelayCommand<int>(LoadPage);
        LoadNextPageCommand = new RelayCommand(LoadNextPage);
        LoadPreviousPageCommand = new RelayCommand(LoadPreviousPage);
        SetTheme();

        // Define Thread culture depending on the selected language
        // It may looks useless, but it's not
        Language = Language;
    }

    public void LoadPage(int page)
    {
        _modelHome.ChargerPage(page);
        _Update();
    }

    public void LoadNextPage()
    {
        _modelHome.ChargerPage(CurrentPage + 1);
        _Update();
    }

    public void LoadPreviousPage()
    {
        _modelHome.ChargerPage(CurrentPage - 1);
        _Update();
    }

    public void _Update()
    {
        OnPropertyChanged(nameof(Novel1));
        OnPropertyChanged(nameof(Novel2));
        OnPropertyChanged(nameof(Novel3));
        OnPropertyChanged(nameof(Novel4));
        OnPropertyChanged(nameof(Novel5));
        OnPropertyChanged(nameof(Novel6));
        OnPropertyChanged(nameof(CurrentPage));
        OnPropertyChanged(nameof(CanLoadNextPage));
        OnPropertyChanged(nameof(CanLoadPreviousPage));
    }


    // We store the theme in the application properties
    // if never set, we default to dark theme
    private bool _IsDarktheme = Application.Current.Properties["IsDarkTheme"] == null || (bool)(Application.Current.Properties["IsDarkTheme"] ?? true);
    public bool IsDarkTheme
    {
        get => _IsDarktheme;
        set
        {
            _IsDarktheme = value;
            Application.Current.Properties["IsDarkTheme"] = value;
            SetTheme();
        }
    }

    public void SetTheme()
    {
        if (IsDarkTheme)
        {
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(".\\Resources\\DarkTheme.xaml", UriKind.Relative) });
        }
        else
        {
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri(".\\Resources\\LightTheme.xaml", UriKind.Relative) });
        }
    }

    public bool IsLightTheme
    {
        get => !IsDarkTheme;
        set
        {
            IsDarkTheme = !value;
        }
    }

    public static string Language
    {
        get => Application.Current.Properties["Language"] != null ? (string)(Application.Current.Properties["Language"] ?? Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName) : Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
        set
        {
            Application.Current.Properties["Language"] = value;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(value);
            ((App)Application.Current).SetLanguageDictionary();
        }
    }

    public List<string> Languages
    {
        get => new List<string> { "en", "fr" };
    }
}
