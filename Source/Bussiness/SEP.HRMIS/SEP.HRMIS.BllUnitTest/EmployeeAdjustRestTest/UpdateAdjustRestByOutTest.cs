//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: UpdateAdjustRestByOutTest.cs
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
    public class UpdateAdjustRestByOutTest
    {
        [Test]
        public void InitUpdateAdjustRestListTest()
        {
            List<AdjustRest> _AdjustRestList=new List<AdjustRest>();
            AdjustRest adjustRest1=new AdjustRest(1,4,null,Convert.ToDateTime("2009-2-1"));
            AdjustRest adjustRest2 = new AdjustRest(1, 2, null, Convert.ToDateTime("2009-2-1"));
            AdjustRest adjustRest3 = new AdjustRest(1, 3, null, Convert.ToDateTime("2008-2-1"));
            AdjustRest adjustRest4 = new AdjustRest(1, 5, null, Convert.ToDateTime("2008-2-1"));
            AdjustRest adjustRest5 = new AdjustRest(1, 6, null, Convert.ToDateTime("2007-2-1"));
            AdjustRest adjustRest6 = new AdjustRest(1, 7, null, Convert.ToDateTime("2007-2-1"));
            AdjustRest adjustRest7 = new AdjustRest(1, 8, null, Convert.ToDateTime("2007-2-1"));
            _AdjustRestList.Add(adjustRest1);
            _AdjustRestList.Add(adjustRest2);
            _AdjustRestList.Add(adjustRest3);
            _AdjustRestList.Add(adjustRest4);
            _AdjustRestList.Add(adjustRest5);
            _AdjustRestList.Add(adjustRest6);
            _AdjustRestList.Add(adjustRest7);
            List<AdjustRest> UpdatedAdjustRestList=UpdateAdjustRestByOut.InitUpdateAdjustRestList(_AdjustRestList);
            Assert.AreEqual(3,UpdatedAdjustRestList.Count);
            Assert.AreEqual(6,UpdatedAdjustRestList[0].SurplusHours);
            Assert.AreEqual(2009, UpdatedAdjustRestList[0].AdjustYear.Year);
            Assert.AreEqual(8, UpdatedAdjustRestList[1].SurplusHours);
            Assert.AreEqual(2008, UpdatedAdjustRestList[1].AdjustYear.Year);
            Assert.AreEqual(21, UpdatedAdjustRestList[2].SurplusHours);
            Assert.AreEqual(2007, UpdatedAdjustRestList[2].AdjustYear.Year);

        }

        [Test]
        public void InitUpdateAdjustRestListTest2()
        {
            List<AdjustRest> _AdjustRestList = new List<AdjustRest>();
            AdjustRest adjustRest1 = new AdjustRest(1, 4, null, Convert.ToDateTime("2009-12-21"));
            AdjustRest adjustRest2 = new AdjustRest(1, 2, null, Convert.ToDateTime("2009-12-20"));
            AdjustRest adjustRest3 = new AdjustRest(1, 3, null, Convert.ToDateTime("2008-12-20"));
            AdjustRest adjustRest4 = new AdjustRest(1, 5, null, Convert.ToDateTime("2008-12-21"));
            AdjustRest adjustRest5 = new AdjustRest(1, 6, null, Convert.ToDateTime("2007-2-1"));
            AdjustRest adjustRest6 = new AdjustRest(1, 7, null, Convert.ToDateTime("2007-2-1"));
            AdjustRest adjustRest7 = new AdjustRest(1, 8, null, Convert.ToDateTime("2007-2-1"));
            _AdjustRestList.Add(adjustRest1);
            _AdjustRestList.Add(adjustRest2);
            _AdjustRestList.Add(adjustRest3);
            _AdjustRestList.Add(adjustRest4);
            _AdjustRestList.Add(adjustRest5);
            _AdjustRestList.Add(adjustRest6);
            _AdjustRestList.Add(adjustRest7);
            List<AdjustRest> UpdatedAdjustRestList = UpdateAdjustRestByOut.InitUpdateAdjustRestList(_AdjustRestList);
            Assert.AreEqual(4, UpdatedAdjustRestList.Count);
            Assert.AreEqual(4, UpdatedAdjustRestList[0].SurplusHours);
            Assert.AreEqual(2010, UpdatedAdjustRestList[0].AdjustYear.Year);
            Assert.AreEqual(7, UpdatedAdjustRestList[1].SurplusHours);
            Assert.AreEqual(2009, UpdatedAdjustRestList[1].AdjustYear.Year);
            Assert.AreEqual(3, UpdatedAdjustRestList[2].SurplusHours);
            Assert.AreEqual(2008, UpdatedAdjustRestList[2].AdjustYear.Year);
            Assert.AreEqual(21, UpdatedAdjustRestList[3].SurplusHours);
            Assert.AreEqual(2007, UpdatedAdjustRestList[3].AdjustYear.Year);

        }
    }
}