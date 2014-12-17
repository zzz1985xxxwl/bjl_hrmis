using System.IO;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.FileCargos
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateFileCargo : Transaction
    {
        private readonly FileCargo _FileCargo;
        private static readonly IFileCargo _FileCargoDal = DalFactory.DataAccess.CreateFileCargo();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileCargo"></param>
        public UpdateFileCargo(FileCargo fileCargo)
        {
            _FileCargo = fileCargo;
        }

        protected override void Validation()
        {
            
        }

        protected override void ExcuteSelf()
        {         
            string filelocation = _FileCargoDal.GetFileCargoByFileCargoID(_FileCargo.FileCargoID).File;
            if (!string.IsNullOrEmpty(filelocation) && !string.IsNullOrEmpty(_FileCargo.File))
            {
                if(File.Exists(filelocation))
                {
                    File.Delete(filelocation);
                }
            }
            else if (!string.IsNullOrEmpty(filelocation) && string.IsNullOrEmpty(_FileCargo.File))
            {
                _FileCargo.File = filelocation;
            }
            _FileCargoDal.Update(_FileCargo);
        }
    }
}