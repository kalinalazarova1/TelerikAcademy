//12. Write a program that parses an URL address given in the format: [protocol]://[server]/[resource]
//and extracts from it the [protocol], [server] and [resource] elements. For example from 
//the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//[protocol] = "http"
//[server] = "www.devbg.org"
//[resource] = "/forum/index.php"

using System;
using System.Text;

class ExctractFromURL
{
    static void Main()
    {
        string inputURL = "http://www.devbg.org/forum/index.php";
        int indexProtocol = inputURL.IndexOf(':');
        Console.WriteLine("[protocol] = \"{0}\"", inputURL.Substring(0, indexProtocol));
        int indexServer = inputURL.IndexOf('/', indexProtocol + 3);
        Console.WriteLine("[server] = \"{0}\"", inputURL.Substring(indexProtocol + 3, indexServer - indexProtocol - 3));
        Console.WriteLine("[resource] = \"{0}\"", inputURL.Substring(indexServer));
    }
}
