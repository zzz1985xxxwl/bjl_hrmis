using System;
using System.Transactions;
using SEP.HRMIS.Facade;
using SEP.HRMIS.IFacede;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IEmployees;
using SEP.Model.Utility;

namespace SEP.Presenter.Employees
{
    public class CreateEmployeePresenter : BasePresenter
    {
        private readonly IEmployeeDetailPresenter _ItsView;

        public CreateEmployeePresenter(IEmployeeDetailPresenter view, Account loginUser)
            : base(loginUser)
        {
            _ItsView = view;

            _ItsView.BtnOKEvent += ExecutEvent;
        }

        public override void Initialize(bool isPostBack)
        {
            new EmployeeViewIniter(_ItsView).SetMessageEmpty();

            if (isPostBack)
                return;

            _ItsView.Operation = "新增用户";
            _ItsView.IfValidate = Convert.ToInt32(true);
            _ItsView.DepartmentSource = BllInstance.DepartmentBllInstance.GetAllDepartment();
            _ItsView.GradesTypeSource = GradesType.GetAll();
        }

        public event DelegateNoParameter GoToListPage;

        /// <summary>
        /// 新增
        /// </summary>
        public void ExecutEvent(object source, EventArgs e)
        {
            _ItsView.ResultMessage = string.Empty;

            if (!new EmployeeValidater(_ItsView).Validation())
            {
                return;
            }

            Account account = new EmployeeDataCollector(_ItsView).AccountDataCollect();

            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    BllInstance.AccountBllInstance.CreateAccount(account, LoginUser);
                    if (CompanyConfig.HasHrmisSystem && account.IsHRAccount)
                    {
                        IEmployeeFacade hrmisEmployeeFacade =
                            new EmployeeFacade();
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