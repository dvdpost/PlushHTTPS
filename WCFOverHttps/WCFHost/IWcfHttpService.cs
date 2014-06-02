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

        [OperationContract(Action = "setTVODCustomerSubscription", ReplyAction = "setTVODCustomerSubscription")]
        [WebGet(UriTemplate = "/setTVODCustomerSubscription?em={em}&pswd={pswd}&device={device}&dvcnmbr={dvcnmbr}&lngid={lngid}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int setTVODCustomerSubscription(string em, string pswd, int device, string dvcnmbr, int lngid);

        [OperationContract(Action = "AcceptAlias", ReplyAction = "AcceptAlias")]
        [WebGet(UriTemplate = "/AcceptAlias?ALIAS={ALIAS}&BRAND={BRAND}&CARDNO={CARDNO}&CN={CN}&CVC={CVC}&ED={ED}&NCERROR={NCERROR}&NCERRORCN={NCERRORCN}&NCERRORCARDNO={NCERRORCARDNO}&NCERRORCVC={NCERRORCVC}&NCERRORED={NCERRORED}&ORDERID={ORDERID}&SHASIGN={SHASIGN}&STATUS={STATUS}", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
        void AcceptAlias(string ALIAS, string BRAND, string CARDNO, string CN, string CVC, string ED, string NCERROR, string NCERRORCN, string NCERRORCARDNO, string NCERRORCVC, string NCERRORED, string ORDERID, string SHASIGN, string STATUS);

        [OperationContract(Action = "ExceptionAlias", ReplyAction = "ExceptionAlias")]
        [WebInvoke(UriTemplate = "/ExceptionAlias?ALIAS={ALIAS}&BRAND={BRAND}&CARDNO={CARDNO}&CN={CN}&CVC={CVC}&ED={ED}&NCERROR={NCERROR}&NCERRORCN={NCERRORCN}&NCERRORCARDNO={NCERRORCARDNO}&NCERRORCVC={NCERRORCVC}&NCERRORED={NCERRORED}&ORDERID={ORDERID}&SHASIGN={SHASIGN}&STATUS={STATUS}", Method="GET",  ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml)]
        void ExceptionAlias(string ALIAS, string BRAND, string CARDNO, string CN, string CVC, string ED, string NCERROR, string NCERRORCN, string NCERRORCARDNO, string NCERRORCVC, string NCERRORED, string ORDERID, string SHASIGN, string STATUS);

        [OperationContract(Action = "TVODPayAndGetVodTokenAndLngs", ReplyAction = "TVODPayAndGetVodTokenAndLngs")]
        [WebGet(UriTemplate = "/TVODPayAndGetVodTokenAndLngs?imdb_id={imdb_id}&disk_id={disk_id}&season_id={season_id}&cn={cn}&device={device}&amount={amount}&card_type={card_type}&card_no={card_no}&card_ed={card_ed}&card_owner={card_owner}&card_cvc={card_cvc}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        VodTokenLengs TVODPayAndGetVodTokenAndLngs(int imdb_id, int disk_id, int season_id, string amount, string card_type, string card_no, string card_ed, string card_owner, string card_cvc, int cn, int device);
        
    }
}
