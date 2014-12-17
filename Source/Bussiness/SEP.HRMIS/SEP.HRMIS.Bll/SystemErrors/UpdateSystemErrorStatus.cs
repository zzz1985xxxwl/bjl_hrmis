//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: UpdateSystemErrorStatus.cs
// Creater:  Xue.wenlong
// Date:  2009-10-20
// Resume:
// ----------------------------------------------------------------

using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.SystemError;

namespace SEP.HRMIS.Bll.SystemErrors
{
    /// <summary>
    /// </summary>
    public class UpdateSystemErrorStatus : Transaction
    {
        private readonly SystemError _SystemError;
        private readonly ISystemError _ISystemError = DalFactory.DataAccess.CreateSystemError();

        /// <summary>
        /// 
        /// </summary>
        public UpdateSystemErrorStatus(SystemError systemError)
        {
            _SystemError = systemError;
        }

        /// <summary>
        /// for test
        /// </summary>
        public UpdateSystemErrorStatus(SystemError systemError, ISystemError isystemError) : this(systemError)
        {
            _ISystemError = isystemError;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            if (_ISystemError.GetSystemErrorByTypeAndMarkID(_SystemError.ErrorType, _SystemError.MarkID) == null)
            {
                _SystemError.ErrorStatus = ErrorStatus.Ignore;
                _ISystemError.SystemErrorInsert(_SystemError);
            }
            else
            {
                _ISystemError.DeleteSystemErrorByTypeAndMarkID(_SystemError.ErrorType, _SystemError.MarkID);
            }
        }
    }
}