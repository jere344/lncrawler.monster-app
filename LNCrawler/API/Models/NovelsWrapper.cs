using Newtonsoft.Json;
using System.Collections.Generic;

namespace LNCrawler.API.Models;

#nullable disable

public class NovelsWrapper
{
    [JsonProperty("content")]
    public Dictionary<string, Novel> Content { get; set; }

    [JsonProperty("metadata")]
    public Metadata Metadata { get; set; }

}
