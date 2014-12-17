using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class DiyProcessDataBinder
    {
        public IDiyProcessFacade _IDiyProcessFacade = InstanceFactory.CreateDiyProcessFacade();
        private readonly IDiyProcessView _ItsView;

        public DiyProcessDataBinder(IDiyProcessView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(int diyProcessID)
        {
            DiyProcess theDataToBind = _IDiyProcessFacade.GetDiyProcessByPKID(diyProcessID);

            if (theDataToBind != null)
            {
                _ItsView.DiyProcessID = theDataToBind.ID.ToString();
                _ItsView.Name = theDataToBind.Name;
                _ItsView.Remark = theDataToBind.Remark;
                _ItsView.ProcessType = theDataToBind.Type;
                return true;
            }
            return false;
        }

        public bool DataBindDiyStepList(int diyProcessID)
        {
            DiyProcess theDataToBind = _IDiyProcessFacade.GetDiyProcessByPKID(diyProcessID);

            if (theDataToBind != null)
            {
                for (int i = 0; i < theDataToBind.DiySteps.Count; i++)
                {
                    theDataToBind.DiySteps[i].IfSystem = (theDataToBind.DiySteps[i].Status == "�ύ") ||
                                                       (theDataToBind.DiySteps[i].Status == "ȡ��") ||
                                                       (theDataToBind.DiySteps[i].Status == "����");
                }
                _ItsView.DiyStepList = CollerctDiySteps(theDataToBind.DiySteps);
                return true;
            }
            return false;
        }

        private List<DiyStep> CollerctDiySteps(List<DiyStep> process)
        {
            switch (_ItsView.ProcessType.Id)
            {
                //�����������
                case 1:
                //�Ӱ���������
                case 2:
                    List<DiyStep> iRet = new List<DiyStep>();
                    DiyStep firststep =
                        new DiyStep(process[0].DiyStepID,
                                    process[0].Status, new OperatorType(0, "����"),
                                    0); ;
                    firststep.MailAccount = process[0].MailAccount;
                    firststep.IfSystem = true;
                    iRet.Add(firststep);
                    for (int i = 1; i < process.Count; i++)
                    {
                        DiyStep step =
                            new DiyStep(process[i].DiyStepID, process[i].Status,
                                        process[i - 1].OperatorType, process[i - 1].OperatorID);
                        step.MailAccount = process[i].MailAccount;
                        iRet.Add(step);
                    }
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
                    return process;
                default:
                    return new List<DiyStep>();
            }
        }
    }
}
