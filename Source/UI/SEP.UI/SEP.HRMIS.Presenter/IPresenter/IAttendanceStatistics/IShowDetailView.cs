//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IShowDetailView.cs
// ������: ���h��
// ��������: 2008-08-27
// ����: �ӿ�
// ----------------------------------------------------------------
namespace SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics
{
    public interface IShowDetailView
    {
        string Employee { get;set;}
        string Type { get;set;}
        string Time { get;set;}
        string Date { get;set;}
        string Location { get;set;}
        string Reason { get;set;}
   }
}
