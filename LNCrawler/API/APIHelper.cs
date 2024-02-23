using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LNCrawler.API.Models;
using System.Collections.Generic;
using System.Threading;
using System;

namespace LNCrawler.API;

public class APIHelper
{
    private NovelsWrapper? _GetNovels(int page, int number = 6, List<string>? tags = null)
    {
        try
        {
            using var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(5) };
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
            return JsonConvert.DeserializeObject<NovelsWrapper>(content);
        }
        catch (HttpRequestException)
        {
            return null;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
    }

    public NovelsWrapper? GetNovels(int page, int number = 6, List<string>? tags = null, int retries = 1)
    {
        for (int i = 0; i < retries; i++)
        {
            var novelsWrapper = _GetNovels(page, number, tags);
            if (novelsWrapper != null)
            {
                return novelsWrapper;
            }
            Thread.Sleep(500);
        }
        throw new HttpRequestException("Failed to get novels");
    }

    public NovelFromSource? GetNovel(string novelSlug, string sourceSlug)
    {
        try
        {
            //  timeout after 3 seconds
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(3);
            var response = client.GetAsync($"https://api.lncrawler.monster/novel?novel={novelSlug}&source={sourceSlug}").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<NovelFromSource>(content);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}
