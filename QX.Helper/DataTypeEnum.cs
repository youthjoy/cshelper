using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QX.Helper
{
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationTypeEnum
    {
        Add,
        Edit,
        Look,
        Query,
        Finish
    }

    /// <summary>
    /// 成品状态
    /// </summary>
    public enum ProdStat
    { 
        In,
        Out
    }

    public enum iTypeEnum
    { 
        /*Prod_Pool*/
        Prod,

        /*Prod_Components*/
        Comp,/*Prod_Doc*/
        OtherComp
        
        
    }

}
