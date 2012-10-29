using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text.RegularExpressions;
using PowerLog.Data.Migrations;
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
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<LoggedExercise>().Ignore(e => e.Weight);
            modelBuilder.Entity<LoggedExercise>().Ignore(e => e.WeightUnitName);
            modelBuilder.Entity<UserProfile>().Ignore(e => e.WeightUnits);
            base.OnModelCreating(modelBuilder);
        }
    }
}