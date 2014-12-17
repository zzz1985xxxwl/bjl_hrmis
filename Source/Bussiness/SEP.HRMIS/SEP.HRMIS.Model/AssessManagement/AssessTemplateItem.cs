//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessTemplateItem.cs
// 创建者: 刘丹、张珍
// 创建日期: 2008-05-19
// 概述: 模板考评项实体
// ----------------------------------------------------------------
using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class AssessTemplateItem
    {
        private int _AssessTemplateItemID;
        private string _Question;
        private AssessTemplateItemType _AssessTemplateItemType;
        private OperateType _ItsOperateType;
        private string _Option;
        private ItemClassficationEmnu _Classfication;
        private string _Description;
        private decimal _Weight;
        public AssessTemplateItem(int assessTemplateItemID, string question, OperateType itsOperateType)
        {
            _AssessTemplateItemID = assessTemplateItemID;
            _Question = question;
            _ItsOperateType = itsOperateType;
        }


        public int AssessTemplateItemID
        {
            get { return _AssessTemplateItemID; }
            set { _AssessTemplateItemID = value; }
        }

        public string Question
        {
            get { return _Question; }
            set { _Question = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public AssessTemplateItemType AssessTemplateItemType
        {
            get { return _AssessTemplateItemType; }
            set { _AssessTemplateItemType = value; }
        }

        public OperateType ItsOperateType
        {
            get { return _ItsOperateType; }
            set { _ItsOperateType = value; }
        }

        public string Option
        {
            get { return _Option; }
            set { _Option = value; }
        }

        public ItemClassficationEmnu Classfication
        {
            get { return _Classfication; }
            set { _Classfication = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }

        private string _WeightString;
        /// <summary>
        /// 用于暂存
        /// </summary>
        public string WeightString
        {
            get { return _WeightString; }
            set { _WeightString = value; }
        }
        /// <summary>
        /// 用于界面显示
        /// </summary>
        public string OptionToShow
        {
            get
            {
                switch (AssessTemplateItemType)
                {
                    case AssessTemplateItemType.Score:
                        string[] s = Option.Split('/');
                        return string.Format("{0}分 ~ {1}分", s[0], s[1]);
                    case AssessTemplateItemType.Formula:
                        return string.Format("公式：{0}", Option);
                    default:
                        return Option;
                }
            }
        }
        /// <summary>
        /// </summary>
        public string AssessTemplateItemTypeName
        {
            get
            {
                switch (AssessTemplateItemType)
                {
                    case AssessTemplateItemType.Score:
                       return "打分项";
                   case AssessTemplateItemType.Open:
                       return "开发项";
                   case AssessTemplateItemType.Option:
                       return "选择项";
                   case AssessTemplateItemType.Formula:
                       return "公式项";
                    default:
                        return "";
                }
            }
        }
    }
}