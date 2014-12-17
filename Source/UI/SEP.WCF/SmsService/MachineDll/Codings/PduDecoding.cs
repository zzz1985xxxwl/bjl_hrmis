using System;
using System.Text;

namespace MachineDll.Codings
{
    /// <summary>
    /// By popcorn 2004.5��
    /// cnpopcorn@hotmail.com
    /// ������popcorn�ṩ��me�޸���һ�º���DecodingMsg��ǩ����
    /// </summary>
    public class PduDecoding
    {
        /// <summary>
        /// ����������Ϣ���н���
        /// </summary>
        /// <param name="s">Ҫ�������Ϣ</param>
        /// <param name="senderNumber">�����ĵ绰����</param>
        /// <param name="content">�����Ķ�������</param>
        /// <param name="sendTime">����ʱ���</param>
        /// <returns>�ɹ�����true</returns>
        static public bool DecodingMsg(string s, out string senderNumber, out string content, out DateTime sendTime)
        {
            senderNumber = null;
            content = null;
            sendTime = new DateTime(1900,1,1);

            try
            {
                //����Ϣ����
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

                //recvInfo.SCA = sca; Ŀǰ����Ҫ��ȡ�������ġ�
                s = s.Remove(0, iLength * 2 + 6);

                //���ͷ�����
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

                //���뷽ʽ
                GSMCode codeType;
                if (s.Substring(0, 2) == "08")
                    codeType = GSMCode.UCS2;
                else if (s.Substring(0, 2) == "00")
                    codeType = GSMCode.Bit7;
                else
                    codeType = GSMCode.Bit8;

                //recvInfo.CodeType = codeType; Ŀǰ����Ҫ���뷽ʽ

                s = s.Remove(0, 2);

                //ʱ���
                sendTime = new DateTime(int.Parse("20" + s.Substring(1, 1) + s.Substring(0, 1)),
                    int.Parse(s.Substring(3, 1) + s.Substring(2, 1)),
                    int.Parse(s.Substring(5, 1) + s.Substring(4, 1)),
                    int.Parse(s.Substring(7, 1) + s.Substring(6, 1)),
                    int.Parse(s.Substring(9, 1) + s.Substring(8, 1)),
                    int.Parse(s.Substring(11, 1) + s.Substring(10, 1)));
                s = s.Remove(0, 16);

                //�յ�����Ϣ
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
        /// �Զ���Ϣ���Ľ��б���
        /// </summary>
        /// <param name="s">Ҫ����ĺ���</param>
        /// <returns>�����ĺ���</returns>
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
                sb.Append("91");   //�ù��ʸ�ʽ����(��ǰ��ӡ�+��)
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
        /// �Ե绰������б���
        /// </summary>
        /// <param name="mobileNo">Ҫ����ĵ绰����</param>
        /// <returns>�����ĵ绰����</returns>
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
        /// ʹ��7-bit���б���
        /// </summary>
        /// <param name="s">Ҫ�����Ӣ���ַ���</param>
        /// <returns>��Ϣ���ȼ��������ַ���</returns>
        static public string EncodingBit7(string s)
        {
            int iLeft = 0;
            string sReturn = "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                // ȡԴ�ַ����ļ���ֵ�����3λ
                int iChar = i & 7;
                byte bSrc = (byte)char.Parse(s.Substring(i, 1));
                // ����Դ����ÿ���ֽ�
                if (iChar == 0)
                {
                    // ���ڵ�һ���ֽڣ�ֻ�Ǳ�����������������һ���ֽ�ʱʹ��
                    iLeft = (int)char.Parse(s.Substring(i, 1));
                }
                else
                {
                    // ���������ֽڣ������ұ߲��������������ӣ��õ�һ��Ŀ������ֽ�
                    sReturn = (bSrc << (8 - iChar) | iLeft).ToString("X4");
                    // �����ֽ�ʣ�µ���߲��֣���Ϊ�������ݱ�������
                    iLeft = bSrc >> iChar;
                    // �޸�Ŀ�괮��ָ��ͼ���ֵ pDst++;
                    sb.Append(sReturn.Substring(2, 2));
                }
            }
            sb.Append(sReturn.Substring(0, 2));
            return (sb.Length / 2).ToString("X2") + sb.ToString();
        }
        /// <summary>
        /// ��7-bit������н���
        /// </summary>
        /// <param name="s">Ҫ������ַ���</param>
        /// <returns>������Ӣ���ַ���</returns>
        static public string DecodingBit7(string s)
        {
            int iByte = 0;
            int iLeft = 0;
            // ��Դ����ÿ7���ֽڷ�Ϊһ�飬��ѹ����8���ֽ�
            // ѭ���ô�����̣�ֱ��Դ���ݱ�������
            // ������鲻��7�ֽڣ�Ҳ����ȷ����
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < s.Length; i += 2)
            {
                byte bSrc = byte.Parse(s.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                // ��Դ�ֽ��ұ߲��������������ӣ�ȥ�����λ���õ�һ��Ŀ������ֽ�
                sb.Append((((bSrc << iByte) | iLeft) & 0x7f).ToString("X2"));
                // �����ֽ�ʣ�µ���߲��֣���Ϊ�������ݱ�������
                iLeft = bSrc >> (7 - iByte);
                // �޸��ֽڼ���ֵ
                iByte++;
                // ����һ������һ���ֽ�
                if (iByte == 7)
                {
                    // ����õ�һ��Ŀ������ֽ�
                    sb.Append(iLeft.ToString("X2"));
                    // �����ֽ���źͲ������ݳ�ʼ��
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
        /// ʹ��8-bit���б���
        /// </summary>
        /// <param name="s">Ҫ������ַ���</param>
        /// <returns>��Ϣ���ȼ��������ַ���</returns>
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
        /// ʹ��8-bit���н���
        /// </summary>
        /// <param name="s">Ҫ������ַ���</param>
        /// <returns>�������ַ���</returns>
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
        /// ���Ķ���ϢUCS2����
        /// </summary>
        /// <param name="s">Ҫ����������ַ���</param>
        /// <returns>��Ϣ���ȼ��������ַ���</returns>
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
        /// ���Ķ���ϢUCS2����
        /// </summary>
        /// <param name="s">Ҫ�������Ϣ</param>
        /// <returns>�����������ַ���</returns>
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
    /// �����ʽ
    /// </summary>
    public enum GSMCode
    {
        Bit7 = 0,
        Bit8 = 1,
        UCS2 = 2
    }
}


