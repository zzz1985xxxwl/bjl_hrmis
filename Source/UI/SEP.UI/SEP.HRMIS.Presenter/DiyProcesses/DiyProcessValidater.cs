using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class DiyProcessValidater
    {
        private readonly IDiyProcessView _ItsView;

        public DiyProcessValidater(IDiyProcessView view)
        {
            _ItsView = view;
        }

        public bool Vaildate()
        {
            _ItsView.NameMessage = string.Empty;
            _ItsView.ResultMessage = string.Empty;

            bool vaildate = true;
            if (string.IsNullOrEmpty(_ItsView.Name.Trim()))
            {
                _ItsView.NameMessage = DiyProcessUtility._IsEmpty;
                vaildate = false;
            }
            for (int i = 0; i < _ItsView.DiyStepList.Count; i++)
            {
                if (string.IsNullOrEmpty(_ItsView.DiyStepList[i].Status))
                {
                    vaildate = false;
                    _ItsView.ResultMessage = DiyProcessUtility._ItemNone;
                    break;
                }
                if ((_ItsView.DiyStepList[i].OperatorType.Id == OperatorType.Others.Id) &&
                    (_ItsView.DiyStepList[i].OperatorID == 0))
                {
                    vaildate = false;
                    _ItsView.ResultMessage = DiyProcessUtility._OperatorNone;
                    break;
                }
            }
            if (vaildate)
            {
                vaildate = VaildateProcessType();
            }
            return vaildate;
        }

        private bool VaildateProcessType()
        {
            switch (_ItsView.ProcessType.Id)
            {
                    //请假流程ProcessType.LeaveRequest
                case 0:
                    return VaildateProcessTypeLeaveRequest();
                    //外出申请流程ProcessType.ApplicationTypeOut
                case 1:
                    return VaildateProcessTypeApplicationTypeOut();
                    //加班申请流程ProcessType.ApplicationTypeOverTime
                case 2:
                    return VaildateProcessTypeApplicationTypeOverTime();
                    //考评流程ProcessType.Assess
                case 3:
                    return VaildateProcessTypeAssess();
                    //人事负责人ProcessType.HRPrincipal
                case 4:
                    return VaildateProcessTypeHRPrincipal();
                    //报销流程ProcessType.Reimburse
                case 5:
                    return VaildateProcessTypeReimburse();
                case 6:
                    return VaildateProcessTypeTraineeApplication();
                default:
                    return true;
            }
        }

        /// <summary>
        /// 作为人事，我希望请假流程每一个流程必须有经过提交->审核->取消->审核取消，且提交和取消只能是本人操作。
        /// 用户只能加审核和审核取消两种操作，且两种操作至少出现一次。（1人日）
        /// </summary>
        /// <returns></returns>
        private bool VaildateProcessTypeLeaveRequest()
        {
            if (_ItsView.DiyStepList == null || _ItsView.DiyStepList.Count == 0)
            {
                _ItsView.ResultMessage = DiyProcessUtility._ItemMoreThanOne;
                return false;
            }
            int cancelID = 0;
            for (int i = 1; i < _ItsView.DiyStepList.Count; i++)
            {
                if (_ItsView.DiyStepList[i].Status == "取消")
                {
                    cancelID = i;
                }
                else if (_ItsView.DiyStepList[i].Status != "审核")
                {
                    _ItsView.ResultMessage = "第" + (i + 1) + "步" + DiyProcessUtility._WrongStatus;
                    return false;
                }
            }
            if (cancelID == 1)
            {
                _ItsView.ResultMessage = DiyProcessUtility._ReviewStatus;
                return false;
            }
            if (cancelID == _ItsView.DiyStepList.Count - 1)
            {
                _ItsView.ResultMessage = DiyProcessUtility._CancelReviewStatus;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 作为人事，我希望外出申请流程的流程必须有提交和审核，且提交只能是本人操作。审核又分审核和可以改调休（0.5人日）
        /// </summary>
        /// <returns></returns>
        private bool VaildateProcessTypeApplicationTypeOut()
        {
            if (_ItsView.DiyStepList == null || _ItsView.DiyStepList.Count < 2)
            {
                _ItsView.ResultMessage = DiyProcessUtility._ItemMoreThanTwo;
                return false;
            }
            return true;

        }

        /// <summary>
        /// 作为人事，我希望加班申请流程必须有提交和审核，且提交只能是本人操作。审核又分审核和可以改调休。（0.5人日）
        /// </summary>
        /// <returns></returns>
        private bool VaildateProcessTypeApplicationTypeOverTime()
        {
            if (_ItsView.DiyStepList == null || _ItsView.DiyStepList.Count < 2)
            {
                _ItsView.ResultMessage = DiyProcessUtility._ItemMoreThanTwo;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 作为人事，我希望考评流程的步骤至少有一步。该流程的操作有：人事评定、个人评定、主管评定和批阅。（1人日）
        /// </summary>
        /// <returns></returns>
        private bool VaildateProcessTypeAssess()
        {
            if (_ItsView.DiyStepList == null || _ItsView.DiyStepList.Count == 0)
            {
                _ItsView.ResultMessage = DiyProcessUtility._ItemMoreThanOne;
                return false;
            }
            for (int i = 0; i < _ItsView.DiyStepList.Count - 1; i++)
            {
                if (_ItsView.DiyStepList[i].Status == "终结评语")
                {
                    _ItsView.ResultMessage = DiyProcessUtility._SummarizeCommmentNotLase;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 3 作为人事，我希望制定“人事负责人”这类流程时，只有一个步骤，该步骤的操作是“发信”。（1人日）
        /// </summary>
        /// <returns></returns>
        private bool VaildateProcessTypeHRPrincipal()
        {
            if (_ItsView.DiyStepList == null || _ItsView.DiyStepList.Count != 1)
            {
                _ItsView.ResultMessage = DiyProcessUtility._ItemOnlyOne;
                return false;
            }
            if (_ItsView.DiyStepList[0].Status != "发信")
            {
                _ItsView.ResultMessage = "第1步" + DiyProcessUtility._WrongStatus;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 作为人事，我希望报销流程的步骤至少有一步。该流程的操作有：审批，且报销流程只有审批一种操作。（1人日）
        /// </summary>
        /// <returns></returns>
        private bool VaildateProcessTypeReimburse()
        {
            if (_ItsView.DiyStepList == null || _ItsView.DiyStepList.Count ==0)
            {
                _ItsView.ResultMessage = DiyProcessUtility._ItemMoreThanOne;
                return false;
            }
            for (int i = 0; i < _ItsView.DiyStepList.Count; i++)
            {
                if (!(_ItsView.DiyStepList[i].Status == "审核" 
                    || _ItsView.DiyStepList[i].Status == "部门领导电子签名"
                    || _ItsView.DiyStepList[i].Status == "财务电子签名"
                    || _ItsView.DiyStepList[i].Status == "CEO电子签名"))
                {
                    _ItsView.ResultMessage = "第" + (i + 1) + "步" + DiyProcessUtility._WrongStatus;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 作为人事，我希望培训申请流程的流程必须有提交和审核
        /// </summary>
        /// <returns></returns>
        private bool VaildateProcessTypeTraineeApplication()
        {
            if (_ItsView.DiyStepList == null || _ItsView.DiyStepList.Count < 2)
            {
                _ItsView.ResultMessage = DiyProcessUtility._ItemMoreThanTwo;
                return false;
            }
            return true;
        }

    }
}
