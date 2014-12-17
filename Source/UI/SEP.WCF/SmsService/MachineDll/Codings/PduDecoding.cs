using System;
using System.Text;

namespace MachineDll.Codings
{
    /// <summary>
    /// By popcorn 2004.5。
    /// cnpopcorn@hotmail.com
    /// 本类由popcorn提供，me修改了一下函数DecodingMsg的签名。
    /// </summary>
    public class PduDecoding
    {
        /// <summary>
        /// 对整个短信息进行解码
        /// </summary>
        /// <param name="s">要解码的信息</param>
        /// <param name="senderNumber">解码后的电话号码</param>
        /// <param name="content">解码后的短信内容</param>
        /// <param name="sendTime">短信时间戳</param>
        /// <returns>成功返回true</returns>
        static public bool DecodingMsg(string s, out string senderNumber, out string content, out DateTime sendTime)
        {
            senderNumber = null;
            content = null;
            sendTime = new DateTime(1900,1,1);

            try
            {
                //短信息中心
                string sca = "";
                int iLength = int.Parse(s.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                if (iLength > 0)
                {
                    if (s.Substring(2, 2) == "91")
                    {
                        sca += "+";
                        iLength--;
                    }
                    for (int i = 0; i < iLength * 2; i += 2)
                    {
                        sca += s.Substring(5 + i, 1);
                        sca += s.Substring(4 + i, 1);
                    }
                    if (sca.EndsWith("F")) sca = sca.Remove(sca.Length - 1, 1);
                }

                //recvInfo.SCA = sca; 目前不需要获取短信中心。
                s = s.Remove(0, iLength * 2 + 6);

                //发送方号码
                string cellNumber = "";
                iLength = int.Parse(s.Substring(0, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                if (s.Substring(2, 2) == "91")
                {
                    cellNumber = "+";
                }
                if (iLength % 2 == 1) iLength++;
                for (int i = 0; i < iLength; i += 2)
                {
                    cellNumber += s.Substring(5 + i, 1);
                    cellNumber += s.Substring(4 + i, 1);
                }
                if (cellNumber.EndsWith("F")) cellNumber = cellNumber.Remove(cellNumber.Length - 1, 1);

                senderNumber = cellNumber;

                s = s.Remove(0, iLength + 6);

                //编码方式
                GSMCode codeType;
                if (s.Substring(0, 2) == "08")
                    codeType = GSMCode.UCS2;
                else if (s.Substring(0, 2) == "00")
                    codeType = GSMCode.Bit7;
                else
                    codeType = GSMCode.Bit8;

                //recvInfo.CodeType = codeType; 目前不需要编码方式

                s = s.Remove(0, 2);

                //时间戳
                sendTime = new DateTime(int.Parse("20" + s.Substring(1, 1) + s.Substring(0, 1)),
                    int.Parse(s.Substring(3, 1) + s.Substring(2, 1)),
                    int.Parse(s.Substring(5, 1) + s.Substring(4, 1)),
                    int.Parse(s.Substring(7, 1) + s.Substring(6, 1)),
                    int.Parse(s.Substring(9, 1) + s.Substring(8, 1)),
                    int.Parse(s.Substring(11, 1) + s.Substring(10, 1)));
                s = s.Remove(0, 16);

                //收到的信息
                string text;
                if (codeType == GSMCode.Bit7)
                {
                    text = DecodingBit7(s);
                }
                else if (codeType == GSMCode.UCS2)
                {
                    text = DecodingUCS2(s);
                }
                else
                {
                    text = DecodingBit8(s);
                }
                content = text.Replace("\0", "");

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 对短信息中心进行编码
        /// </summary>
        /// <param name="s">要编码的号码</param>
        /// <returns>编码后的号码</returns>
        static public string EncodingSCA(string s)
        {
            StringBuilder sb = new StringBuilder();
            if (s.Length == 0)
            {
                sb.Append("00");
                return sb.ToString();
            }
            if (s.StartsWith("+"))
            {
                sb.Append("91");   //用国际格式号码(在前面加‘+’)
                s = s.Remove(0, 1);
            }
            else
            {
                sb.Append("C8");
            }
            if (s.Length % 2 == 1) s += "F";
            for (int i = 0; i < s.Length; i += 2)
            {
                sb.Append(s.Substring(i + 1, 1));
                sb.Append(s.Substring(i, 1));
            }
            string len = (sb.Length / 2).ToString("X2");
            return len + sb.ToString();
        }
        /// <summary>
        /// 对电话号码进行编码
        /// </summary>
        /// <param name="mobileNo">要编码的电话号码</param>
        /// <returns>编码后的电话号码</returns>
        static public string EncodingNumber(string mobileNo)
        {
            StringBuilder sb = new StringBuilder();
            if (mobileNo.StartsWith("+"))
            {
                sb.Append("91");
                mobileNo = mobileNo.Remove(0, 1);
            }
            else
            {
                sb.Append("C8");
            }
            string len = mobileNo.Length.ToString("X2");
            if (mobileNo.Length % 2 == 1) mobileNo += "F";
            for (int i = 0; i < mobileNo.Length; i += 2)
            {
                sb.Append(mobileNo.Substring(i + 1, 1));
                sb.Append(mobileNo.Substring(i, 1));
            }
            return len + sb.ToString();
        }

        /// <summary>
        /// 使用7-bit进行编码
        /// </summary>
        /// <param name="s">要编码的英文字符串</param>
        /// <returns>信息长度及编码后的字符串</returns>
        static public string EncodingBit7(string s)
        {
            int iLeft = 0;
            string sReturn = "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                // 取源字符串的计数值的最低3位
                int iChar = i & 7;
                byte bSrc = (byte)char.Parse(s.Substring(i, 1));
                // 处理源串的每个字节
                if (iChar == 0)
                {
                    // 组内第一个字节，只是保存起来，待处理下一个字节时使用
                    iLeft = (int)char.Parse(s.Substring(i, 1));
                }
                else
                {
                    // 组内其它字节，将其右边部分与残余数据相加，得到一个目标编码字节
                    sReturn = (bSrc << (8 - iChar) | iLeft).ToString("X4");
                    // 将该字节剩下的左边部分，作为残余数据保存起来
                    iLeft = bSrc >> iChar;
                    // 修改目标串的指针和计数值 pDst++;
                    sb.Append(sReturn.Substring(2, 2));
                }
            }
            sb.Append(sReturn.Substring(0, 2));
            return (sb.Length / 2).ToString("X2") + sb.ToString();
        }
        /// <summary>
        /// 对7-bit编码进行解码
        /// </summary>
        /// <param name="s">要解码的字符串</param>
        /// <returns>解码后的英文字符串</returns>
        static public string DecodingBit7(string s)
        {
            int iByte = 0;
            int iLeft = 0;
            // 将源数据每7个字节分为一组，解压缩成8个字节
            // 循环该处理过程，直至源数据被处理完
            // 如果分组不到7字节，也能正确处理
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < s.Length; i += 2)
            {
                byte bSrc = byte.Parse(s.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                // 将源字节右边部分与残余数据相加，去掉最高位，得到一个目标解码字节
                sb.Append((((bSrc << iByte) | iLeft) & 0x7f).ToString("X2"));
                // 将该字节剩下的左边部分，作为残余数据保存起来
                iLeft = bSrc >> (7 - iByte);
                // 修改字节计数值
                iByte++;
                // 到了一组的最后一个字节
                if (iByte == 7)
                {
                    // 额外得到一个目标解码字节
                    sb.Append(iLeft.ToString("X2"));
                    // 组内字节序号和残余数据初始化
                    iByte = 0;
                    iLeft = 0;
                }
            }
            string sReturn = sb.ToString();
            byte[] buf = new byte[sReturn.Length / 2];
            for (int i = 0; i < sReturn.Length; i += 2)
            {
                buf[i / 2] = byte.Parse(sReturn.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            return System.Text.Encoding.ASCII.GetString(buf);
        }

        /// <summary>
        /// 使用8-bit进行编码
        /// </summary>
        /// <param name="s">要编码的字符串</param>
        /// <returns>信息长度及编码后的字符串</returns>
        static public string EncodingBit8(string s)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = Encoding.ASCII.GetBytes(s);
            sb.Append(buf.Length.ToString("X2"));
            for (int i = 0; i < buf.Length; i++)
            {
                sb.Append(buf[i].ToString("X2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 使用8-bit进行解码
        /// </summary>
        /// <param name="s">要解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        static public string DecodingBit8(string s)
        {
            byte[] buf = new byte[s.Length / 2];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i += 2)
            {
                buf[i / 2] = byte.Parse(s.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            return Encoding.ASCII.GetString(buf);
        }

        /// <summary>
        /// 中文短信息UCS2编码
        /// </summary>
        /// <param name="s">要编码的中文字符串</param>
        /// <returns>信息长度及编码后的字符串</returns>
        static public string EncodingUCS2(string s)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = Encoding.Unicode.GetBytes(s);
            sb.Append(buf.Length.ToString("X2"));
            for (int i = 0; i < buf.Length; i += 2)
            {
                sb.Append(buf[i + 1].ToString("X2"));
                sb.Append(buf[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 中文短信息UCS2解码
        /// </summary>
        /// <param name="s">要解码的信息</param>
        /// <returns>解码后的中文字符串</returns>
        static public string DecodingUCS2(string s)
        {
            byte[] buf = new byte[s.Length];
            for (int i = 0; i < s.Length; i += 4)
            {
                buf[i / 2] = byte.Parse(s.Substring(2 + i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                buf[i / 2 + 1] = byte.Parse(s.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            return Encoding.Unicode.GetString(buf);
        }

    }
    /// <summary>
    /// 编码格式
    /// </summary>
    public enum GSMCode
    {
        Bit7 = 0,
        Bit8 = 1,
        UCS2 = 2
    }
}


