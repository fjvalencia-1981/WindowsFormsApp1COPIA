﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace WindowsFormsApp1.ZWSMM_OBTENER_CLIENTES {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    // CODEGEN: No se controló el elemento de extensión WSDL opcional 'Policy' del espacio de nombres 'http://schemas.xmlsoap.org/ws/2004/09/policy'.
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="binding", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ZmmfObtenerClientesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public service() {
            this.Url = global::WindowsFormsApp1.Properties.Settings.Default.WindowsFormsApp1_ZWSMM_OBTENER_CLIENTES_service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ZmmfObtenerClientesCompletedEventHandler ZmmfObtenerClientesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ZmmfObtenerClientesResponse", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
        public ZmmfObtenerClientesResponse ZmmfObtenerClientes([System.Xml.Serialization.XmlElementAttribute("ZmmfObtenerClientes", Namespace="urn:sap-com:document:sap:soap:functions:mc-style")] ZmmfObtenerClientes ZmmfObtenerClientes1) {
            object[] results = this.Invoke("ZmmfObtenerClientes", new object[] {
                        ZmmfObtenerClientes1});
            return ((ZmmfObtenerClientesResponse)(results[0]));
        }
        
        /// <remarks/>
        public void ZmmfObtenerClientesAsync(ZmmfObtenerClientes ZmmfObtenerClientes1) {
            this.ZmmfObtenerClientesAsync(ZmmfObtenerClientes1, null);
        }
        
        /// <remarks/>
        public void ZmmfObtenerClientesAsync(ZmmfObtenerClientes ZmmfObtenerClientes1, object userState) {
            if ((this.ZmmfObtenerClientesOperationCompleted == null)) {
                this.ZmmfObtenerClientesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnZmmfObtenerClientesOperationCompleted);
            }
            this.InvokeAsync("ZmmfObtenerClientes", new object[] {
                        ZmmfObtenerClientes1}, this.ZmmfObtenerClientesOperationCompleted, userState);
        }
        
        private void OnZmmfObtenerClientesOperationCompleted(object arg) {
            if ((this.ZmmfObtenerClientesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ZmmfObtenerClientesCompleted(this, new ZmmfObtenerClientesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZmmfObtenerClientes {
        
        private string pFechaultimadescargaField;
        
        private int pLimitField;
        
        private bool pLimitFieldSpecified;
        
        private int pRowsetField;
        
        private bool pRowsetFieldSpecified;
        
        private int pTipodescargaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PFechaultimadescarga {
            get {
                return this.pFechaultimadescargaField;
            }
            set {
                this.pFechaultimadescargaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int PLimit {
            get {
                return this.pLimitField;
            }
            set {
                this.pLimitField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PLimitSpecified {
            get {
                return this.pLimitFieldSpecified;
            }
            set {
                this.pLimitFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int PRowset {
            get {
                return this.pRowsetField;
            }
            set {
                this.pRowsetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PRowsetSpecified {
            get {
                return this.pRowsetFieldSpecified;
            }
            set {
                this.pRowsetFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int PTipodescarga {
            get {
                return this.pTipodescargaField;
            }
            set {
                this.pTipodescargaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZmmsGetItemsCustomers {
        
        private int idField;
        
        private string origenField;
        
        private int empidField;
        
        private string rutclienteField;
        
        private string nombresField;
        
        private string apellidosField;
        
        private string nombrefantasiaField;
        
        private string razonsocialField;
        
        private int giroField;
        
        private string tipoclienteField;
        
        private int sucursalField;
        
        private string nombresucursalField;
        
        private string direccionField;
        
        private string telefonoField;
        
        private string emailField;
        
        private string comunaField;
        
        private string ciuidField;
        
        private int regionField;
        
        private string contactoField;
        
        private string telefonocontactoField;
        
        private string tiporeferenciaField;
        
        private string numeroreferenciaField;
        
        private string codigoextField;
        
        private string codigolistaField;
        
        private string lineacreditoField;
        
        private string formapagoField;
        
        private int bancoField;
        
        private string nrocuentaField;
        
        private string vendedorField;
        
        private string georeferenciaField;
        
        private string indbloqueoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Origen {
            get {
                return this.origenField;
            }
            set {
                this.origenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Empid {
            get {
                return this.empidField;
            }
            set {
                this.empidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Rutcliente {
            get {
                return this.rutclienteField;
            }
            set {
                this.rutclienteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Nombres {
            get {
                return this.nombresField;
            }
            set {
                this.nombresField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Apellidos {
            get {
                return this.apellidosField;
            }
            set {
                this.apellidosField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Nombrefantasia {
            get {
                return this.nombrefantasiaField;
            }
            set {
                this.nombrefantasiaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Razonsocial {
            get {
                return this.razonsocialField;
            }
            set {
                this.razonsocialField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Giro {
            get {
                return this.giroField;
            }
            set {
                this.giroField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Tipocliente {
            get {
                return this.tipoclienteField;
            }
            set {
                this.tipoclienteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Sucursal {
            get {
                return this.sucursalField;
            }
            set {
                this.sucursalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Nombresucursal {
            get {
                return this.nombresucursalField;
            }
            set {
                this.nombresucursalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Direccion {
            get {
                return this.direccionField;
            }
            set {
                this.direccionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Telefono {
            get {
                return this.telefonoField;
            }
            set {
                this.telefonoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Comuna {
            get {
                return this.comunaField;
            }
            set {
                this.comunaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Ciuid {
            get {
                return this.ciuidField;
            }
            set {
                this.ciuidField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Region {
            get {
                return this.regionField;
            }
            set {
                this.regionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Contacto {
            get {
                return this.contactoField;
            }
            set {
                this.contactoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Telefonocontacto {
            get {
                return this.telefonocontactoField;
            }
            set {
                this.telefonocontactoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Tiporeferencia {
            get {
                return this.tiporeferenciaField;
            }
            set {
                this.tiporeferenciaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Numeroreferencia {
            get {
                return this.numeroreferenciaField;
            }
            set {
                this.numeroreferenciaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Codigoext {
            get {
                return this.codigoextField;
            }
            set {
                this.codigoextField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Codigolista {
            get {
                return this.codigolistaField;
            }
            set {
                this.codigolistaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Lineacredito {
            get {
                return this.lineacreditoField;
            }
            set {
                this.lineacreditoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Formapago {
            get {
                return this.formapagoField;
            }
            set {
                this.formapagoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Banco {
            get {
                return this.bancoField;
            }
            set {
                this.bancoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Nrocuenta {
            get {
                return this.nrocuentaField;
            }
            set {
                this.nrocuentaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Vendedor {
            get {
                return this.vendedorField;
            }
            set {
                this.vendedorField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Georeferencia {
            get {
                return this.georeferenciaField;
            }
            set {
                this.georeferenciaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Indbloqueo {
            get {
                return this.indbloqueoField;
            }
            set {
                this.indbloqueoField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZmmsGetCustomers {
        
        private int countField;
        
        private string resultadoField;
        
        private string resultadoDesField;
        
        private int resultadoCodigoField;
        
        private int limitField;
        
        private int rowsetField;
        
        private ZmmsGetItemsCustomers[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Count {
            get {
                return this.countField;
            }
            set {
                this.countField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Resultado {
            get {
                return this.resultadoField;
            }
            set {
                this.resultadoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ResultadoDes {
            get {
                return this.resultadoDesField;
            }
            set {
                this.resultadoDesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int ResultadoCodigo {
            get {
                return this.resultadoCodigoField;
            }
            set {
                this.resultadoCodigoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Limit {
            get {
                return this.limitField;
            }
            set {
                this.limitField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Rowset {
            get {
                return this.rowsetField;
            }
            set {
                this.rowsetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZmmsGetItemsCustomers[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:soap:functions:mc-style")]
    public partial class ZmmfObtenerClientesResponse {
        
        private ZmmsGetCustomers weCustomersField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public ZmmsGetCustomers WeCustomers {
            get {
                return this.weCustomersField;
            }
            set {
                this.weCustomersField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void ZmmfObtenerClientesCompletedEventHandler(object sender, ZmmfObtenerClientesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ZmmfObtenerClientesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ZmmfObtenerClientesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ZmmfObtenerClientesResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ZmmfObtenerClientesResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591