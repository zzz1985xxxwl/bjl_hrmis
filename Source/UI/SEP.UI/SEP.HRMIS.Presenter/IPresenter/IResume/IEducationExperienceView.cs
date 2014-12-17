namespace SEP.HRMIS.Presenter
{
    public interface IEducationExperienceView
    {
        string Message { get; set;}
        string Id { get; set;}

        string School { get; set;}
        string ExperiencePeriod { get; set;}
        string Contect { get; set;}
        string Remark { get; set;}

        string MsgSchool { get; set;}
        string MsgPeriod { get; set;}
        string MsgContect { get; set;}
    }
}
