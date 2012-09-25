using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PowerLog.Models
{
    public class Exercise
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class ExerciseLog
    {
        [Key]
        public int ID { get; set; }
        public int ExerciseID { get; set; }
        public virtual Exercise Exercise { get; set; }

    [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public float Weight { get; set; }
        public int Reps { get; set; }
    }
}