﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextExcel.KleberServicePostCode {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KleberServicePostCode.IDtKleberService")]
    public interface IDtKleberService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDtKleberService/ProcessXmlRequest", ReplyAction="http://tempuri.org/IDtKleberService/ProcessXmlRequestResponse")]
        string ProcessXmlRequest(string DtXmlRequest);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDtKleberService/ProcessXmlRequest", ReplyAction="http://tempuri.org/IDtKleberService/ProcessXmlRequestResponse")]
        System.Threading.Tasks.Task<string> ProcessXmlRequestAsync(string DtXmlRequest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDtKleberServiceChannel : TextExcel.KleberServicePostCode.IDtKleberService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DtKleberServiceClient : System.ServiceModel.ClientBase<TextExcel.KleberServicePostCode.IDtKleberService>, TextExcel.KleberServicePostCode.IDtKleberService {
        
        public DtKleberServiceClient() {
        }
        
        public DtKleberServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DtKleberServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DtKleberServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DtKleberServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ProcessXmlRequest(string DtXmlRequest) {
            return base.Channel.ProcessXmlRequest(DtXmlRequest);
        }
        
        public System.Threading.Tasks.Task<string> ProcessXmlRequestAsync(string DtXmlRequest) {
            return base.Channel.ProcessXmlRequestAsync(DtXmlRequest);
        }
    }
}
