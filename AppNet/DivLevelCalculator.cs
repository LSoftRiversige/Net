using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;

namespace AppNet
{
    public class DivLevelCalculator
    {
        const string divStartPattern = "<div";
        const string divFinishPattern = "</div";

        public async static void Run()
        {
            string html = await new HttpClient().GetStringAsync("http://itcloud.academy"); 

            int maxLevel = 0;

            FindNextDiv(html, 0, 0, ref maxLevel);

            Console.WriteLine($"MaxLevel={maxLevel}");
        }

        private static int FindNextDiv(string html, int startIndex, int startLevel, ref int maxLevel)
        {
            int level = startLevel;

            do
            {
                int divStartCurrentIndex = html.IndexOf(divStartPattern, startIndex);
                int divFinishCurrentIndex = html.IndexOf(divFinishPattern, startIndex);

                if (divStartCurrentIndex < divFinishCurrentIndex && divStartCurrentIndex != -1)
                {
                    level++;
                    
                    if (level > maxLevel)
                    {
                        maxLevel = level;
                    }
                    startIndex = FindNextDiv(html, divStartCurrentIndex + divStartPattern.Length, level, ref maxLevel);
                }
                else
                {
                    return divFinishCurrentIndex + divFinishPattern.Length;
                }
            } while (true);
        }
    }   
}