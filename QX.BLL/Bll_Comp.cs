using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;
using QX.GenFramework.Utils;
using QX.Shared;

namespace QX.BLL
{
    /// <summary>
    /// 零件管理
    /// </summary>
    public class Bll_Comp
    {
        public ADOTpl_Components tcInstance = new ADOTpl_Components();

        public ADOTpl_ReqDoc trInstance = new ADOTpl_ReqDoc();

        public ADOProd_Doc docInstance = new ADOProd_Doc();

        public ADOProd_Components pcInstance = new ADOProd_Components();

        public ADOCC_File fileInstance = new ADOCC_File();

        #region 零件模板管理增删改

        public bool CompInsert(Tpl_Components model)
        {
            model.CreateTime = DateTime.Now;

            model.UpdateTime = DateTime.Now;

            if (tcInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool CompUpdate(Tpl_Components model)
        {

            model.UpdateTime = DateTime.Now;

            if (tcInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool CompDelete(Tpl_Components model)
        {

            model.Stat = 1;

            model.DeleteTime = DateTime.Now;

            if (tcInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region 零件管理增删改

        public bool CompInsert(Prod_Components model)
        {
            model.CreateTime = DateTime.Now;

            model.UpdateTime = DateTime.Now;

            if (pcInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool CompUpdate(Prod_Components model)
        {

            model.UpdateTime = DateTime.Now;

            if (pcInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool CompDelete(Prod_Components model)
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

        /// <summary>
        /// 零件添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddComp(Prod_Components model)
        {
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            var re = pcInstance.AddWithReturn(model);
            return TypeConverter.ObjectToInt(re);
        }

        public bool InsertComp(Prod_Components model)
        {
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            var re = pcInstance.Add(model);
            if (re > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 零件图号添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddComp(Tpl_Components model)
        {
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            var re = tcInstance.AddWithReturn(model);
            return TypeConverter.ObjectToInt(re);
        }
        /// <summary>
        /// 零件图号编号生成
        /// </summary>
        /// <returns></returns>
        public string GenerateCompCode()
        {
            return new Bll_Comm().GetTableKey("", "Comp");
        }
        /// <summary>
        /// 零件编号生成
        /// </summary>
        /// <returns></returns>
        public string GeneratePCompCode()
        {
            return new Bll_Comm().GetTableKey("", "PComp");
        }

        public void DeleteDocByComp(Prod_Components comp)
        {
            var list = GetPDocByComp(comp.PRDC_CompNo);
            foreach (var d in list)
            {
                PDocDelete(d);
            }
        }

        /// <summary>
        /// 零件图号模板文档编号生成
        /// </summary>
        /// <returns></returns>
        public string GenerateDocCode()
        {
            return new Bll_Comm().GetTableKey("", "ReqDoc");
        }

        /// <summary>
        /// 零件图号模板更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateComp(Tpl_Components model)
        {
            return CompUpdate(model);
        }

        /// <summary>
        /// 零件成品更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateComp(Prod_Components model)
        {
            return CompUpdate(model);
        }

        /// <summary>
        /// 获取所有图号模板
        /// </summary>
        /// <returns></returns>
        public List<Tpl_Components> GetComponentsList()
        {
            string where = string.Format("");
            return tcInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取所有图号模板
        /// </summary>
        /// <returns></returns>
        public List<Tpl_Components> GetComponentsList(string bDate, string eDate, string key)
        {
            string where = string.Format(" AND isnull(CreateTime,'1970-1-1') between '{0}' AND '{1}' AND (TPLC_Name like '%{2}%' OR TPLC_Code like '%{2}%') ", bDate, eDate, key);
            return tcInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 根据零件编号获取与其相关的零件文档
        /// </summary>
        /// <param name="compCode"></param>
        /// <returns></returns>
        public List<CC_File> GetCCFileListByComp(string compCode)
        {
            string where = string.Format(" AND PRDQ_CompNo='{0}'", compCode);
            return fileInstance.GetListByWhereExtend(where);
        }

        /// <summary>
        /// 文档删除
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool DeleteDocument(CC_File file)
        {
            file.Stat = 1;
            if (fileInstance.Update(file) > 0)
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 获取所有零件列表（常规）
        /// </summary>
        /// <returns></returns>
        public List<Prod_Components> GetPComponentsList()
        {
            string where = string.Format(" AND PRDC_iType='{0}' ", "Comp");
            return pcInstance.GetListByWhere(where);
        }



        /// <summary>
        /// 获取零件列表（常规）搜索
        /// </summary>
        /// <returns></returns>
        public List<Prod_Components> GetPComponentsList(string bDate, string eDate, string key)
        {
            string where = string.Format(" AND PRDC_CompNo is not NULL AND PRDC_iType='{0}' AND (CreateTime between '{1}' AND '{2}' OR CreateTime is null) AND (PRDC_CompName like '%{3}%' OR PRDC_CompCode like '%{3}%' OR PRDC_CompNo like '%{3}%' OR PRDC_Tec3 like '%{3}%' OR PRDC_Tec4 like '%{3}%')  Order by PRDC_ID", "Comp", bDate, eDate, key);
            return pcInstance.GetListByWhere(where);
        }

        public List<Prod_Components> GetPComponentsListForPatch(string bDate, string eDate, string key)
        {
            string where = string.Format(" AND isnull(PRDC_ProdCode,'')='' AND PRDC_CompNo is not NULL AND PRDC_iType='{0}' AND CreateTime between '{1}' AND '{2}' AND (PRDC_CompName like '%{3}%' OR PRDC_CompCode like '%{3}%' OR PRDC_CompNo like '%{3}%')  Order by PRDC_ID", "Comp", bDate, eDate, key);
            return pcInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 零件列表获取（其他）
        /// </summary>
        /// <param name="bDate"></param>
        /// <param name="eDate"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<Prod_Components> GetOtherComponentsList(string bDate, string eDate, string key)
        {
            string where = string.Format(" AND PRDC_iType='{0}' AND PRDC_RecDate between '{1}' AND '{2}' AND (PRDC_CompName like '%{3}%' OR PRDC_CompCode like '%{3}%' OR PRDC_CompNo like '%{3}%') ", "OtherComp", bDate, eDate, key);
            return pcInstance.GetListByWhere(where);
        }

        public List<Prod_Components> GetOtherComponentsList()
        {
            string where = string.Format(" AND PRDC_iType='{0}'", "OtherComp");
            return pcInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 图号模板相关文档更新
        /// </summary>
        /// <param name="main"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddOrUpdateCDoc(Tpl_Components main, List<Tpl_ReqDoc> list)
        {

            bool flag = true;

            List<Tpl_ReqDoc> oldSIList = GetReqDocByComp(main.TPLC_Code);

            try
            {
                foreach (Tpl_ReqDoc r in oldSIList)
                {
                    var temp = list.FirstOrDefault(o => o.TPRD_ID == r.TPRD_ID);
                    //如果存在则更新
                    if (temp != null)
                    {
                        temp.CreateTime = DateTime.Now;
                        temp.UpdateTime = DateTime.Now;
                        temp.TPRD_ID = r.TPRD_ID;
                        ReqDocUpdate(temp);
                        list.Remove(temp);

                    }//不存在则删除
                    else
                    {
                        r.DeleteTime = DateTime.Now;
                        ReqDocDelete(r);
                    }
                }

                foreach (Tpl_ReqDoc detail in list)
                {
                    //如果有编码生成，则在此处完成

                    detail.CreateTime = DateTime.Now;
                    detail.UpdateTime = DateTime.Now;
                    detail.TPRD_Code = GenerateDocCode();
                    detail.TPRD_CompCode = main.TPLC_Code;
                    ReqDocInsert(detail);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public Dictionary<string, List<Prod_Components>> GetCompDocByRefDoc(List<Prod_Doc> docList, string compno)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var d in docList)
            {
                sb.Append("'" + d.PRDQ_Code + "'").Append(",");
            }
            string code = sb.ToString().TrimEnd(',');
            string where = string.Format(" AND PRDQ_Code in ({0}) AND PRDQ_CompNo!='{1}'", code, compno);
            List<Prod_Doc> list = docInstance.GetListByWhere(where);
            Dictionary<string, List<Prod_Components>> dic = new Dictionary<string, List<Prod_Components>>();
            foreach (var l in list.Select(o => o.PRDQ_Code).Distinct())
            {
                if (!dic.Keys.Contains(l))
                {
                    List<Prod_Doc> dlist = list.Where(o => o.PRDQ_Code == l).ToList();
                    if (dlist != null)
                    {
                        List<Prod_Components> tempList = new List<Prod_Components>();
                        foreach (var dd in dlist)
                        {
                            Prod_Components p = new Prod_Components();
                            p.PRDC_CompNo = dd.PRDQ_CompNo;
                            tempList.Add(p);
                        }
                        dic.Add(l, tempList);
                    }
                    else
                    {
                        dic.Add(l, new List<Prod_Components>());
                    }
                }
            }

            return dic;
        }

        /// <summary>
        /// 零件关联文档
        /// </summary>
        /// <param name="main"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool AddOrUpdateCDoc(Prod_Components main, List<Prod_Doc> list)
        {

            bool flag = true;

            List<Prod_Doc> oldSIList = GetPDocByComp(main.PRDC_CompNo);

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
                    detail.PRDQ_CompNo = main.PRDC_CompNo;
                    detail.PRDQ_CompCode = main.PRDC_CompCode;
                    detail.PRDQ_CompName = main.PRDC_CompName;
                    PDocInsert(detail);
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public Prod_Components GetCompModel(string code)
        {
            return pcInstance.GetListByWhere(string.Format(" AND PRDC_CompNo='{0}'",code)).FirstOrDefault();
        }

        public bool AddOrUpdateCDocForRef(Prod_Doc doc, List<Prod_Components> list)
        {

            bool flag = true;

            foreach (var c in list)
            {
                List<Prod_Doc> oldSIList = GetPDocByComp(c.PRDC_CompNo);
                //如果该零件原文档列表存在该文档则更新
                if (oldSIList.FirstOrDefault(o => o.PRDQ_Code == doc.PRDQ_Code) == null)
                {
                    Prod_Doc d = new Prod_Doc();
                    d.PRDQ_Plant = doc.PRDQ_Plant;
                    d.PRDQ_Code = doc.PRDQ_Code;
                    d.PRDQ_Name = doc.PRDQ_Name;
                    d.PRDQ_IsScan = doc.PRDQ_IsScan;
                    d.PRDQ_Type = doc.PRDQ_Type;
                    d.PRDQ_iType = doc.PRDQ_iType;
                    d.CreateTime = DateTime.Now;
                    d.UpdateTime = DateTime.Now;
                    d.PRDQ_CompNo = c.PRDC_CompNo;
                    d.PRDQ_CompCode = c.PRDC_CompCode;
                    d.PRDQ_CompName = c.PRDC_CompName;
                   
                    
                    if (oldSIList.FirstOrDefault(o => o.PRDQ_Type == doc.PRDQ_Type) != null)
                    {
                        var templist = oldSIList.Where(o => o.PRDQ_Type == doc.PRDQ_Type && string.IsNullOrEmpty(o.PRDQ_Code));
                        foreach (var dc in templist)
                        {
                            PDocDelete(dc);
                        }
                    }

                    PDocInsert(d);
                }
                else
                {
                    var temp = oldSIList.FirstOrDefault(o => o.PRDQ_Code == doc.PRDQ_Code);
                    var temp1 = new Prod_Doc();
                    temp1.PRDQ_Plant = doc.PRDQ_Plant;
                    temp1.PRDQ_Type = doc.PRDQ_Type;
                    temp1.PRDQ_ID = temp.PRDQ_ID;
                    temp1.PRDQ_iType = doc.PRDQ_iType;
                    temp1.PRDQ_IsScan = doc.PRDQ_IsScan;
                    temp1.PRDQ_CompNo = c.PRDC_CompNo;
                    PDocUpdate(temp1);
                }
            }

            return flag;

        }

        /// <summary>
        /// 添加多零件文档关联
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="list"></param>
        /// <param name="oldComponents"></param>
        /// <returns></returns>
        public bool AddOrUpdateCDocForRef(Prod_Doc doc, List<Prod_Components> list, List<Prod_Components> oldComponents)
        {
            bool flag = true;
            ///原零件与现关联零件比较 
            foreach (var d in oldComponents)
            {
                var temp = list.FirstOrDefault(o => o.PRDC_CompNo == d.PRDC_CompNo);
                //如果不存在则表示已删除
                if (temp == null)
                {
                    List<Prod_Doc> oldSIList = GetPDocByComp(d.PRDC_CompNo);
                    var temp1 = oldSIList.FirstOrDefault(o => o.PRDQ_Code == doc.PRDQ_Code);
                    PDocDelete(temp1);
                }
            }

            foreach (var c in list)
            {
                List<Prod_Doc> oldSIList = GetPDocByComp(c.PRDC_CompNo);

                if (oldSIList.FirstOrDefault(o => o.PRDQ_Code == doc.PRDQ_Code) == null)
                {
                    Prod_Doc d = new Prod_Doc();
                    d.PRDQ_Plant = doc.PRDQ_Plant;
                    d.PRDQ_Code = doc.PRDQ_Code;
                    d.PRDQ_Type = doc.PRDQ_Type;
                    d.PRDQ_iType = doc.PRDQ_iType;
                    d.PRDQ_IsScan = 1;
                    d.CreateTime = DateTime.Now;
                    d.UpdateTime = DateTime.Now;
                    d.PRDQ_CompNo = c.PRDC_CompNo;
                    d.PRDQ_CompCode = c.PRDC_CompCode;
                    d.PRDQ_CompName = c.PRDC_CompName;
                    d.PRDQ_Name = doc.PRDQ_Name;
                    //如果零件原文档列表已存在该文档类型的数据则进行更新操作,否则插入
                    if (oldSIList.FirstOrDefault(o => o.PRDQ_Type == doc.PRDQ_Type) != null)
                    {
                        var templist = oldSIList.Where(o => o.PRDQ_Type == doc.PRDQ_Type && string.IsNullOrEmpty(o.PRDQ_Code));
                        foreach (var dc in templist)
                        {
                            PDocDelete(dc);
                        }
                    }

                    PDocInsert(d);

                }
                else
                {
                    var temp = oldSIList.FirstOrDefault(o => o.PRDQ_Code == doc.PRDQ_Code);
                    var temp1 = new Prod_Doc();
                    temp1.PRDQ_Plant = doc.PRDQ_Plant;
                    temp1.PRDQ_Type = doc.PRDQ_Type;
                    temp1.PRDQ_ID = temp.PRDQ_ID;
                    temp1.PRDQ_iType = temp.PRDQ_iType;
                    temp1.PRDQ_CompNo = c.PRDC_CompNo;
                    PDocUpdate(temp1);
                }
            }

            return flag;

        }


        public bool DeleteDoc(Prod_Doc doc, Prod_Components model)
        {
            List<Prod_Doc> oldSIList = GetPDocByComp(model.PRDC_CompNo);
            var temp = oldSIList.FirstOrDefault(o => o.PRDQ_Code == doc.PRDQ_Code);
            return PDocDelete(temp);

        }


        /// <summary>
        /// 根据图号获取相关文档模板
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Tpl_ReqDoc> GetReqDocByComp(string code)
        {

            string where = string.Format(" AND TPRD_CompCode='{0}'", code);

            return trInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取零件关联文档
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Prod_Doc> GetPDocByComp(string code)
        {

            string where = string.Format(" AND PRDQ_CompNo='{0}'", code);

            return docInstance.GetListByWhere(where);
        }
        /// <summary>
        /// 获取某一文档编号数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Prod_Doc> GetPDocBySelf(string code)
        {

            string where = string.Format(" AND PRDQ_Code='{0}'", code);

            return docInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 获取零件关联文档
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Prod_Doc> GetProdDocByComp(string code)
        {

            string where = string.Format(" AND PRDQ_CompNo='{0}'", code);

            return docInstance.GetListByWhereExtend(where);
        }

        /// <summary>
        /// 成品
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Prod_Doc> GetProdDocByCompForProd(string code)
        {

            string where = string.Format(" AND PRDQ_CompNo='{0}'", code);

            return docInstance.GetListByWhereExtend(where);
        }


        #region 零件文档增删改


        public bool ReqDocInsert(Tpl_ReqDoc model)
        {
            model.CreateTime = DateTime.Now;

            model.UpdateTime = DateTime.Now;

            if (trInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool ReqDocUpdate(Tpl_ReqDoc model)
        {

            model.UpdateTime = DateTime.Now;

            if (trInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool ReqDocDelete(Tpl_ReqDoc model)
        {

            model.Stat = 1;

            model.DeleteTime = DateTime.Now;

            if (trInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        #endregion


        #region 零件文档增删改


        public bool PDocInsert(Prod_Doc model)
        {
            model.CreateTime = DateTime.Now;

            model.UpdateTime = DateTime.Now;

            if (docInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PDocUpdate(Prod_Doc model)
        {

            model.UpdateTime = DateTime.Now;

            if (docInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool PDocDelete(Prod_Doc model)
        {

            model.Stat = 1;

            model.DeleteTime = DateTime.Now;

            if (docInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
