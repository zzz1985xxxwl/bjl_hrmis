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
                    //�������ProcessType.LeaveRequest
                case 0:
                    return VaildateProcessTypeLeaveRequest();
                    //�����������ProcessType.ApplicationTypeOut
                case 1:
                    return VaildateProcessTypeApplicationTypeOut();
                    //�Ӱ���������ProcessType.ApplicationTypeOverTime
                case 2:
                    return VaildateProcessTypeApplicationTypeOverTime();
                    //��������ProcessType.Assess
                case 3:
                    return VaildateProcessTypeAssess();
                    //���¸�����ProcessType.HRPrincipal
                case 4:
                    return VaildateProcessTypeHRPrincipal();
                    //��������ProcessType.Reimburse
                case 5:
                    return VaildateProcessTypeReimburse();
                case 6:
                    return VaildateProcessTypeTraineeApplication();
                default:
                    return true;
            }
        }

        /// <summary>
        /// ��Ϊ���£���ϣ���������ÿһ�����̱����о����ύ->���->ȡ��->���ȡ�������ύ��ȡ��ֻ���Ǳ��˲�����
        /// �û�ֻ�ܼ���˺����ȡ�����ֲ����������ֲ������ٳ���һ�Ρ���1���գ�
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
                if (_ItsView.DiyStepList[i].Status == "ȡ��")
                {
                    cancelID = i;
                }
                else if (_ItsView.DiyStepList[i].Status != "���")
                {
                    _ItsView.ResultMessage = "��" + (i + 1) + "��" + DiyProcessUtility._WrongStatus;
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
        /// ��Ϊ���£���ϣ������������̵����̱������ύ����ˣ����ύֻ���Ǳ��˲���������ַ���˺Ϳ��Ըĵ��ݣ�0.5���գ�
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
        /// ��Ϊ���£���ϣ���Ӱ��������̱������ύ����ˣ����ύֻ���Ǳ��˲���������ַ���˺Ϳ��Ըĵ��ݡ���0.5���գ�
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
        /// ��Ϊ���£���ϣ���������̵Ĳ���������һ���������̵Ĳ����У����������������������������������ġ���1���գ�
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
                if (_ItsView.DiyStepList[i].Status == "�ս�����")
                {
                    _ItsView.ResultMessage = DiyProcessUtility._SummarizeCommmentNotLase;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 3 ��Ϊ���£���ϣ���ƶ������¸����ˡ���������ʱ��ֻ��һ�����裬�ò���Ĳ����ǡ����š�����1���գ�
        /// </summary>
        /// <returns></returns>
        private bool VaildateProcessTypeHRPrincipal()
        {
            if (_ItsView.DiyStepList == null || _ItsView.DiyStepList.Count != 1)
            {
                _ItsView.ResultMessage = DiyProcessUtility._ItemOnlyOne;
                return false;
            }
            if (_ItsView.DiyStepList[0].Status != "����")
            {
                _ItsView.ResultMessage = "��1��" + DiyProcessUtility._WrongStatus;
                return false;
            }
            return true;
        }

        /// <summary>
        /// ��Ϊ���£���ϣ���������̵Ĳ���������һ���������̵Ĳ����У��������ұ�������ֻ������һ�ֲ�������1���գ�
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
                if (!(_ItsView.DiyStepList[i].Status == "���" 
                    || _ItsView.DiyStepList[i].Status == "�����쵼����ǩ��"
                    || _ItsView.DiyStepList[i].Status == "�������ǩ��"
                    || _ItsView.DiyStepList[i].Status == "CEO����ǩ��"))
                {
                    _ItsView.ResultMessage = "��" + (i + 1) + "��" + DiyProcessUtility._WrongStatus;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ��Ϊ���£���ϣ����ѵ�������̵����̱������ύ�����
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
