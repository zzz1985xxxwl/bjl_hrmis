using System;

namespace SEP.HRMIS.Model.PayModule
{
    [Serializable]
    public class AccountSetPara
    {
        private int _AccountSetParaID;
        private string _AccountSetParaName;
        private bool _IsVisibleToEmployee;
        private bool _IsVisibleWhenZero;
        private FieldAttributeEnum _FieldAttribute;
        private MantissaRoundEnum _MantissaRound;
        private BindItemEnum _BindItem;
        private string _Description;

        public AccountSetPara(int ParaID, string ParaName)
        {
            _AccountSetParaID = ParaID;
            _AccountSetParaName = ParaName;
        }

        /// <summary>
        /// ���ײ������
        /// </summary>
        public int AccountSetParaID
        {
            get { return _AccountSetParaID; }
            set { _AccountSetParaID = value; }
        }

        /// <summary>
        /// ���ײ�������
        /// </summary>
        public string AccountSetParaName
        {
            get { return _AccountSetParaName; }
            set { _AccountSetParaName = value; }
        }

        /// <summary>
        /// ��ֵ
        /// </summary>
        public BindItemEnum BindItem
        {
            get { return _BindItem; }
            set { _BindItem = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public FieldAttributeEnum FieldAttribute
        {
            get { return _FieldAttribute; }
            set { _FieldAttribute = value; }
        }

        /// <summary>
        /// β������
        /// </summary>
        public MantissaRoundEnum MantissaRound
        {
            get { return _MantissaRound; }
            set { _MantissaRound = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// �������Ա���Ƿ�ɼ�
        /// </summary>
        public bool IsVisibleToEmployee
        {
            get { return _IsVisibleToEmployee; }
            set { _IsVisibleToEmployee = value; }
        }
        /// <summary>
        /// ������Ϊ0ʱ�������Ա���Ƿ�ɼ�
        /// </summary>
        public bool IsVisibleWhenZero
        {
            get { return _IsVisibleWhenZero; }
            set { _IsVisibleWhenZero = value; }
        }
        
    }
}
