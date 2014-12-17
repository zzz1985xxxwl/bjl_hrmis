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

        #region ISecurity ��Ա

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="decryptStr">����</param>
        /// <returns>����</returns>
        public string Decryption(string decryptStr)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[decryptStr.Length / 2];
            for (int x = 0; x < decryptStr.Length / 2; x++)
            {
                int i = (Convert.ToInt32(decryptStr.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = Encoding.ASCII.GetBytes(_Key);//�������ܶ������Կ��ƫ��������ֵ��Ҫ�������޸�
            des.IV = Encoding.ASCII.GetBytes(_Key);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //StringBuilder ret = new StringBuilder();//����StringBuilder����CreateDecryptʹ�õ��������󣬱���ѽ��ܺ���ı����������

            return Encoding.Default.GetString(ms.ToArray());
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="encryptStr">����</param>
        /// <returns>����</returns>
        public string Encryption(string encryptStr)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();//���ַ����ŵ�byte������

            byte[] inputByteArray = Encoding.Default.GetBytes(encryptStr);

            des.Key = Encoding.ASCII.GetBytes(_Key);//�������ܶ������Կ��ƫ����
            des.IV = Encoding.ASCII.GetBytes(_Key);//ԭ��ʹ��ASCIIEncoding.ASCII������GetBytes����
            MemoryStream ms = new MemoryStream();//ʹ�����������������Ӣ���ı�
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
