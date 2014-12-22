using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll.PositionApplications
{
    public class GetPositionApplication
    {
        private readonly IPositionApplicationDal _PositionApplicationDal =new PositionApplicationDal();
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positionApplication"></param>
        /// <param name="diyStep"></param>
        /// <returns></returns>
        internal int ChangeOperatorToEmployee(PositionApplication positionApplication, DiyStep diyStep)
        {
            int accountID = 0;
            try
            {
                switch (diyStep.OperatorType.Id)
                {
                    //"本人"
                    case 0:
                        accountID = positionApplication.Account.Id;
                        break;
                    //"部门主管"
                    case 1:
                        accountID = _IAccountBll.GetLeaderByAccountId(positionApplication.Account.Id).Id;
                        break;
                    //"上级部门主管";
                    case 2:
                        Account account2 = _IAccountBll.GetAccountById(positionApplication.Account.Id);
                        accountID = _IDepartmentBll.GetParentDept(account2.Dept.Id, null).Leader.Id;
                        break;
                    //"上上级部门主管"
                    case 3:
                        Account account3 = _IAccountBll.GetAccountById(positionApplication.Account.Id);
                        Department department3 = _IDepartmentBll.GetParentDept(account3.Dept.Id, null);
                        accountID = _IDepartmentBll.GetParentDept(department3.Id, null).Leader.Id;
                        break;
                    //"上上上级部门主管"
                    case 4:
                        Account account4 = _IAccountBll.GetAccountById(positionApplication.Account.Id);
                        Department department4 = _IDepartmentBll.GetParentDept(account4.Dept.Id, null);
                        department4 = _IDepartmentBll.GetParentDept(department4.Id, null);
                        accountID = _IDepartmentBll.GetParentDept(department4.Id, null).Leader.Id;
                        break;
                    //"上上上上级部门主管"
                    case 5:
                        Account account5 = _IAccountBll.GetAccountById(positionApplication.Account.Id);
                        Department department5 = _IDepartmentBll.GetParentDept(account5.Dept.Id, null);
                        department5 = _IDepartmentBll.GetParentDept(department5.Id, null);
                        department5 = _IDepartmentBll.GetParentDept(department5.Id, null);
                        accountID = _IDepartmentBll.GetParentDept(department5.Id, null).Leader.Id;
                        break;
                    //"其他"
                    case 6:
                        accountID = diyStep.OperatorID;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                //-1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;
                //5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
                RequestStatus status;
                switch (positionApplication.Status.Id)
                {
                    case 4:
                    case 8:
                        status = RequestStatus.ApproveCancelFail;
                        break;
                    default: //1 7
                        status = RequestStatus.ApproveFail;
                        break;
                }
                ApproveFailPositionApplication approveFailPositionApplication =
                    new ApproveFailPositionApplication(positionApplication.PKID, Account.AdminPkid, status,
                                                       HrmisUtility._No_Account);
                approveFailPositionApplication.Excute();
            }
            return accountID;
        }

        public PositionApplication GetPositionApplicationByPKID(int pkid)
        {
            PositionApplication positionApplication = _PositionApplicationDal.GetPositionApplicationByPKID(pkid);
            positionApplication.Account = _IAccountBll.GetAccountById(positionApplication.Account.Id);
            if (positionApplication != null
                && positionApplication.Position != null
                && positionApplication.Position.Grade != null)
            {
                positionApplication.Position.Grade =
                    BllInstance.PositionBllInstance.GetPositionGradeById(positionApplication.Position.Grade.Id, null);
            }

            if (positionApplication != null
                && positionApplication.Position != null
                && positionApplication.Position.Nature != null)
            {
                for (int i = 0; i < positionApplication.Position.Nature.Count; i++)
                {
                    positionApplication.Position.Nature[i] =
                        BllInstance.PositionBllInstance.GetPositionNatureById(
                            positionApplication.Position.Nature[i].Pkid);
                }
            }

            for (int i = 0; i < positionApplication.Position.Members.Count; i++)
            {
                positionApplication.Position.Members[i] =
                    _IAccountBll.GetAccountById(positionApplication.Position.Members[i].Id);
            }
            for (int i = 0; i < positionApplication.Position.Departments.Count; i++)
            {
                positionApplication.Position.Departments[i] =
                    _IDepartmentBll.GetDepartmentById(positionApplication.Position.Departments[i].Id, null);
            }
            return positionApplication;
        }

        public List<PositionApplication> GetPositionApplicationByAccountID(int accountID)
        {
            return _PositionApplicationDal.GetPositionApplicationByAccountID(accountID);
        }

        public List<PositionApplication> GetConfirmPositionApplication(int accountID)
        {
            List<PositionApplication> leaveRequestList = new List<PositionApplication>();
            //找出所有待审核的申请
            List<PositionApplication> confirmList = _PositionApplicationDal.GetConfirmPositionApplication();

            foreach (PositionApplication confirmLeaveRequest in confirmList)
            {
                confirmLeaveRequest.Account = _IAccountBll.GetAccountById(confirmLeaveRequest.Account.Id);

                confirmLeaveRequest.CurrentStep.OperatorID =
                    ChangeOperatorToEmployee(confirmLeaveRequest, confirmLeaveRequest.CurrentStep);

                if (confirmLeaveRequest.CurrentStep.OperatorID == accountID &&
                    confirmLeaveRequest.CurrentStep.Status != "取消")
                {
                    leaveRequestList.Add(confirmLeaveRequest);
                }
            }
            return leaveRequestList;
        }

        public List<PositionApplication> GetPositionApplicationConfirmHistoryByOperatorID(int operatorID, string name)
        {
            List<PositionApplication> iRet =
                _PositionApplicationDal.GetPositionApplicationConfirmHistoryByOperatorID(operatorID);
            List<PositionApplication> positionApplications = new List<PositionApplication>();
            foreach (PositionApplication positionApplication in iRet)
            {
                positionApplication.Account = _IAccountBll.GetAccountById(positionApplication.Account.Id);
                if (positionApplication.Account.Name.Contains(name))
                {
                    positionApplications.Add(positionApplication);
                }
            }
            return positionApplications;
        }

        public List<PositionApplicationFlow> GetPositionApplicationFlowByPositionApplicationID(int positionApplicationID)
        {
            List<PositionApplicationFlow> ret =
                _PositionApplicationDal.GetPositionApplicationFlowByPositionApplicationID(positionApplicationID);
            for (int i = 0; i < ret.Count; i++)
            {
                if (ret[i].Account != null)
                {
                    ret[i].Account = BllInstance.AccountBllInstance.GetAccountById(ret[i].Account.Id);
                }
            }
            return ret;
        }

        public List<PositionApplication> GetPositionApplicationByCondition(string name, string account, int isPublish, int status)
        {
            List<PositionApplication> iRet = new List<PositionApplication>();
            List<PositionApplication> positionApplicationList =
                _PositionApplicationDal.GetPositionApplicationByCondition(name, isPublish, status);
            for (int i = 0; i < positionApplicationList.Count; i++)
            {
                positionApplicationList[i].Account = _IAccountBll.GetAccountById(positionApplicationList[i].Account.Id);
                if(positionApplicationList[i].Account.Name.Contains(account))
                {
                    iRet.Add(positionApplicationList[i]);
                }
            }
            return positionApplicationList;
        }

        private void GetPositionApplicationMoreInfo(PositionApplication PositionApplication)
        {
            if (PositionApplication != null
                && PositionApplication.Position != null
                && PositionApplication.Position.Grade != null)
            {
                PositionApplication.Position.Grade =
                    BllInstance.PositionBllInstance.GetPositionGradeById(PositionApplication.Position.Grade.Id, null);
            }

            if (PositionApplication != null
                && PositionApplication.Position != null
                && PositionApplication.Position.Nature != null)
            {
                for (int i = 0; i < PositionApplication.Position.Nature.Count; i++)
                {
                    PositionApplication.Position.Nature[i] =
                        BllInstance.PositionBllInstance.GetPositionNatureById(
                            PositionApplication.Position.Nature[i].Pkid);
                }
            }
            if (PositionApplication != null
                && PositionApplication.Position != null
                && PositionApplication.Position.Departments != null)
            {
                for (int i = 0; i < PositionApplication.Position.Departments.Count; i++)
                {
                    PositionApplication.Position.Departments[i] =
                        BllInstance.DepartmentBllInstance.GetDepartmentById(
                            PositionApplication.Position.Departments[i].Id, null);
                }
            }
            if (PositionApplication != null
                && PositionApplication.Position != null
                && PositionApplication.Position.Members != null)
            {
                for (int i = 0; i < PositionApplication.Position.Members.Count; i++)
                {
                    PositionApplication.Position.Members[i] =
                        BllInstance.AccountBllInstance.GetAccountById(PositionApplication.Position.Members[i].Id);
                }
            }

        }
    }
}