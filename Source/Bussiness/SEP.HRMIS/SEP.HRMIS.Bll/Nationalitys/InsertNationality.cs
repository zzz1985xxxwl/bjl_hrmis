using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Nationalitys
{
    /// <summary>
    /// 
    /// </summary>
    public class InsertNationality : Transaction
    {
        private static IParameter _IParameter = DalFactory.DataAccess.CreateParameter();
        private readonly Nationality _Nationality;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationality"></param>
        public InsertNationality(Nationality nationality)
        {
            _Nationality = nationality;
        }

        /// <summary>
        /// for test
        /// </summary>
        /// <param name="nationality"></param>
        /// <param name="mockIParameter"></param>
        public InsertNationality(Nationality nationality, IParameter mockIParameter)
            : this(nationality)
        {
            _Nationality = nationality;
            _IParameter = mockIParameter;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _IParameter.InsertNationality(_Nationality);
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
        }

        protected override void Validation()
        {
            if (_IParameter.CountNationalityByName(_Nationality.Name) > 0)
            {
                HrmisUtility.ThrowException(HrmisUtility._Nationality_Name_Repeat);
            }
        }
    }
}