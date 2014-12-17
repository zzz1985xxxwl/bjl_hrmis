using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.Model.Positions;

namespace SEP.Performance.Views.HRMIS.AssessManagement
{
    public partial class ChosePositionView : UserControl, IChosePostionView
    {
        private readonly string _PositionRightViewStateName = "PositionRight";
        private readonly string _PositionLeftViewStateName = "PositionLeft";
        private int _PositionID;
        private string _PositionNameForRight;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (InitView != null)
                {
                    InitView(null, null);
                }
            }
        }

        public int PositionID
        {
            get { return _PositionID; }
            set { _PositionID = value; }
        }

        public string PositionNameForRight
        {
            get { return _PositionNameForRight; }
            set { _PositionNameForRight = value; }
        }

        public event EventHandler ToRightEvent;
        public event EventHandler ToLeftEvent;
        public event EventHandler InitView;
        public event EventHandler AttachAccountAjax;
        public List<Position> PositionRight
        {
            get { return ViewState[_PositionRightViewStateName] as List<Position>; }
            set
            {
                ViewState[_PositionRightViewStateName] = value;
                PositionSelected.DataSource = value;
                PositionSelected.DataValueField = "Id";
                PositionSelected.DataTextField = "Name";
                PositionSelected.DataBind();
            }
        }

        public List<Position> PositionLeft
        {
            get { return ViewState[_PositionLeftViewStateName] as List<Position>; }
            set
            {
                ViewState[_PositionLeftViewStateName] = value;
                AllPosition.DataSource = value;
                AllPosition.DataValueField = "Id";
                AllPosition.DataTextField = "Name";
                AllPosition.DataBind();
            }
        }

        protected void ToRight_Click(object sender, EventArgs e)
        {
            foreach (int i in AllPosition.GetSelectedIndices())
            {
                PositionID = Convert.ToInt32(AllPosition.Items[i].Value);
                PositionNameForRight = AllPosition.Items[i].Text;
                ToRightEvent(this, EventArgs.Empty);
            }
            BindPositionSelected();
        }

        protected void ToLeft_Click(object sender, EventArgs e)
        {
            foreach (int i in PositionSelected.GetSelectedIndices())
            {
                PositionID = Convert.ToInt32(PositionSelected.Items[i].Value);
                ToLeftEvent(this, EventArgs.Empty);
            }
            BindPositionSelected();
        }
        private void BindPositionSelected()
        {
            PositionSelected.DataSource = PositionRight;
            PositionSelected.DataValueField = "Id";
            PositionSelected.DataTextField = "Name";
            PositionSelected.DataBind();
            if (AttachAccountAjax != null)
            {
                AttachAccountAjax(this, EventArgs.Empty);
            }
        }

    }
}