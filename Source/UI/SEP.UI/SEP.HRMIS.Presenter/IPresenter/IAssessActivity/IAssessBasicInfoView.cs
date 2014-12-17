using hrmisModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IAssessBasicInfoView
    {
        string Message { set;}
        string ManagerName { set;}
        bool IsBack{ get; set;}
        hrmisModel.AssessActivity AssessActivityToShow { set;  }
    }
}
