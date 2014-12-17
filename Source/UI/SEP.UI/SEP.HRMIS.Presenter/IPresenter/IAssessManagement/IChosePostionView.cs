//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: IChosePostionView.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-05
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.Model.Positions;

namespace SEP.HRMIS.Presenter
{
    public interface IChosePostionView
    {
        int PositionID { get; set; }
        string PositionNameForRight { get; set; }
        List<Position> PositionRight { get; set; }
        List<Position> PositionLeft { get; set; }
        event EventHandler ToRightEvent;
        event EventHandler ToLeftEvent;
        event EventHandler InitView;
    }
}