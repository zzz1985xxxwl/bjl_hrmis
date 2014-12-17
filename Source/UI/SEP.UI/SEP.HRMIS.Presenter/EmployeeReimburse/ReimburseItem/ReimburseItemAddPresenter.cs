using System;
using System.Collections.Generic;
using HRMisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseItem
{
    public class ReimburseItemAddPresenter
    {
        private readonly IReimburseItemView _IReimburseItemView;
        private readonly bool _IsTravel;

        public ReimburseItemAddPresenter(IReimburseItemView iReimburseItemView,bool isTravel)
        {
            _IReimburseItemView = iReimburseItemView;
            _IsTravel = isTravel;
            AttachViewEvent();
        }
        private void AttachViewEvent()
        {
            _IReimburseItemView.btnOKClick += AddReimburseItemEvent;
        }
        public void InitView()
        {
            _IReimburseItemView.SetFormReadonly = false;
            _IReimburseItemView.Operation = "新增报销项";
            _IReimburseItemView.Message = string.Empty;
            new ReimburseItemViewIniter(_IReimburseItemView, _IsTravel).InitTheViewToDefault();
        }
        public void AddReimburseItemEvent(object source, EventArgs e)
        {
            if (!new ReimburseItemValidater(_IReimburseItemView).Vaildate())
            {
                return;
            }
            HRMisModel.ReimburseItem aNewObject =
                new HRMisModel.ReimburseItem(_IReimburseItemView.ReimburseType,
                                  Convert.ToDecimal(_IReimburseItemView.TotalCost), string.Empty);
            aNewObject.ConsumePlace = _IReimburseItemView.ConsumePlace;
            aNewObject.Reason = _IReimburseItemView.Reason;


            new ReimburseItemDataCollector(_IReimburseItemView).CompleteTheObject(aNewObject);

            if (_IReimburseItemView.ReimburseItemSource == null)
            {
                _IReimburseItemView.ReimburseItemSource = new List<HRMisModel.ReimburseItem>();
            }
            _IReimburseItemView.ReimburseItemSource.Add(aNewObject);
            _IReimburseItemView.ActionSuccess = true;
        }

    }
}
