//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: DeleteFileCargo.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-09
// Resume: 
// ----------------------------------------------------------------
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.FileCargos
{
    /// <summary>
    /// 
    /// </summary>
    public class AddFileCargo:Transaction
    {
        private readonly FileCargo _FileCargo;
        private static readonly IFileCargo _FileCargoDal = new FileCargoDal();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileCargo"></param>
        public AddFileCargo(FileCargo fileCargo)
        {
            _FileCargo = fileCargo;
        }

        protected override void Validation()
        {
            
        }

        protected override void ExcuteSelf()
        {
            _FileCargoDal.Insert(_FileCargo);
        }
    }
}