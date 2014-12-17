using SEP.Presenter.IPresenter.ISpecialDate;

namespace SEP.Presenter.SpecialDates
{
    public class SpecialDataInit
    {
        private readonly ISpecialDateEditView _ItsView;

        public SpecialDataInit(ISpecialDateEditView itsView)
        {
            _ItsView = itsView;
        }
        public void InitSpecialDate(string specialDateID, string specialDate,
            string specialDateBackColor, string specialDescription, string specialForeColor,
            string specialHeader, int isWork)
        {
            _ItsView.ValidateTitle = string.Empty;
            _ItsView.ResultMessage = string.Empty;
            _ItsView.ValidateTitle = string.Empty;
            _ItsView.ResultMessage = string.Empty;
            _ItsView.SpecialDate = specialDate;
            _ItsView.SpecialDateID = specialDateID;
            _ItsView.SpecialDescription = specialDescription;
            _ItsView.SpecialHeader = specialHeader;
            _ItsView.IsWork = isWork;
        }
    }
}
