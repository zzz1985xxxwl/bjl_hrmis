//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: AddSkillTypePresenter.cs
// ������: ����
// ��������: 2008-10-07
// ����: ������������С�����Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter;


namespace SEP.HRMIS.Presenter.Parameter.SkillType
{
   public class AddSkillTypePresenter
    {
        private readonly ISkillTypeView _ItsView;
       private ISkillTypeFacade _ISkillTypeFacade = InstanceFactory.CreateSkillTypeFacade();

       public Model.SkillType _ItsModel;

        public AddSkillTypePresenter(ISkillTypeView itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += AddEvent;
        }

       public void InitView(bool isPagePostBack)
        {
            _ItsView.Message = string.Empty;
            
            if (!isPagePostBack)
            {
                _ItsView.SkillTypeID = string.Empty;
                _ItsView.SkillTypeName = string.Empty;
                _ItsView.NameMsg = string.Empty;
                _ItsView.OperationTitle = "������������";
                _ItsView.OperationType = "Add";
                
            }
            
        }

       public void AddEvent()
       {
           if (Vaildation())
           {
               try
               {
                   Model.SkillType skillType = new Model.SkillType(0, _ItsView.SkillTypeName);
                   _ISkillTypeFacade.AddSkillType(skillType);
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
               _ItsView.NameMsg = "�������Ʋ���Ϊ��";
               return false;
           }
           _ItsView.NameMsg = string.Empty;
           return true;
       }

       public ISkillTypeFacade AddSkillType
       {
           get { return _ISkillTypeFacade; }
       }
    }
}
