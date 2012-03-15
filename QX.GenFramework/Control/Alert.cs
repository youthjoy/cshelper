using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QX.GenFramework.BseControl
{
    public class Alert
    {
        /// <summary>
        /// 消息提示
        /// </summary>
        /// <param name="type">用以显示哪些按钮</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        public static DialogResult Show(MessageBoxButtons type, string message)
        {
            DialogResult result = DialogResult.Cancel;
            string caption = "提示信息";
            switch (type)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    result = MessageBox.Show(message, caption, type, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    break;
                case MessageBoxButtons.OK:
                    result = MessageBox.Show(message, caption, type, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    break;
                case MessageBoxButtons.OKCancel:
                    result = MessageBox.Show(message, caption, type, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    break;
                case MessageBoxButtons.RetryCancel:
                    result = MessageBox.Show(message, caption, type, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    break;
                case MessageBoxButtons.YesNo:
                    result = MessageBox.Show(message, caption, type, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    result = MessageBox.Show(message, caption, type, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    break;
                default:
                    break;
            }
            return result;
        }

        public static DialogResult Show(string message)
        {
            DialogResult result = DialogResult.Cancel;
            string caption = "提示信息";
            result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            return result;
        }

  


        public static bool ShowIsConfirm(string message)
        {
            DialogResult re = Alert.Show(MessageBoxButtons.OKCancel, message);
            if (re == DialogResult.OK)
            {
                return true;
            }

            return false;
        }
    }
}
