//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetDepartmentHistoryTest.cs
// 创建者: 王玥琦
// 创建日期: 2008-11-13
// 概述: 查询部门历史的单元测试
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.Model.Departments;

namespace SEP.HRMIS.BllUnitTest
{
    [TestFixture]
    public class GetDepartmentHistoryTest
    {
        [Test, Description("获得dt时间点deparmentID的树形结构，以列表形式返回")]
        public void GetDepartmentListStructByDepartmentIDAndDateTimeTest()
        {
            MockRepository mocks = new MockRepository();
            IDepartmentHistory iDepartmentHistory = (IDepartmentHistory)mocks.CreateMock(typeof(IDepartmentHistory));

            List<Department> allDepartment = new List<Department>();
            Department Department0 = new Department(0, null, "0", null);
            Department Department1 = new Department(1, null, "1", Department0);
            Department Department11 = new Department(11, null, "11", Department1);
            Department Department12 = new Department(12, null, "12", Department1);
            Department Department13 = new Department(13, null, "13", Department1);
            Department Department111 = new Department(111, null, "111", Department11);
            Department Department112 = new Department(112, null, "112", Department11);
            Department Department121 = new Department(121, null, "121", Department12);
            Department Department122 = new Department(122, null, "122", Department12);
            Department Department123 = new Department(123, null, "123", Department12);
            Department Department131 = new Department(131, null, "131", Department13);
            Department Department132 = new Department(132, null, "132", Department13);
            Department Department133 = new Department(133, null, "133", Department13);

            allDepartment.Add(Department1);
            allDepartment.Add(Department11);
            allDepartment.Add(Department12);
            allDepartment.Add(Department13);
            allDepartment.Add(Department111);
            allDepartment.Add(Department112);
            allDepartment.Add(Department121);
            allDepartment.Add(Department122);
            allDepartment.Add(Department123);
            allDepartment.Add(Department131);
            allDepartment.Add(Department132);
            allDepartment.Add(Department133);
            DateTime dt = DateTime.Now;

            Expect.Call(iDepartmentHistory.GetDepartmentNoStructByDateTime(dt)).Return(allDepartment);

            mocks.ReplayAll();

            List<Department> expectedDepartment = new List<Department>();
            expectedDepartment.Add(Department1);
            expectedDepartment.Add(Department11);
            expectedDepartment.Add(Department111);
            expectedDepartment.Add(Department112);
            expectedDepartment.Add(Department12);
            expectedDepartment.Add(Department121);
            expectedDepartment.Add(Department122);
            expectedDepartment.Add(Department123);
            expectedDepartment.Add(Department13);
            expectedDepartment.Add(Department131);
            expectedDepartment.Add(Department132);
            expectedDepartment.Add(Department133);

            GetDepartmentHistory target = new GetDepartmentHistory(iDepartmentHistory);
            List<Department> actualDepartment = target.GetDepartmentListStructByDepartmentIDAndDateTime(1, dt);
            mocks.VerifyAll();

            Assert.AreEqual(expectedDepartment.Count, actualDepartment.Count);
            AssertDepartmentListInfo(expectedDepartment, actualDepartment);
        }
        [Test, Description("获得dt时间点的组织架构,有树形结构")]
        public void GetDepartmentTreeStructByDateTimeTest()
        {
            MockRepository mocks = new MockRepository();
            IDepartmentHistory iDepartmentHistory = (IDepartmentHistory)mocks.CreateMock(typeof(IDepartmentHistory));
            DateTime dt = DateTime.Now;
            Expect.Call(iDepartmentHistory.GetDepartmentTreeStructByDateTime(dt)).Return(
                new List<Department>());
            mocks.ReplayAll();
            GetDepartmentHistory target = new GetDepartmentHistory(iDepartmentHistory);
            target.GetDepartmentTreeStructByDateTime(dt);
            mocks.VerifyAll();
        }
        [Test, Description("获得dt时间点的组织架构,无结构")]
        public void GetDepartmentNoStructByDateTimeTest()
        {
            MockRepository mocks = new MockRepository();
            IDepartmentHistory iDepartmentHistory = (IDepartmentHistory)mocks.CreateMock(typeof(IDepartmentHistory));
            DateTime dt = DateTime.Now;
            Expect.Call(iDepartmentHistory.GetDepartmentNoStructByDateTime(dt)).Return(
                new List<Department>());
            mocks.ReplayAll();
            GetDepartmentHistory target = new GetDepartmentHistory(iDepartmentHistory);
            target.GetDepartmentNoStructByDateTime(dt);
            mocks.VerifyAll();
        }

        private static void AssertDepartmentListInfo(List<Department> expecteds, List<Department> actuals)
        {
            for (int i = 0; i < expecteds.Count; i++)
            {
                AssertDepartmentInfo(expecteds[i], actuals[i]);
            }
        }

        private static void AssertDepartmentInfo(Department expected, Department actual)
        {
            Assert.AreEqual(expected.DepartmentID, actual.DepartmentID);
            Assert.AreEqual(expected.DepartmentName, actual.DepartmentName);
            Assert.AreEqual(expected.ParentDepartment.DepartmentID, actual.ParentDepartment.DepartmentID);
            Assert.AreEqual(expected.ParentDepartment.DepartmentName, actual.ParentDepartment.DepartmentName);
        }
    }
}
