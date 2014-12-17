//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TestUtility.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 测试Utility
// ----------------------------------------------------------------
using System.Collections.Generic;
using NUnit.Framework;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.BllUnitTest.PayModuleTest.AccountSet
{
    public class TestUtility
    {
        public static void AssertAccountSetPara(AccountSetPara actual, AccountSetPara expected)
        {
            Assert.AreEqual(expected.AccountSetParaID, actual.AccountSetParaID);
            Assert.AreEqual(expected.AccountSetParaName, actual.AccountSetParaName);
            Assert.AreEqual(expected.BindItem.Id, actual.BindItem.Id);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.FieldAttribute.Id, actual.FieldAttribute.Id);
            Assert.AreEqual(expected.MantissaRound.Id, actual.MantissaRound.Id);
        }
        public static void AssertAccountSet(SEP.HRMIS.Model.PayModule.AccountSet actual, SEP.HRMIS.Model.PayModule.AccountSet expected)
        {
            Assert.AreEqual(expected.AccountSetID, actual.AccountSetID);
            Assert.AreEqual(expected.AccountSetName, actual.AccountSetName);
            Assert.AreEqual(expected.Description, actual.Description);
            AssertAccountSetItemList(expected.Items, actual.Items);
        }

        private static void AssertAccountSetItemList(List<AccountSetItem> actualItems, List<AccountSetItem> expectedItems)
        {
            Assert.AreEqual(expectedItems.Count, actualItems.Count);
            for (int i = 0; i < expectedItems.Count; i++)
            {
                AssertAccountSetItem(actualItems[i], expectedItems[i]);
            }
        }

        private static void AssertAccountSetItem(AccountSetItem actual, AccountSetItem expected)
        {
            Assert.AreEqual(actual.AccountSetItemID, expected.AccountSetItemID);
            Assert.AreEqual(actual.CalculateFormula, expected.CalculateFormula);
            //Assert.AreEqual(actual.CalculateResult, expected.CalculateResult);
            AssertAccountSetPara(actual.AccountSetPara, expected.AccountSetPara);
        }

        public static void AssertEmployeeAccountSet(List<EmployeeSalary> actual, List<EmployeeSalary> expected)
        {
            Assert.AreEqual(actual.Count, expected.Count);
            for(int i=0;i<actual.Count;i++)
            {
                AssertAccountSet(actual[i].AccountSet, expected[i].AccountSet);
            }
        }
    }
}
