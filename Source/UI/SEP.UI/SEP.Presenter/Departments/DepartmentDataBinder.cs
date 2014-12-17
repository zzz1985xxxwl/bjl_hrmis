using SEP.IBll;
//using SEP.IBll.Accounts;
//using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IDepartments;

namespace SEP.Presenter.Departments
{
    public class DepartmentDataBinder : BasePresenter
    {
        private readonly IDepartmentView _ItsView;

        public DepartmentDataBinder(IDepartmentView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
        }

        public bool DataBind(string leaveRequestTypeId)
        {
            int id;
            if (!int.TryParse(leaveRequestTypeId, out id))
            {
                return SetViewUnable();
            }

            Department theDataToBind = BllInstance.DepartmentBllInstance.GetDepartmentById(id, LoginUser);
            if (theDataToBind != null)
            {
                _ItsView.DepartmentID = theDataToBind.Id.ToString();
                _ItsView.DepartmentName = theDataToBind.Name;
                _ItsView.LeaderName = BllInstance.AccountBllInstance.GetAccountById(theDataToBind.Leader.Id).Name;
                _ItsView.Address = theDataToBind.Address;
                _ItsView.Phone = theDataToBind.Phone;
                _ItsView.Fax = theDataToBind.Fax;
                _ItsView.Others = theDataToBind.Others;
                _ItsView.Description = theDataToBind.Description;
                if (theDataToBind.FoundationTime!=null)
                    _ItsView.FoundationTime = theDataToBind.FoundationTime.ToString();
                return true;
            }
            return SetViewUnable();
        }

        private bool SetViewUnable()
        {
            _ItsView.Message = "≥ı ºªØ ß∞‹";
            return false;
        }

        public override void Initialize(bool isPostBack)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }
    }
}