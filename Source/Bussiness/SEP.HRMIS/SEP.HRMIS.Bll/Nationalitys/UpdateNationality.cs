using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.Nationalitys
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateNationality : Transaction
    {
        private readonly IParameter _IParameter = new ParameterDal();
        private readonly IEmployee _IEmployee = new EmployeeDal();
        private readonly Nationality _Nationality;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationality"></param>
        public UpdateNationality(Nationality nationality)
        {
            _Nationality = nationality;
        }

        /// <summary>
        /// for test
        /// </summary>
        /// <param name="nationality"></param>
        /// <param name="mockIParameter"></param>
        public UpdateNationality(Nationality nationality, IParameter mockIParameter, IEmployee mockIEmployee)
            : this(nationality)
        {
            _Nationality = nationality;
            _IParameter = mockIParameter;
            _IEmployee = mockIEmployee;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _IParameter.UpdateNationality(_Nationality);
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }

        protected override void Validation()
        {
            if (_IParameter.CountNationalityByNameDiffPKID(_Nationality.ParameterID, _Nationality.Name) > 0)
            {
                HrmisUtility.ThrowException(HrmisUtility._Nationality_Name_Repeat);
            }
            if (_IEmployee.CountEmployeeByNationalityID(_Nationality.ParameterID) > 0)
            {
                HrmisUtility.ThrowException(HrmisUtility._Nationality_HasBeenUsed);
            }
        }
    }
}
