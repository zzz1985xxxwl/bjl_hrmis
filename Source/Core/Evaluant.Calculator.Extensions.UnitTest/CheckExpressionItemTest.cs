//add by wsl
//测试检查单条表达式
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Evaluant.Calculator.Extensions.UnitTest
{
    [TestFixture]
    public class CheckExpressionItemTest
    {
        private static bool _IsDiffUpperOrLower;

        #region method
        private static void AssertFailedTestCase(string parameter, string expression, string expectedmessage)
        {
            bool isException = false;
            try
            {
                List<ExpressionItem> expressionItemList = MakeExpressionItemListForTest();
                foreach (ExpressionItem item in expressionItemList)
                {
                    if (parameter.ToLower() == item.Parameter.ToLower())
                    {
                        item.Expression = expression;
                    }
                }
                CheckExpressionItem ce = new CheckExpressionItem(parameter, "A", expressionItemList);
                ce.IsDiffUpperOrLower = _IsDiffUpperOrLower;
                ce.CheckExpressionItemValid();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedmessage, ex.Message);
                isException = true;
            }
            Assert.AreEqual(isException, true);
        }

        private static List<ExpressionItem> MakeExpressionItemListForTest()
        {
            List<ExpressionItem> retListItem = new List<ExpressionItem>();
            for (int i = 1; i <= 900; i++)
            {
                if (i <= 300)
                {
                    retListItem.Add(new ExpressionItem("A" + i, "", EnumDataType.Number));
                }
                if (i > 300 && i <= 600)
                {
                    retListItem.Add(new ExpressionItem("A" + i, "", EnumDataType.DateTime));
                }
                if (i > 600 && i <= 900)
                {
                    retListItem.Add(new ExpressionItem("A" + i, "", EnumDataType.Other));
                }
            }
            return retListItem;
        }

        private static void AssertSuccessTestCase(string parameter, string expression)
        {
            List<ExpressionItem> expressionItemList = MakeExpressionItemListForTest();
            foreach (ExpressionItem item in expressionItemList)
            {
                if (parameter.ToLower() == item.Parameter.ToLower())
                {
                    item.Expression = expression;
                }
            }
            CheckExpressionItem ce = new CheckExpressionItem(parameter, "A", expressionItemList);
            ce.IsDiffUpperOrLower = _IsDiffUpperOrLower;
            Assert.AreEqual(ce.CheckExpressionItemValid(), true);
        }
        #endregion

        #region 其他测试
        [Test, Description("期望不通过验证的用例,验证null值传入的有效处理")]
        public void FailedTest()
        {
            try
            {
                CheckExpressionItem ce = new CheckExpressionItem("A1", "A", null);
                ce.CheckExpressionItemValid();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("A1没有定义，系统无法解释", ex.Message);
            }
        }
        #endregion

        #region Number
        #region 大小写敏感用例
        [Test, Description("期望通过验证的用例")]
        public void SuccessNumberTest()
        {
            _IsDiffUpperOrLower = true;
            AssertSuccessTestCase("A300", "OmitFenJiao(A1)");
            AssertSuccessTestCase("A300", "OmitFen(A13)");
            AssertSuccessTestCase("A300", "RoundToYuan(if(3,2,4))");
            AssertSuccessTestCase("A300", "RoundToJiao(if(3,2,4))");
            AssertSuccessTestCase("A300", "RoundToFen(if(3,2,4))");
            AssertSuccessTestCase("A300", "JianJiaoJinYuan(if(3,2,4))");
            AssertSuccessTestCase("A300", "JianFenJinJiao(if(3,2,4))");
            AssertSuccessTestCase("A300", "NoDealWith(if(3,2,4))");
            AssertSuccessTestCase("A300", "Range(if(3,2,4),8,9)");
            AssertSuccessTestCase("A300", "Range(3,if(2,3,1),9)");
            AssertSuccessTestCase("A300", "Range(1,8,9)");
            AssertSuccessTestCase("A300", "Range(1,9,8)");
            AssertSuccessTestCase("A300", "if(true,4+3,3)");
            AssertSuccessTestCase("A300", "if(true,A33,0)");
            AssertSuccessTestCase("A300", "if(true,A1,0)");
            AssertSuccessTestCase("A300", " A1 + A1");
            AssertSuccessTestCase("A300", "A1　+　A1");
            AssertSuccessTestCase("A300",
                "if(A3<=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))");
            AssertSuccessTestCase("A300",
                "if(A3<=2,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%),if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))");
        }

        [Test, Description("期望不通过验证的用例")]
        public void FailedNumberTest()
        {
            _IsDiffUpperOrLower = true;
            AssertFailedTestCase("A300", "A1/(A3-A3)", "试图除以零。");
            AssertFailedTestCase("A300", "A1/(A3+A4-A4-A3)", "试图除以零。");
            AssertFailedTestCase("A300",
                "if(A3<if=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "if(A3<=2,A5/21.75*A4* 58.88%%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "参数58.88%%是无效表达式");
            AssertFailedTestCase("A300",
                "IfafF(A3<=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "无法识别函数IfafF");
            AssertFailedTestCase("A300",
                "if(A3<=2,3,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "if()函数只可定义3个参数，目前你定义了4个参数");
            AssertFailedTestCase("A300",
                "if(A3<=2,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "if()函数只可定义3个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300",
                "A3joaf",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "Tax(3)",
                "系统无法执行Tax函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "ForeignTax(3)",
                "系统无法执行ForeignTax函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "AnnualBonusTax(3)",
                "系统无法执行AnnualBonusTax函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "AnnualBonusForeignTax(3)",
                "系统无法执行AnnualBonusForeignTax函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "IsSalaryEndDateMonthEquel(3)",
                "系统无法执行IsSalaryEndDateMonthEquel函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "TaxWithPoint(3,3)",
                "系统无法执行TaxWithPoint函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "DoubleSalary(3)",
                "系统无法执行DoubleSalary函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "A1;",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "A1:",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "A1?",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "A1;",
                "语法严重错误，系统无法解释计算公式表达式");
            //AssertFailedTestCase("A300", 
            //    "A1!~@#$%^&*()_",
            //    "语法严重错误，系统无法解释计算公式表达式");
            //AssertFailedTestCase("A300", 
            //    "A1!~@#$%^&*()_",
            //    "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "Range(3,if(2,3,1))",
                "Range()函数只可定义3个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300",
                "RaNge(3,if(2,3,1))",
                "无法识别函数RaNge");
            AssertFailedTestCase("A300", "OmitfenJiao(A1)", "无法识别函数OmitfenJiao");
            AssertFailedTestCase("A300", "OMitFen(A13)", "无法识别函数OMitFen");
            AssertFailedTestCase("A300", "roundToYuan(if(3,2,4))", "无法识别函数roundToYuan");
            AssertFailedTestCase("A300", "RounDToJiao(if(3,2,4))", "无法识别函数RounDToJiao");
            AssertFailedTestCase("A300", "RounDToFen(if(3,2,4))", "无法识别函数RounDToFen");
            AssertFailedTestCase("A300", "JianJiaojinyuan(if(3,2,4))", "无法识别函数JianJiaojinyuan");
            AssertFailedTestCase("A300", "JianFeNJinJiao(if(3,2,4))", "无法识别函数JianFeNJinJiao");
            AssertFailedTestCase("A300", "NoDeaLWith(if(3,2,4))", "无法识别函数NoDeaLWith");

            AssertFailedTestCase("A300", "OmitFenJiao(A1,0)", "OmitFenJiao()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "OmitFen(A13,9)", "OmitFen()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "RoundToYuan(if(3,2,4),9)", "RoundToYuan()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "RoundToJiao(if(3,2,4),7)", "RoundToJiao()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "RoundToFen(if(3,2,4),7)", "RoundToFen()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "JianJiaoJinYuan(if(3,2,4),5)", "JianJiaoJinYuan()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "JianFenJinJiao(if(3,2,4),3)", "JianFenJinJiao()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "NoDealWith(if(3,2,4),7)", "NoDealWith()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "DateMax('2009-9-3',A504)", "无法将A300参数的计算结果转换为数字类型");
            AssertFailedTestCase("A300", "NoDealWith(A504)", "无法将A300参数的计算结果转换为数字类型");
            AssertFailedTestCase("A300", "JianFenJinJiao(A504)", "输入字符串的格式不正确。");
        }

        #endregion
        #region 大小写不敏感用例
        [Test, Description("期望通过验证的用例,大小写不敏感用例")]
        public void SuccessNumber_NoDiffUpperLower_Test()
        {
            _IsDiffUpperOrLower = false;
            AssertSuccessTestCase("A300", "OMitFenJiao(A1)");
            AssertSuccessTestCase("A300", "OmItFen(A13)");
            AssertSuccessTestCase("A300", "RoUndToYuan(if(3,2,4))");
            AssertSuccessTestCase("A300", "RouNdToJiao(if(3,2,4))");
            AssertSuccessTestCase("A300", "RouNdToFEN(if(3,2,4))");
            AssertSuccessTestCase("A300", "JiAnjIaoJinYuan(if(3,2,4))");
            AssertSuccessTestCase("A300", "JIanFenJInJiao(if(3,2,4))");
            AssertSuccessTestCase("A300", "NODealWIth(if(3,2,4))");
            AssertSuccessTestCase("A300", "RANGE(If(3,2,4),8,9)");
            AssertSuccessTestCase("A300", "RANgE(1,8,9)");
            AssertSuccessTestCase("A300", "RaNge(3,if(2,3,1),9)");
            AssertSuccessTestCase("A300", "iF(True,4+3,3)");
            AssertSuccessTestCase("A300", "if(TRUE,A33,0)");
            AssertSuccessTestCase("A300", "if(False,a1,0)");
            AssertSuccessTestCase("A300", " A1 + a1");
            AssertSuccessTestCase("A300", "a1　+　A1");
            AssertSuccessTestCase("A300",
                "IF(A3<=2,A5/21.75*a4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))");
            AssertSuccessTestCase("A300",
                "if(A3<=2,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%),if(a3<=4,A5/ 21.75*A3* 51%,if(a3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))");
        }

        [Test, Description("期望不通过验证的用例,大小写不敏感用例")]
        public void FailedNumber_NoDiffUpperLower_Test()
        {
            _IsDiffUpperOrLower = false;
            AssertFailedTestCase("A300", "A1/(A3-A3)", "试图除以零。");
            AssertFailedTestCase("A300", "a1/(a3+A4-a4-a3)", "试图除以零。");
            AssertFailedTestCase("A300",
                "If(A3<if=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "if(A3<=2,A5/21.75*A4* 58.88%%,if(a3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "参数58.88%%是无效表达式");
            AssertFailedTestCase("A300",
                "IfafF(A3<=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "无法识别函数IFAFF");
            AssertFailedTestCase("A300",
                "if(A3<=2,3,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "if()函数只可定义3个参数，目前你定义了4个参数");
            AssertFailedTestCase("A300",
                "if(A3<=2,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "if()函数只可定义3个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300",
                "A3joaf",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "TAx(3)",
                "系统无法执行Tax函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "AnnUalBonusTax(3)",
                "系统无法执行AnnualBonusTax函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "IssalaryENdDateMonthEquel(3)",
                "系统无法执行IsSalaryEndDateMonthEquel函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "TaxWithPOint(3)",
                "系统无法执行TaxWithPoint函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "DOublesalary(3)",
                "系统无法执行DoubleSalary函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "foreignTAx(3)",
                "系统无法执行ForeignTax函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "AnnUalBonusforeignTax(3)",
                "系统无法执行AnnualBonusForeignTax函数，此函数没有实例化");
            AssertFailedTestCase("A300",
                "A1;",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "A1:",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "A1?",
                "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "A1;",
                "语法严重错误，系统无法解释计算公式表达式");
            //AssertFailedTestCase("A300", 
            //    "A1!~@#$%^&*()_",
            //    "语法严重错误，系统无法解释计算公式表达式");
            //AssertFailedTestCase("A300", 
            //    "A1!~@#$%^&*()_",
            //    "语法严重错误，系统无法解释计算公式表达式");
            AssertFailedTestCase("A300",
                "Range(3,if(2,3,1))",
                "Range()函数只可定义3个参数，目前你定义了2个参数");

            AssertFailedTestCase("A300", "OmItFenJiao(A1,0)", "OmitFenJiao()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "OmiTFen(A13,9)", "OmitFen()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "RouNdToYuan(if(3,2,4),9)", "RoundToYuan()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "RoUndToJiao(if(3,2,4),7)", "RoundToJiao()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "RoUndToFEn(if(3,2,4),7)", "RoundToFen()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "JiAnJiaoJinYuan(if(3,2,4),5)", "JianJiaoJinYuan()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "JianFenJInJiao(if(3,2,4),3)", "JianFenJinJiao()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("A300", "NoDealWiTh(if(3,2,4),7)", "NoDealWith()函数只可定义1个参数，目前你定义了2个参数");
            AssertFailedTestCase("a300", "dateMax('2009-9-3',a504)", "无法将A300参数的计算结果转换为数字类型");
            AssertFailedTestCase("A300", "NoDealWith(a504)", "无法将A300参数的计算结果转换为数字类型");
            AssertFailedTestCase("a300", "jianFenjinjiao(a504)", "输入字符串的格式不正确。");
        }

        #endregion
        #endregion

        #region DateTime
        #region 大小写敏感用例
        [Test, Description("期望通过验证的用例")]
        public void SuccessDateTimeTest()
        {
            _IsDiffUpperOrLower = true;
            AssertSuccessTestCase("A600", "A301");
            AssertSuccessTestCase("A600", "DateMax(A301,'2009-4-4')");
            AssertSuccessTestCase("A600", "DateMax(DateMax(A301,'2009-4-4'),'2009-4-4')");
        }

        [Test, Description("期望不通过验证的用例")]
        public void FailedDateTimeTest()
        {
            _IsDiffUpperOrLower = true;
            AssertFailedTestCase("A600", "DateMax(2009-4-4,A301)", "DateMax()函数的第1个参数无法解释，它必须是日期格式的数据");
            AssertFailedTestCase("A600", "DateMax(A301,2009-4-4)", "DateMax()函数的第2个参数无法解释，它必须是日期格式的数据");
            AssertFailedTestCase("A600", "DateMax(A601,2009-4-4)", "A601参数的数据类型不明，无法计算");
            AssertFailedTestCase("A601", "DateMax(A600,'2009-4-4')", "A601参数的数据类型不明，无法计算");
            AssertFailedTestCase("A600", "Max(A6,A9)", "无法将A600参数的计算结果转换为日期类型");
        }
        #endregion
        #region 大小写不敏感用例
        [Test, Description("期望通过验证的用例,大小写不敏感用例")]
        public void SuccessDateTime_NoDiffUpperLower_Test()
        {
            _IsDiffUpperOrLower = false;
            AssertSuccessTestCase("A600", "a301");
            AssertSuccessTestCase("A600", "DateMAx(A301,'2009-4-4')");
            AssertSuccessTestCase("A600", "datEMax(DateMax(a301,'2009-4-4'),'2009-4-4')");
        }

        [Test, Description("期望不通过验证的用例,大小写不敏感用例")]
        public void FailedDateTime_NoDiffUpperLower_Test()
        {
            _IsDiffUpperOrLower = false;
            AssertFailedTestCase("A600", "DaTeMax(2009-4-4,A301)", "DateMax()函数的第1个参数无法解释，它必须是日期格式的数据");
            AssertFailedTestCase("A600", "datemax(A301,2009-4-4)", "DateMax()函数的第2个参数无法解释，它必须是日期格式的数据");
            AssertFailedTestCase("a600", "dateMax(a601,2009-4-4)", "A601参数的数据类型不明，无法计算");
            AssertFailedTestCase("A601", "DateMaX(a600,'2009-4-4')", "A601参数的数据类型不明，无法计算");
            AssertFailedTestCase("a600", "max(a6,A9)", "无法将A600参数的计算结果转换为日期类型");
        }

        #endregion
        #endregion
    }
}
