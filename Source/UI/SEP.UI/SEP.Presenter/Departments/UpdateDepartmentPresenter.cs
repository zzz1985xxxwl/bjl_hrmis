using System;
using System.Transactions;
using SEP.HRMIS.IFacede;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;
using SEP.Presenter.IPresenter.IDepartments;

namespace SEP.Presenter.Departments
{
    public class UpdateDepartmentPresenter 
    {
        private readonly IDepartmentView _ItsView;
        private readonly IDepartmentBll _DepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly Account _LoginUser;
        public UpdateDepartmentPresenter(IDepartmentView itsView,Account loginUser)
        {
            _LoginUser = loginUser;
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(string id)
        {
            new DepartmentIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = DepartmentUtility.UpdatePageTitle;
            _ItsView.ActionButtonTxt = DepartmentUtility.UpdateActionButtonTxt;
            _ItsView.OperationType = DepartmentUtility.UpdateOperationType;
            _ItsView.SetReadonly = false;

            new DepartmentDataBinder(_ItsView, _LoginUser).DataBind(id);
        }

        public void UpdateEvent()
        {
            //数据验证过程
            if (!new DepartmentVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集过程
            Department theObject = new Department(Convert.ToInt32(_ItsView.DepartmentID), _ItsView.DepartmentName);
            new DepartmentDataCollector(_ItsView).CompleteTheObject(theObject);
            //执行事务过程
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    Department theOldObject =
                        _DepartmentBll.GetDepartmentById(Convert.ToInt32(_ItsView.DepartmentID), null);
                    _DepartmentBll.UpdateDept(theObject, _LoginUser);
                    if (CompanyConfig.HasHrmisSystem)
                    {
                        if (theOldObject.Name != theObject.Name
                            || theOldObject.Leader.Id != theObject.Leader.Id || theOldObject.Address != theObject.Address || theOldObject.Phone != theObject.Phone || theOldObject.Fax != theObject.Fax || theOldObject.FoundationTime != theObject.FoundationTime || theOldObject.Others != theObject.Others || theOldObject.Description != theObject.Description
                            )
                        {
                            IDepartmentHistoryFacade hrmisDepartmentHistoryFacade =
                                InstanceFactory.CreateDepartmentHistoryFacade();
                            hrmisDepartmentHistoryFacade.AddDepartmentHistory(_LoginUser);
                        }
                        if (theOldObject.Name != theObject.Name || theOldObject.Address != theObject.Address || theOldObject.Phone != theObject.Phone || theOldObject.Fax != theObject.Fax || theOldObject.FoundationTime != theObject.FoundationTime || theOldObject.Others != theObject.Others)
                        {
                            IEmployeeHistoryFacade hrmisEmployeeHistoryFacade =
                                InstanceFactory.CreateEmployeeHistoryFacade();
                            hrmisEmployeeHistoryFacade.AddEmployeeHistoryByDepartment(theObject, _LoginUser);
                        }
                    }
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