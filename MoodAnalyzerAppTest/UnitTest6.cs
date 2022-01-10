using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerApp;

namespace MoodAnalyzerAppTest
{
    [TestClass]
    public class UC6TestCase
    {
        /// <summary>
        /// TC 6.1 : Given Happy Message When Proper Should Return HAPPY Mood Using Reflection. 
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_ShouldReturn_HappyMood_UsingReflectorInvoke_Method()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }

        /// <summary>
        /// TC 6.2 : Given Happy Message When Improper Method Should Throw MoodAnalysisException.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessageWhenImproperMethodShouldThrowMoodAnalysisException()
        {
            try
            {
                string expected = "method not found";
                string mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMoodWrong");
                Assert.AreNotEqual(expected, mood);
            }

            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("method not found", ex.Message);
            }
        }
    }
}