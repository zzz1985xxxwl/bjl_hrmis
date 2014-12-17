using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.ISpecialDate;
using SEP.Model.Accounts;

namespace SEP.Presenter.SpecialDates
{
    public class SpecialDateAllPresenter : BasePresenter
    {
        private ISpecialDateInfoView _ItsView;

        private SepcialDateAddPresenter _BasePresenter;

        public SpecialDateAllPresenter(ISpecialDateInfoView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
        }

        public void InitView(bool IsPostBack, string SpectialDate)
        {
            _BasePresenter = new SepcialDateAddPresenter(_ItsView.SpecialDateView, LoginUser);
            new EditSpecialDatePresenter(_ItsView.SpecialDateEditView, LoginUser);
            AttachViewPresenter();
            _BasePresenter.InitView(false, SpectialDate);
        }

        public override void Initialize(bool isPostBack)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }

        private void AttachViewPresenter()
        {
            _ItsView.SpecialDateView.SpecialDateSlection += SelectSpecialDate;
            _ItsView.SpecialDateEditView.ActionButtonEvent += ActionEvent;
            _ItsView.SpecialDateEditView.CancelButtonEvent += CancelEvent;
        }

        private void SelectSpecialDate(string specialDateID, string specialDate, string specialDateBackColor, string specialDescription,
                                             string specialForeColor, string specialHeader, int isWork)
        {
            new EditSpecialDatePresenter(_ItsView.SpecialDateEditView, LoginUser).InitView(specialDateID, specialDate,
                                             specialDateBackColor, specialDescription, specialForeColor, specialHeader, isWork);
            _ItsView.SpecialDateEditViewVisible = true;
        }

        private void ActionEvent(string SpectialDate)
        {
            if (_ItsView.SpecialDateEditView.ActionSuccess)
            {
                _BasePresenter.InitView(false, SpectialDate);
                _ItsView.SpecialDateEditViewVisible = false;
            }
            else
            {
                _ItsView.SpecialDateEditViewVisible = true;
            }
        }

        private void CancelEvent()
        {
            _ItsView.SpecialDateEditViewVisible = false;
        }
    }
}