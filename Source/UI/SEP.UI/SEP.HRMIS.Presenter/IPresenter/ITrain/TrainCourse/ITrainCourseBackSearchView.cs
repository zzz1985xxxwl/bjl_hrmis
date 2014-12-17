using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface ITrainCourseBackSearchView
    {
        string ErrorMessage { get;set;}
        //课程名称
        string CourseName { get; set;}
        //培训师
        string Trainer { get; set;}
        //协调员
        string Codinator { get; set;}
        //培训范围
        string Scope { get; set;}
        //培训状态
        string Status { get; set;}
        //相关技能
        string Skill { get; set;}
        //被培训人
        string Trainee { get; set;}
        //计划时间
        string ExpectedST { get; set;}
        string ExpectedET { get; set;}
        //string ExpectedTMsg { get; set;}

        //实际时间
        string ActualST { get; set;}
        string ActualET { get; set;}
        //string ActualTMsg { get; set;}


        string TimeErrorMessage { get; set;}

        //计划成本
        string ExpectedCost { get; set;}
        string ExpectedHour { get; set;}
        //实际成本
        string ActualCost { get; set;}
        string ActualHour { get; set;}

        string CostErrorMessage { get; set;}

        //培训范围源
        List<TrainScopeType> ScopeSource { get; set;}
        //培训状态源
        List<TrainStatusType> StatusSource { get; set;}
        //
        //List<Course> TrainCourseSource { get; set;}

        ITrainCourseListView listView { get; set;}
    }
}
