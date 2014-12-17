//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: ChosePositionPresenter.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-05
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.IBll.Positions;
using SEP.Model.Positions;

namespace SEP.HRMIS.Presenter.AssessManagement
{
    public class ChosePositionPresenter
    {
        public readonly IChosePostionView _View;
        private readonly IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        public ChosePositionPresenter(IChosePostionView view)
        {
            _View = view;
            AttachViewEvent();
        }
        public void AttachViewEvent()
        {
            _View.ToRightEvent += ToRight;
            _View.ToLeftEvent += ToLeft;
            _View.InitView += Init;
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Init(object sender, EventArgs e)
        {
            _View.PositionLeft = _IPositionBll.GetAllPosition();
            if (_View.PositionRight == null)
            {
                _View.PositionRight = new List<Position>();
            }
        }


        /// <summary>
        /// 移入员工操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToRight(object sender, EventArgs e)
        {
            if (!contions(_View.PositionID))
            {
                Position position=new Position(_View.PositionID,_View.PositionNameForRight,null);
                _View.PositionRight.Add(position);
            }
        }

        private bool contions(int i)
        {
            foreach (Position position in _View.PositionRight)
            {
                if (i == position.Id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 移除员工操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ToLeft(object sender, EventArgs e)
        {
            _View.PositionRight.RemoveAll(MatchID);
        }

        private bool MatchID(Position position)
        {
            if (position.Id == _View.PositionID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}