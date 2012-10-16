using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace PowerLog.Parser
{
    public class PowerLogParser
    {
        public static IEnumerable<Log> ParseInput(string input)
        {

            //  return  KillStonesWithBirds.Kill("bacon 2x2 5x5x5;deadlift 5x10;this is sparta 2 2x");

            return KillStonesWithBirds.Kill(input);
        }


        public static CommonTree Convert(string input)
        {
            var lexer = new PowerLogASTLexer(new ANTLRStringStream(input));
            var parser = new PowerLogASTParser(new CommonTokenStream(lexer));
            return parser.evaluate().Tree;
        }
    }
}
