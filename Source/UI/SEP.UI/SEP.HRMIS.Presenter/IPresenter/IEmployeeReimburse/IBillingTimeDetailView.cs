using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IBillingTimeDetailView
    {
        /// <summary>
        /// 显示底层的一些信息
        /// </summary>
        string Message { set;}

        /// <summary>
        /// 记账时间的报错信息
        /// </summary>
        string ReimburseID { set; get;}

        /// <summary>
        /// 记账时间的报错信息
        /// </summary>
        string BillingTimeMessage { set;}

        /// <summary>
        /// 记账时间
        /// </summary>
        string BillingTime { set; get;}

        /// <summary>
        /// 操作类型;新增，修改，详细
        /// </summary>
        string OperationTitle { set; get;}

        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;

        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}

        /// <summary>
        /// 操作类型
        /// </summary>
        string OperationType { get; set;}
    }
}
