using System;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseItem
{
    public class ReimburseItemDeletePresenter
    {
        private readonly IReimburseItemView _IReimburseItemView;
        private readonly string _Id;
        private readonly bool _IsTravel;

        public ReimburseItemDeletePresenter(IReimburseItemView itsView, string id,bool isTravel)
        {
            _IReimburseItemView = itsView;
            _Id = id;
            _IsTravel = isTravel;
            AttachViewEvent();
        }
        private void AttachViewEvent()
        {
            _IReimburseItemView.btnOKClick += DeleteReimburseItemEvent;
        }
        public void InitView()
        {
            _IReimburseItemView.SetFormReadonly = true;
            _IReimburseItemView.Operation = "É¾³ý±¨ÏúÏî";
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
        private void RemoveWorkExperienceById(int id)
        {
            if (_IReimburseItemView.ReimburseItemSource != null)
            {
                foreach (hrmisModel.ReimburseItem eachReimburseItem in _IReimburseItemView.ReimburseItemSource)
                {
                    if (eachReimburseItem.HashCode.Equals(id))
                    {
                        _IReimburseItemView.ReimburseItemSource.Remove(eachReimburseItem);
                        break;
                    }
                }
            }
        }
        public void DeleteReimburseItemEvent(object source, EventArgs e)
        {
            int theId;
            if (!int.TryParse(_Id, out theId))
            {
                return;
            }
            RemoveWorkExperienceById(theId);
            _IReimburseItemView.ActionSuccess = true;
        }

    }
}
