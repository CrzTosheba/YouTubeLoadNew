using System;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Converter;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using YouTubeLoad;

namespace YouTubeLoad
{
    public static class Program
    {
        public static async Task<int> Main()
        {
            {
                var youtube = new YoutubeClient();

                /// путь к видео ///
                Console.Write("Введите ссылку: ");
                var videoId = VideoId.Parse(Console.ReadLine() ?? "");
                var video = await youtube.Videos.GetAsync(videoId);
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();// запрос потока, звук и видео, поэтому юзаю Muxed
                /// мы у ранее созданного YoutubeClient() запрашиваем информацию о видео, URL которого будет тот, что мы указали.///
                Console.WriteLine($"Название: {video.Title}");
                Console.WriteLine($"Продолжительность: {video.Duration}");
                Console.WriteLine($"Автор: {video.Author}");
            }
            Console.ReadLine();
            return 0;
        }
    }

}
