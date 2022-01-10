using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerApp;
using System;

namespace MoodAnalyzerAppTest
{
    [TestClass]
    public class UC2TestCase
    {
        [TestMethod]
        [DataRow(null)]
        public void GivenHAPPYMoodShouldReturnHappy(string message)
        {
            // Arrange
            string expected = "HAPPY";
            MoodAnalyse2 moodAnalyzer = new MoodAnalyse2(message);

            //Act
            string mood = moodAnalyzer.AnalyseMood();

            // Assert
            Assert.AreEqual(expected, mood);
        }
    }
}