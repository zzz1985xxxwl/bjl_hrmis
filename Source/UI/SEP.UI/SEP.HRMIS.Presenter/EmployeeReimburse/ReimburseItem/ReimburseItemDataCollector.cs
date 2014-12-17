using System;
using System.Linq;
using System.Collections.Generic;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Logic;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseItem
{
    public class ReimburseItemDataCollector
    {
        private readonly IReimburseItemView _ItsView;
        private hrmisModel.ReimburseItem _TheObjectToComplete;
        public ReimburseItemDataCollector(IReimburseItemView itsView)
        {
            _ItsView = itsView;
        }
      
        public void CompleteTheObject(hrmisModel.ReimburseItem theObjectToComplete)
        {
            _TheObjectToComplete = theObjectToComplete;

            if (_TheObjectToComplete != null)
            {
                _TheObjectToComplete.ConsumePlace = _ItsView.ConsumePlace;
                _TheObjectToComplete.CustomerID = _ItsView.CustomerID.GetValueOrDefault();
                _TheObjectToComplete.Reason = _ItsView.Reason;
                _TheObjectToComplete.ReimburseTypeEnum = _ItsView.ReimburseType;
                _TheObjectToComplete.TotalCost = Convert.ToDecimal(_ItsView.TotalCost);
            }
        }
    }
}
