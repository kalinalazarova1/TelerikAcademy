//4. Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg)
//and stores it the current directory. Find in Google how to download files in C#.
//Be sure to catch all exceptions and to free any used resources in the finally block.


using System;
using System.Net;

class InternetFileDownload
{
    static void Main()
    {
        string URL = "http://www.devbg.org/img/Logo-BASD.jpg";
        using(WebClient wc = new WebClient())
        {
            try
            {
                wc.DownloadFile(URL, "image.jpg");
                Console.WriteLine("File successfully downloaded.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The specified address is not valid.");
            }
            catch (WebException)
            {
                Console.WriteLine("Un error occur while downloading the file.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The download on multiple threads is not possible.");
            }
        }
    }
}
