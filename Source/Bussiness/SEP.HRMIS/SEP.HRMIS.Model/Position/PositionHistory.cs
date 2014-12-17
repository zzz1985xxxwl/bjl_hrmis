using System;
using SEP.Model.Accounts;
using SEP.Model.Positions;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class PositionHistory
    {
        private Position _Position;
        private DateTime _OperationTime;
        private int _PKID;
        private Account _Operator;

        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        /// <summary>
        /// 职位
        /// </summary>
        public Position Position
        {
            get{return _Position;}
            set{_Position = value;}
        }



        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime
        {
            get { return _OperationTime; }
            set { _OperationTime = value; }
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public Account Operator 
        {
            get { return _Operator; }
            set { _Operator = value; }
        }

    }
}
