//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CompanyRegulationsPresenter.cs
// 创建者: SYY
// 创建日期: 2009-01-04
// 概述: 设置公司规章制度
// ----------------------------------------------------------------

using System;
using SEP.Model.CompanyRegulations;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.ICompanyRegulations;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.Presenter.CompanyRegulations
{
    public class CompanyRegulationsPresenter : BasePresenter
    {
        private readonly IEditCompanyRegulationView _View;

        public CompanyRegulationsPresenter(IEditCompanyRegulationView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _View.InitView += Init;

            _View.ChangedType += ChangedType;

            _View.AddAppendix += btnAddAppendix;
            _View.DeleteAppendix += btnDeleteAppendix;

            _View.btnOKClicked += btnOKClick;
        }

        private void ChangedType(object sender, EventArgs e)
        {
            GetCompanyRegulations(_View.SelectedReguType);
        }

        private void GetCompanyRegulations(int SelectedReguType)
        {
            CompanyRegulation companyRegulations = BllInstance.CompanyRegulationBllInstance.GetCompanyRegulationsByType((ReguType)SelectedReguType, LoginUser);

            _View.ComanyReguId = companyRegulations.CompanyRegulationsID;
            _View.Title = companyRegulations.Title;
            _View.Content = companyRegulations.Content;
            _View.CompanyReguAppendixList = companyRegulations.AppendixList;
        }

        private bool Valid()
        {
            _View.CompanyRegulationsTitleErrorMessage = "";

            if (string.IsNullOrEmpty(_View.Title) || _View.Title.Trim().Length == 0)
            {
                _View.CompanyRegulationsTitleErrorMessage = "公司规章制度不能为空";
                return false;
            }
            if (_View.Title.Trim().Length > 100)
            {
                _View.CompanyRegulationsTitleErrorMessage = "公司规章制度标题不能超过100个字符";
                return false;
            }
            return true;
        }

        private void Init(object sender, EventArgs e)
        {
            _View.ReguTypeDataSrc = CompanyRegulation.GetAllReguType();

            GetCompanyRegulations(_View.SelectedReguType);
        }

        private void btnOKClick(object sender, EventArgs e)
        {
            if(!Valid())
                return;

            try
            {
                CompanyRegulation companyRegulations = new CompanyRegulation(
                    _View.ComanyReguId, 
                    (ReguType)_View.SelectedReguType, 
                    _View.Title, 
                    _View.Content);

                companyRegulations.AppendixList = _View.CompanyReguAppendixList;
                BllInstance.CompanyRegulationBllInstance.SaveCompanyRegulations(companyRegulations, LoginUser);
                _View.ErrorMessageFromCompanyRegulations = "保存成功！";
            }
            catch (ApplicationException ex)
            {
                _View.ErrorMessageFromCompanyRegulations = //"&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;" + 
                    ex.Message;
            }
        }

        private void btnAddAppendix(object sender, EventArgs e)
        {
            _View.CompanyReguAppendixList.Add((CompanyReguAppendix)sender);
        }

        private void btnDeleteAppendix(object sender, EventArgs e)
        {
            if(_View.CompanyReguAppendixList == null || _View.CompanyReguAppendixList.Count == 0)
                return;

            
            //string file = _View.CompanyReguAppendixList[_View.SelectedCompanyReguAppendixId].Directory;
            //if (File.Exists(file))
            //{
            //    File.Delete(file);
            //}

            _View.CompanyReguAppendixList.RemoveAt(_View.SelectedCompanyReguAppendixId);

            //for (int i = _View.CompanyReguAppendixList.Count - 1; i >= 0; i--)
            //{
            //    if (_View.CompanyReguAppendixList[i].Directory == ((CompanyReguAppendix) sender).Directory)
            //        _View.CompanyReguAppendixList.RemoveAt(i);
            //}
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
