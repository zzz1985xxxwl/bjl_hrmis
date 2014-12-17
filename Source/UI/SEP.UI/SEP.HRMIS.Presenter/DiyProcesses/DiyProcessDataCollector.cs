using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class DiyProcessDataCollector
    {
        private readonly IDiyProcessView _ItsView;
        public DiyProcessDataCollector(IDiyProcessView view)
        {
            _ItsView = view;
        }

        public void CompleteTheObject(ref DiyProcess theObjectToComplete)
        {
            theObjectToComplete = new DiyProcess();
            theObjectToComplete.ID = string.IsNullOrEmpty(_ItsView.DiyProcessID)
                                           ? 0
                                           : Convert.ToInt32(_ItsView.DiyProcessID);
            theObjectToComplete.Name = _ItsView.Name;
            theObjectToComplete.Remark = _ItsView.Remark;
            theObjectToComplete.Type = _ItsView.ProcessType;
            theObjectToComplete.DiySteps = CollerctDiySteps();
        }

        private List<DiyStep> CollerctDiySteps()
        {
            switch (_ItsView.ProcessType.Id)
            {
                    //�����������
                case 1:
                    //�Ӱ���������
                case 2:
                    List<DiyStep> iRet = new List<DiyStep>();
                    for (int i = 0; i < _ItsView.DiyStepList.Count - 1; i++)
                    {
                        DiyStep step =
                            new DiyStep(_ItsView.DiyStepList[i].DiyStepID, _ItsView.DiyStepList[i].Status,
                                        _ItsView.DiyStepList[i + 1].OperatorType, _ItsView.DiyStepList[i + 1].OperatorID);
                        step.MailAccount = _ItsView.DiyStepList[i].MailAccount;
                        iRet.Add(step);
                    }
                    DiyStep lasestep =
                        new DiyStep(_ItsView.DiyStepList[_ItsView.DiyStepList.Count - 1].DiyStepID,
                                    _ItsView.DiyStepList[_ItsView.DiyStepList.Count - 1].Status, new OperatorType(0, ""),
                                    0);
                    lasestep.MailAccount = _ItsView.DiyStepList[_ItsView.DiyStepList.Count - 1].MailAccount;
                    iRet.Add(lasestep);
                    return iRet;
                    //�������
                case 0:
                    //��������
                case 3:
                    //���¸�����
                case 4:
                    //��������
                case 5:
                    //��ѵ��������
                case 6:
                    return _ItsView.DiyStepList;

                default:
                    return new List<DiyStep>();
            }
        }
    }
}
