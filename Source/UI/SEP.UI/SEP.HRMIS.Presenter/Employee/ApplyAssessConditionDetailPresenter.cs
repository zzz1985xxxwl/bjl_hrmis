using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class ApplyAssessConditionDetailPresenter: ApplyAssessConditionBasePresenter
    {
        private readonly IApplyAssessConditionView _View;

        public ApplyAssessConditionDetailPresenter(IApplyAssessConditionView view)
        {
            _View = view;
        }
        public void InitView(ApplyAssessCondition applyAssessCondition, bool isPageValid)
        {
            InitBaseView(_View, isPageValid);
            _View.Title = "ϵͳ�Զ�����Ч������������";
            _View.FormReadonly = true;
            if (!isPageValid)
            {
                _View.ApplyAssessCondition = applyAssessCondition;
            }
        }

    }
}
