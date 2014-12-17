//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ISkillSearchView.cs
// ������: ZZ
// ��������: 2008-11-07
// ����: ���ܴ����Ҫʵ�ֽӿ�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface ISkillSearchView
    {
        string SkillName { get; }

        string Message { set; get;}
        string ErrorMessage { set; get;}

        List<Skill> Skills { set; get;}
        List<SkillType> SkillTypeList { set;}

        int SelectedSkillTypeID { get; }
        
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

        
    }
}
