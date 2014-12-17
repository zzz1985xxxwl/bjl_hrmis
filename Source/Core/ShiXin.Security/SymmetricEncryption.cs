using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ShiXin.Security
{
    /// <summary>
    /// 对称加密算法
    /// </summary>
    internal class SymmetricEncryption : ISecurity
    {
        public SymmetricEncryption()
            : this("Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUjjy76*h%(HilJ$lhj!y6&(*jkP87jH7")
        {
        }

        public SymmetricEncryption(string key)
        {
            mobjCryptoService = new RijndaelManaged();
            _Key = key;
        }

        #region ISecurity 成员

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptStr">明文</param>
        /// <returns>密文</returns>
        public string Encryption(string encryptStr)
        {
            byte[] bytIn = Encoding.UTF8.GetBytes(encryptStr);
            MemoryStream ms = PrivateEncryptStream(bytIn);
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptStr">密文</param>
        /// <returns>明文</returns>
        public string Decryption(string decryptStr)
        {
            byte[] bytIn = Convert.FromBase64String(decryptStr);
            Stream cs = PrivateDecrypStream(bytIn);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptStream">明文</param>
        /// <returns>密文</returns>
        public byte[] EncryptStream(MemoryStream encryptStream)
        {
            return PrivateEncryptStream(encryptStream.ToArray()).ToArray();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptBytes">密文</param>
        /// <returns>明文</returns>
        public Stream DecryptStream(byte[] decryptBytes)
        {
            return PrivateDecrypStream(decryptBytes);
        }

        #endregion

        private string _Key;
        private SymmetricAlgorithm mobjCryptoService;

        /// <summary>
        /// 获得密钥
        /// </summary>
        /// <returns>密钥</returns>
        private byte[] GetLegalKey()
        {
            string sTemp = _Key;
            mobjCryptoService.GenerateKey();
            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;
            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');
            return Encoding.ASCII.GetBytes(sTemp);
        }
        /// <summary>
        /// 获得初始向量IV
        /// </summary>
        /// <returns>初试向量IV</returns>
        private byte[] GetLegalIV()
        {
            string sTemp = "E4ghj*Ghg7!rNIfb&95GUY86GjjhUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";
            mobjCryptoService.GenerateIV();
            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;
            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');
            return Encoding.ASCII.GetBytes(sTemp);
        }

        private Stream PrivateDecrypStream(byte[] bytIn)
        {
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
            return new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
        }

        private MemoryStream PrivateEncryptStream(byte[] bytIn)
        {
            MemoryStream ms = new MemoryStream();
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            return ms;
        }

        #region ISecurity 成员


        public byte[] EncryptStream(byte[] photo, string key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public byte[] DecryptStream(byte[] photo, string key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
