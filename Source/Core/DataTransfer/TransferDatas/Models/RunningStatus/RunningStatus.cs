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

        #region 属性

        /// <summary>
        /// 本次操作的描述
        /// </summary>
        public string OperationDescription
        {
            get
            {
                return DefineNameOfOperation();
            }
        }

        /// <summary>
        /// 本次操作起始时间
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
        /// 本次操作结束时间
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
        /// 本次操作状态
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
        /// 运行的最详细的信息
        /// </summary>
        public string RunningDetails
        {
            get
            {
                return _RunningDetails.ToString();
            }
        }


        #endregion

        #region 方法

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
                    return "未运行";
                case Status.Running:
                    return "正在运行";
                case Status.Success:
                    return "运行成功";
                case Status.Failed:
                    return "运行失败";
                case Status.Error:
                    return "运行错误";
                default:
                    return "非正常状态，请联系管理员查看详情";
            }
        }

        #endregion

        #region 私有方法

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
        NotRun,//未运行
        Running,//正在运行
        Success,//运行成功
        Failed,//运行失败
        Error,//运行错误
    }
}