//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AssessActivityPaper.cs
// ������: �ߺ�
// ��������: 2008-05-29
// ����: ������
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.AssessFlow;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ������
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
        /// ������
        /// </summary>
        /// <param name="papername"></param>
        public AssessActivityPaper(string papername)
        {
            _paperName = papername;
            SetDefaultValue();
        }

        /// <summary>
        /// ����������
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
        /// ���������
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
        /// ��������д����Ϣ��List
        /// </summary>
        public List<SubmitInfo> SubmitInfoes
        {
            get { return _submitInfoes; }
            set { _submitInfoes = value; }
        }

        /// <summary>
        /// �������������ҵ��ģ�ͣ�ֻ��template��û��ʵ������
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
        /// ���
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
        /// ͨ��question�Լ�itemType�ҵ���ǰAssessActivityPaper����Ӧ��items
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
        /// �ҵ���ǰAssessActivityPaper�ĸ�����
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
        /// ���˷���
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
        /// ���ܷ���
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
        /// �ҵ���ǰAssessActivityPaper��������
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
