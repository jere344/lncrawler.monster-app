using Newtonsoft.Json;
using System.Collections.Generic;
using LNCrawler.API.Models.Generic;

namespace LNCrawler.API.Models;
#nullable disable
public class ChapterWrapper
{
    [JsonProperty("content")]
    public Chapter Content { get; set; }

    [JsonProperty("is_next")]
    public bool IsNext { get; set; }

    [JsonProperty("is_prev")]
    public bool IsPrev { get; set; }

    [JsonProperty("source")]
    public NovelFromSource Source { get; set; }
}
