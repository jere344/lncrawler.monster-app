using System.Collections.Generic;
using Newtonsoft.Json;

namespace LNCrawler.API.Models;

// stop nullable warnings :
#nullable disable

public class Chapter
{
    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("images")]
    public Dictionary<string, string> Images { get; set; }

    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("volume")]
    public int Volume { get; set; }

    [JsonProperty("volume_title")]
    public string VolumeTitle { get; set; }
}
