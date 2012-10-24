using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Sprache;
using PowerLog.Parser;
using NUnit.Framework;

namespace PowerLog.Tests.Parsers
{
    [TestFixture]
    public class PowerParserTest
    {
        private static IEnumerable<Log> ParseInput(string input)
        {
            return PowerLogParser.ParseInput(input);
        }


        [Test]
        public void shold_parse_front_squat_2x20()
        {
            // arrange
            const string input = "front squat 2x20";

            // act
            var result = ParseInput(input).First();
            var set = result.Sets.SingleOrDefault();

            // assert
            Assert.AreEqual("front squat", result.Name);
            Assert.NotNull(set);
            Assert.AreEqual(2, set.Reps);
            Assert.AreEqual(20, set.Weight);
        }

        [Test]
        public void shold_parse_front_squat_2x4x20()
        {
            // arrange
            const string input = "front squat 2x4x20";

            // act
            var result = ParseInput(input).First();
            var set = result.Sets.FirstOrDefault();
            var count = result.Sets.Count;

            // assert
            Assert.AreEqual("front squat", result.Name);
            Assert.NotNull(set);
            Assert.AreEqual(2, set.Sets);
            Assert.AreEqual(4, set.Reps);
            Assert.AreEqual(20, set.Weight);
        }

        [Test]
        public void shold_parse_front_squat_2x20_DOT_5()
        {
            // arrange
            const string input = "front squat 2x20.5";

            // act
            var result = ParseInput(input).First();
            var set = result.Sets.SingleOrDefault();

            // assert
            Assert.AreEqual("front squat", result.Name);
            Assert.NotNull(set);
            Assert.AreEqual(2, set.Reps);
            Assert.AreEqual(20.5, set.Weight);
        }

        [Test]
        public void shold_parse_front_squat_30_max_ftl()
        {
            // graph:http://rise4fun.com/Agl/T9ke
            // arrange
            const string input = "front squat 30-max-ftl";

            // act
            var result = ParseInput(input).First();
            var set = result.Sets.SingleOrDefault();

            // assert
            Assert.AreEqual("front squat", result.Name);
            Assert.NotNull(set);
            Assert.AreEqual(1, set.Reps);
            Assert.AreEqual(30, set.Weight);
            Assert.IsTrue(set.MaxEffort);
            Assert.IsTrue(set.FailedToLift);
        }

        [Test]
        public void shold_parse_front_squat_30_note_hello_world_max()
        {
            // arrange
            const string input = "front squat 30-note(hello world)-max";

            // act
            var result = ParseInput(input).First();
            var set = result.Sets.SingleOrDefault();

            // assert
            Assert.AreEqual("front squat", result.Name);
            Assert.NotNull(set);
            Assert.AreEqual(1, set.Reps);
            Assert.AreEqual(30, set.Weight);
            Assert.AreEqual("hello world", set.Comment);
            Assert.IsTrue(set.MaxEffort);
        }

        [Test]
        public void shold_parse_front_squat_30_note_hello_world_max_fr_1()
        {
            // graph:http://rise4fun.com/Agl/nQxN
            // arrange
            const string input = "front squat 30-note(hello world)-max-fr(1)";

            // act
            var result = ParseInput(input).First();
            var set = result.Sets.SingleOrDefault();

            // assert
            Assert.AreEqual("front squat", result.Name);
            Assert.NotNull(set);
            Assert.AreEqual(1, set.Reps);
            Assert.AreEqual(30, set.Weight);
            Assert.AreEqual("hello world", set.Comment);
            Assert.IsTrue(set.MaxEffort);
            Assert.AreEqual(1, set.ForcedReps);
        }

        [Test]
        public void shold_parse_front_squat_30_note_hello_world()
        {
            // arrange
            const string input = "front squat 30-note(hello world)";

            // act
            var result = ParseInput(input).First();
            var set = result.Sets.SingleOrDefault();

            // assert
            Assert.AreEqual("front squat", result.Name);
            Assert.NotNull(set);
            Assert.AreEqual(1, set.Reps);
            Assert.AreEqual(30, set.Weight);
            Assert.AreEqual("hello world", set.Comment);
        }

        [Test]
        public void shold_parse_front_squat_2x20_30()
        {
            // arrange
            const string input = "front squat 2x20 30";

            // act
            var result = ParseInput(input).First();
            var first = result.Sets.FirstOrDefault();
            var second = result.Sets.Skip(1).SingleOrDefault();

            // assert
            Assert.AreEqual("front squat", result.Name);

            Assert.NotNull(first);
            Assert.NotNull(second);

            Assert.AreEqual(2, first.Reps);
            Assert.AreEqual(20, first.Weight);

            Assert.AreEqual(1, second.Reps);
            Assert.AreEqual(30, second.Weight);
        }

        [Test]
        public void shold_parse_front_squat_4x20_fr_1()
        {
            // arrange
            const string input = "front squat 4x20-fr(1)";

            // act
            var result = ParseInput(input).First();
            var set = result.Sets.SingleOrDefault();

            // assert
            Assert.AreEqual("front squat", result.Name);
            Assert.NotNull(set);
            Assert.AreEqual(4, set.Reps);
            Assert.AreEqual(20, set.Weight);
            Assert.AreEqual(1, set.ForcedReps);
        }

        [Test]
        public void shold_parse_front_squat_6x4x20_fr_2()
        {
            // arrange
            const string input = "front squat 6x4x20-fr(2)";

            // act
            var result = ParseInput(input).First();
            var set = result.Sets.FirstOrDefault();
            var count = result.Sets.Count;

            // assert
            Assert.AreEqual("front squat", result.Name);
            Assert.NotNull(set);
            Assert.AreEqual(6, set.Sets);
            Assert.AreEqual(4, set.Reps);
            Assert.AreEqual(20, set.Weight);
            Assert.AreEqual(2, set.ForcedReps);
        }
    }
}
