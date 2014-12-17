using System.Collections.Generic;
using SEP.HRMIS.Model;


namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews
{
    public interface IFamilyInfoView
    {
        /// <summary>
        /// ��ͥ������Ϣ�����
        /// </summary>
        IFamilyBasicInfoView FamilyBasicInfoView { get; set;}
        /// <summary>
        /// ��ͥ��ԱС����
        /// </summary>
        IFamilyMemberView FamilyMemberView { get; set;}
        /// <summary>
        /// С�����Ƿ�ɼ�
        /// </summary>
        bool FamilyMemberViewVisiable { get; set;}
    }
    public delegate void DlgFamilyMembers(List<FamilyMember> familymembers);

      

    
}