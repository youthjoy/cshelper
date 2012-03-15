using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;
using QX.GenFramework;

namespace QX.BLL
{
    /// <summary>
    /// 质量文档管理
    /// </summary>
    public class Bll_Doc
    {
        private ADODoc_Directory ddInstance = new ADODoc_Directory();

        private Bll_Prod ppInstance = new Bll_Prod();

        private ADOProd_Components pcInstance = new ADOProd_Components();

        private ADOCC_File fileInstance = new ADOCC_File();


        #region CCFile

        public bool CCFileInsert(CC_File model)
        {
            model.CreateTime = DateTime.Now;

            model.UpdateTime = DateTime.Now;

            if (fileInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool CCFileUpdate(CC_File model)
        {

            model.UpdateTime = DateTime.Now;

            if (fileInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool CCFileDelete(CC_File model)
        {

            model.Stat = 1;

            model.DeleteTime = DateTime.Now;

            if (fileInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        #endregion 

        public bool AddCCFile(CC_File model)
        {
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            return CCFileInsert(model);
        }

        public bool UpdateCCFile(CC_File model)
        {
            //model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;
            return CCFileUpdate(model);
        }

        public string GenerateCCFileCode()
        {
            return new Bll_Comm().GenerateCode("CC_File");
        }

        public List<CC_File> GetFileList(string code)
        {
            string where = string.Format(" AND CCF_DCode='{0}'",code);
            return fileInstance.GetListByWhere(where);
        }


        public List<Doc_Directory> GetDirectoryList()
        {
            string where = string.Format("");
            List<Doc_Directory> list = ddInstance.GetListByWhere(where);

            return list;
            
        }


        /// <summary>
        /// 获取成品列表
        /// </summary>
        /// <returns></returns>
        public List<Prod_Pool> GetProdList()
        {
          return ppInstance.GetAllProdCompList(); 
        }


        /// <summary>
        /// 获取零件列表
        /// </summary>
        /// <returns></returns>
        public List<Prod_Components> GetCompList()
        {
            string where = string.Format(" AND isnull(PRDC_ProdCode,'')=''");

            List<Prod_Components> list = pcInstance.GetListByWhere(where);

            return list;

        }


        public List<Prod_Components> GetProdRefCompList()
        {
            string where = string.Format(" AND PRDC_ProdCode is not NULL");

            List<Prod_Components> list = pcInstance.GetListByWhere(where);

            return list;

        }
    }
}
