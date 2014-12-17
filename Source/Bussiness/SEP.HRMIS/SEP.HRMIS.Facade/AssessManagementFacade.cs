using System.Collections.Generic;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Facade
{
    public class AssessManagementFacade : IAssessManagementFacade
    {
        public void AddAssessTemplatePaper(AssessTemplatePaper assessTemplatePaper)
        {
            InsertAssessPaper addAssessPaper = new InsertAssessPaper(assessTemplatePaper);
            addAssessPaper.Excute();
        }

        public void UpdateAssessTemplatePaper(AssessTemplatePaper assessTemplatePaper)
        {
            UpdateAssessPaper updateAssessPaper = new UpdateAssessPaper(assessTemplatePaper);
            updateAssessPaper.Excute();
        }

        public void DeleteAssessTemplatePaper(int pkid)
        {
            DeleteAssessPaper deleteAssessPaper = new DeleteAssessPaper(pkid);
            deleteAssessPaper.Excute();
        }

        public void AddAssessTemplateItem(AssessTemplateItem assessTemplateItem)
        {
            InsertAssessItem addAssessItem = new InsertAssessItem(assessTemplateItem);
            addAssessItem.Excute();
        }

        public void UpdateAssessTemplateItem(AssessTemplateItem assessTemplateItem)
        {
            UpdateAssessItem updateAssessItem = new UpdateAssessItem(assessTemplateItem);
            updateAssessItem.Excute();
        }

        public void DeleteAssessTemplateItem(int pkid)
        {
            DeleteAssessItem deleteAssessItem = new DeleteAssessItem(pkid);
            deleteAssessItem.Excute();
        }

        public AssessTemplatePaper GetAssessTempletPaperById(int id)
        {
            GetAssessManagement getAssessManagement = new GetAssessManagement();
            return getAssessManagement.GetAssessTempletPaperById(id);
        }

        public List<AssessTemplatePaper> GetAllTemplatePaper()
        {
            GetAssessManagement getAssessManagement = new GetAssessManagement();
            return getAssessManagement.GetAllTemplatePaper();
        }

        public List<AssessTemplatePaper> GetTemplatePapersByPaperName(string paperName)
        {
            GetAssessManagement getAssessManagement = new GetAssessManagement();
            return getAssessManagement.GetTemplatePapersByPaperName(paperName);
        }

        public AssessTemplateItem GetTemplateItemById(int id)
        {
            GetAssessManagement getAssessManagement = new GetAssessManagement();
            return getAssessManagement.GetTemplateItemById(id);
        }

        public List<AssessTemplateItem> GetAllTemplateItems()
        {
            GetAssessManagement getAssessManagement = new GetAssessManagement();
            return getAssessManagement.GetAllTemplateItems();
        }

        public List<AssessTemplateItem> GetTemplateItemsByConditon(string question, OperateType type,
                                                                   ItemClassficationEmnu classfication,
                                                                   AssessTemplateItemType itemtype)
        {
            GetAssessManagement getAssessManagement = new GetAssessManagement();
            return getAssessManagement.GetTemplateItemsByConditon(question, type, classfication, itemtype);
        }

        public AssessTemplatePaper GetTempletPaperAndItemById(int paperId)
        {
            GetAssessManagement getAssessManagement = new GetAssessManagement();
            return getAssessManagement.GetTempletPaperAndItemById(paperId);
        }

        public void ManagerPaperItem(int paperId, List<int> items)
        {
            ManagerPaperItem managerPaperItem = new ManagerPaperItem(paperId, items);
            managerPaperItem.Excute();
        }

        /// <summary>
        /// 
        /// </summary>
        public int GetTempletPaperIDByEmployeePositionID(int positionID)
        {
            return new GetAssessManagement().GetTempletPaperIDByEmployeePositionID(positionID);
        }
        public List<AssessTemplatePaper> GetTemplatePapersAllInfoByPaperName(string paperName)
        {
            return new GetAssessManagement().GetTemplatePapersAllInfoByPaperName(paperName);
        }
        public string ImportTemplatePaper(string filePath)
        {
            ImportTemplatePaper ImportTemplatePaper = new ImportTemplatePaper(filePath);
            ImportTemplatePaper.Excute();
            return ImportTemplatePaper.ResultMessage;
        }
    }
}