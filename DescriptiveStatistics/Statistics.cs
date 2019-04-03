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
            int median = Median(source);
            int minimum = Minimum(source);
            int range = Range(source);

            var summary = new
            {
                Maximum = maximum,
                Mean = mean,
                Median = median,
                Minimum = minimum,
                Range = range

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
        public static int Median(int[] source)
        {
            var list = new List<int>(source);
            list.Sort();
            return list[list.Capacity / 2 - 1];
        }

        /// <summary>
        /// Returns the range from an array of integers.
        /// </summary>
        /// <param name="source">The integers to analyze.</param>
        /// <returns></returns>
        public static int Range(int[] source) => Maximum(source) - Minimum(source);
    }

}