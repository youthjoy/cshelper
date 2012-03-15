using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

[assembly: log4net.Config.DOMConfigurator(Watch = true)]  
namespace QX.Log
{

    /// <summary>
    /// 日志处理
    /// </summary>
    public class PlateLog
    {
        /// <summary>
        /// 静态类
        /// </summary>
        private PlateLog() { }
        private const string LOG_REPOSITORY = "Default"; // this should likely be set in the web config.
        private static ILog m_log=LogManager.GetLogger(LOGGER.TOFILE.ToString());
        private static IQXLog QX_Log = QXLogManager.GetLogger(LOGGER.App_Error.ToString());
        private static IQXOpLog QXOp_Log = QXOpLogManager.GetLogger(LOGGER.App_Op.ToString());
        /// <summary>
        /// 初始化日志系统
        /// 在系统运行开始初始化
        /// Global.asax Application_Start内
        /// </summary>
        public static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        #region 系统文本日志

        /// <summary>
        /// 写入文本日志
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UserName"></param>
        /// <param name="ClientIP"></param>
        /// <param name="RequireURL"></param>
        /// <param name="Message"></param>
        /// <param name="MessageType"></param>
        /// <param name="ex"></param>
        public static void WriteInFile(string UserId, string UserName, string ClientIP, string RequireURL, string Message, LogMessageType MessageType,Exception ex)
        {
            DoLog(UserId, UserName, ClientIP, RequireURL, Message,null,null, MessageType, ex,LOGGER.TOFILE);
        }

        /// <summary>
        /// 系统异常日志
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="UserName"></param>
        /// <param name="ClientIP"></param>
        /// <param name="RequireURL"></param>
        /// <param name="Message"></param>
        /// <param name="MessageType"></param>
        /// <param name="ex"></param>
        public static void WriteError(string UserId, string UserName, string ClientIP, string RequireURL, string Message, LogMessageType MessageType, Exception ex)
        {
            DoLog(UserId, UserName, ClientIP, RequireURL, Message, null, null, MessageType, ex, LOGGER.App_Error);
        }

        /// <summary>
        /// 系统操作日志
        /// </summary>
        /// <param name="UserId">用户编码</param>
        /// <param name="UserName">用户名称</param>
        /// <param name="ClientIP">来源IP</param>
        /// <param name="RequireURL">请求URL</param>
        /// <param name="Message">信息</param>
        /// <param name="MessageType">日志类型</param>
        /// <param name="Module">模块编码</param>
        /// <param name="ModuleName">模块名称</param>
        public static void WriteOp(string UserId, string UserName, string ClientIP, string RequireURL, string Message, LogMessageType MessageType,string Module,string ModuleName)
        {
            DoLog(UserId, UserName, ClientIP, RequireURL, Message, Module, ModuleName, MessageType, null, LOGGER.App_Op);
        }

        /// <summary>
        /// 保存日志(生产环境)
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="messageType">日志类型</param>
        /// <param name="ex">异常</param>
        /// <param name="type">写入日志介质</param>
        public static void DoLog(string UserId,string UserName,string ClientIP,string RequireURL, string message,string Module,string ModuleName,
                                 LogMessageType messageType, Exception ex,LOGGER logger)
        {
            switch (logger)
            {
                case LOGGER.App_Error:
                    switch (messageType)
                    {
                        case LogMessageType.Debug:
                            PlateLog.QX_Log.Debug(message, ex);
                            break;
                        case LogMessageType.Info:
                            PlateLog.QX_Log.Info(UserId, UserName, ClientIP, RequireURL, message, ex);
                            break;
                        case LogMessageType.Warn:
                            PlateLog.QX_Log.Warn(UserId, UserName, ClientIP, RequireURL, message, ex);
                            break;
                        case LogMessageType.Error:
                            PlateLog.QX_Log.Error(UserId, UserName, ClientIP, RequireURL, message, ex);
                            break;
                        case LogMessageType.Fatal:
                            PlateLog.QX_Log.Fatal(UserId, UserName, ClientIP, RequireURL, message, ex);
                            break;
                    }
                    break;
                case LOGGER.TOFILE:
                    switch (messageType)
                    {
                        case LogMessageType.Debug:
                            PlateLog.m_log.Debug(message, ex);
                            break;
                        case LogMessageType.Info:
                            PlateLog.m_log.Info(message, ex);
                            break;
                        case LogMessageType.Warn:
                            PlateLog.m_log.Warn(message, ex);
                            break;
                        case LogMessageType.Error:
                            PlateLog.m_log.Error(message, ex);
                            break;
                        case LogMessageType.Fatal:
                            PlateLog.m_log.Fatal(message, ex);
                            break;
                    }
                    break;
                case LOGGER.App_Op:
                    switch (messageType)
                    {
                        case LogMessageType.Debug:
                            PlateLog.QXOp_Log.Debug(message, ex);
                            break;
                        case LogMessageType.Info:
                            PlateLog.QXOp_Log.Info(UserId, UserName, ClientIP, RequireURL, message,Module,ModuleName);
                            break;
                        case LogMessageType.Warn:
                            PlateLog.QXOp_Log.Warn(UserId, UserName, ClientIP, RequireURL, message,Module,ModuleName);
                            break;
                        case LogMessageType.Error:
                            PlateLog.QXOp_Log.Error(UserId, UserName, ClientIP, RequireURL, message,Module,ModuleName);
                            break;
                        case LogMessageType.Fatal:
                            PlateLog.QXOp_Log.Fatal(UserId, UserName, ClientIP, RequireURL, message,Module,ModuleName);
                            break;
                    }
                    break;
                default:
                    break;
            }
            
        }

        #endregion

        /// <summary>
        /// 日志类型
        /// </summary>
        public enum LogMessageType
        {
            /// <summary>
            /// 调试
            /// </summary>
            Debug,
            /// <summary>
            /// 信息
            /// </summary>
            Info,
            /// <summary>
            /// 警告
            /// </summary>
            Warn,
            /// <summary>
            /// 错误
            /// </summary>
            Error,
            /// <summary>
            /// 致命错误
            /// </summary>
            Fatal
        }

        /// <summary>
        /// 日志写入类型
        /// </summary>
        public enum LOGGER{
            /// <summary>
            /// 系统操作日志
            /// </summary>
            App_Op,
            /// <summary>
            /// 系统异常日志
            /// </summary>
            App_Error,
            /// <summary>
            /// 写入文本
            /// </summary>
            TOFILE
        }
    }
}
