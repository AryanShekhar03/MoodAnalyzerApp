using System;

namespace MoodAnalyzerApp
{
    public class MoodAnalysisException : Exception
    {
        /// <summary>
        /// MoodAnalysisException Class for Handling Exception.
        /// </summary>
        public enum ExceptionType
        {
            NULL_MESSAGE, EMPTY_MESSAGE,
            NO_SUCH_FIELD, NO_SUCH_METHOD,
            NO_SUCH_CLASS, OBJECT_CREATION_ISSUE
        }

        // Creating 'type' variable of type ExceptionType
        private readonly ExceptionType type;

        public MoodAnalysisException(ExceptionType Type, string message) : base(message)
        {
            this.type = Type;
        }
    }
}