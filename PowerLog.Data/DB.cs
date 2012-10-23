using System.Text.RegularExpressions;
using PowerLog.Model;
using PowerLog.Parser;
using Sprache;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;

namespace PowerLog.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<LoggedExercise> LoggedExercises { get; set; }
        public DbSet<SharedExercise> SharedExercises { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new Initializer());
            base.OnModelCreating(modelBuilder);
        }
    }


    public class Initializer : DropCreateDatabaseAlways<UsersContext>
    {

        protected override void Seed(UsersContext db)
        {
            InitializeMembership();

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

            var workout = File.ReadLines(Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), "workout.txt"));
            foreach (var line in workout.Where(x => !x.Contains("#") && !string.IsNullOrWhiteSpace(x)))
            {
                var x = line.Split(',');
                var da = DateTime.Parse(x[0]);
                var expression = x[1];
                AddLogsForExpression(db, expression, da);
                db.SaveChanges();
            }

        }

        private static void InitializeMembership()
        {
            const string username = "MakeitKebaBacon";
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfiles", "UserId", "UserName",autoCreateTables: true);
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
                Roles.AddUsersToRoles(new[] {username}, new[] {"Administrator"});
            }
        }

        private void AddLogsForExpression(UsersContext db, string expression, DateTime date)
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
                            UserId = 1,
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
                log.Exercise = db.Exercises.FirstOrDefault(x => x.Name.Equals(log.Exercise.Name, StringComparison.OrdinalIgnoreCase));
                db.LoggedExercises.Add(log);
            }
        }
    }
}