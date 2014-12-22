using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class ManualAssessDetailPresenter : ManualAssessPresenter
    {
        private readonly int _AssessActivityID;

        public ManualAssessDetailPresenter(string assessActivityID, IManualAssessView view, Account loginUser)
            : base(view, loginUser)
        {
            int.TryParse(assessActivityID, out _AssessActivityID);
        }

        public override void Initialize(bool isPostBack)
        {
            _View.Message = string.Empty;

            if (_AssessActivityID == 0)
            {
                _View.Message = "绩效考核活动信息输入有误";
                return;
            }
            if (!isPostBack)
            {
                _View.AssessCharacterTypes = AssessActivityUtility.GetCharacterTypeEnum();
                _View.ddlCharacterEnabled = false;
                _View.AssessActivityToManual = InstanceFactory.AssessActivityFacade().GetAssessActivityByAssessActivityID(_AssessActivityID);
                _View.FormReadonly = true;
            }
        }

    }
}