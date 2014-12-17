using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 初始化员工信息
    /// </summary>
    public class InitEmployeeProxy: AddEmployee,ITranscationProxy
    {
        /// <summary>
        /// 初始化员工
        /// </summary>
        /// <param name="newEmployeeAccountID"></param>
        /// <param name="operatoraccount"></param>
        public InitEmployeeProxy(int newEmployeeAccountID, Account operatoraccount)
            : base(newEmployeeAccountID, operatoraccount)
        {
        }

        protected override void ExcuteSelf()
        {
            BeforeTranscation();
            base.ExcuteSelf();
            AfterTranscation();
        }

        /// <summary>
        /// 定义该Transcation处理之前要做的工作,验证权限之类的工作可以在这里处理
        /// </summary>
        public void BeforeTranscation()
        {
        }

        /// <summary>
        /// 定义该Transcation成功后要做的工作，记录日志之类的工作可以在这里处理
        /// </summary>
        public void AfterTranscation()
        {
            //todo noted by wsl transfer waiting for modify
            //MailFilter.DisableDimissionEmployeeCache();
            EmployeeCache.DisableEmployeeCache();
        }
    }
}