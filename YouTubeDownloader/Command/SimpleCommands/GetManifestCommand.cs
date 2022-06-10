namespace YouTubeDownloader.Command.SimpleCommands;

using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;

public class GetManifestCommand : ICommand
{
    private readonly CommandContext _commandContext;

    public GetManifestCommand(CommandContext commandContext)
    {
        _commandContext = commandContext;
    }

    public async Task Execute()
    {
        var client = _commandContext.Client;
        var video = _commandContext.VideoId;


        var videoDescription = await client.Videos.GetAsync(video);

        var description = new Description
        {
            Author = videoDescription.Author,
            Duration = videoDescription.Duration,
            Title = videoDescription.Title
        };

        _commandContext.Description = description; 
        var manifest = await client.Videos.Streams.GetManifestAsync(video);
        _commandContext.Manifest = manifest; 
        var videoInfo = manifest.GetMuxedStreams().GetWithHighestVideoQuality();
        _commandContext.Info = videoInfo;
    }
    
    
}