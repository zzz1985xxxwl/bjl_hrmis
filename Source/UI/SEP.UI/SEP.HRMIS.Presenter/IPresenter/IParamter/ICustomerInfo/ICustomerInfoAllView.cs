//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ICustomerInfoView.cs
// ������: ����
// ��������: 2009-08-17
// ����: �ܽ����ViewҪʵ�ֵĽӿ�
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo
{
    public interface ICustomerInfoAllView
    {
        /// <summary>
        /// �����
        /// </summary>
        ICustomerInfoListView CustomerInfoListView { get;}
        /// <summary>
        /// С����
        /// </summary>
        ICustomerInfoView CustomerInfoView { get; }

        bool ShowCustomerInfoViewVisible { set;}
    }
}
