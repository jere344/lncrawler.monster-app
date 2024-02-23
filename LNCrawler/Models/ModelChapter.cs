using LNCrawler.API;
using LNCrawler.API.Models;
using System.Collections.Generic;
using System;
using System.Windows;

namespace LNCrawler.Models;


public class ModelChapter
{
    public string NovelSlug { get; set; }
    public string SourceSlug { get; set; }
    private readonly APIHelper APIHelper = new();
    public Dictionary<int, ChapterWrapper> Chapters { get; set; } = new();
    private int _CurrentChapterNumber { get; set; }
    public int CurrentChapterNumber
    {
        get => _CurrentChapterNumber;
        set
        {
            _CurrentChapterNumber = value;
            Application.Current.Properties[NovelSlug + "-CurrentChapterNumber"] = value;
        }

    }
    public ChapterWrapper? CurrentChapter
    {
        get => Chapters.ContainsKey(CurrentChapterNumber) ? Chapters[CurrentChapterNumber] : null;
    }
    public bool CanLoadPreviousChapter
    {
        get => CurrentChapter?.IsPrev ?? false;
    }
    public bool CanLoadNextChapter
    {
        get => CurrentChapter?.IsNext ?? false;
    }

    public ModelChapter(string novelSlug, string sourceSlug)
    {
        this.NovelSlug = novelSlug;
        this.SourceSlug = sourceSlug;

        CurrentChapterNumber = Application.Current.Properties[novelSlug + "-CurrentChapterNumber"] != null ? Convert.ToInt32(Application.Current.Properties[novelSlug + "-CurrentChapterNumber"]) : 1;

        LoadChapter(CurrentChapterNumber);
    }

    public void LoadChapter(int number = 1)
    {
        if (Chapters.ContainsKey(number))
        {
            CurrentChapterNumber = number;
        }
        else
        {
            var chapter = this.APIHelper.GetChapter(NovelSlug, SourceSlug, number);
            if (chapter != null)
            {
                Chapters[number] = chapter;
                CurrentChapterNumber = number;
            }
        }
    }

}