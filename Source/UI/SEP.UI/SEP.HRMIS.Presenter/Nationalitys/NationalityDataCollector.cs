using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class NationalityDataCollector
    {
        private readonly INationalityView _ItsView;

        public NationalityDataCollector(INationalityView itsView)
        {
            _ItsView = itsView;
        }

        public void CompleteTheObject(ref Nationality theObjectToComplete)
        {
            int nationalityID = string.IsNullOrEmpty(_ItsView.NationalityID)
                                         ? 0
                                         : Convert.ToInt32(_ItsView.NationalityID);
            theObjectToComplete = new Nationality(nationalityID, _ItsView.NationalityName, _ItsView.NationalityDescription);
        }
    }
}