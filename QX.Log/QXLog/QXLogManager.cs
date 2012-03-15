using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using log4net.Core;

namespace QX.Log
{
    public  class QXLogManager
    {

        private static readonly WrapperMap s_wrapperMap = new WrapperMap(new WrapperCreationHandler(WrapperCreationHandler));

        private QXLogManager() { }

        public static IQXLog Exists(string name)
        {
            return Exists(Assembly.GetCallingAssembly(), name);
        }

        public static IQXLog Exists(string domain, string name)
        {
            return WrapLogger(LoggerManager.Exists(domain, name));
        }

        public static IQXLog Exists(Assembly assembly, string name)
        {
            return WrapLogger(LoggerManager.Exists(assembly, name));
        }

        public static IQXLog[] GetCurrentLoggers()
        {
            return GetCurrentLoggers(Assembly.GetCallingAssembly());
        }

        public static IQXLog[] GetCurrentLoggers(string domain)
        {
            return WrapLoggers(LoggerManager.GetCurrentLoggers(domain));
        }

        public static IQXLog[] GetCurrentLoggers(Assembly assembly)
        {
            return WrapLoggers(LoggerManager.GetCurrentLoggers(assembly));
        }

        public static IQXLog GetLogger(string name)
        {
            return GetLogger(Assembly.GetCallingAssembly(), name);
        }

        public static IQXLog GetLogger(string domain, string name)
        {
            return WrapLogger(LoggerManager.GetLogger(domain, name));
        }

        public static IQXLog GetLogger(Assembly assembly, string name)
        {
            return WrapLogger(LoggerManager.GetLogger(assembly, name));
        }

        public static IQXLog GetLogger(Type type)
        {
            return GetLogger(Assembly.GetCallingAssembly(), type.FullName);
        }

        public static IQXLog GetLogger(string domain, Type type)
        {
            return WrapLogger(LoggerManager.GetLogger(domain, type));
        }


        public static IQXLog GetLogger(Assembly assembly, Type type)
        {
            return WrapLogger(LoggerManager.GetLogger(assembly, type));
        }

        private static IQXLog WrapLogger(ILogger logger)
        {
            return (IQXLog)s_wrapperMap.GetWrapper(logger);
        }

        private static IQXLog[] WrapLoggers(ILogger[] loggers)
        {
            IQXLog[] results = new IQXLog[loggers.Length];
            for (int i = 0; i < loggers.Length; i++)
            {
                results[i] = WrapLogger(loggers[i]);
            }
            return results;
        }

        private static ILoggerWrapper WrapperCreationHandler(ILogger logger)
        {
            return new QXLogImpl(logger);
        }

    }
}
