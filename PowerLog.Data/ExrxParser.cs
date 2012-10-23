using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PowerLog.Model;
using Sprache;

namespace PowerLog.Data
{
    internal static class ExrxParser
    {
        // ReSharper disable InconsistentNaming
        private static readonly Parser<string> Data = from x in Parse.AnyChar.Except(Parse.Char(',')).Many().Text() select x;
        private static readonly Parser<char> Separator = from x in Parse.Char(',') select x;
        public static Parser<Exercise> Exrx =
            from bodyPart in Data
            from _ in Separator
            from name in Data
            from __ in Separator
            from utility in Data
            from ___ in Separator
            from mechanics in Data
            from ____ in Separator
            from force in Data
            from _____ in Separator
            from url in Parse.AnyChar.Many().Text()
            select new Exercise
            {
                Name = Regex.Replace(Regex.Replace(name, @"\(|\)| 45°", string.Empty), "-", " "),
                BodyPart = bodyPart,
                Force = force,
                Mechanics = mechanics,
                Url = url,
                Utility = utility
            };

        // ReSharper restore InconsistentNaming
    }
}
