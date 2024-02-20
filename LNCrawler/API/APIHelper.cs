using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LNCrawler.API.Models;
using System.Collections.Generic;
using LNCrawler.API.Models.Generic;
using System.Threading;
using System;

namespace LNCrawler.API;

public class APIHelper
{
    public NovelsWrapper? GetNovels(int page, int number = 6, List<string>? tags = null)
    {
        try
        {
            using var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(3) };
            HttpResponseMessage response;
            if (tags == null)
            {
                response = client.GetAsync($"https://api.lncrawler.monster/novels?page={page}&number={number}").Result;
            }
            else
            {
                response = client.GetAsync($"https://api.lncrawler.monster/novels?page={page}&number={number}&tags={string.Join(",", tags)}").Result;
            }
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<NovelsWrapper>(content)?.FixCovers();
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<NovelFromSource?> GetNovelAsync(string novelSlug, string sourceSlug)
    {
        try
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"https://api.lncrawler.monster/novel?novel={novelSlug}&source={sourceSlug}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NovelFromSource>(content);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public async Task<Chapter?> GetChapterAsync(string novelSlug, string sourceSlug, int chapter)
    {
        try
        {
            using var client = new HttpClient();
            var response = await client.GetAsync($"https://api.lncrawler.monster/chapter?novel={novelSlug}&source={sourceSlug}&chapter={chapter}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Chapter>(content);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}
