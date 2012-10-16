using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PowerLog.Parser;

namespace PowerLog.Tests.Parsers
{
    [TestFixture]
    public class ParserExceptionHandling
    {
        private static IEnumerable<Log> ParseInput(string input)
        {
            return PowerLogParser.ParseInput(input).ToList();
        }
        
        [Test]
        public void shold_throw_when_barbell_bent_over_row_2x12x60()
        {
            // arrange
            const string input = "barbell bent-over row 2x12x60";

            // act
            var ex = Assert.Throws<Exception>(() => ParseInput(input));
        }

        [Test]
        public void shold_throw_when_this_is_sparta_2x()
        {
            // arrange
            const string input = "this is sparta 2x";

            // act
            var ex = Assert.Throws<Exception>(() => ParseInput(input));
            Assert.That(ex.Message, Is.EqualTo("No sets defined for [this is sparta]"));
        }

        [Test]
        public void shold_throw_when_barbell_curl()
        {
            // arrange
            const string input = "barbell curl ";

            // act
            var ex = Assert.Throws<Exception>(() => ParseInput(input));
            Assert.That(ex.Message, Is.EqualTo("No sets defined for [barbell curl]"));
        }
         
        [Test]
        public void shold_not_throw_when_barbell_curl_20x0_()
        {
            // arrange
            const string input = "barbell curl 20x0 ";

            // act
            Assert.DoesNotThrow(() => ParseInput(input));
        }

        [Test]
        public void shold_throw_when_2x2()
        {
            // arrange
            const string input = "2x2";

            // act
            var ex = Assert.Throws<Exception>(() => ParseInput(input));
            Assert.That(ex.Message, Is.EqualTo("Exercise is missing a name."));
        }

        [Test]
        public void shold_throw_when_2()
        {
            // arrange
            const string input = "2";

            // act
            var ex = Assert.Throws<Exception>(() => ParseInput(input));
            Assert.That(ex.Message, Is.EqualTo("Exercise is missing a name."));
        }


        [Test]
        public void shold_throw_when_this_is_LP_sparta_RP_2x2()
        {
            // arrange
            const string input = "this is (sparta) 2x2";

            // act
            var ex = Assert.Throws<Exception>(() => ParseInput(input));
            //   Assert.That(ex.Message, Is.EqualTo("Actual exception message"));
        }
    }
}
