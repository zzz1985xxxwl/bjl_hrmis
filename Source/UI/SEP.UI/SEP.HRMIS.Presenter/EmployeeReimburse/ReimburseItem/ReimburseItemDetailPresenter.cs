using System;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseItem
{
    public class ReimburseItemDetailPresenter
    {
        private readonly IReimburseItemView _IReimburseItemView;
        private readonly string _Id;
        private readonly bool _IsTravel;

        public ReimburseItemDetailPresenter(IReimburseItemView itsView, string id,bool isTravel)
        {
            _IReimburseItemView = itsView;
            _Id = id;
            _IsTravel = isTravel;
            AttachViewEvent();
        }
        private void AttachViewEvent()
        {
            _IReimburseItemView.btnOKClick += DetailReimburseItemEvent;
        }
        public void InitView()
        {
            _IReimburseItemView.SetFormReadonly = true;
            _IReimburseItemView.Operation = "报销项详情";
            _IReimburseItemView.Message = string.Empty;
            new ReimburseItemViewIniter(_IReimburseItemView, _IsTravel).InitTheViewToDefault();


            int id;
            if (!int.TryParse(_Id, out id))
            {
                return;
            }
            hrmisModel.ReimburseItem theObject = FindWorkExperienceById(id);
            new ReimburseItemDataBinder(_IReimburseItemView).DataBind(theObject);

        }
        private hrmisModel.ReimburseItem FindWorkExperienceById(int id)
        {
            if (_IReimburseItemView.ReimburseItemSource != null)
            {
                foreach (hrmisModel.ReimburseItem eachReimburseItem in _IReimburseItemView.ReimburseItemSource)
                {
                    if (eachReimburseItem.HashCode.Equals(id))
                    {
                        return eachReimburseItem;
                    }
                }
            }
            return null;
        }
        public void DetailReimburseItemEvent(object source, EventArgs e)
        {
            _IReimburseItemView.ActionSuccess = true;
        }

    }
}
