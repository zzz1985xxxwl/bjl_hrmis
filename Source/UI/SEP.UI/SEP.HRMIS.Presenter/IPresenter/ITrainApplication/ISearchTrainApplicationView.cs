using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrainApplication
{
    public interface ISearchTrainApplicationView
    {
        string ErrorMessage { set;}
        //øŒ≥Ã√˚≥∆
        string CourseName { get; }
        //≈‡—µ ¶
        string Trainer { get;}

        //≈‡—µ∑∂Œß
        string Scope { get; }
        //≈‡—µ◊¥Ã¨
        string SelectedStatus { get; }

        //±ª≈‡—µ»À
        string Trainee { get;}

        //≤È—Ø ±º‰
        string DateFrom { get;}
        string DateTo { get;}


        string TimeErrorMessage {  set;}

        int HasCertification { get;}

        //≈‡—µ∑∂Œß‘¥
        List<TrainScopeType> ScopeSource { set;}
        //≈‡—µ◊¥Ã¨‘¥
        List<TraineeApplicationStatus> StatusSource {  set;}

        List<TraineeApplication> ApplicationSource { set;}

        //event DelegateID BtnCreateCourseEvent;
        event DelegateNoParameter ApplicationDataBind;
    }
}
