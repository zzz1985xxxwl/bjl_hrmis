using System;
using System.Transactions;
using SEP.HRMIS.Facade;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IEmployees;
using SEP.Model.Utility;

namespace SEP.Presenter.Employees
{
    public class UpdateEmployeePresenter : BasePresenter
    {
        public event DelegateNoParameter GoToListPage;
        private IEmployeeDetailPresenter _ItsView;

        public UpdateEmployeePresenter(IEmployeeDetailPresenter view, Account loginUser)
            : base(loginUser)
        {
            _ItsView = view;

            _ItsView.BtnOKEvent += ExecutEvent;
        }

        public override void Initialize(bool isPostBack)
        {
            new EmployeeViewIniter(_ItsView).SetMessageEmpty();
            if (isPostBack) return;

            _ItsView.Operation = "修改用户";
            _ItsView.DepartmentSource = BllInstance.DepartmentBllInstance.GetAllDepartment();
            _ItsView.GradesTypeSource = GradesType.GetAll();
            new EmployeeDataBind(_ItsView).DataBind();
        }

        /// <summary>
        /// 修改
        /// </summary>
        public void ExecutEvent(object source, EventArgs e)
        {
            if (!new EmployeeValidater(_ItsView).Validation())
                return;

            _ItsView.ResultMessage = string.Empty;

            Account account = new EmployeeDataCollector(_ItsView).AccountDataCollect();
            account.Id = _ItsView.EmployeeID;
            try
            {
                if (!CompanyConfig.HasHrmisSystem)
                {
                    BllInstance.AccountBllInstance.UpdateAccount(account, LoginUser);
                    GoToListPage();
                    return;
                }

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    BllInstance.AccountBllInstance.UpdateAccount(account, LoginUser);

                    IEmployeeFacade hrmisEmployeeFacade = new EmployeeFacade();
                    Employee currEmployee = hrmisEmployeeFacade.GetEmployeeByAccountID(account.Id);
                    if (currEmployee != null)
                    {
                        hrmisEmployeeFacade.UpdateEmployeeProxy(currEmployee, LoginUser);

                    }
                    else if (account.IsHRAccount)
                    {
                        hrmisEmployeeFacade.InitEmployeeProxy(account.Id, LoginUser);
                    }
                    ts.Complete();
                }
                GoToListPage();
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage =
                    //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>" +
                    ex.Message;// +"</span>";
            }
        }
    }
}
