using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QX.UI.Comm
{
    public partial class AutoClosedMessageBox : Form
    {
        //用于保存Label的位置信息
        private static int x, y;

        /// <summary>
        /// 用于保存对话框实例。
        /// </summary>
        public static AutoClosedMessageBox ACMessageBox;

        /// <summary>
        /// 显式一个可以定时自动关闭的对话框。
        /// </summary>
        /// <param name="text">要显示的信息</param>
        /// <param name="caption">对话框的标题</param>
        /// <param name="newlineCount">限制换行的字符数</param>
        /// <param name="milliseconds">设定对话框显示的时间</param>
        public static void Show(string text, string caption, int newlineCount, int milliseconds)
        {
            string formattedText = "";
            ACMessageBox = new AutoClosedMessageBox();  //创建一个实例
            ACMessageBox.Text = caption;    //Caption参数用来设置对话框的标题
            ACMessageBox.tmrAutoClosed.Interval = milliseconds;     //用来控制定时器的触发时间间隔

            //控制要显示的文本的长度，由参数newlineCount来设置
            if (text.Length > newlineCount)
            {
                for (int position = 0; position < text.Length; position += newlineCount)
                {
                    if (text.Length - position > newlineCount)
                    {
                        formattedText += text.Substring(position, newlineCount);
                        formattedText += "\n";
                    }
                    else
                    {
                        formattedText += text.Substring(position);
                    }
                }
            }
            else
            {
                formattedText = text;
            }
            ACMessageBox.lblShowTip.Text = formattedText;   //将处理后的内容赋给Label的Text属性
            ACMessageBox.lblShowTip.TextAlign = ContentAlignment.MiddleCenter;      //设置信息在Label空间中的位置


            //使Label控件显示在对话框的中央位置
            x = (ACMessageBox.Width - ACMessageBox.lblShowTip.Width) / 2;
            y = (ACMessageBox.Height - ACMessageBox.lblShowTip.Height) / 3;
            ACMessageBox.lblShowTip.Location = new Point(x, y);

            //使对话框显示在屏幕的中央位置
            ACMessageBox.CenterToScreen();

            ACMessageBox.tmrAutoClosed.Enabled = true;      //开启定时器
            //ACMessageBox.tmrAutoClosed.Tick += new EventHandler(ACMessageBox.tmrAutoClosed_Tick);
            ACMessageBox.tmrAutoClosed.Start();
            ACMessageBox.ShowDialog();    //显示对话框。
        }

        public AutoClosedMessageBox()
        {
            InitializeComponent();
        }

        private void tmrAutoClosed_Tick(object sender, EventArgs e)
        {
            ACMessageBox.Close();   //关闭对话框
            ACMessageBox.tmrAutoClosed.Enabled = false;     //关闭定时器
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ACMessageBox.Close();   //关闭对话框
            ACMessageBox.tmrAutoClosed.Enabled = false;     //关闭定时器
        }
    }
}