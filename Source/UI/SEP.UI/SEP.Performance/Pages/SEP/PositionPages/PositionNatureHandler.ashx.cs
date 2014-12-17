using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using SEP.Model.Positions;
using SEP.Model.Accounts;
using System.Collections.Generic;
using SEP.IBll;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace SEP.Performance.Pages.SEP.PositionPages
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class PositionNatureHandler : IHttpHandler, IRequiresSessionState 
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
                    case "AddPositionNature":
                        AddPositionNature();
                        break;
                    case "UpdatePositionNature":
                         UpdatePositionNature();
                        break;
                    case "DeletePositionNature":
                        DeletePositionNature();
                        break;
                    case "GetPositionNatureByID":
                         GetPositionNatureByID();
                        break;
                    case "SearchPositionNature":
                        SearchPositionNature();
                        break;
                    default:
                        break;
                }
            }
            context.Response.Write(_ResponseString);
            context.Response.End();

        }

        private void SearchPositionNature()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            List<PositionNatureViewModel> positionNatureViewModel = new List<PositionNatureViewModel>();
            try
            {
                string Name = _Context.Request.Params["Name"];
                if (Name== null)
                {
                    return;
                }
                List<PositionNature> positionNatures = BllInstance.PositionBllInstance.GetPositionNatureListByName(Name);
                for (int i = 0; i < positionNatures.Count; i++)
                {
                    PositionNatureViewModel pnvm = new PositionNatureViewModel();
                    pnvm.PKID = positionNatures[i].Pkid.ToString() ;
                    pnvm.Name = positionNatures[i].Name;
                    pnvm.Description = positionNatures[i].Description;
                    positionNatureViewModel.Add(pnvm);
                }
              
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(positionNatureViewModel),
                              JsonConvert.SerializeObject(errors));
        }


        private void GetPositionNatureByID()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            PositionNatureViewModel positionNatureViewModel = new  PositionNatureViewModel();
            try
            {
                string pkid = _Context.Request.Params["PKID"];
                if (pkid == null)
                {
                    return;
                }
                PositionNature positionNature = BllInstance.PositionBllInstance.GetPositionNatureById(Convert.ToInt32(pkid));
                if (positionNature != null)
                {

                    positionNatureViewModel.PKID = positionNature.Pkid.ToString();
                    positionNatureViewModel.Name = positionNature.Name;
                    positionNatureViewModel.Description = positionNature.Description;
                }
              

            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString =
                string.Format("{{\"itemList\":{0},\"error\":{1}}}", JsonConvert.SerializeObject(positionNatureViewModel),
                              JsonConvert.SerializeObject(errors));
        }

        private void DeletePositionNature()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                   BllInstance.PositionBllInstance.DeletePositionNature(Convert.ToInt32(_Context.Request.Params["PKID"]));
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("lblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }


        private void UpdatePositionNature()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                PositionNature positionNature =
                   BllInstance.PositionBllInstance.GetPositionNatureById(
                        Convert.ToInt32(_Context.Request.Params["PKID"]));
                positionNature.Name = _Context.Request.Params["Name"];
                positionNature.Description = _Context.Request.Params["Description"];
                BllInstance.PositionBllInstance.UpdatePositionNature(positionNature);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        private void AddPositionNature()
        {
            List<Performance.Error> errors = new List<Performance.Error>();
            try
            {
                   PositionNature positionNature = new  PositionNature();
                   positionNature.Description = _Context.Request.Params["Description"];
                   positionNature.Name = _Context.Request.Params["Name"];
                   BllInstance.PositionBllInstance.CreatePositionNature(positionNature);
            }
            catch (Exception e)
            {
                errors.Add(new Performance.Error("dialoglblMessage", e.Message));
            }
            _ResponseString = string.Format("{{\"error\":{0}}}", JsonConvert.SerializeObject(errors));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }


    public class PositionNatureViewModel
    {
       

        public PositionNatureViewModel()
        {
        
        }

        private string _PKID = string.Empty;
        private string _Name = string.Empty;
        private  string _Description = string.Empty;
        public string PKID
        {
            get
            {
                return _PKID;
            }
            set
            {
                _PKID = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        
    }
}
