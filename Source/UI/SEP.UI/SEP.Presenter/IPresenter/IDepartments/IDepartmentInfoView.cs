
namespace SEP.Presenter.IPresenter.IDepartments
{
    public interface IDepartmentInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        IDepartmentListView DepartmentListView { get;set;}
        /// <summary>
        /// С����
        /// </summary>
        IDepartmentView DepartmentView { get;set;}
        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool DepartmentViewVisible { get;set;}

        string divMPEDepartmentClientID { get; }
    }
}
