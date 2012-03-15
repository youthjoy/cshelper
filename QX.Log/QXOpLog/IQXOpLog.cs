using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace QX.Log
{
    /// <summary>
    /// 日志记录扩展类
    /// </summary>
    public interface IQXOpLog:ILog
    {
        void Info(string UserId, string UserName, string clientIP, string requestUrl, object message,string Module,string ModuleName);
        void Info(string UserId, string UserName, string clientIP, string requestUrl, object message, string Module,string ModuleName, Exception t);

        void Warn(string UserId, string UserName, string clientIP, string requestUrl, object message, string Module, string ModuleName);
        void Warn(string UserId, string UserName, string clientIP, string requestUrl, object message, string Module,string ModuleName, Exception t);

        void Error(string UserId, string UserName, string clientIP, string requestUrl, object message, string Module, string ModuleName);
        void Error(string UserId, string UserName, string clientIP, string requestUrl, object message, string Module,string ModuleName, Exception t);

        void Fatal(string UserId, string UserName, string clientIP, string requestUrl, object message, string Module, string ModuleName);
        void Fatal(string UserId, string UserName, string clientIP, string requestUrl, object message, string Module,string ModuleName, Exception t);

    }
}
