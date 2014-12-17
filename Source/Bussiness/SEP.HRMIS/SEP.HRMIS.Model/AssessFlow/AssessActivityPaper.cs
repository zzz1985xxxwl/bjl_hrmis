//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AssessActivityPaper.cs
// 创建者: 倪豪
// 创建日期: 2008-05-29
// 概述: 考评表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 考评表
    /// </summary>
    [Serializable]
    public class AssessActivityPaper
    {
        private string _paperName;
        private List<SubmitInfo> _submitInfoes = new List<SubmitInfo>();
        private List<AssessActivityItem> _assessActivityItems = new List<AssessActivityItem>();
        private decimal _Score;
        private int _AssessActivityPaperID;

        /// <summary>
        /// 考评表
        /// </summary>
        /// <param name="papername"></param>
        public AssessActivityPaper(string papername)
        {
            _paperName = papername;
            SetDefaultValue();
        }

        /// <summary>
        /// 考评表名称
        /// </summary>
        public string PaperName
        {
            get
            {
                return _paperName;
            }
            set
            {
                _paperName = value;
            }
        }

        /// <summary>
        /// 考评表分数
        /// </summary>
        public decimal Score
        {
            get
            {
                return _Score;
            }
            set
            {
                _Score = value;
            }
        }

        /// <summary>
        /// 考评表填写的信息的List
        /// </summary>
        public List<SubmitInfo> SubmitInfoes
        {
            get { return _submitInfoes; }
            set { _submitInfoes = value; }
        }

        /// <summary>
        /// 考评流程中项的业务模型，只有template，没有实质内容
        /// </summary>
        public List<AssessActivityItem> ItsAssessActivityItems
        {
            get
            {
                return _assessActivityItems;
            }
            set
            {
                _assessActivityItems = value;
            }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int AssessActivityPaperID
        {
            get { return _AssessActivityPaperID; }
            set { _AssessActivityPaperID = value; }
        }

        private void SetDefaultValue()
        {
            _Score = ModelUtility.MakeDefaultDecimal();
        }

        /// <summary>
        /// 通过question以及itemType找到当前AssessActivityPaper的相应的items
        /// </summary>
        public AssessActivityItem FindAssessActivityItem(string question, string itemType)
        {
            foreach (AssessActivityItem item in _assessActivityItems)
            {
                if (item.Question.Equals(question) && itemType.Equals(item.GetType().ToString()))
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// 找到当前AssessActivityPaper的个人项
        /// </summary>
        public List<AssessActivityItem> FindEmployeeAssessActivityItems()
        {
            foreach (SubmitInfo submitInfo in SubmitInfoes)
            {
                if (submitInfo.SubmitInfoType.Id == SubmitInfoType.MyselfAssess.Id)
                {
                    return submitInfo.ItsAssessActivityItems;
                }
            }

            return null;
        }

        private double _ManagerScore;

        /// <summary>
        /// 个人分数
        /// </summary>
        public decimal PersonalScore
        {
            get
            {
                _ManagerScore = 0;
                foreach (SubmitInfo submitInfo in SubmitInfoes)
                {
                    foreach (AssessActivityItem item in submitInfo.ItsAssessActivityItems)
                    {

                        if (item.AssessActivityItemType == AssessActivityItemType.PersonalItem)
                        {
                            _ManagerScore += ((double)item.Grade * (double)item.Weight);
                        }
                    }

                }
                return Convert.ToDecimal(Math.Round(_ManagerScore, 2));
            }
        }


        ///<summary>
        /// 主管分数
        ///</summary>
        public decimal ManagerScore
        {
            get
            {
                _ManagerScore = 0;
                foreach (SubmitInfo submitInfo in SubmitInfoes)
                {
                    foreach (AssessActivityItem item in submitInfo.ItsAssessActivityItems)
                    {

                        if (item.AssessActivityItemType == AssessActivityItemType.ManagerItem)
                        {
                            _ManagerScore += ((double)item.Grade * (double)item.Weight);
                        }
                    }

                }
                return Convert.ToDecimal(Math.Round(_ManagerScore, 2));
            }

        }

        /// <summary>
        /// 找到当前AssessActivityPaper的主管项
        /// </summary>
        public List<AssessActivityItem> FindManagerAssessActivityItems()
        {
            foreach (SubmitInfo submitInfo in SubmitInfoes)
            {
                if (submitInfo.SubmitInfoType.Id == SubmitInfoType.ManagerAssess.Id)
                {
                    return submitInfo.ItsAssessActivityItems;
                }
            }

            return null;
        }


    }
}
