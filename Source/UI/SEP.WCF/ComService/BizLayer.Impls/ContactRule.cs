using System;
using System.Collections.Generic;
using System.Text;
using ComService.IBizLayer;
using ComService.IDALayer;
using ComService.ServiceModels;
using Framework.Core;

namespace ComService.BizLayer.Impls
{
    public class ContactRule : IContact
    {
        private static IContactDA _IContactDA = DalFactory.ContactDA;
       
        #region IContact 成员

        public Contact LoadAllContact(string sysNo, int userId, int companyId)
        {
            return LoadAllContact(sysNo, userId,companyId, true);
        }

        public Contact LoadAllContact(string sysNo, int userId, int companyId, bool isExternal)
        {
            return _IContactDA.GetAllLinkmans(sysNo, userId, companyId, isExternal);
        }

        public Contact LoadSomeContactByName(string sysNo, int userId, int companyId ,string name)
        {
            return LoadSomeContactByName(sysNo, userId,companyId, name, true);
        }

        public Contact LoadSomeContactByName(string sysNo, int userId, int companyId, string name, bool isExternal)
        {
            return _IContactDA.GetLinkmansByName(sysNo, userId, name, companyId, isExternal);
        }

        public Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey)
        {
            return LoadSomeContactByIndexKey(sysNo, userId, companyId, indexKey, true);
        }

        public Contact LoadSomeContactByIndexKey(string sysNo, int userId, int companyId, string indexKey, bool isExternal)
        {
            return _IContactDA.GetAllLinkmansByIndexKey(sysNo, userId, companyId, indexKey, isExternal);
        }

        public void SaveLinkman(string sysNo, int userId, int companyId, Linkman linkman)
        {
            string msg;
            if (!Validation(linkman, out msg))
                throw new Exception(msg);

            _IContactDA.DeleteLinkman(linkman.Id);
            _IContactDA.AddLinkman(sysNo, userId, companyId, linkman);
        }

        public void DeleteLinkman(Guid linkmanId)
        {
           _IContactDA.DeleteLinkman(linkmanId);
        }

        public void DeleteAllLinkman(string sysNo, int userId)
        {
            _IContactDA.DeleteContact(sysNo,userId);
        }

        #endregion

        private bool Validation(Linkman linkman, out string msg)
        {
            bool temp = true;

            msg = String.Empty;
            StringBuilder sb = new StringBuilder();

            if (String.IsNullOrEmpty(linkman.Name) || String.IsNullOrEmpty(linkman.Name.Trim())
                || (!Tools.IsAz(linkman.Name.Trim()[0].ToString()) 
                && !Tools.IsCHS(linkman.Name.Trim()[0].ToString())))
            {
                sb.AppendLine("联系人姓名必须以字母或汉字开头：(" + linkman.Name + ")；");
                temp = false;
            }
            
            if (linkman.Details.Count <= 0)
            {
                msg = sb.ToString();
                return temp;
            }

            foreach (LinkmanDetail ld in linkman.Details)
            {
                switch (ld.Type)
                {
                    case InfoType.Num_Fax:
                    case InfoType.Num_General:
                    case InfoType.Num_Home:
                    case InfoType.Num_Mobile:
                    case InfoType.Num_Work:
                        {
                            if (!String.IsNullOrEmpty(ld.Value) 
                                && !String.IsNullOrEmpty(ld.Value.Trim()) 
                                && !Tools.IsPhoneNum(ld.Value.Trim()))
                            {
                                sb.AppendLine("电话号码不合法！");
                                temp = false;
                            }
                        }
                        break;
                    case InfoType.Addr_Email:
                        {
                            if (!String.IsNullOrEmpty(ld.Value) 
                                && !String.IsNullOrEmpty(ld.Value.Trim()) 
                                && !Tools.IsEmail(ld.Value.Trim()))
                            {
                                sb.AppendLine("Email地址不合法！");
                                temp = false;
                            }
                        }
                        break;
                    case InfoType.Addr_Web:
                        {
                            if (!String.IsNullOrEmpty(ld.Value) 
                                && !String.IsNullOrEmpty(ld.Value.Trim()) 
                                && !Tools.IsURL(ld.Value.Trim()))
                            {
                                sb.AppendLine("个人主页地址不合法！");
                                temp = false;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            msg = sb.ToString();
            return temp;
        }
    }
}
