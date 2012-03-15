using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace QX.DataAcess
{
    public interface IDBOperator
    {
        // Methods
        void AddParameter(string ParamName, object Value);
        void BeginTransaction();
        void BeginTransaction(IsolationLevel level);
        void BeginTransaction(IDbTransaction trans);
        void ClearParameter();
        void CommitTransaction();
        int ExeCmd(string SQL);
        int ExeCmd(string SQL,IDbTransaction trans);
        bool ExistData(string SQL);
        bool ExistTable(string strTableName);
        DataSet ReturnDataSet(string SQL);
        DataSet ReturnDataSet(string SQL, int StartIndex, int PageSize, string tablename);
        IDataReader ReturnReader(string SQL);
        IDataReader ReturnReader(string SQL, int StartIndex, int PageSize, string tablename);
        DataTable ReturnDataTable(string SQL);
        object ReturnValue(string SQL);
        ArrayList ReturnValues(string SQL);
        void RollbackTransaction();
        bool RunProc(string procName);
        bool RunProc(string procName, IDbDataParameter[] prams);
        DataSet RunProcReturnDataSet(string procName);
        DataSet RunProcReturnDataSet(string procName, IDbDataParameter[] prams);
        DataTable RunProcReturnDatatable(string procName);
        DataTable RunProcReturnDatatable(string procName, IDbDataParameter[] prams);
        void SetConnection(string strConnectionString);
        void SetConnection(IDbConnection connection);
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
        void SetTransaction(IDbTransaction trans);
        Hashtable GetParameters();
    }
}
