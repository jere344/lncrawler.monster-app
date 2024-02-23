using System.Collections.Generic;
using Newtonsoft.Json;

namespace LNCrawler.API.Models;

// stop nullable warnings :
#nullable disable

public class Chapter
{
    [JsonProperty("body")]
    private string _Body { get; set; }
    public string Body
    {
        get
        {
            // remove html tags. There probably is a way to load the html in a webview and get the text from it, but this is easier for the exercise
            return _Body.Replace("<br>", "\n").Replace("<p>", "").Replace("</p>", "\n").Replace("<br />", "\n").Replace("<br/>", "\n").Replace("<b>", "").Replace("</b>", "").Replace("<i>", "").Replace("</i>", "").Replace("<div>", "").Replace("</div>", "").Replace("<span>", "").Replace("</span>", "").Replace("<em>", "").Replace("</em>", "").Replace("<strong>", "").Replace("</strong>", "").Replace("<u>", "").Replace("</u>", "").Replace("<h1>", "").Replace("</h1>", "").Replace("<h2>", "").Replace("</h2>", "").Replace("<h3>", "").Replace("</h3>", "").Replace("<h4>", "").Replace("</h4>", "").Replace("<h5>", "").Replace("</h5>", "").Replace("<h6>", "").Replace("</h6>", "").Replace("<hr>", "");
        }
    }

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
