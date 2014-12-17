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
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;
        /// <summary>
        /// �������
        /// </summary>
        string OperationInfo { set; get;}
        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}

        /// <summary>
        /// �����Ƿ�ɹ�
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
