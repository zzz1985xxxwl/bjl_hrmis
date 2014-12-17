//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: CompanyRegulationBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公司规章业务实现
// ----------------------------------------------------------------
using System.Transactions;
using SEP.IBll.CompanyRegulations;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.CompanyRegulations;

namespace SEP.Bll
{
    internal class CompanyRegulationBll : ICompanyRegulationBll
    {
        public CompanyRegulation GetCompanyRegulationsByType(ReguType type, Account loginUser)
        {
            CompanyRegulation companyRegulations = DalInstance.CompanyRegulationDalInstance.GetCompanyRegulationsByType(type);

            if (companyRegulations.AppendixList != null)
            {
                for (int i = companyRegulations.AppendixList.Count - 1; i >= 0; i--)
                {
                    if (!System.IO.File.Exists(companyRegulations.AppendixList[i].Directory))
                    {
                        DalInstance.CompanyRegulationDalInstance.DeleteCompanyReguAppendixByPKID(companyRegulations.AppendixList[i].AppendixID);
                        companyRegulations.AppendixList.RemoveAt(i);
                    }
                }
            }
            return companyRegulations;
        }

        public void SaveCompanyRegulations(CompanyRegulation companyRegulations, Account loginUser)
        {
            Validation(companyRegulations);

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    // 删除公司规章
                    if (companyRegulations.CompanyRegulationsID > 0)
                    {
                        DalInstance.CompanyRegulationDalInstance.DeleteCompanyReguAppendixByCompanyRegulationsID(companyRegulations.CompanyRegulationsID);
                        DalInstance.CompanyRegulationDalInstance.DeleteCompanyRegulationsByPKID(companyRegulations.CompanyRegulationsID);
                    }

                    // 新增公司规章
                    int companyReguID = DalInstance.CompanyRegulationDalInstance.InsertCompanyRegulations(companyRegulations);
                    if (companyRegulations.AppendixList != null)
                    {
                        foreach (CompanyReguAppendix companyReguAppendix in companyRegulations.AppendixList)
                        {
                            companyReguAppendix.CompanyReguID = companyReguID;
                            //新增公司规章附件
                            DalInstance.CompanyRegulationDalInstance.InsertCompanyReguAppendix(companyReguAppendix);
                        }
                    }
                    ts.Complete();
                }
                catch
                {
                    throw MessageKeys.AppException(MessageKeys._DbError);
                }
            }
        }

        private void Validation(CompanyRegulation companyRegulations)
        {
            // 标题不能为空
            if (string.IsNullOrEmpty(companyRegulations.Title))
            {
                throw MessageKeys.AppException(MessageKeys._CompanyRegulations_Title_Null);
            }
            if (companyRegulations.AppendixList != null)
            {
                foreach (CompanyReguAppendix companyReguAppendix in companyRegulations.AppendixList)
                {
                    // 附件名称
                    if (string.IsNullOrEmpty(companyReguAppendix.FileName))
                    {
                        throw MessageKeys.AppException(MessageKeys._CompanyReguAppendix_FileName_Null);
                    }
                    if (string.IsNullOrEmpty(companyReguAppendix.Directory))
                    {
                        throw MessageKeys.AppException(MessageKeys._CompanyReguAppendix_Directory_Null);
                    }
                }
            }
        }
    }
}
