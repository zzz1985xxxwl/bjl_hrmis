using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain
{
    public interface IFeedBackPaperListView
    {
        string Message { get;set;}
        string TemplatePaperName { get; set; }
        List<FeedBackPaper> FeedBackPapers { set; get;}
        FeedBackPaper SessionCopyPaper { get; set;}

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDeleteEvent;
        /// <summary>
        ///修改按钮事件
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        event DelegateID BtnDetailEvent;
        event DelegateID BtnCopyEvent;
    }
}
