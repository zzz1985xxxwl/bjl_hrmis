namespace SEP.HRMIS.Entity
{
    public class AuthEntity
    {
        public int PKID { get; set; }
        public string AuthName { get; set; }
        public int AuthParentId { get; set; }
        public string NavigateUrl { get; set; }
        public int IfHasDepartment { get; set; }
    }
}
