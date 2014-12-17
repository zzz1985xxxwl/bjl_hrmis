
namespace SEP.HRMIS.Presenter
{
  public interface ITemplatePaperInfoView
    {
        ITemplatePaperListView TemplatePaperListView { get; set;}

        ITemplatePaperView TemplatePaperView { get; set;}

        bool ShowTemplatePaperViewVisible { get;set;}
      
    }
}
