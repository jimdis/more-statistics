using System;
using System.IO;
using Newtonsoft.Json;

namespace DescriptiveStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                string json = File.ReadAllText(args[0]);
                int[] statistics = JsonConvert.DeserializeObject<int[]>(json);
                Console.WriteLine(statistics[0] + statistics[1]); // 106
            }
        }
    }
}