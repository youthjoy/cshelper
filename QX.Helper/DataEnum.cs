using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QX.Helper
{

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// 查看数据
        /// </summary>
        Look,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit,
        /// <summary>
        /// 添加
        /// </summary>
        Add,
        /// <summary>
        /// 删除
        /// </summary>
        Delete,
        /// <summary>
        /// 查找
        /// </summary>
        Search,
        /// <summary>
        /// 复制
        /// </summary>
        Copy,
        /// <summary>
        /// 浏览数据,可编辑部分数据
        /// </summary>
        View

    }
}
