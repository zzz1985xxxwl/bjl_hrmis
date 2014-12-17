//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: DeleteAdjustRestByLeaveRequestTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-10
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.Model.EmployeeAdjustRest;

namespace SEP.HRMIS.BllUnitTest.EmployeeAdjustRestTest
{
    [TestFixture]
    public class DeleteAdjustRestByLeaveRequestTest
    {
        [Test]
        public void InitUpdateAdjustRestListTest()
        {
            List<AdjustRest> _AdjustRestList = new List<AdjustRest>();
            AdjustRest adjustRest1 = new AdjustRest(1, 4, null, Convert.ToDateTime("2009-1-1"));
            AdjustRest adjustRest2 = new AdjustRest(1, 2, null, Convert.ToDateTime("2009-12-20"));
            AdjustRest adjustRest3 = new AdjustRest(1, 3, null, Convert.ToDateTime("2008-12-21"));
            AdjustRest adjustRest4 = new AdjustRest(1, 5, null, Convert.ToDateTime("2008-12-20"));
            AdjustRest adjustRest5 = new AdjustRest(1, 6, null, Convert.ToDateTime("2007-4-20"));
            AdjustRest adjustRest6 = new AdjustRest(1, 7, null, Convert.ToDateTime("2007-12-21"));
            _AdjustRestList.Add(adjustRest1);
            _AdjustRestList.Add(adjustRest2);
            _AdjustRestList.Add(adjustRest3);
            _AdjustRestList.Add(adjustRest4);
            _AdjustRestList.Add(adjustRest5);
            _AdjustRestList.Add(adjustRest6);

            List<AdjustRest> adjustRestList = DeleteAdjustRestByLeaveRequest.InitUpdateAdjustRestList(_AdjustRestList);
            Assert.AreEqual(4, adjustRestList.Count);
            Assert.AreEqual(2009, adjustRestList[0].AdjustYear.Year);
            Assert.AreEqual(2008, adjustRestList[1].AdjustYear.Year);
            Assert.AreEqual(2007, adjustRestList[2].AdjustYear.Year);
            Assert.AreEqual(2006, adjustRestList[3].AdjustYear.Year);
        }


        [Test]
        public void ContainTest()
        {
            List<AdjustRest> _AdjustRestList = new List<AdjustRest>();
            AdjustRest adjustRest1 = new AdjustRest(1, 4, null, Convert.ToDateTime("2009-1-1"));
            AdjustRest adjustRest2 = new AdjustRest(1, 2, null, Convert.ToDateTime("2009-12-20"));
            AdjustRest adjustRest3 = new AdjustRest(1, 3, null, Convert.ToDateTime("2008-12-21"));
            AdjustRest adjustRest4 = new AdjustRest(1, 5, null, Convert.ToDateTime("2008-12-20"));
            AdjustRest adjustRest5 = new AdjustRest(1, 6, null, Convert.ToDateTime("2007-4-20"));
            AdjustRest adjustRest6 = new AdjustRest(1, 7, null, Convert.ToDateTime("2007-12-21"));
            _AdjustRestList.Add(adjustRest1);
            _AdjustRestList.Add(adjustRest2);
            _AdjustRestList.Add(adjustRest3);
            _AdjustRestList.Add(adjustRest4);
            _AdjustRestList.Add(adjustRest5);
            _AdjustRestList.Add(adjustRest6);

            AdjustRest adjustRest = DeleteAdjustRestByLeaveRequest.Contain(Convert.ToDateTime("2009-1-1"),_AdjustRestList);
            Assert.AreEqual(2008, adjustRest.AdjustYear.Year);
            adjustRest = DeleteAdjustRestByLeaveRequest.Contain(Convert.ToDateTime("2009-4-20"), _AdjustRestList);
            Assert.AreEqual(2008, adjustRest.AdjustYear.Year);
            adjustRest = DeleteAdjustRestByLeaveRequest.Contain(Convert.ToDateTime("2009-4-21"), _AdjustRestList);
            Assert.AreEqual(2009, adjustRest.AdjustYear.Year);
            adjustRest = DeleteAdjustRestByLeaveRequest.Contain(Convert.ToDateTime("2010-4-20"), _AdjustRestList);
            Assert.AreEqual(2009, adjustRest.AdjustYear.Year);
            adjustRest = DeleteAdjustRestByLeaveRequest.Contain(Convert.ToDateTime("2009-12-20"), _AdjustRestList);
            Assert.AreEqual(2009, adjustRest.AdjustYear.Year);
            adjustRest = DeleteAdjustRestByLeaveRequest.Contain(Convert.ToDateTime("2009-12-21"), _AdjustRestList);
            Assert.AreEqual(2009, adjustRest.AdjustYear.Year);
        }

        [Test]
        public void ContainByYearTest()
        {
            List<AdjustRest> _AdjustRestList = new List<AdjustRest>();
            AdjustRest adjustRest1 = new AdjustRest(1, 4, null, Convert.ToDateTime("2009-1-1"));
            AdjustRest adjustRest2 = new AdjustRest(1, 2, null, Convert.ToDateTime("2009-12-20"));
            AdjustRest adjustRest3 = new AdjustRest(1, 3, null, Convert.ToDateTime("2008-12-21"));
            AdjustRest adjustRest4 = new AdjustRest(1, 5, null, Convert.ToDateTime("2008-12-20"));
            AdjustRest adjustRest5 = new AdjustRest(1, 6, null, Convert.ToDateTime("2007-4-20"));
            AdjustRest adjustRest6 = new AdjustRest(1, 7, null, Convert.ToDateTime("2007-12-21"));
            _AdjustRestList.Add(adjustRest1);
            _AdjustRestList.Add(adjustRest2);
            _AdjustRestList.Add(adjustRest3);
            _AdjustRestList.Add(adjustRest4);
            _AdjustRestList.Add(adjustRest5);
            _AdjustRestList.Add(adjustRest6);

            AdjustRest adjustRest = DeleteAdjustRestByLeaveRequest.ContainByYear(Convert.ToDateTime("2009-1-1"), _AdjustRestList);
            Assert.AreEqual(2009, adjustRest.AdjustYear.Year);
            adjustRest = DeleteAdjustRestByLeaveRequest.ContainByYear(Convert.ToDateTime("2009-12-21"), _AdjustRestList);
            Assert.IsNull(adjustRest);
            adjustRest = DeleteAdjustRestByLeaveRequest.ContainByYear(Convert.ToDateTime("2008-12-21"), _AdjustRestList);
            Assert.AreEqual(2009, adjustRest.AdjustYear.Year);
            adjustRest = DeleteAdjustRestByLeaveRequest.ContainByYear(Convert.ToDateTime("2008-12-20"), _AdjustRestList);
            Assert.AreEqual(2008, adjustRest.AdjustYear.Year);
             
        }
    }
}