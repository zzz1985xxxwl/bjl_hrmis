using System;
using SEP.HRMIS.Model.Enum;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.EmployeeAdjustRest
{
    /// <summary>
    /// 调休历史
    /// </summary>
    [Serializable]
    public class AdjustRestHistory
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AdjustRestHistory()
        {
        }
        /// <summary>
        /// 构造函数
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
        /// 生成时间
        /// </summary>
        public DateTime OccurTime
        {
            get { return _OccurTime; }
            set { _OccurTime = value; }
        }
        //private decimal _ResultAdjustRestHours;
        ///// <summary>
        ///// 当前结算结果，剩余调休
        ///// </summary>
        //public decimal ResultAdjustRestHours
        //{
        //    get { return _ResultAdjustRestHours; }
        //    set { _ResultAdjustRestHours = value; }
        //}
        private decimal _ChangeHours;
        /// <summary>
        /// 变动小时数，可能为正可能为负
        /// 为正表示加班获取/手工调整了多少剩余调休
        /// 为负表示调休用去/手工调整了多少剩余调休
        /// </summary>
        public decimal ChangeHours
        {
            get { return _ChangeHours; }
            set { _ChangeHours = value; }
        }
        private Account _Operator;
        /// <summary>
        /// 操作人
        /// </summary>
        public Account Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }
        private AdjustRestHistoryTypeEnum _AdjustRestHistoryTypeEnum;
        /// <summary>
        /// 区分此次历史生成的信息来源
        /// </summary>
        public AdjustRestHistoryTypeEnum AdjustRestHistoryTypeEnum
        {
            get { return _AdjustRestHistoryTypeEnum; }
            set { _AdjustRestHistoryTypeEnum = value; }
        }
        private int _RelevantID;
        /// <summary>
        /// 如果是加班调休生成的，则记录相关的ID
        /// </summary>
        public int RelevantID
        {
            get { return _RelevantID; }
            set { _RelevantID = value; }
        }
        private string _Remark;
        /// <summary>
        /// 备注，文字说明调整原因
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}