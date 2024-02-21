using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LNCrawler.Models;
using LNCrawler.API.Models;

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

    public VMHomePage()
    {
        _modelHome = new ModelHome();
        LoadPageCommand = new RelayCommand<int>(LoadPage);
        LoadNextPageCommand = new RelayCommand(LoadNextPage);
        LoadPreviousPageCommand = new RelayCommand(LoadPreviousPage);
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
    }

}
