//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IAddDimissionInfoView.cs
// ������: ���޾�
// ��������: 2008-09-04
// ����: AddDimissionInfoView��Ҫʵ�ֵĽӿ�
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface IAddDimissionInfoView
    {
        /// <summary>
        /// ��ְ����
        /// </summary>
        string DimissionDate { get; set;}

        /// <summary>
        /// ���ò�����׼
        /// </summary>
        string DimissionMonth { get; set;}

        string DimissionMonthMessage{ get; set;}

        /// <summary>
        /// ��ְ����
        /// </summary>
        string DimissionType{ get; set;}

        /// <summary>
        /// ��ְԭ��
        /// </summary>
        //DimissionReasonType DimissionReasonTypes{ get; set;}
        int DimissionReasonTypeId { get; set;}

        /// <summary>
        /// ����ԭ��
        /// </summary>
        string DimissionOtherReason { get; set;}
        //����󶨵���ʾԴ
        List<FileCargo> FileCargoes { get; set;}

        event CommandEventHandler btnDeleteClick;

        event CommandEventHandler btnUpdateClick;
        
        bool SetButtonStatus{ set;}

    }
}
