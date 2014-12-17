using System.Collections.Generic;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.SpecialDates;
using SEP.Presenter.IPresenter.ISpecialDate;

namespace SEP.Presenter.SpecialDates
{
    public class SepcialDateAddPresenter
    {
        public ISpecialDateView _ItsView;
        public Account _Account;

        public SepcialDateAddPresenter(ISpecialDateView itsView, Account account)
        {
            _ItsView = itsView;
            _Account = account;
        }

        public void InitView(bool IsPostBack, string currentDay)
        {
            _ItsView.CurrentDay = currentDay;
            if (!IsPostBack)
            {
                List<SpecialDate> specialDateList = BllInstance.SpecialDateBllInstance.GetAllSpecialDate(_Account);
                if (specialDateList.Count > 0)
                {
                    _ItsView.SpecialDates = specialDateList;
                }
            }
        }
    }
}
