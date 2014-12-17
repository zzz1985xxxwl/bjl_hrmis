using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews;

namespace SEP.Performance.Views.EmployeeInformation.FamilyInformation
{
    public partial class EmployeeFamilyView : System.Web.UI.UserControl,IFamilyInfoView
    {
        #region IFamilyInfoView ≥…‘±

        public IFamilyBasicInfoView FamilyBasicInfoView
        {
            get
            {
                return FamilyBasicView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IFamilyMemberView FamilyMemberView
        {
            get
            {
                return FamilyMemberView1;
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool FamilyMemberViewVisiable
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                if(value)
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
            FamilyBasicView1.SendMembers =SendFamilyMember;
        }

        private void SendFamilyMember(List<FamilyMember> familyMembers)
        {
            foreach (FamilyMember member in familyMembers)
            {
                member.HashCode = member.GetHashCode();
            }
            FamilyMemberView1.FamilyMemberDataSource = familyMembers;
        }
    }
}