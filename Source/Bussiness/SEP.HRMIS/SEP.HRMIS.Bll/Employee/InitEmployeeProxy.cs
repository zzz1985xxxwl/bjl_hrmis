using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ��ʼ��Ա����Ϣ
    /// </summary>
    public class InitEmployeeProxy: AddEmployee,ITranscationProxy
    {
        /// <summary>
        /// ��ʼ��Ա��
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
        /// �����Transcation����֮ǰҪ���Ĺ���,��֤Ȩ��֮��Ĺ������������ﴦ��
        /// </summary>
        public void BeforeTranscation()
        {
        }

        /// <summary>
        /// �����Transcation�ɹ���Ҫ���Ĺ�������¼��־֮��Ĺ������������ﴦ��
        /// </summary>
        public void AfterTranscation()
        {
            //todo noted by wsl transfer waiting for modify
            //MailFilter.DisableDimissionEmployeeCache();
            EmployeeCache.DisableEmployeeCache();
        }
    }
}