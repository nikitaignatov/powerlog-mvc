﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;

namespace PowerLog.Parser
{
   public class PowerLogParser
   {
       public static Log ParseInput(string input)
       {
           var cStream = new ANTLRStringStream(input);
           var lexer = new PowerLogGrammarLexer(cStream);
           var tStream = new CommonTokenStream(lexer);
           var parser = new PowerLogGrammarParser(tStream);
           var res = parser.exercise();
           var log = res.result;
           log.OriginalInput = input;
           return log.Return();
       }
    }
}