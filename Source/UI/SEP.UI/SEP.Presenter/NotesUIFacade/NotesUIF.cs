//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: NotesUIF.cs
// Creater:  Xue.wenlong
// Date:  2010-04-12
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Notes;
using SEP.Notes.RepeatTypes;

namespace SEP.Presenter.NotesUIFacade
{
    /// <summary>
    /// </summary>
    public class NotesUIF
    {
        public List<Account> GetAccountByCondition(string employeeName, string departmentID)
        {
            return BllInstance.AccountBllInstance.GetAccountByCondition(employeeName.Trim(),
                                                                        departmentID == "-1"
                                                                            ? (int?) null
                                                                            : Convert.ToInt32(
                                                                                  departmentID),
                                                                        null,
                                                                        VisibleType.SEP);
        }

        public
            void AddNoRepeatNotes(string startDate, string startHour, string startMinutes, string endDate,
                                  string endHour, string endMinutes, string content, string shares)
        {
            MadeNoRepeatNotes(startDate, startHour, startMinutes, endDate,
                              endHour, endMinutes, content, shares, "0").Save();
        }

        public
            void UpdateNoRepeatNotes(string startDate, string startHour, string startMinutes, string endDate,
                                     string endHour, string endMinutes, string content, string shares, string pkid)
        {
            MadeNoRepeatNotes(startDate, startHour, startMinutes, endDate,
                              endHour, endMinutes, content, shares, pkid).Update();
        }


        public
            void AddDayRepeatNotes(string startHour, string startMinutes, string endHour, string endMinutes,
                                   string startRange, string
                                                          endRange, string chosetype, string ndayOnce, string content,
                                   string shares)
        {
            MadeDayRepeatNotes(startHour, startMinutes, endHour, endMinutes,
                               startRange,
                               endRange, chosetype, ndayOnce, content, shares, "0").Save();
        }

        public
            void UpdateDayRepeatNotes(string startHour, string startMinutes, string endHour, string endMinutes,
                                      string startRange, string
                                                             endRange, string chosetype, string ndayOnce, string content,
                                      string shares, string pkid)
        {
            MadeDayRepeatNotes(startHour, startMinutes, endHour, endMinutes,
                               startRange,
                               endRange, chosetype, ndayOnce, content, shares, pkid).Update();
        }

        public
            void AddWeekRepeatNotes(string startHour, string startMinutes, string endHour, string endMinutes,
                                    string startRange,
                                    string endRange, string nweek, string weeks, string content, string shares)
        {
            MadeWeekRepeatNotes(startHour, startMinutes, endHour, endMinutes,
                                startRange,
                                endRange, nweek, weeks, content, shares, "0").Save();
        }

        public
            void UpdateWeekRepeatNotes(string startHour, string startMinutes, string endHour, string endMinutes,
                                       string startRange,
                                       string endRange, string nweek, string weeks, string content, string shares,
                                       string pkid)
        {
            MadeWeekRepeatNotes(startHour, startMinutes, endHour, endMinutes,
                                startRange,
                                endRange, nweek, weeks, content, shares, pkid).Update();
        }

        public  void AddMonthRepeatNotes(string startHour, string startMinutes, string endHour,
                                                string endMinutes,
                                                string startRange,
                                                string endRange, string nMonth, string ndayMonthEnum,
                                                string monthDayTypeEnum, string content,
                                                string shares)
        {
            MadeMonthRepeatNotes(startHour, startMinutes, endHour, endMinutes,
                                 startRange,
                                 endRange, nMonth, ndayMonthEnum, monthDayTypeEnum, content,
                                 shares, "0").Save();
        }

        public  void UpdateMonthRepeatNotes(string startHour, string startMinutes, string endHour,
                                                   string endMinutes,
                                                   string startRange,
                                                   string endRange, string nMonth, string ndayMonthEnum,
                                                   string monthDayTypeEnum, string content,
                                                   string shares, string pkid)
        {
            MadeMonthRepeatNotes(startHour, startMinutes, endHour, endMinutes,
                                 startRange,
                                 endRange, nMonth, ndayMonthEnum, monthDayTypeEnum, content,
                                 shares, pkid).Update();
        }

        private static Notes.Notes MadeNoRepeatNotes(string startDate, string startHour, string startMinutes,
                                                     string endDate,
                                                     string endHour, string endMinutes, string content, string shares,
                                                     string pkid)
        {
            Notes.Notes note = new Notes.Notes();
            note.PKID = Convert.ToInt32(pkid);
            note.Content = content.Trim();
            note.Start = Convert.ToDateTime(string.Format("{0} {1}:{2}", startDate.Trim(), startHour, startMinutes));
            note.End = Convert.ToDateTime(string.Format("{0} {1}:{2}", endDate.Trim(), endHour, endMinutes));
            note.ShareSet = new Share();
            note.ShareSet.NoteID = note.PKID;
            note.ShareSet.Accounts = Share.toAccountList(shares);
            note.RepeatType = new NoRepeat();
            return note;
        }

