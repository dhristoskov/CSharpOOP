using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunesShop
{
    public class NewTunesEngine : MyTunesEngine
    {
        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "member_to_band":
                    this.ExecuteInsertMemberToBandCommand(commandWords);
                    break;
                case "song_to_album":
                    this.ExecuteInsertSongToAlbumCommand(commandWords);
                    break;
                default:
                    break;
            }
            base.ExecuteInsertCommand(commandWords);
        }


        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = new Band(commandWords[3]);
                    this.InsertBand(band);
                    break;
                default:
                    break;
            }
            base.ExecuteInsertPerformerCommand(commandWords);
        }

        protected override void ExecuteRateCommand(string[] commandWords)
        {
            var song = this.media.FirstOrDefault(s => s.Title == commandWords[2]) as ISong;
            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database");
                return;
            }
            song.PlaceRating(int.Parse(commandWords[3]));
            this.Printer.PrintLine("The rating has been placed successfully.");
        }


        private void InsertBand(IBand band)
        {
            this.performers.Add(band);
            this.Printer.PrintLine("Band {0} added successfully", band.Name);
        }

        protected void ExecuteInsertMemberToBandCommand(string[] commandWords)
        {
            var band = this.performers.FirstOrDefault(p => p.Name == commandWords[2]) as IBand;
            if (band == null)
            {
                this.Printer.PrintLine("The band does not exist in the database.");
                return;
            }
            InsertMemberToBand(band,commandWords[3]);
        }

        protected void ExecuteInsertSongToAlbumCommand(string[] commandWords)
        {
            var album = this.media.FirstOrDefault(p => p.Title == commandWords[2]) as IAlbum;
            if (album == null)
            {
                this.Printer.PrintLine("The album does not exist in the database.");
                return;
            }

            var song = this.media.FirstOrDefault(p => p.Title == commandWords[3]) as ISong;
            if (song == null)
            {
                this.Printer.PrintLine("The song does not exist in the database.");
                return;
            }


            InsertSongToAlbum(album, song);
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }
                    var album = new Album(
                        commandWords[3],
                        decimal.Parse(commandWords[4]),
                        performer,
                        commandWords[6],
                        int.Parse(commandWords[7]));
                    this.InsertAlbum(album, performer);
                    break;
                default:
                    break;
            }
            base.ExecuteInsertMediaCommand(commandWords);
        }

        private void InsertAlbum(IAlbum album, IPerformer performer)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, performer.Name);
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", quantity, album.Title);
                    break;
                default:
                    break;
            }
            base.ExecuteSellCommand(commandWords);
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", quantity, album.Title);
                    break;
                default:
                    break;
            }
            base.ExecuteSupplyCommand(commandWords);
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "performer":
                    this.ExecuteReportPerformerCommand(commandWords);
                    break;
                case "media":
                    this.ExecuteReportMediaCommand(commandWords);
                    break;
                default:
                    break;
            }
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = this.performers.FirstOrDefault(p => p is Band && p.Name == commandWords[3]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetBandReport(band));
                    break;
                default:
                    break;
            }
            base.ExecuteReportPerformerCommand(commandWords);
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }
                    this.Printer.Print(this.GetAlbumReport(album));
                    break;
                default:
                    break;
            }
            base.ExecuteReportMediaCommand(commandWords);
        }

        protected override string GetSongReport(ISong song)
        {
            var songSalesInfo = this.mediaSupplies[song];
            StringBuilder songInfo = new StringBuilder();
            songInfo.AppendFormat("{0} ({1}) by {2}", song.Title, song.Year, song.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", song.Genre, song.Price).AppendLine()
                .AppendFormat("Rating: {0}", GetAverageRating(song.Ratings)).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold);
            return songInfo.ToString();
        }

        private string GetBandReport(IBand band)
        {
            StringBuilder bandInfo = new StringBuilder();
            bandInfo.Append(band.Name + ": ");
            if (band.Members.Any())
            {
                bandInfo.Append(string.Join(", ", band.Members)); 
            }
            bandInfo.AppendLine();
            if (band.Songs.Any())
            {
                var songs = band.Songs
                  .Select(s => s.Title)
                  .OrderBy(s => s);
                bandInfo.Append(string.Join("; ", songs));

            }
            else
            {
                bandInfo.Append("no songs");
            }

            return bandInfo.ToString();
        }
        //<name> (<member_1, member_2...>): <song_1_title>; <song_2_title> / no songs
        private string GetAlbumReport(IAlbum album)
        {
            var albumSalesInfo = this.mediaSupplies[album];
            StringBuilder albumInfo = new StringBuilder();
            albumInfo.AppendFormat("{0} ({1}) by {2}", album.Title, album.Year, album.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", album.Genre, album.Price).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", albumSalesInfo.Supplies, albumSalesInfo.QuantitySold)
                .AppendLine();
            if (album.Songs.Count == 0)
            {
                albumInfo.AppendLine("No songs");
            }
            else
            {
                albumInfo.AppendFormat("Songs:{1}{0}", GetAlbumSongs(album), Environment.NewLine);
            }

            return albumInfo.ToString();
        }

        private string GetAlbumSongs(IAlbum album)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var song in album.Songs)
            {
                sb.AppendLine(string.Format("{0} ({1})", song.Title, song.Duration));
            }
            return sb.ToString();
        }

        private int GetAverageRating(IList<int> ratings)
        {
            if (ratings.Count == 0)
            {
                return 0;
            }
            return (int)Math.Ceiling(ratings.Sum()/(float)ratings.Count);
        }

        private void InsertSongToAlbum(IAlbum album, ISong song)
        {
            album.Songs.Add(song);
            this.Printer.PrintLine("The song {0} has been added to the album {1}.", song.Title, album.Title);

        }

        private void InsertMemberToBand(IBand band, string memberName)
        {
            band.Members.Add(memberName);
            this.Printer.PrintLine("The member {0} has been added to the band {1}.",memberName,band.Name);
        }
    }
}
