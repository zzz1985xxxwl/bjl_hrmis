using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.DiyProcesses
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteDiyProcess : Transaction
    {
        private readonly IDiyProcessDal _IDiyProcessDal = DalFactory.DataAccess.CreateDiyProcessDal();
        private readonly IEmployeeDiyProcessDal _IEmployeeDiyProcessDal = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();

        private readonly int _DiyProcessID;

        /// <summary>
        /// 
        /// </summary>
        public DeleteDiyProcess(int diyProcessID)
        {
            _DiyProcessID = diyProcessID;
        }

        /// <summary>
        /// 
        /// </summary>
        public DeleteDiyProcess(int diyProcessID, IDiyProcessDal mockIDiyProcessDal, IEmployeeDiyProcessDal mockIEmployeeDiyProcessDal)
        {
            _DiyProcessID = diyProcessID;
            _IDiyProcessDal = mockIDiyProcessDal;
            _IEmployeeDiyProcessDal = mockIEmployeeDiyProcessDal;
        }

        protected override void Validation()
        {
            if (_IEmployeeDiyProcessDal.CountAccountByDiyProcessID(_DiyProcessID) > 0)
            {
                HrmisUtility.ThrowException(HrmisUtility._DiyProcess_Used);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _IDiyProcessDal.DeleteDiyProcess(_DiyProcessID);

            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}

