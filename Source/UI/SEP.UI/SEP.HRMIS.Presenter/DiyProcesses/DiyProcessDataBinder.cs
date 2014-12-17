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
                    theDataToBind.DiySteps[i].IfSystem = (theDataToBind.DiySteps[i].Status == "提交") ||
                                                       (theDataToBind.DiySteps[i].Status == "取消") ||
                                                       (theDataToBind.DiySteps[i].Status == "发信");
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
                //外出申请流程
                case 1:
                //加班申请流程
                case 2:
                    List<DiyStep> iRet = new List<DiyStep>();
                    DiyStep firststep =
                        new DiyStep(process[0].DiyStepID,
                                    process[0].Status, new OperatorType(0, "本人"),
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
                //请假流程
                case 0:
                //考评流程
                case 3:
                //人事负责人
                case 4:
                //报销流程
                case 5:
                //培训申请流程
                case 6:
                    return process;
                default:
                    return new List<DiyStep>();
            }
        }
    }
}
