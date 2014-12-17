//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AssessTemplateItem.cs
// ������: ����������
// ��������: 2008-05-19
// ����: ģ�忼����ʵ��
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
        /// �����ݴ�
        /// </summary>
        public string WeightString
        {
            get { return _WeightString; }
            set { _WeightString = value; }
        }
        /// <summary>
        /// ���ڽ�����ʾ
        /// </summary>
        public string OptionToShow
        {
            get
            {
                switch (AssessTemplateItemType)
                {
                    case AssessTemplateItemType.Score:
                        string[] s = Option.Split('/');
                        return string.Format("{0}�� ~ {1}��", s[0], s[1]);
                    case AssessTemplateItemType.Formula:
                        return string.Format("��ʽ��{0}", Option);
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
                       return "�����";
                   case AssessTemplateItemType.Open:
                       return "������";
                   case AssessTemplateItemType.Option:
                       return "ѡ����";
                   case AssessTemplateItemType.Formula:
                       return "��ʽ��";
                    default:
                        return "";
                }
            }
        }
    }
}