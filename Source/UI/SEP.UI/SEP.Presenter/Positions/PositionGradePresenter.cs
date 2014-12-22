using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using System.Web.UI.WebControls;
using SEP.HRMIS.Facade;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Utility;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IPositions;
using SEP.Model.Accounts;
using SEP.IBll;
using SEP.Model.Positions;

namespace SEP.Presenter.Positions
{
    public class PositionGradePresenter : BasePresenter
    {
        private IPositionGradeView _ItsView;
        private Account _LoginUser;

        public PositionGradePresenter(IPositionGradeView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
        }


        public void InitView(bool isPostback)
        {
            AttachViewEvent();
            _ItsView.OperationTitle = "职位等级维护";
            _ItsView.Message = String.Empty;
            if (!isPostback)
            {
                _ItsView.PositionGradeListSrc = BllInstance.PositionBllInstance.GetAllPositionGrade();
                new PositionGradeDataBinder(_ItsView).DataBind();
            }
        }

        private void AttachViewEvent()
        {
            PositionGradeEditor itemEditor = new PositionGradeEditor(_ItsView);
            _ItsView.ActionButtonEvent += SaveEvent;
            _ItsView.CancelButtonEvent += CancelEvent;
            _ItsView.ddlCardPropertyParaParaChangedForDeleteEvent += itemEditor.ForDeleteEvent;
            _ItsView.ddlCardPropertyParaParaChangedForAddAtEvent += itemEditor.ForAddAtEvent;
            _ItsView.ddlCardPropertyParaParaChangedForUpEvent += itemEditor.ForUpEvent;
            _ItsView.ddlCardPropertyParaParaChangedForDownEvent += itemEditor.ForDownEvent;
            _ItsView.InitEvent += _ItsView_InitEvent;
        }

        protected void _ItsView_InitEvent(LinkButton linkButton, int id)
        {
            if(HasUsing(id))
            {
                linkButton.Text = "<img src=../../image/file_cancel_enable.gif border=0>";
                linkButton.Enabled = false;
            }
        }

        private static bool HasUsing(int id)
        {
            if(MasterPagePresenter.HasHrmisSystem)
            {
                IEmployeeFacade iEmployeeFacade = new EmployeeFacade();
                List<Employee> employeeList = iEmployeeFacade.GetAllEmployeeBasicInfoWithOutLoadAccount();
                foreach (Employee employee in employeeList)
                {
                    if (employee.Account != null && employee.Account.Position != null &&
                        employee.Account.Position.Grade != null)
                    {
                        if (employee.Account.Position.Grade.Id == id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void SaveEvent()
        {
            try
            {
                List<PositionGrade> objs = CloneSrc(_ItsView.PositionGradeListSrc);
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    BllInstance.PositionBllInstance.SavePositionGradeList(objs,
                                                                          _ItsView.DelPositionGradeId, _LoginUser);
                    if (CompanyConfig.HasHrmisSystem)
                    {
                        IPositionHistoryFacade hrmisPositionHistoryFacade =
                            new PositionHistoryFacade();
                        hrmisPositionHistoryFacade.AddPositionHistoryFacade(_LoginUser);
                    }
                    ts.Complete();
                }
                _ItsView.Message = "保存成功！";
                _ItsView.PositionGradeListSrc = objs;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }

        private void CancelEvent()
        {
            _ItsView.PositionGradeListSrc = BllInstance.PositionBllInstance.GetAllPositionGrade();
            new PositionGradeDataBinder(_ItsView).DataBind();
        }

        private List<PositionGrade> CloneSrc(List<PositionGrade> src)
        {
            List<PositionGrade> result = new List<PositionGrade>();

            foreach (PositionGrade grade in src)
            {
                PositionGrade temp = new PositionGrade();
                temp.Id = grade.Id;
                temp.Name = grade.Name;
                temp.ParameterID = grade.ParameterID;
                temp.Sequence = grade.Sequence;
                temp.Description = grade.Description;
                result.Add(temp);
            }
            return result;
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
