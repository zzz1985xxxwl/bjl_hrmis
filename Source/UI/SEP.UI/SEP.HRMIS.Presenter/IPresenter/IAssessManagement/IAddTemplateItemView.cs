//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IAddTemplateItemView.cs
// ������: ����
// ��������: 2008-06-05
// ����: ��ӿ��������
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IAddTemplateItemView
    {
        string Message { set;}
        string QestionNullMessage { set;}
        string Question { get; set;}
        int AssessTemplateItemType { get; set;}
        OperateType ItemOperateType { get; set;}
        Dictionary<string, string> ClassficationSource {set;}
        string ClassficationId { get; set;}
        string Option5 { get; set;}
        string Option4 { get; set;}
        string Option3 { get; set;}
        string Option2 { get; set;}
        string Option1 { get; set;}
        string ItemMessage5 { set;}
        string ItemMessage4 { set;}
        string ItemMessage3 { set;}
        string ItemMessage2 { set;}
        string ItemMessage1 { set;}
        string Description { get; set;}
        string PageTitle { set;}
        bool ReadOnly { set;}

        #region ���

        string MaxRange { get; set;}
        string MinRange { get; set;}
        string RangeError{ set;}

        #endregion

        #region ��ʽ

        string Formula { get; set;}
        string FormulaError{ set;}

        #endregion


    }
}
