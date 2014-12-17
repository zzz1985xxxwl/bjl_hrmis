//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IPositionGradeView.cs
// ������: �����
// ��������: 2008-11-04
// ����: ְλ�㼶��ͼ����
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.Model.Positions;

namespace SEP.Presenter.IPresenter.IPositions
{
    public interface IPositionGradeView
    {
        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        string Message { set; get;}

        string OperationTitle { get; set; }

        bool SetFormReadOnly { set;}

        List<PositionGrade> PositionGradeListSrc { get; set; }
        List<int> DelPositionGradeId { get; set;}

        event DelegateID ddlCardPropertyParaParaChangedForDeleteEvent;
        event DelegateID ddlCardPropertyParaParaChangedForAddAtEvent;
        event DelegateID ddlCardPropertyParaParaChangedForUpEvent;
        event DelegateID ddlCardPropertyParaParaChangedForDownEvent;

        event DlgLinkButtonAndId InitEvent;
    }

    public delegate void DlgLinkButtonAndId(LinkButton linkButton, int id);
}
