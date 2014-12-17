//add by wsl
//计算检查单条表达式
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Evaluant.Calculator.Extensions.UnitTest
{
    [TestFixture]
    public class CalculateExpressionItemListTest
    {
        private static bool _IsDiffUpperOrLower;
        #region method
        private static void AssertListExpressionItem(List<ExpressionItem> actualitems, List<ExpressionItem> expecteditems)
        {
            Assert.AreEqual(actualitems.Count, expecteditems.Count);
            for (int i = 0; i < actualitems.Count; i++)
            {
                Assert.AreEqual(actualitems[i].Parameter, expecteditems[i].Parameter);
                Assert.AreEqual(actualitems[i].Expression, expecteditems[i].Expression);
                Assert.AreEqual(actualitems[i].ExpressionForCalculator, expecteditems[i].ExpressionForCalculator);
                if (expecteditems[i].Result == null)
                {
                    Assert.IsNull(actualitems[i].Result);
                }
                else
                {
                    Assert.AreEqual(actualitems[i].Result.ToString(), expecteditems[i].Result.ToString());
                }
            }
        }

        private static void AddExpectedItem(List<ExpressionItem> actualitems, List<ExpressionItem> expecteditems, ExpressionItem actualExpressionItem,
            ExpressionItem expectedExpressionItem, string expectedexpressionForCalculate, object expectedresult)
        {
            expectedExpressionItem.ExpressionForCalculator = expectedexpressionForCalculate;
            expectedExpressionItem.Result = expectedresult;
            expecteditems.Add(expectedExpressionItem);
            actualitems.Add(actualExpressionItem);
        }
        private static void CalculateAndAssertSuccess(List<ExpressionItem> actualitems, List<ExpressionItem> expecteditems)
        {
            CalculateExpressionItemList ce = new CalculateExpressionItemList(actualitems, "A");
            ce.IsDiffUpperOrLower = _IsDiffUpperOrLower;
            ce.CalculateExpressionResult();
            AssertListExpressionItem(actualitems, expecteditems);
        }
        private static void CalculateAndAssertFailure(List<ExpressionItem> actualitems, string expectedmessage)
        {
            CalculateExpressionItemList ce = new CalculateExpressionItemList(actualitems, "A");
            ce.IsDiffUpperOrLower = _IsDiffUpperOrLower;
            bool isException = false;
            try
            {
                ce.CalculateExpressionResult();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(expectedmessage, ex.Message);
                isException = true;
            }
            Assert.AreEqual(isException, true);
        }
        #endregion
        [Test, Description("期望可计算的用例")]
        public void CalculateExpressionResultTest0()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1%", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A2+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "if(A3>9,1+A2+A1,A3)", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "if(A3>9,1+A2+A1,if(A3>9,1+A2+A1,A3))", EnumDataType.Number));
            items.Add(
                new ExpressionItem("A6",
                                   "if(A3<=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))", EnumDataType.Number));
            items.Add(
                new ExpressionItem("A7",
                                   "if(A3<=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))", EnumDataType.Number));
            items.Add(
                new ExpressionItem("A8",
                                   "if(A3<=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))", EnumDataType.Number));
            items.Add(new ExpressionItem("A9", "if(A3>9,1+A2+A1,if(A3>9,1+A2+A1,A3))", EnumDataType.Number));
            items.Add(new ExpressionItem("A10", "if(A3>9,1+A2+A1,if(A3>9,1+A2+A1,A3))", EnumDataType.Number));
            items.Add(new ExpressionItem("A11", "A1+A10", EnumDataType.Number));
            items.Add(new ExpressionItem("A13", "A2+A21", EnumDataType.Number));
            items.Add(new ExpressionItem("A21", "A11+A1", EnumDataType.Number));


            items.Add(new ExpressionItem("A301", "'2008-4-4'", EnumDataType.DateTime));
            items.Add(new ExpressionItem("A302", "DateMax('2008-4-4',A301)", EnumDataType.DateTime));
            CalculateExpressionItemList ce = new CalculateExpressionItemList(items, "A");
            ce.CalculateExpressionResult();
        }
        //nh集成测试贡献用例
        public void CalculateExpressionResultTest00()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            Random rd = new Random();
            items.Add(new ExpressionItem("A1", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A2", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A3", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A4", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A5", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A6", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A7", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A8", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A10", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A12", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A13", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A15", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A17", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A19", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A21", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A23", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A24", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A25", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A26", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A27", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A28", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A29", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A30", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A31", rd.NextDouble().ToString(), EnumDataType.Number));
            items.Add(new ExpressionItem("A9", "(A1 + A2 + A7)/21.75*A8", EnumDataType.Number));
            items.Add(new ExpressionItem("A16", "(A1 + A2 + A7)*10%*A15", EnumDataType.Number));
            items.Add(
                new ExpressionItem("A32",
                                   "IF(A30 <= 2, 58%, IF(A30 <= 4, 51%, IF(A30 <= 6, 44%, IF(A30 <= 8, 37%, 30%))))", EnumDataType.Number));
            items.Add(new ExpressionItem("A20", "(A1 + A2 + A7)/21.75*A19*70%", EnumDataType.Number));
            items.Add(new ExpressionItem("A18", "(A1 + A2 + A7)/21.75*A17*70%", EnumDataType.Number));
            items.Add(new ExpressionItem("A11", "(A1 + A2 + A7)/21.75*A10*A30", EnumDataType.Number));
            items.Add(new ExpressionItem("A22", "(A1 + A2 + A7)/21.75*A21", EnumDataType.Number));
            items.Add(new ExpressionItem("A14", "A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A33", "A1 + A2 + A3 + A4 + A5 + A6 + A7 - A9 - A11 - A16 - A18 - A20 - A22", EnumDataType.Number));
            items.Add(new ExpressionItem("A37", "A27*0.07", EnumDataType.Number));
            items.Add(new ExpressionItem("A34", "A29*0.08", EnumDataType.Number));
            items.Add(new ExpressionItem("A35", "A29*0.02", EnumDataType.Number));
            items.Add(new ExpressionItem("A36", "A29*0.01", EnumDataType.Number));
            items.Add(new ExpressionItem("A39", "A29*0.01", EnumDataType.Number));
            items.Add(new ExpressionItem("A38", "A34 + A35 + A36 + A39 + A37", EnumDataType.Number));
            items.Add(new ExpressionItem("A40", "A33 - A38", EnumDataType.Number));
            CalculateExpressionItemList ce = new CalculateExpressionItemList(items, "A");
            ce.CalculateExpressionResult();
        }

        #region 大小写敏感用例
        [Test, Description("期望可计算的用例")]
        public void CalculateExpressionResultTest1()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+A1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1)", "2");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), "'2009-3-4'", "2009-3-4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), "DateMax('2009-4-4','2009-6-6')", "2009-6-6 0:00:00");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "DateMax(DateMax('2009-4-4',A3),'2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A5", "DateMax(DateMax('2009-4-4',A3),'2009-6-6')", EnumDataType.DateTime), "DateMax(DateMax('2009-4-4',('2009-3-4')),'2009-6-6')", "2009-6-6 0:00:00");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例")]
        public void CalculateExpressionResultTest3()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1%", EnumDataType.Number), new ExpressionItem("A1", "1%", EnumDataType.Number),
                            "1*0.01", "0.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+A1", EnumDataType.Number),
                            new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1*0.01)", "1.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "1+A2+A1", EnumDataType.Number),
                            new ExpressionItem("A3", "1+A2+A1", EnumDataType.Number), "1+(1+(1*0.01))+(1*0.01)", "2.02");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "if(A3>9,1+A2+A1,A3)", EnumDataType.Number),
                            new ExpressionItem("A4", "if(A3>9,1+A2+A1,A3)", EnumDataType.Number),
                            "if((1+(1+(1*0.01))+(1*0.01))>9,1+(1+(1*0.01))+(1*0.01),(1+(1+(1*0.01))+(1*0.01)))", "2.02");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "if(A3>9,1+A2+A1,if(A3>9,1+A2+A1,A3))", EnumDataType.Number),
                            new ExpressionItem("A5", "if(A3>9,1+A2+A1,if(A3>9,1+A2+A1,A3))", EnumDataType.Number),
                            "if((1+(1+(1*0.01))+(1*0.01))>9,1+(1+(1*0.01))+(1*0.01),if((1+(1+(1*0.01))+(1*0.01))>9,1+(1+(1*0.01))+(1*0.01),(1+(1+(1*0.01))+(1*0.01))))",
                            "2.02");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例")]
        public void CalculateExpressionResultTest4()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "if(A3<9,1+A2,if(A3>9,1+A1,A3))", EnumDataType.Number), new ExpressionItem("A5", "if(A3<9,1+A2,if(A3>9,1+A1,A3))", EnumDataType.Number), "if((1+(1+(1*0.01))+(1*0.01))<9,1+(1+(1*0.01)),if((1+(1+(1*0.01))+(1*0.01))>9,1+(1*0.01),(1+(1+(1*0.01))+(1*0.01))))", "2.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1%", EnumDataType.Number), new ExpressionItem("A1", "1%", EnumDataType.Number), "1*0.01", "0.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+A1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1*0.01)", "1.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "1+A2+A1", EnumDataType.Number), new ExpressionItem("A3", "1+A2+A1", EnumDataType.Number), "1+(1+(1*0.01))+(1*0.01)", "2.02");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "if(A3>9,1+A1,A3)", EnumDataType.Number), new ExpressionItem("A4", "if(A3>9,1+A1,A3)", EnumDataType.Number), "if((1+(1+(1*0.01))+(1*0.01))>9,1+(1*0.01),(1+(1+(1*0.01))+(1*0.01)))", "2.02");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例")]
        public void CalculateExpressionResultTest5()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1%", EnumDataType.Number), new ExpressionItem("A1", "1%", EnumDataType.Number),
                            "1*0.01", "0.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "Range(1+A1,1,0.5)", EnumDataType.Number),
                            new ExpressionItem("A2", "Range(1+A1,1,0.5)", EnumDataType.Number), "Range(1+(1*0.01),1,0.5)", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "Range(-1+A1,1,0.5)", EnumDataType.Number),
                            new ExpressionItem("A3", "Range(-1+A1,1,0.5)", EnumDataType.Number), "Range(-1+(1*0.01),1,0.5)", "0.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "Range(1.5,1.5,0.5)", EnumDataType.Number),
                            new ExpressionItem("A4", "Range(1.5,1.5,0.5)", EnumDataType.Number), "Range(1.5,1.5,0.5)", "1.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "Range(0.5,1.5,0.5)", EnumDataType.Number),
                            new ExpressionItem("A5", "Range(0.5,1.5,0.5)", EnumDataType.Number), "Range(0.5,1.5,0.5)", "0.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A6", "Range(1.5,0.5,1.5)", EnumDataType.Number),
                            new ExpressionItem("A6", "Range(1.5,0.5,1.5)", EnumDataType.Number), "Range(1.5,0.5,1.5)", "1.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A7", "Range(0.5,0.5,1.5)", EnumDataType.Number),
                            new ExpressionItem("A7", "Range(0.5,0.5,1.5)", EnumDataType.Number), "Range(0.5,0.5,1.5)", "0.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A8", "Range(0.15,0.5,0.5)", EnumDataType.Number),
                            new ExpressionItem("A8", "Range(0.15,0.5,0.5)", EnumDataType.Number), "Range(0.15,0.5,0.5)", "0.5");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,NoDealWith")]
        public void CalculateExpressionResultTest6()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "NoDealWith(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "NoDealWith(10.01342)", EnumDataType.Number), "NoDealWith(10.01342)", "10.01342");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "NoDealWith(10.51342)", EnumDataType.Number), new ExpressionItem("A2", "NoDealWith(10.51342)", EnumDataType.Number), "NoDealWith(10.51342)", "10.51342");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "NoDealWith(10.91342)", EnumDataType.Number), new ExpressionItem("A3", "NoDealWith(10.91342)", EnumDataType.Number), "NoDealWith(10.91342)", "10.91342");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "NoDealWith(10.41342)", EnumDataType.Number), new ExpressionItem("A4", "NoDealWith(10.41342)", EnumDataType.Number), "NoDealWith(10.41342)", "10.41342");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,JianFenJinJiao")]
        public void CalculateExpressionResultTest7()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "JianFenJinJiao(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "JianFenJinJiao(10.01342)", EnumDataType.Number), "JianFenJinJiao(10.01342)", "10.1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "JianFenJinJiao(10.05342)", EnumDataType.Number), new ExpressionItem("A2", "JianFenJinJiao(10.05342)", EnumDataType.Number), "JianFenJinJiao(10.05342)", "10.1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "JianFenJinJiao(10.09342)", EnumDataType.Number), new ExpressionItem("A3", "JianFenJinJiao(10.09342)", EnumDataType.Number), "JianFenJinJiao(10.09342)", "10.1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "JianFenJinJiao(10.04342)", EnumDataType.Number), new ExpressionItem("A4", "JianFenJinJiao(10.04342)", EnumDataType.Number), "JianFenJinJiao(10.04342)", "10.1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "JianFenJinJiao(10.90956)", EnumDataType.Number), new ExpressionItem("A5", "JianFenJinJiao(10.90956)", EnumDataType.Number), "JianFenJinJiao(10.90956)", "10.9");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A6", "JianFenJinJiao(81.21)", EnumDataType.Number), new ExpressionItem("A6", "JianFenJinJiao(81.21)", EnumDataType.Number), "JianFenJinJiao(81.21)", "81.3");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,JianJiaoJinYuan")]
        public void CalculateExpressionResultTest8()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "JianJiaoJinYuan(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "JianJiaoJinYuan(10.01342)", EnumDataType.Number), "JianJiaoJinYuan(10.01342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "JianJiaoJinYuan(10.00001)", EnumDataType.Number), new ExpressionItem("A2", "JianJiaoJinYuan(10.00001)", EnumDataType.Number), "JianJiaoJinYuan(10.00001)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "JianJiaoJinYuan(10.51111)", EnumDataType.Number), new ExpressionItem("A3", "JianJiaoJinYuan(10.51111)", EnumDataType.Number), "JianJiaoJinYuan(10.51111)", "11");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "JianJiaoJinYuan(10.49999)", EnumDataType.Number), new ExpressionItem("A4", "JianJiaoJinYuan(10.49999)", EnumDataType.Number), "JianJiaoJinYuan(10.49999)", "11");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "JianJiaoJinYuan(10.09999)", EnumDataType.Number), new ExpressionItem("A5", "JianJiaoJinYuan(10.09999)", EnumDataType.Number), "JianJiaoJinYuan(10.09999)", "10");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,RoundToJiao")]
        public void CalculateExpressionResultTest9()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "RoundToJiao(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "RoundToJiao(10.01342)", EnumDataType.Number), "RoundToJiao(10.01342)", "10.0");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "RoundToJiao(10.49999)", EnumDataType.Number), new ExpressionItem("A2", "RoundToJiao(10.49999)", EnumDataType.Number), "RoundToJiao(10.49999)", "10.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "RoundToJiao(10.44999)", EnumDataType.Number), new ExpressionItem("A3", "RoundToJiao(10.44999)", EnumDataType.Number), "RoundToJiao(10.44999)", "10.4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "RoundToJiao(10.50000)", EnumDataType.Number), new ExpressionItem("A4", "RoundToJiao(10.50000)", EnumDataType.Number), "RoundToJiao(10.50000)", "10.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "RoundToJiao(10.50001)", EnumDataType.Number), new ExpressionItem("A5", "RoundToJiao(10.50001)", EnumDataType.Number), "RoundToJiao(10.50001)", "10.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A6", "RoundToJiao(-10.05000)", EnumDataType.Number), new ExpressionItem("A6", "RoundToJiao(-10.05000)", EnumDataType.Number), "RoundToJiao(-10.05000)", "-10.1");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,RoundToYuan")]
        public void CalculateExpressionResultTest10()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "RoundToYuan(10.49999)", EnumDataType.Number), new ExpressionItem("A1", "RoundToYuan(10.49999)", EnumDataType.Number), "RoundToYuan(10.49999)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "RoundToYuan(10.50000)", EnumDataType.Number), new ExpressionItem("A2", "RoundToYuan(10.50000)", EnumDataType.Number), "RoundToYuan(10.50000)", "11");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "RoundToYuan(-10.50001)", EnumDataType.Number), new ExpressionItem("A3", "RoundToYuan(-10.50001)", EnumDataType.Number), "RoundToYuan(-10.50001)", "-11");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,OmitFen")]
        public void CalculateExpressionResultTest11()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "OmitFen(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "OmitFen(10.01342)", EnumDataType.Number), "OmitFen(10.01342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "OmitFen(10.09342)", EnumDataType.Number), new ExpressionItem("A2", "OmitFen(10.09342)", EnumDataType.Number), "OmitFen(10.09342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "OmitFen(10.99342)", EnumDataType.Number), new ExpressionItem("A3", "OmitFen(10.99342)", EnumDataType.Number), "OmitFen(10.99342)", "10.9");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,OmitFenJiao")]
        public void CalculateExpressionResultTest12()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "OmitFenJiao(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "OmitFenJiao(10.01342)", EnumDataType.Number), "OmitFenJiao(10.01342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "OmitFenJiao(10.91342)", EnumDataType.Number), new ExpressionItem("A2", "OmitFenJiao(10.91342)", EnumDataType.Number), "OmitFenJiao(10.91342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "OmitFenJiao(19.99999)", EnumDataType.Number), new ExpressionItem("A3", "OmitFenJiao(19.99999)", EnumDataType.Number), "OmitFenJiao(19.99999)", "19");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,RoundToFen")]
        public void CalculateExpressionResultTest13()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "RoundToFen(10.01442)", EnumDataType.Number), new ExpressionItem("A1", "RoundToFen(10.01442)", EnumDataType.Number), "RoundToFen(10.01442)", "10.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "RoundToFen(10.49999)", EnumDataType.Number), new ExpressionItem("A2", "RoundToFen(10.49999)", EnumDataType.Number), "RoundToFen(10.49999)", "10.50");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "RoundToFen(10.44999)", EnumDataType.Number), new ExpressionItem("A3", "RoundToFen(10.44999)", EnumDataType.Number), "RoundToFen(10.44999)", "10.45");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A7", "RoundToFen(10.44499)", EnumDataType.Number), new ExpressionItem("A7", "RoundToFen(10.44499)", EnumDataType.Number), "RoundToFen(10.44499)", "10.44");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "RoundToFen(10.50000)", EnumDataType.Number), new ExpressionItem("A4", "RoundToFen(10.50000)", EnumDataType.Number), "RoundToFen(10.50000)", "10.50");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "RoundToFen(10.50001)", EnumDataType.Number), new ExpressionItem("A5", "RoundToFen(10.50001)", EnumDataType.Number), "RoundToFen(10.50001)", "10.50");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A6", "RoundToFen(-10.05000)", EnumDataType.Number), new ExpressionItem("A6", "RoundToFen(-10.05000)", EnumDataType.Number), "RoundToFen(-10.05000)", "-10.05");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }

        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest1()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "试图除以零。");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest2()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "Tax(1)", EnumDataType.Number), new ExpressionItem("A1", "Tax(1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行Tax函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest3()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "AnnualBonusTax (1)", EnumDataType.Number), new ExpressionItem("A1", "AnnualBonusTax (1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行AnnualBonusTax函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest4()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "OmitFenJiao (1,7,7)", EnumDataType.Number), new ExpressionItem("A1", "OmitFenJiao (1)", EnumDataType.Number), "1", "1");
            CalculateAndAssertFailure(actualitems, "OmitFenJiao()函数只可定义1个参数，目前你定义了3个参数");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest5()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+A1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1)", "2");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), "'2009-3-4'", "2009-3-4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), "DateMax('2009-4-4','2009-6-6')", "2009-6-6 0:00:00");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "DateMax(DateMax('2009-4-4',A2),'2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A5", "DateMax(DateMax('2009-4-4',A2),'2009-6-6')", EnumDataType.DateTime), "DateMax(DateMax('2009-4-4',(1+'1')),'2009-6-6')", "2009-6-6 0:00:00");
            CalculateAndAssertFailure(actualitems, "DateMax()函数的第2个参数无法解释，它必须是日期格式的数据");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest6()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+A1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1)", "2");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), "'2009-3-4'", "2009-3-4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), "DateMax('2009-4-4','2009-6-6')", "2009-6-6 0:00:00");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "DateMax(DateMax(A2,'2009-4-4'),'2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A5", "DateMax(DateMax(A2,'2009-4-4'),'2009-6-6')", EnumDataType.DateTime), "DateMax(DateMax((1+'1') ,'2009-4-4'),'2009-6-6')", "2009-6-6 0:00:00");
            CalculateAndAssertFailure(actualitems, "DateMax()函数的第1个参数无法解释，它必须是日期格式的数据");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest7()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+A1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1)", "2");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), "'2009-3-4'", "2009-3-4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), "DateMax('2009-4-4','2009-6-6')", "2009-6-6 0:00:00");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "JianFenJinJiao(A4)", EnumDataType.DateTime), new ExpressionItem("A5", "JianFenJinJiao(A4)", EnumDataType.DateTime), "JianFenJinJiao((DateMax('2009-4-4','2009-6-6'))) ,'2009-4-4'),'2009-6-6')", "2009-6-6 0:00:00");
            CalculateAndAssertFailure(actualitems, "从“DateTime”到“Decimal”的强制转换无效。");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest8()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "ForeignTax(1)", EnumDataType.Number), new ExpressionItem("A1", "ForeignTax(1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行ForeignTax函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest9()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "AnnualBonusForeignTax (1)", EnumDataType.Number), new ExpressionItem("A1", "AnnualBonusForeignTax (1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行AnnualBonusForeignTax函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest10()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "IsSalaryEndDateMonthEquel (1)", EnumDataType.Number), new ExpressionItem("A1", "IsSalaryEndDateMonthEquel (1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行IsSalaryEndDateMonthEquel函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest11()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "DoubleSalary (1)", EnumDataType.Number), new ExpressionItem("A1", "DoubleSalary (1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行DoubleSalary函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailureTest12()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "TaxWithPoint (1,9)", EnumDataType.Number), new ExpressionItem("A1", "TaxWithPoint (1,9)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行TaxWithPoint函数，此函数没有实例化");
        }

        #endregion
        #region 大小写不敏感用例
        [Test, Description("期望可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test1()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a2", "1+A1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1)", "2");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), "'2009-3-4'", "2009-3-4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "dateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), "DateMax('2009-4-4','2009-6-6')", "2009-6-6 0:00:00");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a5", "Datemax(dateMax('2009-4-4',A3),'2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A5", "DateMax(DateMax('2009-4-4',A3),'2009-6-6')", EnumDataType.DateTime), "DateMax(DateMax('2009-4-4',('2009-3-4')),'2009-6-6')", "2009-6-6 0:00:00");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test3()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a1", "1%", EnumDataType.Number), new ExpressionItem("A1", "1%", EnumDataType.Number),
                            "1*0.01", "0.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+a1", EnumDataType.Number),
                            new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1*0.01)", "1.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "1+A2+A1", EnumDataType.Number),
                            new ExpressionItem("A3", "1+A2 + A1", EnumDataType.Number), "1+(1+(1*0.01))+(1*0.01)", "2.02");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "IF(a3>9,1+a2+A1,A3)", EnumDataType.Number),
                            new ExpressionItem("A4", "if(A3>9,1+A2+A1,A3)", EnumDataType.Number),
                            "if((1+(1+(1*0.01))+(1*0.01))>9,1+(1+(1*0.01))+(1*0.01),(1+(1+(1*0.01))+(1*0.01)))", "2.02");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "if(A3>9, 1+A 2 +A1,if(A3>9,1+A2+A1,A3))", EnumDataType.Number),
                            new ExpressionItem("A5", "if(A3>9,1+A2+A1,if(A3>9,1+A2+A1,A3))", EnumDataType.Number),
                            "if((1+(1+(1*0.01))+(1*0.01))>9,1+(1+(1*0.01))+(1*0.01),if((1+(1+(1*0.01))+(1*0.01))>9,1+(1+(1*0.01))+(1*0.01),(1+(1+(1*0.01))+(1*0.01))))",
                            "2.02");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }

        [Test, Description("期望可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test4()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "IF(A3<9,1+A2,if(A3>9,1+A1,A3))", EnumDataType.Number), new ExpressionItem("A5", "if(A3<9,1+A2,if(A3>9,1+A1,A3))", EnumDataType.Number), "if((1+(1+(1*0.01))+(1*0.01))<9,1+(1+(1*0.01)),if((1+(1+(1*0.01))+(1*0.01))>9,1+(1*0.01),(1+(1+(1*0.01))+(1*0.01))))", "2.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1%", EnumDataType.Number), new ExpressionItem("A1", "1%", EnumDataType.Number), "1*0.01", "0.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+ A1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1*0.01)", "1.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "1+ A2+A1", EnumDataType.Number), new ExpressionItem("A3", "1+A2+A1", EnumDataType.Number), "1+(1+(1*0.01))+(1*0.01)", "2.02");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "iF(a3>9,1+A1,A3)", EnumDataType.Number), new ExpressionItem("A4", "if(A3>9,1+A1,A3)", EnumDataType.Number), "if((1+(1+(1*0.01))+(1*0.01))>9,1+(1*0.01),(1+(1+(1*0.01))+(1*0.01)))", "2.02");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test5()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1%", EnumDataType.Number), new ExpressionItem("A1", "1%", EnumDataType.Number),
                            "1*0.01", "0.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a2", "range(1+A1,1,0.5)", EnumDataType.Number),
                            new ExpressionItem("A2", "Range(1+A1,1,0.5)", EnumDataType.Number), "Range(1+(1*0.01),1,0.5)", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a3", "RANGE (-1+A1,1,0.5)", EnumDataType.Number),
                            new ExpressionItem("A3", "Range(-1+A1,1,0.5)", EnumDataType.Number), "Range(-1+(1*0.01),1,0.5)", "0.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a 4", "Range (1.5,1.5,0.5)", EnumDataType.Number),
                            new ExpressionItem("A4", "Range(1.5,1.5,0.5)", EnumDataType.Number), "Range(1.5,1.5,0.5)", "1.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "Range(0.5,1.5,0.5)", EnumDataType.Number),
                            new ExpressionItem("A5", "Range(0.5,1.5,0.5)", EnumDataType.Number), "Range(0.5,1.5,0.5)", "0.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A6", "Range(1.5,0.5,1.5)", EnumDataType.Number),
                            new ExpressionItem("A6", "Range(1.5,0.5,1.5)", EnumDataType.Number), "Range(1.5,0.5,1.5)", "1.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A7", "Range(0.5,0.5,1.5)", EnumDataType.Number),
                            new ExpressionItem("A7", "Range(0.5,0.5,1.5)", EnumDataType.Number), "Range(0.5,0.5,1.5)", "0.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A8", "Rang e (0 . 1 5, 0 . 5,0.5)", EnumDataType.Number),
                         new ExpressionItem("A8", "Range(0.15,0.5,0.5)", EnumDataType.Number), "Range(0.15,0.5,0.5)", "0.5");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例,NoDealWith")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test6()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "NoDEAlWith(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "NoDealWith(10.01342)", EnumDataType.Number), "NoDealWith(10.01342)", "10.01342");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "NoDealWIth(10.51342)", EnumDataType.Number), new ExpressionItem("A2", "NoDealWith(10.51342)", EnumDataType.Number), "NoDealWith(10.51342)", "10.51342");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "NoDealWith(10.91342)", EnumDataType.Number), new ExpressionItem("A3", "NoDealWith(10.91342)", EnumDataType.Number), "NoDealWith(10.91342)", "10.91342");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "NoDealWith(10.41342)", EnumDataType.Number), new ExpressionItem("A4", "NoDealWith(10.41342)", EnumDataType.Number), "NoDealWith(10.41342)", "10.41342");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例,JianFenJinJiao")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test7()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "JianFenJinJiao(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "JianFenJinJiao(10.01342)", EnumDataType.Number), "JianFenJinJiao(10.01342)", "10.1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "JianFen JinJiao(10.05342)", EnumDataType.Number), new ExpressionItem("A2", "JianFenJinJiao(10.05342)", EnumDataType.Number), "JianFenJinJiao(10.05342)", "10.1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "Ji anFenJinJiao(10.09342)", EnumDataType.Number), new ExpressionItem("A3", "JianFenJinJiao(10.09342)", EnumDataType.Number), "JianFenJinJiao(10.09342)", "10.1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "JianFenJinJiao(10.04342)", EnumDataType.Number), new ExpressionItem("A4", "JianFenJinJiao(10.04342)", EnumDataType.Number), "JianFenJinJiao(10.04342)", "10.1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "JianFenJinj iao(10.90956)", EnumDataType.Number), new ExpressionItem("A5", "JianFenJinJiao(10.90956)", EnumDataType.Number), "JianFenJinJiao(10.90956)", "10.9");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例,JianJiaoJinYuan")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test8()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "JianJi aoJinYuan(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "JianJiaoJinYuan(10.01342)", EnumDataType.Number), "JianJiaoJinYuan(10.01342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "Jianj iaoJinYuan(10.00001)", EnumDataType.Number), new ExpressionItem("A2", "JianJiaoJinYuan(10.00001)", EnumDataType.Number), "JianJiaoJinYuan(10.00001)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "jianJiaoJinYuan(10.51111)", EnumDataType.Number), new ExpressionItem("A3", "JianJiaoJinYuan(10.51111)", EnumDataType.Number), "JianJiaoJinYuan(10.51111)", "11");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "JianJiaoJinYuan(10.49999)", EnumDataType.Number), new ExpressionItem("A4", "JianJiaoJinYuan(10.49999)", EnumDataType.Number), "JianJiaoJinYuan(10.49999)", "11");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "Ji AnJiaoJinYuan(10.09999)", EnumDataType.Number), new ExpressionItem("A5", "JianJiaoJinYuan(10.09999)", EnumDataType.Number), "JianJiaoJinYuan(10.09999)", "10");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例,RoundToJiao")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test9()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "rOundToJiao(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "RoundToJiao(10.01342)", EnumDataType.Number), "RoundToJiao(10.01342)", "10.0");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "RoundToJiao(10.49999)", EnumDataType.Number), new ExpressionItem("A2", "RoundToJiao(10.49999)", EnumDataType.Number), "RoundToJiao(10.49999)", "10.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "Rou ndToJiao(10.44999)", EnumDataType.Number), new ExpressionItem("A3", "RoundToJiao(10.44999)", EnumDataType.Number), "RoundToJiao(10.44999)", "10.4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "ROundToJiao(10.50000)", EnumDataType.Number), new ExpressionItem("A4", "RoundToJiao(10.50000)", EnumDataType.Number), "RoundToJiao(10.50000)", "10.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "roundtoJiao(10.50001)", EnumDataType.Number), new ExpressionItem("A5", "RoundToJiao(10.50001)", EnumDataType.Number), "RoundToJiao(10.50001)", "10.5");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A6", "RoundToJiao(10.05000)", EnumDataType.Number), new ExpressionItem("A6", "RoundToJiao(10.05000)", EnumDataType.Number), "RoundToJiao(10.05000)", "10.1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A7", "RoundToJiao(-10.05000)", EnumDataType.Number), new ExpressionItem("A7", "RoundToJiao(-10.05000)", EnumDataType.Number), "RoundToJiao(-10.05000)", "-10.1");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例,RoundToYuan")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test10()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "Roun dToYuan(10.49999)", EnumDataType.Number), new ExpressionItem("A1", "RoundToYuan(10.49999)", EnumDataType.Number), "RoundToYuan(10.49999)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "RoundToYuan(10.50000)", EnumDataType.Number), new ExpressionItem("A2", "RoundToYuan(10.50000)", EnumDataType.Number), "RoundToYuan(10.50000)", "11");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "RoundToYuan(10.50001)", EnumDataType.Number), new ExpressionItem("A3", "RoundToYuan(10.50001)", EnumDataType.Number), "RoundToYuan(10.50001)", "11");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "RoundToYuan(-10.50001)", EnumDataType.Number), new ExpressionItem("A4", "RoundToYuan(-10.50001)", EnumDataType.Number), "RoundToYuan(-10.50001)", "-11");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例,OmitFen")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test11()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "Omitfen(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "OmitFen(10.01342)", EnumDataType.Number), "OmitFen(10.01342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "Omit Fen(10.09342)", EnumDataType.Number), new ExpressionItem("A2", "OmitFen(10.09342)", EnumDataType.Number), "OmitFen(10.09342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "omitFen(10.99342)", EnumDataType.Number), new ExpressionItem("A3", "OmitFen(10.99342)", EnumDataType.Number), "OmitFen(10.99342)", "10.9");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例,OmitFenJiao")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test12()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "OmitfenJiao(10.01342)", EnumDataType.Number), new ExpressionItem("A1", "OmitFenJiao(10.01342)", EnumDataType.Number), "OmitFenJiao(10.01342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "omit Fen jiao(10.91342)", EnumDataType.Number), new ExpressionItem("A2", "OmitFenJiao(10.91342)", EnumDataType.Number), "OmitFenJiao(10.91342)", "10");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "omitFenJiao(19.99999)", EnumDataType.Number), new ExpressionItem("A3", "OmitFenJiao(19.99999)", EnumDataType.Number), "OmitFenJiao(19.99999)", "19");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }
        [Test, Description("期望可计算的用例,大小写不敏感用例,RoundToFen")]
        public void CalculateExpressionResult_NoDiffUpperLower_Test13()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "ROUndToFen(10.01442)", EnumDataType.Number), new ExpressionItem("A1", "RoundToFen(10.01442)", EnumDataType.Number), "RoundToFen(10.01442)", "10.01");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "RoundToFen(10.49999)", EnumDataType.Number), new ExpressionItem("A2", "RoundToFen(10.49999)", EnumDataType.Number), "RoundToFen(10.49999)", "10.50");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "RouN dToFen(10.44999)", EnumDataType.Number), new ExpressionItem("A3", "RoundToFen(10.44999)", EnumDataType.Number), "RoundToFen(10.44999)", "10.45");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A7", "RouNdToFen(10.44499)", EnumDataType.Number), new ExpressionItem("A7", "RoundToFen(10.44499)", EnumDataType.Number), "RoundToFen(10.44499)", "10.44");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "Rou  ndT oFen(10.50000)", EnumDataType.Number), new ExpressionItem("A4", "RoundToFen(10.50000)", EnumDataType.Number), "RoundToFen(10.50000)", "10.50");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "RoUndToFen(10.50001)", EnumDataType.Number), new ExpressionItem("A5", "RoundToFen(10.50001)", EnumDataType.Number), "RoundToFen(10.50001)", "10.50");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A6", "RounDToFen(-10.05000)", EnumDataType.Number), new ExpressionItem("A6", "RoundToFen(-10.05000)", EnumDataType.Number), "RoundToFen(-10.05000)", "-10.05");
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }


        [Test, Description("期望不可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test1()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+ 1 +A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "试图除以零。");
        }
        [Test, Description("期望不可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test2()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a1", "TAx(1)", EnumDataType.Number), new ExpressionItem("A1", "Tax(1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行Tax函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test3()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "AnnUalBonUsTax (1)", EnumDataType.Number), new ExpressionItem("A1", "AnnualBonusTax (1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行AnnualBonusTax函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test4()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "Omit fenJiao (1,7,7)", EnumDataType.Number), new ExpressionItem("A1", "OmitFenJiao (1)", EnumDataType.Number), "1", "1");
            CalculateAndAssertFailure(actualitems, "OmitFenJiao()函数只可定义1个参数，目前你定义了3个参数");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test5()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a2", "1+A1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1)", "2");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), "'2009-3-4'", "2009-3-4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), "DateMax('2009-4-4','2009-6-6')", "2009-6-6 0:00:00");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "DateMax(dateMax('2009-4-4',A2),'2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A5", "DateMax(DateMax('2009-4-4',A2),'2009-6-6')", EnumDataType.DateTime), "DateMax(DateMax('2009-4-4',(1+'1')),'2009-6-6')", "2009-6-6 0:00:00");
            CalculateAndAssertFailure(actualitems, "DateMax()函数的第2个参数无法解释，它必须是日期格式的数据");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test6()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+a1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1)", "2");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), "'2009-3-4'", "2009-3-4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), "DateMax('2009-4-4','2009-6-6')", "2009-6-6 0:00:00");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A5", "Datemax(dateMax(A2,'2009-4-4'),'2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A5", "DateMax(DateMax(A2,'2009-4-4'),'2009-6-6')", EnumDataType.DateTime), "DateMax(DateMax((1+'1') ,'2009-4-4'),'2009-6-6')", "2009-6-6 0:00:00");
            CalculateAndAssertFailure(actualitems, "DateMax()函数的第1个参数无法解释，它必须是日期格式的数据");
        }
        [Test, Description("期望不可计算的用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLowerTest7()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1+A1", EnumDataType.Number), new ExpressionItem("A2", "1+A1", EnumDataType.Number), "1+(1)", "2");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a3", "'2009-3-4'", EnumDataType.DateTime), new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), "'2009-3-4'", "2009-3-4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), new ExpressionItem("A4", "DateMax('2009-4-4','2009-6-6')", EnumDataType.DateTime), "DateMax('2009-4-4','2009-6-6')", "2009-6-6 0:00:00");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a5", "JianFenJinJIao(A4)", EnumDataType.DateTime), new ExpressionItem("A5", "JianFenJinJiao(A4)", EnumDataType.DateTime), "JianFenJinJiao((DateMax('2009-4-4','2009-6-6'))) ,'2009-4-4'),'2009-6-6')", "2009-6-6 0:00:00");
            CalculateAndAssertFailure(actualitems, "从“DateTime”到“Decimal”的强制转换无效。");
        }
        [Test, Description("期望不可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test8()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a1", "foreignTAx(1)", EnumDataType.Number), new ExpressionItem("A1", "ForeignTax(1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("a2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行ForeignTax函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test9()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "AnnUalBonUsforeignTax (1)", EnumDataType.Number), new ExpressionItem("A1", "AnnualBonusForeignTax (1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行AnnualBonusForeignTax函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test10()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "isSalaryendDateMonthEQuel (1)", EnumDataType.Number), new ExpressionItem("A1", "IsSalaryEndDateMonthEquel (1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行IsSalaryEndDateMonthEquel函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test11()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "DOublesalary (1)", EnumDataType.Number), new ExpressionItem("A1", "DoubleSalary (1)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行DoubleSalary函数，此函数没有实例化");
        }
        [Test, Description("期望不可计算的用例,大小写不敏感用例")]
        public void CalculateExpressionResultFailure_NoDiffUpperLower_Test12()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "TaXWithPoint (1,3)", EnumDataType.Number), new ExpressionItem("A1", "TaxWithPoint (1,3)", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), new ExpressionItem("A2", "1/0+1+A1", EnumDataType.Number), "1+(1)", "2");
            CalculateAndAssertFailure(actualitems, "系统无法执行TaxWithPoint函数，此函数没有实例化");
        }

        #endregion
        #region <NULL>的Expression
        [Test, Description("期望可计算的用例")]
        public void CalculateExpressionResultNullTest1()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> expecteditems = new List<ExpressionItem>();
            List<ExpressionItem> actualitems = new List<ExpressionItem>();
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A1", "1", EnumDataType.Number), new ExpressionItem("A1", "1", EnumDataType.Number), "1", "1");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A2", "<NULL>", EnumDataType.Number), new ExpressionItem("A2", "<NULL>", EnumDataType.Number), "<NULL>", null);
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), new ExpressionItem("A3", "'2009-3-4'", EnumDataType.DateTime), "'2009-3-4'", "2009-3-4");
            AddExpectedItem(actualitems, expecteditems, new ExpressionItem("A4", "<NULL>", EnumDataType.DateTime), new ExpressionItem("A4", "<NULL>", EnumDataType.DateTime), "<NULL>", null);
            AddExpectedItem(actualitems, expecteditems,
                            new ExpressionItem("A5", "DateMax(DateMax('2009-4-4',A4),'2009-6-6')", EnumDataType.DateTime),
                            new ExpressionItem("A5", "DateMax(DateMax('2009-4-4',A4),'2009-6-6')", EnumDataType.DateTime),
                            "DateMax(DateMax('2009-4-4',(<NULL>)),'2009-6-6')", null);
            AddExpectedItem(actualitems, expecteditems,
                            new ExpressionItem("A6", "A5", EnumDataType.DateTime),
                            new ExpressionItem("A6", "A5", EnumDataType.DateTime),
                            "(DateMax(DateMax('2009-4-4',(<NULL>)),'2009-6-6'))", null);
            CalculateAndAssertSuccess(actualitems, expecteditems);
        }

        #endregion
    }
}
