//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ITemplateItemListView.cs
// ������: ����
// ��������: 2008-06-16
// ����: ��������ʾ�ӿ�
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface ITemplateItemListView
    {
        OperateType OperateType { get;}
        string Question { get;}

        string Message { set;}
       
        List<AssessTemplateItem> TemplateItems { get; set;}

        Dictionary<string, string> ItemClassficationSource { set;}
        string ItemClassfication { get;}

        string DelMessage{ set;}

        AssessTemplateItemType SelectedAssessTemplateItemType{ get;}
    }
}
