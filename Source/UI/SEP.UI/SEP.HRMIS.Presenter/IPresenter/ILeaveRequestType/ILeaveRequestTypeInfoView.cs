//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ILeaveRequestTypeInfoView.cs
// ������: ����
// ��������: 2008-10-07
// ����: ������͵��ܽ����ViewҪʵ�ֵĽӿ�
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType
{
  public interface ILeaveRequestTypeInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
      ILeaveRequestTypeListView LeaveRequestTypeListView { get;set;}
        /// <summary>
        /// С����
        /// </summary>
      ILeaveRequestTypeView LeaveRequestTypeView { get;set;}
        /// <summary>
        /// С����ɼ�
        /// </summary>
      bool LeaveRequestTypeViewVisible { get;set;}
    }
}
