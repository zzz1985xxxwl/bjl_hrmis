//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessTemplatePaper.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-19
// 概述: 模板考评表实体
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Positions;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class AssessTemplatePaper
    {
        private int _AssessTemplatePaperID;
        private string _PaperName;
        private List<AssessTemplateItem> _ItsAssessTemplateItems;
        private List<Position> _PositionList;

        public AssessTemplatePaper(int assessTemplatePaperID, string paperName, List<AssessTemplateItem> itsAssessTemplateItems)
        {
            _AssessTemplatePaperID = assessTemplatePaperID;
            _PaperName = paperName;
            _ItsAssessTemplateItems = itsAssessTemplateItems;
        }

        public int AssessTemplatePaperID
        {
            get
            {
                return _AssessTemplatePaperID;
            }
            set
            {
                _AssessTemplatePaperID = value;
            }
        }

        public string PaperName
        {
            get
            {
                return _PaperName;
            }
            set
            {
                _PaperName = value;
            }
        }

        public List<AssessTemplateItem> ItsAssessTemplateItems
        {
            get
            {
                return _ItsAssessTemplateItems;
            }
            set
            {
                _ItsAssessTemplateItems = value;
            }
        }

        /// <summary>
        /// </summary>
        public List<Position> PositionList
        {
            get
            {
                return _PositionList;
            }
            set
            {
                _PositionList = value;
            } 
        }

        public static AssessTemplatePaper FindByName(string name, List<AssessTemplatePaper> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].PaperName == name)
                {
                    return list[i];
                }
            }
            return null;
        }

        public static Position FindPositionByPositionName(string positionName, List<AssessTemplatePaper> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].PositionList = list[i].PositionList ?? new List<Position>();
                for (int j = 0; j < list[i].PositionList.Count; j++)
                {
                    if (list[i].PositionList[j].Name == positionName)
                    {
                        return list[i].PositionList[j];
                    }
                }
            }
            return null;
        }

        public static AssessTemplateItem FindItemByItemName(string itemName, List<AssessTemplatePaper> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].ItsAssessTemplateItems = list[i].ItsAssessTemplateItems ?? new List<AssessTemplateItem>();
                for (int j = 0; j < list[i].ItsAssessTemplateItems.Count; j++)
                {
                    if (list[i].ItsAssessTemplateItems[j].AssessTemplateItemTypeName == itemName)
                    {
                        return list[i].ItsAssessTemplateItems[j];
                    }
                }
            }
            return null;
        }
    }
}
