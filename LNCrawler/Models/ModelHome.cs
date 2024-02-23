using LNCrawler.API;
using LNCrawler.API.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace LNCrawler.Models;

public class ModelHome
{
    public Dictionary<string, List<Novel>> Pages { get; set; }
    public int NovelPerPage = 6;
    private int _CurrentPage = Application.Current.Properties["CurrentPage"] != null ? Convert.ToInt32(Application.Current.Properties["CurrentPage"]) : 0;
    public int CurrentPage
    {
        get => _CurrentPage;
        set
        {
            _CurrentPage = value;
            Application.Current.Properties["CurrentPage"] = value;
        }
    }
    private readonly APIHelper APIHelper = new();
    public int TotalPages = 0;

    public ModelHome()
    {
        Pages = new Dictionary<string, List<Novel>>();
        ChargerPage(CurrentPage);
    }

    public void ChargerPage(int page)
    {
        // If page is cached, use it
        if (Pages.ContainsKey(page.ToString()))
        {
            CurrentPage = page;
            return;
        }
        // else, get it from the API
        else
        {
            NovelsWrapper? novelsWrapper = this.APIHelper.GetNovels(page, NovelPerPage, null);
            if (novelsWrapper != null)
            {
                List<Novel> novels = new();
                foreach (var novel in novelsWrapper.Content.Values)
                {
                    novels.Add(novel);
                }
                Pages.Add(page.ToString(), novels);
                CurrentPage = page;
                TotalPages = novelsWrapper.Metadata.TotalPages;
            }
        }
    }
}
