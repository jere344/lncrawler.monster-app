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
    public string APIUrl { get; set; } = "https://api.lncrawler.monster";
    private NovelsWrapper? _GetNovels(int page, int number = 6, List<string>? tags = null)
    {
        try
        {
            using var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(5) };
            HttpResponseMessage response;
            if (tags == null)
            {
                response = client.GetAsync($"{APIUrl}/novels?page={page}&number={number}").Result;
            }
            else
            {
                response = client.GetAsync($"{APIUrl}/novels?page={page}&number={number}&tags={string.Join(",", tags)}").Result;
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
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(3);
            var response = client.GetAsync($"{APIUrl}/novel?novel={novelSlug}&source={sourceSlug}").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<NovelFromSource>(content);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }

    public ChapterWrapper? GetChapter(string novelSlug, string sourceSlug, int chapter)
    {
        try
        {
            using var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(3);
            var response = client.GetAsync($"{APIUrl}/chapter/?novel={novelSlug}&source={sourceSlug}&chapter={chapter}").Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ChapterWrapper>(content);
        }
        catch (HttpRequestException)
        {
            return null;
        }
    }
}
