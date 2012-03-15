using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.GenFramework.Model;
using System.Data;
using System.Data.SqlClient;
namespace QX.GenFramework.ADO
{
    public partial class ADOSys_PD_Filed
    {
        public DataTable GetRefData(string sql)
        {
            return idb.ReturnDataTable(sql);
        }
        public DataTable GetProcData(string proc, string key)
        {
            SqlParameter x1 = new SqlParameter("@dictKey", SqlDbType.NChar, 40);
            x1.Value = key.Trim();
            SqlParameter[] param = new SqlParameter[] { x1 };
            return idb.RunProcReturnDatatable(proc, param);
        }
    }
}
