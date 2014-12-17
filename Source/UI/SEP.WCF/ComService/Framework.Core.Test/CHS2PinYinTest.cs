using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Framework.Core.UnitTest
{
    [TestFixture]
    public class CHS2PinYinTest
    {
        [Test, Description("判断是否取目标字符串的第一个大写字母")]
        public void CHS2PinYinConvertTest()
        {
            Assert.AreEqual("Z", CHS2PinYin.FirstCHSCap("周蒙蒙"));
        }

        [Test, Description("判断取错误的目标字符串的第一个大写字母系统提示")]
        public void CHS2PinYinConvertTest1()
        {  
            Assert.IsFalse(CHS2PinYin.FirstCHSCap("sdfggg") == "A"); 
        }

        [Test, Description("将指定中文字符串转换为拼音形式")]
        public void CHS2PinYinConvertTest2()
        {
           Assert.AreEqual("Cai-Li-Li",CHS2PinYin.Convert("蔡丽丽","-",true));
        }

        [Test, Description("将指定中文字符串转换为拼音形式")]
        public void CHS2PinYinConvertTest3()
        {
           Assert.AreEqual("CaiLiLi", CHS2PinYin.Convert("蔡丽丽", true));
        }

        [Test, Description("非中文字符串不转换为拼音形式")]
        public void CHS2PinYinConvertTest4()
        {
            Assert.AreEqual("123444", CHS2PinYin.Convert("123444","-", true));
        }

        [Test, Description("非中文字符串不转换为拼音形式")]
        public void CHS2PinYinConvertTest5()
        {
            Assert.AreEqual("asss", CHS2PinYin.Convert("asss", "-", true));
        }

        [Test, Description("将指定中文字符串转换为错误的拼音形式")]
        public void CHS2PinYinConvertTest6()
        {
            Assert.IsFalse(CHS2PinYin.Convert("电话", "-", true)== "dian-Hua");
        }

        [Test, Description("将指定中文字符串转换为错误的拼音形式")]
        public void CHS2PinYinConvertTest7()
        {
            Assert.IsFalse(CHS2PinYin.Convert("电话", " ", true) == "Dian-Hua");
        }

        [Test, Description("将指定中文字符串转换为错误的拼音形式")]
        public void CHS2PinYinConvertTest8()
        {
            Assert.IsFalse(CHS2PinYin.Convert("电话", "-", true) == "DiAn-Hua");
        }

        [Test, Description("将指定中文字符串转换为错误的拼音形式")]
        public void CHS2PinYinConvertTest9()
        {
            Assert.IsFalse(CHS2PinYin.Convert("电话", "-", true) == "dian-hua");
        }

        [Test, Description("将指定中文字符串转换为错误的拼音形式")]
        public void CHS2PinYinConvertTest10()
        {
            Assert.IsFalse(CHS2PinYin.Convert("电话号码", "-", true) == "dian-huahaoma");
        }

        [Test, Description("将指定中文字符串转换为错误的拼音形式")]
        public void CHS2PinYinConvertTest11()
        {
            Assert.IsFalse(CHS2PinYin.Convert("KKKKK", "-", true) == "KKKK");
        }

        [Test, Description("取非中英文字符串的第一个大写字母系统提示")]
        public void CHS2PinYinConvertTest12()
        {
            try
            {
                string str = CHS2PinYin.FirstCHSCap("@@@nnuu");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "无法取得第一个大写字母！");
                return;
            }
        }

        [Test, Description("取目标字符串的第一个小写字母系统提示")]
        public void CHS2PinYinConvertTest13()
        {
            string str = CHS2PinYin.FirstCHSCap("哈哈哈哈");
        }

        [Test, Description("取非中英文字符串的第一个大写字母系统提示")]
        public void CHS2PinYinConvertTest14()
        {
            try
            {
                string str =CHS2PinYin.FirstCHSCap("122213");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "无法取得第一个大写字母！");
                return;
            }
        }
        [Test, Description("取非中英文字符串的第一个大写字母系统提示")]
        public void CHS2PinYinConvertTest15()
        {
            try
            {
                string str = CHS2PinYin.FirstCHSCap(",ongxunlu");

            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "无法取得第一个大写字母！");
                return;
            }
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest16()
        {
            Assert.IsTrue(Tools.IsAz("ddggsss"));
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest17()
        {
            Assert.IsFalse(Tools.IsAz("哈哈"));
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest18()
        {
            Assert.IsFalse(Tools.IsAz("@##@!%%*!;,.,"));
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest19()
        {
            Assert.IsFalse(Tools.IsAz("8877732234545556"));
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest20()
        {
            Assert.IsFalse(Tools.IsAz("abc8"));
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest21()
        {
            Assert.IsFalse(Tools.IsAz("abc "));
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest22()
        {
            Assert.IsFalse(Tools.IsAz(" abc "));
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest23()
        {
            Assert.IsFalse(Tools.IsAz("ab cd"));
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest24()
        {
            Assert.IsFalse(Tools.IsAz("fgggf电话"));
        }

        [Test, Description("判断是否由26个英文字母组成的字符串")]
        public void CHS2PinYinConvertTest25()
        {
            Assert.IsFalse(Tools.IsAz("fgg&&…………"));
        }

        [Test, Description("是否包含中文字符")]
        public void CHS2PinYinConvertTest26()
        {
            Assert.IsTrue(Tools.IsCHS("通讯录"));
        }

        [Test, Description("是否包含中文字符")]
        public void CHS2PinYinConvertTest27()
        {
            Assert.IsFalse(Tools.IsCHS("assddfgggg"));
        }

        [Test, Description("是否包含中文字符")]
        public void CHS2PinYinConvertTest28()
        {
            Assert.IsFalse(Tools.IsCHS("!@#%^&*())&^%%5"));
        }

        [Test, Description("是否包含中文字符")]
        public void CHS2PinYinConvertTest29()
        {
            Assert.IsFalse(Tools.IsCHS("877668889999999999"));
        }

        [Test, Description("是否包含中文字符")]
        public void CHS2PinYinConvertTest30()
        {
            Assert.IsTrue(Tools.IsCHS("98通讯录"));
        }

        [Test, Description("是否包含中文字符")]
        public void CHS2PinYinConvertTest31()
        {
            Assert.IsTrue(Tools.IsCHS("通讯eet录"));
        }

        [Test, Description("是否包含中文字符")]
        public void CHS2PinYinConvertTest32()
        {
            Assert.IsTrue(Tools.IsCHS("通33…………&&*#33讯t录"));
        }

        [Test, Description("是否为电话号码")]
        public void CHS2PinYinConvertTest33()
        {
            Assert.IsTrue(Tools.IsPhoneNum("62374197"));
        }

        [Test, Description("是否为电话号码")]
        public void CHS2PinYinConvertTest34()
        {
            Assert.IsFalse(Tools.IsPhoneNum("电话号码"));
        }

        [Test, Description("是否为电话号码")]
        public void CHS2PinYinConvertTest35()
        {
            Assert.IsFalse(Tools.IsPhoneNum("#￥￥%…………"));
        }

        [Test, Description("是否为电话号码")]
        public void CHS2PinYinConvertTest36()
        {
            Assert.IsFalse(Tools.IsPhoneNum("电话62374197"));
        }

        [Test, Description("是否为电话号码")]
        public void CHS2PinYinConvertTest37()
        {
            Assert.IsFalse(Tools.IsPhoneNum("err62374198dd"));
        }

        [Test, Description("是否为电话号码")]
        public void CHS2PinYinConvertTest38()
        {
            Assert.IsFalse(Tools.IsPhoneNum("62374198&**%!@#;'.,<>"));
        }

        [Test, Description("是否为Email地址")]
        public void CHS2PinYinConvertTest39()
        {
            Assert.IsTrue(Tools.IsEmail("cai.lili@staple.sh.cn"));
        }

        [Test, Description("是否为Email地址")]
        public void CHS2PinYinConvertTest40()
        {
            Assert.IsFalse(Tools.IsEmail(" @staple.sh.cn"));
        }

        [Test, Description("是否为Email地址")]
        public void CHS2PinYinConvertTest41()
        {
            Assert.IsFalse(Tools.IsEmail("@staple.sh.cn"));
        }

        [Test, Description("是否为Email地址")]
        public void CHS2PinYinConvertTest42()
        {
            Assert.IsFalse(Tools.IsEmail("@"));
        }

        [Test, Description("是否为Email地址")]
        public void CHS2PinYinConvertTest43()
        {
            Assert.IsFalse(Tools.IsEmail("maomao@126."));
        }

        [Test, Description("是否为Email地址")]
        public void CHS2PinYinConvertTest44()
        {
            Assert.IsFalse(Tools.IsEmail("maomao@126,com"));
        }

        [Test, Description("是否为Email地址")]
        public void CHS2PinYinConvertTest45()
        {
            Assert.IsFalse(Tools.IsEmail("毛毛@126.com"));
        }

        [Test, Description("是否为URL")]
        public void CHS2PinYinConvertTest46()
        {
            Assert.IsTrue(Tools.IsURL("http://10.10.10.41/MySite/Pages/AdminIndex.aspx"));
        }

        [Test, Description("是否为URL")]
        public void CHS2PinYinConvertTest47()
        {
            Assert.IsFalse(Tools.IsURL("ddgg3333333333"));
        }

        [Test, Description("是否为URL")]
        public void CHS2PinYinConvertTest48()
        {
            Assert.IsFalse(Tools.IsURL("$$$$$$$$$######@@@#3"));
        }

        [Test, Description("是否为URL")]
        public void CHS2PinYinConvertTest49()
        {
            Assert.IsFalse(Tools.IsURL("哈哈哈"));
        }


    }

}
