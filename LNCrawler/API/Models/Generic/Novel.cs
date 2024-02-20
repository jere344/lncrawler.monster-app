using Newtonsoft.Json;
using System.Collections.Generic;

namespace LNCrawler.API.Models.Generic;
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
    public string Cover { get; set; }

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
    public double OverallRating { get; set; }

    [JsonProperty("prefered_source")]
    public string PreferedSource { get; set; }

    [JsonProperty("rank")]
    public int Rank { get; set; }

    [JsonProperty("slug")]
    public string Slug { get; set; }

    [JsonProperty("tags")]
    public List<string> Tags { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

}
