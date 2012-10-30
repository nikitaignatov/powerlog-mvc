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
        public static IEnumerable<LoggedExercise> ParseLog(UsersContext db, int userId, string comment, DateTime date, List<string> data, bool perssist = true, TrainingSession session = null)
        {
            int id = userId;
            var user = db.UserProfiles.Find(id);
            if (session == null)
                session = new TrainingSession { Date = date, UserId = id, UserProfile = user,Comment = comment };
            if (perssist)
            {
                db.TrainingSessions.Add(session);
                db.SaveChanges();
            }
            foreach (var expression in data)
            {
                var list = new List<LoggedExercise>();
                foreach (var log in PowerLogParser.ParseInput(expression).ToList())
                {
                    foreach (var set in log.Sets)
                    {
                        for (int i = 0; i < set.Sets; i++)
                        {
                            list.Add(new LoggedExercise
                                         {
                                             UserId = id,
                                             UserProfile = user,
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
                    log.Exercise =
                        db.Exercises.FirstOrDefault(
                            x => x.Name.Equals(log.Exercise.Name, StringComparison.OrdinalIgnoreCase));
                    if (null == log.Exercise)
                    {
                        var message = string.Format("Could not find exercise with name [<strong>{0}<strong>]",
                                                    HttpUtility.HtmlEncode(name));
                        throw new Exception(message);
                    }
                    if (perssist)
                    {
                        session.LoggedExercises.Add(log);
                        log.TrainingSession = session;
                        db.LoggedExercises.Add(log);
                        db.SaveChanges();
                    }
                    else
                    {
                        yield return log;
                    }
                }
            }
        }
    }
}