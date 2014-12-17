using System.IO;

namespace ShiXin.Security
{
    internal interface ISecurity
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptStr">明文</param>
        /// <returns>密文</returns>
        string Encryption(string encryptStr);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <returns>明文</returns>
        string Decryption(string decryptStr);

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptStream">明文</param>
        /// <returns>密文</returns>
        byte[] EncryptStream(MemoryStream encryptStream);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptBytes">密文</param>
        /// <returns>明文</returns>
        Stream DecryptStream(byte[] decryptBytes);

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="photo">明文</param>
        /// <param name="key">key</param>
        /// <returns>密文</returns>
        byte[] EncryptStream(byte[] photo,string key);

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="photo">密文</param>
        /// <param name="key">key</param>
        /// <returns>明文</returns>
        byte[] DecryptStream(byte[] photo, string key);


    }
}
