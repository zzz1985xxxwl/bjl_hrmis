using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.Bll
{
    ///<summary>
    /// 保存员工diy设置
    ///</summary>
    public class SaveEmployeeDiyProcess:Transaction
    {
        private static readonly IEmployeeDiyProcessDal _DiyProcessDal = DalFactory.DataAccess.CreateEmployeeDiyProcessDal();
        private readonly int _AccountId;
        private readonly List<DiyProcess> _diyProcesses;

        ///<summary>
        ///</summary>
        ///<param name="accountId"></param>
        ///<param name="diyProcesses"></param>
        public SaveEmployeeDiyProcess(int accountId,List<DiyProcess> diyProcesses)
        {
            _AccountId = accountId;
            _diyProcesses = diyProcesses;
        }

        protected override void Validation()
        {
     
        }

        protected override void ExcuteSelf()
        {
            foreach(DiyProcess process in _diyProcesses)
            {
                _DiyProcessDal.InsertEmployeeDiyProcess(_AccountId, process);
            }
        }
    }
}
