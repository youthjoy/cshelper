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
    public interface IQXLog:ILog
    {
        void Info(string UserId, string UserName, string clientIP, string requestUrl, object message);
        void Info(string UserId, string UserName, string clientIP, string requestUrl, object message, Exception t);

        void Warn(string UserId, string UserName, string clientIP, string requestUrl, object message);
        void Warn(string UserId, string UserName, string clientIP, string requestUrl, object message, Exception t);

        void Error(string UserId, string UserName, string clientIP, string requestUrl, object message);
        void Error(string UserId, string UserName, string clientIP, string requestUrl, object message, Exception t);

        void Fatal(string UserId, string UserName, string clientIP, string requestUrl, object message);
        void Fatal(string UserId, string UserName, string clientIP, string requestUrl, object message, Exception t);

    }
}
