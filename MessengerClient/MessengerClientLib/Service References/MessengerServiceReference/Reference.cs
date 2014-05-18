﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MessengerClientLib.MessengerServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/MessengerServiceLib")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int Idk__BackingFieldField;
        
        private bool Onlinek__BackingFieldField;
        
        private string Usernamek__BackingFieldField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Id>k__BackingField", IsRequired=true)]
        public int Idk__BackingField {
            get {
                return this.Idk__BackingFieldField;
            }
            set {
                if ((this.Idk__BackingFieldField.Equals(value) != true)) {
                    this.Idk__BackingFieldField = value;
                    this.RaisePropertyChanged("Idk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Online>k__BackingField", IsRequired=true)]
        public bool Onlinek__BackingField {
            get {
                return this.Onlinek__BackingFieldField;
            }
            set {
                if ((this.Onlinek__BackingFieldField.Equals(value) != true)) {
                    this.Onlinek__BackingFieldField = value;
                    this.RaisePropertyChanged("Onlinek__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Username>k__BackingField", IsRequired=true)]
        public string Usernamek__BackingField {
            get {
                return this.Usernamek__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.Usernamek__BackingFieldField, value) != true)) {
                    this.Usernamek__BackingFieldField = value;
                    this.RaisePropertyChanged("Usernamek__BackingField");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/MessengerServiceLib")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int RecieverIdField;
        
        private int SenderIdField;
        
        private string TextField;
        
        private int TimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int RecieverId {
            get {
                return this.RecieverIdField;
            }
            set {
                if ((this.RecieverIdField.Equals(value) != true)) {
                    this.RecieverIdField = value;
                    this.RaisePropertyChanged("RecieverId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int SenderId {
            get {
                return this.SenderIdField;
            }
            set {
                if ((this.SenderIdField.Equals(value) != true)) {
                    this.SenderIdField = value;
                    this.RaisePropertyChanged("SenderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MessengerServiceReference.IMessengerService")]
    public interface IMessengerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/Login", ReplyAction="http://tempuri.org/IMessengerService/LoginResponse")]
        MessengerClientLib.MessengerServiceReference.User Login(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/Login", ReplyAction="http://tempuri.org/IMessengerService/LoginResponse")]
        System.Threading.Tasks.Task<MessengerClientLib.MessengerServiceReference.User> LoginAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/GetUsers", ReplyAction="http://tempuri.org/IMessengerService/GetUsersResponse")]
        MessengerClientLib.MessengerServiceReference.User[] GetUsers(int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/GetUsers", ReplyAction="http://tempuri.org/IMessengerService/GetUsersResponse")]
        System.Threading.Tasks.Task<MessengerClientLib.MessengerServiceReference.User[]> GetUsersAsync(int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/SendMessage", ReplyAction="http://tempuri.org/IMessengerService/SendMessageResponse")]
        void SendMessage(MessengerClientLib.MessengerServiceReference.Message message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/SendMessage", ReplyAction="http://tempuri.org/IMessengerService/SendMessageResponse")]
        System.Threading.Tasks.Task SendMessageAsync(MessengerClientLib.MessengerServiceReference.Message message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/GetUserName", ReplyAction="http://tempuri.org/IMessengerService/GetUserNameResponse")]
        string GetUserName(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/GetUserName", ReplyAction="http://tempuri.org/IMessengerService/GetUserNameResponse")]
        System.Threading.Tasks.Task<string> GetUserNameAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/GetMessages", ReplyAction="http://tempuri.org/IMessengerService/GetMessagesResponse")]
        MessengerClientLib.MessengerServiceReference.Message[] GetMessages(int senderId, int recieverId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessengerService/GetMessages", ReplyAction="http://tempuri.org/IMessengerService/GetMessagesResponse")]
        System.Threading.Tasks.Task<MessengerClientLib.MessengerServiceReference.Message[]> GetMessagesAsync(int senderId, int recieverId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessengerServiceChannel : MessengerClientLib.MessengerServiceReference.IMessengerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessengerServiceClient : System.ServiceModel.ClientBase<MessengerClientLib.MessengerServiceReference.IMessengerService>, MessengerClientLib.MessengerServiceReference.IMessengerService {
        
        public MessengerServiceClient() {
        }
        
        public MessengerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MessengerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessengerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessengerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MessengerClientLib.MessengerServiceReference.User Login(string username) {
            return base.Channel.Login(username);
        }
        
        public System.Threading.Tasks.Task<MessengerClientLib.MessengerServiceReference.User> LoginAsync(string username) {
            return base.Channel.LoginAsync(username);
        }
        
        public MessengerClientLib.MessengerServiceReference.User[] GetUsers(int userID) {
            return base.Channel.GetUsers(userID);
        }
        
        public System.Threading.Tasks.Task<MessengerClientLib.MessengerServiceReference.User[]> GetUsersAsync(int userID) {
            return base.Channel.GetUsersAsync(userID);
        }
        
        public void SendMessage(MessengerClientLib.MessengerServiceReference.Message message) {
            base.Channel.SendMessage(message);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(MessengerClientLib.MessengerServiceReference.Message message) {
            return base.Channel.SendMessageAsync(message);
        }
        
        public string GetUserName(int userId) {
            return base.Channel.GetUserName(userId);
        }
        
        public System.Threading.Tasks.Task<string> GetUserNameAsync(int userId) {
            return base.Channel.GetUserNameAsync(userId);
        }
        
        public MessengerClientLib.MessengerServiceReference.Message[] GetMessages(int senderId, int recieverId) {
            return base.Channel.GetMessages(senderId, recieverId);
        }
        
        public System.Threading.Tasks.Task<MessengerClientLib.MessengerServiceReference.Message[]> GetMessagesAsync(int senderId, int recieverId) {
            return base.Channel.GetMessagesAsync(senderId, recieverId);
        }
    }
}
