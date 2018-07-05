﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppDispatcher.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AbstractPerson", Namespace="http://schemas.datacontract.org/2004/07/DAL")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WpfAppDispatcher.ServiceReference.Driver))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WpfAppDispatcher.ServiceReference.Dispatcher))]
    public partial class AbstractPerson : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SecondNameField;
        
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
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SecondName {
            get {
                return this.SecondNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SecondNameField, value) != true)) {
                    this.SecondNameField = value;
                    this.RaisePropertyChanged("SecondName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Driver", Namespace="http://schemas.datacontract.org/2004/07/DAL")]
    [System.SerializableAttribute()]
    public partial class Driver : WpfAppDispatcher.ServiceReference.AbstractPerson {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WpfAppDispatcher.ServiceReference.Car CarField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double KMField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WpfAppDispatcher.ServiceReference.Location LocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double MoneyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WpfAppDispatcher.ServiceReference.Report[] ReportsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WpfAppDispatcher.ServiceReference.Car Car {
            get {
                return this.CarField;
            }
            set {
                if ((object.ReferenceEquals(this.CarField, value) != true)) {
                    this.CarField = value;
                    this.RaisePropertyChanged("Car");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double KM {
            get {
                return this.KMField;
            }
            set {
                if ((this.KMField.Equals(value) != true)) {
                    this.KMField = value;
                    this.RaisePropertyChanged("KM");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WpfAppDispatcher.ServiceReference.Location Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Money {
            get {
                return this.MoneyField;
            }
            set {
                if ((this.MoneyField.Equals(value) != true)) {
                    this.MoneyField = value;
                    this.RaisePropertyChanged("Money");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WpfAppDispatcher.ServiceReference.Report[] Reports {
            get {
                return this.ReportsField;
            }
            set {
                if ((object.ReferenceEquals(this.ReportsField, value) != true)) {
                    this.ReportsField = value;
                    this.RaisePropertyChanged("Reports");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Dispatcher", Namespace="http://schemas.datacontract.org/2004/07/DAL")]
    [System.SerializableAttribute()]
    public partial class Dispatcher : WpfAppDispatcher.ServiceReference.AbstractPerson {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Car", Namespace="http://schemas.datacontract.org/2004/07/DAL")]
    [System.SerializableAttribute()]
    public partial class Car : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WpfAppDispatcher.ServiceReference.ClassesOfCar ClassOfCarField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WpfAppDispatcher.ServiceReference.Driver[] DriversField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MarkaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int VolumeField;
        
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
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WpfAppDispatcher.ServiceReference.ClassesOfCar ClassOfCar {
            get {
                return this.ClassOfCarField;
            }
            set {
                if ((this.ClassOfCarField.Equals(value) != true)) {
                    this.ClassOfCarField = value;
                    this.RaisePropertyChanged("ClassOfCar");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WpfAppDispatcher.ServiceReference.Driver[] Drivers {
            get {
                return this.DriversField;
            }
            set {
                if ((object.ReferenceEquals(this.DriversField, value) != true)) {
                    this.DriversField = value;
                    this.RaisePropertyChanged("Drivers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Marka {
            get {
                return this.MarkaField;
            }
            set {
                if ((object.ReferenceEquals(this.MarkaField, value) != true)) {
                    this.MarkaField = value;
                    this.RaisePropertyChanged("Marka");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Volume {
            get {
                return this.VolumeField;
            }
            set {
                if ((this.VolumeField.Equals(value) != true)) {
                    this.VolumeField = value;
                    this.RaisePropertyChanged("Volume");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Location", Namespace="http://schemas.datacontract.org/2004/07/DAL")]
    [System.SerializableAttribute()]
    public partial class Location : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WpfAppDispatcher.ServiceReference.Driver[] DriversField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LatField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LngField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PlaceField;
        
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
        public WpfAppDispatcher.ServiceReference.Driver[] Drivers {
            get {
                return this.DriversField;
            }
            set {
                if ((object.ReferenceEquals(this.DriversField, value) != true)) {
                    this.DriversField = value;
                    this.RaisePropertyChanged("Drivers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Lat {
            get {
                return this.LatField;
            }
            set {
                if ((this.LatField.Equals(value) != true)) {
                    this.LatField = value;
                    this.RaisePropertyChanged("Lat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Lng {
            get {
                return this.LngField;
            }
            set {
                if ((this.LngField.Equals(value) != true)) {
                    this.LngField = value;
                    this.RaisePropertyChanged("Lng");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Place {
            get {
                return this.PlaceField;
            }
            set {
                if ((object.ReferenceEquals(this.PlaceField, value) != true)) {
                    this.PlaceField = value;
                    this.RaisePropertyChanged("Place");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Report", Namespace="http://schemas.datacontract.org/2004/07/DAL")]
    [System.SerializableAttribute()]
    public partial class Report : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WpfAppDispatcher.ServiceReference.Driver DriverField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double KMField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double MoneyField;
        
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
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WpfAppDispatcher.ServiceReference.Driver Driver {
            get {
                return this.DriverField;
            }
            set {
                if ((object.ReferenceEquals(this.DriverField, value) != true)) {
                    this.DriverField = value;
                    this.RaisePropertyChanged("Driver");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double KM {
            get {
                return this.KMField;
            }
            set {
                if ((this.KMField.Equals(value) != true)) {
                    this.KMField = value;
                    this.RaisePropertyChanged("KM");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Money {
            get {
                return this.MoneyField;
            }
            set {
                if ((this.MoneyField.Equals(value) != true)) {
                    this.MoneyField = value;
                    this.RaisePropertyChanged("Money");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClassesOfCar", Namespace="http://schemas.datacontract.org/2004/07/DAL")]
    public enum ClassesOfCar : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        For4Person = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        For8Person = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ForVantazh = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IServiceDispatcher")]
    public interface IServiceDispatcher {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/Authorization", ReplyAction="http://tempuri.org/IServiceDispatcher/AuthorizationResponse")]
        string Authorization(string Email, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/Authorization", ReplyAction="http://tempuri.org/IServiceDispatcher/AuthorizationResponse")]
        System.Threading.Tasks.Task<string> AuthorizationAsync(string Email, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/AboutDispatcher", ReplyAction="http://tempuri.org/IServiceDispatcher/AboutDispatcherResponse")]
        WpfAppDispatcher.ServiceReference.Dispatcher AboutDispatcher();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/AboutDispatcher", ReplyAction="http://tempuri.org/IServiceDispatcher/AboutDispatcherResponse")]
        System.Threading.Tasks.Task<WpfAppDispatcher.ServiceReference.Dispatcher> AboutDispatcherAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/Registration", ReplyAction="http://tempuri.org/IServiceDispatcher/RegistrationResponse")]
        string Registration(WpfAppDispatcher.ServiceReference.Dispatcher dispatcher);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/Registration", ReplyAction="http://tempuri.org/IServiceDispatcher/RegistrationResponse")]
        System.Threading.Tasks.Task<string> RegistrationAsync(WpfAppDispatcher.ServiceReference.Dispatcher dispatcher);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/CreateDriver", ReplyAction="http://tempuri.org/IServiceDispatcher/CreateDriverResponse")]
        string CreateDriver(WpfAppDispatcher.ServiceReference.Driver driver, int idCar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/CreateDriver", ReplyAction="http://tempuri.org/IServiceDispatcher/CreateDriverResponse")]
        System.Threading.Tasks.Task<string> CreateDriverAsync(WpfAppDispatcher.ServiceReference.Driver driver, int idCar);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/CreateCar", ReplyAction="http://tempuri.org/IServiceDispatcher/CreateCarResponse")]
        string CreateCar(WpfAppDispatcher.ServiceReference.Car car);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/CreateCar", ReplyAction="http://tempuri.org/IServiceDispatcher/CreateCarResponse")]
        System.Threading.Tasks.Task<string> CreateCarAsync(WpfAppDispatcher.ServiceReference.Car car);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/AllCars", ReplyAction="http://tempuri.org/IServiceDispatcher/AllCarsResponse")]
        WpfAppDispatcher.ServiceReference.Car[] AllCars();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/AllCars", ReplyAction="http://tempuri.org/IServiceDispatcher/AllCarsResponse")]
        System.Threading.Tasks.Task<WpfAppDispatcher.ServiceReference.Car[]> AllCarsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/AllDrivers", ReplyAction="http://tempuri.org/IServiceDispatcher/AllDriversResponse")]
        WpfAppDispatcher.ServiceReference.Driver[] AllDrivers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceDispatcher/AllDrivers", ReplyAction="http://tempuri.org/IServiceDispatcher/AllDriversResponse")]
        System.Threading.Tasks.Task<WpfAppDispatcher.ServiceReference.Driver[]> AllDriversAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceDispatcherChannel : WpfAppDispatcher.ServiceReference.IServiceDispatcher, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceDispatcherClient : System.ServiceModel.ClientBase<WpfAppDispatcher.ServiceReference.IServiceDispatcher>, WpfAppDispatcher.ServiceReference.IServiceDispatcher {
        
        public ServiceDispatcherClient() {
        }
        
        public ServiceDispatcherClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceDispatcherClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDispatcherClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceDispatcherClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Authorization(string Email, string Password) {
            return base.Channel.Authorization(Email, Password);
        }
        
        public System.Threading.Tasks.Task<string> AuthorizationAsync(string Email, string Password) {
            return base.Channel.AuthorizationAsync(Email, Password);
        }
        
        public WpfAppDispatcher.ServiceReference.Dispatcher AboutDispatcher() {
            return base.Channel.AboutDispatcher();
        }
        
        public System.Threading.Tasks.Task<WpfAppDispatcher.ServiceReference.Dispatcher> AboutDispatcherAsync() {
            return base.Channel.AboutDispatcherAsync();
        }
        
        public string Registration(WpfAppDispatcher.ServiceReference.Dispatcher dispatcher) {
            return base.Channel.Registration(dispatcher);
        }
        
        public System.Threading.Tasks.Task<string> RegistrationAsync(WpfAppDispatcher.ServiceReference.Dispatcher dispatcher) {
            return base.Channel.RegistrationAsync(dispatcher);
        }
        
        public string CreateDriver(WpfAppDispatcher.ServiceReference.Driver driver, int idCar) {
            return base.Channel.CreateDriver(driver, idCar);
        }
        
        public System.Threading.Tasks.Task<string> CreateDriverAsync(WpfAppDispatcher.ServiceReference.Driver driver, int idCar) {
            return base.Channel.CreateDriverAsync(driver, idCar);
        }
        
        public string CreateCar(WpfAppDispatcher.ServiceReference.Car car) {
            return base.Channel.CreateCar(car);
        }
        
        public System.Threading.Tasks.Task<string> CreateCarAsync(WpfAppDispatcher.ServiceReference.Car car) {
            return base.Channel.CreateCarAsync(car);
        }
        
        public WpfAppDispatcher.ServiceReference.Car[] AllCars() {
            return base.Channel.AllCars();
        }
        
        public System.Threading.Tasks.Task<WpfAppDispatcher.ServiceReference.Car[]> AllCarsAsync() {
            return base.Channel.AllCarsAsync();
        }
        
        public WpfAppDispatcher.ServiceReference.Driver[] AllDrivers() {
            return base.Channel.AllDrivers();
        }
        
        public System.Threading.Tasks.Task<WpfAppDispatcher.ServiceReference.Driver[]> AllDriversAsync() {
            return base.Channel.AllDriversAsync();
        }
    }
}
