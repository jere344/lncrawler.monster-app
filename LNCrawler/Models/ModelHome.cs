using LNCrawler.API;
using LNCrawler.API.Models;
using System.Collections.Generic;

namespace LNCrawler.Models;

public class ModelHome
{
    public Dictionary<string, List<Novel>> Pages { get; set; }
    public int NovelPerPage = 6;
    public int CurrentPage = 2;
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
