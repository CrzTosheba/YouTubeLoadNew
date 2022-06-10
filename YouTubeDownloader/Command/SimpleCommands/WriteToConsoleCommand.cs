namespace YouTubeDownloader.Command.SimpleCommands;

using System;
using System.Text.Json;
using System.Threading.Tasks;

public class WriteToConsoleCommand : ICommand
{
    private readonly CommandContext _context;

    public WriteToConsoleCommand(CommandContext context)
    {
        _context = context;
    }

    public Task Execute()
    {
        Console.WriteLine($"VideoCodec: {_context.Info.VideoCodec}");

     
        Console.WriteLine($"Автор: {_context.Description.Author}");
        Console.WriteLine($"Название: {_context.Description.Title}");
        
        return Task.CompletedTask;
    }
}