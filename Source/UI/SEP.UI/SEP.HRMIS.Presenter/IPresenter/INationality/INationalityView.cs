using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.INationality
{
    public interface INationalityView
    {
        string Message { get;set;}
        string NameMsg { get;set;}
        string NationalityID { get; set; }
        string NationalityName { get; set;}
        string NationalityDescription { get; set;}

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
    }
}
