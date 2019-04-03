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
                Console.WriteLine(statistics[0] + statistics[1]); // 106
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}