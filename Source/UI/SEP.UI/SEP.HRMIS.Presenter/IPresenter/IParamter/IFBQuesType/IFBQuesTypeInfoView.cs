//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IFBQuesTypeInfoView.cs
// ������: ����
// ��������: 2008-11-12
// ����: �����������͵��ܽ����ViewҪʵ�ֵĽӿ�
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType
{
    public interface IFBQuesTypeInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        IFBQuesTypeListView FBQuesTypeListView { get; set;}
        /// <summary>
        /// С����
        /// </summary>
        IFBQuesTypeView FBQuesTypeView { get; set;}

        bool FBQuesTypeViewVisible { get;set;}
    }
}
