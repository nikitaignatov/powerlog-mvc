using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLog.Parser
{
    public static class ModelExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> newItems)
        {
            foreach (T item in newItems)
            {
                collection.Add(item);
            }
        }
        public static void AddRange<T>(this ICollection<T> collection, int numberOfItems, T newItems)
        {
            const int max = 100;
            if (numberOfItems > max)
            {
                const string template = "You tried to define {0} set, {1} is the maximum possible";
                var message = string.Format(template, numberOfItems, max);
                throw new Exception(message);
            }
            for (int i = 0; i < numberOfItems; i++)
            {
                collection.Add(newItems);
            }
        }
    }

    public class Log
    {
        public Log()
        {
            Sets = new List<Set>();
        }

        public string OriginalInput { get; set; }
        public string Name { get; set; }
        public ICollection<Set> Sets { get; set; }

        public override string ToString()
        {
            var sep = "\n# ***";
            var sb = new StringBuilder(sep);
            sb.AppendFormat("\n# Logged: {0}", DateTime.Now);
            sb.AppendFormat("\n# Exercixe: {0}", Name);
            var i = 0;
            foreach (var set in Sets)
            {
                sb.AppendFormat("\n# Set {0}: {1}", ++i, set);
            }

            sb.AppendFormat("\n# Input: {0}", OriginalInput);
            sb.Append(sep);
            return sb.ToString();
        }

        public Log Return()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
                throw new Exception("Log should have a name of the exercise");
            if (!this.Sets.Any())
                throw new Exception("Log should at least one or more sets");
            return this;
        }
    }

    public class Set
    {
        public Set()
        {
            Sets = 1;
        }

        public int Sets { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
        public bool FailedToLift { get; set; }
        public bool ToFailure { get; set; }
        public bool MaxEffort { get; set; }
        public bool LongNegative { get; set; }
        public int ForcedReps { get; set; }
        public string Comment { get; set; }
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

        public bool IsMultiSet
        {
            get { return Sets > 1; }
        }

        public IEnumerable<Flag> Flags { get; set; }

        public void AddFlag(string flag)
        {
            if (flag == "max")
            {
                MaxEffort = true;
            }
            else if (flag == "ftl")
            {
                FailedToLift = true;
            }
        }

        public override string ToString()
        {
            var note = string.IsNullOrEmpty(Comment) ? string.Empty : string.Format(" [NOTE: {0}]", Comment);
            note += MaxEffort || FailedToLift || ToFailure || LongNegative ?
                string.Format(" [FLAGS: {0}]", MaxEffort ? "max" : ToFailure ? "to failure" : FailedToLift ? "failde to lift" : "") : string.Empty;

            note += ForcedReps < 1 ? string.Empty : string.Format(" [FORCED REPS: {0}]", ForcedReps);
            return string.Format("[{1}x{0:0.##}kg] [1RM:{2:#.0}]{3}", Weight, Reps, OneRepMax, note);
        }

        public Set Return()
        {
            if (this.Reps < 1)
                throw new Exception("Set should have at least 1 rep");
            if (this.Weight < 0)
                throw new Exception("Set should have positive weight value");
            return this;
        }
    }

    public enum Flag
    {
        Max,
        FailedToLift,
        ToFailure,
        LongNegatives
    }

    public class ActionFlag
    {
        public string Name { get; set; }
    }

    public class ToFailure : ActionFlag
    {
        public int Reps { get; set; }
    }

    public class Note : ActionFlag
    {
        public string Value { get; set; }
    }

}
