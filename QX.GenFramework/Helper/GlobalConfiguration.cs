using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace QX.GenFramework.Helper
{
    public static class GlobalConfiguration
    {
        /// <summary>
        /// 审核配色   待审 审核中  废单
        /// </summary>
        public static Color[] AuditColor = { Color.Wheat, Color.SkyBlue, Color.Red };
        /// <summary>
        /// 计划状态配色 未开  已开  废弃
        /// </summary>
        public static Color[] PlanStatColor = { Color.Yellow, Color.SkyBlue, Color.Tomato };
        /// <summary>
        /// 计划状态配色  未安排  安排  废弃
        /// </summary>
        public static Color[] CPlanStatColor = { Color.Yellow, Color.SkyBlue, Color.Tomato };


        public static string Admin = "admin";

        public static string Password = "admin";

    }
}
