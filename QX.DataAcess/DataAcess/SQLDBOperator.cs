using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace QX.DataAcess
{
    public class SQLDBOperator : IDBOperator
    {
        // Fields
        private SqlCommand cmd;
        private SqlConnection connection;
        private string connectionString;
        private Hashtable listParameters;
        private SqlTransaction transaction;

    // Methods
    public SQLDBOperator()
    {
        this.connectionString = ConfigurationSettings.AppSettings["ConnectionString"];
        this.connection = new SqlConnection(this.connectionString);   
    }

    public SQLDBOperator(string connectionString)
    {
        this.connectionString = connectionString;
        this.connection = new SqlConnection(connectionString);
    }

    public void AddParameter(string ParamName, object Value)
    {
        try
        {
            if (this.listParameters == null)
            {
                this.listParameters = new Hashtable();
            }
            if (listParameters.ContainsKey(ParamName))
            {
                listParameters.Remove(ParamName);
                this.listParameters.Add(ParamName, Value);
            }
            else
            {
                this.listParameters.Add(ParamName, Value);
            }            
        }
        catch (Exception e)
        {
            throw new Exception("添加SqlParameter出错:  " + e.Message);
        }
    }

    public void BeginTransaction()
    {
        this.Open();
        this.cmd = this.connection.CreateCommand();
        this.transaction = this.connection.BeginTransaction();
        this.cmd.Transaction = this.transaction;
    }

    public void BeginTransaction(IsolationLevel level)
    {
        this.Open();
        this.cmd = this.connection.CreateCommand();
        this.transaction = this.connection.BeginTransaction(level);
        this.cmd.Transaction = this.transaction;
    }
    public void BeginTransaction(IDbTransaction trans)
    {
        this.Open();
        this.cmd = this.connection.CreateCommand();
        this.transaction = (SqlTransaction)trans;
        this.cmd.Transaction = this.transaction;
    }

    public void ClearParameter()
    {
        this.listParameters.Clear();
    }

    public void Close()
    {
        if (this.connection.State== ConnectionState.Open)
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
            this.Close();
            this.transaction = null;
            
        }
    }

    public SqlCommand CreateCmd(string SQL)
    {
        return this.SetCmd(SQL, CommandType.Text);
    }

    public SqlCommand CreateProcCmd(string procName)
    {
        return this.SetCmd(procName, CommandType.StoredProcedure);
    }

    public SqlCommand CreateProcCmd(string procName, IDbDataParameter[] prams)
    {
        this.cmd = this.SetCmd(procName, CommandType.StoredProcedure);
        if (prams != null)
        {
            cmd.Parameters.Clear();
            foreach (SqlParameter parameter in prams)
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
            SqlDataReader dr = this.ReturnDataReader(SQL);
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

    private SqlDataAdapter GetDataAdapter(string SQL)
    {
        SqlDataAdapter Da = new SqlDataAdapter();
        this.cmd = this.SetCmd(SQL, CommandType.Text);
        Da.SelectCommand = this.cmd;
        new SqlCommandBuilder(Da);
        return Da;
    }

    private void InitMember()
    {
        if (listParameters!=null && listParameters.Count>0)
        {
            this.listParameters.Clear();
            this.listParameters = null;
        }        
        this.cmd = null;
    }

    public SqlParameter MakeInParam(string ParamName, object Value)
    {
        return this.MakeParam(ParamName, ParameterDirection.Input, Value);
    }

    public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, object Value)
    {
        return this.MakeParam(ParamName, DbType, ParameterDirection.Input, Value);
    }

    public SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
    {
        return this.MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
    }

    public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType)
    {
        return this.MakeParam(ParamName, DbType, ParameterDirection.Output);
    }

    public SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
    {
        return this.MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
    }

    public SqlParameter MakeParam(string ParamName, ParameterDirection Direction, object Value)
    {
        SqlParameter param = new SqlParameter(ParamName, Value);
        param.Direction = Direction;
        return param;
    }

    public SqlParameter MakeParam(string ParamName, SqlDbType DbType, ParameterDirection Direction)
    {
        SqlParameter param = new SqlParameter(ParamName, DbType);
        param.Direction = Direction;
        return param;
    }

    public SqlParameter MakeParam(string ParamName, SqlDbType DbType, ParameterDirection Direction, object Value)
    {
        SqlParameter param = new SqlParameter(ParamName, DbType);
        param.Direction = Direction;
        if ((Direction != ParameterDirection.Output) || (Value != null))
        {
            param.Value = Value;
        }
        return param;
    }

    public SqlParameter MakeParam(string ParamName, SqlDbType DbType, int Size, ParameterDirection Direction, object Value)
    {
        SqlParameter param;
        if (Size > 0)
        {
            param = new SqlParameter(ParamName, DbType, Size);
        }
        else
        {
            param = new SqlParameter(ParamName, DbType);
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

    public SqlDataReader ReturnDataReader(string SQL)
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
        object result = null;
        try
        {
            result = this.CreateCmd(SQL).ExecuteScalar();
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
        SqlDataReader dr = null;
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
        SqlDataReader dr = null;
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
        SqlDataReader dr = null;
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
        SqlDataReader dr = null;
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
            new SqlDataAdapter(this.CreateProcCmd(procName)).Fill(Ds);
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
            new SqlDataAdapter(this.CreateProcCmd(procName, prams)).Fill(Ds);
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
            new SqlDataAdapter(this.CreateProcCmd(procName)).Fill(Ds);
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
            new SqlDataAdapter(this.CreateProcCmd(procName, prams)).Fill(Ds);
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

    public SqlCommand SetCmd(string SQL, CommandType cmdType)
    {
        try
        {
            this.Open();
            if (this.cmd == null)
            {
                this.cmd = new SqlCommand(SQL, this.connection);
            }
            this.cmd.CommandType = cmdType;
            this.cmd.CommandText = SQL;
            if (this.listParameters != null)
            {
                cmd.Parameters.Clear();
                foreach (DictionaryEntry parameter in this.listParameters)
                {
                    this.cmd.Parameters.Add(new SqlParameter(parameter.Key.ToString(), parameter.Value));
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
        this.connection = new SqlConnection(this.connectionString);       
    }
    #region IDBOperator 成员


    public IDataReader ReturnReader(string SQL)
    {
        return this.CreateCmd(SQL).ExecuteReader();
    }

    public IDataReader ReturnReader(string SQL, int StartIndex, int PageSize, string tablename)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region IDBOperator 成员


    public int ExeCmd(string SQL, IDbTransaction trans)
    {
        int ret = -1;
        try
        {
            this.transaction =(SqlTransaction)trans;
            ret = this.CreateCmd(SQL).ExecuteNonQuery();
            this.CommitTransaction();
        }
        catch (Exception ee)
        {
            this.RollbackTransaction();
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

    #endregion

    #region IDBOperator 成员


    IDbConnection IDBOperator.GetConnection()
    {
        return this.connection;
    }

    #endregion

    #region IDBOperator 成员


    public void SetConnection(IDbConnection connection)
    {
        this.connection = (SqlConnection)connection;
    }

    #endregion

    #region IDBOperator 成员


    public IDbTransaction GetTransaction()
    {
        return (SqlTransaction)this.transaction;
    }

    #endregion

    #region IDBOperator 成员


    public void SetTransaction(IDbTransaction trans)
    {
        this.cmd.Transaction =(SqlTransaction)trans;
    }

    #endregion

    #region IDBOperator 成员


    public Hashtable GetParameters()
    {
        return listParameters;
    }

    #endregion
    }


}
