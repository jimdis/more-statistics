using System;
using System.Collections.Generic;
using System.Linq;

namespace DescriptiveStatistics
{
    /// <summary>
    /// Represents a statistics analyzer.
    /// </summary>
    public static class Statistics
    {
        /// <summary>
        /// Returns an object containing descriptive statistics based on a source of integers.
        /// </summary>
        /// <param name="source">The integers to analyze.</param>
        /// <returns></returns>
        public static dynamic DescriptiveStatistics(int[] source)
        {
            int maximum = Maximum(source);
            double mean = Mean(source);
            double median = Median(source);
            int minimum = Minimum(source);
            int range = Range(source);
            double standardDeviation = StandardDeviation(source);
            int[] mode = Mode(source);

            var summary = new
            {
                Maximum = maximum,
                Mean = mean,
                Median = median,
                Minimum = minimum,
                Range = range,
                StandardDeviation = standardDeviation,
                Mode = mode

            };

            return summary;
        }

        /// <summary>
        /// Returns the maximum value from an array of integers.
        /// </summary>
        /// <param name="source">The integers to analyze.</param>
        /// <returns></returns>
        public static int Maximum(int[] source) => source.Max();

        /// <summary>
        /// Returns the mean from an array of integers.
        /// </summary>
        /// <param name="source">The integers to analyze.</param>
        /// <returns></returns>
        public static double Mean(int[] source)
        {
            var list = new List<int>(source);
            return list.Average();
        }

        /// <summary>
        /// Returns the minimum value from an array of integers.
        /// </summary>
        /// <param name="source">The integers to analyze.</param>
        /// <returns></returns>
        public static int Minimum(int[] source) => source.Min();

        /// <summary>
        /// Returns the median from an array of integers.
        /// </summary>
        /// <param name="source">The integers to analyze.</param>
        /// <returns></returns>
        public static double Median(int[] source)
        {
            var list = new List<int>(source);
            int index = list.Capacity / 2; // truncates to int in case of float
            list.Sort();

            // If uneven, pick middle value, else take average of two middle values
            double median = list.Capacity % 2 == 1 ?
                list[index] :
                Mean(new int[] { list[index - 1], list[index] });
            return median;
        }

        /// <summary>
        /// Returns the range from an array of integers.
        /// </summary>
        /// <param name="source">The integers to analyze.</param>
        /// <returns></returns>
        public static int Range(int[] source) => Maximum(source) - Minimum(source);

        /// <summary>
        /// Returns the standard deviation from an array of integers.
        /// </summary>
        /// <param name="source">The integers to analyze.</param>
        /// <returns></returns>
        public static double StandardDeviation(int[] source)
        {
            double mean = Mean(source);
            var list = new List<double>(source.Select(x => Math.Pow((x - mean), 2)));
            return Math.Sqrt(list.Average());
        }

        /// <summary>
        /// Returns the mode from an array of integers.
        /// </summary>
        /// <param name="source">The integers to analyze.</param>
        /// <returns></returns>
        public static int[] Mode(int[] source)
        {
            var dict = source
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            return dict.Where(x => x.Value == dict.Values.Max())
                .Select(x => x.Key)
                .ToArray();
        }
    }

}