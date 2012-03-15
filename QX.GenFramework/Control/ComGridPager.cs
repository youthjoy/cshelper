using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BC.Common.BseControl
{
    public partial class ComGridPager : UserControl
    {
        public ComGridPager()
        {
            InitializeComponent();

            this.Load += new EventHandler(ComGridPager_Load);
        }

        void ComGridPager_Load(object sender, EventArgs e)
        {
            this.btnFirst.Click += new EventHandler(btnFirst_Click);
            this.btnLast.Click += new EventHandler(btnLast_Click);
            this.btnNext.Click += new EventHandler(btnNext_Click);
            this.btnPrior.Click += new EventHandler(btnPrior_Click);
        }


        public delegate void DCallBackHandler();

        //public event DCallBackHandler CallBack;

        void btnPrior_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnNext_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnLast_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnFirst_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private int _CurrentPage = 0;
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; }
        }

        /// <summary>
        /// 一页显示记录数
        /// </summary>
        public int PageSize
        {
            get;
            set;
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get;
            set;
        }

        //private int _PageCount = 0;
        /// <summary>
        /// 页数
        /// </summary>
        public int PageCount
        {
            get 
            {
                if (PageSize != 0)
                {
                    return TotalCount / PageSize;
                }
                else
                {
                    return 0;
                }
            }
        }


    }
}
