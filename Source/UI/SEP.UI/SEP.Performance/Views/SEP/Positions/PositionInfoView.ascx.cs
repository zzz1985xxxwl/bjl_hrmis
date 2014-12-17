using System;
using System.Web.UI;
using SEP.Presenter.IPresenter.IPositions;

namespace SEP.Performance.Views.SEP.Positions
{
    public partial class PositionInfoView : UserControl, IPositionInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IPositionListView PositionListView
        {
            get { return null; }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IPositionView PositionView
        {
            get { return PositionView1; }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool PositionViewVisible
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }

            set
            {
                if (value)
                {
                    mpePosition.Show();
                }

                else
                {
                    mpePosition.Hide();
                }
            }
        }

        #region IPositionInfoView ≥…‘±


        public string divMPEPositionClientID
        {
            get
            {
                return divMPEPosition.ClientID; 
            }
        }

        #endregion
    }
}