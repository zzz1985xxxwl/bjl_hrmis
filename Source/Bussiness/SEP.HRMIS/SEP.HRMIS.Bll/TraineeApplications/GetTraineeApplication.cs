
using System;
using System.Collections.Generic;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll.TraineeApplications
{
    public class GetTraineeApplication
    {

        private static readonly ITraineeApplication _DalTraineeApplication = DalFactory.DataAccess.CreateTraineeApplication();
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;


        /// <summary>
        /// �����˺�ID��ø��˺ŵ�����ѵ������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<TraineeApplication> GetTraineeApplicationByAccountID(int accountID)
        {
            List<TraineeApplication> iRet = _DalTraineeApplication.GetEmployeeTraineeApplicationByEmployeeID(accountID);
            for (int i = 0; i < iRet.Count; i++)
            {
                iRet[i] = GetTraineeApplicationByPKID(iRet[i].PKID);
            }
            return iRet;
        }

        /// <summary>
        /// ����PKID��õ���ѵ������Ϣ,���Applicant,StudentList[i]��Ϣ
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public TraineeApplication GetTraineeApplicationByPKID(int pkid)
        {
            TraineeApplication iRet = _DalTraineeApplication.GetTraineeApplicationByTraineeApplicationID(pkid);
            if (iRet != null && iRet.Applicant != null)
            {
                iRet.Applicant = _IAccountBll.GetAccountById(iRet.Applicant.Id);
            }
            if (iRet != null && iRet.StudentList != null)
            {
                for (int i = 0; i < iRet.StudentList.Count; i++)
                {
                    iRet.StudentList[i] = _IAccountBll.GetAccountById(iRet.StudentList[i].Id);
                }
            }
            return iRet;
        }
        /// <summary>
        /// ����applicationID��õ���ѵ��������
        /// </summary>
        /// <param name="traineeApplicationID"></param>
        /// <returns></returns>
        public List<TraineeApplicationFlow> GetTraineeApplicationFlowByTraineeApplicationID(int traineeApplicationID)
        {
            List<TraineeApplicationFlow> iRet = _DalTraineeApplication.GetApplicationFlows(traineeApplicationID);
            foreach (TraineeApplicationFlow item in iRet)
            {
                item.Account = _IAccountBll.GetAccountById(item.Account.Id);
            }
            return iRet;
        }


        ///<summary>
        ///</summary>
        ///<param name="traineeName"></param>
        ///<param name="studentName"></param>
        ///<param name="courseName"></param>
        ///<param name="traineeFrom"></param>
        ///<param name="traineeTo"></param>
        ///<param name="hasCertifacation"></param>
        ///<param name="trainScopeEnum"></param>
        ///<param name="statusEnum"></param>
        ///<returns></returns>
        public List<TraineeApplication> GetTraineeApplicationByCondition
            (string traineeName, string studentName, string courseName, DateTime? traineeFrom, DateTime? traineeTo,
            int hasCertifacation, TrainScopeType trainScopeEnum, TraineeApplicationStatus statusEnum)
        {
            List<TraineeApplication> returnApplication=new List<TraineeApplication>();
            List<Account> traineeList = _IAccountBll.GetAccountByBaseCondition(studentName, -1, -1, null, false, null);
            if (traineeList.Count == 0)
            {
                return returnApplication;
            }
            List<TraineeApplication> applications = _DalTraineeApplication.GetTraineeApplicationByCondition(traineeName, courseName,
                                                                            traineeFrom, traineeTo, hasCertifacation,
                                                                            trainScopeEnum, statusEnum);
            foreach (TraineeApplication application in applications)
            {
                TraineeApplication newapplication = GetTraineeApplicationByPKID(application.PKID);
                //���ҿγ����Ƿ���������������ѵ��Ա
                List<int> traineeListid = new List<int>();
                foreach (Account account in traineeList)
                {
                    traineeListid.Add(account.Id);
                }
                bool isFind = true;
                for (int i = 0; i < newapplication.StudentList.Count; i++)
                {
                    if (traineeListid.Contains(newapplication.StudentList[i].Id))
                    {
                        isFind = false;
                        break;
                    }

                }
                if (!isFind)
                    returnApplication.Add(newapplication);
            }
            return returnApplication;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public List<TraineeApplication> GetMyAuditingTraineeApplications(int accountID)
        {
            List<TraineeApplication> traineeApplicationList = _DalTraineeApplication.GetMyAuditingTraineeApplications(accountID);
            for (int i = 0; i < traineeApplicationList.Count;i++ )
            {
                traineeApplicationList[i] = GetTraineeApplicationByPKID(traineeApplicationList[i].PKID);
            }
            return traineeApplicationList;
        }

        ///<summary>
        ///</summary>
        ///<param name="accountID"></param>
        ///<returns></returns>
        public List<TraineeApplication> GetConfirmTraineeApplication(int accountID)
        {
            List<TraineeApplication> traineeApplicationList = new List<TraineeApplication>();
            //�ҳ����д���˵���ѵ����
            List<TraineeApplication> confirmTraineeApplicationList = GetConfirmTraineeApplication();

            foreach (TraineeApplication confirmTraineeApplication in confirmTraineeApplicationList)
            {
                if (confirmTraineeApplication.CurrentStep.OperatorID == accountID &&
                    confirmTraineeApplication.CurrentStep.Status != "ȡ��")
                {
                    traineeApplicationList.Add(confirmTraineeApplication);
                }
            }
            for (int i = 0; i < traineeApplicationList.Count; i++)
            {
                traineeApplicationList[i] = GetTraineeApplicationByPKID(traineeApplicationList[i].PKID);
            }
            return traineeApplicationList;
        }

        /// <summary>
        /// ����PKID��õ���ѵ������Ϣ
        /// </summary>
        /// <returns></returns>
        public List<TraineeApplication> GetConfirmTraineeApplication()
        {
            //�ҳ����д���˵���ѵ��������
            List<TraineeApplication> confirmTraineeApplicationList =
                _DalTraineeApplication.GetConfimingTraineeApplications();
            for (int i = 0; i < confirmTraineeApplicationList.Count; i++)
            {
                TraineeApplication traineeApplicationitem =
                    GetTraineeApplicationByPKID(confirmTraineeApplicationList[i].PKID);
                if (traineeApplicationitem != null && traineeApplicationitem.StudentList != null)
                {
                    confirmTraineeApplicationList[i].StudentList = traineeApplicationitem.StudentList;
                }
            }
            foreach (TraineeApplication traineeApplication in confirmTraineeApplicationList)
            {
                if (traineeApplication.TraineeApplicationDiyProcess != null)
                {
                    traineeApplication.CurrentStep.OperatorID =
                        ChangeOperatorToEmployee(traineeApplication, traineeApplication.CurrentStep);
                }
                else
                {
                    traineeApplication.CurrentStep = new DiyStep(0, "", OperatorType.Others, 0);
                }
            }
            return confirmTraineeApplicationList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="traineeApplication"></param>
        /// <returns></returns>
        /// <param name="diyStep"></param>
        public int ChangeOperatorToEmployee(TraineeApplication traineeApplication, DiyStep diyStep)
        {
            int accountID = 0;
            try
            {
                switch (diyStep.OperatorType.Id)
                {
                    //"����"
                    case 0:
                        accountID = traineeApplication.Applicant.Id;
                        break;
                    //"��������"
                    case 1:
                        accountID = _IAccountBll.GetLeaderByAccountId(traineeApplication.Applicant.Id).Id;
                        break;
                    //"�ϼ���������";
                    case 2:
                        Account account2 = _IAccountBll.GetAccountById(traineeApplication.Applicant.Id);
                        accountID = _IDepartmentBll.GetParentDept(account2.Dept.Id, null).Leader.Id;
                        break;
                    //"���ϼ���������"
                    case 3:
                        Account account3 = _IAccountBll.GetAccountById(traineeApplication.Applicant.Id);
                        Department department3 = _IDepartmentBll.GetParentDept(account3.Dept.Id, null);
                        accountID = _IDepartmentBll.GetParentDept(department3.Id, null).Leader.Id;
                        break;
                    //"�����ϼ���������"
                    case 4:
                        Account account4 = _IAccountBll.GetAccountById(traineeApplication.Applicant.Id);
                        Department department4 = _IDepartmentBll.GetParentDept(account4.Dept.Id, null);
                        department4 = _IDepartmentBll.GetParentDept(department4.Id, null);
                        accountID = _IDepartmentBll.GetParentDept(department4.Id, null).Leader.Id;
                        break;
                    //"�������ϼ���������"
                    case 5:
                        Account account5 = _IAccountBll.GetAccountById(traineeApplication.Applicant.Id);
                        Department department5 = _IDepartmentBll.GetParentDept(account5.Dept.Id, null);
                        department5 = _IDepartmentBll.GetParentDept(department5.Id, null);
                        department5 = _IDepartmentBll.GetParentDept(department5.Id, null);
                        accountID = _IDepartmentBll.GetParentDept(department5.Id, null).Leader.Id;
                        break;
                    //"����"
                    case 6:
                        accountID = traineeApplication.CurrentStep.OperatorID;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                //todo

                ////-1 ȫ��;0 ����;1 �ύ;2 ��˲�ͨ��;3 ���ͨ��;4 ȡ�����;
                ////5 �ܾ�ȡ������;6 ��׼ȡ������;7 �����;8 ���ȡ����
                //RequestStatus status;
                //switch (traineeApplication.Status.Id)
                //{
                //    case 4:
                //    case 8:
                //        status = RequestStatus.ApproveCancelFail;
                //        break;
                //    default: //1 7
                //        status = RequestStatus.ApproveFail;
                //        break;
                //}
                //ApproveFailTraineeApplicationItem approveFailTraineeApplicationItem =
                //    new ApproveFailTraineeApplicationItem(traineeApplication.PKID, item.TraineeApplicationItemID,
                //                                          Account.AdminPkid,
                //                                          status, HrmisUtility._No_Account);
                //approveFailTraineeApplicationItem.Excute();
            }
            return accountID;
        }
    }
}
