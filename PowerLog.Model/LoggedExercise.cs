using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PowerLog.Model
{
    public class TrainingSession
    {
        public TrainingSession()
        {
            LoggedExercises = new List<LoggedExercise>();
        }

        [Key]
        public int ID { get; set; }
        [StringLength(10, MinimumLength = 10)]
        public string Key { get; set; }

        public int UserId { get; set; }
        public UserProfile UserProfile { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public virtual ICollection<LoggedExercise> LoggedExercises { get; set; }

        public string Title { get; set; }
        public string Comment { get; set; }
        public bool IsPublic { get; set; }
        public bool IsShared { get; set; }
    }

    public class LoggedExercise
    {
        private int _forcedReps;

        [Key]
        public int ID { get; set; }

        public int UserId { get; set; }
        public UserProfile UserProfile { get; set; }

        public int TrainingSessionId { get; set; }
        public TrainingSession TrainingSession { get; set; }

        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public double Weight
        {
            get { return new Weight { Kilograms = WeightValue }.WeightIn(CurrentUnit); }
            set { WeightValue = CurrentUnit == WeightUnit.Kilogram ? value : new Weight { Pounds = value }.Kilograms; }
        }

        [Required]
        [Range(1, 1000)]
        public double WeightValue { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Reps { get; set; }

        public double Load
        {
            get { return Weight * Reps; }
        }

        public double RepWeight
        {
            get { return Load * (Weight * Reps); }
        }

        public string Comment { get; set; }

        public bool FailedToLift { get; set; }
        public bool ToFailure { get; set; }
        public bool MaxEffort { get; set; }
        public bool LongNegative { get; set; }
        public int ForcedReps
        {
            get { return _forcedReps; }
            set
            {
                if (value > this.Reps)
                    throw new Exception("Number of forced reps cannot exceed the number of actual reps");
                _forcedReps = value;
            }
        }

        public double OneRepMax
        {
            get
            {
                if (FailedToLift)
                    return 0;
                var r = this.Reps - this.ForcedReps;
                return Math.Round(
                    Weight / (
                    r < 1 ? 1 :
                    r == 1 ? 1 :
                    r == 2 ? 0.95 :
                    r == 3 ? 0.90 :
                    r == 4 ? 0.88 :
                    r == 5 ? 0.86 :
                    r == 6 ? 0.83 :
                    r == 7 ? 0.80 :
                    r == 8 ? 0.78 :
                    r == 9 ? 0.76 :
                    r == 10 ? 0.75 :
                    r == 11 ? 0.72 :
                    r == 12 ? 0.70 :
                    .65), 1, MidpointRounding.AwayFromZero);
            }
        }

        public override string ToString()
        {
            return string.Format("[{2:dd-MM-yyyy} {3} {1}x{0:0.##}{4}]",
                Weight,
                Reps,
                Date,
                Exercise.Name,
                WeightUnitName);
        }

        public string ToPwl()
        {
            var flags = string.Empty;
            flags += MaxEffort ? "-max" : "";
            flags += FailedToLift ? "-ftl" : "";
            flags += ToFailure ? "-tf" : "";
            flags += LongNegative ? "-ln" : "";
            flags += ForcedReps > 0 ? "-fr(" + ForcedReps + ")" : "";
            flags += string.IsNullOrWhiteSpace(Comment) ? "" : "-note(" + Comment + ")";
            return string.Format("{0}{1}{2}",
                Reps > 1 ? Reps + "x" : "",
                Weight.ToString(CultureInfo.InvariantCulture),
                flags);
        }

        public WeightUnit CurrentUnit
        {
            get { return UserProfile == null ? WeightUnit.Kilogram : UserProfile.WeightUnits; }
        }

        public string WeightUnitName
        {
            get { return Model.Weight.LabelIn(CurrentUnit); }
        }
    }
}
