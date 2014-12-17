using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SEP.HRMIS.Presenter.IPresenter.IParamter.IFBQuesType;

namespace SEP.Performance.Views.HRMIS.FBQuesType
{
    public partial class FBQuesTypeInfoView : UserControl,IFBQuesTypeInfoView
    {
        #region IFBQuesTypeInfoView ≥…‘±

        public IFBQuesTypeListView FBQuesTypeListView
        {
            get
            {
                return FBQuesTypeListView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IFBQuesTypeView FBQuesTypeView
        {
            get
            {
                return FBQuesTypeView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool FBQuesTypeViewVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if (value)
                {
                    mpeFBQuesType.Show();
                }

                else
                {
                    mpeFBQuesType.Hide();
                }
            }
        }

        #endregion
    }
}