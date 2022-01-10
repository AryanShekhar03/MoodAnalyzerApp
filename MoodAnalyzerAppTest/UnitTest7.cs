using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerApp;

namespace MoodAnalyzerMSTestWithCore
{
    [TestClass]
    public class UC7TestCase
    {
        /// <summary>
        /// TC 7.1 : Set Happy Message with Reflector Should Return HAPPY
        /// </summary>
        [TestMethod]
        public void GivenHappy_ShouldReturnHappy_WithReflectorDynamically()
        {
            string result = MoodAnalyserFactory.Setfield("Happy", "message");
            Assert.AreEqual("Happy", result);
        }

        /// <summary>
        /// TC 7.2 : Set Field When Improper Should Throw Exception with No Such Field
        /// </summary>
        [TestMethod]
        public void GivenWrongFieldShouldReturnException()
        {
            try
            {
                string result = MoodAnalyserFactory.Setfield("Happy", "messageWrong");
                Assert.AreEqual("Happy", result);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Field not Found", ex.Message);
            }
        }

        /// <summary>
        /// TC 7.3 : Setting Null Message with Reflector Should Throw Exception
        /// </summary>
        [TestMethod]
        public void GivenEmptyMessageShouldReturnException()
        {
            try
            {
                string result = MoodAnalyserFactory.Setfield(null, "message");
                Assert.AreEqual("Happy", result);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Message should not be null", ex.Message);
            }
        }
    }
}