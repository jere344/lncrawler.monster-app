using Newtonsoft.Json;
using System.Collections.Generic;

namespace LNCrawler.API.Models;
#nullable disable
public class Novel
{
    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("chapter_count")]
    public int ChapterCount { get; set; }

    [JsonProperty("clicks")]
    public int Clicks { get; set; }

    [JsonProperty("comment_count")]
    public int CommentCount { get; set; }

    [JsonProperty("cover")]
    private string _Cover { get; set; }
    public string Cover
    {
        get => "https://api.lncrawler.monster/image/" + _Cover;
    }

    [JsonProperty("current_week_clicks")]
    public int CurrentWeekClicks { get; set; }

    [JsonProperty("first")]
    public string First { get; set; }

    [JsonProperty("language")]
    public string Language { get; set; }

    [JsonProperty("last_update_date")]
    public string LastUpdateDate { get; set; }

    [JsonProperty("latest")]
    public string Latest { get; set; }

    [JsonProperty("overall_rating")]
    private double _OverallRating { get; set; }
    public string OverallRating
    {
        get => _OverallRating.ToString("0.0");
    }

    [JsonProperty("prefered_source")]
    public string PreferedSource { get; set; }

    [JsonProperty("rank")]
    public int Rank { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("tags")]
    private List<string> _Tags { get; set; }
    public string Tags
    {
        get => string.Join(", ", _Tags);
    }

    [JsonProperty("title")]
    public string Title { get; set; }
}
