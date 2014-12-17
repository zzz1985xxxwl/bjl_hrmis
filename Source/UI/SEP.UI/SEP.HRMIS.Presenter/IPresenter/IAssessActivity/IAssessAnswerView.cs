using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IAssessActivity
{
    public interface IAssessAnswerView
    {
        string Message { set; get; }
        string CommentMsg { set; }
        string IntentionMsg { set; }
        string Title { set; }
        string Comment { get; set; }
        string SalaryNow { get; set; }
        string SalaryChange { get; set; }
        string SalaryNowMessage { set; }
        string SalaryChangeMessage { set; }
        string PersonalGoal { set; }
        string AssessFromTime { set; }
        string AssessToTime { set; }
        string EmployeeID { set; get; }
        string Responsibility { set; }
        List<AssessActivityItem> AssessActivityItems { get; set; }
        List<AssessActivityItem> QuesItemsSource { set; }
        string[] IntentionSource { set; }
        string SelectIntention { get; set; }
        bool ShowComment { set; }
        bool ShowIntention { set; }
        bool ShowAssessItem { set; }
        bool ShowPersonalGoal { set; }
        bool ShowResponsibility { set; }
        bool ShowAttendanceStatistics { set; }
        bool ShowbtnSave { set; }
        bool FormReadonly { set; }
        bool ShowSalary { set; }
        bool ShowSalaryChange { set; }
        bool ReadOnlySalaryChange { set; }
        bool ReadOnlySalaryNow { set; }
        bool ShowStar { set; }
        string SalaryName { set; }
        string ManagerSalalry { set; }
        bool ShowNowSalaryStar{ set;}

        bool Visible360 { get; set; }
    }
}

