using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;
using QX.GenFramework.Utils;
using QX.Helper;
using System.Data;

namespace QX.BLL
{
    /// <summary>
    /// 成品管理
    /// </summary>
    public class Bll_Prod
    {

        private ADOProd_Components pcInstance = new ADOProd_Components();

        private ADOProd_Pool ppInstance = new ADOProd_Pool();

        private ADOProd_Doc pdInstance = new ADOProd_Doc();

        private ADOCC_File ccInstance = new ADOCC_File();

        private ADOProd_Maintain pmInstance = new ADOProd_Maintain();

        #region 成品增删改

        public bool PCInsert(Prod_Pool model)
        {
            model.CreateTime = DateTime.Now;

            model.UpdateTime = DateTime.Now;

            if (ppInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PCUpdate(Prod_Pool model)
        {

            model.UpdateTime = DateTime.Now;

            if (ppInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PCDelete(Prod_Pool model)
        {

            model.Stat = 1;

            model.DeleteTime = DateTime.Now;

            if (ppInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region 成品关联零件增删改

        public bool PCompInsert(Prod_Components model)
        {
            model.CreateTime = DateTime.Now;

            model.UpdateTime = DateTime.Now;

            if (pcInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PCompUpdate(Prod_Components model)
        {

            model.UpdateTime = DateTime.Now;

            if (pcInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PCompDelete(Prod_Components model)
        {

            model.Stat = 1;

            model.DeleteTime = DateTime.Now;

            if (pcInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region 零件关联文档增删改

        public bool PDocInsert(Prod_Doc model)
        {
            model.CreateTime = DateTime.Now;

            model.UpdateTime = DateTime.Now;

            if (pdInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PDocUpdate(Prod_Doc model)
        {

            model.UpdateTime = DateTime.Now;

            if (pdInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PDocDelete(Prod_Doc model)
        {

            model.Stat = 1;

            model.DeleteTime = DateTime.Now;

            if (pdInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        #endregion


        #region 维修


        public bool PRepairInsert(Prod_Maintain model)
        {
            model.CreateTime = DateTime.Now;

            model.UpdateTime = DateTime.Now;

            if (pmInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PRepairUpdate(Prod_Maintain model)
        {

            model.UpdateTime = DateTime.Now;

            if (pmInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PRepairDelete(Prod_Maintain model)
        {

            model.Stat = 1;

            model.DeleteTime = DateTime.Now;

            if (pmInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        


        #endregion

        public void DeleteCompByProd(Prod_Pool prod)
        { 
            string where=string.Format(" AND PRDC_ProdCode='{0}'",prod.PRP_ProdCode);

            List<Prod_Components> list = pcInstance.GetListByWhere(where);

            foreach (var c in list)
            {
                c.PRDC_ProdCode = "";

                PCompUpdate(c);

            }
        }

        /// <summary>
        /// 添加维修信息
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public int AddPRepair(Prod_Maintain pr)
        {
            pr.CreateTime = DateTime.Now;
            pr.UpdateTime = DateTime.Now;
            var re = pmInstance.Add(pr);
            return TypeConverter.ObjectToInt(pr);
        }

        /// <summary>
        /// 生成维修记录编码
        /// </summary>
        /// <returns></returns>
        public string GenereateProdRepairCode()
        {
            return new Bll_Comm().GetTableKey("", "PRepair");
        }

        /// <summary>
        /// 获取维修列表 （搜索）
        /// </summary>
        /// <returns></returns>
        public List<Prod_Maintain> GetProdMaintainList(string bDate, string eDate, string key)
        {
            string where = string.Format(" AND CreateTime between '{0}' and '{1}' AND (PRM_ProdCode like '%{2}%')",bDate,eDate,key);
            return pmInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取维修列表
        /// </summary>
        /// <returns></returns>
        public List<Prod_Maintain> GetProdMaintainList()
        {
            string where = string.Format("");
            return pmInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取维修列表
        /// </summary>
        /// <returns></returns>
        public List<Prod_Maintain> GetProdMaintainListByProdCode(string pcode)
        {
            string where = string.Format(" AND PRM_ProdCode='{0}'",pcode);
            return pmInstance.GetListByWhere(where);
        }


        /// <summary>
        /// 获取 成品列表（已入库）
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetInProdCompList()
        {
            string where = string.Format(" AND PRP_iType='{0}'", ProdStat.In);
            return ppInstance.GetListByWhere(where);
        }

        public Prod_Pool GetProdPoolModel(string code)
        {
            return ppInstance.GetListByWhere(string.Format(" AND PRP_ProdCode='{0}'", code)).FirstOrDefault();
        }

        /// <summary>
        /// 获取 成品列表（已入库）
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetInProdCompList(string bDate,string eDate,string key)
        {
            string where = string.Format(" AND PRP_iType='{0}' AND (CreateTime between '{1}' AND '{2}' OR CreateTime is null) AND (PRP_ProdCode like '%{3}%' OR PRP_Name like '%{3}%')", ProdStat.In, bDate, eDate, key);
            return ppInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取待转储的文档
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetChangeProdCompList()
        {
            string where = string.Format(" AND isnull(PRP_IsChange,0)={0}",0);
            return ppInstance.GetListByWhere(where);
        }
        /// <summary>
        /// 获取已转储列表
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetChangedProdCompList()
        {
            string where = string.Format(" AND isnull(PRP_IsChange,0)={0}", 1);
            return ppInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取待转储的文档
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetChangeProdCompList(string bDate,string eDate,string key)
        {

            string where = string.Format(" AND isnull(PRP_IsChange,0)={0} AND PRP_IDate between '{1}' and '{2}' AND PRP_iType='Out' AND (PRP_ProdCode like '%{3}%')", 0, bDate, eDate, key);
            return ppInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取已转储的文档
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetChangedProdCompList(string bDate, string eDate, string key)
        {

            string where = string.Format(" AND isnull(PRP_IsChange,0)={0} AND PRP_IDate between '{1}' and '{2}' AND (PRP_ProdCode like '%{3}%')", 1, bDate, eDate, key);
            return ppInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 设置转储状态
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool SetProdChange(Prod_Pool p)
        {
            p.PRP_IsChange = 1;
            return PCUpdate(p);
        }

        //public DataTable GetCompDocumentByProd(List<Prod_Pool> list)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var d in list)
        //    {
        //        sb.Append("'").Append(d.PRP_ProdCode).Append("',");
        //    }
        //    string ids = sb.ToString().TrimEnd(',');
            
        //}

        /// <summary>
        /// 获取所有成品
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetAllProdCompList()
        {
            string where = string.Format(" ");
            return ppInstance.GetListByWhere(where);
        }

        public List<Prod_Pool> GetAllProdCompList(string bDate,string eDate,string key)
        {
            string where = string.Format(" AND (PRP_ProdCode like '%{0}%' OR PRP_Name like '%{0}%') AND (CreateTime between '{1}' AND '{2}' OR CreateTime is null)", key, bDate, eDate);
            return ppInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取零件
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Prod_Components GetComponentsModel(string code)
        {

            string where = string.Format(" AND PRDC_CompNo='{0}'", code);
            return pcInstance.GetListByWhere(where).FirstOrDefault();
        }

        /// <summary>
        /// 获取已出库列表
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetOutProdCompList()
        {
            string where = string.Format(" AND PRP_iType='{0}'", ProdStat.Out);
            return ppInstance.GetListByWhere(where);
        }


        /// <summary>
        /// 获取已出库列表
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetOutProdCompList(string bDate,string eDate,string key)
        {
            string where = string.Format(" AND PRP_iType='{0}'  and  (isnull(PRP_ODate,'1970-1-1') between '{1}' and '{2}' OR CreateTime between '{1}' and '{2}') AND (PRP_ProdCode like '%{3}%')", ProdStat.Out,bDate,eDate,key);
            return ppInstance.GetListByWhere(where);
        }


        /// <summary>
        /// 成品出库
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public void SetProdListOut(List<Prod_Pool> list)
        {
            foreach (var r in list)
            {
                r.PRP_iType = ProdStat.Out.ToString();
                r.PRP_ODate = DateTime.Now;
                PCUpdate(r);
            }
        }

        /// <summary>
        /// 添加成品信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddProd(Prod_Pool model)
        {
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            var re = ppInstance.AddWithReturn(model);
            return TypeConverter.ObjectToInt(re);
        }

        /// <summary>
        /// 获取关联零件信息列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Prod_Components> GetPCompByProd(string code)
        {

            string where = string.Format(" AND PRDC_ProdCode='{0}'", code);
            return pcInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取零件相关的文档列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<CC_File> GetCCFileListByComp(List<Prod_Components> list)
        {
            if (list.Count == 0)
            {
                return new List<CC_File>();
            }

            StringBuilder sb = new StringBuilder();
            foreach (var c in list)
            {
                sb.Append("'").Append(c.PRDC_CompNo).Append("',");
            }

            string where = string.Format(" AND CCF_CompNo in ({0})",sb.ToString().Trim(','));

            return ccInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 生成成品编码
        /// </summary>
        /// <returns></returns>
        public string GenerateProdCode()
        {
            return new Bll_Comm().GetTableKey("", "Prod");
        }

        public string GenerateProdCompCode()
        {
            return new Bll_Comm().GetTableKey("", "PComp");
        }

        /// <summary>
        /// 添加成品关联零件信息
        /// </summary>
        /// <param name="main"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddOrUpdatePComponents(Prod_Pool main, List<Prod_Components> list)
        {

            bool flag = true;

            List<Prod_Components> oldSIList = GetPCompByProd(main.PRP_ProdCode);

            try
            {
                foreach (Prod_Components r in oldSIList)
                {
                    var temp = list.FirstOrDefault(o => o.PRDC_ID == r.PRDC_ID);
                    //如果存在则更新
                    if (temp != null)
                    {
                        temp.CreateTime = DateTime.Now;
                        temp.UpdateTime = DateTime.Now;
                        temp.PRDC_ID = r.PRDC_ID;
                        temp.PRDC_ProdCode = main.PRP_ProdCode;
                        PCompUpdate(temp);
                        list.Remove(temp);

                    }//不存在则删除
                    else
                    {
                        r.PRDC_ProdCode = "";
                        PCompUpdate(r);
                        //r.DeleteTime = DateTime.Now;
                        //PCompDelete(r);
                    }
                }

                foreach (Prod_Components detail in list)
                {
                    //如果有编码生成，则在此处完成

                    detail.CreateTime = DateTime.Now;
                    detail.UpdateTime = DateTime.Now;
                    detail.PRDC_ProdCode = main.PRP_ProdCode;
                    PCompUpdate(detail);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        

        public bool AddOrUpdateCDoc(Prod_Pool main,List<Prod_Doc> list)
        {

            bool flag = true;

            List<Prod_Doc> oldSIList = this.GetDocByProdCode(main.PRP_ProdCode);

            try
            {
                foreach (Prod_Doc r in oldSIList)
                {
                    var temp = list.FirstOrDefault(o => o.PRDQ_ID == r.PRDQ_ID);
                    //如果存在则更新
                    if (temp != null)
                    {
                        temp.CreateTime = DateTime.Now;
                        temp.UpdateTime = DateTime.Now;
                        temp.PRDQ_ID = r.PRDQ_ID;
                        PDocUpdate(temp);
                        list.Remove(temp);

                    }//不存在则删除
                    else
                    {
                        r.DeleteTime = DateTime.Now;
                        PDocDelete(r);
                    }
                }

                foreach (Prod_Doc detail in list)
                {
                    //如果有编码生成，则在此处完成

                    detail.CreateTime = DateTime.Now;
                    detail.UpdateTime = DateTime.Now;
                    detail.PRDQ_CompNo = main.PRP_ProdCode;
                    //detail.PRDQ_CompCode = main.PRDC_CompCode;
                    //detail.PRDQ_CompName = main.PRDC_CompName;
                    PDocInsert(detail);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public List<Prod_Doc> GetDocByRepair(string code)
        {
            Prod_Doc d = new Prod_Doc();

            string where = string.Format(" AND PRDQ_iType='Repair' AND  PRDQ_CompNo='{0}'", code);

            return pdInstance.GetListByWhere(where);
        }

        public bool AddOrUpdateCDoc(Prod_Maintain main, List<Prod_Doc> list)
        {

            bool flag = true;

            List<Prod_Doc> oldSIList = this.GetDocByProdCode(main.PRM_Code);

            try
            {
                foreach (Prod_Doc r in oldSIList)
                {
                    var temp = list.FirstOrDefault(o => o.PRDQ_ID == r.PRDQ_ID);
                    //如果存在则更新
                    if (temp != null)
                    {
                        temp.CreateTime = DateTime.Now;
                        temp.UpdateTime = DateTime.Now;
                        temp.PRDQ_ID = r.PRDQ_ID;
                        PDocUpdate(temp);
                        list.Remove(temp);

                    }//不存在则删除
                    else
                    {
                        r.DeleteTime = DateTime.Now;
                        PDocDelete(r);
                    }
                }

                foreach (Prod_Doc detail in list)
                {
                    //如果有编码生成，则在此处完成

                    detail.CreateTime = DateTime.Now;
                    detail.UpdateTime = DateTime.Now;
                    detail.PRDQ_CompNo = main.PRM_Code;
                    detail.PRDQ_iType="Repair";
                    //detail.PRDQ_CompCode = main.PRDC_CompCode;
                    //detail.PRDQ_CompName = main.PRDC_CompName;
                    PDocInsert(detail);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool DeleteDocument(CC_File file)
        {
            file.Stat = 1;
            if (ccInstance.Update(file) > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 成品
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Prod_Doc> GetProdDocByCompForProd(string code)
        {

            string where = string.Format(" AND PRDQ_CompNo='{0}'", code);

            return pdInstance.GetListByWhereExtend(where);
        }

        public List<Prod_Doc> GetDocByComponents(string code)
        {
            Prod_Doc d = new Prod_Doc();

            string where = string.Format(" AND  PRDQ_CompNo='{0}'", code);

            return pdInstance.GetListByWhere(where);
        }

        public List<Prod_Doc> GetDocByProdCode(string code)
        {
            Prod_Doc d = new Prod_Doc();

            string where = string.Format(" AND PRDQ_iType='Prod' AND  PRDQ_CompNo='{0}'", code);

            return pdInstance.GetListByWhereExtend(where);
        }

        /// <summary>
        /// 批量更新零件关联文档信息
        /// </summary>
        /// <param name="main"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddOrUpdatePDoc(Prod_Components main, List<Prod_Doc> list)
        {

            bool flag = true;

            List<Prod_Doc> oldSIList = GetDocByComponents(main.PRDC_CompNo);

            try
            {
                foreach (Prod_Doc r in oldSIList)
                {
                    var temp = list.FirstOrDefault(o => o.PRDQ_ID == r.PRDQ_ID);
                    //如果存在则更新
                    if (temp != null)
                    {
                        temp.CreateTime = DateTime.Now;
                        temp.UpdateTime = DateTime.Now;
                        temp.PRDQ_ID = r.PRDQ_ID;
                        PDocUpdate(temp);
                        list.Remove(temp);

                    }//不存在则删除
                    else
                    {
                        r.DeleteTime = DateTime.Now;
                        PDocDelete(r);
                    }
                }

                foreach (Prod_Doc detail in list)
                {
                    //如果有编码生成，则在此处完成

                    detail.CreateTime = DateTime.Now;
                    detail.UpdateTime = DateTime.Now;
                    detail.PRDQ_Code = GenerateDocCode();
                    detail.PRDQ_CompCode = main.PRDC_CompCode;
                    detail.PRDQ_CompName = main.PRDC_CompName;
                    detail.PRDQ_CompNo = main.PRDC_CompNo;
                    PDocInsert(detail);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 生成零件文档编号（报告编号）
        /// </summary>
        /// <returns></returns>
        public string GenerateDocCode()
        {
            return new Bll_Comm().GetTableKey("", "PDoc");
        }

        public Prod_Components GetComponentModel(string code)
        {
            return pcInstance.GetListByWhere(string.Format(" AND PRDC_CompNo='{0}'", code)).FirstOrDefault();
        }

        public Prod_Maintain GetPRMModel(string code)
        {

            return pmInstance.GetListByWhere(string.Format(" AND PRM_Code='{0}'", code)).FirstOrDefault();
        }

        #region 文档存储

        public List<CC_File> GetCCFileListByDCode(string code)
        {
            string where = string.Format(" AND CCF_DCode='{0}'", code);
            return ccInstance.GetListByWhere(where);
        }

        #endregion
    }
}
