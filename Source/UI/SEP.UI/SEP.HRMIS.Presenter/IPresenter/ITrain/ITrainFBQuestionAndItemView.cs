using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain
{
    public interface ITrainFBQuestionAndItemView
    {
        string ResultMessage { get; set;}
        string OperationType { get; set;}
        string FBQuestionID { get; set;}

        string FBQuestion { get; set;}
        string FBQuestionMessage { get;set;}

        string TrainFBQuesType { get;set;}
        List<TrainFBQuesType> TrainFBQuesTypeSource { get; set;}
        string FBQuesTypeMessage { get;set;}

        List<TrainFBItem> FBItemList { get; set;}

        bool SetFormReadOnly { set;}
        
        event EventHandler btnOKClick;

        event EventHandler btnSubmitClick;

        event DelegateID ddlTrainFBItemChangedForDownEvent;

        event DelegateID ddlTrainFBItemChangedForUpEvent;

        event DelegateID TrainFBItemForDeleteAtEvent;

        event DelegateID TrainFBItemForAddAtEvent;
    }
}
