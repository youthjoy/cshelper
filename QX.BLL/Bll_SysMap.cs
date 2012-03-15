using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.Model;
using QX.DAL;
namespace QX.BLL
{
    public class Bll_SysMap
    {
        private ADOSys_Map mapInstance = new ADOSys_Map();

        public List<Sys_Map> GetMap(string module, string source)
        {
            string where = string.Format(" AND Map_Module='{0}' AND Map_Source='{1}'",module,source);
            return mapInstance.GetListByWhere(where);
        }

        public List<Sys_Map> GetMap(string module)
        {
            string where = string.Format(" AND Map_Module='{0}'", module);
            return mapInstance.GetListByWhere(where);
        }

        public bool AddOrUpdateDict(string module, List<Sys_Map> list)
        {
            bool flag = true;
            try
            {
                List<Sys_Map> oldSIList = GetMap(module);
                foreach (Sys_Map r in oldSIList)
                {
                    var temp = list.FirstOrDefault(o => o.Map_Source == r.Map_Source);
                    //如果存在则更新
                    if (temp != null)
                    {
                        //temp.CreateTime = DateTime.Now;
                        //temp.UpdateTime = DateTime.Now;
                        temp.Map_ID = r.Map_ID;
                        UpdateMap(temp);
                        list.Remove(temp);

                    }//不存在则删除
                    else
                    {
                        //r.DeleteTime = DateTime.Now;
                        DeleteMap(r);
                    }
                }

                foreach (Sys_Map detail in list)
                {
                    //如果有编码生成，则在此处完成

                    //detail.CreateTime = DateTime.Now;
                    //detail.UpdateTime = DateTime.Now;
                    //detail.PRDQ_CompNo = main.PRDC_CompNo;
                    //detail.PRDQ_CompCode = main.PRDC_CompCode;
                    //detail.PRDQ_CompName = main.PRDC_CompName;
                    detail.Map_Module = module;
                    detail.Map_Source = Guid.NewGuid().ToString();
                    AddMap(detail);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool AddMap(Sys_Map map)
        {
            if (mapInstance.Add(map) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateMap(Sys_Map map)
        {
            if (mapInstance.Update(map) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteMap(Sys_Map map)
        {
            map.Stat = 1;
            if (mapInstance.Update(map) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
