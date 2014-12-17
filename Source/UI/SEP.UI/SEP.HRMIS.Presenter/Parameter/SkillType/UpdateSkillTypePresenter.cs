//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: UpdateSkillTypePresenter.cs
// 创建者: 刘丹
// 创建日期: 2009-10-22
// 概述: 更新技能类型小界面的Presenter
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.Parameter.SkillType
{
    public class UpdateSkillTypePresenter
    {
         private readonly ISkillTypeView _ItsView;
       private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();

       public Model.SkillType _ItsModel;

        public UpdateSkillTypePresenter(ISkillTypeView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += UpdateEvent;
        }

        public void InitView(string id)
        {
            _ItsView.Message = string.Empty;
            _ItsView.NameMsg = string.Empty;
            _ItsView.SkillTypeID = string.Empty;
            _ItsView.SkillTypeName = string.Empty;
            _ItsView.OperationTitle = "修改技能类型";
            _ItsView.OperationType = "Update";
            DataBind(id);
        }

        public void DataBind(string id)
        {
            int _ID;
            if (!VaildateId(id, out _ID))
            {
                return;
            }
            Model.SkillType theDataToBind = _ISkillTypeFacade.GetSkillTypeByPKID(_ID);
            if (theDataToBind == null) return;
            _ItsView.SkillTypeID = theDataToBind.ParameterID.ToString();
            _ItsView.SkillTypeName = theDataToBind.Name;
        }

        public void UpdateEvent()
       {
           if (Vaildation())
           {
               try
               {
                   Model.SkillType skillType = new Model.SkillType(Convert.ToInt32(_ItsView.SkillTypeID), _ItsView.SkillTypeName);
                   _ISkillTypeFacade.UpdateSkillType(skillType);
                   _ItsView.ActionSuccess = true;
               }
               catch (Exception ex)
               {
                   _ItsView.Message = "<span class='fontred'>" + ex.Message + "</span>";
               }
           }
           
       }
       public bool Vaildation()
       {
           if (string.IsNullOrEmpty(_ItsView.SkillTypeName))
           {
               _ItsView.NameMsg = "类型名称不能为空";
               return false;
           }
           _ItsView.NameMsg = string.Empty;
           return true;
       }

        private bool VaildateId(string id, out int skillTypeId)
        {
            if (!int.TryParse(id, out skillTypeId))
            {
                _ItsView.Message = "删除的记录ID不正确";
                return false;
            }
            return true;
        }

       public ISkillTypeFacade AddSkillType
       {
           get { return _ISkillTypeFacade; }
       }
    }
}
