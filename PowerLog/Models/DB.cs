using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PowerLog.Models
{
    public class DB : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseLog> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}