using Newtonsoft.Json;
using System.Collections.Generic;

namespace LNCrawler.API.Models;
#nullable disable
public class NovelFromSource
{
    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("chapter_count")]
    public int ChapterCount { get; set; }

    [JsonProperty("cover")]
    private string _Cover { get; set; }
    public string Cover
    {
        get => "https://api.lncrawler.monster/image/" + _Cover;
    }

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
    private string _Summary { get; set; }
    public string Summary
    {
        get => _Summary.Replace("<br>", "\n").Replace("</p>", "\n").Replace("<p>", "").Replace("<br />", "\n");
    }

    [JsonProperty("tags")]
    private List<string> _Tags { get; set; }
    public string Tags
    {
        get => string.Join(", ", _Tags);
    }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    public string LNCrawlerUrl => $"https://lncrawler.monster/novel/{Novel.Slug}/{Slug}";
}
