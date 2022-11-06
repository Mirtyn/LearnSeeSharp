using AngleSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace KimJungGiLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ParseYear(2013);
            //ParseYear(2014);
            //ParseYear(2015);
            //ParseYear(2016);
            //ParseYear(2017);
            //ParseYear(2018);
            //ParseYear(2019);
            //ParseYear(2020);
            //ParseYear(2021);
            //ParseYear(2022);

            // https://www.kimjunggi.net/wp-content/uploads/2013/01/0398_resize.jpg

            //Download("https://www.kimjunggi.net/wp-content/uploads/2013/01/0398_resize.jpg", @"D:\Steven\Atelier\Code\LearnSeeSharp\KimJungGiLoader\bin\Debug\netcoreapp3.1\0398_resize.jpg");

            CleanYear(2013);
            CleanYear(2014);
            CleanYear(2015);
            CleanYear(2016);
            CleanYear(2017);
            CleanYear(2018);
            CleanYear(2019);
            CleanYear(2020);
            CleanYear(2021);
            //CleanYear(2022);

            //CleanYearMonth(2022, 9);
        }

        private static void CleanYear(int year)
        {
            for (var month = 1; month < 13; month++)
            {
                CleanYearMonth(year, month);
            }
        }

        private static void CleanYearMonth(int year, int month)
        {
            CleanDirectory(year.ToString() + Path.DirectorySeparatorChar + month.ToString("00"));
        }

        private static void CleanDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                return;
            }

            var files = Directory.EnumerateFiles(directory).ToList();

            if(files.Count == 0)
            {
                Directory.Delete(directory);
            }

            foreach(var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);

                var equals = Directory.EnumerateFiles(directory, name + "*").ToList();

                if(equals.Count > 1)
                {
                    foreach(var e in equals)
                    {
                        if(e.Equals(file, StringComparison.InvariantCultureIgnoreCase))
                        {
                            continue;
                        }

                        File.Delete(e);
                    }
                }
            }
        }

        private static void Download(string url, string path)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("authority", "www.kimjunggi.net");
                client.Headers.Add("upgrade-insecure-requests", "1");
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.35");

                client.DownloadFile(new Uri(url), path);
            }

            //using var httpClient = new HttpClient();

            //var imageBytes = httpClient.GetByteArrayAsync(url).Result;

            //File.WriteAllBytesAsync(path, imageBytes);

            //using (System.Net.WebClient webClient = new System.Net.WebClient())
            //{
            //    webClient.Headers.Add("referer", "https://www.kimjunggi.net/wp-content/uploads/2013/01/");

            //    using (Stream stream = webClient.OpenRead(url))
            //    {

            //    }
            //}

            //try
            //{
            //    var webRequest = System.Net.WebRequest.Create(url);

            //    if (webRequest != null)
            //    {
            //        webRequest.Method = "GET";
            //        webRequest.Headers.Add("authority", "www.kimjunggi.net");
            //        //webRequest.Headers.Add("sec-ch-ua", "www.kimjunggi.net");
            //        //webRequest.Headers.Add("sec-ch-ua-mobile", "?0");
            //        //webRequest.Headers.Add("sec-ch-ua-platform", "Windows");
            //        //webRequest.Headers.Add("sec-fetch-dest", "document");
            //        webRequest.Headers.Add("upgrade-insecure-requests", "1");
            //        webRequest.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.35");

            //        using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
            //        {
            //            using (System.IO.StreamReader sr = new System.IO.StreamReader(s))
            //            {
            //                //var jsonResponse = sr.ReadToEnd();

            //                //Console.WriteLine(String.Format("Response: {0}", jsonResponse));

            //                using (var fileStream = File.Create(path))
            //                {
            //                    //sr.InputStream.Seek(0, SeekOrigin.Begin);
            //                    sr.BaseStream.CopyTo(fileStream);
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
        }

        static void ParseYear(int year)
        {
            for(var month = 1; month < 13; month++)
            {
                var directory = year.ToString() + Path.DirectorySeparatorChar + month.ToString("00");
                var url = @"https://www.kimjunggi.net/wp-content/uploads/" + year + "/" + month.ToString("00");

                var config = Configuration.Default.WithDefaultLoader();
                var address = url;
                var context = BrowsingContext.New(config);
                var document = context.OpenAsync(address).Result;
                var cellSelector = "a";
                var cells = document.QuerySelectorAll(cellSelector).ToList();

                Directory.CreateDirectory(directory);

                foreach (var cell in cells)
                {
                    var href = cell.GetAttribute("href");

                    if (href == null)
                    {
                        continue;
                    }

                    if (href.EndsWith(".gif", StringComparison.InvariantCultureIgnoreCase) || href.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) || href.EndsWith(".jepg", StringComparison.InvariantCultureIgnoreCase) || href.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var name = href;
                        href = url + "/" + href;

                        // download image
                        Download(href, directory + Path.DirectorySeparatorChar + name);
                    }
                }
            }
        }
    }
}
