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
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

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
        private string getVodUrl(int vodid, int cn, int device)
        {
            lock (typeof(WcfService))
            {
                bool isSVOD = true;
                bool isFreeMovie = true;
                string ipaddress = string.Empty;
                //string ipcountry;
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
                //string filePath = ConfigurationManager.AppSettings["countryFilePath"];
                //CountryLookup cl = new CountryLookup(filePath);
                //ipcountry = Utilities.GetClientCoutry();// cl.lookupCountryCode(ipaddress);
                //if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()))
                //{
                //    OperationContext context = OperationContext.Current;
                //    MessageProperties prop = context.IncomingMessageProperties;
                //    RemoteEndpointMessageProperty endpoint =
                //    prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                //    ipaddress = endpoint.Address;
                //    if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()) && !geoCountries.Contains(ipcountry))
                //    {
                //        this._hosteventLog = new System.Diagnostics.EventLog();
                //        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                //        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                //        _hosteventLog.Source = "PlushHTTPSServiceSource";
                //        _hosteventLog.Log = "PlushHTTPSServiceLog";
                //        _hosteventLog.WriteEntry("getVodUrl.Exception: 4 vodid, cn, cntry: " + vodid + ", " + cn + ", error: " + ipcountry, System.Diagnostics.EventLogEntryType.Error);

                //        return "4";
                //    }
                //}
                //
                try
                {
                    contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
                    contextBeProd.ObjectTrackingEnabled = false;
                    contextBeProd.QueryCacheEnabled = true;
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

                    string sqlISSVOD = QueriesDB.getIsSVOD(imdb_id);
                    string sqlIsFreeMovie = QueriesDB.getIsFreeMovie(imdb_id);  
                    IEnumerable<numberresult> svodcount = contextBeProd.ExecuteQuery<numberresult>(sqlISSVOD, null);
                    isSVOD = svodcount.First().r > 0;

                    IEnumerable<numberresult> freemoviecount = contextBeProd.ExecuteQuery<numberresult>(sqlIsFreeMovie, null);
                    isFreeMovie = freemoviecount.First().r > 0;

                    IEnumerable<CustomerDetailsRow> cdr = contextMobileApiWs.ExecuteQuery<CustomerDetailsRow>("CALL sp_customer_getbyid({0})", cn);

                    if (cdr.Count() > 0)
                    {
                        cd = cdr.ToList()[0];
                    }
                    else
                    {
                        return "1"; //no customer
                    }
                    if (!isSVOD && cd.ogreg == 0 && !isFreeMovie)
                    {
                        return "2"; //not ogone registerd
                    }
                    if ((cd.isac == 0))
                    {
                        return "3"; //not active
                    }
                    if (cd.susp > 0)
                    {
                        return "6"; //suspended
                    }
                    if (cd.sbst == 6 && isSVOD && !isFreeMovie)
                    {
                        return "7";
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

                try
                {
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

                    string sqlDirectorSlugAndMovieRating = QueriesDB.GetDirectorSlugAndMovieRating(vodid, cd.lng);

                    contextBeProd.ExecuteCommand("call sp_smarttv_token_insert({0},{1},{2},{3},{4},{5})", cn, token, imdb_id, ipaddress, Utilities.GetClientCoutry(),(device==8?57:54));

                    bool sendEmail = false;
                    bool isParsedEmail = bool.TryParse(ConfigurationManager.AppSettings["sendemail"], out sendEmail);

                    if (sendEmail && !isSVOD)
                    {
                        IEnumerable<VodConfirmationEmail> vcm = contextBeProd.ExecuteQuery<VodConfirmationEmail>(sqlDirectorSlugAndMovieRating);

                        // send email
                        DataTable dt = new DataTable("customermail");
                        dt.Columns.Add("customers_firstname", typeof(string));
                        dt.Columns.Add("customers_lastname", typeof(string));
                        dt.Columns.Add("customers_name", typeof(string));
                        dt.Columns.Add("customers_gender", typeof(string));
                        dt.Columns.Add("email", typeof(string));
                        dt.Columns.Add("customers_language", typeof(int));
                        dt.Columns.Add("Customers_id", typeof(int));
                        dt.Columns.Add("products_id", typeof(int));
                        dt.Columns.Add("customers_abo_payment_method", typeof(int));
                        dt.Columns.Add("customers_abo", typeof(int));
                        dt.Columns.Add("customers_abo_dvd_home_norm", typeof(int));
                        dt.Columns.Add("customers_abo_dvd_home_adult", typeof(int));
                        dt.Columns.Add("date_sent", typeof(DateTime));
                        dt.Columns.Add("director_slug", typeof(string));
                        dt.Columns.Add("director_name", typeof(string));
                        dt.Columns.Add("movie_rating", typeof(decimal));
                        dt.Columns.Add("products_image_big", typeof(string));
                        dt.Columns.Add("products_name", typeof(string));
                        dt.Columns.Add("products_year", typeof(string));
                        dt.Columns.Add("products_description", typeof(string));
                        dt.Columns.Add("imdb_id", typeof(string));

                        DataRow dr = dt.NewRow();
                        dr["customers_firstname"] = cd.frst;
                        dr["customers_lastname"] = cd.lstn;
                        dr["customers_name"] = cd.frst + " " + cd.lstn;
                        dr["customers_gender"] = cd.gndr;
                        dr["email"] = cd.em;
                        dr["customers_language"] = cd.lng;
                        dr["Customers_id"] = cd.cn;
                        dr["products_id"] = contextBeProd.ExecuteCommand(QueriesDB.GetProductFromVod(vodid));// 120619;

                        dr["customers_abo_payment_method"] = cd.sbst;
                        dr["customers_abo"] = cd.isac;
                        dr["date_sent"] = DateTime.Now;
                        if (vcm != null && vcm.Count() > 0)
                        {
                            VodConfirmationEmail vcmData = vcm.First();
                            dr["director_slug"] = vcmData.slug;
                            dr["director_name"] = vcmData.directors_name;
                            dr["movie_rating"] = vcmData.rate;
                            dr["products_name"] = vcmData.products_name;
                            dr["products_year"] = vcmData.products_year;
                            dr["products_image_big"] = vcmData.products_image_big;
                            dr["imdb_id"] = vcmData.imdb_id;
                            dr["products_description"] = vcmData.products_description;
                        }

                        PlushData.clsConnection.typeEnv = "prod";
                        PlushBuziness.clsMail.SendMail(dr, PlushBuziness.clsMail.Mail.MAIL_PLUSH_TVOD_CONFIRMATION, true, string.Empty, string.Empty, string.Empty);

                    }
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

                string token = getVodUrl(vodid, cn, device);
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
                        Utilities.InsertMobileLog(int.Parse(cd.cdr.cn), "getCustomerDetails", pswd + ":" + cd.cdr.pswd, device, modelcontext);
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

        public int setTVODCustomerSubscription(string em, string pswd, int device, string dvcnmbr, int lngid)
        {
            int newCustomersID;
            string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;
            CustomerDetails cd = new CustomerDetails();
            if (lngid == 0)
            {
                lngid = 1;
            }
            try
            {
                modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
                modelcontext.ObjectTrackingEnabled = false;
                modelcontext.QueryCacheEnabled = true;
                IEnumerable<CustomerDetailsRow> cdr = modelcontext.ExecuteQuery<CustomerDetailsRow>("CALL sp_customer_get({0},{1})", em, string.Empty);

                if (cdr.Count() > 0)
                    return -1;
            }
            catch (Exception ex2)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("setTVODCustomerSubscription.Exception: 1 em, pswd: " + em + ", " + pswd + ", error " + ex2.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex2.InnerException != null)
                {
                    _hosteventLog.WriteEntry("setTVODCustomerSubscription InnerException: 1 " + ex2.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                return 0;
            }
            string[] tvodproductsarray = new string[4];
            tvodproducts tvodproducts = new tvodproducts();
            //
            string[] tvodproductsarrayimages = new string[4];
            tvodproducts tvodproductsimages = new tvodproducts();

            IEnumerable<tvodproducts> resultTVODProducts;

            try
            {
                modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
                modelcontext.ObjectTrackingEnabled = false;
                modelcontext.QueryCacheEnabled = true;

                string encryptedPass = Utilities.BCryptPassword(pswd);
                newCustomersID = modelcontext.ExecuteCommand("CALL sp_TVODcustomer_subscription({0},{1},{2})", em, encryptedPass,lngid);

                string strSQLTVODProducts = QueriesDB.getTVODAnyoneProducts();
                resultTVODProducts = modelcontext.ExecuteQuery<tvodproducts>(strSQLTVODProducts);
            }
            catch (Exception ex)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("setTVODCustomerSubscription.Exception: 2 em, pswd: " + em + ", " + pswd + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("setTVODCustomerSubscription InnerException: 2 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                return 0;
            }
            try
            {
                DVdPostMobileApIWS contextBeProd = null;
                string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
                contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
                contextBeProd.ObjectTrackingEnabled = false;
                contextBeProd.QueryCacheEnabled = true;


                // send email
                DataTable dt = new DataTable("customermail");
                dt.Columns.Add("customers_firstname", typeof(string));
                dt.Columns.Add("customers_lastname", typeof(string));
                dt.Columns.Add("customers_name", typeof(string));
                dt.Columns.Add("customers_gender", typeof(string));
                dt.Columns.Add("products_id1", typeof(string));
                dt.Columns.Add("products_id2", typeof(string));
                dt.Columns.Add("products_id3", typeof(string));
                dt.Columns.Add("products_id4", typeof(string));
                dt.Columns.Add("products_id1_name", typeof(string));
                dt.Columns.Add("products_id2_name", typeof(string));
                dt.Columns.Add("products_id3_name", typeof(string));
                dt.Columns.Add("products_id4_name", typeof(string));
                dt.Columns.Add("products_id1_img", typeof(string));
                dt.Columns.Add("products_id2_img", typeof(string));
                dt.Columns.Add("products_id3_img", typeof(string));
                dt.Columns.Add("products_id4_img", typeof(string));
                dt.Columns.Add("email", typeof(string));
                dt.Columns.Add("customers_language", typeof(int));
                dt.Columns.Add("Customers_id", typeof(int));

                DataRow dr = dt.NewRow();
                dr["customers_firstname"] = string.Empty;
                dr["customers_lastname"] = string.Empty;
                dr["customers_name"] = string.Empty;
                dr["customers_gender"] = string.Empty;
                dr["products_id1"] = resultTVODProducts.ToArray()[0].products_id;
                dr["products_id2"] = resultTVODProducts.ToArray()[1].products_id;
                dr["products_id3"] = resultTVODProducts.ToArray()[2].products_id;
                dr["products_id4"] = resultTVODProducts.ToArray()[3].products_id;
                dr["products_id1_name"] = resultTVODProducts.ToArray()[0].products_name; 
                dr["products_id2_name"] = resultTVODProducts.ToArray()[1].products_name; 
                dr["products_id3_name"] = resultTVODProducts.ToArray()[2].products_name;
                dr["products_id4_name"] = resultTVODProducts.ToArray()[3].products_name;
                dr["products_id1_img"] = resultTVODProducts.ToArray()[0].products_image_big; 
                dr["products_id2_img"] = resultTVODProducts.ToArray()[1].products_image_big;
                dr["products_id3_img"] = resultTVODProducts.ToArray()[2].products_image_big;
                dr["products_id4_img"] = resultTVODProducts.ToArray()[3].products_image_big;
                dr["email"] = em;
                dr["customers_language"] = lngid;
                dr["Customers_id"] = newCustomersID;


                PlushData.clsConnection.typeEnv = "prod";
                PlushBuziness.clsMail.SendMail(dr, PlushBuziness.clsMail.Mail.MAIL_PLUSH_TVOD_TO_ANYONE_WELCOME, true, string.Empty, string.Empty, string.Empty);

            }
            catch (Exception ex3)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("setTVODCustomerSubscription.Exception: 3 em, pswd: " + em + ", " + pswd + ", error " + ex3.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex3.InnerException != null)
                {
                    _hosteventLog.WriteEntry("setTVODCustomerSubscription InnerException: 3 " + ex3.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                return 0;
            }

            return newCustomersID;

        }

        public void AcceptAlias(string ALIAS, string BRAND, string CARDNO, string CN, string CVC, string ED, string NCERROR, string NCERRORCN, string NCERRORCARDNO, string NCERRORCVC, string NCERRORED, string ORDERID, string SHASIGN, string STATUS)
        {
            string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;

            this._hosteventLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            _hosteventLog.Source = "PlushHTTPSServiceSource";
            _hosteventLog.Log = "PlushHTTPSServiceLog";

            try
            {
                modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
                modelcontext.ObjectTrackingEnabled = false;
                modelcontext.QueryCacheEnabled = true;

                string strSQLTVODProducts = QueriesDB.UpdateAlias(ALIAS,BRAND,CARDNO,CVC,CVC,ED,NCERROR,NCERRORCN,NCERRORCARDNO,NCERRORCVC,NCERRORED,ORDERID,SHASIGN,STATUS);
                _hosteventLog.WriteEntry("AcceptAlias : " + ORDERID + ", " + STATUS + ", " + ALIAS + ", " + BRAND + ", " + CN + ", " + CARDNO + ", " + CVC + ", " + ED + ", " + NCERROR + ", " + NCERRORCN + ", " + NCERRORCARDNO + ", " + NCERRORCVC + ", " + NCERRORED + ", " + SHASIGN + "error: " + strSQLTVODProducts, System.Diagnostics.EventLogEntryType.Error);
                int rezultat = modelcontext.ExecuteCommand(strSQLTVODProducts);
            }
            catch(Exception ex)
            {
               
                _hosteventLog.WriteEntry("AcceptAlias Exception: " + ORDERID + ", " + STATUS + ", " + ALIAS + ", " + BRAND + ", " + CN + ", " + CARDNO + ", " + CVC + ", " + ED + ", " + NCERROR + ", " + NCERRORCN + ", " + NCERRORCARDNO + ", " + NCERRORCVC + ", " + NCERRORED + ", " + SHASIGN + "error: " + ex.Message , System.Diagnostics.EventLogEntryType.Error);
            }

            
           
        }

        public void ExceptionAlias(string ALIAS, string BRAND, string CARDNO, string CN, string CVC, string ED, string NCERROR, string NCERRORCN, string NCERRORCARDNO, string NCERRORCVC, string NCERRORED, string ORDERID, string SHASIGN, string STATUS)
        {
            string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;

            this._hosteventLog = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            _hosteventLog.Source = "PlushHTTPSServiceSource";
            _hosteventLog.Log = "PlushHTTPSServiceLog";

            try
            {
                modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
                modelcontext.ObjectTrackingEnabled = false;
                modelcontext.QueryCacheEnabled = true;

                string strSQLTVODProducts = QueriesDB.UpdateAlias(ALIAS, BRAND, CARDNO, CVC, CVC, ED, NCERROR, NCERRORCN, NCERRORCARDNO, NCERRORCVC, NCERRORED, ORDERID, SHASIGN, STATUS);
                _hosteventLog.WriteEntry("ExceptionAlias: " + ORDERID + ", " + STATUS + ", " + ALIAS + ", " + BRAND + ", " + CN + ", " + CARDNO + ", " + CVC + ", " + ED + ", " + NCERROR + ", " + NCERRORCN + ", " + NCERRORCARDNO + ", " + NCERRORCVC + ", " + NCERRORED + ", " + SHASIGN + "error: " + strSQLTVODProducts, System.Diagnostics.EventLogEntryType.Error);
                int rezultat = modelcontext.ExecuteCommand(strSQLTVODProducts);
            }
            catch (Exception ex)
            {

                _hosteventLog.WriteEntry("AccepAlias Exception: " + ORDERID + ", " + STATUS + ", " + ALIAS + ", " + BRAND + ", " + CN + ", " + CARDNO + ", " + CVC + ", " + ED + ", " + NCERROR + ", " + NCERRORCN + ", " + NCERRORCARDNO + ", " + NCERRORCVC + ", " + NCERRORED + ", " + SHASIGN + "error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
//Ogone alias and payment
        public VodTokenLengs TVODPayAndGetVodTokenAndLngs(int imdb_id, int disk_id, int season_id, string amount, string card_type, string card_no, string card_ed, string card_owner, string cvc, int cn, int device)
        {
            bool isSVOD = true;
            bool isFreeMovie = true;
            VodTokenLengs returnVTL = new VodTokenLengs();
            CustomerDetailsRow cd;
            string connstr_mobile_api_ws = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            DVdPostMobileApIWS contextMobileApiWs = new DVdPostMobileApIWS(new MySqlConnection(connstr_mobile_api_ws));
            DVdPostMobileApIWS contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));

            contextMobileApiWs.ObjectTrackingEnabled = false;
            contextMobileApiWs.QueryCacheEnabled = true;

            string sqlISSVOD = QueriesDB.getIsSVOD(imdb_id);
            string sqlIsFreeMovie = QueriesDB.getIsFreeMovie(imdb_id);
            IEnumerable<numberresult> svodcount = contextBeProd.ExecuteQuery<numberresult>(sqlISSVOD, null);
            isSVOD = svodcount.First().r > 0;

            IEnumerable<numberresult> freemoviecount = contextBeProd.ExecuteQuery<numberresult>(sqlIsFreeMovie, null);
            isFreeMovie = freemoviecount.First().r > 0;

            IEnumerable<CustomerDetailsRow> cdr = contextMobileApiWs.ExecuteQuery<CustomerDetailsRow>("CALL sp_customer_getbyid({0})", cn);

            if (cdr.Count() > 0)
            {
                cd = cdr.ToList()[0];
            }
            else
            {
                returnVTL.t = "1";
                return returnVTL;  //no customer
            }
            //if (!isSVOD && cd.ogreg == 0 && !isFreeMovie)
            //{
            //    returnVTL.t = "2"; //not ogone registerd
            //    return returnVTL;  
            //}
            if ((cd.isac == 0))
            {
                returnVTL.t = "3"; //not active
                return returnVTL; 
            }
            if (cd.susp > 0)
            {
                returnVTL.t = "6"; //suspended
                return returnVTL; 
            }
            if (cd.sbst == 6 && isSVOD && !isFreeMovie)
            {
                returnVTL.t = "7"; //light customers can not wathc svod
                return returnVTL; 
            }           

            //token already exists
            string sqlGetToken = QueriesDB.getToken(imdb_id, cn);
            var listToken = contextBeProd.ExecuteQuery<Utilities.Token>(sqlGetToken);
            if (listToken.Count<Utilities.Token>() > 0)
            {
                IEnumerable<VODChannel> vodch = contextMobileApiWs.ExecuteQuery<VODChannel>("CALL spmovie_vod_products({0},{1},{2},{3})", imdb_id, disk_id, season_id, Utilities.GetClientCoutry());
                if (vodch.Count() > 0)
                {
                    returnVTL.a = vodch.ToList()[0].a;
                    returnVTL.t = listToken.ToList()[0].token;
                    return returnVTL;
                }
            }
            //

            if ((cd.pmt.Equals("1")) && ((cd.ocno != null && cd.ocno != card_no) || (cd.octp != null && cd.octp != card_type) || (cd.oexp != null && cd.oexp != card_ed) || (cd.oown != null && cd.oown != card_owner)))
            {
                returnVTL = CreateOgoneAlias(card_type, card_owner, card_no, cvc, card_ed, cd.cn);
                int alias_created = int.Parse(returnVTL.t);
                if (alias_created < 0)
                {
                    return returnVTL;
                }
            }
            else if (cd.pmt.Equals("0"))
            {
                returnVTL = CreateOgoneAlias(card_type, card_owner, card_no, cvc, card_ed, cd.cn);
                int alias_created = int.Parse(returnVTL.t);
                if (alias_created < 0)
                {
                    return returnVTL;
                }
            }

            ////insert abo
            //string sqlABO = QueriesDB.GetInsertHistoryAbo(int.Parse(cd.cn), string.Empty, 6, "OGONE", 37);
            //IEnumerable<aliasorder> abo_idEnumerable = contextBeProd.ExecuteQuery<aliasorder>(sqlABO, null);
            //int abo_id = abo_idEnumerable.FirstOrDefault().returned_number ;
            ////insert payment
            //string sqlOgonePayment = QueriesDB.CreateOgonePayment(abo_id, PlushData.ClsCustomersData.Payment_Method.OGONE, int.Parse(cd.cn), amount);
            //IEnumerable<aliasorder> orderidEnumerable = contextBeProd.ExecuteQuery<aliasorder>(sqlOgonePayment, null);
            //int orderid = orderidEnumerable.FirstOrDefault().returned_number;
            //
            returnVTL = CreateOgonePayment(amount, "p" + cd.cn, cvc, int.Parse(cd.cn));

            int ogone_payment_created = int.Parse(returnVTL.t);
            if (ogone_payment_created < 0)
            {
                return returnVTL;
            }
            string card_no_covered = CradNumberCover(card_no);
            string sqlCustomerOgone = QueriesDB.getUpdateCustomerOgone(cn, card_owner, card_no_covered, card_ed, card_type);
            int customerUpdated = contextBeProd.ExecuteCommand(sqlCustomerOgone, null);

            return getVodTokenAndLngs(imdb_id, disk_id, season_id, cn, device);
        }

        private string CradNumberCover(string number)
        {
                string hiddenString = number.Substring(number.Length - 4).PadLeft(number.Length, 'X');
                return hiddenString;
        }

        private VodTokenLengs CreateOgoneAlias(string brand, string customerName, string cardno, string cvc, string ed, string cn)
        {
            DVdPostMobileApIWS contextBeProd = null;
            VodTokenLengs returnVTL = new VodTokenLengs();

            string alias = "p" + cn;

            //string parameters = "?";
            string parametersToHashTmp = string.Empty;
            string shasign = string.Empty;
            string parameterToHash = string.Empty;

            string aliasGatewayURL = ConfigurationManager.AppSettings["AliasGatewayURL"];
            string acceptURL = ConfigurationManager.AppSettings["AcceptAliasURL"];
            string exceptionURL = ConfigurationManager.AppSettings["ExceptionAliasURL"];
            string passPhrase = ConfigurationManager.AppSettings["passPhrase"];
            string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            aliasorder order = null;

            contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));

            try
            {
                string sqlAliasInsert = QueriesDB.InsertOgoneAliasOrder(customerName, cardno, cvc, ed, alias, cn);
                IEnumerable<aliasorder> aliases = contextBeProd.ExecuteQuery<aliasorder>(sqlAliasInsert, null);

                order = aliases.FirstOrDefault();

                if (order == null)
                {
                    returnVTL.t = "-2";
                    return returnVTL;
                }

            }
            catch (Exception ex)
            {
                returnVTL.t = "-2";
                return returnVTL;
            }

            //to hash
            parametersToHashTmp += "ACCEPTURL=" + acceptURL;
            parametersToHashTmp += "&ALIAS=" + alias;
            parametersToHashTmp += "&EXCEPTIONURL=" + exceptionURL;
            parametersToHashTmp += "&ORDERID=" + order.returned_number;
            parametersToHashTmp += "&PSPID=dvdpostogonetest&";
            parameterToHash = parametersToHashTmp.Replace("&", "KILLBILL1$metropolis");

            string s = GenerateHash(Encoding.UTF8.GetBytes(parameterToHash));
            shasign = s.ToUpper();

            try
            {
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["ACCEPTURL"] = acceptURL;
                    data["ALIAS"] = "p" + cn;
                    //data["BRAND"] = brand;
                    data["CARDNO"] = cardno;
                    data["CN"] = customerName;
                    data["CVC"] = cvc;
                    data["ED"] = ed;
                    data["EXCEPTIONURL"] = exceptionURL;
                    data["ORDERID"] = order.returned_number.ToString();
                    data["PSPID"] = "dvdpostogonetest";
                    data["SHASIGN"] = shasign;
                    var response = wb.UploadValues(aliasGatewayURL, "POST", data);

                    Wait();

                    string sqlAliasStatus = QueriesDB.GetOgoneAliasOrderStatus(alias, order.returned_number.ToString());
                    IEnumerable<aliasorder> aliase_status = contextBeProd.ExecuteQuery<aliasorder>(sqlAliasStatus, null);

                    aliasorder order_status = aliase_status.FirstOrDefault();

                    if (order_status.returned_number == 1)
                    {
                        returnVTL.t = "-4";
                        return returnVTL;
                    }
                    returnVTL.t = order.returned_number.ToString();
                    return returnVTL;
                }
            }
            catch (Exception ex)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("CreateOgoneAlias.Exception 2: brand, customerName, cardno, cvc, ed, alias, cn, parameterToHash, shasign: " + brand + ", " + customerName + ", " + cardno + ", " + cvc + ", " + ed + ", " + ", " + alias + ", " + cn + ", " + parameterToHash + ", " + shasign + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("CreateOgoneAlias InnerException 2: " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                returnVTL.t = "-3";
                return returnVTL;
            }
        }

        private VodTokenLengs CreateOgonePayment(string amount, string alias, string cvc,int customers_id)
        {
            DVdPostMobileApIWS contextBeProd = null;
            VodTokenLengs returnVTL = new VodTokenLengs();
            string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            string directLinkURL = ConfigurationManager.AppSettings["OrderURL"];
            string shasign = string.Empty;
            string parameterToHash = string.Empty;
            string parametersToHashOriginal = string.Empty;

            contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));

            contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
            //insert abo
            string sqlABO = QueriesDB.GetInsertHistoryAbo(customers_id, string.Empty, 6, "OGONE", 37);
            IEnumerable<aliasorder> abo_idEnumerable = contextBeProd.ExecuteQuery<aliasorder>(sqlABO, null);
            int abo_id = abo_idEnumerable.FirstOrDefault().returned_number;
            //insert payment
            string sqlOgonePayment = QueriesDB.CreateOgonePayment(abo_id, PlushData.ClsCustomersData.Payment_Method.OGONE, customers_id, amount);
            IEnumerable<aliasorder> orderidEnumerable = contextBeProd.ExecuteQuery<aliasorder>(sqlOgonePayment, null);
            int orderid = orderidEnumerable.FirstOrDefault().returned_number;


            //parameters to hash

            parametersToHashOriginal += "ALIAS=" + alias;
            parametersToHashOriginal += "&ALIASUSAGE=pmtorder";
            parametersToHashOriginal += "&AMOUNT=" + amount;
            parametersToHashOriginal += "&CURRENCY=EUR";
            parametersToHashOriginal += "&CVC=" + cvc;
            parametersToHashOriginal += "&OPERATION=RES";
            parametersToHashOriginal += "&ORDERID=" + orderid;

            parametersToHashOriginal += "&PSPID=dvdpostogonetest&PSWD=dvdapi3&USERID=dvdposttestapi&";

            parameterToHash = parametersToHashOriginal.Replace("&", "KILLBILL1$metropolis");

            string s = GenerateHash(Encoding.UTF8.GetBytes(parameterToHash));
            shasign = s.ToUpper();

            //parameters

            try
            {
                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection();
                    data["ALIAS"] = alias;
                    data["ALIASUSAGE"] = "pmtorder";
                    data["AMOUNT"] = amount;
                    data["CURRENCY"] = "EUR";
                    data["CVC"] = cvc;
                    data["OPERATION"] = "RES";
                    data["ORDERID"] = orderid.ToString() ;
                    data["PSPID"] = "dvdpostogonetest";
                    data["PSWD"] = "dvdapi3";
                    data["SHASIGN"] = shasign;
                    data["USERID"] = "dvdposttestapi";

                    byte[] response = wb.UploadValues(directLinkURL, "POST", data);

                    string str = System.Text.Encoding.UTF8.GetString(response);

                    string sqlResponseXML = QueriesDB.getInsertPaymentOgoneWS(orderid, str);
                    int responseTMP = contextBeProd.ExecuteCommand(sqlResponseXML, null);

                    StringReader rdr = new StringReader(str);
                    XDocument xd = XDocument.Load(rdr);

                    if (xd.Root.Attribute("STATUS").Value.Equals("5") && xd.Root.Attribute("orderID").Value.Equals(orderid.ToString() ))
                    {
                        string sqlUpadatePaymentStatus = QueriesDB.getUpadatePaymentStatus(orderid);
                        int payment_result = contextBeProd.ExecuteCommand(sqlUpadatePaymentStatus, null);

                        returnVTL.t = orderid.ToString() ;
                        return returnVTL;
                    }
                    else
                    {
                        returnVTL.t = "-1";
                        return returnVTL;
                    }
                }
            }
            catch (Exception ex)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("CreateOgonePayment.Exception 1: brand, customerName, cardno, cvc, ed, orderid, alias, cn, parameterToHash, shasign: " + cvc + ", " + orderid + ", " + alias + ", " + ", " + parameterToHash + ", " + shasign + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("CreateOgonePayment InnerException 1: " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                returnVTL.t = "-5";
                return returnVTL;
            }


        }

        //private ncresponse ByteArrayToObject(byte[] arrBytes)
        //{
        //    MemoryStream memStream = new MemoryStream();
        //    BinaryFormatter binForm = new BinaryFormatter();
        //    memStream.Write(arrBytes, 0, arrBytes.Length);
        //    memStream.Seek(0, SeekOrigin.Begin);
        //    Object obj = (Object)binForm.Deserialize(memStream);
        //    return (ncresponse)obj;
        //}

        private void Wait()
        {
            DateTime dt = DateTime.Now.AddSeconds(2);
            while (DateTime.Now < dt) ;
        }

        private static string GenerateHash(byte[] tohash)
        {
            string hashText = "";
            string hexValue = "";

            byte[] hashData = SHA1.Create().ComputeHash(tohash); // SHA1 or MD5

            foreach (byte b in hashData)
            {
                hexValue = b.ToString("X").ToLower(); // Lowercase for compatibility on case-sensitive systems
                hashText += (hexValue.Length == 1 ? "0" : "") + hexValue;
            }

            return hashText;
        }
//
    }

    public class MyPolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint srvPoint,
          X509Certificate certificate, WebRequest request,
          int certificateProblem)
        {
            //Return True to force the certificate to be accepted.
            return true;
        }
    }
}

