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
        public static IEnumerable<LoggedExercise> ParseLog(UsersContext db, DateTime date, string expression)
        {
            var result = PowerLogParser.ParseInput(expression).ToList();
            var list = new List<LoggedExercise>();
            foreach (var log in result)
            {
                foreach (var set in log.Sets)
                {
                    for (int i = 0; i < set.Sets; i++)
                    {
                        list.Add(new LoggedExercise
                        {
                            Reps = set.Reps,
                            Weight = set.Weight,
                            Date = date,
                            FailedToLift = set.FailedToLift,
                            ForcedReps = set.ForcedReps,
                            MaxEffort = set.MaxEffort,
                            ToFailure = set.ToFailure,
                            Comment = set.Comment,
                            Exercise = new Exercise { Name = log.Name }
                        });
                    }
                }
            }

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