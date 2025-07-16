using System.Diagnostics;

namespace logger.Logging.Extensions
{
    internal static class StackFrameExtensions
    {
        public static string ToCallerString(this StackFrame frame)
        {
            string methodName = "unknown";
            string className = "unknown";
            var line = frame.GetFileLineNumber();
            var method = frame.GetMethod();
            if (method != null)
            {
                methodName = method.Name;
                if (method.DeclaringType?.FullName is string fullName)
                {
                    className = fullName;
                }
            }
            return $"{className}.{methodName}#{line}";
        }
    }
}
