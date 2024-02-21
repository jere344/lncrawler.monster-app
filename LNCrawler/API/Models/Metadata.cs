using Newtonsoft.Json;
using System.Collections;

namespace LNCrawler.API.Models;

public class Metadata
{
    [JsonProperty("current_page")]
    public int CurrentPage { get; set; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }
}
