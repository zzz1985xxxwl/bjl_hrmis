using SEP.HRMIS.IFacede;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseItem
{
    public class ReimburseItemDataBinder
    {
        private readonly IReimburseItemView _ItsView;
        private hrmisModel.ReimburseItem _TheDataToShow;
        private readonly ICustomerInfoFacade _ICustomerInfoFacade = InstanceFactory.CreateCustomerInfoFacade();

        public ReimburseItemDataBinder(IReimburseItemView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(hrmisModel.ReimburseItem theDataToBind)
        {
            _TheDataToShow = theDataToBind;
            if (_TheDataToShow == null)
            {
                return false;
            }
            _ItsView.ConsumePlace = theDataToBind.ConsumePlace;
            _ItsView.Message = string.Empty;
            //_ItsView.ProjectName = theDataToBind.ProjectName;
            _ItsView.Reason = theDataToBind.Reason;
            _ItsView.ReasonMsg = string.Empty;
            _ItsView.TotalCost = theDataToBind.TotalCost.ToString();
            _ItsView.TotalCostMsg = string.Empty;
            _ItsView.ReimburseType = theDataToBind.ReimburseTypeEnum;
            _ItsView.CustomerID = theDataToBind.CustomerID;
            if (theDataToBind.CustomerID != 0)
            {
                var customer = _ICustomerInfoFacade.GetCustomerInfoByID(theDataToBind.CustomerID);
                var index = customer.CompanyName.IndexOf(' ');
                if (customer.CompanyName.IndexOf(' ') > 0)
                {
                    _ItsView.CustomerNameCode = customer.CompanyName.Substring(0, index);
                    _ItsView.CustomerName = customer.CompanyName.Substring(index + 1, customer.CompanyName.Length - index - 1);
                }
                else
                {
                    _ItsView.CustomerName = customer.CompanyName;
                }
            }
            return true;
        }
    }
}
