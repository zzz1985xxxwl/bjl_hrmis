namespace SEP.HRMIS.Model.PayModule
{
    /// <summary>
    /// 绑定值结果
    /// </summary>
    public class BindItemValue
    {
        private BindItemEnum _BindItemEnum;
        private decimal _Value;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bindItemEnum"></param>
        public BindItemValue(BindItemEnum bindItemEnum)
        {
            _BindItemEnum = bindItemEnum;
        }
        /// <summary>
        /// 绑定值类型
        /// </summary>
        public BindItemEnum BindItemEnum
        {
            get { return _BindItemEnum; }
            set { _BindItemEnum = value; }
        }
        /// <summary>
        /// 绑定值结果
        /// </summary>
        public decimal Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }
}
