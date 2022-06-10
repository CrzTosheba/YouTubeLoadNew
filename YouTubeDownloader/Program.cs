using System;

namespace YouTubeDownloader;

using System.IO;
using System.Threading.Tasks;
using Actions;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Введите ссылку: ");
        var url = Console.ReadLine();
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "video1.mp4");
        var showInfoAct = new YoutubeActions();
        var downloadAct = new YoutubeActions();
        
        var showInfoTask = showInfoAct.ShowInfo(url, path);
        var downloadTask =  downloadAct.Download_2(url, path);

        await Task.WhenAll(showInfoTask, downloadTask);
        Console.WriteLine($"Видео загружено:");
        Console.WriteLine(path);
    }
}