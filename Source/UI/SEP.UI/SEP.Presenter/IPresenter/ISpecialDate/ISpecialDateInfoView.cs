namespace SEP.Presenter.IPresenter.ISpecialDate
{
    public interface ISpecialDateInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        ISpecialDateView SpecialDateView { get; set;}

        /// <summary>
        /// С����
        /// </summary>
        ISpecialDateEditView SpecialDateEditView { get; set;}

        /// <summary>
        /// С�����Ƿ�ɼ�
        /// </summary>
        bool SpecialDateEditViewVisible { get; set;}
    }
}
