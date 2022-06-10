namespace YouTubeDownloader.Command.SimpleCommands;

using System.Threading.Tasks;
using YoutubeExplode.Videos.Streams;

public class GetVideoCommand : ICommand
{
    private readonly CommandContext _context;

    public GetVideoCommand(CommandContext context)
    {
        _context = context;
    }

    public async Task Execute()
    {
        var manifest = _context.Manifest;
        
        var streamInfo = manifest.GetMuxedStreams().GetWithHighestVideoQuality();
        var client = _context.Client;
        var path = _context.Path;
        await client.Videos.Streams.DownloadAsync(streamInfo, path, default);
    }
}