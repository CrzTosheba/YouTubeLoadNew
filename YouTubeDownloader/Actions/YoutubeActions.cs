namespace YouTubeDownloader.Actions;

using System.Collections.Generic;
using System.Threading.Tasks;
using Command;
using Command.CompositeCommands;
using Command.SimpleCommands;
using YoutubeExplode.Videos;

public class YoutubeActions
{
    private List<ICommand> _commands = new();

    private readonly Dictionary<string, ICommand> _commandsDict;
    private readonly CommandContext _context;

    public YoutubeActions()
    {
        _context = new CommandContext();
        _commandsDict = new()
        {
            ["Info"] = new InfoCommand(_context),
            ["Download"] = new DownloadCommand(_context),
        };
        
        
        _commands.Add(new MakeClientCommand(_context));
        _commands.Add(new GetManifestCommand(_context));
        _commands.Add(new GetVideoCommand(_context));
        _commands.Add(new WriteToConsoleCommand(_context));
    }
    
    public async Task Download(string url, string pathToDownload)
    {
        _context.Path = pathToDownload;
        _context.VideoId = VideoId.Parse(url);
        
        foreach (var command in _commands)
        {
            await command.Execute();
        }
    }
    
    public async Task Download_2(string url, string pathToDownload)
    {
        _context.Path = pathToDownload;
        _context.VideoId = VideoId.Parse(url);
        await _commandsDict["Download"].Execute();
    }

    public async Task ShowInfo(string url, string pathToDownload)
    {
        _context.Path = pathToDownload;
        _context.VideoId = VideoId.Parse(url);
        await _commandsDict["Info"].Execute();
    }
}