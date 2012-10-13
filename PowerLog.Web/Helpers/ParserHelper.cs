using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PowerLog.Data;
using PowerLog.Model;
using PowerLog.Parser;

namespace PowerLog.Web
{
    public static class ParserHelper
    {
        public static IEnumerable<LoggedExercise> ParseLog(DB db, DateTime date, string expression)
        {
            var result = PowerLogParser.ParseInput(expression);
            var list = result.Sets.Select(x => new LoggedExercise
            {
                Reps = x.Reps,
                Weight = x.Weight,
                Date = date,
                FailedToLift = x.FailedToLift,
                ForcedReps = x.ForcedReps,
                MaxEffort = x.MaxEffort,
                ToFailure = x.ToFailure,
                Comment = x.Comment,
                Exercise = new Exercise { Name = result.Name }
            });

            foreach (var log in list)
            {
                log.Date = date;
                var name = log.Exercise.Name;
                log.Exercise = db.Exercises.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (null == log.Exercise)
                {
                    var message = string.Format("Could not find exercise with name [<strong>{0}<strong>]", HttpUtility.HtmlEncode(name));
                    throw new Exception(message);
                }
                yield return log;
            }
        }
    }
}