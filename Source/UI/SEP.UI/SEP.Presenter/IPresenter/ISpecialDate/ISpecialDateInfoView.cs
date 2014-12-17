namespace SEP.Presenter.IPresenter.ISpecialDate
{
    public interface ISpecialDateInfoView
    {
        /// <summary>
        /// 大界面
        /// </summary>
        ISpecialDateView SpecialDateView { get; set;}

        /// <summary>
        /// 小界面
        /// </summary>
        ISpecialDateEditView SpecialDateEditView { get; set;}

        /// <summary>
        /// 小界面是否可见
        /// </summary>
        bool SpecialDateEditViewVisible { get; set;}
    }
}
