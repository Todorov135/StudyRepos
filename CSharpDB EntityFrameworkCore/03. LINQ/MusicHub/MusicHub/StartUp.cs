namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            string output = ExportAlbumsInfo(context, 2);
            Console.WriteLine(output);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder output = new StringBuilder();

            var albumInfo = context
                .Albums
                .Where(a => a.ProducerId.Value == producerId)
                .Include(a => a.Producer)
                .Include(s =>s.Songs)
                .ThenInclude(w=>w.Writer)
                .ToArray()
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    AllSongs = a
                                 .Songs
                                 .Select( s => new 
                                 {
                                     SongName = s.Name,
                                     SongPrice = Math.Round(s.Price, 2),
                                     SongWriter = s.Writer.Name
                                 })
                                 .OrderByDescending(s => s.SongName)
                                 .ThenBy(sw => sw.SongWriter)
                                 .ToArray(),
                    a.Price
                })
                .OrderByDescending(a => a.Price)
                .ToArray();

            foreach (var a in albumInfo)
            {
                output.AppendLine($"-AlbumName: {a.Name}")
                      .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                      .AppendLine($"-ProducerName: {a.ProducerName}")
                      .AppendLine("-Songs:");
                int numberOfSong = 1;

                foreach (var s in a.AllSongs)
                {
                    output.AppendLine($"---#{numberOfSong++}")
                          .AppendLine($"---SongName: {s.SongName}")
                          .AppendLine($"---Price: {s.SongPrice}")
                          .AppendLine($"---Writer: {s.SongWriter}");                          
                }
                output.AppendLine($"-AlbumPrice: {a.Price:F2}");
            }
            return output.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
