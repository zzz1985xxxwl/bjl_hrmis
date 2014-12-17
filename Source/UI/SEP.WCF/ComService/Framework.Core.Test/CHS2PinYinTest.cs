using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Framework.Core.UnitTest
{
    [TestFixture]
    public class CHS2PinYinTest
    {
        [Test, Description("�ж��Ƿ�ȡĿ���ַ����ĵ�һ����д��ĸ")]
        public void CHS2PinYinConvertTest()
        {
            Assert.AreEqual("Z", CHS2PinYin.FirstCHSCap("������"));
        }

        [Test, Description("�ж�ȡ�����Ŀ���ַ����ĵ�һ����д��ĸϵͳ��ʾ")]
        public void CHS2PinYinConvertTest1()
        {  
            Assert.IsFalse(CHS2PinYin.FirstCHSCap("sdfggg") == "A"); 
        }

        [Test, Description("��ָ�������ַ���ת��Ϊƴ����ʽ")]
        public void CHS2PinYinConvertTest2()
        {
           Assert.AreEqual("Cai-Li-Li",CHS2PinYin.Convert("������","-",true));
        }

        [Test, Description("��ָ�������ַ���ת��Ϊƴ����ʽ")]
        public void CHS2PinYinConvertTest3()
        {
           Assert.AreEqual("CaiLiLi", CHS2PinYin.Convert("������", true));
        }

        [Test, Description("�������ַ�����ת��Ϊƴ����ʽ")]
        public void CHS2PinYinConvertTest4()
        {
            Assert.AreEqual("123444", CHS2PinYin.Convert("123444","-", true));
        }

        [Test, Description("�������ַ�����ת��Ϊƴ����ʽ")]
        public void CHS2PinYinConvertTest5()
        {
            Assert.AreEqual("asss", CHS2PinYin.Convert("asss", "-", true));
        }

        [Test, Description("��ָ�������ַ���ת��Ϊ�����ƴ����ʽ")]
        public void CHS2PinYinConvertTest6()
        {
            Assert.IsFalse(CHS2PinYin.Convert("�绰", "-", true)== "dian-Hua");
        }

        [Test, Description("��ָ�������ַ���ת��Ϊ�����ƴ����ʽ")]
        public void CHS2PinYinConvertTest7()
        {
            Assert.IsFalse(CHS2PinYin.Convert("�绰", " ", true) == "Dian-Hua");
        }

        [Test, Description("��ָ�������ַ���ת��Ϊ�����ƴ����ʽ")]
        public void CHS2PinYinConvertTest8()
        {
            Assert.IsFalse(CHS2PinYin.Convert("�绰", "-", true) == "DiAn-Hua");
        }

        [Test, Description("��ָ�������ַ���ת��Ϊ�����ƴ����ʽ")]
        public void CHS2PinYinConvertTest9()
        {
            Assert.IsFalse(CHS2PinYin.Convert("�绰", "-", true) == "dian-hua");
        }

        [Test, Description("��ָ�������ַ���ת��Ϊ�����ƴ����ʽ")]
        public void CHS2PinYinConvertTest10()
        {
            Assert.IsFalse(CHS2PinYin.Convert("�绰����", "-", true) == "dian-huahaoma");
        }

        [Test, Description("��ָ�������ַ���ת��Ϊ�����ƴ����ʽ")]
        public void CHS2PinYinConvertTest11()
        {
            Assert.IsFalse(CHS2PinYin.Convert("KKKKK", "-", true) == "KKKK");
        }

        [Test, Description("ȡ����Ӣ���ַ����ĵ�һ����д��ĸϵͳ��ʾ")]
        public void CHS2PinYinConvertTest12()
        {
            try
            {
                string str = CHS2PinYin.FirstCHSCap("@@@nnuu");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "�޷�ȡ�õ�һ����д��ĸ��");
                return;
            }
        }

        [Test, Description("ȡĿ���ַ����ĵ�һ��Сд��ĸϵͳ��ʾ")]
        public void CHS2PinYinConvertTest13()
        {
            string str = CHS2PinYin.FirstCHSCap("��������");
        }

        [Test, Description("ȡ����Ӣ���ַ����ĵ�һ����д��ĸϵͳ��ʾ")]
        public void CHS2PinYinConvertTest14()
        {
            try
            {
                string str =CHS2PinYin.FirstCHSCap("122213");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "�޷�ȡ�õ�һ����д��ĸ��");
                return;
            }
        }
        [Test, Description("ȡ����Ӣ���ַ����ĵ�һ����д��ĸϵͳ��ʾ")]
        public void CHS2PinYinConvertTest15()
        {
            try
            {
                string str = CHS2PinYin.FirstCHSCap(",ongxunlu");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "�޷�ȡ�õ�һ����д��ĸ��");
                return;
            }
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest16()
        {
            Assert.IsTrue(Tools.IsAz("ddggsss"));
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest17()
        {
            Assert.IsFalse(Tools.IsAz("����"));
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest18()
        {
            Assert.IsFalse(Tools.IsAz("@##@!%%*!;,.,"));
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest19()
        {
            Assert.IsFalse(Tools.IsAz("8877732234545556"));
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest20()
        {
            Assert.IsFalse(Tools.IsAz("abc8"));
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest21()
        {
            Assert.IsFalse(Tools.IsAz("abc "));
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest22()
        {
            Assert.IsFalse(Tools.IsAz(" abc "));
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest23()
        {
            Assert.IsFalse(Tools.IsAz("ab cd"));
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest24()
        {
            Assert.IsFalse(Tools.IsAz("fgggf�绰"));
        }

        [Test, Description("�ж��Ƿ���26��Ӣ����ĸ��ɵ��ַ���")]
        public void CHS2PinYinConvertTest25()
        {
            Assert.IsFalse(Tools.IsAz("fgg&&��������"));
        }

        [Test, Description("�Ƿ���������ַ�")]
        public void CHS2PinYinConvertTest26()
        {
            Assert.IsTrue(Tools.IsCHS("ͨѶ¼"));
        }

        [Test, Description("�Ƿ���������ַ�")]
        public void CHS2PinYinConvertTest27()
        {
            Assert.IsFalse(Tools.IsCHS("assddfgggg"));
        }

        [Test, Description("�Ƿ���������ַ�")]
        public void CHS2PinYinConvertTest28()
        {
            Assert.IsFalse(Tools.IsCHS("!@#%^&*())&^%%5"));
        }

        [Test, Description("�Ƿ���������ַ�")]
        public void CHS2PinYinConvertTest29()
        {
            Assert.IsFalse(Tools.IsCHS("877668889999999999"));
        }

        [Test, Description("�Ƿ���������ַ�")]
        public void CHS2PinYinConvertTest30()
        {
            Assert.IsTrue(Tools.IsCHS("98ͨѶ¼"));
        }

        [Test, Description("�Ƿ���������ַ�")]
        public void CHS2PinYinConvertTest31()
        {
            Assert.IsTrue(Tools.IsCHS("ͨѶeet¼"));
        }

        [Test, Description("�Ƿ���������ַ�")]
        public void CHS2PinYinConvertTest32()
        {
            Assert.IsTrue(Tools.IsCHS("ͨ33��������&&*#33Ѷt¼"));
        }

        [Test, Description("�Ƿ�Ϊ�绰����")]
        public void CHS2PinYinConvertTest33()
        {
            Assert.IsTrue(Tools.IsPhoneNum("62374197"));
        }

        [Test, Description("�Ƿ�Ϊ�绰����")]
        public void CHS2PinYinConvertTest34()
        {
            Assert.IsFalse(Tools.IsPhoneNum("�绰����"));
        }

        [Test, Description("�Ƿ�Ϊ�绰����")]
        public void CHS2PinYinConvertTest35()
        {
            Assert.IsFalse(Tools.IsPhoneNum("#����%��������"));
        }

        [Test, Description("�Ƿ�Ϊ�绰����")]
        public void CHS2PinYinConvertTest36()
        {
            Assert.IsFalse(Tools.IsPhoneNum("�绰62374197"));
        }

        [Test, Description("�Ƿ�Ϊ�绰����")]
        public void CHS2PinYinConvertTest37()
        {
            Assert.IsFalse(Tools.IsPhoneNum("err62374198dd"));
        }

        [Test, Description("�Ƿ�Ϊ�绰����")]
        public void CHS2PinYinConvertTest38()
        {
            Assert.IsFalse(Tools.IsPhoneNum("62374198&**%!@#;'.,<>"));
        }

        [Test, Description("�Ƿ�ΪEmail��ַ")]
        public void CHS2PinYinConvertTest39()
        {
            Assert.IsTrue(Tools.IsEmail("cai.lili@staple.sh.cn"));
        }

        [Test, Description("�Ƿ�ΪEmail��ַ")]
        public void CHS2PinYinConvertTest40()
        {
            Assert.IsFalse(Tools.IsEmail(" @staple.sh.cn"));
        }

        [Test, Description("�Ƿ�ΪEmail��ַ")]
        public void CHS2PinYinConvertTest41()
        {
            Assert.IsFalse(Tools.IsEmail("@staple.sh.cn"));
        }

        [Test, Description("�Ƿ�ΪEmail��ַ")]
        public void CHS2PinYinConvertTest42()
        {
            Assert.IsFalse(Tools.IsEmail("@"));
        }

        [Test, Description("�Ƿ�ΪEmail��ַ")]
        public void CHS2PinYinConvertTest43()
        {
            Assert.IsFalse(Tools.IsEmail("maomao@126."));
        }

        [Test, Description("�Ƿ�ΪEmail��ַ")]
        public void CHS2PinYinConvertTest44()
        {
            Assert.IsFalse(Tools.IsEmail("maomao@126,com"));
        }

        [Test, Description("�Ƿ�ΪEmail��ַ")]
        public void CHS2PinYinConvertTest45()
        {
            Assert.IsFalse(Tools.IsEmail("ëë@126.com"));
        }

        [Test, Description("�Ƿ�ΪURL")]
        public void CHS2PinYinConvertTest46()
        {
            Assert.IsTrue(Tools.IsURL("http://10.10.10.41/MySite/Pages/AdminIndex.aspx"));
        }

        [Test, Description("�Ƿ�ΪURL")]
        public void CHS2PinYinConvertTest47()
        {
            Assert.IsFalse(Tools.IsURL("ddgg3333333333"));
        }

        [Test, Description("�Ƿ�ΪURL")]
        public void CHS2PinYinConvertTest48()
        {
            Assert.IsFalse(Tools.IsURL("$$$$$$$$$######@@@#3"));
        }

        [Test, Description("�Ƿ�ΪURL")]
        public void CHS2PinYinConvertTest49()
        {
            Assert.IsFalse(Tools.IsURL("������"));
        }


    }

}
