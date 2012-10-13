using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace PowerLog.Model
{
    public class SharedExercise
    {
        [Key]
        [StringLength(10, MinimumLength = 10)]
        public string ID { get; set; }

        public string Title { get; set; }
        public virtual ICollection<LoggedExercise> LoggedExercises { get; set; }
    }

    public class LoggedExercise
    {
        [Key]
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int ExerciseID { get; set; }
        public virtual Exercise Exercise { get; set; }

        [Required]
        [Range(1, 1000)]
        public double Weight { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Reps { get; set; }

        public string Comment { get; set; }

        public bool FailedToLift { get; set; }
        public bool ToFailure { get; set; }
        public bool MaxEffort { get; set; }
        public bool LongNegative { get; set; }
        public int ForcedReps { get; set; }

        public double OneRepMax
        {
            get
            {
                return Math.Round(
                    this.Weight / (
                    this.Reps < 1 ? 1 :
                    this.Reps == 1 ? 1 :
                    this.Reps == 2 ? 0.95 :
                    this.Reps == 3 ? 0.90 :
                    this.Reps == 4 ? 0.88 :
                    this.Reps == 5 ? 0.86 :
                    this.Reps == 6 ? 0.83 :
                    this.Reps == 7 ? 0.80 :
                    this.Reps == 8 ? 0.78 :
                    this.Reps == 9 ? 0.76 :
                    this.Reps == 10 ? 0.75 :
                    this.Reps == 11 ? 0.72 :
                    this.Reps == 12 ? 0.70 :
                    .65), 1, MidpointRounding.AwayFromZero);
            }
        }

        public override string ToString()
        {
            return string.Format("[{2:dd-MM-yyyy} {3} {1}x{0:0.##}kg]", Weight, Reps, Date, Exercise.Name);
        }
    }
}
