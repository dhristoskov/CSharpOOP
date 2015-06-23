using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class MusicShop : IMusicShop
    {
        private string _name;
        private IList<IArticle> _articles;

        public MusicShop(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this._name; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format("The music manager {0} shouldn't be empty", Name));
                }
                this._name = value;
            } 
        }


        public IList<IArticle> Articles
        {
            get
            {
                if (_articles == null)
                {
                    _articles = new List<IArticle>();
                }
                return _articles;
            }
        }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("===== {0} =====", this.Name));
            if (Articles.Count <= 0)
            {
                sb.AppendLine("The shop is empty. Come back soon.");
                return sb.ToString();
            }

            var microphones = Articles.OfType<Microphone>().OrderBy(s => s.Make).ThenBy(s => s.Model).ToList();
            if (microphones.Count > 0)
            {
                sb.AppendLine("----- Microphones -----");
                foreach (var microphone in microphones)
                {
                    sb.Append(microphone);
                }
            }
            var drums = Articles.OfType<Drums>().OrderBy(s => s.Make).ThenBy(s => s.Model).ToList();
            if (drums.Count > 0)
            {
                sb.AppendLine("----- Drums -----");
                foreach (var drum in drums)
                {
                    sb.Append(drum);
                }
            }
            var eguitars = Articles.OfType<ElectricGuitar>().OrderBy(s => s.Make).ThenBy(s => s.Model).ToList();
            if (eguitars.Count > 0)
            {
                sb.AppendLine("----- Electric guitars -----");
                foreach (var eguitar in eguitars)
                {
                    sb.Append(eguitar);
                }
            }
            var aguitars = Articles.OfType<AcousticGuitar>().OrderBy(s => s.Make).ThenBy(s => s.Model).ToList();
            if (aguitars.Count > 0)
            {
                sb.AppendLine("----- Acoustic guitars -----");
                foreach (var aguitar in aguitars)
                {
                    sb.Append(aguitar);
                }
            }
            var bguitars = Articles.OfType<BassGuitar>().OrderBy(s => s.Make).ThenBy(s => s.Model).ToList();
            if (bguitars.Count > 0)
            {
                sb.AppendLine("----- Bass guitars -----");
                foreach (var bguitar in bguitars)
                {
                    sb.Append(bguitar);
                }
            }
            return sb.ToString();
        }
    }
}
