using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MyTunesShop
{
    public class Album : Media, IAlbum
    {
        private IPerformer performer;
        private string genre;
        private int year;
        private IList<ISong> songs;
        
        public Album(string title, decimal price, IPerformer performername, string genre, int year) : base(title,price)
        {
            this.Performer = performername;
            this.Genre = genre;
            this.Year = year;
        }

        public IPerformer Performer
        {
            get { return this.performer; }
            set {
                if (value == null)
                {
                    throw new ArgumentNullException(string.Format("The album {0} performer cannot be null", this.Performer));
                }
                this.performer = value;
            } 
        }

        public string Genre
        {
            get { return this.genre; } 
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format("The album {0} cannot be null", this.Genre));
                }
                this.genre = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            private set
            {
                if (value < MinYear || value > MaxYear)
                {
                    throw new ArgumentException(string.Format("The year of a song must be between {0} and {1}.", MinYear, MaxYear));
                }

                this.year = value;
            }
        }

        public IList<ISong> Songs
        {
            get
            {
                if (songs == null)
                {
                    this.songs = new List<ISong>();
                }
                return this.songs;
            } 
        }

        public void AddSong(ISong song)
        {
            this.Songs.Add(song);
        }
    }
}
