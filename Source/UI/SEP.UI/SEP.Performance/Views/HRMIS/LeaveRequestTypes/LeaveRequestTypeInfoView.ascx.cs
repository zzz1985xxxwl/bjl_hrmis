//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: LeaveRequestTypeInfoView.ascx.cs
// 创建者: 张珍
// 创建日期: 2008-10-07
// 概述: 请假类型的总界面
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.Performance.Views.HRMIS.LeaveRequestTypes
{
    public partial class LeaveRequestTypeInfoView : UserControl, ILeaveRequestTypeInfoView
    {
        public ILeaveRequestTypeListView LeaveRequestTypeListView
        {
            get { return LeaveRequestTypeListView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public ILeaveRequestTypeView LeaveRequestTypeView
        {
            get { return LeaveRequestTypeView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public bool LeaveRequestTypeViewVisible
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value)
                {
                    mpeLeaveRequestType.Show();
                }
                else
                {
                    mpeLeaveRequestType.Hide();
                }
            }
        }
    }
}