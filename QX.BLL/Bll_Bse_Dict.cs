using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;
using QX.GenFramework;
using System.Data;
using System.Data.SqlClient;
using QX.GenFramework.Utils;

namespace QX.BLL
{
    public partial class Bll_Bse_Dict
    {
        private ADOBse_Dict instance = new ADOBse_Dict();

        public string CreateDictNode(string parentCode, ref int order)
        {
            //throw new NotImplementedException();
            var dict = GetModelByCode(parentCode);
            order = 0;
            var newCode = GenerateDictCode(dict.Dict_Key);
            return newCode;

        }

        /// <summary>
        /// 是否允许多层级
        /// </summary>
        /// <param name="dictKey"></param>
        /// <returns></returns>
        public bool IsAllowLevel(string dictKey)
        {
            var model = GetModelByCode(dictKey);
            if (model.Dict_Level == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Bse_Dict GetModelByCode(string code)
        {
            string where=string.Format(" AND Dict_Code='{0}'", code);
            return instance.GetListByWhere(where).FirstOrDefault();
        }

        /// <summary>
        /// 根据关键字生成字典编码
        /// </summary>
        /// <param name="key"></param>
        /// <param name="order">该字典顺序号</param>
        /// <returns></returns>
        public string GenerateDictCode(string key)
        {
            return new BLL.Bll_Comm().GenerateCode(key);

            //Dictionary<string, int> dic = new Dictionary<string, int>();
            //int maxNum = TypeConverter.ObjectToInt(instance.GetMax("Dict_ID", key)) + 1;

            //DataTable dt = instance.GenerateCode(key);

            //string code = string.Empty;

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    //code = string.Format("{0}{1}", dt.Rows[0][0], maxNum);
            //    code = dt.Rows[0][0].ToString();
            //}
            //else
            //{
            //    code = string.Format("{0}{1}", key, maxNum);
            //}
            //order = maxNum;
            //return code;

            //return "";c
        }

        public bool IsExsistDictKey(string key)
        {
            string where = string.Format(" AND Dict_Key='{0}'",key);
            List<Bse_Dict> list = instance.GetListByWhere(where);
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据字典关键字获取其相关字典数据(不包含根节点)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<Bse_Dict> GetDictByKey(string key)
        {
            string sql = string.Format(" AND Dict_Key='{0}' AND Dict_Code!='{0}' order by dict_order", key);
            return instance.GetListByWhere(sql);
        }


        public List<Bse_Dict> GetDictListByKeyCode(string key)
        {
            string sql = string.Format(" AND Dict_Key='{0}'", key);
            return instance.GetListByWhere(sql);
        }

        public bool DeleteDict(Bse_Dict item)
        {
            bool flag = false;
            item.Stat = 1;
            if (instance.Update(item) > 0)
            {
                flag = true;
            }

            return flag;
        }

        public bool UpdateDict(Bse_Dict item)
        {
            bool flag = false;
            if (instance.Update(item) > 0)
            {
                flag = true;
            }

            return flag;
        }

        public bool AddDict(Bse_Dict item)
        {
            bool flag = false;
            if (instance.Add(item) > 0)
            {
                flag = true;
            }

            return flag;
        }

        public bool AddOrUpdateDict(string key,List<Bse_Dict> list)
        {
            List<Bse_Dict> oldlist = GetDictByKey(key);

            foreach (Bse_Dict item in oldlist)
            {
                var temp = list.FirstOrDefault(o => o.Dict_Code == item.Dict_Code);
                if (temp != null)
                {
                    temp.Dict_ID = item.Dict_ID;

                    UpdateDict(temp);

                    list.Remove(temp);

                }
                else
                {
                    DeleteDict(item);
                }
            }

            foreach (var it in list)
            {
                Bse_Dict bs = new Bse_Dict();
                bs = it;
                int order = 0;

                bs.Dict_Key = key;

                bs.Dict_Code = GenerateDictCode(key);

                bs.Dict_Order = order;
                bs.Dict_PCode = key;

                AddDict(bs);
            }

            return true;

        }

    }
}
