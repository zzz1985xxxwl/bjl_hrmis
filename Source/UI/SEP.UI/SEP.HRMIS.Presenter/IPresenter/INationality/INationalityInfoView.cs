namespace SEP.HRMIS.Presenter.IPresenter.INationality
{
    public interface INationalityInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        INationalityListView NationalityListView { get;set;}
        /// <summary>
        /// С����
        /// </summary>
        INationalityView NationalityView { get;set;}
        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool NationalityViewVisible { get;set;}
    }
}