using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyzerApp
{
    public class MoodAnalyserFactory
    {
        /// <summary>
        /// UC5 : For parameterized constructor by passing message parameter to class method.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyse3);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                    object instance = ctor.Invoke(new object[] { message });
                    return instance;
                }
                else
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "Constructor not Found");
                }
            }
            else
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_CLASS, "Class not Found");
            }
        }

        /// <summary>
        /// UC6 : Use Reflection to invoke Method – analyseMood
        /// </summary>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyse3);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object moodAnalyserObject = MoodAnalyserFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerApp.MoodAnalyse3",
                    "MoodAnalyse3", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }

            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NULL_VALUE, "method not found");
            }

            /// <summary>
            /// UC7 : Use Reflection to change mood dynamically
            /// </summary>
            public static string Setfield(string message, string fieldName)
            {
                try
                {
                    MoodAnalyse3 moodAnalyse = new MoodAnalyse3();
                    Type type = typeof(MoodAnalyse3);
                    FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                    if (message == null)
                    {
                        throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                    }
                    field.SetValue(moodAnalyse, message);
                    return moodAnalyse.message;
                }

                catch (NullReferenceException)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "Field not Found");
                }
            }
        }
    }
}



            
    
