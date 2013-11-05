using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PlushHTTPS.WCFHost
{
    [ServiceContract(Namespace = "PlushHTTPS.WCFHost")]
    public interface IWcfSoapService
    {
        [OperationContract]
        [WebGet(UriTemplate = "HelloWorld")]
        string HelloWorld();
    }
}
