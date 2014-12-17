using ShiXin.Security;

namespace SEP.HRMIS.SqlServerDal
{
    public static class DalUtility
    {
        public const string _DbError = "���ݿ���ʴ���";

        /// <summary>
        /// ����
        /// </summary>
        public static string DecryptPassword(string encrptyedPassword, string key)
        {
            return  SecurityUtil.SymmetricDecrypt(encrptyedPassword,key);
        }
        /// <summary>
        /// ����
        /// </summary>
        public static string EncryptThePassword(string thePassword, string key)
        {
            return SecurityUtil.SymmetricEncrypt(thePassword, key);
        }
    }
}