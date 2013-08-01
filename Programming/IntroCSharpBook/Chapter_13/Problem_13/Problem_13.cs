using System;
using System.Text;

class Problem_13
{
    static void Main()
    {
        string inputURL = "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd";
        int indexProtocol = inputURL.IndexOf(':');
        Console.WriteLine("protocol: {0}", inputURL.Substring(0,indexProtocol));
        int indexServer = inputURL.IndexOf('/', indexProtocol + 3);
        Console.WriteLine("server: {0}", inputURL.Substring(indexProtocol + 3, indexServer - indexProtocol - 3));
        Console.WriteLine("resource: {0}", inputURL.Substring(indexServer));
    }
}
