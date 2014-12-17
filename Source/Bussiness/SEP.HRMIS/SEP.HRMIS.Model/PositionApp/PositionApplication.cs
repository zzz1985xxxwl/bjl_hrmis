using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using SEP.Model.Positions;

namespace SEP.HRMIS.Model.PositionApp
{
    [Serializable]
    public class PositionApplication
    {
        private int _PKID;
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        private Account _Account = new Account();
        public Account Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        private RequestStatus _Status = RequestStatus.All;
        /// <summary>
        /// 流程状态
        /// </summary>
        public RequestStatus Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private AppType _Type = AppType.All;
        /// <summary>
        /// 申请类型 新增变更
        /// </summary>
        public AppType Type
        {
            get { return _Type; }
            set { _Type = value;}
        }

        private int _IsPublish;
        /// <summary>
        /// 是否已经发布
        /// </summary>
        public int IsPublish
        {
            get { return _IsPublish; }
            set { _IsPublish = value; }
        }

        private Position _Position = new Position();
        /// <summary>
        /// 职位信息
        /// </summary>
        public Position Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        #region 流程相关

        private DiyProcess _DiyProcess = new DiyProcess();
        public DiyProcess DiyProcess
        {
            get { return _DiyProcess; }
            set { _DiyProcess = value; }
        }

        private DiyStep _CurrentStep = new DiyStep(0);
        public DiyStep CurrentStep
        {
            get { return _CurrentStep; }
            set { _CurrentStep = value; }
        }

        private DiyStep _NextStep = new DiyStep(0);
        public DiyStep NextStep
        {
            get { return _NextStep; }
            set { _NextStep = value; }
        }

        private List<PositionApplicationFlow> _PositionApplicationFlowList = new List<PositionApplicationFlow>();
        public List<PositionApplicationFlow> PositionApplicationFlowList
        {
            get { return _PositionApplicationFlowList; }
            set { _PositionApplicationFlowList = value; }
        }
        #endregion

        /// <summary>
        /// 除了新增状态直接删除，其他都可以被自动取消
        /// </summary>
        public bool IfAutoCancel
        {
            get
            {
                if (_Status != null && _Status != RequestStatus.New)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
