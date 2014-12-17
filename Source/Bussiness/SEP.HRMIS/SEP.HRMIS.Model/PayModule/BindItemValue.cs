namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// ��ֵ���
    /// </summary>
    public class BindItemValue
    {
        private BindItemEnum _BindItemEnum;
        private decimal _Value;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="bindItemEnum"></param>
        public BindItemValue(BindItemEnum bindItemEnum)
        {
            _BindItemEnum = bindItemEnum;
        }
        /// <summary>
        /// ��ֵ����
        /// </summary>
        public BindItemEnum BindItemEnum
        {
            get { return _BindItemEnum; }
            set { _BindItemEnum = value; }
        }
        /// <summary>
        /// ��ֵ���
        /// </summary>
        public decimal Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }
}
