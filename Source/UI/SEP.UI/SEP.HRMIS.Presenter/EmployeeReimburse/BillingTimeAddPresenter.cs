using System;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class BillingTimeAddPresenter 
    {
        private readonly IBillingTimeDetailView _View;
        public BillingTimeAddPresenter(IBillingTimeDetailView view)
        {
            _View = view;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(string id)
        {
            _View.Message = string.Empty;
            _View.OperationTitle = "填写记账时间";
            _View.BillingTime = DateTime.Now.ToShortDateString();
            _View.ReimburseID = id;
        }

        public void UpdateEvent()
        {
            _View.Message = string.Empty;
            _View.BillingTimeMessage = string.Empty;
            try
            {
                DateTime dateTimetemp;
                bool validition = true;
                if (string.IsNullOrEmpty(_View.BillingTime))
                {
                    _View.BillingTimeMessage = "不能为空";
                    validition = false;
                }

                else if (!DateTime.TryParse(_View.BillingTime, out dateTimetemp))
                {
                    _View.BillingTimeMessage = "格式不对";
                    validition = false;
                }
                if (validition)
                {

                    _View.ActionSuccess = true;
                }
            }
            catch (ApplicationException ae)
            {
                _View.Message = ae.Message;
            }
        }
    }
}
