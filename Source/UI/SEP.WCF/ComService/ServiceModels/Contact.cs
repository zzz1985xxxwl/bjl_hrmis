using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel;
using Framework.Core;

namespace ComService.ServiceModels
{
    [DataContract(Name = "Contact")]
    [Description("通讯录")]
    [Serializable]
    public class Contact
    {
        [DataMember(Name = "_sysNo")]
        private string _sysNo;
        [DataMember(Name = "_userId")]
        private int _userId;
        [DataMember(Name = "_companyId")]
        private int _companyId;
        [DataMember(Name = "_linkmans")]
        private List<Linkman> _linkmans;

        /// <summary>
        /// 系统标示
        /// </summary>
        public string SysNo
        {
            get
            {
                return _sysNo;
            }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId
        {
            get
            {
                return _userId;
            }
        }

        public int CompanyId
        {
            get
            {
                return _companyId;
            }
        }

        /// <summary>
        /// 联系人集合
        /// </summary>
        public List<Linkman> Linkmans
        {
            get
            {
                return _linkmans;
            }
        }

        public Contact(string sysNo, int userId)
        {
            _sysNo = sysNo;
            _userId = userId;
            _linkmans = new List<Linkman>();
        }

        public bool Contains(Guid linkmanId)
        {
            foreach (Linkman linkman in _linkmans)
            {
                if(linkman.Id == linkmanId)
                    return true;
            }
            return false;
        }

        public bool Contains(Linkman linkman)
        {
            return Contains(linkman.Id);
        }

        public Linkman GetLinkmanById(Guid linkmanId)
        {
            foreach (Linkman linkman in _linkmans)
            {
                if (linkman.Id == linkmanId)
                    return linkman;
            }
            return null;
        }
    }

    [DataContract(Name = "Linkman")]
    [Description("联系人")]
    [Serializable]
    public class Linkman
    {
        [DataMember]
        private Guid _id;
        private string _name;
        [DataMember]
        private string _indexKey;
        [DataMember]
        private List<LinkmanDetail> _details;

        /// <summary>
        /// 联系人ID
        /// </summary>
        public Guid Id
        {
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// 联系人名称
        /// </summary>
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == _name) return;
                //获取拼音首字母(大写)
                try
                {
                    _indexKey = CHS2PinYin.FirstCHSCap(value.Trim());
                }
                catch
                {
                    throw new Exception("联系人姓名必须以汉字或英文字母开头！");
                }
                _name = value.Trim();
            }
        }
        /// <summary>
        /// 索引键
        /// </summary>
        public string IndexKey
        {
            get
            {
                return _indexKey;
            }
        }
        /// <summary>
        /// 联系人详情
        /// </summary>
        public List<LinkmanDetail> Details
        {
            get
            {
                return _details;
            }
        }

        public Linkman() 
            : this(Guid.NewGuid())
        {
        }
        public Linkman(Guid linkmanId)
        {
            _id = linkmanId;
            _details = new List<LinkmanDetail>();
        }



        public bool Contains(Guid detailId)
        {
            foreach (LinkmanDetail detail in _details)
            {
                if (detail.Id == detailId)
                    return true;
            }
            return false;
        }

        public bool Contains(LinkmanDetail detail)
        {
            return Contains(detail.Id);
        }

        public LinkmanDetail GetLinkmanDetailById(Guid detailId)
        {
            foreach (LinkmanDetail detail in _details)
            {
                if (detail.Id == detailId)
                    return detail;
            }
            return null;
        }

        public LinkmanDetail GetLinkmanDetailByType(InfoType type)
        {
            foreach (LinkmanDetail detail in _details)
            {
                if (detail.Type == type)
                    return detail;
            }
            return new LinkmanDetail(type);
        }
    }

    [DataContract(Name = "LinkmanDetail")]
    [Description("联系人详情")]
    [Serializable]
    public class LinkmanDetail
    {
        [DataMember]
        private Guid _id;
        private InfoType _type;
        private string _value;
        private bool _isDefault;

        /// <summary>
        /// 联系人详情ID
        /// </summary>
        public Guid Id
        {
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// 详情类别
        /// </summary>
        [DataMember]
        public InfoType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        /// <summary>
        /// 联系信息值
        /// </summary>
        [DataMember]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        /// <summary>
        /// 是否为默认值
        /// </summary>
        [DataMember]
        public bool IsDefault
        {
            get
            {
                return _isDefault;
            }
            set
            {
                _isDefault = value;
            }
        }

        public LinkmanDetail(Guid id, InfoType type)
        {
            _id = id;
            _type = type;
        }
        public LinkmanDetail(InfoType type)
            : this(Guid.NewGuid(), type)
        {
        }
        public LinkmanDetail(InfoType type, string value)
            : this(Guid.NewGuid(), type)
        {
            _value = value;
        }
    }

    [DataContract(Name = "InfoType")]
    [Description("信息类型")]
    public enum InfoType
    {
        [EnumMember]
        None,

        /// <summary>
        /// 一般号码
        /// </summary>
        [EnumMember]
        Num_General,

        /// <summary>
        /// 手机号码
        /// </summary>
        [EnumMember]
        Num_Mobile,

        /// <summary>
        /// 宅电号码
        /// </summary>
        [EnumMember]
        Num_Home,

        /// <summary>
        /// 工作号码
        /// </summary>
        [EnumMember]
        Num_Work,

        /// <summary>
        /// 传真号码
        /// </summary>
        [EnumMember]
        Num_Fax,

        /// <summary>
        /// 电邮地址
        /// </summary>
        [EnumMember]
        Addr_Email,

        /// <summary>
        /// 个人主页地址
        /// </summary>
        [EnumMember]
        Addr_Web,

        /// <summary>
        /// 家庭住址
        /// </summary>
        [EnumMember]
        Addr_Home,

        /// <summary>
        /// 公司地址
        /// </summary>
        [EnumMember]
        Addr_Work
    }
}
