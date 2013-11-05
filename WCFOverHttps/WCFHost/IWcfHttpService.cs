using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlushContract;
using System.ServiceModel.Activation;

namespace PlushHTTPS.WCFHost
{
    [ServiceContract(Namespace = "PlushHTTPS.WCFHost")]
    public interface IWcfHttpService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetFile/{path}")]
        Stream GetFile(string path);

        [OperationContract(Action = "getVodTokenAndLngs", ReplyAction = "getVodTokenAndLngs")]
        [WebGet(UriTemplate = "/getVodTokenAndLngs?imdb_id={imdb_id}&disk_id={disk_id}&season_id={season_id}&cn={cn}&device={device}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        VodTokenLengs getVodTokenAndLngs(int imdb_id, int disk_id, int season_id, int cn, int device);

        [OperationContract(Action = "getCustomerDetails", ReplyAction = "getCustomerDetails")]
        [WebGet(UriTemplate = "/getCustomerDetails?un={un}&pswd={pswd}&device={device}&dvcnmbr={dvcnmbr}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        CustomerDetails getCustomerDetails(string un, string pswd, int device, string dvcnmbr);
    }
}
