using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            ElementBuilder div = new ElementBuilder("div");
            ElementBuilder a = new ElementBuilder("a");
            ElementBuilder li = new ElementBuilder("li");

            div.AddAtributes("class", "softuni");
            div.AddAtributes("onclick", "highlight();");

            a.AddAtributes("href", "http://softuni.bg");
            a.AddContent("Software University");
            div.AddContent(a.ToString());

            Console.WriteLine(div);

            Console.WriteLine(li * 2);

            Console.WriteLine(HTMLDispatcher.CreateImage("http://softuni.bg/img/logo.png", "softuni-logo", "logo"));
            Console.WriteLine(HTMLDispatcher.CreateURL("http://softuni.bg", "Software University", "The best university in Bulgaria"));
            Console.WriteLine(HTMLDispatcher.CreateInput("text", "address", "Sofia bul. Vasil Kynchew 26"));
        }
    }
}
