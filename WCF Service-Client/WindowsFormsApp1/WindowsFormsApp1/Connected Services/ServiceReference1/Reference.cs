﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Students", Namespace="http://schemas.datacontract.org/2004/07/Entity")]
    [System.SerializableAttribute()]
    public partial class Students : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string surnameField;
        
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
        public System.Guid id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string surname {
            get {
                return this.surnameField;
            }
            set {
                if ((object.ReferenceEquals(this.surnameField, value) != true)) {
                    this.surnameField = value;
                    this.RaisePropertyChanged("surname");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAll", ReplyAction="http://tempuri.org/IService1/GetAllResponse")]
        WindowsFormsApp1.ServiceReference1.Students[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAll", ReplyAction="http://tempuri.org/IService1/GetAllResponse")]
        System.Threading.Tasks.Task<WindowsFormsApp1.ServiceReference1.Students[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddAlumno", ReplyAction="http://tempuri.org/IService1/AddAlumnoResponse")]
        void AddAlumno(WindowsFormsApp1.ServiceReference1.Students alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AddAlumno", ReplyAction="http://tempuri.org/IService1/AddAlumnoResponse")]
        System.Threading.Tasks.Task AddAlumnoAsync(WindowsFormsApp1.ServiceReference1.Students alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteAlumno", ReplyAction="http://tempuri.org/IService1/DeleteAlumnoResponse")]
        void DeleteAlumno(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteAlumno", ReplyAction="http://tempuri.org/IService1/DeleteAlumnoResponse")]
        System.Threading.Tasks.Task DeleteAlumnoAsync(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAlumno", ReplyAction="http://tempuri.org/IService1/UpdateAlumnoResponse")]
        void UpdateAlumno(WindowsFormsApp1.ServiceReference1.Students alumno);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAlumno", ReplyAction="http://tempuri.org/IService1/UpdateAlumnoResponse")]
        System.Threading.Tasks.Task UpdateAlumnoAsync(WindowsFormsApp1.ServiceReference1.Students alumno);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WindowsFormsApp1.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WindowsFormsApp1.ServiceReference1.IService1>, WindowsFormsApp1.ServiceReference1.IService1 {
        
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
        
        public WindowsFormsApp1.ServiceReference1.Students[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<WindowsFormsApp1.ServiceReference1.Students[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public void AddAlumno(WindowsFormsApp1.ServiceReference1.Students alumno) {
            base.Channel.AddAlumno(alumno);
        }
        
        public System.Threading.Tasks.Task AddAlumnoAsync(WindowsFormsApp1.ServiceReference1.Students alumno) {
            return base.Channel.AddAlumnoAsync(alumno);
        }
        
        public void DeleteAlumno(System.Guid id) {
            base.Channel.DeleteAlumno(id);
        }
        
        public System.Threading.Tasks.Task DeleteAlumnoAsync(System.Guid id) {
            return base.Channel.DeleteAlumnoAsync(id);
        }
        
        public void UpdateAlumno(WindowsFormsApp1.ServiceReference1.Students alumno) {
            base.Channel.UpdateAlumno(alumno);
        }
        
        public System.Threading.Tasks.Task UpdateAlumnoAsync(WindowsFormsApp1.ServiceReference1.Students alumno) {
            return base.Channel.UpdateAlumnoAsync(alumno);
        }
    }
}
