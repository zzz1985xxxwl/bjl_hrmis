using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
   public interface IAssessManagementFacade
    {
       /// <summary>
       /// 新增考评表
       /// </summary>
       /// <param name="assessTemplatePaper"></param>
       void AddAssessTemplatePaper(AssessTemplatePaper assessTemplatePaper);
       /// <summary>
       /// 修改考评表
       /// </summary>
       /// <param name="assessTemplatePaper"></param>
       void UpdateAssessTemplatePaper(AssessTemplatePaper assessTemplatePaper);
       /// <summary>
       /// 删除考评表
       /// </summary>
       /// <param name="pkid"></param>
       void DeleteAssessTemplatePaper(int pkid);
       /// <summary>
       /// 新增考评项
       /// </summary>
       /// <param name="assessTemplateItem"></param>
       void AddAssessTemplateItem(AssessTemplateItem assessTemplateItem);
       /// <summary>
       /// 修改考评项
       /// </summary>
       /// <param name="assessTemplateItem"></param>
       void UpdateAssessTemplateItem(AssessTemplateItem assessTemplateItem);
       /// <summary>
       /// 删除考评项
       /// </summary>
       /// <param name="pkid"></param>
       void DeleteAssessTemplateItem(int pkid);
       /// <summary>
       /// 根据ID获得考评表信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       AssessTemplatePaper GetAssessTempletPaperById(int id);
       //GetTemplatePapersByPaperName与GetAllTemplatePaper可以合并
       /// <summary>
       /// 获得所有考评表
       /// </summary>
       /// <returns></returns>
       List<AssessTemplatePaper> GetAllTemplatePaper();
       /// <summary>
       /// 根据名称获得考评表
       /// </summary>
       /// <param name="paperName"></param>
       /// <returns></returns>
       List<AssessTemplatePaper> GetTemplatePapersByPaperName(string paperName);
       /// <summary>
       /// 根据ID获取考评项信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       AssessTemplateItem GetTemplateItemById(int id);
       //可以合并到GetTemplateItemsByConditon
       /// <summary>
       /// 获得所有考评项
       /// </summary>
       /// <returns></returns>
       List<AssessTemplateItem> GetAllTemplateItems();
       /// <summary>
       /// 根据条件获取考评项
       /// </summary>
       /// <param name="question"></param>
       /// <param name="type"></param>
       /// <param name="classfication"></param>
       /// <returns></returns>
       List<AssessTemplateItem> GetTemplateItemsByConditon(string question, OperateType type, ItemClassficationEmnu classfication, AssessTemplateItemType itemtype);
       /// <summary>
       /// 根据ID获得考评表信息及考评项信息
       /// </summary>
       /// <param name="paperId"></param>
       /// <returns></returns>
       AssessTemplatePaper GetTempletPaperAndItemById(int paperId);
       /// <summary>
       /// 管理考评表的考评项
       /// </summary>
       /// <param name="paperId"></param>
       /// <param name="items"></param>
       void ManagerPaperItem(int paperId, List<int> items);

       /// <summary>
       /// 通过员工职位得到对应的考评表
       /// </summary>
       int GetTempletPaperIDByEmployeePositionID(int positionID);
       /// <summary>
       /// for export
       /// </summary>
       /// <param name="paperName"></param>
       /// <returns></returns>
       List<AssessTemplatePaper> GetTemplatePapersAllInfoByPaperName(string paperName);
       /// <summary>
       /// 
       /// </summary>
       /// <param name="filePath"></param>
       string ImportTemplatePaper(string filePath);
    }
}
