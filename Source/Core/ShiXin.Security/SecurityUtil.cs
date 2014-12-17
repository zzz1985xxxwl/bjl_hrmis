
using System.IO;

namespace ShiXin.Security
{
    public sealed class SecurityUtil
    {
        /// <summary>
        /// �ԳƼ����㷨-����
        /// </summary>
        /// <param name="encryptStr">����</param>
        /// <param name="key">��Կ</param>
        /// <returns>����</returns>
        public static string SymmetricEncrypt(string encryptStr, string key)
        {
            ISecurity security = new SymmetricEncryption(key);
            return security.Encryption(encryptStr);
        }

        /// <summary>
        /// �ԳƼ����㷨-����
        /// </summary>
        /// <param name="decryptStr">����</param>
        /// <param name="key">��Կ</param>
        /// <returns>����</returns>
        public static string SymmetricDecrypt(string decryptStr, string key)
        {
            ISecurity security = new SymmetricEncryption(key);
            return security.Decryption(decryptStr);
        }

        /// <summary>
        /// �ԳƼ����㷨-����
        /// </summary>
        /// <param name="encryptStream">����</param>
        /// <returns>����</returns>
        public static byte[] SymmetricEncryptStream(MemoryStream encryptStream)
        {
            ISecurity security = new SymmetricEncryption();
            return security.EncryptStream(encryptStream);
        }

        /// <summary>
        /// �ԳƼ����㷨-����
        /// </summary>
        /// <param name="decryptBytes">����</param>
        /// <returns>����</returns>
        public static Stream SymmetricDecryptStream(byte[] decryptBytes)
        {
            ISecurity security = new SymmetricEncryption();
            return security.DecryptStream(decryptBytes);
        }
        /// <summary>
        /// DEC�����㷨-����
        /// </summary>
        /// <param name="encryptStr">����</param>
        /// <returns>����</returns>
        public static string DECEncrypt(string encryptStr)
        {
            ISecurity security = new DECEncryption();
            return security.Encryption(encryptStr);
        }

        /// <summary>
        /// DEC�����㷨-����
        /// </summary>
        /// <param name="decryptStr">����</param>
        /// <returns>����</returns>
        public static string DECDecrypt(string decryptStr)
        {
            ISecurity security = new DECEncryption();
            return security.Decryption(decryptStr);
        }

        /// <summary>
        /// �ԳƼ����㷨-����
        /// </summary>
        /// <param name="encryptStream">����</param>
        /// <param name="key">key</param>
        /// <returns>����</returns>
        public static byte[] SymmetricEncryptStream(byte[] encryptStream,string key)
        {
            ISecurity security = new DECEncryption();
            return security.EncryptStream(encryptStream, key);
        }

        /// <summary>
        /// �ԳƼ����㷨-����
        /// </summary>
        /// <param name="decryptBytes">����</param>
        /// <param name="key">key</param>
        /// <returns>����</returns>
        public static byte[] SymmetricDecryptStream(byte[] decryptBytes, string key)
        {
            ISecurity security = new DECEncryption();
            return security.DecryptStream(decryptBytes,key);
        }
    }
}
