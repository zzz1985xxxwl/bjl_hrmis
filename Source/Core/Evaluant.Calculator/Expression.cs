using System;
using System.Collections;
using Antlr.Runtime.Tree;
using Evaluant.Calculator.Domain;
using Antlr.Runtime;

namespace Evaluant.Calculator
{
    public class Expression
    {
        protected string expression;

        public Expression(string expression)
        {
            if (expression == null || expression == String.Empty)
                throw new 
                    ArgumentException("Expression can't be empty", "expression");

            this.expression = expression;
        }

        protected CommonTree Parse(string expression)
        {
            ECalcLexer lexer = new ECalcLexer(new ANTLRStringStream(expression));
            ECalcParser parser = new ECalcParser(new CommonTokenStream(lexer));

            try
            {
                RuleReturnScope rule = parser.expression();
                if (parser.HasError)
                {
                    //modify by wsl to translate
                    //throw new EvaluationException(parser.ErrorMessage + " " + parser.ErrorPosition);
                    throw new EvaluationException("语法严重错误，系统无法解释计算公式表达式");
                }
                return rule.Tree as CommonTree;
            }
            catch (EvaluationException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new EvaluationException(e.Message, e);
            }
        }

        public object Evaluate()
        {
            EvaluationVisitor visitor = new EvaluationVisitor();
            visitor.TaxFunction += TaxFunction;
            visitor.TaxWithPointFunction += TaxWithPointFunction;
            visitor.AnnualBonusTaxFunction += AnnualBonusTaxFunction;
            visitor.ForeignTaxFunction += ForeignTaxFunction;
            visitor.IsSalaryEndDateMonthEquelFunction += IsSalaryEndDateMonthEquelFunction;
            visitor.DoubleSalaryFunction += DoubleSalaryFunction;
            visitor.AnnualBonusForeignTaxFunction += AnnualBonusForeignTaxFunction;
            visitor.EvaluateFunction += EvaluateFunction;
            visitor.EvaluateParameter += EvaluateParameter;
            visitor.Parameters = parameters;

            //LogicalExpression.Create(Parse(expression)).Accept(visitor);
            //modify by wsl 
            CommonTree ct = Parse(expression);
            //将表达式转化成LogicalExpression对象
            LogicalExpression le = LogicalExpression.Create(ct);
            //计算表达式
            le.Accept(visitor);
            return visitor.Result;
        }

        //add by wsl
        public event AnnualBonusForeignTaxFunctionDelegate AnnualBonusForeignTaxFunction;
        public event ForeignTaxFunctionDelegate ForeignTaxFunction;
        public event DoubleSalaryFunctionDelegate DoubleSalaryFunction;
        public event IsSalaryEndDateMonthEquelFunctionDelegate IsSalaryEndDateMonthEquelFunction;
        public event AnnualBonusTaxFunctionDelegate AnnualBonusTaxFunction;
        public event TaxWithPointFunctionDelegate TaxWithPointFunction;
        public event TaxFunctionDelegate TaxFunction;
        public event EvaluateFunctionHandler EvaluateFunction;
        public event EvaluateParameterHandler EvaluateParameter;

        private Hashtable parameters = new Hashtable();

        public Hashtable Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

    }
}
