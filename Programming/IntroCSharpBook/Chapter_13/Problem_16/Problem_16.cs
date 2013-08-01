using System;
using System.Text;

class Problem_16
{
    static void Main()
    {
        string text = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
	    text = text.Replace("<a href=\"","[URL=");
        text = text.Replace("\">", "]");
        text = text.Replace("</a>","[/URL]");
        Console.WriteLine(text);
    }
}
