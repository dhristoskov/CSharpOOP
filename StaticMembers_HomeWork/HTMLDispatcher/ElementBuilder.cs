using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    public class ElementBuilder
    {
        public string Name{ get; set; }
        public string Content { get; set; }
        private Dictionary<string, string> atributes;

        public ElementBuilder(string name)
        {
            this.Name = name;
            this.Content = String.Empty;
            this.atributes = new Dictionary<string, string>();
        }

        public void AddAtributes(string name, string content)
        {
            this.atributes.Add(name, content);
        }

        public void AddContent(string content)
        {
            this.Content = content;
        }

        public static string operator *(ElementBuilder element, int counter)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < counter; i++)
            {
                sb.Append(element);
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("<{0}", this.Name));

            foreach (var atribute in this.atributes)
            {
                sb.Append(string.Format(" {0}=\"{1}\"", atribute.Key, atribute.Value));
            }
            sb.Append(">");
            sb.Append(this.Content);
            sb.Append(string.Format("</{0}>", this.Name));

            return sb.ToString();
        }
    }
}
