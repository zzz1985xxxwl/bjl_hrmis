//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ShowDetailViewPresenter.cs
// ������: ���h��
// ��������: 2008-08-07
// ����: 
// ----------------------------------------------------------------

using SEP.Presenter.IPresenter.ICalendar;

namespace SEP.Presenter.Calendars
{
    public class ShowDetailViewPresenter
    {
        public IShowDetailView _IShowDetailView;
        public ShowDetailViewPresenter(IShowDetailView view)
        {
            _IShowDetailView = view;
        }
        public void InitPresenter(string date, string employee,
            string location, string reason, string time, string type)
        {
            _IShowDetailView.Detail = date + " " + employee + " " + location + " " + reason + " " + time + " " + type;
        }
    }
}
