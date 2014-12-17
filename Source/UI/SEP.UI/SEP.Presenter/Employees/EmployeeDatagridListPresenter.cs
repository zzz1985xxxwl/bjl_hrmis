using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Presenter.IPresenter.IEmployees;
using SEP.Presenter.Core;

namespace SEP.Presenter.Employees
{
    public class EmployeeDatagridListPresenter : BasePresenter
    {
        private readonly IEmployeeDatagridListPresenter _ItsView;

        public EmployeeDatagridListPresenter(IEmployeeDatagridListPresenter view, Account loginUser)
            : base(loginUser)
        {
            _ItsView = view;

            _ItsView.BtnSearchEvent += ExecutEvent;
            _ItsView.BtnResetPasswordEvent += _ItsView_BtnResetPasswordEvent;
        }

        public override void Initialize(bool isPostBack)
        {
            if (isPostBack)
                return;

            _ItsView.DepartmentSource = BllInstance.DepartmentBllInstance.GetAllDepartment();
            _ItsView.PositionSource = BllInstance.PositionBllInstance.GetAllPosition();
            _ItsView.GradesTypeSource = GradesType.GetAll();
            ExecutEvent();
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        private void _ItsView_BtnResetPasswordEvent(string loginName)
        {
            try
            {
                BllInstance.AccountBllInstance.SetDefaultPassword(loginName, LoginUser);
                _ItsView.ResultMessage = "<span class='font14b'>成功重置  </span>"
                                     + "<span class='fontred'>" + loginName + "</span>"
                                     + "<span class='font14b'>  的密码为：</span>" + Account.DefaultPassword;
            }
            catch (Exception ex)
            {
                _ItsView.ResultMessage =
                    //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>" +
                    ex.Message;// +"</span>";
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void ExecutEvent()
        {
            _ItsView.ResultMessage = string.Empty;

            bool? ifVisible = null;
            if (_ItsView.IfValidate == "0")
            {
                ifVisible = false;
            }
            else if (_ItsView.IfValidate == "1")
            {
                ifVisible = true;
            }
            int departmentID = Convert.ToInt32(_ItsView.DepartmentID);
            //int? departmentID = Convert.ToInt32(_ItsView.DepartmentID);
            //if (departmentID == -1)
            //{
            //    departmentID = null;
            //}
            int positionID = Convert.ToInt32(_ItsView.PositionID);

            int? gradesID = null;
            if (!string.IsNullOrEmpty(_ItsView.GradesID))
            {
                gradesID = Convert.ToInt32(_ItsView.GradesID);
            }
            //int? positionID = Convert.ToInt32(_ItsView.PositionID);
            //if (positionID == -1)
            //{
            //    positionID = null;
            //}

            try
            {
                //List<Account> accountList = BllInstance.AccountBllInstance.GetAccountByCondition(_ItsView.EmployeeName,
                //                                                                                 departmentID,
                //                                                                                 positionID, ifVisible);
                List<Account> accountList = BllInstance.AccountBllInstance.GetAccountByBaseCondition(_ItsView.EmployeeName,
                                                                                 departmentID,
                                                                                 positionID, gradesID, _ItsView.RecursionDepartment, ifVisible);

                _ItsView.AccountList = accountList;
                _ItsView.ResultMessage = "<span class='font14b'>共查到 </span>"
                                     + "<span class='fontred'>" + accountList.Count + "</span>"
                                     + "<span class='font14b'> 条信息</span>";
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
