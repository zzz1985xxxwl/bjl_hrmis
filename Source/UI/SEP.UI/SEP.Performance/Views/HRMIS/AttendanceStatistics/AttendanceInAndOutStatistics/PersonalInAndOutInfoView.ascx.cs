//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutInfoView.cs
// 创建者:刘丹
// 创建日期: 2008-10-21
// 概述: PersonalInAndOutInfoView 列表
// ----------------------------------------------------------------

using System.Web.UI;

using SEP.HRMIS.Presenter;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics
{
    public partial class PersonalInAndOutInfoView : UserControl, IPersonalInAndOutInfoView
    {
        #region IPersonalInAndOutInfoView 成员

        public IPersonalInAndOutListView InAndOutListView
        {
            get { return PersonalInAndOutListView1; }
        }

        public IPersonalInAndOutView InAndOutView
        {
            get { return PersonalInAndOutView1; }
        }

        public bool InAndOutViewVisible
        {
            set
            {
                if (value)
                {
                    mpeInAndOut.Show();
                }
                else
                {
                    mpeInAndOut.Hide();
                }
            }
        }

        #endregion
    }
}