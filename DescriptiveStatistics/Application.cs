using System;
using System.IO;
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
            Console.WriteLine($"Maximum: {source.Maximum}");

        }
    }
}