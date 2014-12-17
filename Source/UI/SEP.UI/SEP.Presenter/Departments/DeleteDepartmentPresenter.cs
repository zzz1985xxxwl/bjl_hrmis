using System;
using System.Transactions;
using SEP.HRMIS.IFacede;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Utility;
using SEP.Presenter.IPresenter.IDepartments;

namespace SEP.Presenter.Departments
{
    public class DeleteDepartmentPresenter 
    {
        private readonly IDepartmentView _ItsView;
        private readonly IDepartmentBll _DepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly Account _LoginUser;
        public DeleteDepartmentPresenter(IDepartmentView itsView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DeleteEvent;
        }

        public void InitView(string id)
        {
            new DepartmentIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = DepartmentUtility.DeletePageTitle;
            _ItsView.ActionButtonTxt = DepartmentUtility.DeleteActionButtonTxt;
            _ItsView.OperationType = DepartmentUtility.DeleteOperationType;
            _ItsView.SetReadonly = true;

            new DepartmentDataBinder(_ItsView, _LoginUser).DataBind(id);
        }

        private void DeleteEvent()
        {
            try
            {
                if (CompanyConfig.HasHrmisSystem && InstanceFactory.CreateCompanyInvolveFacade().GetEmployeeBasicInfoByCompanyID(Convert.ToInt32(_ItsView.DepartmentID)).Count > 0)
                    throw new ApplicationException("该公司下存在员工，禁止删除！");
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DepartmentBll.DeleteDept(Convert.ToInt32(_ItsView.DepartmentID), _LoginUser);
                    IDepartmentHistoryFacade hrmisDepartmentHistoryFacade =
                        InstanceFactory.CreateDepartmentHistoryFacade();
                    hrmisDepartmentHistoryFacade.AddDepartmentHistory(_LoginUser);
                    ts.Complete();
                }
                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }
    }
}
