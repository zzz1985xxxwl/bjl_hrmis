using System;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.SpecialDates;
using SEP.Presenter.IPresenter.ISpecialDate;

namespace SEP.Presenter.SpecialDates
{
    public class EditSpecialDatePresenter
    {
        private readonly ISpecialDateEditView _ItsView;
        public SpecialDate _specialDate;
        public Account _Account;

        public EditSpecialDatePresenter(ISpecialDateEditView itsView, Account LoginUser)
        {
            _ItsView = itsView;
            _Account = LoginUser;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void InitView(string specialDateID, string specialDate,
             string specialDateBackColor, string specialDescription, string specialForeColor,
             string specialHeader, int isWork)
        {
            new SpecialDataInit(_ItsView).InitSpecialDate(specialDateID, specialDate, specialDateBackColor, specialDescription, specialForeColor,
                                         specialHeader, isWork);
        }

        public void AddEvent(string SpecialDate)
        {

            if (!new SepcialDataValidate(_ItsView).Vaildate())
            {
                return;
            }
            _specialDate = new SpecialDate();
            _specialDate.SpecialBackColor = _ItsView.SpecialBackColor;
            _specialDate.SpecialDateTime = Convert.ToDateTime(SpecialDate);
            _specialDate.SpecialDescription = _ItsView.SpecialDescription;
            _specialDate.SpecialForeColor = _ItsView.SpecialForeColor;
            _specialDate.SpecialHeader = _ItsView.SpecialHeader;
            _specialDate.IsWork = _ItsView.IsWork;
            try
            {
                BllInstance.SpecialDateBllInstance.CreateSpecialDate(_specialDate, _Account);
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ex)
            {
                _ItsView.ResultMessage = ex.Message;
            }
        }
    }
}
