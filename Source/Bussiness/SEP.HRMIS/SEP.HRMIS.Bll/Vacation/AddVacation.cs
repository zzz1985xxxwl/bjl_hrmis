//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: AddVacation.cs
// Creater:  Xue.wenlong
// Date:  2009-01-12
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    public class AddVacation : Transaction
    {
        private static IVacation _VacationDal = new VacationDal();
        private readonly Model.Vacation _Vacation;

        public AddVacation(Model.Vacation vacation)
        {
            _Vacation = vacation;
        }

        #region for test

        public AddVacation(Model.Vacation vacation, IVacation mockVacation)
            : this(vacation)
        {
            _VacationDal = mockVacation;
        }

        #endregion

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _VacationDal.Insert(_Vacation);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}