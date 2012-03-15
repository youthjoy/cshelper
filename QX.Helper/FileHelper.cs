using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace QX.Helper
{
    public class FileHelper
    {
        public static void OpenFile(string path)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName =GlabolConfiguration.SeverPath + path.Replace('/', '\\');
                ////打开资源管理器
                //proc.StartInfo.Arguments = @"/select,"+path;
                //选中"这个路径的"这个程序,即记事本
                proc.Start();
            }
            catch (Exception e)
            {
                throw e;
                ////写入数据库日志
                //PlateLog.WriteError(SessionConfig.UserID, SessionConfig.UserName,
                //    "", "CompManage",
                //   e.Message, PlateLog.LogMessageType.Error, e);
            }
        }
    }
}
