//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IAddFamilyView.cs
// 创建者: 张燕
// 创建日期: 2008-09-01
// 概述: AddFamilyVieww需要实现的接口
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IAddFamilyView
    {
        string TitleFamily { get; set;}

        string FamilyAddress { get; set;}
        string FamilyAddressMessage { get; set;}
        string FamilyPhone { get; set;}
        string PostCode { get; set;}
        string PostCodeMessage { get; set;}
        string RPRAddress { get; set;}
        string RPRAddressMessage{ get; set;}  
        string PRPPostCode{ get; set;}
        string PRPPostCodeMessage{ get; set;}
        string PRPStreet { get; set;}
        string PRPArea { get; set;}
        string PRPAreaMessage{ get; set;}
        string RecordPlace{ get; set;}
        string EmergencyContacts{ get; set;}
        string ChildName1 { get; set;}
        string ChildBirthday1 { get; set;}
        string ChildName2 { get; set;}
        string ChildBirthday2{ get; set;}
        List<FamilyMember> FamilyMembers { get; set;}
        string FamilyMemberMessage { get; set;}

        event CommandEventHandler btnDeleteClick;

        event CommandEventHandler btnUpdateClick;


        bool SetButtoninvisible { set; }

        //bool SetIDReadonly { set;}
    }
}





