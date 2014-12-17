//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: MachineControlLogin.cs
// 创建者: 倪豪
// 创建日期: 2008-10-22
// 概述: 短信机器前台登录验证页面
//       若放置在C盘根目录的Conifg文件正确，则同时验证USBKEY与ID
//       若放置在C盘根目录的Conifg没有或者不正确，则启用默认密码验证
// ----------------------------------------------------------------
using System;
using System.IO;
using ShiXin.Security;

namespace WebControlClient
{
    public partial class MachineControlLogin : System.Web.UI.Page
    {
        //1234qwerasdf的加密字符串
        private const string _DefaultId = "887D9C397462C71A4C9D57E7E3F77F65";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string theMachineId;
            string usbKey;
            //需要验证2次身份
            if (FindTheMachineId(out theMachineId, out usbKey))
            {
                if (VaildateUsbKey(usbKey) && VaildateId(theMachineId))
                {
                    RedirectToPages();
                }
            }
            //仅仅需要验证默认密码
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

            Label3.Text = "身份验证失败！";
            return false;
        }

        private bool VaildateUsbKey(string usbKey)
        {
            int usbKeyCount = int.Parse(lbUsbKeyCount.Value);

            if (usbKeyCount < 1)
            {
                Label3.Text = "请插入UsbKey身份认证";
                return false;
            }
            if (usbKeyCount > 1)
            {
                Label3.Text = "请确保插入一个UsbKey身份认证";
                return false;
            }
            if (!usbKey.Trim().Equals(SecurityUtil.DECEncrypt(CleanUsbKey(lbUsbKey.Value.Trim()))))
            {
                Label3.Text = "USBKEY认证失败";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 通过C:\SmsConfig.txt配置身份验证标识，失败则启用默认密码1234qwerasdf,USBKEY不验证
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
                //默认值
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