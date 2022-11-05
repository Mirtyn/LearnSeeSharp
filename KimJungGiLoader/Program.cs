﻿using AngleSharp;
using System;
using System.Linq;

namespace KimJungGiLoader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        private void Parse(string url)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://en.wikipedia.org/wiki/List_of_The_Big_Bang_Theory_episodes";
            var context = BrowsingContext.New(config);
            var document = context.OpenAsync(address).Result;
            var cellSelector = "tr.vevent td:nth-child(3)";
            var cells = document.QuerySelectorAll(cellSelector);
            var titles = cells.Select(m => m.TextContent);
        }
    }
}
