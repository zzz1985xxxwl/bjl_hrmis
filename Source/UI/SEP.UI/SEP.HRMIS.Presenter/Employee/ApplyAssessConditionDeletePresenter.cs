using System;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class ApplyAssessConditionDeletePresenter : ApplyAssessConditionBasePresenter
    {
        private readonly IApplyAssessConditionView _View;
        public ApplyAssessConditionDeletePresenter(IApplyAssessConditionView view)
        {
            _View = view;
        }
        public void InitView(ApplyAssessCondition applyAssessCondition, bool isPageValid)
        {
            InitBaseView(_View, isPageValid);
            _View.Title = "移除系统自动发起绩效考核条件";
            _View.FormReadonly = true;
            if (!isPageValid)
            {
                _View.ApplyAssessCondition = applyAssessCondition;
                _View.ApplyAssessConditionID = applyAssessCondition.ConditionID.ToString();
            }
        }

        public delegate void GVDeleteApplyAssessCondition(int applyAssessConditionID);
        public GVDeleteApplyAssessCondition _GVDeleteApplyAssessCondition;
        public void btnOKClick(object sender, EventArgs e)
        {
            try
            {
                _GVDeleteApplyAssessCondition(Convert.ToInt32(_View.ApplyAssessConditionID));
            }
            catch (ApplicationException ex)
            {
                _View.Message = ex.Message;
            }
        }
    }
}
