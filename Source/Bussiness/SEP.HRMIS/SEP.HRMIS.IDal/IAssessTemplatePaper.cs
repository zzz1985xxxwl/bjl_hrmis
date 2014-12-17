//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IAssessTemplatePaper.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-19
// 概述: 模板考评表接口
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
