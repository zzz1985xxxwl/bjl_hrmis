namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews
{
    public interface IFileCargoInfoView
    {
        /// <summary>
        /// ������Ϣ����
        /// </summary>
        IFileCargoListView FileCargoListView { get; set; }

        /// <summary>
        ///  ��������
        /// </summary>
        IFileCargoView FileCargoView { get; }

        int AccountID { get; set; }

        /// <summary>
        /// С�����Ƿ�ɼ�
        /// </summary>
        bool FileCargoViewVisible { get; set; }
    }
}