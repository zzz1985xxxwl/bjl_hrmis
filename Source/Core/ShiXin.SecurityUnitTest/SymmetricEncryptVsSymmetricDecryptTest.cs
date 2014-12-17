//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SecurityTest.cs
// 创建者: wangshali
// 创建日期: 2008-08-28
// 概述: 实现对Security的测试
// ----------------------------------------------------------------
using NUnit.Framework;
using ShiXin.Security;

namespace ShiXin.SecurityUnitTest
{
    [TestFixture]
    public class SymmetricEncryptVsSymmetricDecryptTest
    {
        private readonly string key = "wang.shali";
        [Test, Description("测试加密解密")]
        public void Test1()
        {
            const string actual = "adhfoiadfoiydflkj;lkjlczkvjuoiuafoiuewqr;lkj123j;lkjhj倪豪道德阿hoaho号和噢阿訇噢和doifoudaifu 交流电警方蜡黄色地方来哈了哈达和  *&^(*#&^!(*#dlkf;la jfdsafldsaf  iudofiupuerlkjlfj ';][daf=-";
            string Encrypted = SecurityUtil.SymmetricEncrypt(actual, key);

            string Decrypted = SecurityUtil.SymmetricDecrypt(Encrypted, key);
            Assert.AreEqual(Decrypted, actual);

        }
        [Test, Description("测试加密解密")]
        public void Test2()
        {
            const string actual =
                "123哦iu 9874874398731409873475-19358=17532175=76=5213=6503198707警方地段苏坡垭污染";
            string Encrypted = SecurityUtil.SymmetricEncrypt(actual, key);

            string Decrypted = SecurityUtil.SymmetricDecrypt(Encrypted, key);
            Assert.AreEqual(Decrypted, actual);
        }

        [Test, Description("测试加密解密")]
        public void Test3()
        {
            const string actual = "778946";
            string Encrypted = SecurityUtil.SymmetricEncrypt(actual, key);

            string Decrypted = SecurityUtil.SymmetricDecrypt(Encrypted, key);
            Assert.AreEqual(Decrypted, actual);
        }

    }
}
