using System;
using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.PositionApplications
{
    public class ApproveFailPositionApplication : Transaction
    {
        private readonly int _PositionApplicationID;
        private readonly int _OperatorID;
        private readonly string _Reason;
        private readonly RequestStatus _RequestStatus;
        private PositionApplication _PositionApplication;

        private readonly IPositionApplicationDal _PositionApplicationDal = new PositionApplicationDal();
        
        /// <summary>
        /// 因为流程中断，审批不通过整张请假单
        /// </summary>
        public ApproveFailPositionApplication(int positionApplicationID, int operatorID, 
            RequestStatus requestStatus, string reason)
        {
            _PositionApplicationID = positionApplicationID;
            _RequestStatus = requestStatus;
            _Reason = reason;
            _OperatorID = operatorID;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
            _PositionApplication = _PositionApplicationDal.GetPositionApplicationByPKID(_PositionApplicationID);
            if (_PositionApplication == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._PositionApplication_Not_Exit);
            }
        }

        private string _ResultMessage;
        /// <summary>
        /// 操作结果
        /// </summary>
        public string ResultMessage
        {
            get
            {
                return _ResultMessage;
            }
            set
            {
                _ResultMessage = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _PositionApplicationDal.UpdatePositionApplicationStatusByPositionApplicationID(_PositionApplicationID,
                                                                                      _RequestStatus, 0);
                    PositionApplicationFlow flow = new PositionApplicationFlow(0, _PositionApplication.PKID,
                                                                               new Account(_OperatorID, "", ""),
                                                                               DateTime.Now, _RequestStatus, _Reason, _PositionApplication);
                    _PositionApplicationDal.InsertPositionApplicationFlow(flow);

                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}