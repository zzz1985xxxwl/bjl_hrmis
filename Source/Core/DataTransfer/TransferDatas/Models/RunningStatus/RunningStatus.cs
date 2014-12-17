using System;
using System.Collections.Generic;
using System.Text;

namespace TransferDatas
{
    public abstract class RunningStatus
    {
        private string _StartTime;
        private string _EndTime;
        private Status _Status;
        private StringBuilder _RunningDetails = new StringBuilder();

        protected abstract string DefineNameOfOperation();
        List<IStatusChangeObserver> allOverservers = new List<IStatusChangeObserver>();

        #region ����

        /// <summary>
        /// ���β���������
        /// </summary>
        public string OperationDescription
        {
            get
            {
                return DefineNameOfOperation();
            }
        }

        /// <summary>
        /// ���β�����ʼʱ��
        /// </summary>
        public string StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                _StartTime = value;
            }
        }

        /// <summary>
        /// ���β�������ʱ��
        /// </summary>
        public string EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                _EndTime = value;
            }
        }

        /// <summary>
        /// ���β���״̬
        /// </summary>
        public Status Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        /// <summary>
        /// ���е�����ϸ����Ϣ
        /// </summary>
        public string RunningDetails
        {
            get
            {
                return _RunningDetails.ToString();
            }
        }


        #endregion

        #region ����

        public void AddInformationLine(string theInfo)
        {
            _RunningDetails.AppendLine(theInfo);
            InfoTheObservers(theInfo);
        }

        public void AddStatusChangeObserver(IStatusChangeObserver aNewObserver)
        {
            if (!allOverservers.Contains(aNewObserver))
            {
                allOverservers.Add(aNewObserver);
            }
        }

        public static string StatusToString(Status theStatus)
        {
            switch(theStatus)
            {
                case Status.NotRun:
                    return "δ����";
                case Status.Running:
                    return "��������";
                case Status.Success:
                    return "���гɹ�";
                case Status.Failed:
                    return "����ʧ��";
                case Status.Error:
                    return "���д���";
                default:
                    return "������״̬������ϵ����Ա�鿴����";
            }
        }

        #endregion

        #region ˽�з���

        private void InfoTheObservers(string theNewInfo)
        {
            foreach(IStatusChangeObserver anObserver in allOverservers)
            {
                anObserver.NewInfoAdded(theNewInfo);
            }
        }

        #endregion

    }

    public enum Status 
    {
        NotRun,//δ����
        Running,//��������
        Success,//���гɹ�
        Failed,//����ʧ��
        Error,//���д���
    }
}