namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews
{
    public interface IFileCargoInfoView
    {
        /// <summary>
        /// 基本信息界面
        /// </summary>
        IFileCargoListView FileCargoListView { get; set; }

        /// <summary>
        ///  档案界面
        /// </summary>
        IFileCargoView FileCargoView { get; }

        int AccountID { get; set; }

        /// <summary>
        /// 小界面是否可见
        /// </summary>
        bool FileCargoViewVisible { get; set; }
    }
}