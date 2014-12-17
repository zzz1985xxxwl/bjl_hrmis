//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InAndOutLogList.cs
// 创建者:刘丹
// 创建日期: 2008-10-23
// 概述: InAndOutLogList 列表
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class InAndOutLogList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //todo colbert 2
            //PowerUser.UserHasPower(PowerUser._InAndOutRecordLog);

            new InAndOutLogListPresenter(InAndOutLogListView1, LoginUser).Initialize(IsPostBack);
        }
    }
}
