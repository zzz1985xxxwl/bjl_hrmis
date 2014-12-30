//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: NotesTest.cs
// Creater:  Xue.wenlong
// Date:  2010-04-08
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SEP.Model.Accounts;
using SEP.Notes;
using SEP.Notes.RepeatTypes;

namespace Test
{
    /// <summary>
    /// </summary>
    [TestFixture]
    public class NotesTest
    {
        private Notes note;
        [SetUp]
        public void SetUp()
        {
            note=new Notes();
        }

        [Test]
        public void Test1()
        {
            StringBuilder builder = new StringBuilder();
            string[] b = {"d", "c"};
            foreach (string account in b)
            {
                builder.AppendFormat("{0};", account);
            }
            builder.Remove(builder.Length - 1, 1);
            Console.WriteLine(builder.ToString());
        }

        [Test]
        public void Test4()
        {
            DateTime dt = GetLastDate(DateTime.Now);
            Console.WriteLine(dt.AddDays((Convert.ToInt32(DayOfWeek.Monday)- (int)dt.DayOfWeek-7)%7));
        }
        [Test]
        public void Test3()
        {
            StringBuilder builder = new StringBuilder();
            string[] b = { "d", "c" };
            foreach (string account in b)
            {
                builder.AppendFormat("{0};", account);
            }
            builder.Remove(builder.Length - 1, 1);
            Console.WriteLine(builder.ToString());

            DateTime dt = GetLastDate(Convert.ToDateTime("2010-1-1"));
            dt=dt.AddDays((Convert.ToInt32(DayOfWeek.Sunday) - ((int)dt.DayOfWeek == 0 ? 7 : (int)dt.DayOfWeek)) % 7);
            Console.WriteLine(dt);
        }
        private DateTime GetLastDate(DateTime monthDate)
        {
            DateTime dt = new DateTime(monthDate.Year, monthDate.Month, 28);
            for (int i = 1; i < 4; i++)
            {
                if (dt.AddDays(1).Month == monthDate.Month)
                {
                    dt = dt.AddDays(1);
                }
                else
                {
                    return dt;
                }
            }
            return dt;
        }
        [Test]
        public void Test2()
        {
            DateTime dt=new DateTime(2010,4,9,1,2,0);
            Console.WriteLine(dt);
            Console.WriteLine(dt.AddDays(1).AddMinutes(2));
            string s = "2|20|";
            Console.WriteLine(s.Split('|').Length);
            Console.WriteLine(dt);
            dt.AddDays(1);
            dt = dt.AddDays(-Convert.ToInt32(dt.DayOfWeek)+1);
            Console.WriteLine(dt.ToShortTimeString());
            DateTime date = Convert.ToDateTime("2010-4-17");
            Console.WriteLine(Convert.ToInt32(date.DayOfWeek));
            Console.WriteLine((date.Date.AddDays(-Convert.ToInt32(date.DayOfWeek) + 1) - Convert.ToDateTime("2010-4-17").Date).Days % 1 == 0); 
        }

        [Test]
        public void InsertNoRepeat()
        {
            note.Content = "123321";
            note.Start = Convert.ToDateTime("2010-1-1 11:1:1");
            note.End = Convert.ToDateTime("2010-1-1 12:1:1");
            note.Owner = new Account();
            note.Owner.Id = 79;
            note.RepeatType = new NoRepeat();
            note.ShareSet = new Share();
            note.ShareSet.Accounts = new List<Account>();
            note.ShareSet.Accounts.Add(new Account(55, "", ""));
            Assert.IsTrue(note.PKID == 0);
            Assert.IsTrue(note.ShareSet.NoteID == 0);
            note.Save();
            Assert.IsTrue(note.PKID > 0);
            Assert.IsTrue(note.ShareSet.NoteID > 0);
            Notes n = Notes.GetByID(note.PKID);
            Assert.AreEqual(55,n.ShareSet.Accounts[0].Id);
        }

        [Test]
        public void InsertGetDayRepeatTest()
        {
            note.Content = "123321";
            note.Start = Convert.ToDateTime("2010-1-1 11:1:1");
            note.End = Convert.ToDateTime("2010-1-1 12:1:1");
            note.Owner = new Account();
            note.Owner.Id = 79;
            DayRepeat day = new DayRepeat();
            day.RangeStart = Convert.ToDateTime("2010-11-1 11:1:1");
            day.NDayOnce = 1;
            note.RepeatType = day;
            note.Save();
            Notes n=Notes.GetByID(note.PKID);
            Assert.AreEqual(n.Owner.Id,note.Owner.Id);
            Assert.IsTrue(n.RepeatType is DayRepeat);

        }

        [Test]
        public void UpdateDayRepeat()
        {
            note.Content = "123321";
            note.Start = Convert.ToDateTime("2010-1-1 11:1:1");
            note.End = Convert.ToDateTime("2010-1-1 12:1:1");
            note.Owner = new Account();
            note.Owner.Id = 79;
            DayRepeat day = new DayRepeat();
            day.RangeStart = Convert.ToDateTime("2010-11-1 11:1:1");
            day.NDayOnce = 1;
            note.RepeatType = day;
            note.Save();
            Assert.IsTrue(note.PKID > 0);
            note.Content = "5432";
            ((DayRepeat) note.RepeatType).EveryWeek = true;
            note.Update();
        }

        [TearDown]
        public void TearDown()
        {
            note.Delete();
        }
    }
}