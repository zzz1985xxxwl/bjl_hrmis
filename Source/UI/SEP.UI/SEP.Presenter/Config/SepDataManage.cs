using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.Presenter.Config
{
    public class SepDataManage
    {
        public List<Department> GetAllDepartment()
        {
            return BllInstance.DepartmentBllInstance.GetAllDepartment();
        }

        public string SaveInitialData(string positionGradeName, string positionName, string depName, string leaderName, string leaderLoginName)
        {
            string message = "";

            try
            {
                #region Account

                Account accounts = new Account();
                accounts.Name = "系统初始用户";
                accounts.LoginName = "admin";
                accounts.AccountType = VisibleType.SEP;
                accounts.Auths = new List<Auth>();
                accounts.Auths.Add(new Auth(Powers.A101, ""));
                accounts.Auths.Add(new Auth(Powers.A201, ""));
                accounts.Auths.Add(new Auth(Powers.A202, ""));
                accounts.Auths.Add(new Auth(Powers.A203, ""));

                #endregion

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    #region PositionGrade

                    PositionGrade positionGrade = new PositionGrade(-1, positionGradeName, "");
                    List<PositionGrade> objs = new List<PositionGrade>();
                    objs.Add(positionGrade);
                    BllInstance.PositionBllInstance.SavePositionGradeList(objs, new List<int>(), accounts);

                    #endregion

                    #region Position

                    Position position = new Position();
                    position.Name = positionName;
                    position.Description = "";
                    positionGrade =
                        BllInstance.PositionBllInstance.GetPositionGradeByName(positionGradeName, accounts);
                    if (positionGrade != null)
                    {
                        position.Grade = new PositionGrade();
                        position.Grade.Id = positionGrade.Id;
                    }

                    BllInstance.PositionBllInstance.CreatePosition(position, accounts);

                    #endregion

                    #region Employee

                    Account account = new Account();
                    account.LoginName = leaderLoginName;
                    account.AccountType = VisibleType.SEP;
                    account.Password = Account.DefaultPassword;
                    account.Name = leaderName;
                    account.Email1 = "";
                    account.Email2 = "";
                    account.MobileNum = "";
                    account.Dept = new Department(1, "");
                    account.Position = BllInstance.PositionBllInstance.GetPositionByName(positionName, accounts);
                    BllInstance.AccountBllInstance.CreateAccount(account, accounts);

                    #endregion

                    #region Department

                    Department department = new Department();
                    department.Name = depName;
                    department.Leader = new Account(1, leaderName, leaderName);
                    BllInstance.DepartmentBllInstance.CreateDept(department, accounts);

                    #endregion

                    ts.Complete();
                }
            }
            catch (ApplicationException ae)
            {
                message = ae.Message;
            }
            return message;
        }
    }
}