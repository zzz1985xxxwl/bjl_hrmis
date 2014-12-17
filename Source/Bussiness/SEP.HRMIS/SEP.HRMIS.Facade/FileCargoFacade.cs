//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: FileCargoFacade.cs
// Creater: Xue.wenlong
// CreateDate: 2009-07-09
// Resume: 
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Bll.FileCargos;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class FileCargoFacade : IFileCargoFacade
    {
        public void AddFileCargo(FileCargo fileCargo)
        {
            new AddFileCargo(fileCargo).Excute();
        }

        public void UpdateFileCargo(FileCargo fileCargo)
        {
            new UpdateFileCargo(fileCargo).Excute();
        }

        public void DeleteFileCargo(int fileCargoid)
        {
            new DeleteFileCargo(fileCargoid).Excute();
        }

        public List<FileCargo> GetFileCargoByAccountID(int accountID)
        {
            return new GetFileCargo().GetFileCargoByAccountID(accountID);
        }

        public FileCargo GetFileCargoByFileCargoID(int FileCargoID)
        {
            return new GetFileCargo().GetFileCargoByFileCargoID(FileCargoID);
        }
    }
}