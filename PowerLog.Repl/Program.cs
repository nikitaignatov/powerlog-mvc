using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerLog.Parser;

namespace PowerLog.Repl
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = @"
          __      _.._
       .-'__`-._.'.--.'.__.,
      /--'  '-._.'    '-._./
     /__.--._.--._.'``-.__/
     '._.-'-._.-._.-''-..'

              _,,,_
            .'     `'.
           /     ____ \
          |    .'_  _\/
          /    ) a  a|         .----.
         /    (    > |        /|     '--.
        (      ) ._  /        ||    ]|   `-.
        )    _/-.__.'`\       ||    ]|    ::|
       (  .-'`-.   \__ )      ||    ]|    ::|
        `/      `-./  `.      ||    ]|    ::|
       _ |    \      \  \     \|    ]|   .-'
      / \|     \   \  \  \     L.__  .--'(
     |   |\     `. /  /   \  ,---|_      \---------,
     |   `\'.     '. /`\   \/ .--._|=-    |_      /|
     |     \ '.     '._ './`\/ .-'          '.   / |
     |     |   `'.     `;-:-;`)|             |-./  |
     |    /_      `'--./_  ` )/'-------------')/)  |
     \   | `""""""""----""`\//`""""`/,===..'`````````/ (  |
      |  |            / `---` `==='          /   ) |
      /  \           /                      /   (  |
     |    '------.  |'--------------------'|     ) |
      \           `-|                      |    /  |
       `--...,______|                      |   (   |
              | |   |                      |    ) ,|
              | |   |                      |   ( /||
              | |   |                      |   )/ `""
             /   \  |                      |  (/
           .' /I\ '.|                      |  /)
        .-'_.'/ \'. |                      | /
        ```  `""""""` `| .-------------------.||
                    `""`                   `""`
 
 

";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.OutputEncoding = Encoding.UTF8;
            var line = string.Empty;
            while (line != "done")
            {
                try
                {
                    if (!string.IsNullOrEmpty(line))
                        Console.WriteLine(PowerLogParser.ParseInput(line));
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(x);
                    Console.Write("\n\nERROR:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(@" LOLz haha! ");
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                line = Console.ReadLine();
            }
        }
    }
}
