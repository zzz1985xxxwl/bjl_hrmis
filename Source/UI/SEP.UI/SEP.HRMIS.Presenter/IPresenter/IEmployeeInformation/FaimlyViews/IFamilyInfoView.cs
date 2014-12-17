using System.Collections.Generic;
using SEP.HRMIS.Model;


namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FaimlyViews
{
    public interface IFamilyInfoView
    {
        /// <summary>
        /// 家庭基本信息大界面
        /// </summary>
        IFamilyBasicInfoView FamilyBasicInfoView { get; set;}
        /// <summary>
        /// 家庭成员小界面
        /// </summary>
        IFamilyMemberView FamilyMemberView { get; set;}
        /// <summary>
        /// 小界面是否可见
        /// </summary>
        bool FamilyMemberViewVisiable { get; set;}
    }
    public delegate void DlgFamilyMembers(List<FamilyMember> familymembers);

      

    
}