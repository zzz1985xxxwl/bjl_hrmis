//add by wsl
//���ʽ����
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
        #region ����
        /// <summary>
        /// ������
        /// ��A1��A2
        /// </summary>
        private string _Parameter;
        public string Parameter
        {
            get { return _Parameter; }
            set { _Parameter = value; }
        }
        /// <summary>
        /// A1����������
        /// </summary>
        private EnumDataType _EnumDataType;
        public EnumDataType EnumDataType
        {
            get { return _EnumDataType; }
            set { _EnumDataType = value; }
        }
        /// <summary>
        /// ���ʽ�ļ�����
        /// </summary>
        private object _Result;
        public object Result
        {
            get { return _Result; }
            set { _Result = value; }
        }
        /// <summary>
        /// ���ʽ
        /// ��3+A2+if(2>9,5,3)
        /// </summary>
        private string _Expression;
        public string Expression
        {
            get { return _Expression; }
            set { _Expression = value; }
        }
        /// <summary>
        /// ����Evaluant.Calculator���㣬�����б��ʽ�г��ֵĲ���A..�滻�����ձ��ʽ
        /// ��3+A2+if(2>9,5,3)������ӹ�����3+1+if(2>9,5,3)
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
