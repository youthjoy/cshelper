using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace QX.GenFramework.Helper
{
    public class ToolBarHelper
    {
        private string name = "StripItem" + new Random().Next(200, 1000);
        /// <summary>
        /// 控件名字
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private ToolStripItemDisplayStyle displayStyle = ToolStripItemDisplayStyle.ImageAndText;
        /// <summary>
        /// 显示文本和图像
        /// </summary>
        public ToolStripItemDisplayStyle DisplayStyle
        {
            get { return displayStyle; }
            set { displayStyle = value; }
        }

        private ContentAlignment imageAlign = ContentAlignment.MiddleCenter;
        /// <summary>
        /// 图像对齐方式
        /// </summary>
        public ContentAlignment ImageAlign
        {
            get { return imageAlign; }
            set { imageAlign = value; }
        }

        private TextImageRelation textImageRelation = TextImageRelation.ImageAboveText;
        /// <summary>
        /// 文本和图像相对的位置
        /// </summary>
        public TextImageRelation TextImageRelation
        {
            get { return textImageRelation; }
            set { textImageRelation = value; }
        }

        /// <summary>
        /// 新建ToolStripButton
        /// </summary>
        /// <param name="txt">显示文本</param>
        /// <param name="img">显示图片</param>
        /// <param name="click">点击事件</param>
        /// <returns></returns>
        public ToolStripButton New(String txt, Image img, EventHandler click)
        {
            
            ToolStripButton item = new ToolStripButton(txt, img, click);
            item.Name = this.name;
            item.DisplayStyle = this.displayStyle;
            item.ImageAlign = this.imageAlign;
            item.TextImageRelation = this.textImageRelation;
            return item;
        }
    }
}
