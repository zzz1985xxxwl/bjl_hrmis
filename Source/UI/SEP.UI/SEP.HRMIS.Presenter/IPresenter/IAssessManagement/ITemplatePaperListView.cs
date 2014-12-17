//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ITemplatePaperListView.cs
// ������: ����
// ��������: 2008-06-16
// ����: ��ӿ�������ʾ����
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
   public interface ITemplatePaperListView
    {
       string Message { get;set;}
       string TemplatePaperName { get; set; }
       List<AssessTemplatePaper> AssessTemplatePapers { set; get;}
       AssessTemplatePaper SessionCopyPaper { get; set;}

       /// <summary>
       /// ������ť�¼�
       /// </summary>
       event DelegateNoParameter BtnAddEvent;
       /// <summary>
       /// ɾ����ť�¼�
       /// </summary>
       event DelegateID BtnDeleteEvent;
       /// <summary>
       ///�޸İ�ť�¼�
       /// </summary>
       event DelegateID BtnUpdateEvent;
       /// <summary>
       /// ��ѯ��ť�¼�
       /// </summary>
       event DelegateNoParameter BtnSearchEvent;

       event DelegateID BtnDetailEvent;
       event DelegateID BtnCopyEvent;

       event DelegateID ImportEvent;
    }
}
