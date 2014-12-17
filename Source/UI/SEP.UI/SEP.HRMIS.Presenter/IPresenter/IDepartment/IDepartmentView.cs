
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IDepartmentView
    {
        string OperatorID { get; set;}
        string Operator { get; set;}
        string Message { set;}
        string DepNameMsg { set;}
        string LeaderNameMsg { set;}
        string ParentID{ get; set;}
        string DepartmentID { get; set; }
        string DepartmentName { get; set;}
        string LeaderName { get; set;}

        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;
        /// <summary>
        /// 界面标题
        /// </summary>
        string OperationTitle { set; get;}
        /// <summary>
        /// 操作类型
        /// </summary>
        string OperationType { get; set;}
        /// <summary>
        /// 确认按钮显示的字符
        /// </summary>
        string ActionButtonTxt { get; set;}
        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}

        bool SetReadonly { set; }

        string CancelButtonClientEvent { set; }
    }
}
