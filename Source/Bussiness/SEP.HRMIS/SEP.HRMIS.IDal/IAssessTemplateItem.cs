//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IAssessTemplateItem.cs
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
    public interface IAssessTemplateItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        int CountTemplateItemByTitle(string question);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assessTemplateItem"></param>
        /// <returns></returns>
        int InsertTemplateItem(AssessTemplateItem assessTemplateItem);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AssessTemplateItem GetTemplateItemById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<AssessTemplateItem> GetAllTemplateItems();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<AssessTemplateItem> GetTemplateItemsByConditon(string question,OperateType type,ItemClassficationEmnu classfication ,AssessTemplateItemType itemtype);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assessTemplateItem"></param>
        /// <returns></returns>
        int UpdateTemplateItem(AssessTemplateItem assessTemplateItem);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteAssessItemByAssessItemID(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Question"></param>
        /// <returns></returns>
        int CountTemplateItemByQuestionDiffPKID(int id, string Question);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int GetPIShipByItemId(int id);
    }
}
