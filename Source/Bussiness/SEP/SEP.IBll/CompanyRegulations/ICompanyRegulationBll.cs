//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: ICompanyRegulationBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公司规章业务接口
// ----------------------------------------------------------------
using SEP.Model.Accounts;
using SEP.Model.CompanyRegulations;

namespace SEP.IBll.CompanyRegulations
{
    /// <summary>
    /// 公司规章业务接口
    /// </summary>
    public interface ICompanyRegulationBll
    {
        CompanyRegulation GetCompanyRegulationsByType(ReguType type, Account loginUser);

        void SaveCompanyRegulations(CompanyRegulation obj, Account loginUser);
    }
}

