﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行库版本:2.0.50727.3082
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReadDataAccessModel
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataFromAccess", Namespace="http://schemas.datacontract.org/2004/07/ReadDataAccessModel")]
    public partial class DataFromAccess : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string CardNoField;
        
        private System.DateTime IOTimeField;
        
        private ReadDataAccessModel.InOutStatusEnum InOrOutField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CardNo
        {
            get
            {
                return this.CardNoField;
            }
            set
            {
                this.CardNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime IOTime
        {
            get
            {
                return this.IOTimeField;
            }
            set
            {
                this.IOTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ReadDataAccessModel.InOutStatusEnum InOrOut
        {
            get
            {
                return this.InOrOutField;
            }
            set
            {
                this.InOrOutField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InOutStatusEnum", Namespace="http://schemas.datacontract.org/2004/07/ReadDataAccessModel")]
    public enum InOutStatusEnum : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        All = -1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        In = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Out = 1,
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IReadData")]
public interface IReadData
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadData/ReadRecords", ReplyAction="http://tempuri.org/IReadData/ReadRecordsResponse")]
    ReadDataAccessModel.DataFromAccess[] ReadRecords(System.DateTime lastReadTime);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReadData/ReadRecordsWithReadTime", ReplyAction="http://tempuri.org/IReadData/ReadRecordsWithReadTimeResponse")]
    ReadDataAccessModel.DataFromAccess[] ReadRecordsWithReadTime(System.DateTime readFromTime, System.DateTime readToTime);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IReadDataChannel : IReadData, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class ReadDataClient : System.ServiceModel.ClientBase<IReadData>, IReadData
{
    
    public ReadDataClient()
    {
    }
    
    public ReadDataClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ReadDataClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ReadDataClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ReadDataClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public ReadDataAccessModel.DataFromAccess[] ReadRecords(System.DateTime lastReadTime)
    {
        return base.Channel.ReadRecords(lastReadTime);
    }
    
    public ReadDataAccessModel.DataFromAccess[] ReadRecordsWithReadTime(System.DateTime readFromTime, System.DateTime readToTime)
    {
        return base.Channel.ReadRecordsWithReadTime(readFromTime, readToTime);
    }
}
