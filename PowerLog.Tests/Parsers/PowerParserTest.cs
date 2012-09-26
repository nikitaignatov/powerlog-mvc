using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprache;
using PowerLog.Parser;

namespace PowerLog.Tests.Parsers
{
    [TestClass]
    public class PowerParserTest
    {
        public PowerParserTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        [TestMethod]
        public void ParseANumber()
        {
            string result = PowerParser.numberParser.Parse("101");
            Assert.AreEqual("101", result);
        }
        [TestMethod]
        public void FailToParseANumberBecauseItHasTextInIt()
        {
            // x9cX0o3NMKbNSYUaSZ9yzz	b7ee365c4b5108e84c61b05da1ebbad1
            string result = PowerParser.numberParser.TryParse("abc").ToString();
            Assert.IsTrue(result.StartsWith("Parsing failure"));
        }
        [TestMethod]
        public void ParseJustThreeNumbers()
        {
            string result = PowerParser.threeNumberParser.Parse("123");
            Assert.AreEqual("123", result);
        }
        [TestMethod]
        public void ParseJustThreeNumbersOutOfMore()
        {
            string result = PowerParser.threeNumberParser.Parse("12345678");
            Assert.AreEqual("123", result);
        }
        [TestMethod]
        public void FailToParseAThreeDigitNumberBecauseItIsTooShort()
        {
            var result = PowerParser.threeNumberParser.TryParse("10");
            Assert.IsTrue(result.ToString().StartsWith("Parsing failure"));
        }
    }
}
