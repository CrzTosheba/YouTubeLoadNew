namespace YouTubeDownloader.Command.SimpleCommands;

using System;
using YoutubeExplode.Common;

public record Description
{
    public Author Author { get; set; }
    public TimeSpan? Duration { get; set; }
    public string Title { get; internal set; }
}