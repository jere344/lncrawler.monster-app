using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LNCrawler.Models;
using LNCrawler.API.Models.Generic;

namespace LNCrawler.ViewModels;

public class VMNovelInfoPage : ObservableObject
{
    private readonly ModelNovelInfo _modelNovelInfo;
    public NovelFromSource? Novel
    {
        get => _modelNovelInfo.Novel;
    }

    public VMNovelInfoPage(string novelSlug, string sourceSlug)
    {
        _modelNovelInfo = new ModelNovelInfo(novelSlug, sourceSlug);
    }
}
