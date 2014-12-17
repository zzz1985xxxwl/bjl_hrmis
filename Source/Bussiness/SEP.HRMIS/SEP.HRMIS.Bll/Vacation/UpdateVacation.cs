//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateVacation.cs
// Creater:  Xue.wenlong
// Date:  2009-01-12
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class UpdateVacation:Transaction
    {
        private static  IVacation _VacationDal = DalFactory.DataAccess.CreateVacation();
        private readonly Model.Vacation _Vacation;
        public UpdateVacation(Model.Vacation vacation)
        {
            _Vacation = vacation;
        }

        #region for test

        public UpdateVacation(Model.Vacation vacation, IVacation mockVacation)
            : this(vacation)
        {
            _VacationDal = mockVacation;
        }

        #endregion

        protected override void Validation()
        {
            //�ø����Ƿ����
            if (_VacationDal.GetVacationByVacationID(_Vacation.VacationID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Vacation_Not_Exist);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _VacationDal.Update(_Vacation);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
            
        }
    }
}