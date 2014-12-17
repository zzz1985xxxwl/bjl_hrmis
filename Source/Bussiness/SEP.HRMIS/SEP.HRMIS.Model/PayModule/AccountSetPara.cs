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
        /// 帐套参数编号
        /// </summary>
        public int AccountSetParaID
        {
            get { return _AccountSetParaID; }
            set { _AccountSetParaID = value; }
        }

        /// <summary>
        /// 帐套参数名称
        /// </summary>
        public string AccountSetParaName
        {
            get { return _AccountSetParaName; }
            set { _AccountSetParaName = value; }
        }

        /// <summary>
        /// 绑定值
        /// </summary>
        public BindItemEnum BindItem
        {
            get { return _BindItem; }
            set { _BindItem = value; }
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public FieldAttributeEnum FieldAttribute
        {
            get { return _FieldAttribute; }
            set { _FieldAttribute = value; }
        }

        /// <summary>
        /// 尾数舍入
        /// </summary>
        public MantissaRoundEnum MantissaRound
        {
            get { return _MantissaRound; }
            set { _MantissaRound = value; }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        /// <summary>
        /// 帐套项对员工是否可见
        /// </summary>
        public bool IsVisibleToEmployee
        {
            get { return _IsVisibleToEmployee; }
            set { _IsVisibleToEmployee = value; }
        }
        /// <summary>
        /// 当数据为0时帐套项对员工是否可见
        /// </summary>
        public bool IsVisibleWhenZero
        {
            get { return _IsVisibleWhenZero; }
            set { _IsVisibleWhenZero = value; }
        }
        
    }
}
