using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain
{
    public interface IFeedBackPaperView
    {
        string ResultMessage { set; get;}
        string ValidatePaperName { set; get;}
        string TemplatePaperName { get; set;}

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
        string OperationInfo { set; get;}
        /// <summary>
        /// 操作类型
        /// </summary>
        string OperationType { get; set;}

        /// <summary>
        /// 动作是否成功
        /// </summary>
        bool ActionSuccess { get; set;}

        bool SetFormReadOnly { set; }

        List<TrainFBQuestion> QuestionList { get; set; }

        List<TrainFBQuestion> QuestionItems { set; }

        event DelegateID ddlAssessItemChangedForAddEvent;
        event Delegate2Parameter ddlAssessItemChangedForUpdateEvent;
        event DelegateID ddlAssessItemChangedForDeleteEvent;
        event DelegateID ddlAssessItemChangedForAddAtEvent;
        event DelegateID ddlAssessItemChangedForUpEvent;
        event DelegateID ddlAssessItemChangedForDownEvent;
        event DelegateNoParameter btnCopyEvent;
        event DelegateNoParameter btnPasteEvent;

        FeedBackPaper SessionCopyPaper { get; set;}

        bool SetbtnPasteVisible { set; }
    }
}
