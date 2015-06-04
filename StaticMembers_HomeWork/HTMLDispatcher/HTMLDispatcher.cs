using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    public static class HTMLDispatcher
    {
        public static string CreateImage(string source, string alt, string title)
        {
            ElementBuilder image = new ElementBuilder("image");
            image.AddAtributes("src", source);
            image.AddAtributes("alt", alt);
            image.AddAtributes("title", title);

            return image.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder a = new ElementBuilder("a");
            a.AddAtributes("href", url);
            a.AddAtributes("title", title);
            a.AddContent(text);

            return a.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            ElementBuilder input = new ElementBuilder("input");
            input.AddAtributes("type", type);
            input.AddAtributes("name", name);
            input.AddAtributes("value", value);

            return input.ToString();
        }
    }
}
