using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Threading;

namespace ShareBot
{
    class Program
    {
        public static Random random = new Random();
        public static int index = 0;
        public static int amount = 0;
        public static string id = "";
        static async Task Main(string[] args)
        {
            Console.Title = "TikTok Share Botter [Developed By Slayer | @slayisvibing]";
            Console.WriteLine("Enter TikTok URL:"); id = Console.ReadLine().Split('/')[5];
            Console.WriteLine("Enter Amount To Bot:"); amount = Convert.ToInt32(Console.ReadLine());

            Parallel.For(0, amount, new ParallelOptions { MaxDegreeOfParallelism = 10 }, async i =>
            {
                await bot();
            });        
            
            Console.ReadLine();
        }
        
        static async Task bot()
        {
            try
            {
                WebClient client = new WebClient(); 
                client.Headers.Add("x-common-params-v2", $"version_code=16.6.5&app_name=musical_ly&channel=App%20Store&device_id={new string(Enumerable.Repeat("0123456789", 19).Select(s => s[random.Next(s.Length)]).ToArray())}&aid=1233&os_version=13.5.1&device_platform=iphone&device_type=iPhone10,5");
                client.Headers.Add("X-Gorgon", $"{new string(Enumerable.Repeat("abcdef0123456789", 51).Select(s => s[random.Next(s.Length)]).ToArray())}");
                await client.UploadValuesTaskAsync("https://api16-core-c-useast1a.tiktokv.com/aweme/v1/aweme/stats/?ac=WIFI&op_region=SE&app_skin=white&", new NameValueCollection()
                {
                  { "action_time", $"{DateTimeOffset.Now.ToUnixTimeSeconds()}" },
                  { "item_id", id },
                  { "item_type", "1" },
                  { "share_delta", "1" },
                  { "stats_channel", "copy" }
                });
                index++;
                Console.WriteLine($"[{index}/{amount}] Share Sent...");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"oh no there's an error: {ex.Message}");
            }
        }
    }



}
