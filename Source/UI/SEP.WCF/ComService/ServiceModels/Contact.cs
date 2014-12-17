using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel;
using Framework.Core;

namespace ComService.ServiceModels
{
    [DataContract(Name = "Contact")]
    [Description("ͨѶ¼")]
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
        /// ϵͳ��ʾ
        /// </summary>
        public string SysNo
        {
            get
            {
                return _sysNo;
            }
        }
        /// <summary>
        /// �û�ID
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
        /// ��ϵ�˼���
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
    [Description("��ϵ��")]
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
        /// ��ϵ��ID
        /// </summary>
        public Guid Id
        {
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// ��ϵ������
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
                //��ȡƴ������ĸ(��д)
                try
                {
                    _indexKey = CHS2PinYin.FirstCHSCap(value.Trim());
                }
                catch
                {
                    throw new Exception("��ϵ�����������Ժ��ֻ�Ӣ����ĸ��ͷ��");
                }
                _name = value.Trim();
            }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string IndexKey
        {
            get
            {
                return _indexKey;
            }
        }
        /// <summary>
        /// ��ϵ������
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
    [Description("��ϵ������")]
    [Serializable]
    public class LinkmanDetail
    {
        [DataMember]
        private Guid _id;
        private InfoType _type;
        private string _value;
        private bool _isDefault;

        /// <summary>
        /// ��ϵ������ID
        /// </summary>
        public Guid Id
        {
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// �������
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
        /// ��ϵ��Ϣֵ
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
        /// �Ƿ�ΪĬ��ֵ
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
    [Description("��Ϣ����")]
    public enum InfoType
    {
        [EnumMember]
        None,

        /// <summary>
        /// һ�����
        /// </summary>
        [EnumMember]
        Num_General,

        /// <summary>
        /// �ֻ�����
        /// </summary>
        [EnumMember]
        Num_Mobile,

        /// <summary>
        /// լ�����
        /// </summary>
        [EnumMember]
        Num_Home,

        /// <summary>
        /// ��������
        /// </summary>
        [EnumMember]
        Num_Work,

        /// <summary>
        /// �������
        /// </summary>
        [EnumMember]
        Num_Fax,

        /// <summary>
        /// ���ʵ�ַ
        /// </summary>
        [EnumMember]
        Addr_Email,

        /// <summary>
        /// ������ҳ��ַ
        /// </summary>
        [EnumMember]
        Addr_Web,

        /// <summary>
        /// ��ͥסַ
        /// </summary>
        [EnumMember]
        Addr_Home,

        /// <summary>
        /// ��˾��ַ
        /// </summary>
        [EnumMember]
        Addr_Work
    }
}
