using Newtonsoft.Json;
using System.Collections.Generic;

namespace LNCrawler.API.Models.Generic;
#nullable disable
public class NovelFromSource
{
    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("chapter_count")]
    public int ChapterCount { get; set; }

    [JsonProperty("cover")]
    public string Cover { get; set; }

    [JsonProperty("first")]
    public string First { get; set; }

    [JsonProperty("language")]
    public string Language { get; set; }

    [JsonProperty("last_update_date")]
    public string LastUpdateDate { get; set; }

    [JsonProperty("latest")]
    public string Latest { get; set; }

    [JsonProperty("novel")]
    public Novel Novel { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("summary")]
    public string Summary { get; set; }

    [JsonProperty("tags")]
    public List<string> Tags { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}
