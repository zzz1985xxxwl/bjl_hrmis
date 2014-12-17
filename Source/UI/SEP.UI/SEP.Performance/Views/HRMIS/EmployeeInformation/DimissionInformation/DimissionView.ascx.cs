using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;

namespace SEP.Performance.Views.EmployeeInformation.DimissionInformation
{
    public partial class DimissionView : System.Web.UI.UserControl,IDimissionInfoView
    {

        #region IDimissionInfoView ≥…‘±

        public IDimissionBasicView DimmissionBasicView
        {
            get
            {
                return DimissionBasicView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IFileCargoView FileCargoView
        {
            get
            {
                return FileCargosView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool FileCargoViewVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if (value)
                {
                    ModalPopupExtender1.Show();
                }
                else
                {
                    ModalPopupExtender1.Hide();
                }
            }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            DimissionBasicView1.SendFileCargo = SendFileCargos;
        }

        private void SendFileCargos(List<FileCargo> filecargos)
        {
            foreach (FileCargo cargo in filecargos)
            {
                cargo.HashCode =cargo.GetHashCode();
            }
            FileCargosView1.FileCargoDataSource = filecargos;
        }
    }

}