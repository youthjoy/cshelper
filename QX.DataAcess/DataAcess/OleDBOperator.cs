using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Data;

namespace QX.DataAcess
{
    public class OleDBOperator : IDBOperator
{
    // Fields
    private OleDbCommand cmd;
    private OleDbConnection connection;
    private string connectionString;
    private Hashtable listParameters;
    private OleDbTransaction transaction;

    // Methods
    public OleDBOperator()
    {
        this.connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        this.connection = new OleDbConnection(this.connectionString);
    }

    public OleDBOperator(string connectionString)
    {
        this.connectionString = connectionString;
        this.connection = new OleDbConnection(connectionString);
    }

    public void AddParameter(string ParamName, object Value)
    {
        try
        {
            if (this.listParameters == null)
            {
                this.listParameters = new Hashtable();
            }
            this.listParameters.Add(ParamName, Value);
        }
        catch (Exception e)
        {
            throw new Exception("添加OleDbParameter出错:  " + e.Message);
        }
    }

    public void BeginTransaction()
    {
        this.Open();
        this.cmd = this.connection.CreateCommand();
        this.transaction = this.connection.BeginTransaction();
        this.cmd.Transaction = this.transaction;
    }

    public void ClearParameter()
    {
        this.listParameters = null;
    }

    public void Close()
    {
        if (this.connection.State.ToString() == "Open")
        {
            this.connection.Close();
            this.InitMember();
        }
    }

    public void CommitTransaction()
    {
        try
        {
            if (this.transaction != null)
            {
                this.transaction.Commit();
            }
        }
        catch (Exception ex)
        {
            this.transaction.Rollback();
            throw new Exception(ex.Message);
        }
        finally
        {
            this.transaction = null;
            this.Close();
        }
    }

    public OleDbCommand CreateCmd(string SQL)
    {
        return this.SetCmd(SQL, CommandType.Text);
    }

    public OleDbCommand CreateProcCmd(string procName)
    {
        return this.SetCmd(procName, CommandType.StoredProcedure);
    }

    public OleDbCommand CreateProcCmd(string procName, IDbDataParameter[] prams)
    {
        this.cmd = this.SetCmd(procName, CommandType.StoredProcedure);
        if (prams != null)
        {
            foreach (OleDbParameter parameter in prams)
            {
                this.cmd.Parameters.Add(parameter);
            }
        }
        return this.cmd;
    }

    public void Dispose()
    {
        if (this.connection != null)
        {
            this.connection.Close();
            this.connection.Dispose();
        }
        GC.Collect();
    }

