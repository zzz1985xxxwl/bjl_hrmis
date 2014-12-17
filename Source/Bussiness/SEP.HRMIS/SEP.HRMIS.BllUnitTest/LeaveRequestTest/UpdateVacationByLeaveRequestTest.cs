//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: UpdateVacationByLeaveRequestTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-13
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.LeaveRequests;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Request;
using SEP.Model.Calendar;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTest
{
    [TestFixture]
    public class UpdateVacationByLeaveRequestTest
    {
        private List<Model.Vacation> _VacationList;

        [SetUp]
        public void SetUp()
        {
            _VacationList = new List<Model.Vacation>();
        }

        [Test, Description("类型不是年假")]
        public void Test()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();

            DeleteVacationByLeaveReuqest _target = new DeleteVacationByLeaveReuqest();
            _target.TestExcute(1, GetLeaveRequestItem(), GetLeaveRequestType2(), GetVacationList(),
                               GetDayAttendance(), iVacation);
        }

        [Test, Description("没有年假")]
        public void Test2()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();

            DeleteVacationByLeaveReuqest _target = new DeleteVacationByLeaveReuqest();
            string error = "";
            try
            {
                _target.TestExcute(1, GetLeaveRequestItem(), GetLeaveRequestType2(), null,
                                   GetDayAttendance(), iVacation);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("没有年假", error);
        }

        [Test]
        public void Test3()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();
            Expect.Call(delegate { iVacation.Update(null); }).IgnoreArguments().Do(
                new Update(MockUpdate));
            mocks.ReplayAll();
            DeleteVacationByLeaveReuqest _target = new DeleteVacationByLeaveReuqest();
            _target.TestExcute(1, GetLeaveRequestItem(), GetLeaveRequestType(),  GetVacationList(),
                               GetDayAttendance(), iVacation);
            Assert.AreEqual(4, _VacationList[0].SurplusDayNum);
            Assert.AreEqual(6, _VacationList[0].UsedDayNum);
        }

        [Test]
        public void Test4()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();
            string error = "";
            try
            {
                DeleteVacationByLeaveReuqest _target = new DeleteVacationByLeaveReuqest();
                _target.TestExcute(1, GetLeaveRequestItem(), GetLeaveRequestType(),  GetVacationList2(),
                                   GetDayAttendance(), iVacation);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("剩余年假不足", error);
        }

        [Test]
        public void Test5()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();
            Expect.Call(delegate { iVacation.Update(null); }).IgnoreArguments().Do(
                new Update(MockUpdate));
            Expect.Call(delegate { iVacation.Update(null); }).IgnoreArguments().Do(
                new Update(MockUpdate));
            mocks.ReplayAll();
            DeleteVacationByLeaveReuqest _target = new DeleteVacationByLeaveReuqest();
            _target.TestExcute(1, GetLeaveRequestItem(), GetLeaveRequestType(),  GetVacationList3(),
                               GetDayAttendance(), iVacation);
            Assert.AreEqual(2,_VacationList.Count);
            Assert.AreEqual(0, _VacationList[0].SurplusDayNum);
            Assert.AreEqual(10, _VacationList[0].UsedDayNum);
            Assert.AreEqual(5.5, _VacationList[1].SurplusDayNum);
            Assert.AreEqual(4.5, _VacationList[1].UsedDayNum);
        }

        [Test]
        public void Test6()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();
            Expect.Call(delegate { iVacation.Update(null); }).IgnoreArguments().Do(
                new Update(MockUpdate));
            Expect.Call(delegate { iVacation.Update(null); }).IgnoreArguments().Do(
                new Update(MockUpdate));
            mocks.ReplayAll();
            DeleteVacationByLeaveReuqest _target = new DeleteVacationByLeaveReuqest();
            _target.TestExcute(1, GetLeaveRequestItem(), GetLeaveRequestType(),  GetVacationList3(),
                               GetDayAttendance2(), iVacation);
            Assert.AreEqual(2,_VacationList.Count);
            Assert.AreEqual(0, _VacationList[0].SurplusDayNum);
            Assert.AreEqual(10, _VacationList[0].UsedDayNum);
            Assert.AreEqual(4.5, _VacationList[1].SurplusDayNum);
            Assert.AreEqual(5.5, _VacationList[1].UsedDayNum);
        }
        [Test]
        public void Test7()
        {
            MockRepository mocks = new MockRepository();
            IVacation iVacation = mocks.CreateMock<IVacation>();
            Expect.Call(delegate { iVacation.Update(null); }).IgnoreArguments().Do(
                new Update(MockUpdate));
            Expect.Call(delegate { iVacation.Update(null); }).IgnoreArguments().Do(
                new Update(MockUpdate));
            mocks.ReplayAll();
            DeleteVacationByLeaveReuqest _target = new DeleteVacationByLeaveReuqest();
            _target.TestExcute(1, GetLeaveRequestItem(), GetLeaveRequestType(),  GetVacationList3(),
                               GetDayAttendance3(), iVacation);
            Assert.AreEqual(2, _VacationList.Count);
            Assert.AreEqual(0.25, _VacationList[0].SurplusDayNum);
            Assert.AreEqual(9.75, _VacationList[0].UsedDayNum);
            Assert.AreEqual(6, _VacationList[1].SurplusDayNum);
            Assert.AreEqual(4, _VacationList[1].UsedDayNum);
        }

        private static LeaveRequestType GetLeaveRequestType()
        {
            return new LeaveRequestType(1, "", "", LegalHoliday.UnInclude, RestDay.UnInclude, 4);
        }

        private static LeaveRequestType GetLeaveRequestType2()
        {
            return new LeaveRequestType(2, "", "", LegalHoliday.UnInclude, RestDay.UnInclude, 4);
        }

        private static List<LeaveRequestItem> GetLeaveRequestItem()
        {
            List<LeaveRequestItem> items = new List<LeaveRequestItem>();
            LeaveRequestItem item1 =
                new LeaveRequestItem(1, DT("2009-1-1 8:00:00"), DT("2009-1-1 17:00:00"), 8,
                                     RequestStatus.ApproveCancelPass);
            items.Add(item1);
            return items;
        }


        private static DateTime DT(string d)
        {
            return Convert.ToDateTime(d);
        }

        private static List<Model.Vacation> GetVacationList()
        {
            List<Model.Vacation> items = new List<Model.Vacation>();
            Model.Vacation vacation =
                new Model.Vacation(1, null, 10, DT("2009-1-1 8:00:00"), DT("2010-1-1 8:00:00"), 5, 5, "");
            items.Add(vacation);
            return items;
        }

        private static List<Model.Vacation> GetVacationList2()
        {
            List<Model.Vacation> items = new List<Model.Vacation>();
            Model.Vacation vacation =
                new Model.Vacation(1, null, 10, DT("2009-1-1 8:00:00"), DT("2010-1-1 8:00:00"), 9.5m, 0.5m, "");
            items.Add(vacation);
            return items;
        }

        private static List<Model.Vacation> GetVacationList3()
        {
            List<Model.Vacation> items = new List<Model.Vacation>();
            Model.Vacation vacation1 =
                new Model.Vacation(1, null, 10, DT("2010-1-1 8:00:00"), DT("2011-1-1 8:00:00"), 9.5m, 0.5m, "");
            Model.Vacation vacation2 =
                new Model.Vacation(1, null, 10, DT("2009-1-1 8:00:00"), DT("2010-1-1 8:00:00"), 4m, 6m, "");
            Model.Vacation vacation3 =
                new Model.Vacation(1, null, 10, DT("2008-1-1 8:00:00"), DT("2009-1-1 8:00:00"), 9.5m, 0.5m, "");
            items.Add(vacation1);
            items.Add(vacation2);
            items.Add(vacation3);
            return items;
        }

        private List<DayAttendance> GetDayAttendance()
        {
            List<DayAttendance> items = new List<DayAttendance>();
            DayAttendance day = new DayAttendance(1, "", 8, 0, DT("2009-1-1 8:00:00"), "",
                                                  CalendarType.Leave);
            items.Add(day);
            return items;
        }

        private List<DayAttendance> GetDayAttendance3()
        {
            List<DayAttendance> items = new List<DayAttendance>();
            DayAttendance day = new DayAttendance(1, "", 2, 0, DT("2009-1-1 8:00:00"), "",
                                                  CalendarType.Leave);
            items.Add(day);
            return items;
        }

        private List<DayAttendance> GetDayAttendance2()
        {
            List<DayAttendance> items = new List<DayAttendance>();
            DayAttendance day1 = new DayAttendance(1, "", 8, 0, DT("2009-4-30 8:00:00"), "",
                                                  CalendarType.Leave);
            DayAttendance day2 = new DayAttendance(1, "", 8, 0, DT("2009-5-1 8:00:00"), "",
                                                  CalendarType.Leave);
            items.Add(day1);
            items.Add(day2);
            return items;
        }

        private delegate int Update(Model.Vacation l);


        private int MockUpdate(Model.Vacation l)
        {
            _VacationList.Add(l);
            return 2;
        }
    }
}