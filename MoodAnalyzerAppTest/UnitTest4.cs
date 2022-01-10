using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerApp;

namespace MoodAnalyzerAppTest
{
    [TestClass]
    public class UC4TestCase
    {
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            string message = null;
            object expected = new MoodAnalyse3(message);
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerApp.MoodAnalyse3", "MoodAnalyse3");
            expected.Equals(obj);

        }

        [TestMethod]
        public void GivenClassNameWhenImproperShouldThrowMoodAnalysisException()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyse3(message);
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerApp.MoodAnalyse3Wrong", "MoodAnalyse3Wrong");
                expected.Equals(obj);
            }
            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Class not Found", ex.Message);
            }
        }

        [TestMethod]
        public void GivenClassWhenConstuctorNotProperShouldThrowMoodAnalysisException()
        {
            try
            {
                string message = null;
                object expected = new MoodAnalyse3(message);
                object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyzerApp.MoodAnalyse3", "MoodAnalyse3Wrong");
                expected.Equals(obj);
            }

            catch (MoodAnalysisException ex)
            {
                Assert.AreEqual("Constructor not Found", ex.Message);
            }
        }
    }
}