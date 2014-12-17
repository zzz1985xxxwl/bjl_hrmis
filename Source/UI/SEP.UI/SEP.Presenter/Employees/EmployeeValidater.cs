using System;
using System.Text.RegularExpressions;
using SEP.IBll;
using SEP.Presenter.IPresenter.IEmployees;

namespace SEP.Presenter.Employees
{
    public class EmployeeValidater
    {
        private readonly IEmployeeDetailPresenter _ItsView;

        public EmployeeValidater(IEmployeeDetailPresenter view)
        {
            _ItsView = view;
        }

        public bool Validation()
        {
            try
            {
                bool iRet = true;
                if (String.IsNullOrEmpty(_ItsView.LoginName))
                {
                    _ItsView.LoginNameMsg = EmployeePresenterUtility._FieldNotEmpty;
                    iRet = false;
                }
                if (String.IsNullOrEmpty(_ItsView.EmployeeName))
                {
                    _ItsView.NameMsg = EmployeePresenterUtility._FieldNotEmpty;
                    iRet = false;
                }
                if (String.IsNullOrEmpty(_ItsView.Email))
                {
                    _ItsView.EmailMsg = EmployeePresenterUtility._FieldNotEmpty;
                    iRet = false;
                }
                else if (!IsGoodEmail(_ItsView.Email))
                {
                    _ItsView.EmailMsg = EmployeePresenterUtility._FieldNotGood;
                    iRet = false;
                }
                if (!String.IsNullOrEmpty(_ItsView.Email2) && !IsGoodEmail(_ItsView.Email2))
                {
                    _ItsView.EmailMsg2 = EmployeePresenterUtility._FieldNotGood;
                    iRet = false;
                }
                if (String.IsNullOrEmpty(_ItsView.DepartmentID))
                {
                    _ItsView.DepartmentMsg = EmployeePresenterUtility._FieldNotEmpty;
                    iRet = false;
                }
                if (String.IsNullOrEmpty(_ItsView.PositionName))
                {
                    _ItsView.PositionMsg = EmployeePresenterUtility._FieldNotEmpty;
                    iRet = false;
                }
                else if (BllInstance.PositionBllInstance.GetPositionByName(_ItsView.PositionName, null) == null)
                {
                    _ItsView.PositionMsg = EmployeePresenterUtility._PositionNotExit;
                    iRet = false;
                }
                
                
                return iRet;
            }
            catch
            {
                _ItsView.ResultMessage =
                    //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;<span class='fontred'>
                    "输入格式不正确";//</span>";
                return false;
            }
        }
        /// <summary>
        /// 正则表达式验证mail是否合格
        /// </summary>
        public static bool IsGoodEmail(string email)
        {
            string emailPattern = @"^\w+([\.\-]\w+)*\@\w+([\.\-]\w+)*\.\w+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
