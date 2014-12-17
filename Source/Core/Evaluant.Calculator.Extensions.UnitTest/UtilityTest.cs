using System;
using System.Collections;
using NUnit.Framework;

namespace Evaluant.Calculator.Extensions.UnitTest
{
    [TestFixture]
    public class UtilityTest
    {
        [Test, Description("期望通过验证的用例")]
        public void FormatExpressionToDiffUpperOrLowerTest()
        {
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if (true,4+3,3)"), "if(true,4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(false,4+3,3)"), "if(false,4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(not,4+3,3)"), "if(not,4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("IF(And,4+3,3)"), "if(and,4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(OR,4+3,3)"), "if(or,4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(TAX(),4+3,3)"), "if(Tax(),4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(IssalaryEndD ateMonthEquel(),4+3,3)"), "if(IsSalaryEndDateMonthEquel(),4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(TaxWithP Oint(),4+3,3)"), "if(TaxWithPoint(),4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(DoublESalar y(),4+3,3)"), "if(DoubleSalary(),4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(FoReignTAX(),4+3,3)"), "if(ForeignTax(),4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(AnnualBonuS Tax(),4+3,3)"), "if(AnnualBonusTax(),4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("if(AnnualBonuS ForeignTax(),4+3,3)"), "if(AnnualBonusForeignTax(),4+3,3)");
            Assert.AreEqual(Utility.FormatExpressionToDiffUpperOrLower("a1　+　a1"), "A1+A1");
        }

        [Test, Description("期望通过验证的用例")]
        public void GetParameterFromExpressionTest()
        {
            ArrayList arrayListExpected = new ArrayList();
            arrayListExpected.Add("A44");
            arrayListExpected.Add("A43");
            arrayListExpected.Add("A11");
            arrayListExpected.Add("A9");
            arrayListExpected.Add("A4");
            arrayListExpected.Add("A3");
            arrayListExpected.Add("A1");
            AssertParaArray(Utility.GetParameterFromExpression("A1+A4+A9+A43+A44+A3+A11", "A"), arrayListExpected);
        }

        private void AssertParaArray(ArrayList arrayListActual, ArrayList arrayListExpected)
        {
            for (int i = 0; i < arrayListActual.Count; i++)
            {
                Assert.AreEqual(arrayListActual[i], arrayListExpected[i]);
            }
        }

        #region method
        private void UtilitystringArrayTest(string[] testTargetArray)
        {
            for (int i = 0; i < testTargetArray.Length - 1; i++)
            {
                if (testTargetArray[i].Length < testTargetArray[i + 1].Length)
                {
                    throw new Exception(testTargetArray[i] + "应该排在" + testTargetArray[i + 1] + "后面");
                }
                for (int j = i + 1; j < testTargetArray.Length; j++)
                {
                    if (testTargetArray[i] == testTargetArray[j])
                    {
                        throw new Exception("已重复定义" + testTargetArray[i]);
                    }
                }
            }
        }
        private void AssertFailurestringArrayTest(string[] symbols, string message)
        {
            bool isException = false;
            try
            {
                UtilitystringArrayTest(symbols);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, message);
                isException = true;
            }
            Assert.AreEqual(isException, true);
        }
        #endregion
        [Test, Description("验证FunctionName定义的有效性")]
        public void FunctionNameTest()
        {
            UtilitystringArrayTest(Utility.FunctionName);
        }
        [Test, Description("验证LanguageSymbols定义的有效性")]
        public void LanguageSymbolsTest()
        {
            UtilitystringArrayTest(Utility.LanguageSymbols);
        }
        [Test, Description("验证CalculateSymbols定义的有效性")]
        public void CalculateSymbolsTest()
        {
            UtilitystringArrayTest(Utility.CalculateSymbols);
        }
        #region Test TestMethod
        [Test, Description("Failure验证UtilitystringArrayTest")]
        public void UtilitystringArrayTestFailureTest()
        {
            string[] testArrayString = new string[] { "erarfwf", "feeeeeeeeeeeeeeeeeeeeeeeee" };
            AssertFailurestringArrayTest(testArrayString, "erarfwf应该排在feeeeeeeeeeeeeeeeeeeeeeeee后面");
            testArrayString = new string[] { "erarfwf", "gj", "juguyg" };
            AssertFailurestringArrayTest(testArrayString, "gj应该排在juguyg后面");
            testArrayString = new string[] { "erarfwf", "gj", "gj" };
            AssertFailurestringArrayTest(testArrayString, "已重复定义gj");
            testArrayString = new string[] { "gj", "", "" };
            AssertFailurestringArrayTest(testArrayString, "已重复定义");
        }
        [Test, Description("Success验证UtilitystringArrayTest")]
        public void UtilitystringArrayTestSuccessTest()
        {
            string[] testArrayString = new string[] { "erarfwf" };
            UtilitystringArrayTest(testArrayString);
            testArrayString = new string[] { "erarfwf", "" };
            UtilitystringArrayTest(testArrayString);
            testArrayString = new string[] { "erarfwf", "aaa", "sss" };
            UtilitystringArrayTest(testArrayString);
        }
        #endregion
    }
}