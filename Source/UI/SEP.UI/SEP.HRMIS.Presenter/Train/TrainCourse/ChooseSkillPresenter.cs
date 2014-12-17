//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ChooseSkillPresenter.cs
// 创建者: ZZ
// 创建日期: 2008-11-13
// 概述: 选择技能
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;

namespace SEP.HRMIS.Presenter.Train.TrainCourse
{
    public class ChooseSkillPresenter
    {
        public readonly IChooseSkillView _View;
        private ISkillFacade _ISkillFacade = InstanceFactory.CreateSkillFacade();
        private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();
        //private readonly IGetSkillType _IGetSkillType = new GetSkillType();
        //private readonly IGetSkill _IGetSkill = new GetSkill();

        public ChooseSkillPresenter(IChooseSkillView view)
        {
            _View = view;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _View.SearchSkillEvent += SearchSkill;
            _View.ToRightEvent += ToRight;
            _View.ToLeftEvent += ToLeft;
            _View.InitView += Init;

        }

        public void Init(object sender, EventArgs e)
        {
            _View.SkillTypeList = _ISkillTypeFacade.GetSkillTypeByCondition(-1, "");
            _View.SkillRight = new List<Skill>();
            _View.SkillLeft = new List<Skill>();

        }

        public void InitControl(object sender, EventArgs e)
        {
            _View.SkillTypeList = _ISkillTypeFacade.GetSkillTypeByCondition(-1, "");
            _View.SkillRight = _View.SkillRight;
        }

        public void SearchSkill(object sender, EventArgs e)
        {

            _View.SkillLeft =
                _ISkillFacade.GetSkillByCondition(_View.SkillName, _View.SkillTypeID);
        }

        public void ToRight(object sender, EventArgs e)
        {
            if (!contions(_View.SkillID))
            {
                Skill skill = new Skill(0, _View.SkillNameForRight, null);
                skill.SkillID = _View.SkillID;
                _View.SkillRight.Add(skill);
            }
        }

        private bool contions(int i)
        {
            foreach (Skill skill in _View.SkillRight)
            {
                if (i == skill.SkillID)
                    return true;

            }
            return false;
        }

        public void ToLeft(object sender, EventArgs e)
        {
            _View.SkillRight.RemoveAll(MatchID);
        }

        private bool MatchID(Skill skill)
        {
            if (skill.SkillID == _View.SkillID)
            { return true; }
            else
            { return false; }
        }

        //  #region 测试用
        //public IGetSkillType MockGetSkillType { set { _IGetSkillType = value; } }
        //public IGetSkill MockGetEmployee { set { _IGetSkill = value; } }


        //  private string _EmployeeRightSessionName;
        //  public string EmployeeRightSessionName
        //  {
        //      get { return _EmployeeRightSessionName; }
        //      set
        //      {
        //          _EmployeeRightSessionName = value;
        //          _View.EmployeeRightSessionName = value;
        //      }
        //  }

        //  private string _EmployeeLeftSessionName;
        //  public string EmployeeLeftSessionName
        //  {
        //      get { return _EmployeeLeftSessionName; }
        //      set
        //      {
        //          _EmployeeLeftSessionName = value;
        //          _View.EmployeeLeftSessionName = value;
        //      }
        //  }

        //  #endregion
    }
}
