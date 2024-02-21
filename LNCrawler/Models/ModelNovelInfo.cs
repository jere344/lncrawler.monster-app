using LNCrawler.API;
using LNCrawler.API.Models;
using System.Collections.Generic;

namespace LNCrawler.Models;

public class ModelNovelInfo
{
    public NovelFromSource? Novel { get; set; }
    private readonly APIHelper APIHelper = new();

    public ModelNovelInfo(string novelSlug, string sourceSlug)
    {
        Novel = this.APIHelper.GetNovel(novelSlug, sourceSlug);
    }
}
