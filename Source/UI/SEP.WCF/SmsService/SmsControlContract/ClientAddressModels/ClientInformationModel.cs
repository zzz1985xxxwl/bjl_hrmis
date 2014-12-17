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
        /// ��˾ID��˫�����壬��ʱӲ�����ڳ�����
        /// </summary>
        public string HrmisId
        {
            get { return _HrmisId; }
            set { _HrmisId = value; }
        }
        /// <summary>
        /// ��˾����
        /// </summary>
        public string CompanyDescription
        {
            get { return _CompanyDescription; }
            set { _CompanyDescription = value; }
        }
        /// <summary>
        /// �Ƿ���֤
        /// </summary>
        public bool IsPermitted
        {
            get { return _IsPermitted; }
            set { _IsPermitted = value; }
        }
        /// <summary>
        /// ��ַ�б�
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
        /// ���Ըı������ַ(�е�ַ���޸ģ��޵�ַ������)����������ڿͻ����������ע��ʱ�����
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
        /// ��ȡ��ǰ��������Ҫ�㲥�Ŀͻ��˵�ַ����Щ��ַ��Ҫ�㲥�Ĺ����ƶ��ڴ˴�
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
        /// ���ÿͻ��˷����״̬���Ƿ���
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
        /// ͨ���Ĺ����ƶ�
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool IsMePermitted(string address)
        {
            //������֤Hrmis
            if(!_IsPermitted)
            {
                return false;
            }
            //�����֤�ŵ�
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
        /// δ֪�Ŀͻ���������
        /// </summary>
        public static ClientInformationModel CreateGuestAddress(string address, string hrmisId, bool isTheClientAddressGood)
        {
            ClientInformationModel aNewClientAddrssModel = new ClientInformationModel(hrmisId, "δ����Ĺ�˾", false);
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