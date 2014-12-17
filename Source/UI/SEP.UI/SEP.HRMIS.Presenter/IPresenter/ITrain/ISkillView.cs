//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: SkillPresenter.cs
// ������: ZZ
// ��������: 2008-11-07
// ����: ����С����Ҫʵ�ֽӿ�
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface ISkillView
    {
        string Message { set; get;}
        string SkillNameMsg { set; get;}

        string SkillID { get; set; }
        string SkillName { get; set;}
        string SkillType { get; set;}
        string SkillTypeMsg { get; set;}
        List<SkillType> SkillTypes { get; set;}
        //string SelectedType { get; set;}
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
        string OperationTitle { set; get;}
        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}

        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}
       
    }
}
