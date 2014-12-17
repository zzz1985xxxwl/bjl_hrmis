using SEP.HRMIS.Model.Others;

namespace SEP.HRMIS.Model
{
    public class ServiceUtility
    {
        //当前系统的服务编号，每个发布的系统应该保持唯一性
        public static string SYSTEMID = GetConfigKey.SYSTEMID;
    }
}