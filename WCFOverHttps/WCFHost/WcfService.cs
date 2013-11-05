using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
using System.Xml;
using System.Net;
using System.Xml.Schema;
using System.Xml.Linq;
using MySql;
using MySql.Data.MySqlClient;
using MySql.Data;
using DbLinq.Factory;
using PlushContract;
using DVDPostBuziness;
using System.Collections;
using CountryLookupProj;
using System.ServiceModel.Web;
using MobileDevicesService;
using PlushService;
using System.ServiceModel.Activation;
using System.Runtime.CompilerServices;
using PlushContract;

namespace PlushHTTPS.WCFHost
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WcfService : IWcfHttpService, IWcfSoapService
    {
        private System.Diagnostics.EventLog _hosteventLog;

        public string HelloWorld()
        {
            return "Hello World";
        }

        public Stream GetFile(string path)
        {
            path = string.Format("c:\\{0}", path);
            try
            {
                if (!File.Exists(path))
                    throw new Exception("File not found");

                if (WebOperationContext.Current != null)
                    WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";

                return File.OpenRead(path);
            }
            catch (Exception ex)
            {
                if (WebOperationContext.Current != null)
                    WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound(ex.Message);

                return null;
            }
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        private string getVodUrl(int vodid, int cn)
        {
            lock (typeof(WcfService))
            {
                string ipaddress = string.Empty;
                string ipcountry;
                int imdb_id = 0;
                string fileName = string.Empty;
                string token = string.Empty;
                string connstr_mobile_api_ws = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
                string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
                string vodUrl;
                bool geoCheck = false;
                bool isParsed = bool.TryParse(ConfigurationManager.AppSettings["GeoCheck"], out geoCheck);
                vodUrl = ConfigurationManager.AppSettings["VodUrl"];

                string notGeoCustomer = ConfigurationManager.AppSettings["NotGeoCustomer"];
                ArrayList notGeoCustomerList = new ArrayList();
                notGeoCustomerList.AddRange(notGeoCustomer.Split(new char[] { ',' }));
                //
                string geoCountries = ConfigurationManager.AppSettings["GeoCountries"];
                ArrayList geoCountriesList = new ArrayList();
                geoCountriesList.AddRange(geoCountries.Split(new char[] { ',' }));

                VodStreamingInfo vsi = null;
                DVdPostMobileApIWS contextMobileApiWs = null;
                DVdPostMobileApIWS contextBeProd = null;
                IEnumerable<VodStreamingInfo> fn;
                //                        
                CustomerDetailsRow cd = new CustomerDetailsRow();

                //geo check
                string filePath = ConfigurationManager.AppSettings["countryFilePath"];
                CountryLookup cl = new CountryLookup(filePath);
                ipcountry = Utilities.GetClientCoutry();// cl.lookupCountryCode(ipaddress);
                if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()))
                {
                    OperationContext context = OperationContext.Current;
                    MessageProperties prop = context.IncomingMessageProperties;
                    RemoteEndpointMessageProperty endpoint =
                    prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                    ipaddress = endpoint.Address;
                    if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()) && !geoCountries.Contains(ipcountry))
                    {
                        this._hosteventLog = new System.Diagnostics.EventLog();
                        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                        _hosteventLog.Source = "PlushHTTPSServiceSource";
                        _hosteventLog.Log = "PlushHTTPSServiceLog";
                        _hosteventLog.WriteEntry("getVodUrl.Exception: 4 vodid, cn, cntry: " + vodid + ", " + cn + ", error: " + ipcountry, System.Diagnostics.EventLogEntryType.Error);

                        return "4";
                    }
                }
                //
                try
                {
                    contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
                    string sql = QueriesDB.getVodStreamingInfo(vodid);

                    fn = contextBeProd.ExecuteQuery<VodStreamingInfo>(sql, null);
                    

                    if (fn.Count() == 0)
                    {
                        return "5";
                    }
                    vsi = fn.ToList<VodStreamingInfo>()[0];
                    imdb_id = vsi.imdb_id;
                    fileName = vsi.filename;
                    //chect if token already exists
                    string sqlGetToken = QueriesDB.getToken(imdb_id, cn);
                    var listToken = contextBeProd.ExecuteQuery<Utilities.Token>(sqlGetToken);
                    if (listToken.Count<Utilities.Token>() > 0)
                    {
                        return listToken.ToList()[0].token;
                    }

                }
                catch (Exception ex)
                {
                    this._hosteventLog = new System.Diagnostics.EventLog();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                    _hosteventLog.Source = "PlushHTTPSServiceSource";
                    _hosteventLog.Log = "PlushHTTPSServiceLog";
                    _hosteventLog.WriteEntry("getVodUrl.Exception: 0.1 vodid, cn: " + vodid + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    if (ex.InnerException != null)
                    {
                        _hosteventLog.WriteEntry("getVodUrl InnerException: 0.1 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    return "0.1";
                }
                try
                {
                    contextMobileApiWs = new DVdPostMobileApIWS(new MySqlConnection(connstr_mobile_api_ws));
                    contextMobileApiWs.ObjectTrackingEnabled = false;
                    contextMobileApiWs.QueryCacheEnabled = true;
                    //contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));

                    string sqlISSVOD = QueriesDB.getIsSOVD(imdb_id);
                    IEnumerable<numberresult> svodcount = contextBeProd.ExecuteQuery<numberresult>(sqlISSVOD,null);                    
                    bool isSVOD = svodcount.First().r > 0;

                    IEnumerable<CustomerDetailsRow> cdr = contextMobileApiWs.ExecuteQuery<CustomerDetailsRow>("CALL sp_customer_getbyid({0})", cn);

                    if (cdr.Count() > 0)
                    {
                        cd = cdr.ToList()[0];
                    }
                    else
                    {
                        return "1"; //no customer
                    }
                    if (!isSVOD &&  cd.ogreg == 0)
                    {
                        return "2"; //not ogone registerd
                    }
                    if ((cd.isac == 0) )
                    {
                        return "3"; //not active
                    }
                    if (cd.susp > 0)
                    {
                        return "6"; //suspended
                    }

                }
                catch (Exception ex)
                {
                    this._hosteventLog = new System.Diagnostics.EventLog();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                    _hosteventLog.Source = "PlushHTTPSServiceSource";
                    _hosteventLog.Log = "PlushHTTPSServiceLog";
                    _hosteventLog.WriteEntry("getVodUrl.Exception: 3 vodid, cn: " + vodid + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    if (ex.InnerException != null)
                    {
                        _hosteventLog.WriteEntry("getVodUrl InnerException: 3 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    return "0.2";
                }

                //string sql = MobileDevicesService.QueriesDB.getVodStreamingInfo(vodid);

                try
                {
                    //fn = contextBeProd.ExecuteQuery<VodStreamingInfo>(sql, null);

                    //if (fn.Count() == 0)
                    //{
                    //    return "4";
                    //}
                    //vsi = fn.ToList<VodStreamingInfo>()[0];
                    //imdb_id = vsi.imdb_id;
                    //fileName = vsi.filename;
                    ////chect if token already exists
                    //string sqlGetToken = QueriesDB.getToken(imdb_id, cn);
                    //var listToken = contextBeProd.ExecuteQuery<Utilities.Token>( sqlGetToken);
                    //if (listToken.Count<Utilities.Token>() > 0)
                    //{
                    //    return listToken.ToList()[0].token ;
                    //}
                    ////
                    string request = string.Empty;
                    if (ConfigurationManager.AppSettings["NewTokenUrl"].Equals("New"))
                        request = vodUrl + fileName + "&lifetime=172800&simultIp=2&test=false";
                    else
                        request = vodUrl + fileName + "&lifetime=172800&simultIp=2";
                    string responseContent;
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(request);
                    webRequest.Credentials = new NetworkCredential("dvdpost", "sup3rnov4$$");
                    HttpWebResponse webResponse = null;

                    webResponse = (HttpWebResponse)webRequest.GetResponse();
                    Stream responseStream = webResponse.GetResponseStream();
                    StreamReader responseStreamReader = new StreamReader(responseStream);
                    responseContent = responseStreamReader.ReadToEnd();
                    responseStreamReader.Close();
                    XmlDocument xd = new XmlDocument();
                    XDocument xs = XDocument.Parse(responseContent);

                    xd.LoadXml(responseContent);
                    if (ConfigurationManager.AppSettings["NewTokenUrl"].Equals("New"))
                        token = (xd.SelectSingleNode("Webservice_Model_FacadeToken/createToken/response")).InnerText;
                    else
                        token = (xd.SelectSingleNode("OttVod_Token_Facade/create/response")).InnerText;

                }
                catch (Exception ex)
                {
                    this._hosteventLog = new System.Diagnostics.EventLog();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                    _hosteventLog.Source = "PlushHTTPSServiceSource";
                    _hosteventLog.Log = "PlushHTTPSServiceLog";
                    _hosteventLog.WriteEntry("getVodUrl.Exception: 2 vodid, cn: " + vodid + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    if (ex.InnerException != null)
                    {
                        _hosteventLog.WriteEntry("getVodUrl InnerException: 2 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    return "0.3";
                }
                IDbTransaction trans = null;
                try
                {
                    if (contextBeProd.Connection.State != ConnectionState.Open)
                    {
                        contextBeProd.Connection.Open();
                    }
                    trans = contextBeProd.Connection.BeginTransaction();

                    this._hosteventLog = new System.Diagnostics.EventLog();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                    _hosteventLog.Source = "PlushHTTPSServiceSource";
                    _hosteventLog.Log = "PlushHTTPSServiceLog";

                    //string sqlInsertToken = QueriesDB.getInsertToken(cn, token, imdb_id);

                    //string sqlDecreaseCredit = QueriesDB.getDecreaseCredit(cn, vsi.credits);

                    //string sqlInsertCreditHistory = Utilities.GetInsertCreditHistory(cd.remc.Value, cn, cd.sbst, vsi.credits);

                    //
                    //contextBeProd.ExecuteCommand(sqlInsertToken);
                    contextBeProd.ExecuteCommand("call sp_smarttv_token_insert({0},{1},{2},{3},{4})", cn, token, imdb_id, ipaddress, ipcountry);

                    //contextBeProd.ExecuteCommand(sqlDecreaseCredit);

                    //contextBeProd.ExecuteCommand(sqlInsertCreditHistory);

                    // send email
                    //DataTable dt = new DataTable("customermail");
                    //dt.Columns.Add("customers_firstname", typeof(string));
                    //dt.Columns.Add("customers_lastname", typeof(string));
                    //dt.Columns.Add("customers_name", typeof(string));
                    //dt.Columns.Add("customers_gender", typeof(string));
                    //dt.Columns.Add("email", typeof(string));
                    //dt.Columns.Add("customers_language", typeof(int));
                    //dt.Columns.Add("Customers_id", typeof(int));
                    //dt.Columns.Add("products_id", typeof(int));
                    //dt.Columns.Add("customers_abo_payment_method", typeof(int));
                    //dt.Columns.Add("customers_abo", typeof(int));
                    //dt.Columns.Add("customers_abo_dvd_home_norm", typeof(int));
                    //dt.Columns.Add("customers_abo_dvd_home_adult", typeof(int));
                    //dt.Columns.Add("date_sent", typeof(DateTime));


                    //DataRow dr = dt.NewRow();
                    //dr["customers_firstname"] = cd.frst;
                    //dr["customers_lastname"] = cd.lstn;
                    //dr["customers_name"] = cd.frst + " " + cd.lstn;
                    //dr["customers_gender"] = cd.gndr;
                    //dr["email"] = cd.em;
                    //dr["customers_language"] = cd.lng;
                    //dr["Customers_id"] = cd.cn;
                    //dr["products_id"] = contextBeProd.ExecuteCommand(QueriesDB.GetProductFromVod(vodid));// 120619;                
                    //dr["customers_abo_payment_method"] = cd.sbst;
                    //dr["customers_abo"] = cd.isac;
                    ////dr["customers_abo_dvd_home_norm"] = cd.nath;
                    ////dr["customers_abo_dvd_home_adult"] = cd.aath;
                    //dr["date_sent"] = DateTime.Now;
                    //PlushData.clsConnection.typeEnv = "prod";
                    //PlushBuziness.clsMail.SendMail(dr, PlushBuziness.clsMail.Mail.MAIL_VOD_CONFIRMATION, true, string.Empty, string.Empty, string.Empty);

                    trans.Commit();
                    return token;

                    //
                }
                catch (Exception ex)
                {
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                    this._hosteventLog = new System.Diagnostics.EventLog();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                    _hosteventLog.Source = "PlushHTTPSServiceSource";
                    _hosteventLog.Log = "PlushHTTPSServiceLog";
                    _hosteventLog.WriteEntry("getVodUrl.Exception: 3 vodid, cn: " + vodid + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    if (ex.InnerException != null)
                    {
                        _hosteventLog.WriteEntry("getVodUrl InnerException: 3 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    return "0.4";
                }
                //return token;
            }
        }

        public VodTokenLengs getVodTokenAndLngs(int imdb_id, int disk_id, int season_id, int cn, int device)
        {
            string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;
            string ipaddress = string.Empty;
            string ipcountry;
            string vodUrl;
            bool geoCheck = false;
            bool isParsed = bool.TryParse(ConfigurationManager.AppSettings["GeoCheck"], out geoCheck);

            vodUrl = ConfigurationManager.AppSettings["VodUrl"];

            string notGeoCustomer = ConfigurationManager.AppSettings["NotGeoCustomer"];
            ArrayList notGeoCustomerList = new ArrayList();
            notGeoCustomerList.AddRange(notGeoCustomer.Split(new char[] { ',' }));
            //
            string geoCountries = ConfigurationManager.AppSettings["GeoCountries"];
            ArrayList geoCountriesList = new ArrayList();
            geoCountriesList.AddRange(geoCountries.Split(new char[] { ',' }));
            try
            {
                modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
                modelcontext.ObjectTrackingEnabled = false;
                modelcontext.QueryCacheEnabled = true;

                Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 1 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device, modelcontext);
                string filePath = ConfigurationManager.AppSettings["countryFilePath"];
                CountryLookup cl = new CountryLookup(filePath);
                ipcountry = Utilities.GetClientCoutry();// cl.lookupCountryCode(ipaddress);
                if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()))
                {
                    OperationContext context = OperationContext.Current;
                    MessageProperties prop = context.IncomingMessageProperties;
                    RemoteEndpointMessageProperty endpoint =
                    prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                    ipaddress = endpoint.Address;
                    if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()) && !geoCountries.Contains(ipcountry))
                    {
                        this._hosteventLog = new System.Diagnostics.EventLog();
                        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                        _hosteventLog.Source = "PlushHTTPSServiceSource";
                        _hosteventLog.Log = "PlushHTTPSServiceLog";
                        _hosteventLog.WriteEntry("getVodUrl.Exception: 4 imdb_id, cn, cntry: " + imdb_id + ", " + cn + ", error: " + ipcountry, System.Diagnostics.EventLogEntryType.Error);

                        VodTokenLengs vtl1 = new VodTokenLengs();

                        vtl1.a = "";
                        vtl1.t = "4";

                        return vtl1;
                    }
                }

                IEnumerable<VODChannel> vodch = modelcontext.ExecuteQuery<VODChannel>("CALL spmovie_vod_products({0},{1},{2},{3})", imdb_id, disk_id, season_id, Utilities.GetClientCoutry());

                Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 2 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device, modelcontext);


                string[] vodidTmp = vodch.ToArray()[0].a.Split(',');

                int vodid = int.Parse(vodidTmp[0].Split(':').ToArray()[0]);

                Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 3 vodid ", vodid.ToString(), device, modelcontext);
                string token = getVodUrl(vodid, cn);
                Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 4 token ", token, device, modelcontext);
                //
                //string AESkey = ConfigurationManager.AppSettings["AESkey"];
                //string encryptedToken = AESCrypto.EncryptedString.EncryptString(token, AESkey);
                //
                //Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 5 encryptedToken ", encryptedToken, device, modelcontext);
                VodTokenLengs vtl = new VodTokenLengs();
                vtl.t = token;
                vtl.a = vodch.ToList()[0].a;
                Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 6  vtl.a, vtl.t ", vtl.a + ", " + vtl.t, device, modelcontext);
                return vtl;
            }
            catch (Exception ex)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("getVodTokenAndLngs. 1 imdb_id_serie, disk_id, season_id, cn :   " + imdb_id + ", " + disk_id + ", " + season_id + ", " + cn, System.Diagnostics.EventLogEntryType.Error);
                _hosteventLog.WriteEntry("getVodTokenAndLngs.Exception: 1 " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("getVodTokenAndLngs InnerException: 1" + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                return null;
            }
        }

        public CustomerDetails getCustomerDetails(string un, string pswd, int device, string dvcnmbr)
        {
            string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;
            CustomerDetails cd = new CustomerDetails();
            bool checkPassword = bool.TryParse(ConfigurationManager.AppSettings["checkPassword"], out checkPassword);

            try
            {

                modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
                modelcontext.ObjectTrackingEnabled = false;
                modelcontext.QueryCacheEnabled = true;

                IEnumerable<CustomerDetailsRow> cdr = modelcontext.ExecuteQuery<CustomerDetailsRow>("CALL sp_customer_get({0},{1})", un, string.Empty);

                if (cdr.Count() > 0)
                {
                    cd.cdr = cdr.FirstOrDefault<CustomerDetailsRow>();
                    Utilities.InsertMobileApplicationLog(int.Parse(cd.cdr.cn), "getCustomerDetails", dvcnmbr, string.Empty, device); 
                    if (checkPassword)
                    {
                        Utilities.InsertMobileLog(int.Parse( cd.cdr.cn), "getCustomerDetails", pswd + ":" + cd.cdr.pswd, device, modelcontext);
                        if (Utilities.wrongPass(pswd, cd.cdr.pswd))
                        {
                            cd.cdr = null; // password not send to client
                            cd.err = 2;
                            return cd;
                        }
                    }
                   
                    cd.cdr.pswd = null;
                    cd.err = null;
                    return cd;
                }
                else
                {
                    cd.cdr = null;
                    cd.err = 1;
                    return cd;
                }
            }
            catch (Exception ex)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("getCustomerDetails.Exception: 5 un, pswd: " + un + ", " + pswd + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("getCustomerDetails InnerException: 5 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                cd.cdr = null;
                cd.err = 3;
                return cd;
            }
        }        
    }
}
