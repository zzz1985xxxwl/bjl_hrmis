//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SecurityTest.cs
// ������: wangshali
// ��������: 2008-08-28
// ����: ʵ�ֶ�Security�Ĳ���
// ----------------------------------------------------------------
using NUnit.Framework;
using ShiXin.Security;

namespace ShiXin.SecurityUnitTest
{
    [TestFixture]
    public class SymmetricEncryptVsSymmetricDecryptTest
    {
        private readonly string key = "wang.shali";
        [Test, Description("���Լ��ܽ���")]
        public void Test1()
        {
            const string actual = "adhfoiadfoiydflkj;lkjlczkvjuoiuafoiuewqr;lkj123j;lkjhj�ߺ����°�hoaho�ź��ް����޺�doifoudaifu �����羯������ɫ�ط������˹����  *&^(*#&^!(*#dlkf;la jfdsafldsaf  iudofiupuerlkjlfj ';][daf=-";
            string Encrypted = SecurityUtil.SymmetricEncrypt(actual, key);

            string Decrypted = SecurityUtil.SymmetricDecrypt(Encrypted, key);
            Assert.AreEqual(Decrypted, actual);

        }
        [Test, Description("���Լ��ܽ���")]
        public void Test2()
        {
            const string actual =
                "123Ŷiu 9874874398731409873475-19358=17532175=76=5213=6503198707�����ض���������Ⱦ";
            string Encrypted = SecurityUtil.SymmetricEncrypt(actual, key);

            string Decrypted = SecurityUtil.SymmetricDecrypt(Encrypted, key);
            Assert.AreEqual(Decrypted, actual);
        }

        [Test, Description("���Լ��ܽ���")]
        public void Test3()
        {
            const string actual = "778946";
            string Encrypted = SecurityUtil.SymmetricEncrypt(actual, key);

            string Decrypted = SecurityUtil.SymmetricDecrypt(Encrypted, key);
            Assert.AreEqual(Decrypted, actual);
        }

    }
}
