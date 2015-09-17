﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Supakulltracker.IssueService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Issue", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Issue : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long issueIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string issueUFIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string summaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string typeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string statusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string severityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string priorityField;
        
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
        public long issueID {
            get {
                return this.issueIDField;
            }
            set {
                if ((this.issueIDField.Equals(value) != true)) {
                    this.issueIDField = value;
                    this.RaisePropertyChanged("issueID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string issueUFID {
            get {
                return this.issueUFIDField;
            }
            set {
                if ((object.ReferenceEquals(this.issueUFIDField, value) != true)) {
                    this.issueUFIDField = value;
                    this.RaisePropertyChanged("issueUFID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string summary {
            get {
                return this.summaryField;
            }
            set {
                if ((object.ReferenceEquals(this.summaryField, value) != true)) {
                    this.summaryField = value;
                    this.RaisePropertyChanged("summary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string type {
            get {
                return this.typeField;
            }
            set {
                if ((object.ReferenceEquals(this.typeField, value) != true)) {
                    this.typeField = value;
                    this.RaisePropertyChanged("type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string status {
            get {
                return this.statusField;
            }
            set {
                if ((object.ReferenceEquals(this.statusField, value) != true)) {
                    this.statusField = value;
                    this.RaisePropertyChanged("status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string severity {
            get {
                return this.severityField;
            }
            set {
                if ((object.ReferenceEquals(this.severityField, value) != true)) {
                    this.severityField = value;
                    this.RaisePropertyChanged("severity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string priority {
            get {
                return this.priorityField;
            }
            set {
                if ((object.ReferenceEquals(this.priorityField, value) != true)) {
                    this.priorityField = value;
                    this.RaisePropertyChanged("priority");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="IssueService.GetTrackerServicesSoap")]
    public interface GetTrackerServicesSoap {
        
        // CODEGEN: Generating message contract since element name GetAllIssuesResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllIssues", ReplyAction="*")]
        Supakulltracker.IssueService.GetAllIssuesResponse GetAllIssues(Supakulltracker.IssueService.GetAllIssuesRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllIssues", ReplyAction="*")]
        System.Threading.Tasks.Task<Supakulltracker.IssueService.GetAllIssuesResponse> GetAllIssuesAsync(Supakulltracker.IssueService.GetAllIssuesRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllIssuesRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllIssues", Namespace="http://tempuri.org/", Order=0)]
        public Supakulltracker.IssueService.GetAllIssuesRequestBody Body;
        
        public GetAllIssuesRequest() {
        }
        
        public GetAllIssuesRequest(Supakulltracker.IssueService.GetAllIssuesRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetAllIssuesRequestBody {
        
        public GetAllIssuesRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllIssuesResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllIssuesResponse", Namespace="http://tempuri.org/", Order=0)]
        public Supakulltracker.IssueService.GetAllIssuesResponseBody Body;
        
        public GetAllIssuesResponse() {
        }
        
        public GetAllIssuesResponse(Supakulltracker.IssueService.GetAllIssuesResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAllIssuesResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public Supakulltracker.IssueService.Issue[] GetAllIssuesResult;
        
        public GetAllIssuesResponseBody() {
        }
        
        public GetAllIssuesResponseBody(Supakulltracker.IssueService.Issue[] GetAllIssuesResult) {
            this.GetAllIssuesResult = GetAllIssuesResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface GetTrackerServicesSoapChannel : Supakulltracker.IssueService.GetTrackerServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetTrackerServicesSoapClient : System.ServiceModel.ClientBase<Supakulltracker.IssueService.GetTrackerServicesSoap>, Supakulltracker.IssueService.GetTrackerServicesSoap {
        
        public GetTrackerServicesSoapClient() {
        }
        
        public GetTrackerServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetTrackerServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetTrackerServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetTrackerServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Supakulltracker.IssueService.GetAllIssuesResponse Supakulltracker.IssueService.GetTrackerServicesSoap.GetAllIssues(Supakulltracker.IssueService.GetAllIssuesRequest request) {
            return base.Channel.GetAllIssues(request);
        }
        
        public Supakulltracker.IssueService.Issue[] GetAllIssues() {
            Supakulltracker.IssueService.GetAllIssuesRequest inValue = new Supakulltracker.IssueService.GetAllIssuesRequest();
            inValue.Body = new Supakulltracker.IssueService.GetAllIssuesRequestBody();
            Supakulltracker.IssueService.GetAllIssuesResponse retVal = ((Supakulltracker.IssueService.GetTrackerServicesSoap)(this)).GetAllIssues(inValue);
            return retVal.Body.GetAllIssuesResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Supakulltracker.IssueService.GetAllIssuesResponse> Supakulltracker.IssueService.GetTrackerServicesSoap.GetAllIssuesAsync(Supakulltracker.IssueService.GetAllIssuesRequest request) {
            return base.Channel.GetAllIssuesAsync(request);
        }
        
        public System.Threading.Tasks.Task<Supakulltracker.IssueService.GetAllIssuesResponse> GetAllIssuesAsync() {
            Supakulltracker.IssueService.GetAllIssuesRequest inValue = new Supakulltracker.IssueService.GetAllIssuesRequest();
            inValue.Body = new Supakulltracker.IssueService.GetAllIssuesRequestBody();
            return ((Supakulltracker.IssueService.GetTrackerServicesSoap)(this)).GetAllIssuesAsync(inValue);
        }
    }
}
