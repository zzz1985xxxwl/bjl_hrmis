using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ShiXin.Security
{
    internal class DECEncryption : ISecurity
    {
        private string _Key;

        public DECEncryption()
            : this("abcdefgh")
        {
        }

        public DECEncryption(string key)
        {
            _Key = key;
        }

        #region ISecurity 成员

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <returns>明文</returns>
        public string Decryption(string decryptStr)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[decryptStr.Length / 2];
            for (int x = 0; x < decryptStr.Length / 2; x++)
            {
                int i = (Convert.ToInt32(decryptStr.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = Encoding.ASCII.GetBytes(_Key);//建立加密对象的密钥和偏移量，此值重要，不能修改
            des.IV = Encoding.ASCII.GetBytes(_Key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //StringBuilder ret = new StringBuilder();//建立StringBuilder对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象

            return Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptStr">明文</param>
        /// <returns>密文</returns>
        public string Encryption(string encryptStr)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();//把字符串放到byte数组中

            byte[] inputByteArray = Encoding.Default.GetBytes(encryptStr);

            des.Key = Encoding.ASCII.GetBytes(_Key);//建立加密对象的密钥和偏移量
            des.IV = Encoding.ASCII.GetBytes(_Key);//原文使用ASCIIEncoding.ASCII方法的GetBytes方法
            MemoryStream ms = new MemoryStream();//使得输入密码必须输入英文文本
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }

            return ret.ToString();
        }

        public byte[] EncryptStream(MemoryStream encryptStream)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Stream DecryptStream(byte[] decryptBytes)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public byte[] EncryptStream(byte[] photo, string key)
        {
            string temp = SecurityUtil.SymmetricEncrypt(Convert.ToBase64String(photo), key);
            return Convert.FromBase64String(temp);
        }

        public byte[] DecryptStream(byte[] photo, string key)
        {
            string temp = Convert.ToBase64String(photo);
            return Convert.FromBase64String(SecurityUtil.SymmetricDecrypt(temp, key));
        }

        #endregion
    }
}
