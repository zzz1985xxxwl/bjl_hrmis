using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Performance.Pages.SEP.PositionPages;

namespace SEP.Performance.Pages.HRMIS.PositionPages
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class PositionApplicationHandler : IHttpHandler, IRequiresSessionState 
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
                    case "AddPositionApp":
                        AddPositionApp();
                        break;
                    case "UpdatePositionApp":
                        UpdatePositionApp();
                        break;
                    case "DeletePositionApp":
                        DeletePositionApp();
                        break;
                    case "GetPositionAppByID":
                        GetPositionAppByID();
                        break;
                    case "SearchMyPositionApp":
                        SearchMyPositionApp();
                        break;
                    case "SearchPositionApping":
                        SearchPositionApping();
                        break;
                    case "SearchPositionApped":
                        SearchPositionApped();
                        break;
                    case "ApprovePositionApp":
                        ApprovePositionApp();
                        break;
                    case "GetPositionAppHistoryByID":
                        GetPositionAppHistoryByID();
                        break;
                    case "SearchPositionApp":
                        SearchPositionApp();
                        break;
                    case "CancelPositionApp":
                        CancelPositionApp();
                        break;
                    case "GetPositionByName":
                        GetPositionByName();
                        break;
                    default:
                        break;
                }
            }

            context.Response.Write(_ResponseString);
            context.Response.End();
        }

        private void GetPositionByName()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            PositionViewModel pvm = null;
            List<Position> authpositions = BllInstance.PositionBllInstance.GetPositionByLeaderID(_Operator.Id);
            try
            {
                Position p =
                    BllInstance.PositionBllInstance.GetPositionByName(_Context.Request.Params["Name"], _Operator);
                if(Position.FindPosition(authpositions, p.Id) == null)
                {
                    throw new Exception("你没有权限对 "+ _Context.Request.Params["Name"] +" 申请职位变更。");
                }
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

        private void CancelPositionApp()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                InstanceFactory.CreatePositionApplicationFacade().CancelPositionApplication(
                    Convert.ToInt32(_Context.Request.Params["Pkid"]), _Operator.Id, RequestStatus.Cancelled,
                    _Operator.Name + "取消申请");
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void SearchPositionApp()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<PositionApplicationViewModel> positionViewModelUIs = new List<PositionApplicationViewModel>();
            try
            {
                List<PositionApplication> PositionApplications =
                    InstanceFactory.CreatePositionApplicationFacade().GetPositionApplicationByCondition(
                        _Context.Request.Params["Name"], _Context.Request.Params["ApplicantName"],
                        Convert.ToInt32(_Context.Request.Params["IsPublish"]),
                        Convert.ToInt32(_Context.Request.Params["Status"]));
                positionViewModelUIs = PositionApplicationViewModel.Turn(PositionApplications);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(positionViewModelUIs),
                              JsonConvert.SerializeObject(errors));
        }

        private void GetPositionAppHistoryByID()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<PositionApplicationViewModel> positionViewFlowModelUIs = new List<PositionApplicationViewModel>();
            try
            {
                List<PositionApplicationFlow> flow =
                    InstanceFactory.CreatePositionApplicationFacade().GetPositionApplicationFlowByPositionApplicationID(
                        Convert.ToInt32(_Context.Request.Params["Pkid"]));
                positionViewFlowModelUIs = PositionApplicationViewModel.Turn(flow);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(positionViewFlowModelUIs),
                              JsonConvert.SerializeObject(errors));
        }

        private void ApprovePositionApp()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                int i;
                RequestStatus rs;
                if (!string.IsNullOrEmpty(_Context.Request.Params["dialogRequestStatus"])
                    && int.TryParse(_Context.Request.Params["dialogRequestStatus"], out i))
                {
                    rs = RequestStatus.FindRequestStatus(i);
                }
                else
                {
                    rs = RequestStatus.New;
                }
                PositionApplication PositionApplication =
                    InstanceFactory.CreatePositionApplicationFacade().GetPositionApplicationByPKID(
                        Convert.ToInt32(_Context.Request.Params["Pkid"]));
                PositionApplication.Position = PositionApplication.Position ?? new Position();
                PositionApplication.Position.Departments = new List<Department>();
                PositionApplication.Position.Members = new List<Account>();
                PositionApplication.Position.Nature = new List<PositionNature>();
                PositionDataBind(PositionApplication.Position);

                InstanceFactory.CreatePositionApplicationFacade().ApprovePositionApplication(PositionApplication,
                                                                                             _Operator.Id, rs,
                                                                                             _Operator.Name + "审核：" +
                                                                                             rs.Name);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void SearchPositionApped()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<PositionApplicationViewModel> positionViewModelUIs = new List<PositionApplicationViewModel>();
            try
            {
                List<PositionApplication> PositionApplications =
                    InstanceFactory.CreatePositionApplicationFacade().GetPositionApplicationConfirmHistoryByOperatorID(
                        _Operator.Id, _Context.Request.Params["ApplicantName"]);
                positionViewModelUIs = PositionApplicationViewModel.Turn(PositionApplications);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(positionViewModelUIs),
                              JsonConvert.SerializeObject(errors));
        }

        private void SearchPositionApping()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<PositionApplicationViewModel> positionViewModelUIs = new List<PositionApplicationViewModel>();
            try
            {
                List<PositionApplication> PositionApplications =
                    InstanceFactory.CreatePositionApplicationFacade().GetConfirmPositionApplication(_Operator.Id);
                positionViewModelUIs = PositionApplicationViewModel.Turn(PositionApplications);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(positionViewModelUIs),
                              JsonConvert.SerializeObject(errors));
        }

        private void SearchMyPositionApp()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<PositionApplicationViewModel> positionViewModelUIs = new List<PositionApplicationViewModel>();
            try
            {
                List<PositionApplication> PositionApplications =
                    InstanceFactory.CreatePositionApplicationFacade().GetPositionApplicationByAccountID(_Operator.Id);
                positionViewModelUIs = PositionApplicationViewModel.Turn(PositionApplications);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(positionViewModelUIs),
                              JsonConvert.SerializeObject(errors));
        }

        private void GetPositionAppByID()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            PositionApplicationViewModel pavm = null;
            try
            {
                PositionApplication pa =
                    InstanceFactory.CreatePositionApplicationFacade().GetPositionApplicationByPKID(
                        Convert.ToInt32(_Context.Request.Params["Pkid"]));
                pavm = new PositionApplicationViewModel(pa);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"item\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(pavm),
                                            JsonConvert.SerializeObject(errors));
        }

        private void DeletePositionApp()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                InstanceFactory.CreatePositionApplicationFacade().DeletePositionApplication(
                    Convert.ToInt32(_Context.Request.Params["Pkid"]));
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void UpdatePositionApp()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                PositionApplication PositionApplication =
                    InstanceFactory.CreatePositionApplicationFacade().GetPositionApplicationByPKID(
                        Convert.ToInt32(_Context.Request.Params["Pkid"]));
                int i;
                if (!string.IsNullOrEmpty(_Context.Request.Params["dialogRequestStatus"])
                    && int.TryParse(_Context.Request.Params["dialogRequestStatus"], out i))
                {
                    PositionApplication.Status = RequestStatus.FindRequestStatus(i);
                }
                else
                {
                    PositionApplication.Status = RequestStatus.New;
                }
                PositionApplication.IsPublish = 0;
                PositionApplication.Position = PositionApplication.Position ?? new Position();
                PositionApplication.Position.Departments = new List<Department>();
                PositionApplication.Position.Members = new List<Account>();
                PositionApplication.Position.Nature = new List<PositionNature>();
                PositionDataBind(PositionApplication.Position);
                if (PositionApplication.Status.Id == RequestStatus.Submit.Id)
                {
                    InstanceFactory.CreatePositionApplicationFacade().UpdateSubmitPositionApplication(PositionApplication);
                }
                else
                {
                    InstanceFactory.CreatePositionApplicationFacade().UpdatePositionApplication(PositionApplication);
                }
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void AddPositionApp()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                PositionApplication positionApplication = new PositionApplication();

                int i;
                if (!string.IsNullOrEmpty(_Context.Request.Params["dialogAppType"])
                    && int.TryParse(_Context.Request.Params["dialogAppType"], out i))
                {
                    positionApplication.Type = AppType.FindAppType(i);
                }
                else
                {
                    positionApplication.Type = AppType.All;
                }
                if (!string.IsNullOrEmpty(_Context.Request.Params["dialogRequestStatus"])
                    && int.TryParse(_Context.Request.Params["dialogRequestStatus"], out i))
                {
                    positionApplication.Status = RequestStatus.FindRequestStatus(i);
                }
                else
                {
                    positionApplication.Status = RequestStatus.New;
                }
                positionApplication.IsPublish = 0;
                positionApplication.Position = new Position();
                PositionDataBind(positionApplication.Position);
                positionApplication.Account = _Operator;
                if (positionApplication.Status.Id == RequestStatus.Submit.Id)
                {
                    InstanceFactory.CreatePositionApplicationFacade().SubmitPositionApplication(positionApplication);
                }
                else
                {
                    InstanceFactory.CreatePositionApplicationFacade().AddPositionApplication(positionApplication);
                }
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void PositionDataBind(Position position)
        {
            int i;
            if (!string.IsNullOrEmpty(_Context.Request.Params["dialogPositionID"])
                && int.TryParse(_Context.Request.Params["dialogPositionID"], out i))
            {
                position.Id = i;
            }
            else
            {
                position.Id = 0;
            }

            position.Name = _Context.Request.Params["dialogName"] ?? string.Empty;
            position.Description = _Context.Request.Params["dialogDescription"] ?? string.Empty;
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class PositionApplicationViewModel
    {
        private readonly PositionApplication _PositionApplication;
        private readonly Position _Position;
        private string _PKID;
        public string PKID
        {
            get { return _PKID ; }
        }
        public PositionApplicationViewModel(PositionApplication positionApplication)
        {
            _PositionApplicationFlow =
                new PositionApplicationFlow(0, 0, new Account(-9, "", ""), DateTime.Now, RequestStatus.Approving, "",
                                            null);
            _PositionApplication = positionApplication;
            _PKID = positionApplication.PKID.ToString();
            _Position = _PositionApplication.Position ?? new Position();
        }



        public string PositionID
        {
            get { return _PositionApplication != null && _PositionApplication.Position != null ? _PositionApplication.Position.Id.ToString() : "0"; }
        }

        public string Description
        {
            get { return _Position != null ? _Position.Description : ""; }
        }
        public string Name
        {
            get { return _Position != null ? _Position.Name : ""; }
        }
        public string Number
        {
            get { return _Position != null && _Position.Number != null ? string.Empty : ""; }
        }
        public string Reviewer
        {
            get { return _Position != null && _Position.Reviewer != null && _Position.Reviewer.Name != null ? _Position.Reviewer.Name : string.Empty; }
        }
        public string PositionStatus
        {
            get { return _Position != null ? _Position.PositionStatus.Id.ToString() : ""; }
        }
        public string PositionStatusName
        {
            get { return _Position != null ? _Position.PositionStatus.Name : ""; }
        }
        public string Version
        {
            get { return _Position != null && _Position.Version != null ? _Position.Version : ""; }
        }
        public string Commencement
        {
            get
            {
                return _Position != null && 
                    _Position.Commencement != DateTime.MinValue
                        ? _Position.Commencement.ToShortDateString()
                        : string.Empty;
            }
        }
        public string Summary
        {
            get { return _Position != null && _Position.Summary != null ? _Position.Summary : ""; }
        }
        public string MainDuties
        {
            get { return _Position != null && _Position.MainDuties != null ? _Position.MainDuties : ""; }
        }
        public string ReportScope
        {
            get { return _Position != null && _Position.ReportScope != null ? _Position.ReportScope : ""; }
        }
        public string ControlScope
        {
            get { return _Position != null && _Position.ControlScope != null ? _Position.ControlScope : ""; }
        }
        public string Coordination
        {
            get { return _Position != null && _Position.Coordination != null ? _Position.Coordination : ""; }
        }
        public string Authority
        {
            get { return _Position != null && _Position.Authority != null ? _Position.Authority : ""; }
        }
        public string Education
        {
            get { return _Position != null && _Position.Education != null ? _Position.Education : ""; }
        }
        public string ProfessionalBackground
        {
            get { return _Position != null && _Position.ProfessionalBackground != null ? _Position.ProfessionalBackground : ""; }
        }
        public string WorkExperience
        {
            get { return _Position != null && _Position.WorkExperience != null ? _Position.WorkExperience : ""; }
        }
        public string Qualification
        {
            get { return _Position != null && _Position.Qualification != null ? _Position.Qualification : ""; }
        }
        public string Competence
        {
            get { return _Position != null && _Position.Competence != null ? _Position.Competence : ""; }
        }
        public string OtherRequirements
        {
            get { return _Position != null && _Position.OtherRequirements != null ? _Position.OtherRequirements : ""; }
        }
        public string KnowledgeAndSkills
        {
            get { return _Position != null && _Position.KnowledgeAndSkills != null ? _Position.KnowledgeAndSkills : ""; }
        }
        public string RelatedProcesses
        {
            get { return _Position != null && _Position.RelatedProcesses != null ? _Position.RelatedProcesses : ""; }
        }
        public string ManagementSkills
        {
            get { return _Position != null && _Position.ManagementSkills != null ? _Position.ManagementSkills : ""; }
        }
        public string AuxiliarySkills
        {
            get { return _Position != null && _Position.AuxiliarySkills != null ? _Position.AuxiliarySkills : ""; }
        }

        public string GradeName
        {
            get { return _Position != null && _Position.Grade != null && _Position.Grade.Name != null ? _Position.Grade.Name : string.Empty; }
        }

        public string Grade
        {
            get { return _Position != null && _Position.Grade != null ? _Position.Grade.Id.ToString() : string.Empty; }
        }
        public string Members
        {
            get
            {
                string ret = "";
                if (_Position != null && _Position.Members != null)
                {
                    foreach (Account a in _Position.Members)
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
                if (_Position != null && _Position.Departments != null)
                {
                    foreach (Department d in _Position.Departments)
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
                if (_Position != null && _Position.Nature != null)
                {
                    foreach (PositionNature pn in _Position.Nature)
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
                if (_Position != null && _Position.Nature != null)
                {
                    foreach (PositionNature pn in _Position.Nature)
                    {
                        ret += string.IsNullOrEmpty(ret) ? pn.Name : (";" + pn.Name);
                    }
                }
                return ret;
            }
        }
        public string AppTypeName
        {
            get
            {
                return _PositionApplication!=null ?_PositionApplication.Type.Name:"";
            }
        }
        public string PublishLink
        {
            get
            {
                return
                    _PositionApplication.Status.Id == RequestStatus.ApprovePass.Id ||
                    _PositionApplication.Status.Id == RequestStatus.ApproveCancelFail.Id
                        ? "发布"
                        : "";
            }
        }
        public string StatusName
        {
            get
            {
                return _PositionApplication!=null?_PositionApplication.Status.Name:"";
            }
        }
        public string StatusID
        {
            get
            {
                return _PositionApplication!=null?_PositionApplication.Status.Id.ToString():"";
            }
        }
        public string DeleteLink
        {
            get
            {
                return
                    _PositionApplication.Status.Id != RequestStatus.New.Id
                        ? ("<a onclick=\"Delete(confirm('申请已提交审核，确定要删除吗？')," + PKID + ")\">删除</a>")
                        : ("<a onclick=\"Delete(confirm('确定要删除吗？')," + PKID + ")\">删除</a>");
            }
        }
        public string CancelLink
        {
            get
            {
                return _PositionApplication.Status.Id == RequestStatus.Submit.Id
                       || _PositionApplication.Status.Id == RequestStatus.Approving.Id
                       || _PositionApplication.Status.Id == RequestStatus.ApprovePass.Id
                           ? ("<a onclick=\"Cancel(confirm('申请已进入审核流程，确定要取消吗？')," + PKID + ")\">取消</a>")
                           : "<a disabled=\"disabled\">取消</a>";
            }
        }
        public string IsPublish
        {
            get
            {
                return _PositionApplication!=null?(_PositionApplication.IsPublish == 0 ? "未发布" : "已发布"):"";
            }
        }

        public string ApplicantName
        {
            get
            {
                return _PositionApplication!=null&&
                    _PositionApplication.Account != null && _PositionApplication.Account.Name != null
                        ? _PositionApplication.Account.Name
                        : "";
            }
        }
        public static List<PositionApplicationViewModel> Turn(List<PositionApplication> types)
        {
            List<PositionApplicationViewModel> list = new List<PositionApplicationViewModel>();
            foreach (PositionApplication t in types)
            {
                list.Add(new PositionApplicationViewModel(t));
            }
            return list;
        }
  
        private readonly PositionApplicationFlow _PositionApplicationFlow;

        public PositionApplicationViewModel(PositionApplicationFlow positionApplicationFlow)
        {
            _PositionApplicationFlow = positionApplicationFlow;
            _PositionApplication = _PositionApplicationFlow.Detail ?? new PositionApplication();
            _Position = _PositionApplication.Position ?? new Position();

            _PKID = _PositionApplicationFlow.PKID.ToString();
        }
        public string OperationTime
        {
            get
            {
                return _PositionApplicationFlow!=null?
                    _PositionApplicationFlow.OperationTime.ToShortDateString() + " " +
                    _PositionApplicationFlow.OperationTime.ToShortTimeString():"";
            }
        }

        public string Remark
        {
            get
            {
                return _PositionApplicationFlow!=null?_PositionApplicationFlow.Remark:"";
            }
        }

        public string FlowStatusName
        {
            get
            {
                return _PositionApplicationFlow!=null?_PositionApplicationFlow.Status.Name:"";
            }
        }

        public string OperatorName
        {
            get
            {
                return _PositionApplicationFlow!=null&&
                    _PositionApplicationFlow.Account != null && _PositionApplicationFlow.Account.Name != null
                        ? _PositionApplicationFlow.Account.Name
                        : "";
            }
        }
        public static List<PositionApplicationViewModel> Turn(List<PositionApplicationFlow> types)
        {
            List<PositionApplicationViewModel> list = new List<PositionApplicationViewModel>();
            foreach (PositionApplicationFlow t in types)
            {
                list.Add(new PositionApplicationViewModel(t));
            }
            return list;
        }
    }
}
