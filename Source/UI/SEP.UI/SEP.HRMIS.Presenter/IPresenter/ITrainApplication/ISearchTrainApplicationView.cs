using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrainApplication
{
    public interface ISearchTrainApplicationView
    {
        string ErrorMessage { set;}
        //�γ�����
        string CourseName { get; }
        //��ѵʦ
        string Trainer { get;}

        //��ѵ��Χ
        string Scope { get; }
        //��ѵ״̬
        string SelectedStatus { get; }

        //����ѵ��
        string Trainee { get;}

        //��ѯʱ��
        string DateFrom { get;}
        string DateTo { get;}


        string TimeErrorMessage {  set;}

        int HasCertification { get;}

        //��ѵ��ΧԴ
        List<TrainScopeType> ScopeSource { set;}
        //��ѵ״̬Դ
        List<TraineeApplicationStatus> StatusSource {  set;}

        List<TraineeApplication> ApplicationSource { set;}

        //event DelegateID BtnCreateCourseEvent;
        event DelegateNoParameter ApplicationDataBind;
    }
}
