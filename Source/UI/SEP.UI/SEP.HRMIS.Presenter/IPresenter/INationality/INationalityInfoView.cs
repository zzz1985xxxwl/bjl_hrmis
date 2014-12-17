namespace SEP.HRMIS.Presenter.IPresenter.INationality
{
    public interface INationalityInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        INationalityListView NationalityListView { get;set;}
        /// <summary>
        /// 小界面
        /// </summary>
        INationalityView NationalityView { get;set;}
        /// <summary>
        /// 小界面可见
        /// </summary>
        bool NationalityViewVisible { get;set;}
    }
}