using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using QX.Model;
using QX.DataAcess;

namespace QX.DAL
{
   [Serializable]
   public partial class ADOBse_Employee
   {
      public IDBOperator idb =  DBOperator.GetInstance();
      /// <summary>
      /// 添加Bse_Employee对象(即:一条记录)
      /// </summary>
      public int Add(Bse_Employee bse_Employee)
      {
         string sql = "INSERT INTO Bse_Employee (Emp_Code,Emp_Name,Emp_Gendar,Emp_Dept_Code,Emp_Dept_Name,Emp_TitleName,Emp_Title,Emp_DutyName,Emp_Duty,Emp_Birth,Emp_StartDate,Emp_Bak,Emp_CanLogin,Emp_LoginID,Emp_LoginPwd,Emp_Mobile,Emp_HomeTel,Emp_OffTel,Stat,Emp_Stat,Emp_Date,Emp_Order) VALUES (@Emp_Code,@Emp_Name,@Emp_Gendar,@Emp_Dept_Code,@Emp_Dept_Name,@Emp_TitleName,@Emp_Title,@Emp_DutyName,@Emp_Duty,@Emp_Birth,@Emp_StartDate,@Emp_Bak,@Emp_CanLogin,@Emp_LoginID,@Emp_LoginPwd,@Emp_Mobile,@Emp_HomeTel,@Emp_OffTel,@Stat,@Emp_Stat,@Emp_Date,@Emp_Order)";
         if (string.IsNullOrEmpty(bse_Employee.Emp_Code))
         {
            idb.AddParameter("@Emp_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Code", bse_Employee.Emp_Code);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Name))
         {
            idb.AddParameter("@Emp_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Name", bse_Employee.Emp_Name);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Gendar))
         {
            idb.AddParameter("@Emp_Gendar", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Gendar", bse_Employee.Emp_Gendar);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Dept_Code))
         {
            idb.AddParameter("@Emp_Dept_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Dept_Code", bse_Employee.Emp_Dept_Code);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Dept_Name))
         {
            idb.AddParameter("@Emp_Dept_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Dept_Name", bse_Employee.Emp_Dept_Name);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_TitleName))
         {
            idb.AddParameter("@Emp_TitleName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_TitleName", bse_Employee.Emp_TitleName);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Title))
         {
            idb.AddParameter("@Emp_Title", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Title", bse_Employee.Emp_Title);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_DutyName))
         {
            idb.AddParameter("@Emp_DutyName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_DutyName", bse_Employee.Emp_DutyName);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Duty))
         {
            idb.AddParameter("@Emp_Duty", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Duty", bse_Employee.Emp_Duty);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Birth))
         {
            idb.AddParameter("@Emp_Birth", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Birth", bse_Employee.Emp_Birth);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_StartDate))
         {
            idb.AddParameter("@Emp_StartDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_StartDate", bse_Employee.Emp_StartDate);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Bak))
         {
            idb.AddParameter("@Emp_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Bak", bse_Employee.Emp_Bak);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_CanLogin))
         {
            idb.AddParameter("@Emp_CanLogin", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_CanLogin", bse_Employee.Emp_CanLogin);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_LoginID))
         {
            idb.AddParameter("@Emp_LoginID", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_LoginID", bse_Employee.Emp_LoginID);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_LoginPwd))
         {
            idb.AddParameter("@Emp_LoginPwd", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_LoginPwd", bse_Employee.Emp_LoginPwd);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Mobile))
         {
            idb.AddParameter("@Emp_Mobile", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Mobile", bse_Employee.Emp_Mobile);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_HomeTel))
         {
            idb.AddParameter("@Emp_HomeTel", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_HomeTel", bse_Employee.Emp_HomeTel);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_OffTel))
         {
            idb.AddParameter("@Emp_OffTel", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_OffTel", bse_Employee.Emp_OffTel);
         }
         if (bse_Employee.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", bse_Employee.Stat);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Stat))
         {
            idb.AddParameter("@Emp_Stat", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Stat", bse_Employee.Emp_Stat);
         }
         if (bse_Employee.Emp_Date == DateTime.MinValue)
         {
            idb.AddParameter("@Emp_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Date", bse_Employee.Emp_Date);
         }
         if (bse_Employee.Emp_Order == 0)
         {
            idb.AddParameter("@Emp_Order", 0);
         }
         else
         {
            idb.AddParameter("@Emp_Order", bse_Employee.Emp_Order);
         }


            int Re = 0;
            //SQL日志记录
            var RunMethod = System.Reflection.MethodBase.GetCurrentMethod();
            System.Collections.Hashtable param = new System.Collections.Hashtable();
            string Ex = string.Empty;
            foreach (System.Collections.DictionaryEntry item in idb.GetParameters())
            {
                  param.Add(item.Key, item.Value);
            }

  
            try
            {
                Re = idb.ExeCmd(sql);
                Ex = Re.ToString();
            }
            catch (Exception ex)
            {
                Ex = ex.Message;
            }
            finally
            {
                SysRunLog.InsertRunSql(sql, param, RunMethod.DeclaringType +"." + RunMethod.Name,Ex);
             }            return Re;
      }
      /// <summary>
      /// 添加Bse_Employee对象(即:一条记录)
      /// </summary>
      public object AddWithReturn(Bse_Employee bse_Employee)
      {
         string sql = "INSERT INTO Bse_Employee (Emp_Code,Emp_Name,Emp_Gendar,Emp_Dept_Code,Emp_Dept_Name,Emp_TitleName,Emp_Title,Emp_DutyName,Emp_Duty,Emp_Birth,Emp_StartDate,Emp_Bak,Emp_CanLogin,Emp_LoginID,Emp_LoginPwd,Emp_Mobile,Emp_HomeTel,Emp_OffTel,Stat,Emp_Stat,Emp_Date,Emp_Order) VALUES (@Emp_Code,@Emp_Name,@Emp_Gendar,@Emp_Dept_Code,@Emp_Dept_Name,@Emp_TitleName,@Emp_Title,@Emp_DutyName,@Emp_Duty,@Emp_Birth,@Emp_StartDate,@Emp_Bak,@Emp_CanLogin,@Emp_LoginID,@Emp_LoginPwd,@Emp_Mobile,@Emp_HomeTel,@Emp_OffTel,@Stat,@Emp_Stat,@Emp_Date,@Emp_Order);SELECT @@IDENTITY AS ReturnID;";
         if (string.IsNullOrEmpty(bse_Employee.Emp_Code))
         {
            idb.AddParameter("@Emp_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Code", bse_Employee.Emp_Code);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Name))
         {
            idb.AddParameter("@Emp_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Name", bse_Employee.Emp_Name);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Gendar))
         {
            idb.AddParameter("@Emp_Gendar", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Gendar", bse_Employee.Emp_Gendar);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Dept_Code))
         {
            idb.AddParameter("@Emp_Dept_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Dept_Code", bse_Employee.Emp_Dept_Code);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Dept_Name))
         {
            idb.AddParameter("@Emp_Dept_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Dept_Name", bse_Employee.Emp_Dept_Name);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_TitleName))
         {
            idb.AddParameter("@Emp_TitleName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_TitleName", bse_Employee.Emp_TitleName);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Title))
         {
            idb.AddParameter("@Emp_Title", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Title", bse_Employee.Emp_Title);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_DutyName))
         {
            idb.AddParameter("@Emp_DutyName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_DutyName", bse_Employee.Emp_DutyName);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Duty))
         {
            idb.AddParameter("@Emp_Duty", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Duty", bse_Employee.Emp_Duty);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Birth))
         {
            idb.AddParameter("@Emp_Birth", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Birth", bse_Employee.Emp_Birth);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_StartDate))
         {
            idb.AddParameter("@Emp_StartDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_StartDate", bse_Employee.Emp_StartDate);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Bak))
         {
            idb.AddParameter("@Emp_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Bak", bse_Employee.Emp_Bak);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_CanLogin))
         {
            idb.AddParameter("@Emp_CanLogin", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_CanLogin", bse_Employee.Emp_CanLogin);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_LoginID))
         {
            idb.AddParameter("@Emp_LoginID", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_LoginID", bse_Employee.Emp_LoginID);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_LoginPwd))
         {
            idb.AddParameter("@Emp_LoginPwd", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_LoginPwd", bse_Employee.Emp_LoginPwd);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Mobile))
         {
            idb.AddParameter("@Emp_Mobile", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Mobile", bse_Employee.Emp_Mobile);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_HomeTel))
         {
            idb.AddParameter("@Emp_HomeTel", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_HomeTel", bse_Employee.Emp_HomeTel);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_OffTel))
         {
            idb.AddParameter("@Emp_OffTel", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_OffTel", bse_Employee.Emp_OffTel);
         }
         if (bse_Employee.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", bse_Employee.Stat);
         }
         if (string.IsNullOrEmpty(bse_Employee.Emp_Stat))
         {
            idb.AddParameter("@Emp_Stat", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Stat", bse_Employee.Emp_Stat);
         }
         if (bse_Employee.Emp_Date == DateTime.MinValue)
         {
            idb.AddParameter("@Emp_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Date", bse_Employee.Emp_Date);
         }
         if (bse_Employee.Emp_Order == 0)
         {
            idb.AddParameter("@Emp_Order", 0);
         }
         else
         {
            idb.AddParameter("@Emp_Order", bse_Employee.Emp_Order);
         }


            int Re = 0;
            //SQL日志记录
            var RunMethod = System.Reflection.MethodBase.GetCurrentMethod();
            System.Collections.Hashtable param = new System.Collections.Hashtable();
            string Ex = string.Empty;
            foreach (System.Collections.DictionaryEntry item in idb.GetParameters())
            {
                  param.Add(item.Key, item.Value);
            }


            object obj=null; 
            try
            {
                obj = idb.ReturnValue(sql);
                Ex = obj.ToString();
            }
            catch (Exception ex)
            {
                Ex = ex.Message;
            }
            finally
            {
                SysRunLog.InsertRunSql(sql, param, RunMethod.DeclaringType +"." + RunMethod.Name,Ex);
            }            return obj;
      }
      /// <summary>
      /// 更新Bse_Employee对象(即:一条记录
      /// </summary>
      public int Update(Bse_Employee bse_Employee)
      {
         
         StringBuilder sbParameter=new StringBuilder();
      StringBuilder sb=new StringBuilder();
      sb.Append(@"UPDATE       Bse_Employee       SET ");
            if(bse_Employee.Emp_Code_IsChanged){sbParameter.Append("Emp_Code=@Emp_Code, ");}
      if(bse_Employee.Emp_Name_IsChanged){sbParameter.Append("Emp_Name=@Emp_Name, ");}
      if(bse_Employee.Emp_Gendar_IsChanged){sbParameter.Append("Emp_Gendar=@Emp_Gendar, ");}
      if(bse_Employee.Emp_Dept_Code_IsChanged){sbParameter.Append("Emp_Dept_Code=@Emp_Dept_Code, ");}
      if(bse_Employee.Emp_Dept_Name_IsChanged){sbParameter.Append("Emp_Dept_Name=@Emp_Dept_Name, ");}
      if(bse_Employee.Emp_TitleName_IsChanged){sbParameter.Append("Emp_TitleName=@Emp_TitleName, ");}
      if(bse_Employee.Emp_Title_IsChanged){sbParameter.Append("Emp_Title=@Emp_Title, ");}
      if(bse_Employee.Emp_DutyName_IsChanged){sbParameter.Append("Emp_DutyName=@Emp_DutyName, ");}
      if(bse_Employee.Emp_Duty_IsChanged){sbParameter.Append("Emp_Duty=@Emp_Duty, ");}
      if(bse_Employee.Emp_Birth_IsChanged){sbParameter.Append("Emp_Birth=@Emp_Birth, ");}
      if(bse_Employee.Emp_StartDate_IsChanged){sbParameter.Append("Emp_StartDate=@Emp_StartDate, ");}
      if(bse_Employee.Emp_Bak_IsChanged){sbParameter.Append("Emp_Bak=@Emp_Bak, ");}
      if(bse_Employee.Emp_CanLogin_IsChanged){sbParameter.Append("Emp_CanLogin=@Emp_CanLogin, ");}
      if(bse_Employee.Emp_LoginID_IsChanged){sbParameter.Append("Emp_LoginID=@Emp_LoginID, ");}
      if(bse_Employee.Emp_LoginPwd_IsChanged){sbParameter.Append("Emp_LoginPwd=@Emp_LoginPwd, ");}
      if(bse_Employee.Emp_Mobile_IsChanged){sbParameter.Append("Emp_Mobile=@Emp_Mobile, ");}
      if(bse_Employee.Emp_HomeTel_IsChanged){sbParameter.Append("Emp_HomeTel=@Emp_HomeTel, ");}
      if(bse_Employee.Emp_OffTel_IsChanged){sbParameter.Append("Emp_OffTel=@Emp_OffTel, ");}
      if(bse_Employee.Stat_IsChanged){sbParameter.Append("Stat=@Stat, ");}
      if(bse_Employee.Emp_Stat_IsChanged){sbParameter.Append("Emp_Stat=@Emp_Stat, ");}
      if(bse_Employee.Emp_Date_IsChanged){sbParameter.Append("Emp_Date=@Emp_Date, ");}
      if(bse_Employee.Emp_Order_IsChanged){sbParameter.Append("Emp_Order=@Emp_Order ");}          sb.Append(sbParameter.ToString().Trim().TrimEnd(',')); 
      sb.Append(      " WHERE 1=1 AND ((Stat is null) or (Stat=0))   and Emp_ID=@Emp_ID; " );
      string sql=sb.ToString();
         if(bse_Employee.Emp_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Code))
         {
            idb.AddParameter("@Emp_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Code", bse_Employee.Emp_Code);
         }
          }
         if(bse_Employee.Emp_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Name))
         {
            idb.AddParameter("@Emp_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Name", bse_Employee.Emp_Name);
         }
          }
         if(bse_Employee.Emp_Gendar_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Gendar))
         {
            idb.AddParameter("@Emp_Gendar", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Gendar", bse_Employee.Emp_Gendar);
         }
          }
         if(bse_Employee.Emp_Dept_Code_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Dept_Code))
         {
            idb.AddParameter("@Emp_Dept_Code", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Dept_Code", bse_Employee.Emp_Dept_Code);
         }
          }
         if(bse_Employee.Emp_Dept_Name_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Dept_Name))
         {
            idb.AddParameter("@Emp_Dept_Name", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Dept_Name", bse_Employee.Emp_Dept_Name);
         }
          }
         if(bse_Employee.Emp_TitleName_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_TitleName))
         {
            idb.AddParameter("@Emp_TitleName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_TitleName", bse_Employee.Emp_TitleName);
         }
          }
         if(bse_Employee.Emp_Title_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Title))
         {
            idb.AddParameter("@Emp_Title", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Title", bse_Employee.Emp_Title);
         }
          }
         if(bse_Employee.Emp_DutyName_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_DutyName))
         {
            idb.AddParameter("@Emp_DutyName", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_DutyName", bse_Employee.Emp_DutyName);
         }
          }
         if(bse_Employee.Emp_Duty_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Duty))
         {
            idb.AddParameter("@Emp_Duty", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Duty", bse_Employee.Emp_Duty);
         }
          }
         if(bse_Employee.Emp_Birth_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Birth))
         {
            idb.AddParameter("@Emp_Birth", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Birth", bse_Employee.Emp_Birth);
         }
          }
         if(bse_Employee.Emp_StartDate_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_StartDate))
         {
            idb.AddParameter("@Emp_StartDate", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_StartDate", bse_Employee.Emp_StartDate);
         }
          }
         if(bse_Employee.Emp_Bak_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Bak))
         {
            idb.AddParameter("@Emp_Bak", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Bak", bse_Employee.Emp_Bak);
         }
          }
         if(bse_Employee.Emp_CanLogin_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_CanLogin))
         {
            idb.AddParameter("@Emp_CanLogin", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_CanLogin", bse_Employee.Emp_CanLogin);
         }
          }
         if(bse_Employee.Emp_LoginID_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_LoginID))
         {
            idb.AddParameter("@Emp_LoginID", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_LoginID", bse_Employee.Emp_LoginID);
         }
          }
         if(bse_Employee.Emp_LoginPwd_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_LoginPwd))
         {
            idb.AddParameter("@Emp_LoginPwd", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_LoginPwd", bse_Employee.Emp_LoginPwd);
         }
          }
         if(bse_Employee.Emp_Mobile_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Mobile))
         {
            idb.AddParameter("@Emp_Mobile", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Mobile", bse_Employee.Emp_Mobile);
         }
          }
         if(bse_Employee.Emp_HomeTel_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_HomeTel))
         {
            idb.AddParameter("@Emp_HomeTel", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_HomeTel", bse_Employee.Emp_HomeTel);
         }
          }
         if(bse_Employee.Emp_OffTel_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_OffTel))
         {
            idb.AddParameter("@Emp_OffTel", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_OffTel", bse_Employee.Emp_OffTel);
         }
          }
         if(bse_Employee.Stat_IsChanged)
         {
         if (bse_Employee.Stat == 0)
         {
            idb.AddParameter("@Stat", 0);
         }
         else
         {
            idb.AddParameter("@Stat", bse_Employee.Stat);
         }
          }
         if(bse_Employee.Emp_Stat_IsChanged)
         {
         if (string.IsNullOrEmpty(bse_Employee.Emp_Stat))
         {
            idb.AddParameter("@Emp_Stat", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Stat", bse_Employee.Emp_Stat);
         }
          }
         if(bse_Employee.Emp_Date_IsChanged)
         {
         if (bse_Employee.Emp_Date == DateTime.MinValue)
         {
            idb.AddParameter("@Emp_Date", DBNull.Value);
         }
         else
         {
            idb.AddParameter("@Emp_Date", bse_Employee.Emp_Date);
         }
          }
         if(bse_Employee.Emp_Order_IsChanged)
         {
         if (bse_Employee.Emp_Order == 0)
         {
            idb.AddParameter("@Emp_Order", 0);
         }
         else
         {
            idb.AddParameter("@Emp_Order", bse_Employee.Emp_Order);
         }
          }

         idb.AddParameter("@Emp_ID", bse_Employee.Emp_ID);


            int Re = 0;
            //SQL日志记录
            var RunMethod = System.Reflection.MethodBase.GetCurrentMethod();
            System.Collections.Hashtable param = new System.Collections.Hashtable();
            string Ex = string.Empty;
            foreach (System.Collections.DictionaryEntry item in idb.GetParameters())
            {
                  param.Add(item.Key, item.Value);
            }

 
            try
            {
                Re = idb.ExeCmd(sql);
                Ex = Re.ToString();
            }
            catch (Exception ex)
            {
                Ex = ex.Message;
            }
            finally
            {
                SysRunLog.InsertRunSql(sql, param, RunMethod.DeclaringType +"." + RunMethod.Name,Ex);
            }            return Re;
      }
      /// <summary>
      /// 删除Bse_Employee对象(即:一条记录
      /// </summary>
      public int Delete(Int64 emp_ID)
      {
         string sql = "DELETE Bse_Employee WHERE 1=1  AND Emp_ID=@Emp_ID ";
         idb.AddParameter("@Emp_ID", emp_ID);

         return idb.ExeCmd(sql);
      }
      /// <summary>
      /// 获取指定的Bse_Employee对象(即:一条记录
      /// </summary>
      public Bse_Employee GetByKey(Int64 emp_ID)
      {
         Bse_Employee bse_Employee = new Bse_Employee();
         string sql = "SELECT  Emp_ID,Emp_Code,Emp_Name,Emp_Gendar,Emp_Dept_Code,Emp_Dept_Name,Emp_TitleName,Emp_Title,Emp_DutyName,Emp_Duty,Emp_Birth,Emp_StartDate,Emp_Bak,Emp_CanLogin,Emp_LoginID,Emp_LoginPwd,Emp_Mobile,Emp_HomeTel,Emp_OffTel,Stat,Emp_Stat,Emp_Date,Emp_Order FROM Bse_Employee WHERE 1=1 AND ((Stat is null) or (Stat=0) )  AND Emp_ID=@Emp_ID ";
         idb.AddParameter("@Emp_ID", emp_ID);

          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            if (dr["Emp_ID"] != DBNull.Value) bse_Employee.Emp_ID = Convert.ToInt64(dr["Emp_ID"]);
            if (dr["Emp_Code"] != DBNull.Value) bse_Employee.Emp_Code = Convert.ToString(dr["Emp_Code"]);
            if (dr["Emp_Name"] != DBNull.Value) bse_Employee.Emp_Name = Convert.ToString(dr["Emp_Name"]);
            if (dr["Emp_Gendar"] != DBNull.Value) bse_Employee.Emp_Gendar = Convert.ToString(dr["Emp_Gendar"]);
            if (dr["Emp_Dept_Code"] != DBNull.Value) bse_Employee.Emp_Dept_Code = Convert.ToString(dr["Emp_Dept_Code"]);
            if (dr["Emp_Dept_Name"] != DBNull.Value) bse_Employee.Emp_Dept_Name = Convert.ToString(dr["Emp_Dept_Name"]);
            if (dr["Emp_TitleName"] != DBNull.Value) bse_Employee.Emp_TitleName = Convert.ToString(dr["Emp_TitleName"]);
            if (dr["Emp_Title"] != DBNull.Value) bse_Employee.Emp_Title = Convert.ToString(dr["Emp_Title"]);
            if (dr["Emp_DutyName"] != DBNull.Value) bse_Employee.Emp_DutyName = Convert.ToString(dr["Emp_DutyName"]);
            if (dr["Emp_Duty"] != DBNull.Value) bse_Employee.Emp_Duty = Convert.ToString(dr["Emp_Duty"]);
            if (dr["Emp_Birth"] != DBNull.Value) bse_Employee.Emp_Birth = Convert.ToString(dr["Emp_Birth"]);
            if (dr["Emp_StartDate"] != DBNull.Value) bse_Employee.Emp_StartDate = Convert.ToString(dr["Emp_StartDate"]);
            if (dr["Emp_Bak"] != DBNull.Value) bse_Employee.Emp_Bak = Convert.ToString(dr["Emp_Bak"]);
            if (dr["Emp_CanLogin"] != DBNull.Value) bse_Employee.Emp_CanLogin = Convert.ToString(dr["Emp_CanLogin"]);
            if (dr["Emp_LoginID"] != DBNull.Value) bse_Employee.Emp_LoginID = Convert.ToString(dr["Emp_LoginID"]);
            if (dr["Emp_LoginPwd"] != DBNull.Value) bse_Employee.Emp_LoginPwd = Convert.ToString(dr["Emp_LoginPwd"]);
            if (dr["Emp_Mobile"] != DBNull.Value) bse_Employee.Emp_Mobile = Convert.ToString(dr["Emp_Mobile"]);
            if (dr["Emp_HomeTel"] != DBNull.Value) bse_Employee.Emp_HomeTel = Convert.ToString(dr["Emp_HomeTel"]);
            if (dr["Emp_OffTel"] != DBNull.Value) bse_Employee.Emp_OffTel = Convert.ToString(dr["Emp_OffTel"]);
            if (dr["Stat"] != DBNull.Value) bse_Employee.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Emp_Stat"] != DBNull.Value) bse_Employee.Emp_Stat = Convert.ToString(dr["Emp_Stat"]);
            if (dr["Emp_Date"] != DBNull.Value) bse_Employee.Emp_Date = Convert.ToDateTime(dr["Emp_Date"]);
            if (dr["Emp_Order"] != DBNull.Value) bse_Employee.Emp_Order = Convert.ToInt32(dr["Emp_Order"]);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return bse_Employee;
      }
      /// <summary>
      /// 获取指定的Bse_Employee对象集合
      /// </summary>
      public List<Bse_Employee> GetListByWhere(string strCondition)
      {
         List<Bse_Employee> ret = new List<Bse_Employee>();
         string sql = "SELECT  Emp_ID,Emp_Code,Emp_Name,Emp_Gendar,Emp_Dept_Code,Emp_Dept_Name,Emp_TitleName,Emp_Title,Emp_DutyName,Emp_Duty,Emp_Birth,Emp_StartDate,Emp_Bak,Emp_CanLogin,Emp_LoginID,Emp_LoginPwd,Emp_Mobile,Emp_HomeTel,Emp_OffTel,Stat,Emp_Stat,Emp_Date,Emp_Order FROM Bse_Employee WHERE 1=1 AND ((Stat is null) or (Stat=0) ) ";
         if(!string.IsNullOrEmpty(strCondition))
         {
            strCondition.Replace('\'','"'); //防sql注入
            sql += strCondition ;
         }
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Bse_Employee bse_Employee = new Bse_Employee();
            if (dr["Emp_ID"] != DBNull.Value) bse_Employee.Emp_ID = Convert.ToInt64(dr["Emp_ID"]);
            if (dr["Emp_Code"] != DBNull.Value) bse_Employee.Emp_Code = Convert.ToString(dr["Emp_Code"]);
            if (dr["Emp_Name"] != DBNull.Value) bse_Employee.Emp_Name = Convert.ToString(dr["Emp_Name"]);
            if (dr["Emp_Gendar"] != DBNull.Value) bse_Employee.Emp_Gendar = Convert.ToString(dr["Emp_Gendar"]);
            if (dr["Emp_Dept_Code"] != DBNull.Value) bse_Employee.Emp_Dept_Code = Convert.ToString(dr["Emp_Dept_Code"]);
            if (dr["Emp_Dept_Name"] != DBNull.Value) bse_Employee.Emp_Dept_Name = Convert.ToString(dr["Emp_Dept_Name"]);
            if (dr["Emp_TitleName"] != DBNull.Value) bse_Employee.Emp_TitleName = Convert.ToString(dr["Emp_TitleName"]);
            if (dr["Emp_Title"] != DBNull.Value) bse_Employee.Emp_Title = Convert.ToString(dr["Emp_Title"]);
            if (dr["Emp_DutyName"] != DBNull.Value) bse_Employee.Emp_DutyName = Convert.ToString(dr["Emp_DutyName"]);
            if (dr["Emp_Duty"] != DBNull.Value) bse_Employee.Emp_Duty = Convert.ToString(dr["Emp_Duty"]);
            if (dr["Emp_Birth"] != DBNull.Value) bse_Employee.Emp_Birth = Convert.ToString(dr["Emp_Birth"]);
            if (dr["Emp_StartDate"] != DBNull.Value) bse_Employee.Emp_StartDate = Convert.ToString(dr["Emp_StartDate"]);
            if (dr["Emp_Bak"] != DBNull.Value) bse_Employee.Emp_Bak = Convert.ToString(dr["Emp_Bak"]);
            if (dr["Emp_CanLogin"] != DBNull.Value) bse_Employee.Emp_CanLogin = Convert.ToString(dr["Emp_CanLogin"]);
            if (dr["Emp_LoginID"] != DBNull.Value) bse_Employee.Emp_LoginID = Convert.ToString(dr["Emp_LoginID"]);
            if (dr["Emp_LoginPwd"] != DBNull.Value) bse_Employee.Emp_LoginPwd = Convert.ToString(dr["Emp_LoginPwd"]);
            if (dr["Emp_Mobile"] != DBNull.Value) bse_Employee.Emp_Mobile = Convert.ToString(dr["Emp_Mobile"]);
            if (dr["Emp_HomeTel"] != DBNull.Value) bse_Employee.Emp_HomeTel = Convert.ToString(dr["Emp_HomeTel"]);
            if (dr["Emp_OffTel"] != DBNull.Value) bse_Employee.Emp_OffTel = Convert.ToString(dr["Emp_OffTel"]);
            if (dr["Stat"] != DBNull.Value) bse_Employee.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Emp_Stat"] != DBNull.Value) bse_Employee.Emp_Stat = Convert.ToString(dr["Emp_Stat"]);
            if (dr["Emp_Date"] != DBNull.Value) bse_Employee.Emp_Date = Convert.ToDateTime(dr["Emp_Date"]);
            if (dr["Emp_Order"] != DBNull.Value) bse_Employee.Emp_Order = Convert.ToInt32(dr["Emp_Order"]);
            ret.Add(bse_Employee);
         }
          }catch (System.Exception ex){ throw ex; }  finally { if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   }  
         return ret;
      }
      /// <summary>
      /// 获取所有的Bse_Employee对象(即:一条记录
      /// </summary>
      public List<Bse_Employee> GetAll()
      {
         List<Bse_Employee> ret = new List<Bse_Employee>();
         string sql = "SELECT  Emp_ID,Emp_Code,Emp_Name,Emp_Gendar,Emp_Dept_Code,Emp_Dept_Name,Emp_TitleName,Emp_Title,Emp_DutyName,Emp_Duty,Emp_Birth,Emp_StartDate,Emp_Bak,Emp_CanLogin,Emp_LoginID,Emp_LoginPwd,Emp_Mobile,Emp_HomeTel,Emp_OffTel,Stat,Emp_Stat,Emp_Date,Emp_Order FROM Bse_Employee where 1=1 AND ((Stat is null) or (Stat=0) ) ";
          SqlDataReader dr=null;  
           try {  
          dr=(SqlDataReader)idb.ReturnReader(sql);
         while(dr.Read())
         {
            Bse_Employee bse_Employee = new Bse_Employee();
            if (dr["Emp_ID"] != DBNull.Value) bse_Employee.Emp_ID = Convert.ToInt64(dr["Emp_ID"]);
            if (dr["Emp_Code"] != DBNull.Value) bse_Employee.Emp_Code = Convert.ToString(dr["Emp_Code"]);
            if (dr["Emp_Name"] != DBNull.Value) bse_Employee.Emp_Name = Convert.ToString(dr["Emp_Name"]);
            if (dr["Emp_Gendar"] != DBNull.Value) bse_Employee.Emp_Gendar = Convert.ToString(dr["Emp_Gendar"]);
            if (dr["Emp_Dept_Code"] != DBNull.Value) bse_Employee.Emp_Dept_Code = Convert.ToString(dr["Emp_Dept_Code"]);
            if (dr["Emp_Dept_Name"] != DBNull.Value) bse_Employee.Emp_Dept_Name = Convert.ToString(dr["Emp_Dept_Name"]);
            if (dr["Emp_TitleName"] != DBNull.Value) bse_Employee.Emp_TitleName = Convert.ToString(dr["Emp_TitleName"]);
            if (dr["Emp_Title"] != DBNull.Value) bse_Employee.Emp_Title = Convert.ToString(dr["Emp_Title"]);
            if (dr["Emp_DutyName"] != DBNull.Value) bse_Employee.Emp_DutyName = Convert.ToString(dr["Emp_DutyName"]);
            if (dr["Emp_Duty"] != DBNull.Value) bse_Employee.Emp_Duty = Convert.ToString(dr["Emp_Duty"]);
            if (dr["Emp_Birth"] != DBNull.Value) bse_Employee.Emp_Birth = Convert.ToString(dr["Emp_Birth"]);
            if (dr["Emp_StartDate"] != DBNull.Value) bse_Employee.Emp_StartDate = Convert.ToString(dr["Emp_StartDate"]);
            if (dr["Emp_Bak"] != DBNull.Value) bse_Employee.Emp_Bak = Convert.ToString(dr["Emp_Bak"]);
            if (dr["Emp_CanLogin"] != DBNull.Value) bse_Employee.Emp_CanLogin = Convert.ToString(dr["Emp_CanLogin"]);
            if (dr["Emp_LoginID"] != DBNull.Value) bse_Employee.Emp_LoginID = Convert.ToString(dr["Emp_LoginID"]);
            if (dr["Emp_LoginPwd"] != DBNull.Value) bse_Employee.Emp_LoginPwd = Convert.ToString(dr["Emp_LoginPwd"]);
            if (dr["Emp_Mobile"] != DBNull.Value) bse_Employee.Emp_Mobile = Convert.ToString(dr["Emp_Mobile"]);
            if (dr["Emp_HomeTel"] != DBNull.Value) bse_Employee.Emp_HomeTel = Convert.ToString(dr["Emp_HomeTel"]);
            if (dr["Emp_OffTel"] != DBNull.Value) bse_Employee.Emp_OffTel = Convert.ToString(dr["Emp_OffTel"]);
            if (dr["Stat"] != DBNull.Value) bse_Employee.Stat = Convert.ToInt32(dr["Stat"]);
            if (dr["Emp_Stat"] != DBNull.Value) bse_Employee.Emp_Stat = Convert.ToString(dr["Emp_Stat"]);
            if (dr["Emp_Date"] != DBNull.Value) bse_Employee.Emp_Date = Convert.ToDateTime(dr["Emp_Date"]);
            if (dr["Emp_Order"] != DBNull.Value) bse_Employee.Emp_Order = Convert.ToInt32(dr["Emp_Order"]);
            ret.Add(bse_Employee);
         }
          }catch (System.Exception ex){ throw ex; }  finally {  if (dr != null) { dr.Close(); } if (idb.GetConnection() != null && idb.GetConnection().State == ConnectionState.Open) { idb.GetConnection().Close(); }   } 
         return ret;
      }
   }
}
