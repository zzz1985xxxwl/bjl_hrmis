//add by wsl
//���Լ����ʽlist
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Evaluant.Calculator.Extensions.UnitTest
{
    [TestFixture]
    public class CheckExpressionItemListTest
    {
        private static bool _IsDiffUpperOrLower;
        #region method
        private static void AssertSuccessTestCase(List<ExpressionItem> items)
        {
            CheckExpressionItemList cel = new CheckExpressionItemList(items, "A");
            cel.IsDiffUpperOrLower = _IsDiffUpperOrLower;
            Assert.AreEqual(cel.CheckExpressionItemListValid(), true);
        }
        private static void AssertFailedTestCase(List<ExpressionItem> items, string expectedmessage)
        {
            CheckExpressionItemList cel = new CheckExpressionItemList(items, "A");
            bool isException = false;
            try
            {
                cel.IsDiffUpperOrLower = _IsDiffUpperOrLower;
                cel.CheckExpressionItemListValid();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, expectedmessage);
                isException = true;
            }
            Assert.AreEqual(isException, true);
        }

        #endregion
        #region Number
        #region ��Сд��������
        [Test, Description("����ͨ����֤������")]
        public void SuccessNumberTest1()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }
        [Test, Description("����ͨ����֤������")]
        public void SuccessNumberTest3()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "1+A1", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }
        [Test, Description("����ͨ����֤������")]
        public void SuccessNumberTest4()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "A1��+��A1", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }
        [Test, Description("����ͨ����֤������")]
        public void SuccessNumberTest5()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "Range(A1+A5,A1,A5)", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "Range(A1��+��A1,10,14)", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }
        [Test, Description("����ͨ����֤������")]
        public void SuccessNumberTest6()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "OmitFenJiao(A1)", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "OmitFen(A2)", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "RoundToYuan(if(A3,2,4))", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "RoundToJiao(if(3,A4,4))", EnumDataType.Number));
            items.Add(new ExpressionItem("A6", "if(JianJiaoJinYuan(if(3,2,A5)),A5,A4)", EnumDataType.Number));
            items.Add(new ExpressionItem("A7", "JianFenJinJiao(if(3,2,A6))", EnumDataType.Number));
            items.Add(new ExpressionItem("A8", "NoDealWith(A7)", EnumDataType.Number));
            items.Add(new ExpressionItem("A9", "RoundToFen(A7)", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest1()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "1+A1", EnumDataType.Number));
            AssertFailedTestCase(items, "A1û�ж��壬ϵͳ�޷�����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest2()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "Tax(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��Tax�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest3()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A3", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            AssertFailedTestCase(items, "���㹫ʽ�г�������������A4�Ĺ�ʽ");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest4()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            AssertFailedTestCase(items, "���㹫ʽ�г�������������A2�Ĺ�ʽ");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest5()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "Rang(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "�޷�ʶ����Rang");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest6()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "Range(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "Range()����ֻ�ɶ���3��������Ŀǰ�㶨����1������");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest7()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "AnnualBonusTax(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��AnnualBonusTax�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest8()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "OmitFenJiao(A1+A5)", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "OmitFen(A1+A5)", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "RoundToYuan(A1+A5)", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "RoundToJiao(A1+A5)", EnumDataType.Number));
            items.Add(new ExpressionItem("A6", "JianJiaoJinYuan(A1+A5)", EnumDataType.Number));
            items.Add(new ExpressionItem("A7", "JianFEnJinJiao(A1+A5)", EnumDataType.Number));
            items.Add(new ExpressionItem("A8", "NoDealWith(A1+A5)", EnumDataType.Number));
            items.Add(new ExpressionItem("A9", "RoundToFen(A1+A5)", EnumDataType.Number));

            AssertFailedTestCase(items, "�޷�ʶ����JianFEnJinJiao");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest9()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "ForeignTax(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��ForeignTax�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest10()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "AnnualBonusForeignTax(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��AnnualBonusForeignTax�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest11()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "IsSalaryEndDateMonthEquel(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��IsSalaryEndDateMonthEquel�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest12()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "DoubleSalary(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��DoubleSalary�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumberTest13()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "TaxWithPoint(1+A1,3)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��TaxWithPoint�������˺���û��ʵ����");
        }

        #endregion
        #region ��Сд����������
        [Test, Description("����ͨ����֤����������Сд����������")]
        public void SuccessNumber_NoDiffUpperLower_Test1()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("a1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("a2", "1+A1", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }
        [Test, Description("����ͨ����֤����������Сд����������")]
        public void SuccessNumber_NoDiffUpperLower_Test3()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+a4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "1+A1", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }
        [Test, Description("����ͨ����֤����������Сд����������")]
        public void SuccessNumber_NoDiffUpperLower_Test4()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("a4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "a1��+��A1", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }
        [Test, Description("����ͨ����֤������")]
        public void SuccessNumber_NoDiffUpperLower_Test5()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "RA Nge(A1+A5,A1,A5)", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "ran ge(A1��+��A1,10,14)", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }
        [Test, Description("����ͨ����֤������")]
        public void SuccessNumber_NoDiffUpperLower_Test6()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "OmitFenJiao(A1)", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "OMitFen(A2)", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "ROundToYuan(if(A3,2,4))", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "RoundTO Jiao(if(3,A4,4))", EnumDataType.Number));
            items.Add(new ExpressionItem("A6", "if(JianJiaoJinYuan(if(3,2,A5)),A5,A4)", EnumDataType.Number));
            items.Add(new ExpressionItem("A7", "JianFenJ iNJiao(if(3,2,A6))", EnumDataType.Number));
            items.Add(new ExpressionItem("A8", "NoDealWiTh (A7)", EnumDataType.Number));
            AssertSuccessTestCase(items);
        }

        [Test, Description("δͨ����֤����������Сд����������")]
        public void FailureNumber_NoDiffUpperLower_Test1()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("a3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "IF(1+A1,3,7)", EnumDataType.Number));
            AssertFailedTestCase(items, "A1û�ж��壬ϵͳ�޷�����");
        }
        [Test, Description("δͨ����֤����������Сд����������")]
        public void FailureNumber_NoDiffUpperLower_Test2()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("a3", "1+a4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "TAx(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��Tax�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤����������Сд����������")]
        public void FailureNumber_NoDiffUpperLower_Test3()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A3", EnumDataType.Number));
            items.Add(new ExpressionItem("a3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            AssertFailedTestCase(items, "���㹫ʽ�г�������������A4�Ĺ�ʽ");
        }
        [Test, Description("δͨ����֤����������Сд����������")]
        public void FailureNumber_NoDiffUpperLower_Test4()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "A2", EnumDataType.Number));
            items.Add(new ExpressionItem("a2", "1+A1", EnumDataType.Number));
            AssertFailedTestCase(items, "���㹫ʽ�г�������������A2�Ĺ�ʽ");
        }
        [Test, Description("δͨ����֤����������Сд����������")]
        public void FailureNumber_NoDiffUpperLower_Test5()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("a3", "1+a4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "ANnualBonusTax(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��AnnualBonusTax�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤����������Сд����������")]
        public void FailureNumber_NoDiffUpperLower_Test6()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("a3", "1+a4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "foreignTAx(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��ForeignTax�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤����������Сд����������")]
        public void FailureNumber_NoDiffUpperLower_Test7()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("a3", "1+a4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "ANnualBonusforeignTax(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��AnnualBonusForeignTax�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumber_NoDiffUpperLower_Test8()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "isSalaryENdDateMonthEquel(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��IsSalaryEndDateMonthEquel�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumber_NoDiffUpperLower_Test9()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "doubLeSalary(1+A1)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��DoubleSalary�������˺���û��ʵ����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureNumber_NoDiffUpperLower_Test10()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "A1+A5", EnumDataType.Number));
            items.Add(new ExpressionItem("A3", "1+A4", EnumDataType.Number));
            items.Add(new ExpressionItem("A4", "1+A2", EnumDataType.Number));
            items.Add(new ExpressionItem("A5", "TaXWitHPoint(1+A1,4)", EnumDataType.Number));
            AssertFailedTestCase(items, "ϵͳ�޷�ִ��TaxWithPoint�������˺���û��ʵ����");
        }

        #endregion
        #endregion
        #region DateTime
        #region ��Сд��������
        [Test, Description("����ͨ����֤������")]
        public void SuccessDateTimeTest1()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A301", "'2009-3-3'", EnumDataType.DateTime));
            items.Add(new ExpressionItem("A302", "DateMax(A301,A301)", EnumDataType.DateTime));
            AssertSuccessTestCase(items);
        }

        [Test, Description("δͨ����֤������")]
        public void FailureDateTimeTest1()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A301", "'2009-3-3'", EnumDataType.DateTime));
            items.Add(new ExpressionItem("A302", "DateMax(A301)", EnumDataType.DateTime));
            AssertFailedTestCase(items, "DateMax()����ֻ�ɶ���2��������Ŀǰ�㶨����1������");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureDateTimeTest2()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A301", "'2009-3-3'", EnumDataType.DateTime));
            items.Add(new ExpressionItem("A302", "DateMax(1+A1,A301)", EnumDataType.DateTime));
            AssertFailedTestCase(items, "DateMax()�����ĵ�1�������޷����ͣ������������ڸ�ʽ������");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureDateTimeTest3()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A301", "'2009-3-3'", EnumDataType.Other));
            items.Add(new ExpressionItem("A302", "DateMax(1+A1,A301)", EnumDataType.DateTime));
            AssertFailedTestCase(items, "A301�������������Ͳ������޷�����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureDateTimeTest4()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A301", "'2009-3-3'", EnumDataType.DateTime));
            items.Add(new ExpressionItem("A302", "DateMax('2009-3-4',A301)", EnumDataType.Other));
            AssertFailedTestCase(items, "A302�������������Ͳ������޷�����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureDateTimeTest5()
        {
            _IsDiffUpperOrLower = true;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A302", "DateMax('2009-3-4',A301)", EnumDataType.Other));
            AssertFailedTestCase(items, "A301û�ж��壬ϵͳ�޷�����");
        }
        #endregion
        #region ��Сд����������
        [Test, Description("����ͨ����֤����������Сд����������")]
        public void SuccessDateTime_NoDiffUpperLower_Test1()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("a2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A301", "'2009-3-3'", EnumDataType.DateTime));
            items.Add(new ExpressionItem("A302", "datemax(A301,A301)", EnumDataType.DateTime));
            AssertSuccessTestCase(items);
        }

        [Test, Description("δͨ����֤������")]
        public void FailureDateTime_NoDiffUpperLower_Test1()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("a2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A301", "'2009-3-3'", EnumDataType.DateTime));
            items.Add(new ExpressionItem("a302", "dAtemax(A301)", EnumDataType.DateTime));
            AssertFailedTestCase(items, "DateMax()����ֻ�ɶ���2��������Ŀǰ�㶨����1������");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureDateTime_NoDiffUpperLower_Test2()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A301", "'2009-3-3'", EnumDataType.DateTime));
            items.Add(new ExpressionItem("a302", "dateMax(1+a1,A301)", EnumDataType.DateTime));
            AssertFailedTestCase(items, "DateMax()�����ĵ�1�������޷����ͣ������������ڸ�ʽ������");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureDateTime_NoDiffUpperLower_Test3()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("a301", "'2009-3-3'", EnumDataType.Other));
            items.Add(new ExpressionItem("A302", "DaTeMax(1+A1,a301)", EnumDataType.DateTime));
            AssertFailedTestCase(items, "A301�������������Ͳ������޷�����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureDateTime_NoDiffUpperLower_Test4()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("A301", "'2009-3-3'", EnumDataType.DateTime));
            items.Add(new ExpressionItem("a302", "DateMax('2009-3-4',A301)", EnumDataType.Other));
            AssertFailedTestCase(items, "A302�������������Ͳ������޷�����");
        }
        [Test, Description("δͨ����֤������")]
        public void FailureDateTime_NoDiffUpperLower_Test5()
        {
            _IsDiffUpperOrLower = false;
            List<ExpressionItem> items = new List<ExpressionItem>();
            items.Add(new ExpressionItem("A1", "1", EnumDataType.Number));
            items.Add(new ExpressionItem("A2", "1+A1", EnumDataType.Number));
            items.Add(new ExpressionItem("a302", "DateMax('2009-3-4',a301)", EnumDataType.Other));
            AssertFailedTestCase(items, "A301û�ж��壬ϵͳ�޷�����");
        }

        #endregion
        #endregion
    }
}
