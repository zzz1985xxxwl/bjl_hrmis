using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.EmployInformation.FileCargosInformations.FileCargoInfo
{
    public class UpdateFileCargoPresenter
    {
        private readonly IFileCargoView _ItsView;
        private readonly string _Id;
        private readonly IFileCargoFacade _IFileCargoFacade = InstanceFactory.CreateFileCargoFacade();
        public UpdateFileCargoPresenter(IFileCargoView itsView, string id)
        {
            _Id = id;
            _ItsView = itsView;
            AttachViewEvent();
        }

        private void AttachViewEvent()
        {
            _ItsView.BtnActionEvent += UpdateFileCargoEvent;
        }

        public void InitView()
        {
            //初始化
            _ItsView.Id = string.Empty;
            _ItsView.Title = EmployeePresenterUtilitys._DimissionInfoFileCargoUpdate;
            _ItsView.FileCargoNameSource = FileCargoName.GetAll();
            //数据绑定
            int id;
            if (!int.TryParse(_Id, out id))
            {
                return;
            }
            FileCargo theObject = _IFileCargoFacade.GetFileCargoByFileCargoID(id);
            if (theObject != null)
            {
                _ItsView.Id = theObject.FileCargoID.ToString();
                _ItsView.FileCargoName = theObject.Name.Id.ToString();
                _ItsView.Remark = theObject.Remark;
            }
        }

        //private FileCargo FindFileCargoById(int id)
        //{
        //    if (_ItsView.FileCargoDataSource != null)
        //    {
        //        foreach (FileCargo fc in _ItsView.FileCargoDataSource)
        //        {
        //            if (fc.HashCode.Equals(id))
        //            {
        //                return fc;
        //            }
        //        }
        //    }
        //    return null;
        //}

        public void UpdateFileCargoEvent()
        {
            int theId;
            if (!int.TryParse(_Id, out theId))
            {
                return;
            }

            FileCargo theObject = new FileCargo(theId, FileCargoName.FindFileCargoName(int.Parse(_ItsView.FileCargoName)), _ItsView.Remark,_ItsView.File,new Account(_ItsView.AccountID,"",""));
           _IFileCargoFacade.UpdateFileCargo(theObject);
            _ItsView.ActionSuccess = true;
        }
    }
}