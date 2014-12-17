using System;
using System.Configuration;
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
    public class AddDepartmentPresenter
    {
        private readonly IDepartmentView _ItsView;
        public IDepartmentBll _DepartmentBll = BllInstance.DepartmentBllInstance;
        public Department _ANewObject;
        private readonly Account _LoginUser;

        public AddDepartmentPresenter(IDepartmentView itsView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

        public void InitView(string parentid)
        {
            int parentID;
            if (!int.TryParse(parentid, out parentID))
            {
                _ItsView.Message = "初始化失败，无法获取所选父级部门结点";
            }
            _ItsView.ParentID = parentID.ToString();
            new DepartmentIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = DepartmentUtility.AddPageTitle;
            _ItsView.ActionButtonTxt = DepartmentUtility.AddActionButtonTxt;
            _ItsView.OperationType = DepartmentUtility.AddOperationType;
            _ItsView.SetReadonly = false;
        }

        public void AddEvent()
        {
            //数据验证过程
            if (!new DepartmentVaildater(_ItsView).Vaildate())
            {
                return;
            }
            //数据收集过程
            _ANewObject = new Department(0, "");
            new DepartmentDataCollector(_ItsView).CompleteTheObject(_ANewObject);
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DepartmentBll.CreateDept(Convert.ToInt32(_ItsView.ParentID), _ANewObject, _LoginUser);
                    if (CompanyConfig.HasHrmisSystem)
                    {
                        IDepartmentHistoryFacade hrmisDepartmentHistoryFacade =
                            InstanceFactory.CreateDepartmentHistoryFacade();
                        hrmisDepartmentHistoryFacade.AddDepartmentHistory(_LoginUser);
                    }
                    ts.Complete();
                }

                _ItsView.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
            catch (Exception e)
            {
                _ItsView.Message = e.Message;
            }
        }
    }
}