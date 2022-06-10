namespace YouTubeDownloader.Command.SimpleCommands;

using System.Threading.Tasks;
using YoutubeExplode;

public class MakeClientCommand : ICommand
{
    private readonly CommandContext context;

    public MakeClientCommand(CommandContext context)
    {
        this.context = context;
    }

    public Task Execute()
    {
        context.Client = new YoutubeClient();
        return Task.CompletedTask;
    }
}