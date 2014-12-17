//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractTypeList.aspx.cs
// 创建者: 顾艳娟
// 创建日期: 2008-10-08
// 概述: 查询合同类型
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.Parameter.ContractTypePresenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages
{
    public partial class ContractTypeList : BasePage
    {
         protected void Page_Load(object sender, EventArgs e)
         {
             if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A101))
             {
                 throw new ApplicationException("没有权限访问");
             }

             ContractTypePresenter thePresenter = new ContractTypePresenter(ContractTypeInfoView1);
             thePresenter.InitView(Page.IsPostBack);
         }
    }
}


#region
    //public partial class ContractTypeList : Page
    //{
    //    ContractTypeAddPresenter ContractTypeAddPresenter;
    //    ContractTypeUpdatePresenter ContractTypeUpdatePresenter;
    //    ContractTypeDeletePresenter ContractTypeDeletePresenter;
    //    ContractTypeDetailPresenter ContractTypeDetailPresenter;

    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        //PowerUser.UserHasPower(PowerUser._ContractTypeList);
    //        ContractTypeListPresenter presenter = new ContractTypeListPresenter(ContractTypeListView1);
    //        presenter.InitContractTypeList(IsPostBack);
    //        ContractTypeListView1.btnSearchClick += presenter.ExecuteEvent;
    //        ContractTypeListView1._ShowItemWindowForAdd = ShowWindowForAdd;
    //        ContractTypeListView1._ShowItemWindowForModify = ShowWindowForModify;
    //        ContractTypeListView1._ShowItemWindowForDelete = ShowWindowForDelete;
    //        ContractTypeListView1._ShowItemWindowForDetail = ShowWindowForDetail;

    //        ContractTypeAddPresenter = new ContractTypeAddPresenter(ContractTypeView1);
    //        ContractTypeUpdatePresenter = new ContractTypeUpdatePresenter(ContractTypeView1);
    //        ContractTypeDeletePresenter = new ContractTypeDeletePresenter(ContractTypeView1);
    //        ContractTypeDetailPresenter = new ContractTypeDetailPresenter(ContractTypeView1);
    //        ContractTypeView1._UpdateListWindow = UpdateWindow;
    //        ContractTypeView1.btnCancelServerClick += HideWindow;

    //        switch (Operation.Value)
    //        {
    //            case "add":
    //                ContractTypeView1.btnOKClick += ContractTypeAddPresenter.ExecuteEvent;
    //                break;
    //            case "update":
    //                ContractTypeView1.btnOKClick += ContractTypeUpdatePresenter.ExecuteEvent;
    //                break;
    //            case "delete":
    //                ContractTypeView1.btnOKClick += ContractTypeDeletePresenter.ExecuteEvent;
    //                break;
    //            case "detail":
    //                ContractTypeView1._UpdateListWindow = None;
    //                ContractTypeView1.btnOKClick += HideWindow;
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //    private static void None()
    //    {
    //    }
    //    private void HideWindow(object sender, EventArgs e)
    //    {
    //        mpeContractType.Hide();
    //    }
    //    private void ShowWindowForAdd()
    //    {
    //        Operation.Value = "add";
    //        ContractTypeAddPresenter.InitView();
    //        mpeContractType.Show();
    //    }
    //    private void ShowWindowForModify(string id)
    //    {
    //        Operation.Value = "update";
    //        ContractTypeUpdatePresenter.InitContractTypeUpdate(IsPostBack,id);
    //        UpdatePanel1.Update();
    //        mpeContractType.Show();
    //    }
    //    private void ShowWindowForDelete(string id)
    //    {
    //        Operation.Value = "delete";
    //        ContractTypeDeletePresenter.InitContractTypeDelete(IsPostBack,id);
    //        UpdatePanel1.Update();
    //        mpeContractType.Show();
    //    }
    //    private void ShowWindowForDetail(string id)
    //    {
    //        Operation.Value = "detail";
    //        ContractTypeDetailPresenter.InitContractTypeDetail(IsPostBack,id);
    //        UpdatePanel1.Update();
    //        mpeContractType.Show();
    //    }
    //    private void UpdateWindow()
    //    {
    //        if (string.IsNullOrEmpty(ContractTypeView1.ValidateName) &&
    //            string.IsNullOrEmpty(ContractTypeView1.ValidateID) &&
    //            string.IsNullOrEmpty(ContractTypeView1.ResultMessage))
    //        {
    //            ContractTypeListView1.Search();
    //            UpdatePanel1.Update();
    //            mpeContractType.Hide();
    //        }
    //        else
    //        {
    //            mpeContractType.Show();
    //        }
    //    }
    //}
#endregion

