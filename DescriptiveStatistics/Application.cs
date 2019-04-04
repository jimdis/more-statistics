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
                int[] numbers = JsonConvert.DeserializeObject<int[]>(json);
                var statistics = Statistics.DescriptiveStatistics(numbers);
                ViewResult(statistics);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"ERROR: {ex}");
            }

        }

        /// <summary>
        /// Prints out a table of descriptive statistics to the console.
        /// </summary>
        /// <param name="statistics">The dynamic object containing the descriptive statistics</param>
        private static void ViewResult(dynamic statistics)
        {
            var dict = new Dictionary<string, string>
                {
                    ["Maximum"] = $"{statistics.Maximum}",
                    ["Minimum"] = $"{statistics.Minimum}",
                    ["Medelvärde"] = $"{statistics.Mean:f1}",
                    ["Median"] = $"{statistics.Median}",
                    ["Typvärde"] = $"{string.Join(", ", statistics.Mode)}",
                    ["Variationsbredd"] = $"{statistics.Range}",
                    ["Standardavvikelse"] = $"{statistics.StandardDeviation:f1}"

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