using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DataAcess;
using System.Data;

namespace QX.GenFramework.DAO
{
    public class CommHelper
    {
        public IDBOperator idb = DBOperator.GetInstance();

        public DataTable ListViewData(string sql)
        {
            return idb.ReturnDataTable(sql);
        }
    }
}
