using System;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseItem
{
    public class ReimburseItemUpdatePresenter
    {
        private readonly IReimburseItemView _IReimburseItemView;
        private readonly string _Id;
        private readonly bool _IsTravel;

        public ReimburseItemUpdatePresenter(IReimburseItemView iReimburseItemView, string id,bool isTravel)
        {
            _IReimburseItemView = iReimburseItemView;
            _Id = id;
            _IsTravel = isTravel;
            AttachViewEvent();
        }
        private void AttachViewEvent()
        {
            _IReimburseItemView.btnOKClick += UpdateReimburseItemEvent;
        }
        public void InitView()
        {
            _IReimburseItemView.SetFormReadonly = false;
            _IReimburseItemView.Operation = "修改报销项";
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
        public void UpdateReimburseItemEvent(object source, EventArgs e)
        {
            if (!new ReimburseItemValidater(_IReimburseItemView).Vaildate())
            {
                return;
            }

            int theId;
            if (!int.TryParse(_Id, out theId))
            {
                return;
            }
            new ReimburseItemDataCollector(_IReimburseItemView).CompleteTheObject(FindWorkExperienceById(theId));
            _IReimburseItemView.ActionSuccess = true;
        }

    }
}
