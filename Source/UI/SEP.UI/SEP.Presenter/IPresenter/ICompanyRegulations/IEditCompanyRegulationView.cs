//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IEditCompanyRegulationsView.cs
// ������: SYY
// ��������: 2009-01-04
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.CompanyRegulations;

namespace SEP.Presenter.IPresenter.ICompanyRegulations
{
    public interface IEditCompanyRegulationView
    {
        /// <summary>
        /// ����PKID
        /// </summary>
        int ComanyReguId { get; set;}

        /// <summary>
        /// ����
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// ��˾�����ƶ���������Դ
        /// </summary>
        List<KeyValuePair<int, string>> ReguTypeDataSrc { get; set;}

        /// <summary>
        /// ѡ��Ĺ�˾�����ƶ�����
        /// </summary>
        int SelectedReguType { get; set;}

        /// <summary>
        /// ����
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// �����б�
        /// </summary>
        List<CompanyReguAppendix> CompanyReguAppendixList { get; set; }

        /// <summary>
        /// ѡ��ĸ���PKID
        /// </summary>
        int SelectedCompanyReguAppendixId { get; }


        /// <summary>
        /// ���ⱨ����Ϣ
        /// </summary>
        string CompanyRegulationsTitleErrorMessage { get;set; }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        string ErrorMessageFromCompanyRegulations { get;set;}

        /// <summary>
        /// ������Ϣ
        /// </summary>
        string CompanyReguAppendixListErrorMessage { get;set; }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        event EventHandler InitView;

        /// <summary>
        /// ��������
        /// </summary>
        event EventHandler ChangedType;

        /// <summary>
        /// ����
        /// </summary>
        event EventHandler btnOKClicked;

        /// <summary>
        /// ��������
        /// </summary>
        event EventHandler AddAppendix;

        /// <summary>
        /// ɾ������
        /// </summary>
        event EventHandler DeleteAppendix;

    }
}
