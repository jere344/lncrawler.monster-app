using LNCrawler.API;
using LNCrawler.API.Models;
using LNCrawler.API.Models.Generic;
using System.Collections.Generic;

namespace LNCrawler.Models;

public class ModelNovelInfo
{
    public NovelFromSource? Novel { get; set; }
    private readonly APIHelper APIHelper = new();

    public ModelNovelInfo(string novelSlug, string sourceSlug)
    {
        Novel = this.APIHelper.GetNovelAsync(novelSlug, sourceSlug).Result;
    }
}
