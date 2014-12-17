using System;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class ApplyAssessConditionAddPresenter : ApplyAssessConditionBasePresenter
    {
        private readonly IApplyAssessConditionView _View;

        public ApplyAssessConditionAddPresenter(IApplyAssessConditionView view)
        {
            _View = view;
        }
        public void InitView(bool isPageValid)
        {
            InitBaseView(_View, isPageValid);
            _View.Title = "添加系统自动发起绩效考核条件";
            _View.FormReadonly = false;
            if (!isPageValid)
            {
                _View.ApplyDate = "";
                _View.ScopeFrom = "";
                _View.ScopeTo = "";
            }
        }

        public delegate void GVAddApplyAssessCondition(ApplyAssessCondition applyAssessCondition);
        public GVAddApplyAssessCondition _GVAddApplyAssessCondition;
        public void btnOKClick(object sender, EventArgs e)
        {
            if (Validation(_View))
            {
                try
                {
                    _GVAddApplyAssessCondition(_View.ApplyAssessCondition);
                }
                catch (ApplicationException ex)
                {
                    _View.Message = ex.Message;
                }
            }
        }

    }
}
