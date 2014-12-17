//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: BllUtility.cs
// 创建者: 倪豪
// 创建日期: 2008-05-19
// 概述: 处理了ResourceManager获取指定字符，抛出异常的工作
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    public static class BllUtility
    {
        public const string _SmtpClient = "_SmtpClient";
        public const string _EmptyMailAddress = "empty@mailAddress.com";
        public const string _ResidenceString = @"到期，请在有效期满前60日之内向原办理处提出续办申请。

续办流程：

 

1．登陆21世纪人才网，进入《境内人员上海市居住证审批》业务；

 <http://www.21cnhr.gov.cn/> http://www.21cnhr.gov.cn

2．请用个人名义登陆。用户名：身份证号码，初始密码111111；

3．请仔细填写申报信息，若提交将无法修改（办理流程选择：续办）

4．填完后，提交，并告知公司人力资源部；

5．准备申请材料，将需盖章件交公司人力资源部；

6．个人携带相关资料去网点办理；

7．登陆网站查询审核结果。

8．收到续办通知书后，请将复印件（人事局的章要清晰）转交给公司人力资料部

 

参考资料： 

申请材料（申请续签人员所有信息未发生变化的）

　　1、《国内人才（上海市居住证）申领表》（需加盖聘用单位公章）（附件）； 

　　2、居住证及身份证复印件；

3、居住证有效期内最近一年的在沪个人收入纳税证明复印件（验原件）

4、居住证有效期内最近一年的在沪养老保险证明（可以到上海市劳动和社会保障局的网站 <http://www.12333.com.cn/>  http://www.12333sh.gov.cn打印后由单位加盖公章,注明本人姓名、身份证号码）。
如之前未开通过社保密码，请到就近的社保中心去申请密码,当场就可办妥.要带身份证及居住证原件。




申请续签的人员如相关信息发生变化的，应提供相关材料

　　1、单位变化的，提供新单位的组织机构代码证和营业执照（事业单位法人证书），劳动（聘用）合同，以上资料都需要提供原件及复印件；新单位需符合关于单位申请条件的规定。

　　2、原劳动（聘用）合同已到期的，需提供新的一年期以上的有效劳动（聘用）合同；

　　3、住所发生变化的，需按对住所证明的相关要求提供证明材料。

4、子女超过16周岁的还需提供学校在读证明。

 

Best Regards

              Iceneed Fan
-------------------------

' 86 21 69902161
7 86 21 69902165
*  <mailto:fan.jing@shixintech.comú> fan.jing@shixintech.com
*  <http://www.shixintech.com> http://www.shixintech.com
";

        /// <summary>
        /// 加密字符串常量
        /// </summary>
        public const string SECRET = "kjhqjherqiheramnxsaskjjkhqewurhbdnbaqjdquermqerjqnerkqelkjdqejhefjqfeqwfrqdjmqjejfndewffheqwkhbgeqwdeqwdxeqwdhbeqwdjqwdkjheqwjfhdjeqwhfbjwfkbeqwhbdvhgftwgdiurbdqliyh";
        public const string SECRETLOGIN = "nrewjnfrnfgrewjnw";
        
        private static readonly ResourceManager _resourceManager = new ResourceManager("SEP.HRMIS.Bll.ExceptionResources", typeof(ExceptionResources).Assembly);

        /// <summary>
        /// 根据resourceId获取指定的字符串常量
        /// </summary>
        public static string GetResourceMessage(string resourceId)
        {
            string retValue;
            try
            {
                retValue = _resourceManager.GetString(resourceId);
            }
            catch
            {
                retValue = BllExceptionConst._NormalError;
            }
            return retValue;
        }

        public static void ThrowException(string resourceId)
        {
            throw new ApplicationException(GetResourceMessage(resourceId));
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strSrc">原字符串</param>
        /// <param name="constSecret">加密字符串</param>
        /// <returns></returns>
        public static string SimpleEncode(string strSrc, string constSecret)
        {
            char[] cnB = constSecret.ToCharArray(0, constSecret.Length);
            char[] show = strSrc.ToCharArray(0, strSrc.Length);
            StringBuilder str = new StringBuilder();
            //string str = "";
            for (int i = 0; i < show.Length; i++)
            {
                int sum = Convert.ToInt32(cnB[i]) + Convert.ToInt32(show[i]);
                string s;
                if (sum < 100 && sum >= 10)
                    s = "0" + sum;
                else if (sum < 10)
                    s = "00" + sum;
                else s = sum.ToString();
                str.Append(s);
                //str = str + s;
            }
            return str.ToString();
        }

        public static string SimpleDecode(string result, string constSecret)
        {
            char[] cnB = constSecret.ToCharArray(0, constSecret.Length);
            char[] rB = result.ToCharArray(0, result.Length);
            StringBuilder str = new StringBuilder();
            //string str = "";
            for (int i = 0; i < rB.Length; i += 3)
            {
                string s2 = result.Substring(i, 3);
                int sum = Convert.ToInt32(s2);
                char src = Convert.ToChar(sum - Convert.ToInt32(cnB[i / 3]));
                string s = src.ToString();
                str.Append(s);
                //str = str + s;
            }
            return str.ToString();
        }

        /// <summary>
        /// 取得加密字符串
        /// </summary>
        /// <param name="oldStr">原加密字符串</param>
        /// <param name="count">复制次数</param>
        /// <returns>新加密字符串</returns>
        public static string getExpandString(string oldStr, int count)
        {
            //string newStr = string.Empty;
            StringBuilder newStr = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                newStr.Append(oldStr);
                //newStr += oldStr;
            }
            return newStr.ToString();
        }

        /// <summary>
        /// 根据账号ID获取Email地址
        /// </summary>
        public static List<List<string>> GetEmailsByAccountIds(List<Account> accounts)
        {
            List<List<string>> emails = new List<List<string>>();

            List<string> email1s = new List<string>();
            List<string> email2s = new List<string>();
            emails.Add(email1s);
            emails.Add(email2s);

            if (accounts == null || accounts.Count == 0)
                return emails;

            Account temp;
            foreach (Account account in accounts)
            {
                temp = BllInstance.AccountBllInstance.GetAccountById(account.Id);
                if (temp == null)
                    continue;

                if (!String.IsNullOrEmpty(temp.Email1))
                    email1s.Add(temp.Email1);
                if (!String.IsNullOrEmpty(temp.Email2))
                    email2s.Add(temp.Email2);
            }
            return emails;
        }
    }
}
