using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;
using SEPPerformance = SEP.Performance;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
	/// <summary>
	/// $codebehindclassname$ 的摘要说明
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class SetEmployeeSalaryHandler : IHttpHandler, IRequiresSessionState
	{
		private readonly IEmployeeAccountSetFacade _IEmployeeAccountSetFacade =
			InstanceFactory.CreateEmployeeAccountSetFacade();

		private readonly IAccountSetFacade _IAccountSetFacade =
			InstanceFactory.CreateAccountSetFacade();

		private HttpContext _Context;
		private string _ResponseString;
		private Account _LoginUser;

		public void ProcessRequest(HttpContext context)
		{
			_Context = context;
			_LoginUser = context.Session[SessionKeys.LOGININFO] as Account;
			_ResponseString = "{}";
			context.Response.ContentType = "text/plain";

			if (_Context.Request.Params["type"] != null)
			{
				switch (_Context.Request.Params["type"])
				{
					case "Search":
						Search();
						break;
					case "Initial": //发放
						Initial();
						break;
					case "Close":
						Close();
						break;
					case "TempSave": //暂存
						TempSave();
						break;
					case "Delete":
						Delete();
						break;
					case "Add":
						Add();
						break;
					case "BindddlAccountSetItem":
						BindddlAccountSetItem();
						break;
					case "Export":
						Export();
						break;
					case "Import":
						Import();
						break;
					case "Reopen":
						Reopen();
						break;
					case "Mail":
						Mail();
						break;
					default:
						break;
				}
			}
			context.Response.Write(_ResponseString);
			context.Response.End();
		}

		private void BindddlAccountSetItem()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			List<DropDownListSource> model = new List<DropDownListSource>();
			string errormessage = string.Empty;
			AccountSet accountSet =
				_IAccountSetFacade.GetWholeAccountSetByPKID(Convert.ToInt32(_Context.Request.Params["accountSetID"]));
			if (accountSet == null || accountSet.Items == null || accountSet.Items.Count == 0)
			{
				errormessage = "没有可批量修改的帐套项";
			}
			else
			{
				foreach (AccountSetItem accountSetItem in accountSet.Items)
				{
					if (accountSetItem.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.FixedField.Id
						|| accountSetItem.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.FloatField.Id)
					{
						DropDownListSource s = new DropDownListSource();
						s.value = accountSetItem.AccountSetItemID;
						s.Text = accountSetItem.AccountSetPara.AccountSetParaName;
						model.Add(s);
					}
				}
			}
			if (!string.IsNullOrEmpty(errormessage) || model.Count < 1)
			{
				errors.Add(new Performance.Error("lblMessage", "没有可批量修改的帐套项"));
			}
			_ResponseString = FomartSearchString(model, errors);
		}


		private void Delete()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			List<UpdateItemModel> successItem = new List<UpdateItemModel>();
			List<UpdateItemModel> errorItem = new List<UpdateItemModel>();
			string errormessage = string.Empty;
			List<SalaryModel> salaryModel =
				JsonConvert.DeserializeObject<List<SalaryModel>>(_Context.Request.Params["values"]);
			EmployeeSalaryHistory theSalaryTobeUpdate;
			foreach (SalaryModel model in salaryModel)
			{
				try
				{
					theSalaryTobeUpdate = _IEmployeeAccountSetFacade.GetEmployeeSalaryHistoryByPKID(model.PKID);
					theSalaryTobeUpdate.VersionNumber = model.VersionNumber;

					theSalaryTobeUpdate.EmployeeAccountSet.Items = null;
					theSalaryTobeUpdate.EmployeeAccountSet.AccountSetID = 0;
					_IEmployeeAccountSetFacade.TemporarySaveEmployeeAccountSetFacadeFacade(model.PKID, model.EmployeeID,
																						   Convert.ToDateTime(
																							   _Context.Request.Params[
																								   "SalaryTime"]),
																						   theSalaryTobeUpdate.
																							   EmployeeAccountSet,
																						   _LoginUser.Name,
																						   model.Remark ?? "",
																						   theSalaryTobeUpdate.
																							   VersionNumber);
					successItem.Add(
						new UpdateItemModel(model.PKID,
											_IEmployeeAccountSetFacade.GetEmployeeSalaryHistoryByPKID(model.PKID).
												VersionNumber));
				}
				catch (Exception ex)
				{
					errormessage = ex.Message;
					errorItem.Add(new UpdateItemModel(model.PKID, model.VersionNumber));
				}
			}
			if (!string.IsNullOrEmpty(errormessage))
			{
				errors.Add(new Performance.Error("lblMessage", errormessage));
			}
			_ResponseString = FomartErrorAndSuccessString(successItem, errorItem, errors);
		}

		private void TempSave()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			List<UpdateItemModel> successItem = new List<UpdateItemModel>();
			List<UpdateItemModel> errorItem = new List<UpdateItemModel>();
			string errormessage = string.Empty;
			List<SalaryModel> salaryModel =
				JsonConvert.DeserializeObject<List<SalaryModel>>(_Context.Request.Params["values"]);
			EmployeeSalaryHistory theSalaryTobeUpdate;
			foreach (SalaryModel model in salaryModel)
			{
				try
				{
					theSalaryTobeUpdate = _IEmployeeAccountSetFacade.GetEmployeeSalaryHistoryByPKID(model.PKID);
					theSalaryTobeUpdate.VersionNumber = model.VersionNumber;

					//获取帐号信息中需更新的项
					if (theSalaryTobeUpdate.EmployeeAccountSet.Items != null)
					{
						foreach (AccountSetItem item in theSalaryTobeUpdate.EmployeeAccountSet.Items)
						{
							if (item.AccountSetPara.FieldAttribute != null)
							{
								item.CalculateResult = GetValue(model.SalaryValueList, item.AccountSetItemID);
							}
						}
					}
					_IEmployeeAccountSetFacade.TemporarySaveEmployeeAccountSetFacadeFacade(model.PKID, model.EmployeeID,
																						   Convert.ToDateTime(
																							   _Context.Request.Params[
																								   "SalaryTime"]),
																						   theSalaryTobeUpdate.
																							   EmployeeAccountSet,
																						   _LoginUser.Name,
																						   model.Remark ?? "",
																						   theSalaryTobeUpdate.
																							   VersionNumber);
					EmployeeSalaryHistory s = _IEmployeeAccountSetFacade.GetEmployeeSalaryHistoryByPKID(model.PKID);
					UpdateItemModel m = new UpdateItemModel(model.PKID, s.VersionNumber);
					foreach (AccountSetItem item in s.EmployeeAccountSet.Items)
					{
						SalaryValue sv = new SalaryValue();
						sv.ItemID = item.AccountSetItemID;
						sv.ItemValue = item.CalculateResult.ToString("G0");
						m.SalaryValueList.Add(sv);
					}
					successItem.Add(m);
				}
				catch (Exception ex)
				{
					errormessage = ex.Message;
					errorItem.Add(new UpdateItemModel(model.PKID, model.VersionNumber));
				}
			}
			if (!string.IsNullOrEmpty(errormessage))
			{
				errors.Add(new Performance.Error("lblMessage", errormessage));
			}
			_ResponseString = FomartErrorAndSuccessString(successItem, errorItem, errors);
		}

		private void Add()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			List<UpdateItemModel> successItem = new List<UpdateItemModel>();
			List<UpdateItemModel> errorItem = new List<UpdateItemModel>();
			string errormessage = string.Empty;
			List<SalaryModel> salaryModel =
				JsonConvert.DeserializeObject<List<SalaryModel>>(_Context.Request.Params["values"]);
			EmployeeSalaryHistory theSalaryTobeUpdate;
			foreach (SalaryModel model in salaryModel)
			{
				try
				{
					theSalaryTobeUpdate = _IEmployeeAccountSetFacade.GetEmployeeSalaryHistoryByPKID(model.PKID);
					theSalaryTobeUpdate.VersionNumber = model.VersionNumber;

					EmployeeSalary theAccountSet =
						_IEmployeeAccountSetFacade.GetEmployeeAccountSetByEmployeeID(model.EmployeeID);
					if (theAccountSet != null)
					{
					}
					else
					{
						theAccountSet = new EmployeeSalary(model.EmployeeID);
						theAccountSet.AccountSet = new AccountSet(0, string.Empty);
					}

					_IEmployeeAccountSetFacade.TemporarySaveEmployeeAccountSetFacadeFacade(model.PKID, model.EmployeeID,
																						   Convert.ToDateTime(
																							   _Context.Request.Params[
																								   "SalaryTime"]),
																						   theAccountSet.AccountSet,
																						   _LoginUser.Name,
																						   model.Remark ?? "",
																						   theSalaryTobeUpdate.
																							   VersionNumber);
					UpdateItemModel m = new UpdateItemModel(model.PKID,
															_IEmployeeAccountSetFacade.GetEmployeeSalaryHistoryByPKID(
																model.PKID).
																VersionNumber);
					if (theAccountSet != null && theAccountSet.AccountSet != null && theAccountSet.AccountSet.Items != null)
					{
						foreach (AccountSetItem item in theAccountSet.AccountSet.Items)
						{
							SalaryValue sv = new SalaryValue();
							sv.ItemID = item.AccountSetItemID;
							sv.ItemValue = item.CalculateResult.ToString("G0");
							m.SalaryValueList.Add(sv);
						}
						successItem.Add(m);
					}
					else
					{
						errormessage = "没有帐套";
						errorItem.Add(new UpdateItemModel(model.PKID, model.VersionNumber));
					}
				}
				catch (Exception ex)
				{
					errormessage = ex.Message;
					errorItem.Add(new UpdateItemModel(model.PKID, model.VersionNumber));
				}
			}
			if (!string.IsNullOrEmpty(errormessage))
			{
				errors.Add(new Performance.Error("lblMessage", errormessage));
			}
			_ResponseString = FomartErrorAndSuccessString(successItem, errorItem, errors);
		}

		private static decimal GetValue(IEnumerable<SalaryValue> values, int itemID)
		{
			foreach (SalaryValue value in values)
			{
				if (value.ItemID == itemID)
				{
					return Convert.ToDecimal(value.ItemValue);
				}
			}
			return 0;
		}

		private void Initial()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			try
			{
				_IEmployeeAccountSetFacade.InitialEmployeeSalaryFacade(
					Convert.ToDateTime(_Context.Request.Params["SalaryTime"]), _LoginUser.Name,
					string.Empty, Convert.ToInt32(_Context.Request.Params["CompanyId"]), Convert.ToInt32(_Context.Request.Params["DepartmentId"]));
			}
			catch (Exception ex)
			{
				errors.Add(new Performance.Error("lblMessage", ex.Message));
			}

			_ResponseString = FomartErrorString(errors);
		}

		private void Search()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			List<SalaryModel> salaryModelList = new List<SalaryModel>();
			string status = "";
			try
			{
				List<EmployeeSalary> employeeSalaryList =
					_IEmployeeAccountSetFacade.GetEmployeeSalaryByConditionFacade(
						_Context.Request.Params["EmployeeName"].Trim(),
						Convert.ToDateTime(_Context.Request.Params["SalaryTime"]),
						Convert.ToInt32(_Context.Request.Params["DepartmentId"]),
						Convert.ToInt32(_Context.Request.Params["PositionId"]),
						Convert.ToInt32(_Context.Request.Params["AccountSetId"]),
						EmployeeTypeUtility.GetEmployeeTypeByID(Convert.ToInt32(_Context.Request.Params["EmployeeType"])),
						Convert.ToInt32(_Context.Request.Params["CompanyId"]));
				employeeSalaryList =
					HrmisUtility.RemoteUnAuthEmployeeSalary(employeeSalaryList, AuthType.HRMIS, _LoginUser,
															HrmisPowers.A606);


				if (employeeSalaryList.Count == 0)
				{
					status = "noRecord";

				}
				//工资是不是已封涨
				else if (employeeSalaryList[0].EmployeeSalaryHistoryList[0].EmployeeSalaryStatus.Id ==
					 EmployeeSalaryStatusEnum.AccountClosed.Id)
				{
					status = "closed";
				}
				//工资是不是解封
				else if (employeeSalaryList[0].EmployeeSalaryHistoryList[0].EmployeeSalaryStatus.Id ==
						 EmployeeSalaryStatusEnum.AccountReopened.Id)
				{
					status = "reopen";
				}

				List<string> allRows = new List<string>();
				//添加所有员工的帐套
				for (int i = 0; i < employeeSalaryList.Count; i++)
				{
					//判断数据源是否为空
					if ((employeeSalaryList[i].EmployeeSalaryHistoryList == null ||
						 employeeSalaryList[i].EmployeeSalaryHistoryList.Count == 0) ||
						employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet == null) continue;
					if (employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items != null)
					{
						foreach (
							AccountSetItem item in
								employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items)
						{
							string columnName = item.AccountSetPara.AccountSetParaName;
							//判断帐套中的数据类型是否为空
							if (item.AccountSetPara.FieldAttribute == null) continue;
							//对于绑定项及计算公式 设置为不可修改
							if (!allRows.Contains(columnName))
							{
								allRows.Add(columnName);
							}
						}
					}
				}

				for (int i = 0; i < employeeSalaryList.Count; i++)
				{
					SalaryModel model = new SalaryModel();

					model.EmployeeID = employeeSalaryList[i].Employee.Account.Id;
					model.EmployeeName = employeeSalaryList[i].Employee.Account.Name;
					if (employeeSalaryList[i].EmployeeSalaryHistoryList != null ||
						employeeSalaryList[i].EmployeeSalaryHistoryList.Count != 0 ||
						employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet != null)
					{
						model.PKID = employeeSalaryList[i].EmployeeSalaryHistoryList[0].HistoryId;
						model.AccountSetName =
							employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.AccountSetName;
						model.AccountSetID =
							employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.AccountSetID;
						foreach (string s in allRows)
						{
							model.SalaryValueList.Add(new SalaryValue(s));
						}
						if (employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items != null)
						{
							for (int j = 0;
								 j < employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Count;
								 j++)
							{
								if (
									employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[j].
										AccountSetPara.FieldAttribute != null)
								{
									SalaryValue sv =
										FindSalaryAccountSet(
											employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
												j].
												AccountSetPara.AccountSetParaName, model.SalaryValueList);

									if (sv != null)
									{
										//对于绑定项及计算公式 设置为不可修改
										if (
											employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
												j].
												AccountSetPara.FieldAttribute.Id.Equals(FieldAttributeEnum.BindField.Id) ||
											employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
												j].
												AccountSetPara.FieldAttribute.Id.Equals(
												FieldAttributeEnum.CalculateField.Id))
										{
											sv.Editable = false;
										} //如果已封帐,帐套中所有项也不可调
										else if (
											employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeSalaryStatus.Id ==
											EmployeeSalaryStatusEnum.AccountClosed.Id)
										{
											sv.Editable = false;
										}
										sv.ItemID =
											employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
												j].AccountSetItemID;
										sv.ItemValue =
											employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
												j].
												CalculateResult.ToString("G0");
									}
								}
							}
						}
					}
					model.Remark = employeeSalaryList[i].EmployeeSalaryHistoryList[0].Description;
					model.VersionNumber = employeeSalaryList[i].EmployeeSalaryHistoryList[0].VersionNumber;
					//model = employeeSalarys[i].EmployeeSalaryHistoryList[0].RowStatus;
					salaryModelList.Add(model);
				}
			}
			catch (Exception ex)
			{
				errors.Add(new Performance.Error("lblMessage", ex.Message));
			}

			_ResponseString = FomartSearchStringWithStatus(salaryModelList, errors, status);
		}

		private List<SalaryExcelModel> SearchEvent()
		{
			List<SalaryExcelModel> salaryModelList = new List<SalaryExcelModel>();
			List<EmployeeSalary> employeeSalaryList =
				_IEmployeeAccountSetFacade.GetEmployeeSalaryByConditionFacade(
					_Context.Request.Params["EmployeeName"].Trim(),
					Convert.ToDateTime(_Context.Request.Params["SalaryTime"]),
					Convert.ToInt32(_Context.Request.Params["DepartmentId"]),
					Convert.ToInt32(_Context.Request.Params["PositionId"]),
					Convert.ToInt32(_Context.Request.Params["AccountSetId"]),
					EmployeeTypeUtility.GetEmployeeTypeByID(Convert.ToInt32(_Context.Request.Params["EmployeeType"])),
					Convert.ToInt32(_Context.Request.Params["CompanyId"]));
			employeeSalaryList =
				HrmisUtility.RemoteUnAuthEmployeeSalary(employeeSalaryList, AuthType.HRMIS, _LoginUser,
														HrmisPowers.A606);
			List<string> allRows = new List<string>();
			//添加所有员工的帐套
			for (int i = 0; i < employeeSalaryList.Count; i++)
			{
				//判断数据源是否为空
				if ((employeeSalaryList[i].EmployeeSalaryHistoryList == null ||
					 employeeSalaryList[i].EmployeeSalaryHistoryList.Count == 0) ||
					employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet == null) continue;
				if (employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items != null)
				{
					foreach (
						AccountSetItem item in
							employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items)
					{
						string columnName = item.AccountSetPara.AccountSetParaName;
						//判断帐套中的数据类型是否为空
						if (item.AccountSetPara.FieldAttribute == null) continue;
						//对于绑定项及计算公式 设置为不可修改
						if (!allRows.Contains(columnName))
						{
							allRows.Add(columnName);
						}
					}
				}
			}

			for (int i = 0; i < employeeSalaryList.Count; i++)
			{
				SalaryExcelModel model = new SalaryExcelModel();

				model.EmployeeID = employeeSalaryList[i].Employee.Account.Id;
				model.EmployeeName = employeeSalaryList[i].Employee.Account.Name;
				if (employeeSalaryList[i].EmployeeSalaryHistoryList != null ||
					employeeSalaryList[i].EmployeeSalaryHistoryList.Count != 0 ||
					employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet != null)
				{
					model.PKID = employeeSalaryList[i].EmployeeSalaryHistoryList[0].HistoryId;
					model.AccountSetName =
						employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.AccountSetName;
					model.AccountSetID =
						employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.AccountSetID;
					if (employeeSalaryList[i].Employee.EmployeeDetails != null)
					{
						if (employeeSalaryList[i].Employee.EmployeeDetails.Work != null)
						{
							model.WorkPlace = employeeSalaryList[i].Employee.EmployeeDetails.Work.WorkPlace;

							if (employeeSalaryList[i].Employee.EmployeeDetails.Work.Principalship != null)
							{
								model.PrincipalshipName =
									employeeSalaryList[i].Employee.EmployeeDetails.Work.Principalship.Name;
							}
							model.ComeDate =
								employeeSalaryList[i].Employee.EmployeeDetails.Work.ComeDate.ToShortDateString();

							model.SalaryCardNo = "'" + employeeSalaryList[i].Employee.EmployeeDetails.Work.SalaryCardNo;
						}
						if (employeeSalaryList[i].Employee.EmployeeDetails.ProbationTime != DateTime.MinValue)
						{
							model.ProbationTime =
								employeeSalaryList[i].Employee.EmployeeDetails.ProbationTime.ToShortDateString();
						}
					}
					if (employeeSalaryList[i].Employee.Account.Dept != null)
					{
						model.Dept = employeeSalaryList[i].Employee.Account.Dept.Name;
					}
					if (employeeSalaryList[i].Employee.Account.Position != null)
					{
						model.Position = employeeSalaryList[i].Employee.Account.Position.Name;
						if (employeeSalaryList[i].Employee.Account.Position.Grade != null)
						{
							model.Grade = employeeSalaryList[i].Employee.Account.Position.Grade.Name;
						}
					}

					foreach (string s in allRows)
					{
						model.SalaryValueList.Add(new SalaryValue(s));
					}
					if (employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items != null)
					{
						for (int j = 0;
							 j < employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items.Count;
							 j++)
						{
							if (
								employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[j].
									AccountSetPara.FieldAttribute != null)
							{
								SalaryValue sv =
									FindSalaryAccountSet(
										employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
											j].
											AccountSetPara.AccountSetParaName, model.SalaryValueList);

								if (sv != null)
								{
									//对于绑定项及计算公式 设置为不可修改
									if (
										employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
											j].
											AccountSetPara.FieldAttribute.Id.Equals(FieldAttributeEnum.BindField.Id) ||
										employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
											j].
											AccountSetPara.FieldAttribute.Id.Equals(
											FieldAttributeEnum.CalculateField.Id))
									{
										sv.Editable = false;
									} //如果已封帐,帐套中所有项也不可调
									else if (
										employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeSalaryStatus.Id ==
										EmployeeSalaryStatusEnum.AccountClosed.Id)
									{
										sv.Editable = false;
									}
									sv.ItemID =
										employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
											j].AccountSetItemID;
									sv.ItemValue =
										employeeSalaryList[i].EmployeeSalaryHistoryList[0].EmployeeAccountSet.Items[
											j].
											CalculateResult.ToString("G0");
								}
							}
						}
					}
				}
				model.Remark = employeeSalaryList[i].EmployeeSalaryHistoryList[0].Description;
				model.VersionNumber = employeeSalaryList[i].EmployeeSalaryHistoryList[0].VersionNumber;
				//model = employeeSalarys[i].EmployeeSalaryHistoryList[0].RowStatus;
				salaryModelList.Add(model);
			}
			return salaryModelList;
		}


		private void Close()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			try
			{
				string errorname =
					_IEmployeeAccountSetFacade.CloseEmployeeSalaryFacade(
						Convert.ToDateTime(_Context.Request.Params["SalaryTime"]),
						_LoginUser.Name,
						string.Empty, Convert.ToInt32(_Context.Request.Params["CompanyId"]), Convert.ToInt32(_Context.Request.Params["DepartmentId"]),
						Convert.ToBoolean(_Context.Request.Params["IsSendEmail"]));
				if (!string.IsNullOrEmpty(errorname))
				{
					errors.Add(new Performance.Error("lblMessage", "<span class='fontred'>以下员工没有收到工资邮件：" + errorname +
																   "。<br />失败原因可能为：1. 邮件系统未启动。 2. 员工没有生成USBKEY。</span>"));
				}
			}
			catch (Exception ex)
			{
				errors.Add(new Performance.Error("lblMessage", ex.Message));
			}
			_ResponseString = FomartErrorString(errors);
		}

		private void Reopen()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			try
			{
				_IEmployeeAccountSetFacade.ReopenEmployeeSalaryFacade(Convert.ToDateTime(_Context.Request.Params["SalaryTime"]),
						_LoginUser.Name,
						string.Empty, Convert.ToInt32(_Context.Request.Params["CompanyId"]), Convert.ToInt32(_Context.Request.Params["DepartmentId"]));
			}
			catch (Exception ex)
			{
				errors.Add(new Performance.Error("lblMessage", ex.Message));
			}
			_ResponseString = FomartErrorString(errors);
		}
		private void Mail()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			try
			{
				string mailFailName = string.Empty;
				DateTime st = Convert.ToDateTime(_Context.Request.Params["SalaryTime"]);
				List<int> employeeIDs = JsonConvert.DeserializeObject<List<int>>(_Context.Request.Params["EmployeeIDs"]);
				for (int i = 0; i < employeeIDs.Count; i++)
				{
					string sendresultname = _IEmployeeAccountSetFacade.SendEmployeeEmail(employeeIDs[i], st);
					if (!string.IsNullOrEmpty(sendresultname))
					{
						if (!string.IsNullOrEmpty(mailFailName))
						{
							mailFailName += "，";
						}
						mailFailName += sendresultname;
					}
				}
				if (!string.IsNullOrEmpty(mailFailName))
				{
					errors.Add(new Performance.Error("lblMessage", "<span class='fontred'>以下员工没有受到工资邮件：" + mailFailName +
									  "。<br />失败原因可能为：1. 邮件系统未启动。 2. 员工没有生成USBKEY。</span>"));
				}
			}
			catch (Exception ex)
			{
				errors.Add(new Performance.Error("lblMessage", ex.Message));
			}
			_ResponseString = FomartErrorString(errors);
		}

		#region 导出

		/// <summary>
		/// 导出事件
		/// </summary>
		private void Export()
		{
			string NowDate = DateTime.Now.ToString();
			NowDate = NowDate.Replace(" ", "");
			NowDate = NowDate.Replace(":", "");
			NowDate = NowDate.Replace("-", "");
			NowDate = NowDate.Replace("/", "");
			string filename = "员工薪资表" + NowDate + ".xls";
			Export3(filename);
		}

		private void Export2(string FileName)
		{
			var sb = new StringBuilder();
			List<SalaryExcelModel> models = SearchEvent();

			////生成表头
			List<String> heads = new List<String>() { "员工姓名", "帐套名称", "工作地点", "部门", "职位", "职务", "职级", "入职时间", "试用期到期日", "工资卡号" };
			if (models.Count > 0)
			{
				foreach (SalaryValue sv in models[0].SalaryValueList)
				{
					heads.Add(sv.ItemName);
				}
			}
			heads.Add("备注");
			sb.Append(string.Join(",", heads));
			sb.Append(Environment.NewLine);

			//生成内容
			for (int i = 0; i < models.Count; i++)
			{
				List<String> body = new List<String>();
				body.Add(models[i].EmployeeName);
				body.Add(models[i].AccountSetName);
				body.Add(models[i].WorkPlace);
				body.Add(models[i].Dept);
				body.Add(models[i].Position);
				body.Add(models[i].PrincipalshipName);
				body.Add(models[i].Grade);
				body.Add(models[i].ComeDate);
				body.Add(models[i].ProbationTime);
				body.Add(models[i].SalaryCardNo);
				for (int j = 0; j < models[i].SalaryValueList.Count; j++)
				{
					body.Add(models[i].SalaryValueList[j].ItemValue);
				}
				body.Add(models[i].Remark);
				sb.Append(string.Join(",", body));
				sb.Append(Environment.NewLine);
			}

			_Context.Response.Clear();
			_Context.Response.Charset = "GB2312";
			_Context.Response.ContentEncoding = UnicodeEncoding.GetEncoding("GB2312");
			_Context.Response.AddHeader("Content-Disposition",
										"attachment; filename=员工薪资表.csv");
			_Context.Response.AddHeader("Content-Length", sb.Length.ToString());
			_Context.Response.ContentType = "text/csv";
			_Context.Response.Write(sb);
			_Context.Response.End();
		}

		private void Export3(string filename)
		{
			var sb = new StringBuilder();
			List<SalaryExcelModel> models = SearchEvent();
			IWorkbook workbook = new HSSFWorkbook();
			var sheet = workbook.CreateSheet("Sheet1");
			var font = workbook.CreateFont();
			font.FontName = "MS Sans Serif";
			//生成表头
			List<String> heads = new List<String>() { "员工姓名", "帐套名称", "工作地点", "部门", "职位", "职务", "职级", "入职时间", "试用期到期日", "工资卡号" };
			if (models.Count > 0)
			{
				foreach (SalaryValue sv in models[0].SalaryValueList)
				{
					heads.Add(sv.ItemName);
				}
			}
			heads.Add("备注");
			var firstRow = sheet.CreateRow(0);
			for (var i = 0; i < heads.Count; i++)
			{
				var cell = firstRow.CreateCell(i);
				cell.SetCellValue(heads[i]);
				cell.CellStyle.SetFont(font);
			}

			//生成内容
			for (int i = 0; i < models.Count; i++)
			{
				List<String> body = new List<String>();
				body.Add(models[i].EmployeeName);
				body.Add(models[i].AccountSetName);
				body.Add(models[i].WorkPlace);
				body.Add(models[i].Dept);
				body.Add(models[i].Position);
				body.Add(models[i].PrincipalshipName);
				body.Add(models[i].Grade);
				body.Add(models[i].ComeDate);
				body.Add(models[i].ProbationTime);
				body.Add(models[i].SalaryCardNo);
				for (int j = 0; j < models[i].SalaryValueList.Count; j++)
				{
					body.Add(models[i].SalaryValueList[j].ItemValue);
				}
				body.Add(models[i].Remark);
				var row = sheet.CreateRow(i + 1);
				for (int j = 0; j < body.Count; j++)
				{
					var cell = row.CreateCell(j);
					cell.SetCellValue(body[j]);
					cell.CellStyle.SetFont(font);
				}
			}

			var ms = new MemoryStream();
			workbook.Write(ms);
			ms.Position = 0;
			byte[] bytes = ms.GetBuffer();
			_Context.Response.Clear();
			_Context.Response.Charset = "UTF8";
			_Context.Response.ContentEncoding = Encoding.UTF8;
			_Context.Response.AddHeader("Content-Disposition",
										"attachment; filename=" + _Context.Server.UrlEncode(filename));
			//_Context.Response.AddHeader("Content-Length", sb.Length.ToString());
			_Context.Response.ContentType = "application/vnd.ms-excel";
			_Context.Response.BinaryWrite(bytes);
			_Context.Response.End();
		}

		private void Export(string FileName)
		{
			GC.Collect();
			string tempdirectory = ConfigurationManager.AppSettings["EmployeeExportLocation"];
			if (!Directory.Exists(tempdirectory))
			{
				Directory.CreateDirectory(tempdirectory);
			}
			string templocation = tempdirectory + "\\" + FileName;
			Application excel = new Application();
			_Workbook xBk =
				excel.Workbooks.Add(HttpContext.Current.Request.PhysicalApplicationPath +
									@"\Pages\HRMIS\Template\empty2003Excel.xls");
			_Worksheet xSt = (_Worksheet)xBk.ActiveSheet;

			try
			{
				TemplateBuildStringWriter(excel);
				object nothing = Type.Missing;
				object fileFormat = XlFileFormat.xlExcel8;
				object file1 = templocation;
				if (File.Exists(file1.ToString()))
				{
					File.Delete(file1.ToString());
				}
				xBk.SaveAs(file1, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing,
						   nothing, nothing, nothing, nothing);
			}
			finally
			{
				xBk.Close(false, null, null);
				excel.Quit();
				Marshal.ReleaseComObject(xBk);
				Marshal.ReleaseComObject(excel);
				Marshal.ReleaseComObject(xSt);
				GC.Collect();
			}
			FileInfo file = new FileInfo(templocation);
			if (file.Exists)
			{
				_Context.Response.Clear();
				_Context.Response.Charset = "GB2312";
				_Context.Response.ContentEncoding = Encoding.UTF8;
				_Context.Response.AddHeader("Content-Disposition",
											"attachment; filename=" + _Context.Server.UrlEncode(file.Name));
				_Context.Response.AddHeader("Content-Length", file.Length.ToString());
				_Context.Response.ContentType = "application/ms-excel";
				_Context.Response.WriteFile(file.FullName);
				_Context.Response.End();
			}
		}


		/// <summary>
		/// 生成表数据
		/// </summary>
		private void TemplateBuildStringWriter(_Application excel)
		{
			List<SalaryExcelModel> models = SearchEvent();
			//生成表头
			TemplateBuildHead(models, excel);
			//生成内容
			TemplateBuildBody(models, excel);
		}

		/// <summary>
		/// 生成内容
		/// </summary>
		private static void TemplateBuildBody(IList<SalaryExcelModel> modellist, _Application excel)
		{
			for (int i = 0; i < modellist.Count; i++)
			{
				excel.Cells[i + 2, 1] = modellist[i].EmployeeName;
				excel.Cells[i + 2, 2] = modellist[i].AccountSetName;
				excel.Cells[i + 2, 3] = modellist[i].WorkPlace;
				excel.Cells[i + 2, 4] = modellist[i].Dept;
				excel.Cells[i + 2, 5] = modellist[i].Position;
				excel.Cells[i + 2, 6] = modellist[i].PrincipalshipName;
				excel.Cells[i + 2, 7] = modellist[i].Grade;
				excel.Cells[i + 2, 8] = modellist[i].ComeDate;
				excel.Cells[i + 2, 9] = modellist[i].ProbationTime;
				excel.Cells[i + 2, 10] = modellist[i].SalaryCardNo;

				for (int j = 0; j < modellist[i].SalaryValueList.Count; j++)
				{
					excel.Cells[i + 2, j + 11] = modellist[i].SalaryValueList[j].ItemValue;
				}
				excel.Cells[i + 2, modellist[i].SalaryValueList.Count + 11] = modellist[i].Remark;
			}
		}

		/// <summary>
		/// 生成表头
		/// </summary>
		private static void TemplateBuildHead(IList<SalaryExcelModel> modellist, _Application excel)
		{
			int i = 11;
			excel.Cells[1, 1] = "员工姓名";
			excel.Cells[1, 2] = "帐套名称";
			excel.Cells[1, 3] = "工作地点";
			excel.Cells[1, 4] = "部门";
			excel.Cells[1, 5] = "职位";
			excel.Cells[1, 6] = "职务";
			excel.Cells[1, 7] = "职级";
			excel.Cells[1, 8] = "入职时间";
			excel.Cells[1, 9] = "试用期到期日";
			excel.Cells[1, 10] = "工资卡号";
			if (modellist.Count > 0)
			{
				foreach (SalaryValue sv in modellist[0].SalaryValueList)
				{
					excel.Cells[1, i] = sv.ItemName;
					i++;
				}
			}
			excel.Cells[1, i] = "备注";
		}

		#endregion

		#region 导入 by xwl

		private void Import()
		{
			List<Performance.Error> errors = new List<Performance.Error>();
			string uploadFileLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
			if (!Directory.Exists(uploadFileLocation))
			{
				Directory.CreateDirectory(uploadFileLocation);
			}
			HttpPostedFile hpf = _Context.Request.Files[0];
			if (hpf != null)
			{
				string filename = Path.GetFileName(hpf.FileName);
				string fileExt = Path.GetExtension(hpf.FileName);
				string filePath = uploadFileLocation + "\\员工薪资.xls";
				if (Validation(filename, fileExt, errors))
				{
					hpf.SaveAs(filePath);
					try
					{
						_IEmployeeAccountSetFacade.ImportEmployeeSalary(filePath,
																		Convert.ToDateTime(
																			_Context.Request.Params["SalaryTime"]),
																		_LoginUser.Name,
																		Convert.ToInt32(
																			_Context.Request.Params["CompanyId"]));
					}
					catch (Exception ex)
					{
						errors.Add(new Performance.Error("lblMessage", ex.Message));
					}
				}
			}
			_ResponseString = FomartErrorString(errors);
		}

		private static bool Validation(string filename, string fileExt, ICollection<Performance.Error> errors)
		{
			if (!string.IsNullOrEmpty(filename.Trim()))
			{
				if (fileExt == ".xls" || fileExt == ".xlsx")
				{
					return true;
				}
				errors.Add(new Performance.Error("lblMessage", "导入的文件格式错误"));
				return false;
			}
			errors.Add(new Performance.Error("lblMessage", "没有要导入的文件"));
			return false;
		}

		#endregion

		private static string FomartSearchString<T>(List<T> itemList, List<Performance.Error> errorList)
		{
			return
				string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(itemList),
							  JsonConvert.SerializeObject(errorList));
		}
		private static string FomartSearchStringWithStatus<T>(List<T> itemList, List<Performance.Error> errorList, string status)
		{
			return
				string.Format("{{\"itemList\":{0},\"error\":{1},\"status\":\"{2}\"}}", JsonConvert.SerializeObject(itemList),
							  JsonConvert.SerializeObject(errorList), status);
		}

		private static string FomartErrorString(List<Performance.Error> errorList)
		{
			return
				string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errorList));
		}

		private static string FomartErrorAndSuccessString(List<UpdateItemModel> successitem,
														  List<UpdateItemModel> erroritem,
														  List<Performance.Error> errorList)
		{
			return
				string.Format("{{\"successItem\":{0},\"errorItem\":{1},\"error\":{2}}}",
							  JsonConvert.SerializeObject(successitem), JsonConvert.SerializeObject(erroritem),
							  JsonConvert.SerializeObject(errorList));
		}

		private static SalaryValue FindSalaryAccountSet(string name, IEnumerable<SalaryValue> set)
		{
			foreach (SalaryValue sv in set)
			{
				if (sv.ItemName == name)
				{
					return sv;
				}
			}
			return null;
		}

		public bool IsReusable
		{
			get { return false; }
		}
	}


	public class SalaryModel
	{
		public int PKID;
		public string EmployeeName;
		public int EmployeeID;
		public string AccountSetName;
		public int AccountSetID;
		public string Remark;
		public int VersionNumber;
		public List<SalaryValue> SalaryValueList = new List<SalaryValue>();
	}

	public class SalaryExcelModel
	{
		public int PKID;
		public string EmployeeName;
		public int EmployeeID;
		public string AccountSetName;
		public int AccountSetID;
		public string Remark;
		public int VersionNumber;
		public string WorkPlace;
		public string PrincipalshipName;
		public string ComeDate;
		public string SalaryCardNo;
		public string ProbationTime;
		public string Dept;
		public string Position;
		public string Grade;
		public List<SalaryValue> SalaryValueList = new List<SalaryValue>();
	}

	public class SalaryValue
	{
		public SalaryValue()
		{
		}

		public SalaryValue(string itemName)
		{
			ItemName = itemName;
		}

		public string ItemName;
		public string ItemValue = "";
		public int ItemID;
		public bool Editable = true;
	}

	public class UpdateItemModel
	{
		public UpdateItemModel(int pkid, int versionNumber)
		{
			PKID = pkid;
			VersionNumber = versionNumber;
		}

		public int PKID;
		public int VersionNumber;
		public List<SalaryValue> SalaryValueList = new List<SalaryValue>();
	}

	public class DropDownListSource
	{
		public int value;
		public string Text;
	}

	public class ButtonSet
	{
		public string BtnID;
		public bool Enable;
	}
}