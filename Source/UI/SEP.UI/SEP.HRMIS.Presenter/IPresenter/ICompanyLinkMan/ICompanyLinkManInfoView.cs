//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ICompanyLinkManInfoView.cs
// ������: liudan
// ��������: 2009-06-30
// ����: ��ϵ�˽����ܽӿ�
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan
{
    public interface ICompanyLinkManInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        ICompanyLinkListView LinkManListView { get;set;}
        /// <summary>
        /// С����
        /// </summary>
        ICompnayLinkManView LinkManView { get;set;}
        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool LinkManViewVisible { get;set;}
    }
}