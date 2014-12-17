using System.Transactions;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PositionApp;

namespace SEP.HRMIS.Bll.PositionApplications
{
    public class DeletePositionApplication:Transaction
    {
        private readonly IPositionApplicationDal _PositionApplicationDal = DalFactory.DataAccess.CreatePositionApplication();
        private readonly int _ApplicationID;

        /// <summary>
        /// 
        /// </summary>
        public DeletePositionApplication(int applicationID)
        {
            _ApplicationID = applicationID;
        }

        protected override void Validation()
        {
            PositionApplication _OldPositionApplication =
                _PositionApplicationDal.GetPositionApplicationByPKID(_ApplicationID);
            if (_OldPositionApplication == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._PositionApplication_Not_Exit);
            }

        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _PositionApplicationDal.DeletePositionApplication(_ApplicationID);
                    ts.Complete();
                }
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }
    }
}