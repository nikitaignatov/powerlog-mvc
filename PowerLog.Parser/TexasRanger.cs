using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerLog.Parser
{
    public class TexasRanger
    {
        public static void ValidateLog(Log log)
        {
            if (!log.Sets.Any())
                throw new Exception(string.Format("No sets defined for [{0}]", log.Name));
        }
        public static void ValidateLogs(IEnumerable<Log> logs)
        {
            if (!logs.Any())
                throw new Exception("You should start of with the name of the exercise.");
        }

        public static void ValidateSet(Set set)
        {
            if (set.Weight < 0.0)
                throw new Exception("Weight cannot be negaive.");
            if (set.Reps < 1)
                throw new Exception("Number of reps cannot be less than 1.");
            if (set.ForcedReps < 0)
                throw new Exception("Number of forced reps cannot be negaive.");
        }
    }
}
