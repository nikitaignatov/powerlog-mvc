using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Security;
using PowerLog.Model;
using PowerLog.Parser;
using Sprache;
using WebMatrix.WebData;

namespace PowerLog.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PowerLog.Data.UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PowerLog.Data.UsersContext context)
        {
            InitializeMembership();
            Run(context);
        }
        private static void InitializeMembership()
        {
            const string username = "MakeitKebaBacon";
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfiles", "UserId", "UserName", autoCreateTables: true);
            }

            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }

            if (!WebSecurity.UserExists(username))
            {
                WebSecurity.CreateUserAndAccount(username, "ajHjEw5m6zGd3ZzW0Nte");
            }

            if (!Roles.GetRolesForUser(username).Contains("Administrator"))
            {
                Roles.AddUsersToRoles(new[] { username }, new[] { "Administrator" });
            }
        }
        private void Run(UsersContext db)
        {
            foreach (var line in File.ReadLines("\\REPO\\random.txt")
                //  .Where(x => x.Contains("Dumbbell") || x.Contains("Barbell") || x.Contains("Cable"))
                .OrderBy(x => x.Split(',')[1]))
            {
                try
                {
                    db.Exercises.Add(ExrxParser.Exrx.Parse(line));
                    db.SaveChanges();
                }
                catch (Exception)
                {
                }
            }

            var workout = File.ReadLines("\\REPO\\workout.txt");
            var data = new Dictionary<DateTime, List<string>>();
            foreach (var line in workout.Where(x => !x.Contains("#") && !string.IsNullOrWhiteSpace(x)))
            {
                var x = line.Split(',');
                var date = DateTime.Parse(x[0]);
                if (data.ContainsKey(date))
                    data[date].Add(x[1]);
                else
                {
                    data[date] = new List<string> { x[1] };
                }
            }
            SaveExpressionsInDatabase(db, data);

        }

        private void SaveExpressionsInDatabase(UsersContext db, Dictionary<DateTime, List<string>> data)
        {
            const int id = 1;
            foreach (var date in data)
            {
                var session = new TrainingSession { Date = date.Key, UserId = id };
                db.TrainingSessions.Add(session);
                foreach (var expression in date.Value)
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
                                    Reps = set.Reps,
                                    Weight = set.Weight,
                                    Date = date.Key,
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
                        log.Date = date.Key;
                        log.Exercise = db.Exercises.FirstOrDefault(x => x.Name.Equals(log.Exercise.Name, StringComparison.OrdinalIgnoreCase));
                        session.LoggedExercises.Add(log);
                        log.TrainingSession = session;
                        db.LoggedExercises.Add(log);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
