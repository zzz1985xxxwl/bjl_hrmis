//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: MachineControlLogin.cs
// ������: �ߺ�
// ��������: 2008-10-22
// ����: ���Ż���ǰ̨��¼��֤ҳ��
//       ��������C�̸�Ŀ¼��Conifg�ļ���ȷ����ͬʱ��֤USBKEY��ID
//       ��������C�̸�Ŀ¼��Conifgû�л��߲���ȷ��������Ĭ��������֤
// ----------------------------------------------------------------
using System;
using System.IO;
using ShiXin.Security;

namespace WebControlClient
{
    public partial class MachineControlLogin : System.Web.UI.Page
    {
        //1234qwerasdf�ļ����ַ���
        private const string _DefaultId = "887D9C397462C71A4C9D57E7E3F77F65";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string theMachineId;
            string usbKey;
            //��Ҫ��֤2�����
            if (FindTheMachineId(out theMachineId, out usbKey))
            {
                if (VaildateUsbKey(usbKey) && VaildateId(theMachineId))
                {
                    RedirectToPages();
                }
            }
            //������Ҫ��֤Ĭ������
            else
            {
                if (VaildateId(_DefaultId))
                {
                    RedirectToPages();
                }
            }
        }

        private void RedirectToPages()
        {
            Session["MachineController"] = DateTime.Now;
            if (DropDownList1.SelectedIndex == 0)
            {
                Response.Redirect("ClientInformationMain.aspx");
            }
            else
            {
                Response.Redirect("MachineControl.aspx");
            }
        }

        private bool VaildateId(string theMachineId)
        {
            if (theMachineId.Equals(SecurityUtil.DECEncrypt(TextBox1.Text.Trim())))
            {
                return true;
            }

            Label3.Text = "�����֤ʧ�ܣ�";
            return false;
        }

        private bool VaildateUsbKey(string usbKey)
        {
            int usbKeyCount = int.Parse(lbUsbKeyCount.Value);

            if (usbKeyCount < 1)
            {
                Label3.Text = "�����UsbKey�����֤";
                return false;
            }
            if (usbKeyCount > 1)
            {
                Label3.Text = "��ȷ������һ��UsbKey�����֤";
                return false;
            }
            if (!usbKey.Trim().Equals(SecurityUtil.DECEncrypt(CleanUsbKey(lbUsbKey.Value.Trim()))))
            {
                Label3.Text = "USBKEY��֤ʧ��";
                return false;
            }
            return true;
        }

        /// <summary>
        /// ͨ��C:\SmsConfig.txt���������֤��ʶ��ʧ��������Ĭ������1234qwerasdf,USBKEY����֤
        /// </summary>
        private static bool FindTheMachineId(out string id, out string usbKey)
        {
            usbKey = null;
            try
            {
                StreamReader sw = new StreamReader(@"C:\SmsConfig.txt");
                sw.ReadLine();
                sw.ReadLine();

                if ((id = sw.ReadLine()) == null)
                {
                    sw.Close();
                    return false;
                }
                if ((usbKey = sw.ReadLine()) == null)
                {
                    sw.Close();
                    return false;
                }
                sw.Close();
                return true;
            }
            catch
            {
                //Ĭ��ֵ
                id = _DefaultId;
                usbKey = null;
                return false;
            }
        }

        private static string CleanUsbKey(string usbKey)
        {
            usbKey = usbKey.Replace(@"USB\VID_", "");
            usbKey = usbKey.Replace("&PID_", "");
            usbKey = usbKey.Replace(@"\", "");
            return usbKey;
        }
    }
}