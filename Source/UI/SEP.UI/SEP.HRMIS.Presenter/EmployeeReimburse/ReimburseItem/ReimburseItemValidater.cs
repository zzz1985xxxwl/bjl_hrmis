using System;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseItem
{
    public class ReimburseItemValidater
    {
        private readonly IReimburseItemView _ItsView;

        public ReimburseItemValidater(IReimburseItemView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            _ItsView.Message = string.Empty;
            _ItsView.ReasonMsg = string.Empty;
            _ItsView.TotalCostMsg = string.Empty;
            bool iRet = true;

            if (string.IsNullOrEmpty(_ItsView.Reason))
            {
                _ItsView.ReasonMsg = "����Ϊ��";
                iRet = false;
            }
            if (string.IsNullOrEmpty(_ItsView.TotalCost))
            {
                _ItsView.TotalCostMsg = "����Ϊ��";
                iRet = false;
            }
            else
            {
                decimal i = 0;
                if (!decimal.TryParse(_ItsView.TotalCost, out i))
                {
                    _ItsView.TotalCostMsg = "����Ϊ����";
                    iRet = false;
                }
                else if (i <= 0)
                {
                    _ItsView.TotalCostMsg = "�������0";
                    iRet = false;
                }
            }
            return iRet;
        }
    }
}
