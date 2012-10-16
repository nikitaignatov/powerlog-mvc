namespace PowerLog.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Antlr.Runtime;
    using Antlr.Runtime.Tree;

    public partial class KillStonesWithBirds
    {
        private static readonly Dictionary<string, IEnumerable<Log>> Cache = new Dictionary<string, IEnumerable<Log>>();

        public static IEnumerable<Log> Kill(string input)
        {
            var dot = new DotTreeGenerator();
            var result = new List<Log>();
            Print(input);

            input = input.ToLowerInvariant().Trim();
            if (Cache.ContainsKey(input))
                result = Cache[input].ToList();
            else
            {
                var parser = ParseWithASTParser(input);
                var tree = parser.evaluate().Tree;
                PrintString(dot.ToDot(tree));
                Parse(tree, result);
                Cache.Add(input, result);
            }

            TexasRanger.ValidateLogs(result);
            result.ForEach(x => Print(x.ToString()));

            foreach (var log in result)
            {
                log.OriginalInput = input;
                yield return log.Return();
            }
        }

        static partial void PrintString(string message);

        static partial void Print(object template, params object[] args);

        private static PowerLogASTParser ParseWithASTParser(string input)
        {
            var lexer = new PowerLogASTLexer(new ANTLRStringStream(input));
            return new PowerLogASTParser(new CommonTokenStream(lexer));
        }

        private static void Parse(CommonTree tree, ICollection<Log> list)
        {
            if (tree.Type == PowerLogASTLexer.EXERCISE)
            {
                if (tree.ChildCount > 0)
                {
                    var log = new Log();
                    foreach (var child in tree.Children)
                    {
                        ParseLog((CommonTree)child, log);
                    }

                    TexasRanger.ValidateLog(log);
                    list.Add(log);
                }
            }

            ParseChildren(tree, list, Parse);
        }

        private static void ParseChildren<T>(CommonTree tree, T item, Action<CommonTree, T> fun) where T : class
        {
            Print(tree.Text);

            if (tree.ChildCount <= 0)
            {
                return;
            }

            foreach (var child in tree.Children)
            {
                fun((CommonTree)child, item);
            }
        }

        private static void ParseLog(CommonTree tree, Log log)
        {
            if (tree.Type == PowerLogASTLexer.EXERCISE_NAME)
            {
                if (tree.ChildCount < 1)
                {
                    throw new Exception("Exercise is missing a name.");
                }
                else if (tree.Children.Any(x => x.Type == PowerLogASTLexer.WORD) == false)
                {
                    throw new Exception("Exercise is missing a name.");
                }

                log.Name = string.Join(" ", tree.Children.Select(x => x.Text));
                PrintString(log.Name);
            }
            else if (tree.Type == PowerLogASTLexer.FLAGGED_SET)
            {
                var set = new Set();
                var childSet = (from s in tree.Children
                                where s.Type == PowerLogASTLexer.SET
                                    || s.Type == PowerLogASTLexer.MULTI_SET
                                select (CommonTree)s)
                                .FirstOrDefault();

                var childFlags = (from s in tree.Children
                                  where s.Type == PowerLogASTLexer.FLAGS
                                  select (CommonTree)s)
                                .FirstOrDefault();

                if (childSet == null)
                {
                    throw new Exception(string.Format("No sets defined for [{0}]", log.Name));
                }

                ParseSet(childSet, set);
                ParseSetFlags(childFlags, set);
                TexasRanger.ValidateSet(set);
                log.Sets.Add(set);
            }

            ParseChildren(tree, log, ParseLog);
        }

        private static void ParseSetFlags(CommonTree tree, Set set)
        {
            if (null == tree)
            {
                return;
            }

            if (tree.Type == PowerLogASTLexer.MESSAGE)
            {
                if (tree.ChildCount > 0)
                    set.Comment = string.Join(" ", tree.Children.Select(x => x.Text));
            }
            else if (tree.Parent.Type == PowerLogASTLexer.REP)
            {
                ParseRep(tree, "forced reps", x => set.ForcedReps = x);
            }
            else if (tree.Parent.Type == PowerLogASTLexer.FLAGS && tree.ChildCount == 0)
            {
                switch (tree.Text)
                {
                    case "max":
                        set.MaxEffort = true;
                        break;
                    case "tf":
                        set.ToFailure = true;
                        break;
                    case "ftl":
                        set.FailedToLift = true;
                        break;
                    case "ln":
                        set.LongNegative = true;
                        break;
                }
            }

            ParseChildren(tree, set, ParseSetFlags);
        }

        private static void ParseSet(CommonTree tree, Set set)
        {
            if (null == tree)
            {
                return;
            }

            switch (tree.Parent.Type)
            {
                case PowerLogASTLexer.WEIGHT:
                    set.Weight = Convert.ToDouble(tree.Text, CultureInfo.InvariantCulture);
                    break;
                case PowerLogASTLexer.REP:
                    ParseRep(tree, "reps", x => set.Reps = x);
                    break;
                case PowerLogASTLexer.SETS:
                    ParseRep(tree, "sets", x => set.Sets = x);
                    break;
            }

            ParseChildren(tree, set, ParseSet);
        }

        private static void ParseRep(CommonTree tree, string propertyName, Action<int> func)
        {
            try
            {
                var isSingle = tree.Type == PowerLogASTLexer.SINGLE;
                func(isSingle ? 1 : Convert.ToInt32(tree.Text));
            }
            catch (Exception e)
            {
                var message = string.Format(
                    "Invalid number of {0}. [line:{1}][column:{2}]",
                    propertyName,
                    tree.Line,
                    tree.CharPositionInLine);
                throw new Exception(message);
            }
        }
    }

    public partial class KillStonesWithBirds
    {
        [Conditional("DEBUG")]
        static partial void PrintString(string message)
        {
            Trace.WriteLine(message);
        }

        [Conditional("DEBUG")]
        static partial void Print(object template, params object[] args)
        {
            Trace.WriteLineIf(!args.Any(), template);
            Trace.WriteLineIf(args.Any(), string.Format(template.ToString(), args));
        }
    }
}
