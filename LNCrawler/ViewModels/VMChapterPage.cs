using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LNCrawler.Models;
using LNCrawler.API.Models;

namespace LNCrawler.ViewModels;

public class VMChapterPage : ObservableObject
{
    private readonly ModelChapter _ModelChapter;
    public ChapterWrapper? CurrentChapter
    {
        get => _ModelChapter.CurrentChapter;
    }
    public string ChapterTitle
    {
        get => _ModelChapter.CurrentChapter?.Content?.Title ?? "";
    }
    public string ChapterContent
    {
        get => _ModelChapter.CurrentChapter?.Content?.Body ?? "";
    }
    public string Noveltitle
    {
        get => _ModelChapter.CurrentChapter?.Source?.Novel?.Title ?? "";
    }
    public bool CanLoadPreviousChapter
    {
        get => _ModelChapter.CanLoadPreviousChapter;
    }
    public bool CanLoadNextChapter
    {
        get => _ModelChapter.CanLoadNextChapter;
    }
    public int CurrentChapterNumber
    {
        get => _ModelChapter.CurrentChapterNumber;
    }
    public int TextBoxChapter { get; set; }
    public ICommand LoadPreviousChapterCommand { get; set; }
    public ICommand LoadNextChapterCommand { get; set; }
    public ICommand GoToChapterCommand { get; set; }

    public VMChapterPage(string novelSlug, string sourceSlug)
    {
        _ModelChapter = new ModelChapter(novelSlug, sourceSlug);
        LoadPreviousChapterCommand = new RelayCommand(() => LoadPreviousChapter());
        LoadNextChapterCommand = new RelayCommand(() => LoadNextChapter());
        GoToChapterCommand = new RelayCommand(() => GoToChapter());
        Update();
    }

    public void Update() {
        OnPropertyChanged(nameof(CurrentChapter));
        OnPropertyChanged(nameof(CanLoadPreviousChapter));
        OnPropertyChanged(nameof(CanLoadNextChapter));
        OnPropertyChanged(nameof(ChapterTitle));
        OnPropertyChanged(nameof(ChapterContent));
        OnPropertyChanged(nameof(Noveltitle));
        OnPropertyChanged(nameof(CurrentChapterNumber));
        TextBoxChapter = CurrentChapterNumber;
        OnPropertyChanged(nameof(TextBoxChapter));
    }

    public void GoToChapter()
    {
        string chapterNumber = TextBoxChapter.ToString();
        if (int.TryParse(chapterNumber, out int result))
        {
            _ModelChapter.LoadChapter(result);
            Update();
        }
    }

    public void LoadNextChapter()
    {
        _ModelChapter.LoadChapter(_ModelChapter.CurrentChapterNumber + 1);
        Update();
    }

    public void LoadPreviousChapter()
    {
        _ModelChapter.LoadChapter(_ModelChapter.CurrentChapterNumber - 1);
        Update();
    }
}