    public int ExeCmd(string SQL)
    {
        int ret = -1;
        try
        {
            ret = this.CreateCmd(SQL).ExecuteNonQuery();
        }
        catch (Exception ee)
        {
            throw new Exception(SQL + ee.ToString());
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return ret;
    }

    public bool ExistData(string SQL)
    {
        bool ret = false;
        try
        {
            OleDbDataReader dr = this.ReturnDataReader(SQL);
            if (dr.HasRows)
            {
                ret = true;
            }
            dr.Close();
        }
        catch (Exception Ex)
        {
            throw new Exception(SQL + Ex.ToString());
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return ret;
    }

    public bool ExistTable(string strTableName)
    {
        bool ret = false;
        try
        {
            string sql = "select   name   from   sysobjects where name = '" + strTableName + "'";
            ret = this.ExistData(sql);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return ret;
    }

    private OleDbDataAdapter GetDataAdapter(string SQL)
    {
        OleDbDataAdapter Da = new OleDbDataAdapter();
        this.cmd = this.SetCmd(SQL, CommandType.Text);
        Da.SelectCommand = this.cmd;
        new OleDbCommandBuilder(Da);
        return Da;
    }

    private void InitMember()
    {
        this.listParameters = null;
        this.cmd = null;
    }

    public OleDbParameter MakeInParam(string ParamName, object Value)
    {
        return this.MakeParam(ParamName, ParameterDirection.Input, Value);
    }

    public OleDbParameter MakeInParam(string ParamName, OleDbType dbType, object Value)
    {
        return this.MakeParam(ParamName, dbType, ParameterDirection.Input, Value);
    }

    public OleDbParameter MakeInParam(string ParamName, OleDbType dbType, int Size, object Value)
    {
        return this.MakeParam(ParamName, dbType, Size, ParameterDirection.Input, Value);
    }

    public OleDbParameter MakeOutParam(string ParamName, OleDbType dbType)
    {
        return this.MakeParam(ParamName, dbType, ParameterDirection.Output);
    }

    public OleDbParameter MakeOutParam(string ParamName, OleDbType dbType, int Size)
    {
        return this.MakeParam(ParamName, dbType, Size, ParameterDirection.Output, null);
    }

    public OleDbParameter MakeParam(string ParamName, OleDbType dbType, ParameterDirection Direction)
    {
        OleDbParameter param = new OleDbParameter(ParamName, dbType);
        param.Direction = Direction;
        return param;
    }

    public OleDbParameter MakeParam(string ParamName, ParameterDirection Direction, object Value)
    {
        OleDbParameter param = new OleDbParameter(ParamName, Value);
        param.Direction = Direction;
        return param;
    }

    public OleDbParameter MakeParam(string ParamName, OleDbType dbType, ParameterDirection Direction, object Value)
    {
        OleDbParameter param = new OleDbParameter(ParamName, dbType);
        param.Direction = Direction;
        if ((Direction != ParameterDirection.Output) || (Value != null))
        {
            param.Value = Value;
        }
        return param;
    }

    public OleDbParameter MakeParam(string ParamName, OleDbType dbType, int Size, ParameterDirection Direction, object Value)
    {
        OleDbParameter param;
        if (Size > 0)
        {
            param = new OleDbParameter(ParamName, dbType, Size);
        }
        else
        {
            param = new OleDbParameter(ParamName, dbType);
        }
        param.Direction = Direction;
        if ((Direction != ParameterDirection.Output) || (Value != null))
        {
            param.Value = Value;
        }
        return param;
    }

    public void Open()
    {
        if (this.connection.State == ConnectionState.Closed)
        {
            this.connection.Open();
        }
    }

    public OleDbDataReader ReturnDataReader(string SQL)
    {
        return this.CreateCmd(SQL).ExecuteReader();
    }

    public DataSet ReturnDataSet(string SQL)
    {
        DataSet Ds = new DataSet();
        try
        {
            this.GetDataAdapter(SQL).Fill(Ds);
        }
        catch (Exception Err)
        {
            throw new Exception(SQL + Err.ToString());
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return Ds;
    }

    public DataSet ReturnDataSet(string SQL, string tablename)
    {
        DataSet Ds = new DataSet();
        try
        {
            this.GetDataAdapter(SQL).Fill(Ds, tablename);
        }
        catch (Exception Err)
        {
            throw new Exception(SQL + Err.ToString());
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return Ds;
    }

    public DataSet ReturnDataSet(string SQL, int StartIndex, int PageSize, string tablename)
    {
        DataSet Ds = new DataSet();
        try
        {
            this.GetDataAdapter(SQL).Fill(Ds, StartIndex, PageSize, tablename);
        }
        catch (Exception Err)
        {
            throw new Exception(SQL + Err.ToString());
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return Ds;
    }

    public DataTable ReturnDataTable(string SQL)
    {
        DataTable dt = new DataTable();
        try
        {
            this.GetDataAdapter(SQL).Fill(dt);
        }
        catch (Exception Err)
        {
            throw new Exception(SQL + Err.ToString());
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return dt;
    }

    public object ReturnValue(string SQL)
    {
        object result = "";
        try
        {
            result = this.CreateCmd(SQL).ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            throw new Exception(SQL + ex.Message);
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return result;
    }

    public string ReturnValue(string SQL, int ColumnI)
    {
        string result = string.Empty;
        OleDbDataReader dr = null;
        try
        {
            dr = this.ReturnDataReader(SQL);
            if (dr.Read())
            {
                return dr[ColumnI].ToString();
            }
            result = "";
        }
        catch (Exception ex)
        {
            throw new Exception(SQL + ex.Message);
        }
        finally
        {
            dr.Close();
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return result;
    }

    public string ReturnValue(string SQL, string Filed)
    {
        string ret = "";
        OleDbDataReader dr = null;
        try
        {
            dr = this.ReturnDataReader(SQL);
            if (dr.Read())
            {
                ret = dr[Filed].ToString();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(SQL + ex.Message);
        }
        finally
        {
            dr.Close();
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return ret;
    }

    public ArrayList ReturnValues(string SQL)
    {
        ArrayList ret = new ArrayList();
        OleDbDataReader dr = null;
        try
        {
            dr = this.ReturnDataReader(SQL);
            while (dr.Read())
            {
                ret.Add(dr[0]);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(SQL + ex.Message);
        }
        finally
        {
            dr.Close();
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return ret;
    }

    public ArrayList ReturnValues(string SQL, string Filed)
    {
        ArrayList ret = new ArrayList();
        OleDbDataReader dr = null;
        try
        {
            dr = this.ReturnDataReader(SQL);
            while (dr.Read())
            {
                ret.Add(dr[Filed]);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(SQL + ex.Message);
        }
        finally
        {
            dr.Close();
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return ret;
    }

    public void RollbackTransaction()
    {
        if (this.transaction != null)
        {
            this.transaction.Rollback();
        }
    }

    public bool RunProc(string procName)
    {
        bool ret = false;
        try
        {
            this.Open();
            if (this.CreateProcCmd(procName).ExecuteNonQuery() > 0)
            {
                ret = true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(procName + ex.Message);
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return ret;
    }

    public bool RunProc(string procName, IDbDataParameter[] prams)
    {
        bool ret = false;
        this.Open();
        try
        {
            if (this.CreateProcCmd(procName, prams).ExecuteNonQuery() > 0)
            {
                ret = true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(procName + ex.Message);
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return ret;
    }

    public DataSet RunProcReturnDataSet(string procName)
    {
        DataSet Ds = new DataSet();
        try
        {
            new OleDbDataAdapter(this.CreateProcCmd(procName)).Fill(Ds);
        }
        catch (Exception Ex)
        {
            throw new Exception(procName + Ex.Message);
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return Ds;
    }

    public DataSet RunProcReturnDataSet(string procName, IDbDataParameter[] prams)
    {
        DataSet Ds = new DataSet();
        try
        {
            new OleDbDataAdapter(this.CreateProcCmd(procName, prams)).Fill(Ds);
        }
        catch (Exception Ex)
        {
            throw new Exception(procName + Ex.Message);
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return Ds;
    }

    public DataTable RunProcReturnDatatable(string procName)
    {
        DataTable Ds = new DataTable();
        try
        {
            new OleDbDataAdapter(this.CreateProcCmd(procName)).Fill(Ds);
        }
        catch (Exception Ex)
        {
            throw new Exception(procName + Ex.Message);
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return Ds;
    }

    public DataTable RunProcReturnDatatable(string procName, IDbDataParameter[] prams)
    {
        DataTable Ds = new DataTable();
        try
        {
            new OleDbDataAdapter(this.CreateProcCmd(procName, prams)).Fill(Ds);
        }
        catch (Exception Ex)
        {
            throw new Exception(procName + Ex.Message);
        }
        finally
        {
            if (this.transaction == null)
            {
                this.Close();
            }
        }
        return Ds;
    }

    public OleDbCommand SetCmd(string SQL, CommandType cmdType)
    {
        try
        {
            this.Open();
            if (this.cmd == null)
            {
                this.cmd = new OleDbCommand(SQL, this.connection);
            }
            this.cmd.CommandType = cmdType;
            this.cmd.CommandText = SQL;
            if (this.listParameters != null)
            {
                foreach (DictionaryEntry parameter in this.listParameters)
                {
                    this.cmd.Parameters.Add(new OleDbParameter(parameter.Key.ToString(), parameter.Value));
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return this.cmd;
    }

    public void SetConnection(string strConnectionString)
    {
        this.connectionString = strConnectionString;
        this.connection = new OleDbConnection(this.connectionString);
    }

    #region IDBOperator 成员


    public IDataReader ReturnReader(string SQL)
    {
        throw new NotImplementedException();
    }

    public IDataReader ReturnReader(string SQL, int StartIndex, int PageSize, string tablename)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IDBOperator 成员


    public int ExeCmd(string SQL, IDbTransaction trans)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IDBOperator 成员


    public IDbConnection GetConnection()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IDBOperator 成员


    public void SetConnection(IDbConnection connection)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IDBOperator 成员


    public IDbTransaction GetTransaction()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IDBOperator 成员


    public void SetTransaction(IDbTransaction trans)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IDBOperator 成员


    public void BeginTransaction(IsolationLevel level)
    {
        throw new NotImplementedException();
    }

    public void BeginTransaction(IDbTransaction trans)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IDBOperator 成员


    public Hashtable GetParameters()
    {
        throw new NotImplementedException();
    }

    #endregion
}


}
