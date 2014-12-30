//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IRepeat.cs
// Creater:  Xue.wenlong
// Date:  2010-04-09
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SEP.Model.CalendarExt;

namespace SEP.Notes.RepeatTypes
{
    /// <summary>
    /// </summary>
    public interface IRepeat
    {
        List<CalendarADay> GetByDate(DateTime start, DateTime end, List<Notes> source);
        void Valide();
        IRepeat SqlGetByID(SqlDataReader sdr);

        void SqlSave(SqlCommand cmd);

        void SqlUpdate(SqlCommand cmd);
    }
}