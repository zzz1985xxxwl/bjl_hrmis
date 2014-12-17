using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.DiyProcesss
{
    /// <summary>
    /// �Զ��������еĲ���
    /// </summary>
    [Serializable]
    public class DiyStep
    {
        #region ˽�б���

        private int _DiyStepID;
        private string _Status;
        private OperatorType _OperatorType;
        private int _OperatorID;
        private DiyStep _NextDiyStep;
        private List<Account> _MailAccount;
        private string _MailAccountShow;
        private List<ProcessType> _MailRole;

        private bool _IfSystem;
        private bool _IfLast;

        #endregion

        #region ���캯��

        /// <summary>
        /// 
        /// </summary>
        public DiyStep(int diyStepID)
        {
            _DiyStepID = diyStepID;
        }
        /// <summary>
        /// 
        /// </summary>
        public DiyStep(int diyStepID, string status, OperatorType type, int operatorID)
        {
            _DiyStepID = diyStepID;
            _Status = status;
            _OperatorType = type;
            _OperatorID = operatorID;
            _MailAccount = new List<Account>();
        }

        #endregion

        #region ����

        /// <summary>
        /// ������
        /// </summary>
        public int OperatorID
        {
            get { return _OperatorID; }
            set { _OperatorID = value; }
        }

        /// <summary>
        /// ��һ������
        /// </summary>
        public DiyStep NextDiyStep
        {
            get { return _NextDiyStep; }
            set { _NextDiyStep = value; }
        }

        /// <summary>
        /// ��ǰ״̬
        /// </summary>
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// ����������
        /// </summary>
        public OperatorType OperatorType
        {
            get { return _OperatorType; }
            set { _OperatorType = value; }
        }

        /// <summary>
        /// Mail֪ͨ
        /// </summary>
        public List<Account> MailAccount
        {
            get { return _MailAccount; }
            set { _MailAccount = value; }
        }


        /// <summary>
        /// Mail֪ͨ
        /// </summary>
        public List<ProcessType> MailRole
        {
            get { return _MailRole; }
            set { _MailRole = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int DiyStepID
        {
            get { return _DiyStepID; }
            set { _DiyStepID = value; }
        }

        /// <summary>
        /// ������ʾ
        /// </summary>
        public string MailAccountShow
        {
            get
            {
                _MailAccountShow = "";
                if (MailAccount != null && MailAccount.Count > 0)
                {
                    foreach (Account account in _MailAccount)
                    {
                        _MailAccountShow += account.Name + ",";
                    }
                    _MailAccountShow = _MailAccountShow.Remove(_MailAccountShow.Length - 1);
                }
                return _MailAccountShow;
            }
            set
            {
                _MailAccountShow = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IfSystem
        {
            get { return _IfSystem; }
            set { _IfSystem = value; }
        }

        /// <summary>
        /// �Ƿ������һ��������ǣ���������
        /// </summary>
        public bool IfLast
        {
            get { return _IfLast; }
            set { _IfLast = value; }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Equal(DiyStep step)
        {
            if (OperatorType.Id == step.OperatorType.Id && OperatorID == step.OperatorID)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        public static bool Contains(List<DiyStep> steps, DiyStep step)
        {
            foreach (DiyStep diyStep in steps)
            {
                if (diyStep.Equal(step))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
