//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ISkillTypeView.cs
// ������: ����
// ��������: 2008-11-06
// ����: ��������С������ͼ
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
   public interface ISkillTypeView
    {
        string Message { set;}
        string NameMsg { set;}

        string SkillTypeID { get; set; }
        string SkillTypeName { get; set;}
       

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
