using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using log4net.Core;

namespace QX.Log
{
    public  class QXOpLogManager
    {

        private static readonly WrapperMap s_wrapperMap = new WrapperMap(new WrapperCreationHandler(WrapperCreationHandler));

        private QXOpLogManager() { }

        public static IQXOpLog Exists(string name)
        {
            return Exists(Assembly.GetCallingAssembly(), name);
        }

        public static IQXOpLog Exists(string domain, string name)
        {
            return WrapLogger(LoggerManager.Exists(domain, name));
        }

        public static IQXOpLog Exists(Assembly assembly, string name)
        {
            return WrapLogger(LoggerManager.Exists(assembly, name));
        }

        public static IQXOpLog[] GetCurrentLoggers()
        {
            return GetCurrentLoggers(Assembly.GetCallingAssembly());
        }

        public static IQXOpLog[] GetCurrentLoggers(string domain)
        {
            return WrapLoggers(LoggerManager.GetCurrentLoggers(domain));
        }

        public static IQXOpLog[] GetCurrentLoggers(Assembly assembly)
        {
            return WrapLoggers(LoggerManager.GetCurrentLoggers(assembly));
        }

        public static IQXOpLog GetLogger(string name)
        {
            return GetLogger(Assembly.GetCallingAssembly(), name);
        }

        public static IQXOpLog GetLogger(string domain, string name)
        {
            return WrapLogger(LoggerManager.GetLogger(domain, name));
        }

        public static IQXOpLog GetLogger(Assembly assembly, string name)
        {
            return WrapLogger(LoggerManager.GetLogger(assembly, name));
        }

        public static IQXOpLog GetLogger(Type type)
        {
            return GetLogger(Assembly.GetCallingAssembly(), type.FullName);
        }

        public static IQXOpLog GetLogger(string domain, Type type)
        {
            return WrapLogger(LoggerManager.GetLogger(domain, type));
        }


        public static IQXOpLog GetLogger(Assembly assembly, Type type)
        {
            return WrapLogger(LoggerManager.GetLogger(assembly, type));
        }

        private static IQXOpLog WrapLogger(ILogger logger)
        {
            return (IQXOpLog)s_wrapperMap.GetWrapper(logger);
        }

        private static IQXOpLog[] WrapLoggers(ILogger[] loggers)
        {
            IQXOpLog[] results = new IQXOpLog[loggers.Length];
            for (int i = 0; i < loggers.Length; i++)
            {
                results[i] = WrapLogger(loggers[i]);
            }
            return results;
        }

        private static ILoggerWrapper WrapperCreationHandler(ILogger logger)
        {
            return new QXOpLogImpl(logger);
        }

    }
}
