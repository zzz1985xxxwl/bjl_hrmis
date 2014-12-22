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

namespace SEP.HRMIS.Bll.PositionApplications
{
    public class AddPositionApplication : Transaction
    {
        private readonly IPositionApplicationDal _PositionApplicationDal = new PositionApplicationDal();
        private readonly IEmployeeDiyProcessDal _DalEmployeeDiyProcess = new EmployeeDiyProcessDal();
        private readonly PositionApplication _PositionApplication;
        private readonly bool _IfSubmit;

        /// <summary>
        /// 
        /// </summary>
        public AddPositionApplication(PositionApplication positionApplication, bool ifSubmit)
        {
            _PositionApplication = positionApplication;
            _IfSubmit = ifSubmit;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (_IfSubmit)
                    {
                        _PositionApplication.Status = RequestStatus.Submit;
                        DiyStep currentStep = _PositionApplication.DiyProcess.FindFirstStep();
                        DiyStep nextStep = _PositionApplication.DiyProcess.FindSecondStep();
                        _PositionApplication.NextStep = nextStep;
                        _PositionApplication.PKID = _PositionApplicationDal.InsertPositionApplication(_PositionApplication);
                        PositionApplicationFlow flow = new PositionApplicationFlow(0, _PositionApplication.PKID,
                                                                                   _PositionApplication.Account,
                                                                                   DateTime.Now, RequestStatus.Submit,
                                                                                   "", _PositionApplication);
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
                        _PositionApplication.PKID = _PositionApplicationDal.InsertPositionApplication(_PositionApplication);
                    }
                    ts.Complete();
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }

        protected override void Validation()
        {
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
