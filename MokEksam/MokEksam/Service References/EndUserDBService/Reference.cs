﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 14.0.23107.0
// 

using System;

namespace MokEksam.EndUserDBService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EndUser", Namespace="http://schemas.datacontract.org/2004/07/EndUserDatabase")]
    public partial class EndUser : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string user_emailField;
        
        private string user_nameField;
        
        private string user_passwordField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string user_email {
            get {
                return this.user_emailField;
            }
            set {
                if ((object.ReferenceEquals(this.user_emailField, value) != true)) {
                    this.user_emailField = value;
                    this.RaisePropertyChanged("user_email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string user_name {
            get {
                return this.user_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.user_nameField, value) != true)) {
                    this.user_nameField = value;
                    this.RaisePropertyChanged("user_name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string user_password {
            get {
                return this.user_passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.user_passwordField, value) != true)) {
                    this.user_passwordField = value;
                    this.RaisePropertyChanged("user_password");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EndUserDBService.IEndUserDatabaseService")]
    public interface IEndUserDatabaseService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEndUserDatabaseService/GetEndUser", ReplyAction="http://tempuri.org/IEndUserDatabaseService/GetEndUserResponse")]
        System.Threading.Tasks.Task<string> GetEndUserAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEndUserDatabaseService/InsertEndUser", ReplyAction="http://tempuri.org/IEndUserDatabaseService/InsertEndUserResponse")]
        System.Threading.Tasks.Task<MokEksam.EndUserDBService.EndUser> InsertEndUserAsync(MokEksam.EndUserDBService.EndUser newEndUser);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEndUserDatabaseServiceChannel : MokEksam.EndUserDBService.IEndUserDatabaseService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EndUserDatabaseServiceClient : System.ServiceModel.ClientBase<MokEksam.EndUserDBService.IEndUserDatabaseService>, MokEksam.EndUserDBService.IEndUserDatabaseService, IDisposable
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public EndUserDatabaseServiceClient() : 
                base(EndUserDatabaseServiceClient.GetDefaultBinding(), EndUserDatabaseServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IEndUserDatabaseService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EndUserDatabaseServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(EndUserDatabaseServiceClient.GetBindingForEndpoint(endpointConfiguration), EndUserDatabaseServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EndUserDatabaseServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(EndUserDatabaseServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EndUserDatabaseServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(EndUserDatabaseServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public EndUserDatabaseServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<string> GetEndUserAsync(string username) {
            return base.Channel.GetEndUserAsync(username);
        }
        
        public System.Threading.Tasks.Task<MokEksam.EndUserDBService.EndUser> InsertEndUserAsync(MokEksam.EndUserDBService.EndUser newEndUser) {
            return base.Channel.InsertEndUserAsync(newEndUser);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IEndUserDatabaseService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IEndUserDatabaseService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:62344/EndUserDatabaseService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return EndUserDatabaseServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IEndUserDatabaseService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return EndUserDatabaseServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IEndUserDatabaseService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IEndUserDatabaseService,
        }

        public void Dispose()
        {
            
        }
    }
}
