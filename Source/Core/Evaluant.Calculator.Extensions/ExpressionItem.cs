//add by wsl
//表达式对象
namespace Evaluant.Calculator.Extensions
{
    public class ExpressionItem
    {
        public ExpressionItem(string parameter, string expression, EnumDataType enumDataType)
        {
            _Expression = Utility.FormatExpressionBase(expression);
            _Parameter = parameter;
            _EnumDataType = enumDataType;
        }
        #region 属性
        /// <summary>
        /// 参数名
        /// 如A1，A2
        /// </summary>
        private string _Parameter;
        public string Parameter
        {
            get { return _Parameter; }
            set { _Parameter = value; }
        }
        /// <summary>
        /// A1的数据类型
        /// </summary>
        private EnumDataType _EnumDataType;
        public EnumDataType EnumDataType
        {
            get { return _EnumDataType; }
            set { _EnumDataType = value; }
        }
        /// <summary>
        /// 表达式的计算结果
        /// </summary>
        private object _Result;
        public object Result
        {
            get { return _Result; }
            set { _Result = value; }
        }
        /// <summary>
        /// 表达式
        /// 如3+A2+if(2>9,5,3)
        /// </summary>
        private string _Expression;
        public string Expression
        {
            get { return _Expression; }
            set { _Expression = value; }
        }
        /// <summary>
        /// 用于Evaluant.Calculator计算，将所有表达式中出现的参数A..替换成最终表达式
        /// 如3+A2+if(2>9,5,3)被程序加工后获得3+1+if(2>9,5,3)
        /// </summary>
        private string _ExpressionCalculator;
        public string ExpressionForCalculator
        {
            get { return _ExpressionCalculator; }
            set { _ExpressionCalculator = value; }
        }
        #endregion
    }
}
