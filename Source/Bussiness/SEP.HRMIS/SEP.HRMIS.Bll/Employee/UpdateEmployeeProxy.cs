//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateEmployeeProxy.cs
// ������: �ߺ�
// ��������: 2008-11-11
// ����: �޸�Ա���Ĵ�����,�ڲ��ı�ԭ��������ǰ���£�����һЩ
//       �������ԵĹ���
// ----------------------------------------------------------------

using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ����Ա����Ϣ
    /// </summary>
    public class UpdateEmployeeProxy : UpdateEmployee, ITranscationProxy
    {
        /// <summary>
        /// ����Ա����Ϣ
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operatoraccount"></param>
        public UpdateEmployeeProxy(Employee employee, Account operatoraccount)
            : base(employee, operatoraccount)
        {
        }

        protected override void ExcuteSelf()
        {
            BeforeTranscation();
            base.ExcuteSelf();
            AfterTranscation();
        }
        #region ITranscationProxy ��Ա


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
        #endregion
    }
}