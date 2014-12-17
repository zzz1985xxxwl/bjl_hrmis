//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ITemplatePaperView.cs
// ������: ����
// ��������: 2008-06-16
// ����: ��ӿ������������޸ġ�ɾ������
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Positions;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface ITemplatePaperView
    {
        string ResultMessage { set; get;}
        string ValidatePaperName { set; get;}
        string TemplatePaperName { get; set;}
       
        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;
        /// <summary>
        /// �������
        /// </summary>
        string OperationInfo { set; get;}
        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}

        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}

        bool SetFormReadOnly { set; }

        List<Position> PositionList{ get; set;}

        List<AssessTemplateItem> AssessItemList { get; set; }

        List<AssessTemplateItem> AssessItems { set; }

        event DelegateID ddlAssessItemChangedForAddEvent;
        event Delegate2Parameter ddlAssessItemChangedForUpdateEvent;
        event DelegateID ddlAssessItemChangedForDeleteEvent;
        event DelegateID ddlAssessItemChangedForAddAtEvent;
        event DelegateID ddlAssessItemChangedForUpEvent;
        event DelegateID ddlAssessItemChangedForDownEvent;
        event DelegateNoParameter btnCopyEvent;
        event DelegateNoParameter btnPasteEvent;

        AssessTemplatePaper SessionCopyPaper { get; set;}

        bool SetbtnPasteVisible { set; }
    }
}
