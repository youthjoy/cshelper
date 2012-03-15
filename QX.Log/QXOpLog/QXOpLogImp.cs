using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Core;

namespace QX.Log
{
    public class QXOpLogImpl : LogImpl, IQXOpLog
    {
                /// <summary>
        /// The fully qualified name of this declaring type not the type of any subclass.
        /// </summary>
        private readonly static Type ThisDeclaringType = typeof(QXOpLogImpl);

        public QXOpLogImpl(ILogger logger)
            : base(logger)
        {
        }


        #region IQXLog 成员

        public void Info(string EL_Author, string EL_AuthorName, string EL_ClientIP, string EL_RequireURL, object message, string EL_Module, string EL_ModuleName)
        {
            Info(EL_Author, EL_AuthorName, EL_ClientIP, EL_RequireURL, message, EL_Module, EL_ModuleName, null);
        }

        public void Info(string EL_Author, string EL_AuthorName, string EL_ClientIP, string EL_RequireURL, object message, string EL_Module, string EL_ModuleName, Exception t)
        {
            if (this.IsInfoEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info, message, t);
                loggingEvent.Properties["EL_Author"] = EL_Author;
                loggingEvent.Properties["EL_AuthorName"] = EL_AuthorName;
                loggingEvent.Properties["EL_ClientIP"] = EL_ClientIP;
                loggingEvent.Properties["EL_RequireURL"] = EL_RequireURL;
                loggingEvent.Properties["EL_Module"] = EL_Module;
                loggingEvent.Properties["EL_ModuleName"] = EL_ModuleName;
                Logger.Log(loggingEvent);
            }
        }

        public void Warn(string EL_Author, string EL_AuthorName, string EL_ClientIP, string EL_RequireURL, object message, string EL_Module, string EL_ModuleName)
        {
            Warn(EL_Author, EL_AuthorName, EL_ClientIP, EL_RequireURL, message,EL_Module,EL_ModuleName, null);
        }

        public void Warn(string EL_Author, string EL_AuthorName, string EL_ClientIP, string EL_RequireURL, object message, string EL_Module, string EL_ModuleName, Exception t)
        {
            if (this.IsWarnEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info, message, t);
                loggingEvent.Properties["EL_Author"] = EL_Author;
                loggingEvent.Properties["EL_AuthorName"] = EL_AuthorName;
                loggingEvent.Properties["EL_ClientIP"] = EL_ClientIP;
                loggingEvent.Properties["EL_RequireURL"] = EL_RequireURL;
                loggingEvent.Properties["EL_Module"] = EL_Module;
                loggingEvent.Properties["EL_ModuleName"] = EL_ModuleName;
                Logger.Log(loggingEvent);
            }
        }

        public void Error(string EL_Author, string EL_AuthorName, string EL_ClientIP, string EL_RequireURL, object message, string EL_Module, string EL_ModuleName)
        {
            Error(EL_Author, EL_AuthorName, EL_ClientIP, EL_RequireURL, message, EL_Module,EL_ModuleName, null);
        }

        public void Error(string EL_Author, string EL_AuthorName, string EL_ClientIP, string EL_RequireURL, object message, string EL_Module, string EL_ModuleName, Exception t)
        {
            if (this.IsErrorEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info, message, t);
                loggingEvent.Properties["EL_Author"] = EL_Author;
                loggingEvent.Properties["EL_AuthorName"] = EL_AuthorName;
                loggingEvent.Properties["EL_ClientIP"] = EL_ClientIP;
                loggingEvent.Properties["EL_RequireURL"] = EL_RequireURL;
                loggingEvent.Properties["EL_Module"] = EL_Module;
                loggingEvent.Properties["EL_ModuleName"] = EL_ModuleName;
                Logger.Log(loggingEvent);
            }
        }

        public void Fatal(string EL_Author, string EL_AuthorName, string EL_ClientIP, string EL_RequireURL, object message, string EL_Module, string EL_ModuleName)
        {
            Fatal(EL_Author, EL_AuthorName, EL_ClientIP, EL_RequireURL, message, EL_Module,EL_ModuleName, null);
        }

        public void Fatal(string EL_Author, string EL_AuthorName, string EL_ClientIP, string EL_RequireURL, object message,string EL_Module, string EL_ModuleName, Exception t)
        {
            if (this.IsFatalEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info, message, t);
                loggingEvent.Properties["EL_Author"] = EL_Author;
                loggingEvent.Properties["EL_AuthorName"] = EL_AuthorName;
                loggingEvent.Properties["EL_ClientIP"] = EL_ClientIP;
                loggingEvent.Properties["EL_RequireURL"] = EL_RequireURL;
                loggingEvent.Properties["EL_Module"] = EL_Module;
                loggingEvent.Properties["EL_ModuleName"] = EL_ModuleName;
                Logger.Log(loggingEvent);
            }
        }

        #endregion
     
    }
}
