using Newtonsoft.Json;
using System.Collections.Generic;
using LNCrawler.API.Models.Generic;

namespace LNCrawler.API.Models;

#nullable disable

public class NovelsWrapper
{
    [JsonProperty("content")]
    public Dictionary<string, Novel> Content { get; set; }

    [JsonProperty("metadata")]
    public Metadata Metadata { get; set; }

    public NovelsWrapper FixCovers()
    {
        foreach (var novel in Content.Values)
        {
            novel.Cover = "https://api.lncrawler.monster/image/" + novel.Cover;
        }
        return this;
    }
}
