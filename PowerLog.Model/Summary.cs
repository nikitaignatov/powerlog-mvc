using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerLog.Model
{
    public class Summary
    {
        public double AverageReps { get; set; }
        public double TotalVolume { get; set; }
        public int TotalReps { get; set; }
    }

    public static class SummaryExtensions
    {
        public static Summary Summarize(this IEnumerable<LoggedExercise> exercises)
        {
            var list = exercises.ToList();
            return new Summary
            {
                AverageReps = list.Average(x => x.Reps),
                TotalReps = list.Sum(x => x.Reps),
                TotalVolume = list.Sum(x => x.Load)
            };
        }
    }
}
