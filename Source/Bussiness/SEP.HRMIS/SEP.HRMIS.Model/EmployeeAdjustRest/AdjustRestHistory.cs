using System;
using SEP.HRMIS.Model.Enum;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.EmployeeAdjustRest
{
    /// <summary>
    /// ������ʷ
    /// </summary>
    [Serializable]
    public class AdjustRestHistory
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public AdjustRestHistory()
        {
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        public AdjustRestHistory(int adjustRestHistoryID, DateTime occurTime, 
            decimal changeHours, AdjustRestHistoryTypeEnum adjustRestHistoryTypeEnum)
        {
            _AdjustRestHistoryID = adjustRestHistoryID;
            _OccurTime = occurTime;
            //_ResultAdjustRestHours = resultAdjustRestHours;
            _ChangeHours = changeHours;
            _AdjustRestHistoryTypeEnum = adjustRestHistoryTypeEnum;
        }

        private int _AdjustRestHistoryID;
        /// <summary>
        /// PKID
        /// </summary>
        public int AdjustRestHistoryID
        {
            get { return _AdjustRestHistoryID; }
            set { _AdjustRestHistoryID = value; }
        }
        private DateTime _OccurTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime OccurTime
        {
            get { return _OccurTime; }
            set { _OccurTime = value; }
        }
        //private decimal _ResultAdjustRestHours;
        ///// <summary>
        ///// ��ǰ��������ʣ�����
        ///// </summary>
        //public decimal ResultAdjustRestHours
        //{
        //    get { return _ResultAdjustRestHours; }
        //    set { _ResultAdjustRestHours = value; }
        //}
        private decimal _ChangeHours;
        /// <summary>
        /// �䶯Сʱ��������Ϊ������Ϊ��
        /// Ϊ����ʾ�Ӱ��ȡ/�ֹ������˶���ʣ�����
        /// Ϊ����ʾ������ȥ/�ֹ������˶���ʣ�����
        /// </summary>
        public decimal ChangeHours
        {
            get { return _ChangeHours; }
            set { _ChangeHours = value; }
        }
        private Account _Operator;
        /// <summary>
        /// ������
        /// </summary>
        public Account Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        private AdjustRestHistoryTypeEnum _AdjustRestHistoryTypeEnum;
        /// <summary>
        /// ���ִ˴���ʷ���ɵ���Ϣ��Դ
        /// </summary>
        public AdjustRestHistoryTypeEnum AdjustRestHistoryTypeEnum
        {
            get { return _AdjustRestHistoryTypeEnum; }
            set { _AdjustRestHistoryTypeEnum = value; }
        }
        private int _RelevantID;
        /// <summary>
        /// ����ǼӰ�������ɵģ����¼��ص�ID
        /// </summary>
        public int RelevantID
        {
            get { return _RelevantID; }
            set { _RelevantID = value; }
        }
        private string _Remark;
        /// <summary>
        /// ��ע������˵������ԭ��
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}