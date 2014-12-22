using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
   public interface IAssessManagementFacade
    {
       /// <summary>
       /// ����������
       /// </summary>
       /// <param name="assessTemplatePaper"></param>
       void AddAssessTemplatePaper(AssessTemplatePaper assessTemplatePaper);
       /// <summary>
       /// �޸Ŀ�����
       /// </summary>
       /// <param name="assessTemplatePaper"></param>
       void UpdateAssessTemplatePaper(AssessTemplatePaper assessTemplatePaper);
       /// <summary>
       /// ɾ��������
       /// </summary>
       /// <param name="pkid"></param>
       void DeleteAssessTemplatePaper(int pkid);
       /// <summary>
       /// ����������
       /// </summary>
       /// <param name="assessTemplateItem"></param>
       void AddAssessTemplateItem(AssessTemplateItem assessTemplateItem);
       /// <summary>
       /// �޸Ŀ�����
       /// </summary>
       /// <param name="assessTemplateItem"></param>
       void UpdateAssessTemplateItem(AssessTemplateItem assessTemplateItem);
       /// <summary>
       /// ɾ��������
       /// </summary>
       /// <param name="pkid"></param>
       void DeleteAssessTemplateItem(int pkid);
       /// <summary>
       /// ����ID��ÿ�������Ϣ
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       AssessTemplatePaper GetAssessTempletPaperById(int id);
       //GetTemplatePapersByPaperName��GetAllTemplatePaper���Ժϲ�
       /// <summary>
       /// ������п�����
       /// </summary>
       /// <returns></returns>
       List<AssessTemplatePaper> GetAllTemplatePaper();
       /// <summary>
       /// �������ƻ�ÿ�����
       /// </summary>
       /// <param name="paperName"></param>
       /// <returns></returns>
       List<AssessTemplatePaper> GetTemplatePapersByPaperName(string paperName);
       /// <summary>
       /// ����ID��ȡ��������Ϣ
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       AssessTemplateItem GetTemplateItemById(int id);
       //���Ժϲ���GetTemplateItemsByConditon
       /// <summary>
       /// ������п�����
       /// </summary>
       /// <returns></returns>
       List<AssessTemplateItem> GetAllTemplateItems();
       /// <summary>
       /// ����������ȡ������
       /// </summary>
       /// <param name="question"></param>
       /// <param name="type"></param>
       /// <param name="classfication"></param>
       /// <returns></returns>
       List<AssessTemplateItem> GetTemplateItemsByConditon(string question, OperateType type, ItemClassficationEmnu classfication, AssessTemplateItemType itemtype);
       /// <summary>
       /// ����ID��ÿ�������Ϣ����������Ϣ
       /// </summary>
       /// <param name="paperId"></param>
       /// <returns></returns>
       AssessTemplatePaper GetTempletPaperAndItemById(int paperId);
       /// <summary>
       /// ��������Ŀ�����
       /// </summary>
       /// <param name="paperId"></param>
       /// <param name="items"></param>
       void ManagerPaperItem(int paperId, List<int> items);

       /// <summary>
       /// ͨ��Ա��ְλ�õ���Ӧ�Ŀ�����
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
