using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class SetEmployeeAccountSetPresenter
    {
        private readonly ISetEmployeeAccountSetPresenter _ItsView;

        private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
            InstanceFactory.CreateEmployeeAccountSetFacade();

        private readonly IAccountSetFacade _IAccountSetFacade = InstanceFactory.CreateAccountSetFacade();

        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        
        private string _BackAccountsName;

        public SetEmployeeAccountSetPresenter(ISetEmployeeAccountSetPresenter view)
        {
            _ItsView = view;
            AttachViewEvent();
        }

        public void InitView(bool isPostBack, int employeeID, string backAccountsName)
        {
            _BackAccountsName = backAccountsName;
            _ItsView.EmployeeID = employeeID.ToString();
            _ItsView.IsPostBack = isPostBack;

            if (!isPostBack)
            {
                GetData();
                BindEmployeeSetByEmployeeID(employeeID);
            }
            else
            {
                BindEmployeeSet(employeeID);
            }
        }

        private void BindEmployeeSetByEmployeeID(int employeeID)
        {
            try
            {
                _ItsView.ResultMessage = string.Empty;
                EmployeeSalary employeeSalary;
                EmployeeSalary temp = _IEmployeeAccountSetFacade.GetEmployeeAccountSetByEmployeeID(employeeID);
                if (temp != null)
                {
                    employeeSalary = temp;
                    _ItsView.Description = employeeSalary.AccountSet.Description;
                }
                else
                {
                    employeeSalary = new EmployeeSalary(employeeID);
                    employeeSalary.AccountSet = _IAccountSetFacade.GetWholeAccountSetByPKID(_ItsView.AccountSetID);
                }
                employeeSalary.Employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(employeeID);
                _ItsView.EmployeeSalary = employeeSalary;
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        private void BindEmployeeSet(int employeeID)
        {
            try
            {
                _ItsView.ResultMessage = string.Empty;
                EmployeeSalary employeeSalary = new EmployeeSalary(employeeID);
                employeeSalary.AccountSet = _IAccountSetFacade.GetWholeAccountSetByPKID(_ItsView.AccountSetID);
                employeeSalary.Employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(employeeID);
                _ItsView.EmployeeSalary = employeeSalary;
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        private void GetData()
        {
            _ItsView.AccountSetSource = _IAccountSetFacade.GetAccountSetByCondition("");
        }

        public event EventHandler GoToListPage;
        public void AttachViewEvent()
        {
            _ItsView.BtnOKEvent += ExecutEvent;
            _ItsView.BtnCancelEvent += GoToListPage;
        }

        private Model.PayModule.AccountSet _AccountSet;
        private Model.PayModule.AccountSet AccountSet 
        { 
            get
            {
                return _AccountSet;
            }
            set
            {
                _AccountSet = value;
            }
        }

        private bool Validation()
        {
            try
            {
                AccountSet = _ItsView.AccountSet;
                return true;
            }
            catch
            {
                _ItsView.ResultMessage =
                    //"&nbsp;&nbsp;&nbsp;<img src='../../../Pages/image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>
                    "输入格式不正确";//</span>";
                return false;
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        public void ExecutEvent(object source, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    _ItsView.ResultMessage = string.Empty;
                    int employeeID = Convert.ToInt32(_ItsView.EmployeeID);
                    if (_IEmployeeAccountSetFacade.GetEmployeeAccountSetByEmployeeID(employeeID) == null)
                    {
                        _IEmployeeAccountSetFacade.CreateEmployeeAccountSetFacade(employeeID, AccountSet, _BackAccountsName,
                                                         DateTime.Now,
                                                         _ItsView.Description);
                    }
                    else
                    {
                        _IEmployeeAccountSetFacade.UpdateEmployeeAccountSetFacade(employeeID, AccountSet, _BackAccountsName,
                                                         DateTime.Now,
                                                         _ItsView.Description);
                    }

                    _ItsView.ResultMessage =
                        //"&nbsp;&nbsp;&nbsp;<img src='../../../Pages/image/cg.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>
                        "设置成功";//</span>";
                }
                catch (Exception ex)
                {
                    _ItsView.ResultMessage =
                        //"&nbsp;&nbsp;&nbsp;<img src='../../../Pages/image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>" +
                        ex.Message;// +"</span>";
                }
            }
        }
    }
}
