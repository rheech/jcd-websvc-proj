﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace libwebsvcprod.CurrencyConverterSvc {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CurrencyConverterSvc.ConverterSoap")]
    public interface ConverterSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCurrencies", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] GetCurrencies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCurrencyRate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        decimal GetCurrencyRate(string Currency, System.DateTime RateDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCurrencyRates", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetCurrencyRates(System.DateTime RateDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetConversionRate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        decimal GetConversionRate(string CurrencyFrom, string CurrencyTo, System.DateTime RateDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetConversionAmount", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        decimal GetConversionAmount(string CurrencyFrom, string CurrencyTo, System.DateTime RateDate, decimal Amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCultureInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetCultureInfo(string Currency);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ConvertDataTableColumn", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void ConvertDataTableColumn(ref System.Data.DataSet ds, int TableIndex, string ColumnName, string FromCurrency, string ToCurrency);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetLastUpdateDate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.DateTime GetLastUpdateDate();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ConverterSoapChannel : libwebsvcprod.CurrencyConverterSvc.ConverterSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConverterSoapClient : System.ServiceModel.ClientBase<libwebsvcprod.CurrencyConverterSvc.ConverterSoap>, libwebsvcprod.CurrencyConverterSvc.ConverterSoap {
        
        public ConverterSoapClient() {
        }
        
        public ConverterSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConverterSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConverterSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConverterSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetCurrencies() {
            return base.Channel.GetCurrencies();
        }
        
        public decimal GetCurrencyRate(string Currency, System.DateTime RateDate) {
            return base.Channel.GetCurrencyRate(Currency, RateDate);
        }
        
        public System.Data.DataSet GetCurrencyRates(System.DateTime RateDate) {
            return base.Channel.GetCurrencyRates(RateDate);
        }
        
        public decimal GetConversionRate(string CurrencyFrom, string CurrencyTo, System.DateTime RateDate) {
            return base.Channel.GetConversionRate(CurrencyFrom, CurrencyTo, RateDate);
        }
        
        public decimal GetConversionAmount(string CurrencyFrom, string CurrencyTo, System.DateTime RateDate, decimal Amount) {
            return base.Channel.GetConversionAmount(CurrencyFrom, CurrencyTo, RateDate, Amount);
        }
        
        public string GetCultureInfo(string Currency) {
            return base.Channel.GetCultureInfo(Currency);
        }
        
        public void ConvertDataTableColumn(ref System.Data.DataSet ds, int TableIndex, string ColumnName, string FromCurrency, string ToCurrency) {
            base.Channel.ConvertDataTableColumn(ref ds, TableIndex, ColumnName, FromCurrency, ToCurrency);
        }
        
        public System.DateTime GetLastUpdateDate() {
            return base.Channel.GetLastUpdateDate();
        }
    }
}