        private static Notes.Notes MadeDayRepeatNotes(string startHour, string startMinutes, string endHour,
                                                      string endMinutes,
                                                      string startRange, string
                                                                             endRange, string chosetype, string ndayOnce,
                                                      string content, string shares, string pkid)
        {
            Notes.Notes note = new Notes.Notes();
            note.PKID = Convert.ToInt32(pkid);
            note.Content = content.Trim();
            note.Start = Convert.ToDateTime(string.Format("2010-1-1 {0}:{1}", startHour, startMinutes));
            note.End = Convert.ToDateTime(string.Format("2010-1-1 {0}:{1}", endHour, endMinutes));
            note.ShareSet = new Share();
            note.ShareSet.NoteID = note.PKID;
            note.ShareSet.Accounts = Share.toAccountList(shares);
            DayRepeat repeat = new DayRepeat();
            switch (chosetype)
            {
                case "1":
                    repeat.NDayOnce = Convert.ToInt32(ndayOnce);
                    break;
                case "2":
                    repeat.EveryWork = true;
                    break;
                case "3":
                    repeat.EveryWeek = true;
                    break;
            }
            repeat.RangeStart = Convert.ToDateTime(startRange);
            if (!string.IsNullOrEmpty(endRange.Trim()))
            {
                repeat.RangeEnd = Convert.ToDateTime(endRange);
            }
            note.RepeatType = repeat;
            return note;
        }

        private static Notes.Notes MadeWeekRepeatNotes(string startHour, string startMinutes, string endHour,
                                                       string endMinutes,
                                                       string startRange,
                                                       string endRange, string nweek, string weeks, string content,
                                                       string shares, string pkid)
        {
            Notes.Notes note = new Notes.Notes();
            note.PKID = Convert.ToInt32(pkid);
            note.Content = content.Trim();
            note.Start = Convert.ToDateTime(string.Format("2010-1-1 {0}:{1}", startHour, startMinutes));
            note.End = Convert.ToDateTime(string.Format("2010-1-1 {0}:{1}", endHour, endMinutes));
            note.ShareSet = new Share();
            note.ShareSet.NoteID = note.PKID;
            note.ShareSet.Accounts = Share.toAccountList(shares);
            WeekRepeat repeat = new WeekRepeat();
            repeat.NWeek = Convert.ToInt32(nweek);
            repeat.WeekList = new List<string>(weeks.Split('|'));
            if (string.IsNullOrEmpty(repeat.WeekList[repeat.WeekList.Count - 1]))
            {
                repeat.WeekList.RemoveAt(repeat.WeekList.Count - 1);
            }
            repeat.RangeStart = Convert.ToDateTime(startRange);
            if (!string.IsNullOrEmpty(endRange.Trim()))
            {
                repeat.RangeEnd = Convert.ToDateTime(endRange);
            }
            note.RepeatType = repeat;
            return note;
        }

        private static Notes.Notes MadeMonthRepeatNotes(string startHour, string startMinutes, string endHour,
                                                        string endMinutes,
                                                        string startRange,
                                                        string endRange, string nMonth, string ndayMonthEnum,
                                                        string monthDayTypeEnum, string content,
                                                        string shares, string pkid)
        {
            Notes.Notes note = new Notes.Notes();
            note.PKID = Convert.ToInt32(pkid);
            note.Content = content.Trim();
            note.Start = Convert.ToDateTime(string.Format("2010-1-1 {0}:{1}", startHour, startMinutes));
            note.End = Convert.ToDateTime(string.Format("2010-1-1 {0}:{1}", endHour, endMinutes));
            note.ShareSet = new Share();
            note.ShareSet.NoteID = note.PKID;
            note.ShareSet.Accounts = Share.toAccountList(shares);
            MonthRepeat repeat = new MonthRepeat();
            repeat.NMonth = Convert.ToInt32(nMonth);
            repeat.MonthDayTypeEnum = MonthDayTypeEnum.GetByValue(Convert.ToInt32(monthDayTypeEnum));
            repeat.NDayMonthEnum = NDayMonthEnum.GetByValue(Convert.ToInt32(ndayMonthEnum));
            repeat.RangeStart = Convert.ToDateTime(startRange);
            if (!string.IsNullOrEmpty(endRange.Trim()))
            {
                repeat.RangeEnd = Convert.ToDateTime(endRange);
            }
            note.RepeatType = repeat;
            return note;
        }

        public void QuiteShare(string pkid)
        {
            Share.Quite(Convert.ToInt32(pkid));
        }

        public void DeleteNotes(string pkid)
        {
            Notes.Notes note = Notes.Notes.GetByID(Convert.ToInt32(pkid));
            note.Delete();
        }

        public Notes.Notes GetNoteByID(string pkid)
        {
            return Notes.Notes.GetByID(Convert.ToInt32(pkid));
        }
    }
}