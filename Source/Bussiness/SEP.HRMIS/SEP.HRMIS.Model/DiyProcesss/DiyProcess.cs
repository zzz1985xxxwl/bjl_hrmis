using System;
using System.Collections.Generic;
using System.Text;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.DiyProcesss
{
    /// <summary>
    /// �Զ�������
    /// </summary>
   [Serializable]
    public class DiyProcess
    {
        #region ˽�б���

        private int _ID;
        private string _Name;
        private string _Remark;
        private ProcessType _Type;
        private List<DiyStep> _DiySteps;

        #endregion

        #region ���캯��

        /// <summary>
        /// �Զ�������
        /// </summary>
        public DiyProcess()
        {
            DiySteps = new List<DiyStep>();
        }

        /// <summary>
        /// �Զ�������
        /// </summary>
        public DiyProcess(int id,string name,string remark,ProcessType type)
        {
            _ID = id;
            _Name = name;
            _Remark = remark;
            _Type = type;
            DiySteps = new List<DiyStep>();
        }

        #endregion

        #region ����

        /// <summary>
        /// ���̱��
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public List<DiyStep> DiySteps
        {
            get { return _DiySteps; }
            set { _DiySteps = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public ProcessType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        #endregion

        #region ����

        /// <summary>
        /// �ҵ������̵ĵ�һ������������Ϊ���ύ��
        /// </summary>
        /// <returns></returns>
        public DiyStep FindFirstStep()
        {
            if (DiySteps != null)
            {
                return DiySteps[0];
            }
            return null;
        }

        /// <summary>
        /// �ҵ������̵ĵڶ�������������Ϊ����ˡ�
        /// </summary>
        /// <returns></returns>
        public DiyStep FindSecondStep()
        {
            if (DiySteps != null && DiySteps.Count > 1)
            {
                return DiySteps[1];
            }
            return null;
        }

        /// <summary>
        /// �ҵ���ȡ�����������̵ĵ�һ��
        /// </summary>
        /// <returns></returns>
        public DiyStep FindCancelNextStep()
        {
            return FindNextStep(FindCancelStep().DiyStepID);
        }

        /// <summary>
        /// �ҵ���ȡ�����������̵ĵ�һ��
        /// </summary>
        /// <returns></returns>
        public DiyStep FindCancelStep()
        {
            if (DiySteps != null)
            {
                for (int i = 0; i < DiySteps.Count; i++)
                {
                    if (DiySteps[i].Status == "ȡ��")
                    {
                        return DiySteps[i];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// �ҵ���һ��
        /// </summary>
        /// <param name="id">��ǰ�����id</param>
        /// <returns></returns>
        public DiyStep FindNextStep(int id)
        {
            if (DiySteps != null)
            {
                for (int i = 0; i < DiySteps.Count; i++)
                {
                    if ((DiySteps[i].DiyStepID == id) && (i <= DiySteps.Count - 2))
                    {
                        return DiySteps[i + 1];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// �ҵ�ĳһ��
        /// </summary>
        /// <param name="id">��ǰ�����id</param>
        /// <returns></returns>
        public DiyStep FindStep(int id)
        {
            if (DiySteps != null)
            {
                for (int i = 0; i < DiySteps.Count; i++)
                {
                    if (DiySteps[i].DiyStepID == id)
                    {
                        return DiySteps[i];
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// ��DiyProcess����ת��Ϊ�ַ���
        /// </summary>
        public static string ConvertToString(DiyProcess diyProcess)
        {
            string process = "";
            StringBuilder processtext = new StringBuilder();
            if (diyProcess != null && diyProcess.DiySteps != null && diyProcess.DiySteps.Count > 0)
            {
                foreach (DiyStep step in diyProcess.DiySteps)
                {
                    processtext.Append(step.DiyStepID);
                    processtext.Append("|");
                    processtext.Append(step.Status);
                    processtext.Append("|");
                    processtext.Append(step.OperatorType.Id);
                    processtext.Append("|");
                    processtext.Append(step.OperatorID);
                    processtext.Append("|");

                    foreach (Account account in step.MailAccount)
                    {
                        processtext.Append(account.Id);
                        processtext.Append(",");
                    }
                    processtext.Append("|");

                    foreach (ProcessType role in step.MailRole)
                    {
                        processtext.Append(role.Id);
                        processtext.Append(",");
                    }

                    processtext.Append(";");
                }
            }
            if (processtext.Length > 0)
            {
                process = processtext.ToString().Substring(0, processtext.Length - 1);
            }
            return process;
        }

        /// <summary>
        /// ���ַ���ת��ΪDiyProcess����
        /// </summary>
        public static DiyProcess ConvertToObject(string strProcess)
        {
            DiyProcess process = new DiyProcess();
            List<DiyStep> diyStepList = new List<DiyStep>();
            string[] diySteps = strProcess.Split(';');
            foreach (string diyStep in diySteps)
            {
                string[] steps = diyStep.Split('|');
                if (steps.Length > 5)
                {
                    DiyStep step =
                        new DiyStep(Convert.ToInt32(steps[0]), steps[1],
                                    new OperatorType(Convert.ToInt32(steps[2]),
                                                     OperatorType.FindOperatorTypeByID(Convert.ToInt32(steps[2]))),
                                    Convert.ToInt32(steps[3]));

                    string[] mailAccounts = steps[4].Split(',');
                    foreach (string mailAccount in mailAccounts)
                    {
                        if (!string.IsNullOrEmpty(mailAccount))
                        {
                            step.MailAccount.Add(new Account(Convert.ToInt32(mailAccount), "", ""));
                        }
                    }

                    string[] mailRoles = steps[5].Split(',');
                    foreach (string mailRole in mailRoles)
                    {
                        if (!string.IsNullOrEmpty(mailRole))
                        {
                            step.MailRole.Add(ProcessType.FindProcessTypeByProcessTypeID(Convert.ToInt32(mailRole)));
                        }
                    }

                    diyStepList.Add(step);
                }
            }

            process.DiySteps = diyStepList;
            return process;
        }
        #endregion

        /// <summary>
        /// ���ַ���ת��ΪDiyProcess����
        /// </summary>
        public static DiyProcess ConvertToObject_DiyProcessDal(string strProcess)
        {
            DiyProcess process = new DiyProcess();
            List<DiyStep> diyStepList = new List<DiyStep>();
            string[] diySteps = strProcess.Split(';');
            foreach (string diyStep in diySteps)
            {
                string[] steps = diyStep.Split('|');
                if (steps.Length > 4)
                {
                    DiyStep step =
                        new DiyStep(Convert.ToInt32(steps[0]), steps[1],
                                    new OperatorType(Convert.ToInt32(steps[2]),
                                                     OperatorType.FindOperatorTypeByID(Convert.ToInt32(steps[2]))),
                                    Convert.ToInt32(steps[3]));

                    string[] mailAccounts = steps[4].Split(',');
                    foreach (string mailAccount in mailAccounts)
                    {
                        if (!string.IsNullOrEmpty(mailAccount))
                        {
                            step.MailAccount.Add(new Account(Convert.ToInt32(mailAccount), "", ""));
                        }
                    }

                    diyStepList.Add(step);
                }
            }

            process.DiySteps = diyStepList;
            return process;
        }
    }



}
