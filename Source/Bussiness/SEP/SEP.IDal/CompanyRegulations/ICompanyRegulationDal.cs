//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: ICompanyRegulationDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公司规章持久层接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.CompanyRegulations;

namespace SEP.IDal.CompanyRegulations
{
    /// <summary>
    /// 公司规章持久层接口
    /// </summary>
    public interface ICompanyRegulationDal
    {
        /// <summary>
        /// 新增公司规章制度
        /// </summary>
        /// <returns>PKID</returns>
        int InsertCompanyRegulations(CompanyRegulation obj);

        /// <summary>
        /// 通过公司规章制度ID删除公司规章制度
        /// </summary>
        void DeleteCompanyRegulationsByPKID(int pkId);

        /// <summary>
        /// 插入公司规章制度附件
        /// </summary>
        int InsertCompanyReguAppendix(CompanyReguAppendix obj);

        /// <summary>
        /// 通过公司规章制度附件ID删除公司规章制度附件
        /// </summary>
        void DeleteCompanyReguAppendixByPKID(int pkId);

        /// <summary>
        /// 通过公司规章制度ID删除公司规章制度附件
        /// </summary>
        void DeleteCompanyReguAppendixByCompanyRegulationsID(int companyRegulationsID);

        /// <summary>
        /// 通过公司规章制度ID查找公司规章制度附件
        /// </summary>
        List<CompanyReguAppendix> GetCompanyReguAppendixByCompanyRegulationsID(int companyRegulationsID);

        /// <summary>
        /// 通过公司规章制度类型查找公司规章制度
        /// </summary>
        CompanyRegulation GetCompanyRegulationsByType(ReguType type);
    }
}