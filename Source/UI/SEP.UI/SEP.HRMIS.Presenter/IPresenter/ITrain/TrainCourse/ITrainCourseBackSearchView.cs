using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface ITrainCourseBackSearchView
    {
        string ErrorMessage { get;set;}
        //�γ�����
        string CourseName { get; set;}
        //��ѵʦ
        string Trainer { get; set;}
        //Э��Ա
        string Codinator { get; set;}
        //��ѵ��Χ
        string Scope { get; set;}
        //��ѵ״̬
        string Status { get; set;}
        //��ؼ���
        string Skill { get; set;}
        //����ѵ��
        string Trainee { get; set;}
        //�ƻ�ʱ��
        string ExpectedST { get; set;}
        string ExpectedET { get; set;}
        //string ExpectedTMsg { get; set;}

        //ʵ��ʱ��
        string ActualST { get; set;}
        string ActualET { get; set;}
        //string ActualTMsg { get; set;}


        string TimeErrorMessage { get; set;}

        //�ƻ��ɱ�
        string ExpectedCost { get; set;}
        string ExpectedHour { get; set;}
        //ʵ�ʳɱ�
        string ActualCost { get; set;}
        string ActualHour { get; set;}

        string CostErrorMessage { get; set;}

        //��ѵ��ΧԴ
        List<TrainScopeType> ScopeSource { get; set;}
        //��ѵ״̬Դ
        List<TrainStatusType> StatusSource { get; set;}
        //
        //List<Course> TrainCourseSource { get; set;}

        ITrainCourseListView listView { get; set;}
    }
}
