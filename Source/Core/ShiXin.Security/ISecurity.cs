using System.IO;

namespace ShiXin.Security
{
    internal interface ISecurity
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="encryptStr">����</param>
        /// <returns>����</returns>
        string Encryption(string encryptStr);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="decryptStr">����</param>
        /// <returns>����</returns>
        string Decryption(string decryptStr);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="encryptStream">����</param>
        /// <returns>����</returns>
        byte[] EncryptStream(MemoryStream encryptStream);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="decryptBytes">����</param>
        /// <returns>����</returns>
        Stream DecryptStream(byte[] decryptBytes);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="photo">����</param>
        /// <param name="key">key</param>
        /// <returns>����</returns>
        byte[] EncryptStream(byte[] photo,string key);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="photo">����</param>
        /// <param name="key">key</param>
        /// <returns>����</returns>
        byte[] DecryptStream(byte[] photo, string key);


    }
}
