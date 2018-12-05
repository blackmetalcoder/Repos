﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceSMS.ServiceSkicka {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://genericmobile.se/MessItGateway", ConfigurationName="ServiceSkicka.MessItGatewaySoap")]
    public interface MessItGatewaySoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://genericmobile.se/MessItGateway/SendMessages", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SendMessages(string user, string password, string xml, bool async);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://genericmobile.se/MessItGateway/SendMessages", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SendMessagesAsync(string user, string password, string xml, bool async);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://genericmobile.se/MessItGateway/GetInbox", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetInbox(string user, string password, bool onlyNewMessages);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://genericmobile.se/MessItGateway/GetInbox", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetInboxAsync(string user, string password, bool onlyNewMessages);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://genericmobile.se/MessItGateway/DeleteInboxItem", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string DeleteInboxItem(string user, string password, int smsID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://genericmobile.se/MessItGateway/DeleteInboxItem", ReplyAction="*")]
        System.Threading.Tasks.Task<string> DeleteInboxItemAsync(string user, string password, int smsID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface MessItGatewaySoapChannel : ServiceSMS.ServiceSkicka.MessItGatewaySoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessItGatewaySoapClient : System.ServiceModel.ClientBase<ServiceSMS.ServiceSkicka.MessItGatewaySoap>, ServiceSMS.ServiceSkicka.MessItGatewaySoap {
        
        public MessItGatewaySoapClient() {
        }
        
        public MessItGatewaySoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MessItGatewaySoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessItGatewaySoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessItGatewaySoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string SendMessages(string user, string password, string xml, bool async) {
            return base.Channel.SendMessages(user, password, xml, async);
        }
        
        public System.Threading.Tasks.Task<string> SendMessagesAsync(string user, string password, string xml, bool async) {
            return base.Channel.SendMessagesAsync(user, password, xml, async);
        }
        
        public string GetInbox(string user, string password, bool onlyNewMessages) {
            return base.Channel.GetInbox(user, password, onlyNewMessages);
        }
        
        public System.Threading.Tasks.Task<string> GetInboxAsync(string user, string password, bool onlyNewMessages) {
            return base.Channel.GetInboxAsync(user, password, onlyNewMessages);
        }
        
        public string DeleteInboxItem(string user, string password, int smsID) {
            return base.Channel.DeleteInboxItem(user, password, smsID);
        }
        
        public System.Threading.Tasks.Task<string> DeleteInboxItemAsync(string user, string password, int smsID) {
            return base.Channel.DeleteInboxItemAsync(user, password, smsID);
        }
    }
}