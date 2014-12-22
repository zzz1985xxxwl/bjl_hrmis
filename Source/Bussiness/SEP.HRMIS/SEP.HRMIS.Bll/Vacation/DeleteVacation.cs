//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DeleteVacation.cs
// Creater:  Xue.wenlong
// Date:  2009-01-12
// Resume:
// ---------------------------------------------------------------


using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    public class DeleteVacation : Transaction
    {
        private static IVacation _VacationDal = new VacationDal();
        private readonly int _VacationID;

        public DeleteVacation(int vacationID)
        {
            _VacationID = vacationID;
        }

        #region for test

        public DeleteVacation(int vacationID, IVacation mockVacation)
            : this(vacationID)
        {
            _VacationDal = mockVacation;
        }

        #endregion

        protected override void Validation()
        {
            //该附件是否存在
            if (_VacationDal.GetVacationByVacationID(_VacationID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Vacation_Not_Exist);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _VacationDal.DeleteVacationByVacationID(_VacationID);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}