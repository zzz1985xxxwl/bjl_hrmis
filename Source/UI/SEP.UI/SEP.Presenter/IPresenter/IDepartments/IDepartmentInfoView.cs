
namespace SEP.Presenter.IPresenter.IDepartments
{
    public interface IDepartmentInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        IDepartmentListView DepartmentListView { get;set;}
        /// <summary>
        /// 小界面
        /// </summary>
        IDepartmentView DepartmentView { get;set;}
        /// <summary>
        /// 小界面可见
        /// </summary>
        bool DepartmentViewVisible { get;set;}

        string divMPEDepartmentClientID { get; }
    }
}
