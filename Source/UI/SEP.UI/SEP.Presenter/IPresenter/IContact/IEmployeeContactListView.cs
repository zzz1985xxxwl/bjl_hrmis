//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IEmployeeContactListView.cs
// ������: Emma
// ��������: 2008-12-02
// ����: ��ѯԱ��ͨѶ¼����
// ----------------------------------------------------------------

using System.Web.UI.WebControls;
using ComService.ServiceModels;

namespace SEP.Presenter.IPresenter.IContact
{
    public interface IEmployeeContactListView
    {
        //Guid LinkManID { set;get;}
        Contact LinkManNameSource { get; set;}
        string LblCurrent { get; set;}
        event CommandEventHandler BtnUpdateEvent;
        event CommandEventHandler BtnDeleteEvent;
    }
}