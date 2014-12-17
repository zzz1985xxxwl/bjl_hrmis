//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IAssessTemplatePaper.cs
// ������: ����������
// ��������: 2008-05-19
// ����: ģ�忼����ӿ�
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAssessTemplatePaper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AssessTemplatePaper GetAssessTempletPaperById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paperName"></param>
        /// <returns></returns>
        int CountTemplatePaperByPaperName(string paperName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paperName"></param>
        /// <returns></returns>
        int CountTemplatePaperByPaperNameDiffPKID(int id, string paperName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assessTemplatePaper"></param>
        /// <returns></returns>
        int InsertAssessTemplatePaper(AssessTemplatePaper assessTemplatePaper);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assessTemplatePaper"></param>
        /// <returns></returns>
        int UpdateTemplatePaper(AssessTemplatePaper assessTemplatePaper);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteAssessPaperByAssessPaperID(int id);
        /// <summary>
        /// 
        /// </summary>
        int ManagePaperItems(int paperId, int itemId,decimal  weight);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paperId"></param>
        /// <returns></returns>
        int DeleteAllItemsInPaper(int paperId);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<AssessTemplatePaper> GetAllTemplatePaper();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paperName"></param>
        /// <returns></returns>
        List<AssessTemplatePaper> GetTemplatePapersByPaperName(string paperName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AssessTemplatePaper GetTempletPaperAndItemById(int id);
    }
}
