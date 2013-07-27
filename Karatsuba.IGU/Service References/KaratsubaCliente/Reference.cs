﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18052
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Karatsuba.IGU.KaratsubaCliente {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KaratsubaCliente.IServicioMultiplicacionKaratsuba")]
    public interface IServicioMultiplicacionKaratsuba {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioMultiplicacionKaratsuba/Multiplicar", ReplyAction="http://tempuri.org/IServicioMultiplicacionKaratsuba/MultiplicarResponse")]
        string Multiplicar(string primerValor, string segundoValor);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServicioMultiplicacionKaratsuba/Multiplicar", ReplyAction="http://tempuri.org/IServicioMultiplicacionKaratsuba/MultiplicarResponse")]
        System.IAsyncResult BeginMultiplicar(string primerValor, string segundoValor, System.AsyncCallback callback, object asyncState);
        
        string EndMultiplicar(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioMultiplicacionKaratsubaChannel : Karatsuba.IGU.KaratsubaCliente.IServicioMultiplicacionKaratsuba, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MultiplicarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public MultiplicarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public partial class ServicioMultiplicacionKaratsubaClient : System.ServiceModel.ClientBase<Karatsuba.IGU.KaratsubaCliente.IServicioMultiplicacionKaratsuba>, Karatsuba.IGU.KaratsubaCliente.IServicioMultiplicacionKaratsuba {
        
        private BeginOperationDelegate onBeginMultiplicarDelegate;
        
        private EndOperationDelegate onEndMultiplicarDelegate;
        
        private System.Threading.SendOrPostCallback onMultiplicarCompletedDelegate;
        
        public ServicioMultiplicacionKaratsubaClient() {
        }
        
        public ServicioMultiplicacionKaratsubaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioMultiplicacionKaratsubaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioMultiplicacionKaratsubaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioMultiplicacionKaratsubaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<MultiplicarCompletedEventArgs> MultiplicarCompleted;
        
        public string Multiplicar(string primerValor, string segundoValor) {
            return base.Channel.Multiplicar(primerValor, segundoValor);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginMultiplicar(string primerValor, string segundoValor, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginMultiplicar(primerValor, segundoValor, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string EndMultiplicar(System.IAsyncResult result) {
            return base.Channel.EndMultiplicar(result);
        }
        
        private System.IAsyncResult OnBeginMultiplicar(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string primerValor = ((string)(inValues[0]));
            string segundoValor = ((string)(inValues[1]));
            return this.BeginMultiplicar(primerValor, segundoValor, callback, asyncState);
        }
        
        private object[] OnEndMultiplicar(System.IAsyncResult result) {
            string retVal = this.EndMultiplicar(result);
            return new object[] {
                    retVal};
        }
        
        private void OnMultiplicarCompleted(object state) {
            if ((this.MultiplicarCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.MultiplicarCompleted(this, new MultiplicarCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void MultiplicarAsync(string primerValor, string segundoValor) {
            this.MultiplicarAsync(primerValor, segundoValor, null);
        }
        
        public void MultiplicarAsync(string primerValor, string segundoValor, object userState) {
            if ((this.onBeginMultiplicarDelegate == null)) {
                this.onBeginMultiplicarDelegate = new BeginOperationDelegate(this.OnBeginMultiplicar);
            }
            if ((this.onEndMultiplicarDelegate == null)) {
                this.onEndMultiplicarDelegate = new EndOperationDelegate(this.OnEndMultiplicar);
            }
            if ((this.onMultiplicarCompletedDelegate == null)) {
                this.onMultiplicarCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnMultiplicarCompleted);
            }
            base.InvokeAsync(this.onBeginMultiplicarDelegate, new object[] {
                        primerValor,
                        segundoValor}, this.onEndMultiplicarDelegate, this.onMultiplicarCompletedDelegate, userState);
        }
    }
}