using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class SummarizeCommmentFillAssessPresenter : FillAssessPresenter
    {
        public SummarizeCommmentFillAssessPresenter(string strAssessActivityId, string submitID, IAssessAnswerView view, Account loginUser)
            : base(strAssessActivityId, submitID, view, loginUser)
        {
        }

        public void InitView(bool isPageValid)
        {
            Initialize(isPageValid);
            if (_AssessActivity != null)
            {
                if (!isPageValid)
                {
                    _View.Title = "÷’Ω·∆¿”Ô";
                    if (String.IsNullOrEmpty(_View.Comment))
                    {
                        _View.Comment = "";
                    }
                    _View.Comment = _SubmitInfo.Comment;
                    _View.SalaryNow = _SalaryNow.ToString();
                    _View.SalaryChange = _SalaryChange.ToString();
                    _View.ShowPersonalGoal = false;
                    _View.ShowResponsibility = false;
                    _View.ShowAttendanceStatistics = false;
                    _View.ShowIntention = false;
                    _View.ShowAssessItem = false;
                    _View.ShowbtnSave = false;
                    _View.ShowStar = false;
                    _View.ReadOnlySalaryNow = true;
                    _View.ReadOnlySalaryChange = true;
                }
            }
        }

        public EventHandler ToGetCurrentAssessPage;
        public void btnSubmitClick(object sender, EventArgs e)
        {

            try
            {
                InstanceFactory.AssessActivityFacade.FillSummarizeCommmentExcute(_AssessActivity.AssessActivityID,
                                                                          _View.Comment, LoginUser.Name);
                ToGetCurrentAssessPage(this, null);
            }
            catch (Exception ex)
            {
                _View.Message = ex.Message;
            }

        }
    }
}
