using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprache;

namespace PowerLog.Parser
{
    public class PowerParser
    {
        // deadlift 5x10
        // deadlift 5x10 6x8 8x9
        public static Parser<string> numberParser = Parse.Digit.AtLeastOnce().Text();

        public static Parser<string> threeNumberParser =
            from f in Parse.Numeric
            from s in Parse.Numeric
            from t in Parse.Numeric
            select f.ToString() + s.ToString() + t.ToString();
    }
}
