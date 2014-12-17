using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using Newtonsoft.Json;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;
using System.Drawing;
using System.IO;
using Microsoft.Office.Interop.Excel;
using SEP.Performance.Views;

namespace SEP.Performance.Pages.SEP.WorkTaskPages
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WorkTaskManageHandle : IHttpHandler, IRequiresSessionState
    {
        private HttpContext _Context;
        private string _ResponseString;
        private Account _Operator;
        public void ProcessRequest(HttpContext context)
        {
            _Context = context;
            _Operator = _Context.Session[SessionKeys.LOGININFO] as Account;
            _ResponseString = "{}";
            context.Response.ContentType = "text/plain";
            if (context.Request.Params["type"] != null)
            {
                switch (context.Request.Params["type"])
                {
                    case "AddWorkTask":
                        AddWorkTask();
                        break;
                    case "UpdateWorkTask":
                        UpdateWorkTask();
                        break;
                    case "DeleteWorkTask":
                        DeleteWorkTask();
                        break;
                    case "GetWorkTaskByID":
                        GetWorkTaskByID();
                        break;
                    case "GetWorkTaskByName":
                        GetWorkTaskByName();
                        break;
                    case "SearchOwnerWorkTask":
                        SearchWorkTask();
                        break;
                    case "SearchOtherWorkTask":
                        SearchWorkTask();
                        break;
                    case "GetAllWorkTaskGrade":
                        GetAllWorkTaskGrade();
                        break;
                    case "GetAllWorkTaskNature":
                        GetAllWorkTaskNature();
                        break;
                    case "GetWorkTaskHistory":
                        GetWorkTaskHistory();
                        break;
                    case "GetWorkTaskHistoryByID":
                        GetWorkTaskHistoryByID();
                        break;
                    case "PublishWorkTask":
                        PublishWorkTask();
                        break;
                    case "GetWorkTaskQAByWorkTaskID":
                        GetWorkTaskQAByWorkTaskID();
                        break;
                    case "AddWorkTaskQA":
                        AddWorkTaskQA();
                        break;
                    case "UpdateWorkTaskQA":
                        UpdateWorkTaskQA();
                        break;
                    case "DeleteWorkTaskQA":
                        DeleteWorkTaskQA();
                        break;
                    case "AnswerQA":
                        AnswerQA();
                        break;
                    case "SearchTeamWorkTask":
                        SearchWorkTask();
                        break;
                    case "Export":
                        Export();
                        break;
                }
            }

            context.Response.Write(_ResponseString);
            context.Response.End();
        }
        private void Export()
        {
            GC.Collect();
            Application excelApp = new ApplicationClass();
            excelApp.Visible = false;
            List<Worksheet> excelSheetList = new List<Worksheet>();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);

            Worksheet excelSheet3 =
                (Worksheet)excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelSheetList.Add(excelSheet3);
            excelSheet3.Name = "工作计划";
            ExportToExcel(excelSheet3);

            ExcelExportUtility.RemoveBlankWorkSheet(excelBook);
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            string path = ConfigurationManager.AppSettings["EmployeeExportLocation"];
            if (!Directory.Exists(path)) //判断是否存在
            {
                Directory.CreateDirectory(path); //创建新路径
            }
            object file = path + "\\工作计划表" + DateTime.Now.ToBinary() + ".xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange,
                             nothing, nothing, nothing, nothing, nothing);

            excelBook.Close(false, null, null);

            ExcelExportUtility.ReleaseComObject(excelApp, excelBook, excelSheetList);
            ExcelExportUtility.KillProcess(excelApp, "Excel");
            ExcelExportUtility.OutputExcel(file.ToString(), _Context.Server, _Context.Response);
        }

        private void ExportToExcel(Worksheet excelSheet)
        {
            List<WorkTask> worktasks = new List<WorkTask>();
            try
            {
                if (_Context.Request.Params["ExportSource"] == "OwnerWorkTaskList")
                {
                    excelSheet.Name = "个人工作计划";
                    worktasks = _Context.Session["SearchOwnerWorkTaskList"] as List<WorkTask>;
                }
                if (_Context.Request.Params["ExportSource"] == "OtherWorkTaskList")
                {
                    excelSheet.Name = "其他工作计划";
                    worktasks = _Context.Session["SearchOtherWorkTaskList"] as List<WorkTask>;
                }
                if (_Context.Request.Params["ExportSource"] == "TeamWorkTaskList")
                {
                    excelSheet.Name = "团队工作计划";
                    worktasks = _Context.Session["SearchTeamWorkTaskList"] as List<WorkTask>;
                }
            }
            catch
            {
            }
            if (worktasks == null)
            {
                worktasks = new List<WorkTask>();
            }
            //二维数组定义是多一个标题行。
            List<WorkTaskViewModel> workTaskViewModelUIs = WorkTaskViewModel.Turn(worktasks);
            int rowcount = worktasks.Count;
            int colcount = 10;
            object[,] dataArray = new object[rowcount + 1, colcount];

            dataArray[0, 0] = "任务名称";
            dataArray[0, 1] = "工作内容";
            dataArray[0, 2] = "优先级别";
            dataArray[0, 3] = "创建人";
            dataArray[0, 4] = "负责人";
            dataArray[0, 5] = "开始时间";
            dataArray[0, 6] = "完成时间";
            dataArray[0, 7] = "当前状态";
            dataArray[0, 8] = "当前状态工作描述";
            dataArray[0, 9] = "备注";
            for (int i = 0; i < workTaskViewModelUIs.Count; i++)
            {
                dataArray[i + 1, 0] = workTaskViewModelUIs[i].Title;
                dataArray[i + 1, 1] = workTaskViewModelUIs[i].Content;
                dataArray[i + 1, 2] = workTaskViewModelUIs[i].PriorityName;
                dataArray[i + 1, 3] = workTaskViewModelUIs[i].OwerName;
                dataArray[i + 1, 4] = workTaskViewModelUIs[i].ResponsiblesNameIncludeOwner;
                dataArray[i + 1, 5] = workTaskViewModelUIs[i].StartDate;
                dataArray[i + 1, 6] = workTaskViewModelUIs[i].EndDate;
                dataArray[i + 1, 7] = workTaskViewModelUIs[i].StatusName;
                dataArray[i + 1, 8] = workTaskViewModelUIs[i].Description;
                dataArray[i + 1, 9] = workTaskViewModelUIs[i].Remark;
            }
            excelSheet.get_Range("A1", excelSheet.Cells[rowcount + 1, colcount]).Value2 = dataArray;

            Range r = excelSheet.get_Range("A1", excelSheet.Cells[rowcount + 1, colcount]);
            r.Font.Size = 10;
            r.WrapText = true;
            r.Borders.LineStyle = XlLineStyle.xlContinuous;
            r.Borders.Color = Color.Black.ToArgb();
            r.BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlThin,
                                          XlColorIndex.xlColorIndexAutomatic, Color.Black.ToArgb());
            r.RowHeight = 24;

            ((Range)
             excelSheet.Columns[
                 ExcelExportUtility.ExcelColumnNames[0] + ":" + ExcelExportUtility.ExcelColumnNames[0],
                 Type.Missing]).ColumnWidth = 15;
            ((Range)
             excelSheet.Columns[
                 ExcelExportUtility.ExcelColumnNames[1] + ":" + ExcelExportUtility.ExcelColumnNames[1],
                 Type.Missing]).ColumnWidth = 28;
            ((Range)
             excelSheet.Columns[
                 ExcelExportUtility.ExcelColumnNames[4] + ":" + ExcelExportUtility.ExcelColumnNames[4],
                 Type.Missing]).ColumnWidth = 10;
            ((Range)
             excelSheet.Columns[
                 ExcelExportUtility.ExcelColumnNames[8] + ":" + ExcelExportUtility.ExcelColumnNames[8],
                 Type.Missing]).ColumnWidth = 33;
            if (worktasks.Count > 0)
            {
                Range r8 = excelSheet.get_Range("I2", "I" + (worktasks.Count + 1));
                r8.Font.Color = ColorTranslator.FromHtml("#FF0000").ToArgb();
            }
            ((Range)excelSheet.Rows["1:1", Type.Missing]).RowHeight = 45;
            ((Range)excelSheet.Rows["1:1", Type.Missing]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
            for (int i = 0; i < workTaskViewModelUIs.Count; i++)
            {

                Range r7 = excelSheet.get_Range("H" + (i + 2), "H" + (i + 2));
                if (workTaskViewModelUIs[i].StatusName == "未开始")
                {
                    r7.Interior.Color = ColorTranslator.FromHtml("#FF0000").ToArgb();
                }
                if (workTaskViewModelUIs[i].StatusName == "进行中")
                {
                    r7.Interior.Color = ColorTranslator.FromHtml("#00FFFF").ToArgb();
                }
                if (workTaskViewModelUIs[i].StatusName == "未完成")
                {
                    r7.Interior.Color = ColorTranslator.FromHtml("#0000FF").ToArgb();
                }
                if (workTaskViewModelUIs[i].StatusName == "已完成")
                {
                    r7.Interior.Color = ColorTranslator.FromHtml("#00FF00").ToArgb();
                }
            }

        }

        private void PublishWorkTask()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                if (Convert.ToInt32(_Context.Request.Params["Pkid"]) != 0)
                {
                    UpdateWorkTask();
                }
                else
                {
                    AddWorkTask();
                }
                //InstanceFactory.CreateWorkTaskApplicationFacade().SetIsPublishApplication(
                //    Convert.ToInt32(_Context.Request.Params["dialogWorkTaskAppID"]), 1);
                return;
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void GetWorkTaskByName()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            WorkTaskViewModel pvm = null;
            try
            {
                //WorkTask p =
                //    BllInstance.WelcomeMailBllInstance.GetWorkTaskByName(_Context.Request.Params["Name"], _Operator);
                //if (p != null)
                //{
                //    p = BllInstance.WorkTaskBllInstance.GetWorkTaskById(p.Id, _Operator);
                //}
                //pvm = new WorkTaskViewModel(p);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"item\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(pvm),
                                            JsonConvert.SerializeObject(errors));
        }

        private void GetWorkTaskHistoryByID()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            WorkTaskViewModel pvm = null;
            try
            {
                //WorkTaskHistory p =
                //    InstanceFactory.CreateWorkTaskHistoryFacade().GetWorkTaskHistoryByPKID(
                //        Convert.ToInt32(_Context.Request.Params["HistoryId"]));
                //pvm = new WorkTaskViewModel(p);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"item\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(pvm),
                                            JsonConvert.SerializeObject(errors));
        }

        private void GetWorkTaskHistory()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<WorkTaskViewModel> workTaskViewModelUIs = new List<WorkTaskViewModel>();
            try
            {
                //List<WorkTaskHistory> phs =
                //    InstanceFactory.CreateWorkTaskHistoryFacade().GetWorkTaskHistoryByWorkTaskID(
                //        Convert.ToInt32(_Context.Request.Params["Pkid"]));

                //workTaskViewModelUIs = WorkTaskViewModel.Turn(phs);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(workTaskViewModelUIs),
                              JsonConvert.SerializeObject(errors));
        }

        private void GetAllWorkTaskNature()
        {
            string result = String.Empty;
            //List<WorkTaskNature> all = BllInstance.WorkTaskBllInstance.GetAllWorkTaskNature();

            //foreach (WorkTaskNature item in all)
            //{
            //    result += string.IsNullOrEmpty(result)
            //                  ? item.Name
            //                  : "\n" + item.Name;
            //}
            _ResponseString = result;
        }

        private void GetAllWorkTaskGrade()
        {
            string result = String.Empty;
            //List<WorkTaskGrade> all = BllInstance.WorkTaskBllInstance.GetAllWorkTaskGrade();

            //foreach (WorkTaskGrade item in all)
            //{
            //    result += string.IsNullOrEmpty(result)
            //                  ? item.Name
            //                  : "\n" + item.Name;
            //}
            _ResponseString = result;
        }

        private void GetWorkTaskByID()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            WorkTaskViewModel pvm = null;
            try
            {
                WorkTask p =
                    BllInstance.WorkTaskBllInstance.GetWorkTask(Convert.ToInt32(_Context.Request.Params["Pkid"]));
                pvm = new WorkTaskViewModel(p);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"item\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(pvm),
                                            JsonConvert.SerializeObject(errors));
        }

        private void GetWorkTaskQAByWorkTaskID()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<WorkTaskViewModelQA> workTaskViewModelUIs = new List<WorkTaskViewModelQA>();
            try
            {
                List<WorkTaskQA> p =
                    BllInstance.WorkTaskBllInstance.GetWorkTask(Convert.ToInt32(_Context.Request.Params["Pkid"])).
                        WorkTaskQAs;

                workTaskViewModelUIs = WorkTaskViewModelQA.Turn(p);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"item\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(workTaskViewModelUIs),
                                            JsonConvert.SerializeObject(errors));
        }

        private void DeleteWorkTask()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                BllInstance.WorkTaskBllInstance.DeleteWorkTask(Convert.ToInt32(_Context.Request.Params["Pkid"]));
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void UpdateWorkTask()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                WorkTask workTask = new WorkTask();
                workTask.Pkid = Convert.ToInt32(_Context.Request.Params["Pkid"]);
                workTask.Responsibles = new List<Account>();
                WorkTaskDataBind(workTask);

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    BllInstance.WorkTaskBllInstance.UpdateWorkTask(workTask,
                                                                   Convert.ToBoolean(
                                                                       _Context.Request.Params["info_IfEmail"]));
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void AddWorkTask()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                WorkTask workTask = new WorkTask();
                WorkTaskDataBind(workTask);
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    BllInstance.WorkTaskBllInstance.CreateWorkTask(workTask,
                                                                   Convert.ToBoolean(
                                                                       _Context.Request.Params["info_IfEmail"]));

                    ts.Complete();
                }

            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void WorkTaskDataBind(WorkTask workTask)
        {
            workTask.Title = _Context.Request.Params["info_Title"];
            DateTime startdt;
            if (DateTime.TryParse(_Context.Request.Params["info_StartDate"], out startdt))
            {
                workTask.StartDate = startdt;
            }
            DateTime enddt;
            if (DateTime.TryParse(_Context.Request.Params["info_EndDate"], out enddt))
            {
                workTask.EndDate = enddt;
            }
            workTask.Priority = WTPriority.GetById(Convert.ToInt32(_Context.Request.Params["info_Priority"]));
            workTask.Status = WTStatus.GetById(Convert.ToInt32(_Context.Request.Params["info_Status"]));
            workTask.Description = _Context.Request.Params["info_Description"];
            workTask.Remark = _Context.Request.Params["info_Remark"];
            workTask.Content = _Context.Request.Params["info_Content"];
            workTask.Account = _Operator;

            string errorname;
            List<Account> accounts = BllInstance.AccountBllInstance.GetAccountByNameString(
                _Context.Request.Params["info_Responsibles"] ?? string.Empty, out errorname);
            if (!string.IsNullOrEmpty(errorname))
            {
                throw new Exception("系统中没有找到" + errorname + "，请确认系统中有这些人员的信息。");
            }
            workTask.Responsibles = accounts;
        }

        private void SearchWorkTask()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<WorkTaskViewModel> workTaskViewModelUIs = new List<WorkTaskViewModel>();
            try
            {
                DateTime dt;
                int x;
                bool b;

                DateTime startDate = new DateTime(1900, 1, 1);
                DateTime endDate = new DateTime(2999, 12, 31);
                int status = -1;
                int accountID = 0;
                bool ifNotStarted = false;
                bool ifFinish = false;
                bool ifOngoing = false;
                bool ifFailure = false;
                if (_Context.Request.Params["StartDate"] != null &&
                    DateTime.TryParse(_Context.Request.Params["StartDate"], out dt))
                {
                    startDate = dt;
                }
                if (_Context.Request.Params["EndDate"] != null &&
                    DateTime.TryParse(_Context.Request.Params["EndDate"], out dt))
                {
                    endDate = dt;
                }
                if (_Context.Request.Params["Priority"] != null &&
                    int.TryParse(_Context.Request.Params["Priority"], out x))
                {
                    status = x;
                }
                if (_Context.Request.Params["AccountID"] != null &&
                    int.TryParse(_Context.Request.Params["AccountID"], out x))
                {
                    accountID = x;
                }
                if (!string.IsNullOrEmpty(_Context.Request.Params["Status"]))
                {
                    string[] ischecks = _Context.Request.Params["Status"].Split('|');
                    if (ischecks.Length == 5)
                    {
                        ifNotStarted = bool.TryParse(ischecks[1], out b) ? b : ifNotStarted;
                        ifOngoing = bool.TryParse(ischecks[2], out b) ? b : ifOngoing;
                        ifFailure = bool.TryParse(ischecks[3], out b) ? b : ifFailure;
                        ifFinish = bool.TryParse(ischecks[4], out b) ? b : ifFinish;
                    }
                }
                List<WorkTask> WorkTasks = new List<WorkTask>();
                if (_Context.Request.Params["type"] == "SearchOwnerWorkTask")
                {
                    WorkTasks =
                        BllInstance.WorkTaskBllInstance.GetMyWorkTaskByCondition(
                            _Context.Request.Params["TaskName"] ?? string.Empty, startDate, endDate, status, ifNotStarted,
                            ifOngoing, ifFailure, ifFinish, accountID);
                    _Context.Session["SearchOwnerWorkTaskList"] = WorkTasks;
                }
                if (_Context.Request.Params["type"] == "SearchOtherWorkTask")
                {
                    WorkTasks =
                        BllInstance.WorkTaskBllInstance.GetResponsibleWorkTaskByCondition(
                            _Context.Request.Params["TaskName"] ?? string.Empty, startDate, endDate, status, ifNotStarted,
                            ifOngoing, ifFailure, ifFinish, accountID);
                    _Context.Session["SearchOtherWorkTaskList"] = WorkTasks;
                }
                if (_Context.Request.Params["type"] == "SearchTeamWorkTask")
                {
                    WorkTasks =
                        BllInstance.WorkTaskBllInstance.GetTeamWorkTaskByCondition(_Context.Request.Params["CreatorName"] ?? string.Empty,
                         _Context.Request.Params["DeptName"] ?? string.Empty,
                            _Context.Request.Params["TaskName"] ?? string.Empty, startDate, endDate, status, ifNotStarted,
                            ifOngoing, ifFailure, ifFinish, accountID);
                    _Context.Session["SearchTeamWorkTaskList"] = WorkTasks;
                }
                workTaskViewModelUIs = WorkTaskViewModel.Turn(WorkTasks);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(workTaskViewModelUIs),
                              JsonConvert.SerializeObject(errors));
        }

        private void AddWorkTaskQA()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                WorkTaskQA workTaskQA = new WorkTaskQA();
                workTaskQA.WorkTask.Pkid = Convert.ToInt32(_Context.Request.Params["Pkid"]);
                workTaskQA.QAccount = _Operator;
                workTaskQA.Question = _Context.Request.Params["info_Question"];
                BllInstance.WorkTaskBllInstance.QuestionWorkTask(workTaskQA,
                                                                 Convert.ToBoolean(
                                                                     _Context.Request.Params["info_IfQAEmail"]));
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void UpdateWorkTaskQA()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                WorkTaskQA workTaskQA =
                    BllInstance.WorkTaskBllInstance.GetWorkTaskQA(Convert.ToInt32(_Context.Request.Params["Pkid"]));
                workTaskQA.QAccount = _Operator;
                workTaskQA.Question = _Context.Request.Params["info_Question"];

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    BllInstance.WorkTaskBllInstance.QuestionWorkTask(workTaskQA,
                                                                   Convert.ToBoolean(
                                                                       _Context.Request.Params["info_IfQAEmail"]));
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void DeleteWorkTaskQA()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                BllInstance.WorkTaskBllInstance.DeleteWorkTaskQA(Convert.ToInt32(_Context.Request.Params["QAID"]));
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void AnswerQA()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                WorkTaskQA workTaskQA =
                    BllInstance.WorkTaskBllInstance.GetWorkTaskQA(Convert.ToInt32(_Context.Request.Params["Pkid"]));
                workTaskQA.AAccount = _Operator;
                workTaskQA.Answer = _Context.Request.Params["info_Answer"];

                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    BllInstance.WorkTaskBllInstance.AnswerWorkTask(workTaskQA,
                                                                   Convert.ToBoolean(
                                                                       _Context.Request.Params["info_IfQAEmail"]));
                    ts.Complete();
                }
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        public bool IsReusable
        {
            get { return false; }
        }

    }

    public class WorkTaskViewModel
    {
        private readonly WorkTask _WorkTask;

        public WorkTaskViewModel(WorkTask workTask)
        {
            _WorkTask = workTask;
        }
        public string PKID
        {
            get { return _WorkTask.Pkid.ToString(); }
        }

        public string OwerID
        {
            get { return _WorkTask.Account.Id.ToString(); }
        }

        public string OwerName
        {
            get { return _WorkTask.Account.Name; }
        }
        public string Remark
        {
            get { return _WorkTask.Remark; }
        }
        public string Content
        {
            get { return _WorkTask.Content; }
        }

        public string Description
        {
            get { return _WorkTask.Description; }
        }
        public string StartDate
        {
            get { return _WorkTask.StartDate.ToShortDateString(); }
        }
        public string EndDate
        {
            get { return _WorkTask.EndDate.ToShortDateString(); }
        }
        public string PriorityName
        {
            get { return _WorkTask.Priority.Name; }
        }
        public string StatusName
        {
            get { return _WorkTask.Status.Name; }
        }
        public string RowStyle
        {
            get
            {
                return _WorkTask.Status.LineStyle;
            }
        }
        public string StatusNameWithStyle
        {
            get
            {
                return "<span class=\"" + _WorkTask.Status.Style + "\">" + _WorkTask.Status.Name + "</span>";
            }
        }
        public string Priority
        {
            get { return _WorkTask.Priority.Id.ToString(); }
        }
        public string Status
        {
            get { return _WorkTask.Status.Id.ToString(); }
        }
        public string Title
        {
            get { return _WorkTask.Title; }
        }
        public string ResponsiblesNameIncludeOwner
        {
            get
            {
                string ret = string.Empty;
                foreach (Account account in _WorkTask.Responsibles)
                {
                    ret += string.IsNullOrEmpty(ret) ? "" : ";";
                    ret += account.Name;
                }
                ret += string.IsNullOrEmpty(ret) ? "" : ";";
                ret += OwerName;
                return ret;
            }
        }
        public string ResponsiblesName
        {
            get
            {
                string ret = string.Empty;
                foreach (Account account in _WorkTask.Responsibles)
                {
                    ret += string.IsNullOrEmpty(ret) ? "" : ";";
                    ret += account.Name;
                }
                return ret;
            }
        }
        public string ContentAndDesc
        {
            get
            {
                return
                    _WorkTask.Content +
                    (string.IsNullOrEmpty(_WorkTask.Description)
                         ? ""
                         : ("<br/><span style='color:blue'>当前状态：" + _WorkTask.Description + "</span>"));
            }
        }
        public string QACount
        {
            get
            {
                return _WorkTask.WorkTaskQAs.Count.ToString();
            }
        }
        public static List<WorkTaskViewModel> Turn(List<WorkTask> types)
        {
            List<WorkTaskViewModel> list = new List<WorkTaskViewModel>();
            foreach (WorkTask t in types)
            {
                list.Add(new WorkTaskViewModel(t));
            }
            return list;
        }
    }

    public class WorkTaskViewModelQA
    {
        private readonly WorkTaskQA _WorkTaskQA;

        public WorkTaskViewModelQA(WorkTaskQA workTaskQA)
        {
            _WorkTaskQA = workTaskQA;
        }

        public string PKID
        {
            get { return _WorkTaskQA.Pkid.ToString(); }
        }

        public string QAccountID
        {
            get { return _WorkTaskQA.QAccount.Id.ToString(); }
        }

        public string QAccount
        {
            get { return _WorkTaskQA.QAccount.Name; }
        }

        public string AAccount
        {
            get { return _WorkTaskQA.AAccount.Name; }
        }

        public string Question
        {
            get { return _WorkTaskQA.Question; }
        }

        public string Answer
        {
            get { return _WorkTaskQA.Answer; }
        }

        public string QuestionDate
        {
            get { return _WorkTaskQA.QuestionDate.ToString(); }
        }

        public string AnswerDate
        {
            get { return _WorkTaskQA.AnswerDate.ToString(); }
        }

        public static List<WorkTaskViewModelQA> Turn(List<WorkTaskQA> types)
        {
            List<WorkTaskViewModelQA> list = new List<WorkTaskViewModelQA>();
            foreach (WorkTaskQA t in types)
            {
                list.Add(new WorkTaskViewModelQA(t));
            }
            return list;
        }
    }

}