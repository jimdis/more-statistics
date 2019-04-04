using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DescriptiveStatistics
{
    /// <summary>
    /// Represents a console application.
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// The file to read from.
        /// </summary>
        public static string SourceFile { get; set; }

        /// <summary>
        /// Runs an application.
        /// </summary>
        public static void Run()
        {
            try
            {
                string json = File.ReadAllText(SourceFile);
                int[] statistics = JsonConvert.DeserializeObject<int[]>(json);
                var descriptiveStatistics = Statistics.DescriptiveStatistics(statistics);
                ViewResult(descriptiveStatistics);
                // foreach (int val in descriptiveStatistics.Mode)
                // {
                //     Console.WriteLine(val);
                // }
                // Console.WriteLine(descriptiveStatistics);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ERROR: {ex.Message}");
            }

        }
        private static void ViewResult(dynamic source)
        {
            var dict = new Dictionary<string, string>
                {
                    ["Maximum"] = $"{source.Maximum}",
                    ["Minimum"] = $"{source.Minimum}",
                    ["Medelvärde"] = $"{source.Mean:f1}",
                    ["Median"] = $"{source.Median}",
                    ["Typvärde"] = $"{string.Join(", ", source.Mode)}",
                    ["Variationsbredd"] = $"{source.Range}",
                    ["Standardavvikelse"] = $"{source.StandardDeviation:f1}"

                };
            int padding = dict
                .Select(x => x.Key)
                .OrderByDescending(x => x.Length)
                .ToArray() [0].Length;

            // Console.WriteLine("\n----------------------");
            Console.WriteLine("\nDeskriptiv statistik");
            Console.WriteLine("-------------------------");
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key.PadRight(padding)}: {kvp.Value}");
            }
            Console.WriteLine("-------------------------\n");
        }
    }
}