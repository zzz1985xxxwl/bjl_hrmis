using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Model.Utility;
using SEPPerformance = SEP.Performance;


namespace SEP.Performance.Pages.SEP.PositionPages
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class PositionHandler : IHttpHandler, IRequiresSessionState
    {

        private HttpContext _Context;
        private string _ResponseString;
        private Account _Operator;
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
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
                    case "AddPosition":
                        AddPosition();
                        break;
                    case "UpdatePosition":
                        UpdatePosition();
                        break;
                    case "DeletePosition":
                        DeletePosition();
                        break;
                    case "GetPositionByID":
                        GetPositionByID();
                        break;
                    case "GetPositionByName":
                        GetPositionByName();
                        break;
                    case "SearchPosition":
                        SearchPosition();
                        break;
                    case "Export":
                        Export();
                        break;
                    case "ExportEmployee":
                        ExportEmployee();
                        break;
                    case "GetAllPositionGrade":
                        GetAllPositionGrade();
                        break;
                    case "GetAllPositionNature":
                        GetAllPositionNature();
                        break;
                    case "GetPositionHistory":
                        GetPositionHistory();
                        break;
                    case "GetPositionHistoryByID":
                        GetPositionHistoryByID();
                        break;
                    case "PublishPosition":
                        PublishPosition();
                        break;

                }
            }

            context.Response.Write(_ResponseString);
            context.Response.End();
        }

        private void PublishPosition()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                if (Convert.ToInt32(_Context.Request.Params["Pkid"]) != 0)
                {
                    UpdatePosition();
                }
                else
                {
                    AddPosition();
                }
                InstanceFactory.CreatePositionApplicationFacade().SetIsPublishApplication(
                    Convert.ToInt32(_Context.Request.Params["dialogPositionAppID"]), 1);
                return;
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void GetPositionByName()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            PositionViewModel pvm = null;
            try
            {
                Position p =
                    BllInstance.PositionBllInstance.GetPositionByName(_Context.Request.Params["Name"], _Operator);
                if (p != null)
                {
                    p = BllInstance.PositionBllInstance.GetPositionById(p.Id, _Operator);
                }
                pvm = new PositionViewModel(p);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"item\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(pvm),
                                            JsonConvert.SerializeObject(errors));
        }

        private void GetPositionHistoryByID()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            PositionViewModel pvm = null;
            try
            {
                PositionHistory p =
                    InstanceFactory.CreatePositionHistoryFacade().GetPositionHistoryByPKID(
                        Convert.ToInt32(_Context.Request.Params["HistoryId"]));
                pvm = new PositionViewModel(p);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"item\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(pvm),
                                            JsonConvert.SerializeObject(errors));
        }

        private void GetPositionHistory()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<PositionViewModel> positionViewModelUIs = new List<PositionViewModel>();
            try
            {
                List<PositionHistory> phs =
                    InstanceFactory.CreatePositionHistoryFacade().GetPositionHistoryByPositionID(
                        Convert.ToInt32(_Context.Request.Params["Pkid"]));

                positionViewModelUIs = PositionViewModel.Turn(phs);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(positionViewModelUIs),
                              JsonConvert.SerializeObject(errors));
        }

        private void GetAllPositionNature()
        {
            string result = String.Empty;
            List<PositionNature> all = BllInstance.PositionBllInstance.GetAllPositionNature();

            foreach (PositionNature item in all)
            {
                result += string.IsNullOrEmpty(result)
                              ? item.Name
                              : "\n" + item.Name;
            }
            _ResponseString = result;
        }

        private void GetAllPositionGrade()
        {
            string result = String.Empty;
            List<PositionGrade> all = BllInstance.PositionBllInstance.GetAllPositionGrade();

            foreach (PositionGrade item in all)
            {
                result += string.IsNullOrEmpty(result)
                              ? item.Name
                              : "\n" + item.Name;
            }
            _ResponseString = result;
        }

        private void ExportEmployee()
        {
            if (_Context.Request.Params["Pkid"] != null)
            {
                Account exportAccount =
                    BllInstance.AccountBllInstance.GetAccountById(Convert.ToInt32(_Context.Request.Params["AccountID"]));
                Position p =
                    BllInstance.PositionBllInstance.GetPositionById(Convert.ToInt32(_Context.Request.Params["Pkid"]),
                                                                    exportAccount);

                Account leader = BllInstance.AccountBllInstance.GetLeaderByAccountId(exportAccount.Id);
                if (leader != null)
                {
                    leader = BllInstance.AccountBllInstance.GetAccountById(leader.Id);
                }
                if (leader == null)
                {
                    leader = new Account();
                    leader.Dept = new Department();
                }
                if (p == null)
                {
                    _ResponseString = "alert('导出失败');";
                    return;
                }
                p.Members = new List<Account>();
                p.Members.Add(new Account(0, "", _Context.Request.Params["EmployeeName"]));

                string filestringbuild = ToCreateFile(p, leader.Name, leader.Dept.Name, exportAccount.Dept.Name);
                ExportWord(filestringbuild);
            }
        }

        private void ExportWord(string filestringbuild)
        {

            if (string.IsNullOrEmpty(filestringbuild) || !File.Exists(filestringbuild))
            {
                _ResponseString = "alert('导出失败');";
                return;
            }

            FileInfo fileInfo = new FileInfo(filestringbuild);
            _Context.Response.Clear();
            _Context.Response.ClearContent();
            _Context.Response.ClearHeaders();
            _Context.Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(filestringbuild));
            _Context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            _Context.Response.AddHeader("Content-Transfer-Encoding", "binary");
            _Context.Response.ContentType = "application/octet-stream";
            _Context.Response.ContentEncoding = Encoding.GetEncoding("gb2312");
            _Context.Response.WriteFile(fileInfo.FullName);
            _Context.Response.Flush();
            _Context.Response.End();
        }

        private void Export()
        {
            if (_Context.Request.Params["Pkid"] != null)
            {
                Position p =
                    BllInstance.PositionBllInstance.GetPositionById(Convert.ToInt32(_Context.Request.Params["Pkid"]),
                                                                    _Operator);

                if (p == null)
                {
                    _ResponseString = "alert('导出失败');";
                    return;
                }

                string filestringbuild = ToCreateFile(p, "", "", "");

                ExportWord(filestringbuild);

            }
        }

        private string ToCreateFile(Position p, string leaderName, string leaderPosition, string dept)
        {
            string ret = "";
            PositionViewModel pvm = new PositionViewModel(p);

            Application app = new Application();
            object nothing = Type.Missing;
            object localPatho = _Context.Server.MapPath(ConstParameters.Template_PositionInfoDoc);
            Document doc = app.Documents.Add(ref localPatho, ref nothing, ref nothing, ref nothing);

            try
            {
                if (!Directory.Exists(_EmployeeExportLocation))
                {
                    Directory.CreateDirectory(_EmployeeExportLocation);
                }
                Table tb = doc.Tables[1];

                tb.Cell(2, 2).Range.Text = pvm.Name;
                tb.Cell(2, 4).Range.Text = leaderPosition;
                tb.Cell(3, 2).Range.Text = pvm.Members;
                tb.Cell(3, 4).Range.Text = leaderName;
                tb.Cell(4, 2).Range.Text = string.IsNullOrEmpty(dept) ? pvm.Depts : dept;
                tb.Cell(4, 4).Range.Text = pvm.NatureNames;

                tb.Cell(6, 1).Range.Text = pvm.Summary;
                tb.Cell(8, 1).Range.Text = pvm.MainDuties;

                tb.Cell(10, 2).Range.Text = pvm.ReportScope;
                tb.Cell(11, 2).Range.Text = pvm.ControlScope;
                tb.Cell(12, 2).Range.Text = pvm.Coordination;

                tb.Cell(14, 1).Range.Text = pvm.Authority;

                tb.Cell(16, 1).Range.Text = pvm.Qualification; ;

                tb.Cell(18, 2).Range.Text = pvm.KnowledgeAndSkills;
                tb.Cell(19, 2).Range.Text = pvm.RelatedProcesses;
                tb.Cell(20, 2).Range.Text = pvm.ManagementSkills;
                tb.Cell(21, 2).Range.Text = pvm.AuxiliarySkills;
                tb.Cell(22, 2).Range.Text = pvm.Competence;
                tb.Cell(23, 2).Range.Text = pvm.OtherRequirements;


                object fileFormat = WdSaveFormat.wdFormatTemplate97;
                object filename = _EmployeeExportLocation + "\\" + "职位说明书-" + p.Name + ".doc";
                doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing);
                ret = filename.ToString();
            }
            catch (Exception e)
            {
                doc.Tables[1].Cell(3, 2).Range.Text = e.Message;
                object filename = _EmployeeExportLocation + "\\" + "temp.doc";
                object fileFormat = WdSaveFormat.wdFormatTemplate97;
                doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing);
            }
            finally
            {
                doc.Close(ref nothing, ref nothing, ref nothing);
                app.Quit(ref nothing, ref nothing, ref nothing);
            }
            return ret;
        }

        private void GetPositionByID()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            PositionViewModel pvm = null;
            try
            {
                Position p =
                    BllInstance.PositionBllInstance.GetPositionById(Convert.ToInt32(_Context.Request.Params["Pkid"]),
                                                                    _Operator);
                pvm = new PositionViewModel(p);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"item\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(pvm),
                                            JsonConvert.SerializeObject(errors));
        }

        private void DeletePosition()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                BllInstance.PositionBllInstance.DeletePosition(Convert.ToInt32(_Context.Request.Params["Pkid"]),
                                                               _Operator);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void UpdatePosition()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                Position oldposition =
                    BllInstance.PositionBllInstance.GetPositionById(
                        Convert.ToInt32(_Context.Request.Params["Pkid"]), _Operator);
                Position position = new Position();
                position.Id = Convert.ToInt32(_Context.Request.Params["Pkid"]);
                position.Departments = new List<Department>();
                position.Members = new List<Account>();
                position.Nature = new List<PositionNature>();
                PositionDataBind(position);

                //using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                //{
                BllInstance.PositionBllInstance.UpdatePosition(position,
                                                               _Operator);
                UpdateAccountPosition(position);
                //System.Threading.Thread.Sleep(1500);
                if (CompanyConfig.HasHrmisSystem && !oldposition.IsEqual(position))
                {
                    IPositionHistoryFacade hrmisPositionHistoryFacade =
                        InstanceFactory.CreatePositionHistoryFacade();
                    hrmisPositionHistoryFacade.AddPositionHistoryFacade(_Operator, position);
                }
                //    ts.Complete();
                //}
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void AddPosition()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                Position position = new Position();
                PositionDataBind(position);
                //using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                //{
                BllInstance.PositionBllInstance.CreatePosition(position, _Operator);

                UpdateAccountPosition(position);
                //System.Threading.Thread.Sleep(1500);
                if (CompanyConfig.HasHrmisSystem)
                {
                    IPositionHistoryFacade hrmisPositionHistoryFacade =
                        InstanceFactory.CreatePositionHistoryFacade();
                    hrmisPositionHistoryFacade.AddPositionHistoryFacade(_Operator);
                }
                //    ts.Complete();
                //}

            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }
        private void UpdateAccountPosition(Position position)
        {

            foreach (Account account in position.Members)
            {
                if (account.Position.Id == position.Id)
                {
                    continue;
                }
                account.Position = position;
                BllInstance.AccountBllInstance.UpdateAccount(account, _Operator);
                if (CompanyConfig.HasHrmisSystem)
                {
                    IEmployeeFacade hrmisEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
                    Employee currEmployee = hrmisEmployeeFacade.GetEmployeeByAccountID(account.Id);
                    if (currEmployee != null)
                    {
                        hrmisEmployeeFacade.UpdateEmployeeProxy(currEmployee, _Operator);
                    }
                    else if (account.IsHRAccount)
                    {
                        hrmisEmployeeFacade.InitEmployeeProxy(account.Id, _Operator);
                    }
                }
            }
        }

        private void PositionDataBind(Position position)
        {
            DateTime dt;
            position.Name = _Context.Request.Params["dialogName"] ?? string.Empty;
            position.Description = _Context.Request.Params["dialogDescription"] ?? string.Empty;
            position.Number = _Context.Request.Params["dialogNumber"] ?? string.Empty;
            position.Reviewer =
                BllInstance.AccountBllInstance.GetAccountByName(_Context.Request.Params["dialogReviewer"] ??
                                                                string.Empty);
            position.Version = _Context.Request.Params["dialogVersion"] ?? string.Empty;
            if (_Context.Request.Params["dialogCommencement"] != null &&
                DateTime.TryParse(_Context.Request.Params["dialogCommencement"], out dt))
            {
                position.Commencement = dt;
            }
            position.Summary = _Context.Request.Params["dialogSummary"] ?? string.Empty;
            position.MainDuties = _Context.Request.Params["dialogMainDuties"] ?? string.Empty;
            position.ReportScope = _Context.Request.Params["dialogReportScope"] ?? string.Empty;
            position.ControlScope = _Context.Request.Params["dialogControlScope"] ?? string.Empty;
            position.Coordination = _Context.Request.Params["dialogCoordination"] ?? string.Empty;
            position.Authority = _Context.Request.Params["dialogAuthority"] ?? string.Empty;
            position.Education = _Context.Request.Params["dialogEducation"] ?? string.Empty;
            position.ProfessionalBackground = _Context.Request.Params["dialogProfessionalBackground"] ?? string.Empty;
            position.WorkExperience = _Context.Request.Params["dialogWorkExperience"] ?? string.Empty;
            position.Qualification = _Context.Request.Params["dialogQualification"] ?? string.Empty;
            position.Competence = _Context.Request.Params["dialogCompetence"] ?? string.Empty;
            position.OtherRequirements = _Context.Request.Params["dialogOtherRequirements"] ?? string.Empty;
            position.KnowledgeAndSkills = _Context.Request.Params["dialogKnowledgeAndSkills"] ?? string.Empty;
            position.RelatedProcesses = _Context.Request.Params["dialogRelatedProcesses"] ?? string.Empty;
            position.ManagementSkills = _Context.Request.Params["dialogManagementSkills"] ?? string.Empty;
            position.AuxiliarySkills = _Context.Request.Params["dialogAuxiliarySkills"] ?? string.Empty;

            int i;
            if (!string.IsNullOrEmpty(_Context.Request.Params["dialogPositionStatus"])
                && int.TryParse(_Context.Request.Params["dialogPositionStatus"], out i))
            {
                position.PositionStatus = PositionStatus.GetById(i);
            }
            else
            {
                position.PositionStatus = PositionStatus.All;
            }
            if (!string.IsNullOrEmpty(_Context.Request.Params["dialogcblNature"]))
            {
                string[] natureIDs = _Context.Request.Params["dialogcblNature"].Split('|');
                foreach (string id in natureIDs)
                {
                    if (int.TryParse(id, out i))
                    {
                        PositionNature pn = new PositionNature();
                        pn.Pkid = i;
                        position.Nature = position.Nature ?? new List<PositionNature>();
                        position.Nature.Add(pn);
                    }
                }
            }

            position.Grade = new PositionGrade();
            position.Grade.Id = 0;
            //position.Grade.Id = !string.IsNullOrEmpty(_Context.Request.Params["dialogGrade"]) &&
            //                    int.TryParse(_Context.Request.Params["dialogGrade"], out i)
            //                        ? i
            //                        : 0;


            string errorname;
            List<Account> accounts =
                BllInstance.AccountBllInstance.GetAccountByNameString(
                    _Context.Request.Params["dialogEmployee"] ?? string.Empty, out errorname);
            if (!string.IsNullOrEmpty(errorname))
            {
                throw new Exception("系统中没有找到" + errorname + "，请确认系统中有这些人员的信息。");
            }
            position.Members = accounts;

            errorname = string.Empty;
            List<Department> departments =
                BllInstance.DepartmentBllInstance.GetDepartmentByNameString(
                    _Context.Request.Params["dialogDepartment"] ?? string.Empty, out errorname);
            if (!string.IsNullOrEmpty(errorname))
            {
                throw new Exception("系统中没有找到" + errorname + "，请确认系统中有这些部门。");
            }
            position.Departments = departments;
        }

        private void SearchPosition()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<PositionViewModel> positionViewModelUIs = new List<PositionViewModel>();
            try
            {
                string Name =
                    (_Context.Request.Params["Name"] ?? string.Empty).Replace('；', ';').Trim().Trim(';').Trim();
                //string Grade =
                //    (_Context.Request.Params["Grade"] ?? string.Empty).Replace('；', ';').Trim().Trim(';').Trim();
                string Nature =
                    (_Context.Request.Params["Nature"] ?? string.Empty).Replace('；', ';').Trim().Trim(';').Trim();
                string Department =
                    (_Context.Request.Params["Department"] ?? string.Empty).Replace('；', ';').Trim().Trim(';').Trim();
                string AccountName =
                    (_Context.Request.Params["AccountName"] ?? string.Empty).Replace('；', ';').Trim().Trim(';').Trim();

                string NameWhere = string.Empty;
                foreach (string str in Name.Split(';'))
                {
                    NameWhere += string.IsNullOrEmpty(NameWhere)
                                     ? "positionname like '%" + str.Trim() + "%' "
                                     : "or positionname like '%" + str.Trim() + "%' ";
                }
                //string GradeWhere = string.Empty;
                //foreach (string str in Grade.Split(';'))
                //{
                //    GradeWhere += string.IsNullOrEmpty(GradeWhere)
                //                      ? "PositionGradeName like '%" + str.Trim() + "%' "
                //                      : "or PositionGradeName like '%" + str.Trim() + "%' ";
                //}
                string NatureWhere = string.Empty;
                foreach (string str in Nature.Split(';'))
                {
                    NatureWhere += string.IsNullOrEmpty(NatureWhere)
                                       ? "tpositionnature.name like '%" + str.Trim() + "%' "
                                       : "or tpositionnature.name like '%" + str.Trim() + "%' ";
                }
                string DepartmentWhere = string.Empty;
                foreach (string str in Department.Split(';'))
                {
                    DepartmentWhere += string.IsNullOrEmpty(DepartmentWhere)
                                           ? "Departmentname like '%" + str.Trim() + "%' "
                                           : "or Departmentname like '%" + str.Trim() + "%' ";
                }
                string AccountNameWhere = string.Empty;
                foreach (string str in AccountName.Split(';'))
                {
                    AccountNameWhere += string.IsNullOrEmpty(AccountNameWhere)
                                            ? "employeename like '%" + str.Trim() + "%' "
                                            : "or employeename like '%" + str.Trim() + "%' ";
                }
                string sql = "select distinct tposition.pkid "
                             + "from tposition "
                             + "where (" + NameWhere + ") "
                             + "and  (     '' = '" + Nature + "' "
                             + "     or"
                             + "      ("
                             + "         tposition.pkid in "
                             + "		 (	 select tpositionnaturerelationship.positionid "
                             + "			 from tpositionnature,tpositionnaturerelationship "
                             + "			 where tpositionnature.pkid = tpositionnaturerelationship.positionnatureid "
                             + "			 and (" + NatureWhere + ") "
                             + "		 ) "
                             + "     ) "
                             + " ) "
                             + "and  (     '' = '" + Department + "' "
                             + "     or"
                             + "      ("
                             + "         tposition.pkid in "
                             + "		 (	 select tpositiondeptrelationship.positionid "
                             + "			 from tDepartment,tpositiondeptrelationship "
                             + "			 where tDepartment.pkid = tpositiondeptrelationship.deptid "
                             + "			 and (" + DepartmentWhere + ") "
                             + "		 ) "
                             + "     ) "
                             + " ) "
                             + "and  (     '' = '" + AccountName + "' "
                             + "     or "
                             + "      ( "
                             + "         tposition.pkid in "
                             + "		 (	 select taccount.positionid "
                             + "			 from taccount "
                             + "			 where (" + AccountNameWhere + ") "
                             + "		 ) "
                             + "     ) "
                             + " ) ";
                //+ "and  (     '' = '" + Grade + "' "
                //+ "     or "
                //+ "      ( "
                //+ "         tposition.pkid in "
                //+ "		 (	 select tposition.pkid "
                //+ "			 from tpositiongrade,tposition "
                //+ "			 where tpositiongrade.pkid = tposition.levelid "
                //+ "				and  (" + GradeWhere + ") "
                //+ "		 ) "
                //+ "     ) "
                //+ " ) ";

                List<Position> Positions = BllInstance.PositionBllInstance.GetPositionByCondition(sql);
                for (int i = 0; i < Positions.Count; i++)
                {
                    Positions[i] = BllInstance.PositionBllInstance.GetPositionById(Positions[i].Id, _Operator);
                }
                positionViewModelUIs = PositionViewModel.Turn(Positions);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(positionViewModelUIs),
                              JsonConvert.SerializeObject(errors));
        }

        public bool IsReusable
        {
            get { return false; }
        }

    }


    public class PositionViewModel
    {
        private readonly Position _Postion;

        public PositionViewModel(Position postion)
        {
            _Postion = postion;
        }
        public PositionViewModel(PositionHistory postionhistory)
        {
            _Postion = postionhistory != null && postionhistory.Position != null
                           ? postionhistory.Position
                           : new Position();
            _OperateTime =
                postionhistory != null
                    ? postionhistory.OperationTime.ToShortDateString() + " " +
                      postionhistory.OperationTime.ToShortTimeString()
                    : string.Empty;
            _OperateName =
                postionhistory != null && postionhistory.Operator != null && postionhistory.Operator.Name != null
                    ? postionhistory.Operator.Name
                    : string.Empty;
            _HistoryID = postionhistory.PKID.ToString();
        }

        private readonly string _HistoryID = string.Empty;
        private readonly string _OperateName = string.Empty;
        private readonly string _OperateTime = string.Empty;
        public string HistoryID
        {
            get { return _HistoryID; }
        }

        public string OperateName
        {
            get { return _OperateName; }
        }
        public string OperateTime
        {
            get { return _OperateTime; }
        }
        public string PKID
        {
            get { return _Postion.Id.ToString(); }
        }

        public string Description
        {
            get { return _Postion.Description; }
        }
        public string Name
        {
            get { return _Postion.Name; }
        }
        public string Number
        {
            get { return _Postion.Number ?? string.Empty; }
        }
        public string Reviewer
        {
            get { return _Postion.Reviewer != null && _Postion.Reviewer.Name != null ? _Postion.Reviewer.Name : string.Empty; }
        }
        public string PositionStatus
        {
            get { return _Postion.PositionStatus.Id.ToString(); }
        }
        public string PositionStatusName
        {
            get { return _Postion.PositionStatus.Name; }
        }
        public string Version
        {
            get { return _Postion.Version ?? string.Empty; }
        }
        public string Commencement
        {
            get
            {
                return
                    _Postion.Commencement != DateTime.MinValue
                        ? _Postion.Commencement.ToShortDateString()
                        : string.Empty;
            }
        }
        public string Summary
        {
            get { return _Postion.Summary ?? string.Empty; }
        }
        public string MainDuties
        {
            get { return _Postion.MainDuties ?? string.Empty; }
        }
        public string ReportScope
        {
            get { return _Postion.ReportScope ?? string.Empty; }
        }
        public string ControlScope
        {
            get { return _Postion.ControlScope ?? string.Empty; }
        }
        public string Coordination
        {
            get { return _Postion.Coordination ?? string.Empty; }
        }
        public string Authority
        {
            get { return _Postion.Authority ?? string.Empty; }
        }
        public string Education
        {
            get { return _Postion.Education ?? string.Empty; }
        }
        public string ProfessionalBackground
        {
            get { return _Postion.ProfessionalBackground ?? string.Empty; }
        }
        public string WorkExperience
        {
            get { return _Postion.WorkExperience ?? string.Empty; }
        }
        public string Qualification
        {
            get { return _Postion.Qualification ?? string.Empty; }
        }
        public string Competence
        {
            get { return _Postion.Competence ?? string.Empty; }
        }
        public string OtherRequirements
        {
            get { return _Postion.OtherRequirements ?? string.Empty; }
        }
        public string KnowledgeAndSkills
        {
            get { return _Postion.KnowledgeAndSkills ?? string.Empty; }
        }
        public string RelatedProcesses
        {
            get { return _Postion.RelatedProcesses ?? string.Empty; }
        }
        public string ManagementSkills
        {
            get { return _Postion.ManagementSkills ?? string.Empty; }
        }
        public string AuxiliarySkills
        {
            get { return _Postion.AuxiliarySkills ?? string.Empty; }
        }

        public string GradeName
        {
            get { return _Postion.Grade != null && _Postion.Grade.Name != null ? _Postion.Grade.Name : string.Empty; }
        }

        public string Grade
        {
            get { return _Postion.Grade != null ? _Postion.Grade.Id.ToString() : string.Empty; }
        }

        public string Members
        {
            get
            {
                string ret = "";
                if (_Postion.Members != null)
                {
                    foreach (Account a in _Postion.Members)
                    {
                        ret += string.IsNullOrEmpty(ret) ? a.Name : (";" + a.Name);
                    }
                }
                return ret;
            }
        }
        public string Depts
        {
            get
            {
                string ret = "";
                if (_Postion.Departments != null)
                {
                    foreach (Department d in _Postion.Departments)
                    {
                        ret += string.IsNullOrEmpty(ret) ? d.Name : (";" + d.Name);
                    }
                }
                return ret;
            }
        }
        public string NatureIDs
        {
            get
            {
                string ret = "";
                if (_Postion.Nature != null)
                {
                    foreach (PositionNature pn in _Postion.Nature)
                    {
                        ret += string.IsNullOrEmpty(ret) ? pn.Pkid.ToString() : ("|" + pn.Pkid);
                    }
                }
                return ret;
            }
        }
        public string NatureNames
        {
            get
            {
                string ret = "";
                if (_Postion.Nature != null)
                {
                    foreach (PositionNature pn in _Postion.Nature)
                    {
                        ret += string.IsNullOrEmpty(ret) ? pn.Name : (";" + pn.Name);
                    }
                }
                return ret;
            }
        }

        public static List<PositionViewModel> Turn(List<Position> types)
        {
            List<PositionViewModel> list = new List<PositionViewModel>();
            foreach (Position t in types)
            {
                list.Add(new PositionViewModel(t));
            }
            return list;
        }
        public static List<PositionViewModel> Turn(List<PositionHistory> types)
        {
            List<PositionViewModel> list = new List<PositionViewModel>();
            foreach (PositionHistory t in types)
            {
                list.Add(new PositionViewModel(t));
            }
            return list;
        }
    }

}

