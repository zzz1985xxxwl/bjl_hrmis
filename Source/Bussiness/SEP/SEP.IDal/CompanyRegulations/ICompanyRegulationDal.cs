//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: ICompanyRegulationDal.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ��˾���³־ò�ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.CompanyRegulations;

namespace SEP.IDal.CompanyRegulations
{
    /// <summary>
    /// ��˾���³־ò�ӿ�
    /// </summary>
    public interface ICompanyRegulationDal
    {
        /// <summary>
        /// ������˾�����ƶ�
        /// </summary>
        /// <returns>PKID</returns>
        int InsertCompanyRegulations(CompanyRegulation obj);

        /// <summary>
        /// ͨ����˾�����ƶ�IDɾ����˾�����ƶ�
        /// </summary>
        void DeleteCompanyRegulationsByPKID(int pkId);

        /// <summary>
        /// ���빫˾�����ƶȸ���
        /// </summary>
        int InsertCompanyReguAppendix(CompanyReguAppendix obj);

        /// <summary>
        /// ͨ����˾�����ƶȸ���IDɾ����˾�����ƶȸ���
        /// </summary>
        void DeleteCompanyReguAppendixByPKID(int pkId);

        /// <summary>
        /// ͨ����˾�����ƶ�IDɾ����˾�����ƶȸ���
        /// </summary>
        void DeleteCompanyReguAppendixByCompanyRegulationsID(int companyRegulationsID);

        /// <summary>
        /// ͨ����˾�����ƶ�ID���ҹ�˾�����ƶȸ���
        /// </summary>
        List<CompanyReguAppendix> GetCompanyReguAppendixByCompanyRegulationsID(int companyRegulationsID);

        /// <summary>
        /// ͨ����˾�����ƶ����Ͳ��ҹ�˾�����ƶ�
        /// </summary>
        CompanyRegulation GetCompanyRegulationsByType(ReguType type);
    }
}