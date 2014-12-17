using System;
using System.Collections.Generic;
using System.Web.UI;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;

namespace SEP.Performance.Views.HRMIS.Train
{
    public partial class ChooseSkillView : UserControl, IChooseSkillView
    {
        private int _SkillID;
        private string _SkillNameForRight;
        private string _SkillRightSessionName;
        private string _SkillLeftSessionName;



        public int SkillID
        {
            get { return _SkillID; }
            set { _SkillID = value; }
        }

        public string SkillName
        {
            get { return txtSkillName.Text; }
            set { }
        }

        public int SkillTypeID
        {
            get { return Convert.ToInt32(listSkillType.SelectedValue); }
            set { }
        }

        public string SkillNameForRight
        {
            get { return _SkillNameForRight; }
            set { _SkillNameForRight = value; }
        }

        public List<hrmisModel.Skill> SkillRight
        {
            get
            {
                return ViewState[SkillRightSessionName] as List<hrmisModel.Skill>;
                // return Session[SkillRightSessionName] as List<Model.Skill>;
            }
            set
            {
                ViewState[SkillRightSessionName] = value;
                //Session[SkillRightSessionName] = value;
                SkillToSend.DataSource = value;
                SkillToSend.DataValueField = "SkillID";
                SkillToSend.DataTextField = "SkillName";
                SkillToSend.DataBind();
            }
        }

        public List<hrmisModel.Skill> SkillLeft
        {
            get
            {
                return ViewState[SkillLeftSessionName] as List<hrmisModel.Skill>;
                //return Session[SkillLeftSessionName] as List<Model.Skill>; 
            }
            set
            {
                ViewState[SkillLeftSessionName] = value;
                //Session[SkillLeftSessionName] = value;
                SkillSearched.DataSource = value;
                SkillSearched.DataValueField = "SkillID";
                SkillSearched.DataTextField = "SkillName";
                SkillSearched.DataBind();
            }
        }

        public List<hrmisModel.SkillType> SkillTypeList
        {
            get { return null; }
            set
            {
                listSkillType.Items.Clear();
                listSkillType.Items.Add("");
                listSkillType.Items[0].Value = "-1";
                int i = 1;
                if (value != null)
                {
                    foreach (hrmisModel.SkillType skillType in value)
                    {
                        listSkillType.Items.Add(skillType.Name);
                        listSkillType.Items[i].Value = skillType.ParameterID.ToString();
                        i++;
                    }
                }
            }
        }

        public string SkillRightSessionName
        {
            get { return _SkillRightSessionName; }
            set { _SkillRightSessionName = value; }
        }

        public string SkillLeftSessionName
        {
            get { return _SkillLeftSessionName; }
            set { _SkillLeftSessionName = value; }
        }

        public event EventHandler SearchSkillEvent;
        public event EventHandler ToRightEvent;
        public event EventHandler ToLeftEvent;
        public event EventHandler InitView;

        //public event EventHandler ToLeftAjax;
        public event EventHandler AttachSkillAjax;
        public event EventHandler SearchAjax;

        protected void Search_Click(object sender, EventArgs e)
        {
            if (SearchSkillEvent != null)
            { SearchSkillEvent(this, EventArgs.Empty); }
            if (SearchAjax != null)
            { SearchAjax(this, EventArgs.Empty); }

        }

        protected void ToRight_Click(object sender, EventArgs e)
        {
            foreach (int i in SkillSearched.GetSelectedIndices())
            {
                SkillID = Convert.ToInt32(SkillSearched.Items[i].Value);
                SkillNameForRight = SkillSearched.Items[i].Text;
                ToRightEvent(this, EventArgs.Empty);

            }
            BindSkillToSend();

        }

        private void BindSkillToSend()
        {

            SkillToSend.DataSource = SkillRight;
            SkillToSend.DataValueField = "SkillID";
            SkillToSend.DataTextField = "SkillName";
            SkillToSend.DataBind();
            if (AttachSkillAjax != null)
            {
                AttachSkillAjax(this, EventArgs.Empty);
            }
        }

        protected void ToLeft_Click(object sender, EventArgs e)
        {
            foreach (int i in SkillToSend.GetSelectedIndices())
            {
                SkillID = Convert.ToInt32(SkillToSend.Items[i].Value);
                ToLeftEvent(this, EventArgs.Empty);

            }
            BindSkillToSend();

        }
    }
}