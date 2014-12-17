using System.Collections.Generic;
using System;
using System.Runtime.Serialization;

namespace SmsControlContract.ClientAddressModels
{
    [DataContract]
    public class ClientInformationModel
    {
        [DataMember]
        private int _Pkid;
        [DataMember]
        private string _HrmisId;
        [DataMember]
        private string _CompanyDescription;
        [DataMember]
        private bool _IsPermitted;
        [DataMember]
        private List<ListenAddressModel> _TheAddressModelCollcetion = new List<ListenAddressModel>();

        public ClientInformationModel(string hrmisId, string companyDescription, bool isPermmitted)
        {
            _HrmisId = hrmisId;
            _CompanyDescription = companyDescription;
            _IsPermitted = isPermmitted;
        }
        /// <summary>
        /// 公司ID，双方定义，暂时硬编码在程序中
        /// </summary>
        public string HrmisId
        {
            get { return _HrmisId; }
            set { _HrmisId = value; }
        }
        /// <summary>
        /// 公司描述
        /// </summary>
        public string CompanyDescription
        {
            get { return _CompanyDescription; }
            set { _CompanyDescription = value; }
        }
        /// <summary>
        /// 是否被认证
        /// </summary>
        public bool IsPermitted
        {
            get { return _IsPermitted; }
            set { _IsPermitted = value; }
        }
        /// <summary>
        /// 地址列表
        /// </summary>
        public List<ListenAddressModel> TheAddressModelCollcetion
        {
            get { return _TheAddressModelCollcetion; }
            set { _TheAddressModelCollcetion = value; }
        }

        public int Pkid
        {
            get { return _Pkid; }
            set { _Pkid = value; }
        }

        /// <summary>
        /// 尝试改变监听地址(有地址则修改，无地址则新增)，这个方法在客户端向服务器注册时候调用
        /// </summary>
        public void TryAddDiffierentListenAddress(string address, bool isTheClientAddressGood)
        {
            ListenAddressModel theAdderss = GetTheAddressModelBy(address);
            if (theAdderss == null)
            {
                _TheAddressModelCollcetion.Add(new ListenAddressModel(address, _IsPermitted, isTheClientAddressGood, DateTime.Now));
            }
            else
            {
                theAdderss.IsActivited = isTheClientAddressGood;
                theAdderss.LastTryActivitedTime = DateTime.Now;
            }
        }

        /// <summary>
        /// 获取当前对象中需要广播的客户端地址，哪些地址需要广播的规则制定在此处
        /// </summary>
        /// <returns></returns>
        public List<string> GetBoardCastAddress()
        {
            if (!_IsPermitted)
            {
                return new List<string>();
            }

            return GetActivedAndPermittedAddress();
        }

        public void CloseTheAddress(string address)
        {
            foreach (ListenAddressModel lam in TheAddressModelCollcetion)
            {
                if (lam.ListenAddress.Equals(address))
                {
                    lam.IsActivited = false;
                }
            }
        }

        public ListenAddressModel GetTheAddressModelBy(string address)
        {
            foreach (ListenAddressModel listenAddress in TheAddressModelCollcetion)
            {
                if (listenAddress.ListenAddress.Equals(address))
                {
                    return listenAddress;
                }
            }
            return null;
        }

        public ListenAddressModel GetTheAddressModelById(int pkid)
        {
            foreach (ListenAddressModel listenAddress in TheAddressModelCollcetion)
            {
                if (listenAddress.Pkid.Equals(pkid))
                {
                    return listenAddress;
                }
            }
            return null;
        }

        /// <summary>
        /// 设置客户端服务的状态，是否开启
        /// </summary>
        public void SetTheServiceStatus(bool theStatus)
        {
            _IsPermitted = theStatus;
            foreach (ListenAddressModel listenAddress in TheAddressModelCollcetion)
            {
                listenAddress.IsPermitted = theStatus;
            }
        }

        /// <summary>
        /// 通过的规则制定
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool IsMePermitted(string address)
        {
            //首先验证Hrmis
            if(!_IsPermitted)
            {
                return false;
            }
            //其次验证信道
            ListenAddressModel theAddressModel = GetTheAddressModelBy(address);
            if (theAddressModel == null)
            {
                return false;
            }
            if(!theAddressModel.IsPermitted)
            {
                return false;
            }
            return true;
        }

        public List<string> GetActivedAndPermittedAddress()
        {
            List<string> retVal = new List<string>();

            foreach (ListenAddressModel lam in TheAddressModelCollcetion)
            {
                if (lam.IsActivited && lam.IsPermitted)
                {
                    retVal.Add(lam.ListenAddress);
                }
            }

            return retVal;
        }

        public List<string> GetActivedAddress()
        {
            List<string> retVal = new List<string>();

            foreach (ListenAddressModel lam in TheAddressModelCollcetion)
            {
                if (lam.IsActivited)
                {
                    retVal.Add(lam.ListenAddress);
                }
            }

            return retVal;
        }

        /// <summary>
        /// 未知的客户构建对象
        /// </summary>
        public static ClientInformationModel CreateGuestAddress(string address, string hrmisId, bool isTheClientAddressGood)
        {
            ClientInformationModel aNewClientAddrssModel = new ClientInformationModel(hrmisId, "未定义的公司", false);
            aNewClientAddrssModel.TryAddDiffierentListenAddress(address, isTheClientAddressGood);
            return aNewClientAddrssModel;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(ClientInformationModel)) return false;
            return Equals((ClientInformationModel)obj);
        }

        public bool Equals(ClientInformationModel obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj._Pkid == _Pkid && Equals(obj._HrmisId, _HrmisId) && Equals(obj._CompanyDescription, _CompanyDescription) && obj._IsPermitted.Equals(_IsPermitted) && CollectionEquals(obj);
        }

        private bool CollectionEquals(ClientInformationModel obj)
        {
            int theCount = obj._TheAddressModelCollcetion.Count;

            if(_TheAddressModelCollcetion.Count != theCount)
            {
                return false;
            }
            for(int i =0 ;i<theCount ;i++)
            {
                if(!obj._TheAddressModelCollcetion[i].Equals(_TheAddressModelCollcetion[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = _Pkid;
                result = (result*397) ^ (_HrmisId != null ? _HrmisId.GetHashCode() : 0);
                result = (result*397) ^ (_CompanyDescription != null ? _CompanyDescription.GetHashCode() : 0);
                result = (result*397) ^ _IsPermitted.GetHashCode();
                result = (result*397) ^ (_TheAddressModelCollcetion != null ? _TheAddressModelCollcetion.GetHashCode() : 0);
                return result;
            }
        }
    }
}