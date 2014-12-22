using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.DiyProcesses;
using SEP.HRMIS.Bll.PositionApplications.MailAndPhone;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.PositionApplications
{
    public class UpdatePositionApplication : Transaction
    {
        private readonly IPositionApplicationDal _PositionApplicationDal = new PositionApplicationDal();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = new EmployeeDiyProcessDal();
        private readonly PositionApplication _PositionApplication;
        private readonly bool _IfSubmit;
        private readonly PositionApplication _OldPositionApplication;

        /// <summary>
        /// 
        /// </summary>
        public UpdatePositionApplication(PositionApplication positionApplication, bool ifSubmit)
        {
            _PositionApplication = positionApplication;
            _IfSubmit = ifSubmit;
            _OldPositionApplication =
                _PositionApplicationDal.GetPositionApplicationByPKID(_PositionApplication.PKID);
        }

        /// <summary>
        /// 修改
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (_OldPositionApplication.IfAutoCancel)
                    {
                        AutoCancelPositionApplication();
                    }
                    if (_IfSubmit)
                    {
                        _PositionApplication.Status = RequestStatus.Submit;
                        DiyStep currentStep = _PositionApplication.DiyProcess.FindFirstStep();
                        DiyStep nextStep = _PositionApplication.DiyProcess.FindSecondStep();
                        _PositionApplication.NextStep = nextStep;
                        _PositionApplicationDal.UpdatePositionApplication(_PositionApplication);
                        PositionApplicationFlow flow = new PositionApplicationFlow(0, _PositionApplication.PKID,
                                                                                   _PositionApplication.Account,
                                                                                   DateTime.Now, RequestStatus.Submit, "", _PositionApplication);
                        _PositionApplicationDal.InsertPositionApplicationFlow(flow);

                        List<string> accounts =
                            new GetDiyProcess(_DalEmployeeDiyProcess).GetAccountMailListByDiyProcessIDAccountID(
                                currentStep, _PositionApplication.Account.Id);
                        new PositionApplicationMailAndPhoneDelegate().SubmitOperation(_PositionApplication.PKID, accounts, nextStep);
                    }
                    else
                    {
                        _PositionApplication.Status = RequestStatus.New;
                        _PositionApplication.NextStep = _PositionApplication.DiyProcess.FindFirstStep();
                        _PositionApplicationDal.UpdatePositionApplication(_PositionApplication);
                    }
                    ts.Complete();
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }

        private void AutoCancelPositionApplication()
        {
            _PositionApplication.Status = RequestStatus.ApproveCancelPass;
            PositionApplicationFlow flow =
                new PositionApplicationFlow(0, _PositionApplication.PKID, new Account(-9, "", ""),
                                            DateTime.Now, RequestStatus.ApproveCancelPass,
                                            _PositionApplication.Account.Name + "已经重新编辑职位申请" +
                                            _OldPositionApplication.PKID + "，系统自动批准取消。", _PositionApplication);
            _PositionApplicationDal.InsertPositionApplicationFlow(flow);
        }

        /// <summary>
        /// 有效性判断
        /// </summary>
        protected override void Validation()
        {
            if (_OldPositionApplication == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._PositionApplication_Not_Exit);
            }

            _PositionApplication.DiyProcess =
                _DalEmployeeDiyProcess.GetDiyProcessByProcessTypeAndAccountID(ProcessType.PositionApp,
                                                                              _PositionApplication.Account.Id);
            if (_PositionApplication.DiyProcess == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._No_PositionApplication_DiyProcess);
            }
        }
    }
}