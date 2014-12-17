//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ISkillTypeView.cs
// ������: ����
// ��������: 2008-11-12
// ����: ����������������С������ͼ
// ----------------------------------------------------------------
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType
{
    public interface IFBQuesTypeView
    {
        string ResultMessage { get;set;}
        string Title { get; set;}

        string FBQuesTypeName { get; set;}
        string NameMessage { get;set;}

        string FBQuesTypeID { get; set;}

        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}

        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}

        bool SetIDReadonly { set;}

        bool SetNameReadonly { set;}

    }
}
