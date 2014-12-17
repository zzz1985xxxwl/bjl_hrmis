
using System.IO;

namespace ShiXin.Security
{
    public sealed class SecurityUtil
    {
        /// <summary>
        /// 对称加密算法-加密
        /// </summary>
        /// <param name="encryptStr">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        public static string SymmetricEncrypt(string encryptStr, string key)
        {
            ISecurity security = new SymmetricEncryption(key);
            return security.Encryption(encryptStr);
        }

        /// <summary>
        /// 对称加密算法-解密
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        public static string SymmetricDecrypt(string decryptStr, string key)
        {
            ISecurity security = new SymmetricEncryption(key);
            return security.Decryption(decryptStr);
        }

        /// <summary>
        /// 对称加密算法-加密
        /// </summary>
        /// <param name="encryptStream">明文</param>
        /// <returns>密文</returns>
        public static byte[] SymmetricEncryptStream(MemoryStream encryptStream)
        {
            ISecurity security = new SymmetricEncryption();
            return security.EncryptStream(encryptStream);
        }

        /// <summary>
        /// 对称加密算法-解密
        /// </summary>
        /// <param name="decryptBytes">密文</param>
        /// <returns>明文</returns>
        public static Stream SymmetricDecryptStream(byte[] decryptBytes)
        {
            ISecurity security = new SymmetricEncryption();
            return security.DecryptStream(decryptBytes);
        }
        /// <summary>
        /// DEC加密算法-加密
        /// </summary>
        /// <param name="encryptStr">明文</param>
        /// <returns>密文</returns>
        public static string DECEncrypt(string encryptStr)
        {
            ISecurity security = new DECEncryption();
            return security.Encryption(encryptStr);
        }

        /// <summary>
        /// DEC加密算法-解密
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <returns>明文</returns>
        public static string DECDecrypt(string decryptStr)
        {
            ISecurity security = new DECEncryption();
            return security.Decryption(decryptStr);
        }

        /// <summary>
        /// 对称加密算法-加密
        /// </summary>
        /// <param name="encryptStream">明文</param>
        /// <param name="key">key</param>
        /// <returns>密文</returns>
        public static byte[] SymmetricEncryptStream(byte[] encryptStream,string key)
        {
            ISecurity security = new DECEncryption();
            return security.EncryptStream(encryptStream, key);
        }

        /// <summary>
        /// 对称加密算法-解密
        /// </summary>
        /// <param name="decryptBytes">密文</param>
        /// <param name="key">key</param>
        /// <returns>明文</returns>
        public static byte[] SymmetricDecryptStream(byte[] decryptBytes, string key)
        {
            ISecurity security = new DECEncryption();
            return security.DecryptStream(decryptBytes,key);
        }
    }
}
