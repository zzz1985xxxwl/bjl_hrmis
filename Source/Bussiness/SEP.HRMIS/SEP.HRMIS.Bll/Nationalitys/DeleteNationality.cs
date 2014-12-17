using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Nationalitys
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteNationality : Transaction
    {
        private readonly IParameter _IParameter = DalFactory.DataAccess.CreateParameter();
        private readonly IEmployee _IEmployee = DalFactory.DataAccess.CreateEmployee();
        private readonly int _NationalityID;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pkid"></param>
        public DeleteNationality(int pkid)
        {
            _NationalityID = pkid;
        }

        /// <summary>
        /// for test
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="mockIParameter"></param>
        public DeleteNationality(int pkid, IParameter mockIParameter, IEmployee mockIEmployee)
            : this(pkid)
        {
            _NationalityID = pkid;
            _IParameter = mockIParameter;
            _IEmployee = mockIEmployee;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _IParameter.DeleteNationality(_NationalityID);
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }

        protected override void Validation()
        {
            if (_IEmployee.CountEmployeeByNationalityID(_NationalityID) > 0)
            {
                HrmisUtility.ThrowException(HrmisUtility._Nationality_HasBeenUsed);
            }
        }
    }
}

