//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PersonalInAndOutInfoView.cs
// ������:����
// ��������: 2008-10-21
// ����: PersonalInAndOutInfoView �б�
// ----------------------------------------------------------------

using System.Web.UI;

using SEP.HRMIS.Presenter;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics
{
    public partial class PersonalInAndOutInfoView : UserControl, IPersonalInAndOutInfoView
    {
        #region IPersonalInAndOutInfoView ��Ա

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