//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: DeleteFileCargo.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-09
// Resume: 
// ----------------------------------------------------------------

using System.IO;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.Bll.FileCargos
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteFileCargo : Transaction
    {
        private readonly int _FileCargoID;
        private static readonly IFileCargo _FileCargoDal = DalFactory.DataAccess.CreateFileCargo();

        /// <summary>
        /// 
        /// </summary>
        public DeleteFileCargo(int fileCargoID)
        {
            _FileCargoID = fileCargoID;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            string filelocation = _FileCargoDal.GetFileCargoByFileCargoID(_FileCargoID).File;
            if (File.Exists(filelocation))
            {
                File.Delete(filelocation);
            }
            _FileCargoDal.Delete(_FileCargoID);
        }
    }
}