using System;
using System.Linq;

namespace DescriptiveStatistics
{
    /// <summary>
    /// Represents a statistics analyzer.
    /// </summary>
    public static class Statistics
    {
        public static dynamic DescriptiveStatistics(int[] source)
        {
            int maximum = Maximum(source);

            var summary = new
            {
                Maximum = maximum
            };

            return summary;
        }
        public static int Maximum(int[] source) => source.Max();
    }
}