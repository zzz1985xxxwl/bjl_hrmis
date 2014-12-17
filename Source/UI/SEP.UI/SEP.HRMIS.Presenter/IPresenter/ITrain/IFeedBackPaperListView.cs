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
        /// ������ť�¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event DelegateID BtnDeleteEvent;
        /// <summary>
        ///�޸İ�ť�¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;

        event DelegateID BtnDetailEvent;
        event DelegateID BtnCopyEvent;
    }
}
