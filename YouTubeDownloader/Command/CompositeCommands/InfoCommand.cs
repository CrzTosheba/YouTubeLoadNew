namespace YouTubeDownloader.Command.CompositeCommands;

using System.Threading.Tasks;
using SimpleCommands;

public class InfoCommand : ICommand
{
    private readonly CommandContext _context;

    public InfoCommand(CommandContext context)
    {
        _context = context;
    }

    public async Task Execute()
    {
        await new MakeClientCommand(_context).Execute();
        await new GetManifestCommand(_context).Execute();
        await new WriteToConsoleCommand(_context).Execute();
    }
}