namespace YouTubeDownloader.Command;

using SimpleCommands;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

public class CommandContext
{
    public YoutubeClient Client { get; set; }
    public VideoId VideoId { get; set; }
    public IVideoStreamInfo Info { get; set; }
    public StreamManifest Manifest { get; set; }
    public string Path { get; set; }
    public Description Description { get; set; }
}