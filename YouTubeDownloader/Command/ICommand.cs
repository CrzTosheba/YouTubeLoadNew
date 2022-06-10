namespace YouTubeDownloader.Command;

using System.Threading.Tasks;

interface ICommand
{
    Task Execute();
}