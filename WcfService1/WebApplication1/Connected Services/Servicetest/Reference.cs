﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Servicetest {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Servicetest.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.IAsyncResult BeginGetData(int value, System.AsyncCallback callback, object asyncState);
        
        string EndGetData(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllBooks", ReplyAction="http://tempuri.org/IService1/GetAllBooksResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WebApplication1.Servicetest.CompositeType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetAllBooks();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetAllBooks", ReplyAction="http://tempuri.org/IService1/GetAllBooksResponse")]
        System.IAsyncResult BeginGetAllBooks(System.AsyncCallback callback, object asyncState);
        
        object[] EndGetAllBooks(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetBook", ReplyAction="http://tempuri.org/IService1/GetBookResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WebApplication1.Servicetest.CompositeType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetBook();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetBook", ReplyAction="http://tempuri.org/IService1/GetBookResponse")]
        System.IAsyncResult BeginGetBook(System.AsyncCallback callback, object asyncState);
        
        object[] EndGetBook(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Hello", ReplyAction="http://tempuri.org/IService1/HelloResponse")]
        string Hello(string name);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/Hello", ReplyAction="http://tempuri.org/IService1/HelloResponse")]
        System.IAsyncResult BeginHello(string name, System.AsyncCallback callback, object asyncState);
        
        string EndHello(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        WebApplication1.Servicetest.CompositeType GetDataUsingDataContract(WebApplication1.Servicetest.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.IAsyncResult BeginGetDataUsingDataContract(WebApplication1.Servicetest.CompositeType composite, System.AsyncCallback callback, object asyncState);
        
        WebApplication1.Servicetest.CompositeType EndGetDataUsingDataContract(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebApplication1.Servicetest.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetAllBooksCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetAllBooksCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public object[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetBookCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetBookCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public object[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((object[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HelloCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public HelloCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDataUsingDataContractCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetDataUsingDataContractCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public WebApplication1.Servicetest.CompositeType Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((WebApplication1.Servicetest.CompositeType)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebApplication1.Servicetest.IService1>, WebApplication1.Servicetest.IService1 {
        
        private BeginOperationDelegate onBeginGetDataDelegate;
        
        private EndOperationDelegate onEndGetDataDelegate;
        
        private System.Threading.SendOrPostCallback onGetDataCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetAllBooksDelegate;
        
        private EndOperationDelegate onEndGetAllBooksDelegate;
        
        private System.Threading.SendOrPostCallback onGetAllBooksCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetBookDelegate;
        
        private EndOperationDelegate onEndGetBookDelegate;
        
        private System.Threading.SendOrPostCallback onGetBookCompletedDelegate;
        
        private BeginOperationDelegate onBeginHelloDelegate;
        
        private EndOperationDelegate onEndHelloDelegate;
        
        private System.Threading.SendOrPostCallback onHelloCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetDataUsingDataContractDelegate;
        
        private EndOperationDelegate onEndGetDataUsingDataContractDelegate;
        
        private System.Threading.SendOrPostCallback onGetDataUsingDataContractCompletedDelegate;
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<GetDataCompletedEventArgs> GetDataCompleted;
        
        public event System.EventHandler<GetAllBooksCompletedEventArgs> GetAllBooksCompleted;
        
        public event System.EventHandler<GetBookCompletedEventArgs> GetBookCompleted;
        
        public event System.EventHandler<HelloCompletedEventArgs> HelloCompleted;
        
        public event System.EventHandler<GetDataUsingDataContractCompletedEventArgs> GetDataUsingDataContractCompleted;
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetData(int value, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetData(value, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndGetData(System.IAsyncResult result) {
            return base.Channel.EndGetData(result);
        }
        
        private System.IAsyncResult OnBeginGetData(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int value = ((int)(inValues[0]));
            return this.BeginGetData(value, callback, asyncState);
        }
        
        private object[] OnEndGetData(System.IAsyncResult result) {
            string retVal = this.EndGetData(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetDataCompleted(object state) {
            if ((this.GetDataCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetDataCompleted(this, new GetDataCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetDataAsync(int value) {
            this.GetDataAsync(value, null);
        }
        
        public void GetDataAsync(int value, object userState) {
            if ((this.onBeginGetDataDelegate == null)) {
                this.onBeginGetDataDelegate = new BeginOperationDelegate(this.OnBeginGetData);
            }
            if ((this.onEndGetDataDelegate == null)) {
                this.onEndGetDataDelegate = new EndOperationDelegate(this.OnEndGetData);
            }
            if ((this.onGetDataCompletedDelegate == null)) {
                this.onGetDataCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetDataCompleted);
            }
            base.InvokeAsync(this.onBeginGetDataDelegate, new object[] {
                        value}, this.onEndGetDataDelegate, this.onGetDataCompletedDelegate, userState);
        }
        
        public object[] GetAllBooks() {
            return base.Channel.GetAllBooks();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetAllBooks(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetAllBooks(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public object[] EndGetAllBooks(System.IAsyncResult result) {
            return base.Channel.EndGetAllBooks(result);
        }
        
        private System.IAsyncResult OnBeginGetAllBooks(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetAllBooks(callback, asyncState);
        }
        
        private object[] OnEndGetAllBooks(System.IAsyncResult result) {
            object[] retVal = this.EndGetAllBooks(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetAllBooksCompleted(object state) {
            if ((this.GetAllBooksCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetAllBooksCompleted(this, new GetAllBooksCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetAllBooksAsync() {
            this.GetAllBooksAsync(null);
        }
        
        public void GetAllBooksAsync(object userState) {
            if ((this.onBeginGetAllBooksDelegate == null)) {
                this.onBeginGetAllBooksDelegate = new BeginOperationDelegate(this.OnBeginGetAllBooks);
            }
            if ((this.onEndGetAllBooksDelegate == null)) {
                this.onEndGetAllBooksDelegate = new EndOperationDelegate(this.OnEndGetAllBooks);
            }
            if ((this.onGetAllBooksCompletedDelegate == null)) {
                this.onGetAllBooksCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetAllBooksCompleted);
            }
            base.InvokeAsync(this.onBeginGetAllBooksDelegate, null, this.onEndGetAllBooksDelegate, this.onGetAllBooksCompletedDelegate, userState);
        }
        
        public object[] GetBook() {
            return base.Channel.GetBook();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetBook(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetBook(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public object[] EndGetBook(System.IAsyncResult result) {
            return base.Channel.EndGetBook(result);
        }
        
        private System.IAsyncResult OnBeginGetBook(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetBook(callback, asyncState);
        }
        
        private object[] OnEndGetBook(System.IAsyncResult result) {
            object[] retVal = this.EndGetBook(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetBookCompleted(object state) {
            if ((this.GetBookCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetBookCompleted(this, new GetBookCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetBookAsync() {
            this.GetBookAsync(null);
        }
        
        public void GetBookAsync(object userState) {
            if ((this.onBeginGetBookDelegate == null)) {
                this.onBeginGetBookDelegate = new BeginOperationDelegate(this.OnBeginGetBook);
            }
            if ((this.onEndGetBookDelegate == null)) {
                this.onEndGetBookDelegate = new EndOperationDelegate(this.OnEndGetBook);
            }
            if ((this.onGetBookCompletedDelegate == null)) {
                this.onGetBookCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetBookCompleted);
            }
            base.InvokeAsync(this.onBeginGetBookDelegate, null, this.onEndGetBookDelegate, this.onGetBookCompletedDelegate, userState);
        }
        
        public string Hello(string name) {
            return base.Channel.Hello(name);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginHello(string name, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginHello(name, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndHello(System.IAsyncResult result) {
            return base.Channel.EndHello(result);
        }
        
        private System.IAsyncResult OnBeginHello(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string name = ((string)(inValues[0]));
            return this.BeginHello(name, callback, asyncState);
        }
        
        private object[] OnEndHello(System.IAsyncResult result) {
            string retVal = this.EndHello(result);
            return new object[] {
                    retVal};
        }
        
        private void OnHelloCompleted(object state) {
            if ((this.HelloCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.HelloCompleted(this, new HelloCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void HelloAsync(string name) {
            this.HelloAsync(name, null);
        }
        
        public void HelloAsync(string name, object userState) {
            if ((this.onBeginHelloDelegate == null)) {
                this.onBeginHelloDelegate = new BeginOperationDelegate(this.OnBeginHello);
            }
            if ((this.onEndHelloDelegate == null)) {
                this.onEndHelloDelegate = new EndOperationDelegate(this.OnEndHello);
            }
            if ((this.onHelloCompletedDelegate == null)) {
                this.onHelloCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnHelloCompleted);
            }
            base.InvokeAsync(this.onBeginHelloDelegate, new object[] {
                        name}, this.onEndHelloDelegate, this.onHelloCompletedDelegate, userState);
        }
        
        public WebApplication1.Servicetest.CompositeType GetDataUsingDataContract(WebApplication1.Servicetest.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetDataUsingDataContract(WebApplication1.Servicetest.CompositeType composite, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetDataUsingDataContract(composite, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public WebApplication1.Servicetest.CompositeType EndGetDataUsingDataContract(System.IAsyncResult result) {
            return base.Channel.EndGetDataUsingDataContract(result);
        }
        
        private System.IAsyncResult OnBeginGetDataUsingDataContract(object[] inValues, System.AsyncCallback callback, object asyncState) {
            WebApplication1.Servicetest.CompositeType composite = ((WebApplication1.Servicetest.CompositeType)(inValues[0]));
            return this.BeginGetDataUsingDataContract(composite, callback, asyncState);
        }
        
        private object[] OnEndGetDataUsingDataContract(System.IAsyncResult result) {
            WebApplication1.Servicetest.CompositeType retVal = this.EndGetDataUsingDataContract(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetDataUsingDataContractCompleted(object state) {
            if ((this.GetDataUsingDataContractCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetDataUsingDataContractCompleted(this, new GetDataUsingDataContractCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetDataUsingDataContractAsync(WebApplication1.Servicetest.CompositeType composite) {
            this.GetDataUsingDataContractAsync(composite, null);
        }
        
        public void GetDataUsingDataContractAsync(WebApplication1.Servicetest.CompositeType composite, object userState) {
            if ((this.onBeginGetDataUsingDataContractDelegate == null)) {
                this.onBeginGetDataUsingDataContractDelegate = new BeginOperationDelegate(this.OnBeginGetDataUsingDataContract);
            }
            if ((this.onEndGetDataUsingDataContractDelegate == null)) {
                this.onEndGetDataUsingDataContractDelegate = new EndOperationDelegate(this.OnEndGetDataUsingDataContract);
            }
            if ((this.onGetDataUsingDataContractCompletedDelegate == null)) {
                this.onGetDataUsingDataContractCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetDataUsingDataContractCompleted);
            }
            base.InvokeAsync(this.onBeginGetDataUsingDataContractDelegate, new object[] {
                        composite}, this.onEndGetDataUsingDataContractDelegate, this.onGetDataUsingDataContractCompletedDelegate, userState);
        }
    }
}