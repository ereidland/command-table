using System.Collections.Generic;

namespace CommandTable
{
    public static class Log
    {
        public enum Level
        {
            Raw,
            Debug,
            Info,
            Warning,
            Error,
            Exception,
        }

        public delegate void LogCallback(Level level, string message); 

        static List<LogCallback> _logCallbacks = new List<LogCallback>();

        public static void AddLogCallback(LogCallback callback)
        {
            if (callback == null || _logCallbacks.Contains(callback))
                return;

            _logCallbacks.Add(callback);
        }

        public static void RemoveLogCallback(LogCallback callback)
        {
            if (callback == null)
                return;

            _logCallbacks.Remove(callback);
        }

        public static void Message(Level level, string message)
        {
            for (int i = 0; i < _logCallbacks.Count; i++)
            {
                _logCallbacks[i](level, message);
            }
        }

        public static void MessageFormat(Level level, string format, params object[] args)
        {
            Message(level, string.Format(format, args));
        }
    }
}
