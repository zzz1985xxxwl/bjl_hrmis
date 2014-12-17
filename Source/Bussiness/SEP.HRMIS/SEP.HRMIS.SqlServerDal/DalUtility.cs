using ShiXin.Security;

namespace SEP.HRMIS.SqlServerDal
{
    public static class DalUtility
    {
        public const string _DbError = "数据库访问错误";

        /// <summary>
        /// 解密
        /// </summary>
        public static string DecryptPassword(string encrptyedPassword, string key)
        {
            return  SecurityUtil.SymmetricDecrypt(encrptyedPassword,key);
        }
        /// <summary>
        /// 加密
        /// </summary>
        public static string EncryptThePassword(string thePassword, string key)
        {
            return SecurityUtil.SymmetricEncrypt(thePassword, key);
        }
    }
}