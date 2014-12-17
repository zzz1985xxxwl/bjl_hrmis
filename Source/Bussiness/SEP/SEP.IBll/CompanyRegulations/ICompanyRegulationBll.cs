//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: ICompanyRegulationBll.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ��˾����ҵ��ӿ�
// ----------------------------------------------------------------
using SEP.Model.Accounts;
using SEP.Model.CompanyRegulations;

namespace SEP.IBll.CompanyRegulations
{
    /// <summary>
    /// ��˾����ҵ��ӿ�
    /// </summary>
    public interface ICompanyRegulationBll
    {
        CompanyRegulation GetCompanyRegulationsByType(ReguType type, Account loginUser);

        void SaveCompanyRegulations(CompanyRegulation obj, Account loginUser);
    }
}

