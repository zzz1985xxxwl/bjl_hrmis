//add by wsl
//���Լ�鵥�����ʽ
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

        #region ��������
        [Test, Description("������ͨ����֤������,��֤nullֵ�������Ч����")]
        public void FailedTest()
        {
            try
            {
                CheckExpressionItem ce = new CheckExpressionItem("A1", "A", null);
                ce.CheckExpressionItemValid();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("A1û�ж��壬ϵͳ�޷�����", ex.Message);
            }
        }
        #endregion

        #region Number
        #region ��Сд��������
        [Test, Description("����ͨ����֤������")]
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
            AssertSuccessTestCase("A300", "A1��+��A1");
            AssertSuccessTestCase("A300",
                "if(A3<=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))");
            AssertSuccessTestCase("A300",
                "if(A3<=2,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%),if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))");
        }

        [Test, Description("������ͨ����֤������")]
        public void FailedNumberTest()
        {
            _IsDiffUpperOrLower = true;
            AssertFailedTestCase("A300", "A1/(A3-A3)", "��ͼ�����㡣");
            AssertFailedTestCase("A300", "A1/(A3+A4-A4-A3)", "��ͼ�����㡣");
            AssertFailedTestCase("A300",
                "if(A3<if=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "if(A3<=2,A5/21.75*A4* 58.88%%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "����58.88%%����Ч���ʽ");
            AssertFailedTestCase("A300",
                "IfafF(A3<=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "�޷�ʶ����IfafF");
            AssertFailedTestCase("A300",
                "if(A3<=2,3,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "if()����ֻ�ɶ���3��������Ŀǰ�㶨����4������");
            AssertFailedTestCase("A300",
                "if(A3<=2,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "if()����ֻ�ɶ���3��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300",
                "A3joaf",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "Tax(3)",
                "ϵͳ�޷�ִ��Tax�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "ForeignTax(3)",
                "ϵͳ�޷�ִ��ForeignTax�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "AnnualBonusTax(3)",
                "ϵͳ�޷�ִ��AnnualBonusTax�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "AnnualBonusForeignTax(3)",
                "ϵͳ�޷�ִ��AnnualBonusForeignTax�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "IsSalaryEndDateMonthEquel(3)",
                "ϵͳ�޷�ִ��IsSalaryEndDateMonthEquel�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "TaxWithPoint(3,3)",
                "ϵͳ�޷�ִ��TaxWithPoint�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "DoubleSalary(3)",
                "ϵͳ�޷�ִ��DoubleSalary�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "A1;",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "A1:",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "A1?",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "A1;",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            //AssertFailedTestCase("A300", 
            //    "A1!~@#$%^&*()_",
            //    "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            //AssertFailedTestCase("A300", 
            //    "A1!~@#$%^&*()_",
            //    "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "Range(3,if(2,3,1))",
                "Range()����ֻ�ɶ���3��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300",
                "RaNge(3,if(2,3,1))",
                "�޷�ʶ����RaNge");
            AssertFailedTestCase("A300", "OmitfenJiao(A1)", "�޷�ʶ����OmitfenJiao");
            AssertFailedTestCase("A300", "OMitFen(A13)", "�޷�ʶ����OMitFen");
            AssertFailedTestCase("A300", "roundToYuan(if(3,2,4))", "�޷�ʶ����roundToYuan");
            AssertFailedTestCase("A300", "RounDToJiao(if(3,2,4))", "�޷�ʶ����RounDToJiao");
            AssertFailedTestCase("A300", "RounDToFen(if(3,2,4))", "�޷�ʶ����RounDToFen");
            AssertFailedTestCase("A300", "JianJiaojinyuan(if(3,2,4))", "�޷�ʶ����JianJiaojinyuan");
            AssertFailedTestCase("A300", "JianFeNJinJiao(if(3,2,4))", "�޷�ʶ����JianFeNJinJiao");
            AssertFailedTestCase("A300", "NoDeaLWith(if(3,2,4))", "�޷�ʶ����NoDeaLWith");

            AssertFailedTestCase("A300", "OmitFenJiao(A1,0)", "OmitFenJiao()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "OmitFen(A13,9)", "OmitFen()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "RoundToYuan(if(3,2,4),9)", "RoundToYuan()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "RoundToJiao(if(3,2,4),7)", "RoundToJiao()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "RoundToFen(if(3,2,4),7)", "RoundToFen()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "JianJiaoJinYuan(if(3,2,4),5)", "JianJiaoJinYuan()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "JianFenJinJiao(if(3,2,4),3)", "JianFenJinJiao()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "NoDealWith(if(3,2,4),7)", "NoDealWith()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "DateMax('2009-9-3',A504)", "�޷���A300�����ļ�����ת��Ϊ��������");
            AssertFailedTestCase("A300", "NoDealWith(A504)", "�޷���A300�����ļ�����ת��Ϊ��������");
            AssertFailedTestCase("A300", "JianFenJinJiao(A504)", "�����ַ����ĸ�ʽ����ȷ��");
        }

        #endregion
        #region ��Сд����������
        [Test, Description("����ͨ����֤������,��Сд����������")]
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
            AssertSuccessTestCase("A300", "a1��+��A1");
            AssertSuccessTestCase("A300",
                "IF(A3<=2,A5/21.75*a4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))");
            AssertSuccessTestCase("A300",
                "if(A3<=2,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%),if(a3<=4,A5/ 21.75*A3* 51%,if(a3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))");
        }

        [Test, Description("������ͨ����֤������,��Сд����������")]
        public void FailedNumber_NoDiffUpperLower_Test()
        {
            _IsDiffUpperOrLower = false;
            AssertFailedTestCase("A300", "A1/(A3-A3)", "��ͼ�����㡣");
            AssertFailedTestCase("A300", "a1/(a3+A4-a4-a3)", "��ͼ�����㡣");
            AssertFailedTestCase("A300",
                "If(A3<if=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "if(A3<=2,A5/21.75*A4* 58.88%%,if(a3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "����58.88%%����Ч���ʽ");
            AssertFailedTestCase("A300",
                "IfafF(A3<=2,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "�޷�ʶ����IFAFF");
            AssertFailedTestCase("A300",
                "if(A3<=2,3,A5/21.75*A4* 58.88%,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "if()����ֻ�ɶ���3��������Ŀǰ�㶨����4������");
            AssertFailedTestCase("A300",
                "if(A3<=2,if(A3<=4,A5/ 21.75*A3* 51%,if(A3<=6,A5/ 21.75*A3* 44%,if(A3<=8,A5/ 21.75*A3* 37%,A5/ 21.75*A3* 30%))))",
                "if()����ֻ�ɶ���3��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300",
                "A3joaf",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "TAx(3)",
                "ϵͳ�޷�ִ��Tax�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "AnnUalBonusTax(3)",
                "ϵͳ�޷�ִ��AnnualBonusTax�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "IssalaryENdDateMonthEquel(3)",
                "ϵͳ�޷�ִ��IsSalaryEndDateMonthEquel�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "TaxWithPOint(3)",
                "ϵͳ�޷�ִ��TaxWithPoint�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "DOublesalary(3)",
                "ϵͳ�޷�ִ��DoubleSalary�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "foreignTAx(3)",
                "ϵͳ�޷�ִ��ForeignTax�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "AnnUalBonusforeignTax(3)",
                "ϵͳ�޷�ִ��AnnualBonusForeignTax�������˺���û��ʵ����");
            AssertFailedTestCase("A300",
                "A1;",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "A1:",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "A1?",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "A1;",
                "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            //AssertFailedTestCase("A300", 
            //    "A1!~@#$%^&*()_",
            //    "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            //AssertFailedTestCase("A300", 
            //    "A1!~@#$%^&*()_",
            //    "�﷨���ش���ϵͳ�޷����ͼ��㹫ʽ���ʽ");
            AssertFailedTestCase("A300",
                "Range(3,if(2,3,1))",
                "Range()����ֻ�ɶ���3��������Ŀǰ�㶨����2������");

            AssertFailedTestCase("A300", "OmItFenJiao(A1,0)", "OmitFenJiao()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "OmiTFen(A13,9)", "OmitFen()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "RouNdToYuan(if(3,2,4),9)", "RoundToYuan()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "RoUndToJiao(if(3,2,4),7)", "RoundToJiao()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "RoUndToFEn(if(3,2,4),7)", "RoundToFen()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "JiAnJiaoJinYuan(if(3,2,4),5)", "JianJiaoJinYuan()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "JianFenJInJiao(if(3,2,4),3)", "JianFenJinJiao()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("A300", "NoDealWiTh(if(3,2,4),7)", "NoDealWith()����ֻ�ɶ���1��������Ŀǰ�㶨����2������");
            AssertFailedTestCase("a300", "dateMax('2009-9-3',a504)", "�޷���A300�����ļ�����ת��Ϊ��������");
            AssertFailedTestCase("A300", "NoDealWith(a504)", "�޷���A300�����ļ�����ת��Ϊ��������");
            AssertFailedTestCase("a300", "jianFenjinjiao(a504)", "�����ַ����ĸ�ʽ����ȷ��");
        }

        #endregion
        #endregion

        #region DateTime
        #region ��Сд��������
        [Test, Description("����ͨ����֤������")]
        public void SuccessDateTimeTest()
        {
            _IsDiffUpperOrLower = true;
            AssertSuccessTestCase("A600", "A301");
            AssertSuccessTestCase("A600", "DateMax(A301,'2009-4-4')");
            AssertSuccessTestCase("A600", "DateMax(DateMax(A301,'2009-4-4'),'2009-4-4')");
        }

        [Test, Description("������ͨ����֤������")]
        public void FailedDateTimeTest()
        {
            _IsDiffUpperOrLower = true;
            AssertFailedTestCase("A600", "DateMax(2009-4-4,A301)", "DateMax()�����ĵ�1�������޷����ͣ������������ڸ�ʽ������");
            AssertFailedTestCase("A600", "DateMax(A301,2009-4-4)", "DateMax()�����ĵ�2�������޷����ͣ������������ڸ�ʽ������");
            AssertFailedTestCase("A600", "DateMax(A601,2009-4-4)", "A601�������������Ͳ������޷�����");
            AssertFailedTestCase("A601", "DateMax(A600,'2009-4-4')", "A601�������������Ͳ������޷�����");
            AssertFailedTestCase("A600", "Max(A6,A9)", "�޷���A600�����ļ�����ת��Ϊ��������");
        }
        #endregion
        #region ��Сд����������
        [Test, Description("����ͨ����֤������,��Сд����������")]
        public void SuccessDateTime_NoDiffUpperLower_Test()
        {
            _IsDiffUpperOrLower = false;
            AssertSuccessTestCase("A600", "a301");
            AssertSuccessTestCase("A600", "DateMAx(A301,'2009-4-4')");
            AssertSuccessTestCase("A600", "datEMax(DateMax(a301,'2009-4-4'),'2009-4-4')");
        }

        [Test, Description("������ͨ����֤������,��Сд����������")]
        public void FailedDateTime_NoDiffUpperLower_Test()
        {
            _IsDiffUpperOrLower = false;
            AssertFailedTestCase("A600", "DaTeMax(2009-4-4,A301)", "DateMax()�����ĵ�1�������޷����ͣ������������ڸ�ʽ������");
            AssertFailedTestCase("A600", "datemax(A301,2009-4-4)", "DateMax()�����ĵ�2�������޷����ͣ������������ڸ�ʽ������");
            AssertFailedTestCase("a600", "dateMax(a601,2009-4-4)", "A601�������������Ͳ������޷�����");
            AssertFailedTestCase("A601", "DateMaX(a600,'2009-4-4')", "A601�������������Ͳ������޷�����");
            AssertFailedTestCase("a600", "max(a6,A9)", "�޷���A600�����ļ�����ת��Ϊ��������");
        }

        #endregion
        #endregion
    }
}
