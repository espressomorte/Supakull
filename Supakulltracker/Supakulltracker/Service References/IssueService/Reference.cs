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
    [System.Runtime.Serialization.DataContractAttribute(Name="ProxyTaskMain", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class ProxyTaskMain : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TaskIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubtaskTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SummaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreatedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreatedByField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LinkToTrackerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstimationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TargetVersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CommentsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Supakulltracker.IssueService.ProxyUsersList[] AssignedField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string TaskID {
            get {
                return this.TaskIDField;
            }
            set {
                if ((object.ReferenceEquals(this.TaskIDField, value) != true)) {
                    this.TaskIDField = value;
                    this.RaisePropertyChanged("TaskID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string SubtaskType {
            get {
                return this.SubtaskTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.SubtaskTypeField, value) != true)) {
                    this.SubtaskTypeField = value;
                    this.RaisePropertyChanged("SubtaskType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Summary {
            get {
                return this.SummaryField;
            }
            set {
                if ((object.ReferenceEquals(this.SummaryField, value) != true)) {
                    this.SummaryField = value;
                    this.RaisePropertyChanged("Summary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((object.ReferenceEquals(this.PriorityField, value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string Product {
            get {
                return this.ProductField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductField, value) != true)) {
                    this.ProductField = value;
                    this.RaisePropertyChanged("Product");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Project {
            get {
                return this.ProjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectField, value) != true)) {
                    this.ProjectField = value;
                    this.RaisePropertyChanged("Project");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string CreatedDate {
            get {
                return this.CreatedDateField;
            }
            set {
                if ((object.ReferenceEquals(this.CreatedDateField, value) != true)) {
                    this.CreatedDateField = value;
                    this.RaisePropertyChanged("CreatedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string CreatedBy {
            get {
                return this.CreatedByField;
            }
            set {
                if ((object.ReferenceEquals(this.CreatedByField, value) != true)) {
                    this.CreatedByField = value;
                    this.RaisePropertyChanged("CreatedBy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string LinkToTracker {
            get {
                return this.LinkToTrackerField;
            }
            set {
                if ((object.ReferenceEquals(this.LinkToTrackerField, value) != true)) {
                    this.LinkToTrackerField = value;
                    this.RaisePropertyChanged("LinkToTracker");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=11)]
        public string Estimation {
            get {
                return this.EstimationField;
            }
            set {
                if ((object.ReferenceEquals(this.EstimationField, value) != true)) {
                    this.EstimationField = value;
                    this.RaisePropertyChanged("Estimation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string TargetVersion {
            get {
                return this.TargetVersionField;
            }
            set {
                if ((object.ReferenceEquals(this.TargetVersionField, value) != true)) {
                    this.TargetVersionField = value;
                    this.RaisePropertyChanged("TargetVersion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string Comments {
            get {
                return this.CommentsField;
            }
            set {
                if ((object.ReferenceEquals(this.CommentsField, value) != true)) {
                    this.CommentsField = value;
                    this.RaisePropertyChanged("Comments");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public Supakulltracker.IssueService.ProxyUsersList[] Assigned {
            get {
                return this.AssignedField;
            }
            set {
                if ((object.ReferenceEquals(this.AssignedField, value) != true)) {
                    this.AssignedField = value;
                    this.RaisePropertyChanged("Assigned");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ProxyUsersList", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class ProxyUsersList : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Supakulltracker.IssueService.ProxyTaskMain[] TaskListField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIdField, value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public Supakulltracker.IssueService.ProxyTaskMain[] TaskList {
            get {
                return this.TaskListField;
            }
            set {
                if ((object.ReferenceEquals(this.TaskListField, value) != true)) {
                    this.TaskListField = value;
                    this.RaisePropertyChanged("TaskList");
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
        public Supakulltracker.IssueService.ProxyTaskMain[] GetAllIssuesResult;
        
        public GetAllIssuesResponseBody() {
        }
        
        public GetAllIssuesResponseBody(Supakulltracker.IssueService.ProxyTaskMain[] GetAllIssuesResult) {
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
        
        public Supakulltracker.IssueService.ProxyTaskMain[] GetAllIssues() {
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
