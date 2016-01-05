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
using com.Akamai.EdgeAuth;
using buydrm.keyos.authxml.generator;
using buydrm.keyos.authxml.generator.rights;

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

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //private string getBuyDRMVodUrl(int vodid, int cn, int device)
        //{
        //    lock (typeof(WcfService))
        //    {
        //        bool isSVOD = true;
        //        bool isFreeMovie = true;
        //        string ipaddress = string.Empty;
        //        //string ipcountry;
        //        int imdb_id = 0;
        //        //string fileName = string.Empty;
        //        string token = string.Empty;
        //        string connstr_mobile_api_ws = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
        //        string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
        //        string AkamaiTokenKey = ConfigurationManager.AppSettings["AkamaiTokenKey"];
        //        string AkamaiTokenDurationInSeconds = ConfigurationManager.AppSettings["AkamaiTokenDurationInSeconds"];
        //        //string vodUrl;               

        //        VodStreamingInfo vsi = null;
        //        DVdPostMobileApIWS contextMobileApiWs = null;
        //        DVdPostMobileApIWS contextBeProd = null;
        //        IEnumerable<VodStreamingInfo> fn;
        //        //                        
        //        CustomerDetailsRow cd = new CustomerDetailsRow();                
        //        OperationContext context = OperationContext.Current;
        //        MessageProperties prop = context.IncomingMessageProperties;
        //        RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
        //        ipaddress = endpoint.Address;            
        //        try
        //        {
        //            contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
        //            contextBeProd.ObjectTrackingEnabled = false;
        //            contextBeProd.QueryCacheEnabled = true;
        //            string sql = QueriesDB.getVodStreamingInfo(vodid);

        //            fn = contextBeProd.ExecuteQuery<VodStreamingInfo>(sql, null);
        //            if (fn.Count() == 0)
        //            {
        //                return "5";
        //            }
        //            vsi = fn.ToList<VodStreamingInfo>()[0];
        //            imdb_id = vsi.imdb_id;
        //            //fileName = vsi.filename;                   
        //        }
        //        catch (Exception ex)
        //        {
        //            this._hosteventLog = new System.Diagnostics.EventLog();
        //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
        //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
        //            _hosteventLog.Source = "PlushHTTPSServiceSource";
        //            _hosteventLog.Log = "PlushHTTPSServiceLog";
        //            _hosteventLog.WriteEntry("getBuyDRMVodUrl.Exception: 0.1 vodid, cn: " + vodid + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
        //            if (ex.InnerException != null)
        //            {
        //                _hosteventLog.WriteEntry("getBuyDRMVodUrl InnerException: 0.1 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
        //            }
        //            return "0.1";
        //        }
        //        try
        //        {
        //            contextMobileApiWs = new DVdPostMobileApIWS(new MySqlConnection(connstr_mobile_api_ws));
        //            contextMobileApiWs.ObjectTrackingEnabled = false;
        //            contextMobileApiWs.QueryCacheEnabled = true;

        //            string sqlISSVOD = QueriesDB.getIsSVOD(imdb_id);
        //            string sqlIsFreeMovie = QueriesDB.getIsFreeMovie(imdb_id);  
        //            IEnumerable<numberresult> svodcount = contextBeProd.ExecuteQuery<numberresult>(sqlISSVOD, null);
        //            isSVOD = svodcount.First().r > 0;

        //            IEnumerable<numberresult> freemoviecount = contextBeProd.ExecuteQuery<numberresult>(sqlIsFreeMovie, null);
        //            isFreeMovie = freemoviecount.First().r > 0;

        //            IEnumerable<CustomerDetailsRow> cdr = contextMobileApiWs.ExecuteQuery<CustomerDetailsRow>("CALL sp_customer_tvod_free_getbyid({0})", cn);

        //            if (cdr.Count() > 0)
        //            {
        //                cd = cdr.ToList()[0];
        //            }
        //            else
        //            {
        //                return "1"; //no customer
        //            }
        //            if (!isSVOD && cd.ogreg == 0 && !isFreeMovie)
        //            {
        //                return "2"; //not ogone registerd
        //            }
        //            if ((cd.isac == 0))
        //            {
        //                return "3"; //not active
        //            }
        //            if (cd.susp > 0)
        //            {
        //                return "6"; //suspended
        //            }
        //            if (cd.sbst == 6 && isSVOD && !isFreeMovie)
        //            {
        //                return "7";
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            this._hosteventLog = new System.Diagnostics.EventLog();
        //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
        //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
        //            _hosteventLog.Source = "PlushHTTPSServiceSource";
        //            _hosteventLog.Log = "PlushHTTPSServiceLog";
        //            _hosteventLog.WriteEntry("getBuyDRMVodUrl.Exception: 3 vodid, cn: " + vodid + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
        //            if (ex.InnerException != null)
        //            {
        //                _hosteventLog.WriteEntry("getBuyDRMVodUrl InnerException: 3 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
        //            }
        //            return "0.2";
        //        }

        //        try
        //        {   
        //            //CREATE TOKEN
        //            AkamaiTokenConfig conf = new AkamaiTokenConfig();
        //            conf.TokenAlgorithm = Algorithm.HMACSHA256;
        //            conf.Window = long.Parse (AkamaiTokenDurationInSeconds);
        //            conf.Acl = "/ondemand/*";
        //            conf.Key = AkamaiTokenKey ;

        //            token = AkamaiTokenGenerator.GenerateToken(conf);
        //        }
        //        catch (Exception ex)
        //        {
        //            this._hosteventLog = new System.Diagnostics.EventLog();
        //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
        //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
        //            _hosteventLog.Source = "PlushHTTPSServiceSource";
        //            _hosteventLog.Log = "PlushHTTPSServiceLog";
        //            _hosteventLog.WriteEntry("getBuyDRMVodUrl.Exception: 2 vodid, cn: " + vodid + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
        //            if (ex.InnerException != null)
        //            {
        //                _hosteventLog.WriteEntry("getBuyDRMVodUrl InnerException: 2 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
        //            }
        //            return "0.3";
        //        }
        //        string authXML = AuthXMLCreate(ipaddress);

        //        IDbTransaction trans = null;
        //        try
        //        {
        //            if (contextBeProd.Connection.State != ConnectionState.Open)
        //            {
        //                contextBeProd.Connection.Open();
        //            }
        //            trans = contextBeProd.Connection.BeginTransaction();

        //            string sqlDirectorSlugAndMovieRating = QueriesDB.GetDirectorSlugAndMovieRating(vodid, cd.lng);
                    
        //            string sqlGetToken = QueriesDB.getToken(imdb_id, cn);
        //            var listToken = contextBeProd.ExecuteQuery<Utilities.Token>(sqlGetToken);
        //            if (listToken.Count<Utilities.Token>() == 0)
        //            {
        //                contextBeProd.ExecuteCommand("call sp_smarttv_token_insert({0},{1},{2},{3},{4},{5})", cn, token, imdb_id, ipaddress, Utilities.GetClientCoutry(), (device == 8 ? 57 : 54));
        //            }

        //            bool sendEmail = false;
        //            bool isParsedEmail = bool.TryParse(ConfigurationManager.AppSettings["sendemail"], out sendEmail);

        //            if (sendEmail && !isSVOD)
        //            {
        //                IEnumerable<VodConfirmationEmail> vcm = contextBeProd.ExecuteQuery<VodConfirmationEmail>(sqlDirectorSlugAndMovieRating);

        //                IEnumerable<tvodproducts> resultTVODProducts;

        //                string strSQLTVODProducts = QueriesDB.getTVODAnyoneProducts();
        //                resultTVODProducts = contextMobileApiWs.ExecuteQuery<tvodproducts>(strSQLTVODProducts);

        //                // send email
        //                DataTable dt = new DataTable("customermail");
        //                dt.Columns.Add("customers_firstname", typeof(string));
        //                dt.Columns.Add("customers_lastname", typeof(string));
        //                dt.Columns.Add("customers_name", typeof(string));
        //                dt.Columns.Add("customers_gender", typeof(string));
        //                dt.Columns.Add("email", typeof(string));
        //                dt.Columns.Add("customers_language", typeof(int));
        //                dt.Columns.Add("Customers_id", typeof(int));
        //                dt.Columns.Add("products_id", typeof(int));
        //                dt.Columns.Add("customers_abo_payment_method", typeof(int));
        //                dt.Columns.Add("customers_abo", typeof(int));
        //                dt.Columns.Add("customers_abo_dvd_home_norm", typeof(int));
        //                dt.Columns.Add("customers_abo_dvd_home_adult", typeof(int));
        //                dt.Columns.Add("date_sent", typeof(DateTime));
        //                dt.Columns.Add("director_slug", typeof(string));
        //                dt.Columns.Add("director_name", typeof(string));
        //                dt.Columns.Add("movie_rating", typeof(decimal));
        //                dt.Columns.Add("products_image_big", typeof(string));
        //                dt.Columns.Add("products_name", typeof(string));
        //                dt.Columns.Add("products_year", typeof(string));
        //                dt.Columns.Add("products_description", typeof(string));
        //                dt.Columns.Add("imdb_id", typeof(string));
        //                dt.Columns.Add("products_id1", typeof(string));
        //                dt.Columns.Add("products_id2", typeof(string));
        //                dt.Columns.Add("products_id3", typeof(string));
        //                dt.Columns.Add("products_id4", typeof(string));
        //                dt.Columns.Add("products_id1_name", typeof(string));
        //                dt.Columns.Add("products_id2_name", typeof(string));
        //                dt.Columns.Add("products_id3_name", typeof(string));
        //                dt.Columns.Add("products_id4_name", typeof(string));
        //                dt.Columns.Add("products_id1_img", typeof(string));
        //                dt.Columns.Add("products_id2_img", typeof(string));
        //                dt.Columns.Add("products_id3_img", typeof(string));
        //                dt.Columns.Add("products_id4_img", typeof(string));

        //                DataRow dr = dt.NewRow();
        //                dr["customers_firstname"] = cd.frst;
        //                dr["customers_lastname"] = cd.lstn;
        //                dr["customers_name"] = cd.frst + " " + cd.lstn;
        //                dr["customers_gender"] = cd.gndr;
        //                dr["email"] = cd.em;
        //                dr["customers_language"] = cd.lng;
        //                dr["Customers_id"] = cd.cn;
        //                dr["products_id"] = contextBeProd.ExecuteCommand(QueriesDB.GetProductFromVod(vodid));// 120619;

        //                dr["customers_abo_payment_method"] = cd.sbst;
        //                dr["customers_abo"] = cd.isac;
        //                dr["date_sent"] = DateTime.Now;
        //                if (vcm != null && vcm.Count() > 0)
        //                {
        //                    VodConfirmationEmail vcmData = vcm.First();
        //                    dr["director_slug"] = vcmData.slug;
        //                    dr["director_name"] = vcmData.directors_name;
        //                    dr["movie_rating"] = vcmData.rate;
        //                    dr["products_name"] = vcmData.products_name;
        //                    dr["products_year"] = vcmData.products_year;
        //                    dr["products_image_big"] = vcmData.products_image_big;
        //                    dr["imdb_id"] = vcmData.imdb_id;
        //                    dr["products_description"] = vcmData.products_description;
        //                }
        //                dr["products_id1"] = resultTVODProducts.ToArray()[0].products_id;
        //                dr["products_id2"] = resultTVODProducts.ToArray()[1].products_id;
        //                dr["products_id3"] = resultTVODProducts.ToArray()[2].products_id;
        //                dr["products_id4"] = resultTVODProducts.ToArray()[3].products_id;
        //                dr["products_id1_name"] = resultTVODProducts.ToArray()[0].products_name;
        //                dr["products_id2_name"] = resultTVODProducts.ToArray()[1].products_name;
        //                dr["products_id3_name"] = resultTVODProducts.ToArray()[2].products_name;
        //                dr["products_id4_name"] = resultTVODProducts.ToArray()[3].products_name;
        //                dr["products_id1_img"] = resultTVODProducts.ToArray()[0].products_image_big;
        //                dr["products_id2_img"] = resultTVODProducts.ToArray()[1].products_image_big;
        //                dr["products_id3_img"] = resultTVODProducts.ToArray()[2].products_image_big;
        //                dr["products_id4_img"] = resultTVODProducts.ToArray()[3].products_image_big;

        //                PlushData.clsConnection.typeEnv = "prod";
        //                PlushBuziness.clsMail.SendMail(dr, PlushBuziness.clsMail.Mail.MAIL_PLUSH_TVOD_CONFIRMATION, true, string.Empty, string.Empty, string.Empty);

        //            }
        //            trans.Commit();
        //            return token;

        //            //
        //        }
        //        catch (Exception ex)
        //        {
        //            if (trans != null)
        //            {
        //                trans.Rollback();
        //            }
        //            this._hosteventLog = new System.Diagnostics.EventLog();
        //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
        //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
        //            _hosteventLog.Source = "PlushHTTPSServiceSource";
        //            _hosteventLog.Log = "PlushHTTPSServiceLog";
        //            _hosteventLog.WriteEntry("getBuyDRMVodUrl.Exception: 3 vodid, cn: " + vodid + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
        //            if (ex.InnerException != null)
        //            {
        //                _hosteventLog.WriteEntry("getBuyDRMVodUrl InnerException: 3 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
        //            }
        //            return "0.4";
        //        }

        //    }
        //}

        [MethodImpl(MethodImplOptions.Synchronized)]
        private string getVodUrl(int vodid, int season_id, int episode_id, int cn, int device)
        {
            Utilities.InsertMobileLog(cn, "getVodUrl 2.1 ",   vodid.ToString() + ", " + cn.ToString(), device);
            //lock (typeof(WcfService))
            //{
                Utilities.InsertMobileLog(cn, "getVodUrl 2.2.1 ", vodid.ToString() + ", " + cn.ToString(), device);
                bool isSVOD = true;
                bool isFreeMovie = true;
                string ipaddress = string.Empty;
                //string ipcountry;
                int imdb_id = 0;
                string fileName = string.Empty;
                string quality = string.Empty;
                string akamai_folder = string.Empty;
                string token = string.Empty;
                string connstr_mobile_api_ws = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
                string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
                string vodUrl;
                bool geoCheck = false;
                Utilities.InsertMobileLog(cn, "getVodUrl 2.2.2 ", imdb_id.ToString() + ", " + vodid.ToString() + ", " + cn.ToString(), device);
                bool isParsed = bool.TryParse(ConfigurationManager.AppSettings["GeoCheck"], out geoCheck);
                vodUrl = ConfigurationManager.AppSettings["VodUrl"];
                string tokenKind = "_";

                //string notGeoCustomer = ConfigurationManager.AppSettings["NotGeoCustomer"];
                //ArrayList notGeoCustomerList = new ArrayList();
                //notGeoCustomerList.AddRange(notGeoCustomer.Split(new char[] { ',' }));
                //
                Utilities.InsertMobileLog(cn, "getVodUrl 2.2 ", imdb_id.ToString() + ", " + vodid.ToString() + ", " + cn.ToString(), device);
                //string geoCountries = ConfigurationManager.AppSettings["GeoCountries"];
                //ArrayList geoCountriesList = new ArrayList();
                //geoCountriesList.AddRange(geoCountries.Split(new char[] { ',' }));

                VodStreamingInfo vsi = null;
                DVdPostMobileApIWS contextMobileApiWs = null;
                DVdPostMobileApIWS contextBeProd = null;
                IEnumerable<VodStreamingInfo> fn;
                //                        
                CustomerDetailsRowExtended cd = new CustomerDetailsRowExtended();

                //geo check
                //string filePath = ConfigurationManager.AppSettings["countryFilePath"];
                //CountryLookup cl = new CountryLookup(filePath);
                //ipcountry = Utilities.GetClientCoutry();// cl.lookupCountryCode(ipaddress);
                //if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()))
                //{
                OperationContext context = OperationContext.Current;
                MessageProperties prop = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                ipaddress = endpoint.Address;

                Utilities.InsertMobileLog(cn, "getVodUrl 2.3 ", imdb_id.ToString() + ", " + vodid.ToString() + ", " + cn.ToString(), device);
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
                    quality = vsi.quality;
                    akamai_folder = vsi.akamai_folder;
                    //chect if token already exists
                    string sqlGetToken = QueriesDB.getToken(imdb_id, season_id, episode_id, cn);
                    var listToken = contextBeProd.ExecuteQuery<Utilities.Token>(sqlGetToken);
                    if (listToken.Count<Utilities.Token>() > 0)
                    {
                        if (akamai_folder != null && akamai_folder != string.Empty)
                        {
                            akamai_folder += "/";
                        }
                        if (quality != null && quality != string.Empty && (quality.Equals("1080p") || quality.Equals("720p")))
                        {
                            token = "4/i/" + akamai_folder + imdb_id;
                        }
                        else
                        {
                            token = "3/i/" + akamai_folder + imdb_id;
                        }

                        return token;
                    }

                    Utilities.InsertMobileLog(cn, "getVodUrl 2.4 ", imdb_id.ToString() + ", " + vodid.ToString() + ", " + cn.ToString(), device);
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

                    //IEnumerable<CustomerDetailsRow> cdr = contextMobileApiWs.ExecuteQuery<CustomerDetailsRow>("CALL sp_customer_getbyid({0})", cn);
                    IEnumerable<CustomerDetailsRowExtended> cdr = contextMobileApiWs.ExecuteQuery<CustomerDetailsRowExtended>("CALL sp_customer_tvod_free_getbyid({0})", cn);

                    if (cdr.Count() > 0)
                    {
                        cd = cdr.ToList()[0];
                    }
                    else
                    {
                        return "1"; //no customer
                    }
                    if (!isSVOD && cd.ogreg == 0 && !isFreeMovie && !(cd.tvod_free>0) )
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

                    if (cd.tvod_free > 0)
                    {
                        string sqlTvodFreeDecrease = QueriesDB.getTVODFREEDecrease(cn);
                        contextBeProd.ExecuteCommand(sqlTvodFreeDecrease);
                        tokenKind = "FREE";
                    }
                    else if (cd.sbst == 6)
                    {
                        tokenKind = "TVOD_ONLY";
                    }
                    Utilities.InsertMobileLog(cn, "getVodUrl 2.4 ", imdb_id.ToString() + ", " + vodid.ToString() + ", " + cn.ToString(), device);
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

                string useAkamai = ConfigurationManager.AppSettings["UseAkamai"];
                 
                if (akamai_folder != null && akamai_folder != string.Empty)
                {
                    akamai_folder += "/";
                }
                if (quality != null && quality != string.Empty && (quality.Equals("1080p") || quality.Equals("720p")))
                {
                    token = "4/i/" + akamai_folder + imdb_id;
                }
                else
                {
                    token = "3/i/" + akamai_folder + imdb_id;
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
                    Utilities.InsertMobileLog(cn, "getVodUrl 2.6 ", imdb_id.ToString() + ", " + vodid.ToString() + ", " + cn.ToString(), device);
                    contextBeProd.ExecuteCommand("call sp_smarttv_token_insert({0},{1},{2},{3},{4},{5},{6},{7},{8})", cn, token, imdb_id, season_id, episode_id, ipaddress, Utilities.GetClientCoutry(), (device == 8 ? 57 : 54), tokenKind);
                    //contextBeProd.ExecuteCommand("call sp_smarttv_token_insert({0},{1},{2},{3},{4},{5},{6})", cn, token, imdb_id, ipaddress, Utilities.GetClientCoutry(), (device == 8 ? 57 : 54), tokenKind);
                    Utilities.InsertMobileLog(cn, "getVodUrl 2.7 ", imdb_id.ToString() + ", " + vodid.ToString() + ", " + cn.ToString(), device);

                    bool sendEmail = false;
                    bool isParsedEmail = bool.TryParse(ConfigurationManager.AppSettings["sendemail"], out sendEmail);

                    if (sendEmail && !isSVOD)
                    {
                        IEnumerable<VodConfirmationEmail> vcm = contextBeProd.ExecuteQuery<VodConfirmationEmail>(sqlDirectorSlugAndMovieRating);

                        IEnumerable<tvodproducts> resultTVODProducts;

                        string strSQLTVODProducts = QueriesDB.getTVODAnyoneProducts();
                        resultTVODProducts = contextMobileApiWs.ExecuteQuery<tvodproducts>(strSQLTVODProducts);

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
                        Utilities.InsertMobileLog(cn, "getVodUrl 2.9.1 ", imdb_id.ToString() + ", " + vodid.ToString() + ", " + cn.ToString(), device);
                        PlushData.clsConnection.typeEnv = "prod";
                        PlushBuziness.clsMail.SendMail(dr, PlushBuziness.clsMail.Mail.MAIL_PLUSH_TVOD_CONFIRMATION, true, string.Empty, string.Empty, string.Empty);
                        Utilities.InsertMobileLog(cn, "getVodUrl 2.9.2 ", imdb_id.ToString() + ", " + vodid.ToString() + ", " + cn.ToString(), device);
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

            //}
        }
        private bool isAvailableAsCurrentMovie(DVdPostMobileApIWS contextBeProd, int imdb_id, int season_id, int episode_id, int cn)
        {
            string sqlGetToken = QueriesDB.getToken(imdb_id, season_id, episode_id, cn);
            //string sqlGetToken = QueriesDB.getToken(imdb_id, cn);
            var listToken = contextBeProd.ExecuteQuery<Utilities.Token>(sqlGetToken);
            return listToken.Count<Utilities.Token>() > 0;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public VodTokenAuthXMLLengs getBuyDRMVodTokenAuthXMLAndLngs(int imdb_id, int disk_id, int season_id, int cn, int device)
        {
            return getPrivate(imdb_id, disk_id, season_id, cn, device, 0);
            ////lock (typeof(WcfService))
            ////{
            //    DVdPostMobileApIWS contextMobileApiWs = null;
            //    DVdPostMobileApIWS contextBeProd = null;
            //    CustomerDetailsRowExtended cd = new CustomerDetailsRowExtended();
            //    string ipaddress = string.Empty;
            //    string ipcountry;
            //    bool geoCheck = false;
            //    bool isSVOD = true;
            //    bool isFreeMovie = true;
            //    bool isCurrentMovie = false;
            //    string token = string.Empty;
            //    string audiolanguageReturn = string.Empty;
            //    string authXML = string.Empty;
            //    bool isParsed = bool.TryParse(ConfigurationManager.AppSettings["GeoCheck"], out geoCheck);                
            //    string notGeoCustomer = ConfigurationManager.AppSettings["NotGeoCustomer"];
            //    string vodUrl = ConfigurationManager.AppSettings["VodUrl"];
            //    string geoCountries = ConfigurationManager.AppSettings["GeoCountries"];
            //    string filePath = ConfigurationManager.AppSettings["countryFilePath"];
            //    string connstr_mobile_api_ws = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            //    string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            //    string AkamaiTokenKey = ConfigurationManager.AppSettings["AkamaiTokenKey"];
            //    string AkamaiTokenDurationInSeconds = ConfigurationManager.AppSettings["AkamaiTokenDurationInSeconds"];
            //    string tokenKind = "_";

            //    VodTokenAuthXMLLengs vtlReturn = new VodTokenAuthXMLLengs();

            //    try
            //    {
            //    Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 0 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
            //    ArrayList notGeoCustomerList = new ArrayList();
            //    notGeoCustomerList.AddRange(notGeoCustomer.Split(new char[] { ',' }));
            //    //            
            //    ArrayList geoCountriesList = new ArrayList();
            //    geoCountriesList.AddRange(geoCountries.Split(new char[] { ',' }));
               
            //        CountryLookup cl = new CountryLookup(filePath);
            //        ipcountry = Utilities.GetClientCoutry();// cl.lookupCountryCode(ipaddress);
            //        if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()))
            //        {
            //            OperationContext context = OperationContext.Current;
            //            MessageProperties prop = context.IncomingMessageProperties;
            //            RemoteEndpointMessageProperty endpoint =
            //            prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            //            ipaddress = endpoint.Address;
            //            if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()) && !geoCountries.Contains(ipcountry))
            //            {
            //                this._hosteventLog = new System.Diagnostics.EventLog();
            //                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            //                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            //                _hosteventLog.Source = "PlushHTTPSServiceSource";
            //                _hosteventLog.Log = "PlushHTTPSServiceLog";
            //                _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 4 imdb_id, cn, cntry: " + imdb_id + ", " + cn + ", error: " + ipcountry, System.Diagnostics.EventLogEntryType.Error);
                            
            //                vtlReturn.a = "";
            //                vtlReturn.t = "4";
            //                vtlReturn.authxml = "";

            //                return vtlReturn;
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        this._hosteventLog = new System.Diagnostics.EventLog();
            //        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            //        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            //        _hosteventLog.Source = "PlushHTTPSServiceSource";
            //        _hosteventLog.Log = "PlushHTTPSServiceLog";
            //        _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs. 1 imdb_id, disk_id, season_id, cn :   " + imdb_id + ", " + disk_id + ", " + season_id + ", " + cn, System.Diagnostics.EventLogEntryType.Error);
            //        _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 1 " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            //        if (ex.InnerException != null)
            //        {
            //            _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs InnerException: 1" + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
            //        }
            //        vtlReturn.a = "";
            //        vtlReturn.t = "0.1";
            //        vtlReturn.authxml = "";

            //        return vtlReturn;
            //    }
            //    try
            //    {
            //        contextMobileApiWs = new DVdPostMobileApIWS(new MySqlConnection(connstr_mobile_api_ws));
            //        contextMobileApiWs.ObjectTrackingEnabled = false;
            //        contextMobileApiWs.QueryCacheEnabled = true;
            //        //
            //        contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
            //        contextBeProd.ObjectTrackingEnabled = false;
            //        contextBeProd.QueryCacheEnabled = true;
            //        //
            //        Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 1 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device, contextMobileApiWs);

            //        IEnumerable<VODChannel> vodch = contextMobileApiWs.ExecuteQuery<VODChannel>("CALL spmovie_vod_products({0},{1},{2},{3})", imdb_id, disk_id, season_id, Utilities.GetClientCoutry());

            //        Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 2 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString() + vodch.ToList()[0].a , device, contextMobileApiWs);

            //        audiolanguageReturn = vodch.ToList()[0].a;                            
                        
            //        string sqlISSVOD = QueriesDB.getIsSVOD(imdb_id);
            //        string sqlIsFreeMovie = QueriesDB.getIsFreeMovie(imdb_id);
            //        IEnumerable<numberresult> svodcount = contextBeProd.ExecuteQuery<numberresult>(sqlISSVOD, null);
            //        isSVOD = svodcount.First().r > 0;

            //        IEnumerable<numberresult> freemoviecount = contextBeProd.ExecuteQuery<numberresult>(sqlIsFreeMovie, null);
            //        isFreeMovie = freemoviecount.First().r > 0;

            //        isCurrentMovie = isAvailableAsCurrentMovie(contextBeProd, imdb_id, cn);

            //        IEnumerable<CustomerDetailsRowExtended> cdr = contextMobileApiWs.ExecuteQuery<CustomerDetailsRowExtended>("CALL sp_customer_tvod_free_getbyid({0})", cn);

            //        if (cdr.Count() > 0)
            //        {
            //            cd = cdr.ToList()[0];
            //        }
            //        else
            //        {
            //            //return "1"; //no customer
            //            vtlReturn.a = "";
            //            vtlReturn.t = "1";
            //            vtlReturn.authxml = "";

            //            return vtlReturn;
            //        }
            //        //if (!isSVOD && cd.ogreg == 0 && !isFreeMovie && !(cd.tvod_free > 0))
            //        //{
            //        //    //return "2"; //not ogone registerd
            //        //    vtlReturn.a = "";
            //        //    vtlReturn.t = "2";
            //        //    vtlReturn.authxml = "";

            //        //    return vtlReturn;
            //        //}
            //        if ((cd.isac == 0))
            //        {
            //            //return "3"; //not active
            //            vtlReturn.a = "";
            //            vtlReturn.t = "3";
            //            vtlReturn.authxml = "";

            //            return vtlReturn;
            //        }
            //        if (cd.susp > 0)
            //        {
            //            //return "6"; //suspended
            //            vtlReturn.a = "";
            //            vtlReturn.t = "6";
            //            vtlReturn.authxml = "";

            //            return vtlReturn;
            //        }
            //        if (cd.sbst == 6 && isSVOD && !isFreeMovie)
            //        {
            //            //return "7";
            //            vtlReturn.a = "";
            //            vtlReturn.t = "7";
            //            vtlReturn.authxml = "";

            //            return vtlReturn;
            //        }
                    
                    
            //        if (!isCurrentMovie && cd.tvod_free > 0 && !isSVOD )
            //        {
            //            //// create Akami token
            //            //token = AkamaiTokenCreate(AkamaiTokenDurationInSeconds, AkamaiTokenKey);
            //            ////CREATE AUTH XML
            //            //authXML = AuthXMLCreate(ipaddress);
            //            // decrease tvod_free
            //            string sqlTvodFreeDecrease = QueriesDB.getTVODFREEDecrease(cn);
            //            contextBeProd.ExecuteCommand(sqlTvodFreeDecrease);
            //            tokenKind = "FREE";
            //            //
            //            //vtlReturn.t = token;
            //            //vtlReturn.authxml = authXML;
            //            //vtlReturn.a = audiolanguageReturn; // vodch.ToList()[0].a;
            //            //Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 7  vtl.a, vtl.t ", audiolanguageReturn + ", " + token, device, contextMobileApiWs);
            //            //return vtlReturn;
            //        }
            //        else if (cd.sbst == 6)
            //        {
            //            tokenKind = "TVOD_ONLY";
            //        }
                    
            //        if (isFreeMovie)
            //        {
            //            tokenKind = "PREPAID";
            //        }
            //        else if (isPrepaid == 1)
            //        {
            //            tokenKind = "PPVPREPAID";
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        this._hosteventLog = new System.Diagnostics.EventLog();
            //        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            //        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            //        _hosteventLog.Source = "PlushHTTPSServiceSource";
            //        _hosteventLog.Log = "PlushHTTPSServiceLog";
            //        _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 2 imdb_id, cn: " + imdb_id + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            //        if (ex.InnerException != null)
            //        {
            //            _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs InnerException: 2 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
            //        }
            //        //return "0.2";
            //        vtlReturn.a = "";
            //        vtlReturn.t = "0.2";
            //        vtlReturn.authxml = "";

            //        return vtlReturn;
            //    }

            //    try
            //    {
            //        // create Akami token
            //        token = AkamaiTokenCreate(AkamaiTokenDurationInSeconds, AkamaiTokenKey); 
            //        //CREATE AUTH XML
            //        authXML = AuthXMLCreate(ipaddress);
            //    }
            //    catch (Exception ex)
            //    {
            //        this._hosteventLog = new System.Diagnostics.EventLog();
            //        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            //        ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            //        _hosteventLog.Source = "PlushHTTPSServiceSource";
            //        _hosteventLog.Log = "PlushHTTPSServiceLog";
            //        _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 3 imdbid, cn: " + imdb_id + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            //        if (ex.InnerException != null)
            //        {
            //            _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs InnerException: 3 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
            //        }
            //        //return "0.3";
            //        vtlReturn.a = "";
            //        vtlReturn.t = "0.3";
            //        vtlReturn.authxml = "";

            //        return vtlReturn;
            //    }
            //    if (!isCurrentMovie)
            //    {
            //        IDbTransaction trans = null;
            //        try
            //        {
            //            if (contextBeProd.Connection.State != ConnectionState.Open)
            //            {
            //                contextBeProd.Connection.Open();
            //            }
            //            trans = contextBeProd.Connection.BeginTransaction();

            //            //string sqlDirectorSlugAndMovieRating = QueriesDB.GetDirectorSlugAndMovieRating(vodid, cd.lng);

            //            TokenInsert(contextBeProd, cn, token, imdb_id, ipaddress, device, tokenKind);

            //            EMailSend(contextBeProd, contextMobileApiWs, cd, isSVOD, imdb_id, (int)(cd.lng.HasValue ? (int)cd.lng : 1));

            //            trans.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            if (trans != null)
            //            {
            //                trans.Rollback();
            //            }
            //            this._hosteventLog = new System.Diagnostics.EventLog();
            //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            //            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            //            _hosteventLog.Source = "PlushHTTPSServiceSource";
            //            _hosteventLog.Log = "PlushHTTPSSerlviceLog";
            //            _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 4 imdb_id, cn: " + imdb_id + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            //            if (ex.InnerException != null)
            //            {
            //                _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs InnerException: 4 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
            //            }
            //            //return "0.4";
            //            vtlReturn.a = "";
            //            vtlReturn.t = "0.4";
            //            vtlReturn.authxml = "";

            //            return vtlReturn;
            //        }
            //    }
            //    Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 4 token ", token, device, contextMobileApiWs);

            //    //VodTokenAuthXMLLengs vtl = new VodTokenAuthXMLLengs();
            //    vtlReturn.t = token;
            //    vtlReturn.authxml = authXML;
            //    vtlReturn.a = audiolanguageReturn; // vodch.ToList()[0].a;
            //    Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 6  vtl.a, vtl.t ", audiolanguageReturn + ", " + token, device, contextMobileApiWs);
            //    return vtlReturn;
               
            ////}
        }

        private VodTokenAuthXMLLengs getPrivate(int imdb_id, int disk_id, int season_id, int cn, int device, int isPrepaid)
        {
            //lock (typeof(WcfService))
            //{
                DVdPostMobileApIWS contextMobileApiWs = null;
                DVdPostMobileApIWS contextBeProd = null;
                CustomerDetailsRowExtended cd = new CustomerDetailsRowExtended();
                string ipaddress = string.Empty;
                string ipcountry;
                bool geoCheck = false;
                bool isSVOD = true;
                bool isFreeMovie = true;
                bool isCurrentMovie = false;
                string token = string.Empty;
                string audiolanguageReturn = string.Empty;
                string authXML = string.Empty;
                bool isParsed = bool.TryParse(ConfigurationManager.AppSettings["GeoCheck"], out geoCheck);                
                string notGeoCustomer = ConfigurationManager.AppSettings["NotGeoCustomer"];
                string vodUrl = ConfigurationManager.AppSettings["VodUrl"];
                string geoCountries = ConfigurationManager.AppSettings["GeoCountries"];
                string filePath = ConfigurationManager.AppSettings["countryFilePath"];
                string connstr_mobile_api_ws = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
                string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
                string AkamaiTokenKey = ConfigurationManager.AppSettings["AkamaiTokenKey"];
                string AkamaiTokenDurationInSeconds = ConfigurationManager.AppSettings["AkamaiTokenDurationInSeconds"];
                string tokenKind = "_";

                VodTokenAuthXMLLengs vtlReturn = new VodTokenAuthXMLLengs();

                try
                {
                    Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 0 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
                    ArrayList notGeoCustomerList = new ArrayList();
                    notGeoCustomerList.AddRange(notGeoCustomer.Split(new char[] { ',' }));
                    //            
                    ArrayList geoCountriesList = new ArrayList();
                    geoCountriesList.AddRange(geoCountries.Split(new char[] { ',' }));

                    OperationContext context = OperationContext.Current;
                    MessageProperties prop = context.IncomingMessageProperties;
                    RemoteEndpointMessageProperty endpoint =
                    prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                    ipaddress = endpoint.Address;

                    CountryLookup cl = new CountryLookup(filePath);
                    ipcountry = Utilities.GetClientCoutry();// cl.lookupCountryCode(ipaddress);
                    if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()))
                    {
                       
                        if (geoCheck && !notGeoCustomerList.Contains(cn.ToString()) && !geoCountries.Contains(ipcountry))
                        {
                            this._hosteventLog = new System.Diagnostics.EventLog();
                            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                            ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                            _hosteventLog.Source = "PlushHTTPSServiceSource";
                            _hosteventLog.Log = "PlushHTTPSServiceLog";
                            _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 4 imdb_id, cn, cntry: " + imdb_id + ", " + cn + ", error: " + ipcountry, System.Diagnostics.EventLogEntryType.Error);
                            
                            vtlReturn.a = "";
                            vtlReturn.t = "4";
                            vtlReturn.authxml = "";

                            return vtlReturn;
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
                    _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs. 1 imdb_id, disk_id, season_id, cn :   " + imdb_id + ", " + disk_id + ", " + season_id + ", " + cn, System.Diagnostics.EventLogEntryType.Error);
                    _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 1 " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    if (ex.InnerException != null)
                    {
                        _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs InnerException: 1" + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    vtlReturn.a = "";
                    vtlReturn.t = "0.1";
                    vtlReturn.authxml = "";

                    return vtlReturn;
                }
                try
                {
                    contextMobileApiWs = new DVdPostMobileApIWS(new MySqlConnection(connstr_mobile_api_ws));
                    contextMobileApiWs.ObjectTrackingEnabled = false;
                    contextMobileApiWs.QueryCacheEnabled = true;
                    //
                    contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
                    contextBeProd.ObjectTrackingEnabled = false;
                    contextBeProd.QueryCacheEnabled = true;
                    //
                    Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 1 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device, contextMobileApiWs);

                    IEnumerable<VODChannel> vodch = contextMobileApiWs.ExecuteQuery<VODChannel>("CALL spmovie_vod_products({0},{1},{2},{3})", imdb_id, disk_id, season_id, Utilities.GetClientCoutry());

                    Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 2 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString() + vodch.ToList()[0].a , device, contextMobileApiWs);

                    audiolanguageReturn = vodch.ToList()[0].a;                            
                        
                    string sqlISSVOD = QueriesDB.getIsSVOD(imdb_id);
                    string sqlIsFreeMovie = QueriesDB.getIsFreeMovie(imdb_id);
                    IEnumerable<numberresult> svodcount = contextBeProd.ExecuteQuery<numberresult>(sqlISSVOD, null);
                    isSVOD = svodcount.First().r > 0;
                    Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 2.1 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString() + vodch.ToList()[0].a, device, contextMobileApiWs);
                    IEnumerable<numberresult> freemoviecount = contextBeProd.ExecuteQuery<numberresult>(sqlIsFreeMovie, null);
                    isFreeMovie = freemoviecount.First().r > 0;
                    Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 2.2 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString() + vodch.ToList()[0].a, device, contextMobileApiWs);
                    isCurrentMovie = isAvailableAsCurrentMovie(contextBeProd, imdb_id, season_id,disk_id , cn);
                    Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 2.3 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString() + vodch.ToList()[0].a, device, contextMobileApiWs);
                    IEnumerable<CustomerDetailsRowExtended> cdr = contextMobileApiWs.ExecuteQuery<CustomerDetailsRowExtended>("CALL sp_customer_tvod_free_getbyid({0})", cn);

                    if (cdr.Count() > 0)
                    {
                        cd = cdr.ToList()[0];
                    }
                    else
                    {
                        //return "1"; //no customer
                        vtlReturn.a = "";
                        vtlReturn.t = "1";
                        vtlReturn.authxml = "";

                        return vtlReturn;
                    }
                    //if (!isSVOD && cd.ogreg == 0 && !isFreeMovie && !(cd.tvod_free > 0))
                    //{
                    //    //return "2"; //not ogone registerd
                    //    vtlReturn.a = "";
                    //    vtlReturn.t = "2";
                    //    vtlReturn.authxml = "";

                    //    return vtlReturn;
                    //}
                    if ((cd.isac == 0))
                    {
                        //return "3"; //not active
                        vtlReturn.a = "";
                        vtlReturn.t = "3";
                        vtlReturn.authxml = "";

                        return vtlReturn;
                    }
                    if (cd.susp > 0)
                    {
                        //return "6"; //suspended
                        vtlReturn.a = "";
                        vtlReturn.t = "6";
                        vtlReturn.authxml = "";

                        return vtlReturn;
                    }
                    if (cd.sbst == 6 && isSVOD && !isFreeMovie)
                    {
                        //return "7";
                        vtlReturn.a = "";
                        vtlReturn.t = "7";
                        vtlReturn.authxml = "";

                        Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 2.7 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString() + "vtlReturn.t = 7", device, contextMobileApiWs);

                        return vtlReturn;
                    }
                    
                    
                    if (!isCurrentMovie && cd.tvod_free > 0 && !isSVOD )
                    {
                        //// create Akami token
                        //token = AkamaiTokenCreate(AkamaiTokenDurationInSeconds, AkamaiTokenKey);
                        ////CREATE AUTH XML
                        //authXML = AuthXMLCreate(ipaddress);
                        // decrease tvod_free
                        string sqlTvodFreeDecrease = QueriesDB.getTVODFREEDecrease(cn);
                        contextBeProd.ExecuteCommand(sqlTvodFreeDecrease);
                        tokenKind = "FREE";
                        //
                        //vtlReturn.t = token;
                        //vtlReturn.authxml = authXML;
                        //vtlReturn.a = audiolanguageReturn; // vodch.ToList()[0].a;
                        //Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 7  vtl.a, vtl.t ", audiolanguageReturn + ", " + token, device, contextMobileApiWs);
                        //return vtlReturn;
                    }
                    else if (cd.sbst == 6)
                    {
                        tokenKind = "TVOD_ONLY";
                    }
                    
                    if (isFreeMovie)
                    {
                        tokenKind = "PREPAID";
                    }
                    else if (isPrepaid == 1)
                    {
                        tokenKind = "PPVPREPAID";
                    }

                }
                catch (Exception ex)
                {
                    this._hosteventLog = new System.Diagnostics.EventLog();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                    _hosteventLog.Source = "PlushHTTPSServiceSource";
                    _hosteventLog.Log = "PlushHTTPSServiceLog";
                    _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 2 imdb_id, cn: " + imdb_id + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    if (ex.InnerException != null)
                    {
                        _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs InnerException: 2 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    //return "0.2";
                    vtlReturn.a = "";
                    vtlReturn.t = "0.2";
                    vtlReturn.authxml = "";

                    return vtlReturn;
                }

                try
                {
                    // create Akami token
                    token = AkamaiTokenCreate(AkamaiTokenDurationInSeconds, AkamaiTokenKey); 
                    //CREATE AUTH XML
                    authXML = AuthXMLCreate(ipaddress);
                }
                catch (Exception ex)
                {
                    this._hosteventLog = new System.Diagnostics.EventLog();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                    _hosteventLog.Source = "PlushHTTPSServiceSource";
                    _hosteventLog.Log = "PlushHTTPSServiceLog";
                    _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 3 imdbid, cn: " + imdb_id + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                    if (ex.InnerException != null)
                    {
                        _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs InnerException: 3 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                    }
                    //return "0.3";
                    vtlReturn.a = "";
                    vtlReturn.t = "0.3";
                    vtlReturn.authxml = "";

                    return vtlReturn;
                }
                if (!isCurrentMovie)
                {
                    IDbTransaction trans = null;
                    try
                    {
                        if (contextBeProd.Connection.State != ConnectionState.Open)
                        {
                            contextBeProd.Connection.Open();
                        }
                        trans = contextBeProd.Connection.BeginTransaction();

                        //string sqlDirectorSlugAndMovieRating = QueriesDB.GetDirectorSlugAndMovieRating(vodid, cd.lng);

                        TokenInsert(contextBeProd, cn, token, imdb_id, season_id, disk_id, ipaddress, device, tokenKind);

                        EMailSend(contextBeProd, contextMobileApiWs, cd, isSVOD, imdb_id, (int)(cd.lng.HasValue ? (int)cd.lng : 1));

                        trans.Commit();
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
                        _hosteventLog.Log = "PlushHTTPSSerlviceLog";
                        _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs.Exception: 4 imdb_id, cn: " + imdb_id + ", " + cn + ", error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        if (ex.InnerException != null)
                        {
                            _hosteventLog.WriteEntry("getBuyDRMVodTokenAuthXMLAndLngs InnerException: 4 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                        }
                        //return "0.4";
                        vtlReturn.a = "";
                        vtlReturn.t = "0.4";
                        vtlReturn.authxml = "";

                        return vtlReturn;
                    }
                }
                Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 4 token ", token, device, contextMobileApiWs);

                //VodTokenAuthXMLLengs vtl = new VodTokenAuthXMLLengs();
                vtlReturn.t = token;
                vtlReturn.authxml = authXML;
                vtlReturn.a = audiolanguageReturn; // vodch.ToList()[0].a;
                Utilities.InsertMobileLog(cn, "getBuyDRMVodTokenAuthXMLAndLngs 6  vtl.a, vtl.t ", audiolanguageReturn + ", " + token, device, contextMobileApiWs);
                return vtlReturn;
               
            //}
        }

        private void TokenInsert(DVdPostMobileApIWS contextBeProd, int cn, string token, int imdb_id, int season_id, int episode_id, string ipaddress, int device, string kind)
        {
            string sqlGetToken = QueriesDB.getToken(imdb_id, season_id, episode_id,  cn);
            var listToken = contextBeProd.ExecuteQuery<Utilities.Token>(sqlGetToken);
            if (listToken.Count<Utilities.Token>() == 0)
            {
                contextBeProd.ExecuteCommand("call sp_smarttv_token_insert({0},{1},{2},{3},{4},{5},{6},{7},{8})", cn, token, imdb_id, season_id, episode_id, ipaddress, Utilities.GetClientCoutry(), (device == 8 ? 57 : 54), kind);
                //contextBeProd.ExecuteCommand("call sp_smarttv_token_insert({0},{1},{2},{3},{4},{5},{6})", cn, token, imdb_id, ipaddress, Utilities.GetClientCoutry(), (device == 8 ? 57 : 54), kind);
            }
        }

        private void EMailSend(DVdPostMobileApIWS contextBeProd, DVdPostMobileApIWS contextMobileApiWs, CustomerDetailsRowExtended cd, bool isSVOD, int imdb_id, int lngid = 1)
        {
            bool sendEmail = false;
            bool isParsedEmail = bool.TryParse(ConfigurationManager.AppSettings["sendemail"], out sendEmail);
            string sqlDirectorSlugAndMovieRating = QueriesDB.GetDirectorSlugAndMovieRatingIMDBID(imdb_id, lngid );

            if (sendEmail && !isSVOD)
            {
                IEnumerable<VodConfirmationEmail> vcm = contextBeProd.ExecuteQuery<VodConfirmationEmail>(sqlDirectorSlugAndMovieRating);

                IEnumerable<tvodproducts> resultTVODProducts;

                string strSQLTVODProducts = QueriesDB.getTVODAnyoneProducts();
                resultTVODProducts = contextMobileApiWs.ExecuteQuery<tvodproducts>(strSQLTVODProducts);

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

                DataRow dr = dt.NewRow();
                dr["customers_firstname"] = cd.frst;
                dr["customers_lastname"] = cd.lstn;
                dr["customers_name"] = cd.frst + " " + cd.lstn;
                dr["customers_gender"] = cd.gndr;
                dr["email"] = cd.em;
                dr["customers_language"] = cd.lng;
                dr["Customers_id"] = cd.cn;
                dr["products_id"] = contextBeProd.ExecuteCommand(QueriesDB.GetProductFromVodIMDB(imdb_id));// 120619;

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

                PlushData.clsConnection.typeEnv = "prod";
                PlushBuziness.clsMail.SendMail(dr, PlushBuziness.clsMail.Mail.MAIL_PLUSH_TVOD_CONFIRMATION, true, string.Empty, string.Empty, string.Empty);

            }
        }
        

        public VodTokenLengs getVodTokenAndLngs(int imdb_id, int disk_id, int season_id, int cn, int device)
        {
            Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 1 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
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
                        _hosteventLog.WriteEntry("getVodTokenAndLngs.Exception: 4 imdb_id, cn, cntry: " + imdb_id + ", " + cn + ", error: " + ipcountry, System.Diagnostics.EventLogEntryType.Error);

                        VodTokenLengs vtl1 = new VodTokenLengs();

                        vtl1.a = "";
                        vtl1.t = "4";

                        return vtl1;
                    }
                }

                 IEnumerable<VODChannel> vodch = null;

                //string useAkamai = ConfigurationManager.AppSettings["UseAkamai"];
                //if (useAkamai.Equals("true"))
                //{
                    vodch = modelcontext.ExecuteQuery<VODChannel>("CALL spmovie_vod_products_akamai({0},{1},{2},{3})", imdb_id, disk_id, season_id, Utilities.GetClientCoutry());
                //}
                //else
                //{
                //    vodch = modelcontext.ExecuteQuery<VODChannel>("CALL spmovie_vod_products({0},{1},{2},{3})", imdb_id, disk_id, season_id, Utilities.GetClientCoutry());
                //}

                Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 2 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device, modelcontext);


                string[] vodidTmp = vodch.ToArray()[0].a.Split(',');

                int vodid = int.Parse(vodidTmp[0].Split(':').ToArray()[0]);

                Utilities.InsertMobileLog(cn, "getVodTokenAndLngs 2.1 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device, modelcontext);

                string token = getVodUrl(vodid, season_id,disk_id, cn, device);
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

        public CustomerDetailsExtended getCustomerDetailsExtended(string un, string pswd, int device, string dvcnmbr)
        {
            string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;
            CustomerDetailsExtended cd = new CustomerDetailsExtended();
            bool checkPassword = bool.TryParse(ConfigurationManager.AppSettings["checkPassword"], out checkPassword);

            try
            {

                modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
                modelcontext.ObjectTrackingEnabled = false;
                modelcontext.QueryCacheEnabled = true;

                IEnumerable<CustomerDetailsRowExtended> cdr = modelcontext.ExecuteQuery<CustomerDetailsRowExtended>("CALL sp_customer_get_extended({0},{1})", un, string.Empty);

                if (cdr.Count() > 0)
                {
                    cd.cdr = cdr.FirstOrDefault<CustomerDetailsRowExtended>();
                    Utilities.InsertMobileApplicationLog(int.Parse(cd.cdr.cn), "getCustomerDetailsExtended", dvcnmbr, string.Empty, device);
                    if (checkPassword)
                    {
                        Utilities.InsertMobileLog(int.Parse(cd.cdr.cn), "getCustomerDetailsExtended", pswd + ":" + cd.cdr.pswd, device, modelcontext);
                        if (Utilities.wrongPass(pswd, cd.cdr.pswd))
                        {
                            Utilities.InsertMobileLog(int.Parse(cd.cdr.cn), "getCustomerDetailsExtended - wrong pass ", pswd + ":" + cd.cdr.pswd, device, modelcontext);
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
                _hosteventLog.WriteEntry("getCustomerDetailsExtended.Exception: 5 un, pswd: " + un + ", " + pswd + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("getCustomerDetailsExtended InnerException: 5 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                cd.cdr = null;
                cd.err = 3;
                return cd;
            }
        }

        public CustomerDetailsExtended getCustomerDetailsExtendedByCN(int cn, int device, string dvcnmbr)
        {
            string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;
            CustomerDetailsExtended cd = new CustomerDetailsExtended();           

            try
            {

                modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
                modelcontext.ObjectTrackingEnabled = false;
                modelcontext.QueryCacheEnabled = true;

                IEnumerable<CustomerDetailsRowExtended> cdr = modelcontext.ExecuteQuery<CustomerDetailsRowExtended>("CALL sp_customer_get_bycn_extended({0})", cn);

                Utilities.InsertMobileLog(cn, "getCustomerDetailsExtendedByCN", cn.ToString(), device);

                if (cdr.Count() > 0)
                {
                    cd.cdr = cdr.FirstOrDefault<CustomerDetailsRowExtended>();
                    Utilities.InsertMobileApplicationLog(int.Parse(cd.cdr.cn), "getCustomerDetailsExtendedByCN", dvcnmbr, string.Empty, device);

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
                _hosteventLog.WriteEntry("getCustomerDetailsExtendedByCN.Exception: 5 un, pswd: " + cn + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("getCustomerDetailsExtendedByCN InnerException: 5 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                cd.cdr = null;
                cd.err = 3;
                return cd;
            }
        }

        public CustomersCCData getCustomersCCData(int cn, int device)
        {
            string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;
            CustomersCCData cd = new CustomersCCData();
            //bool checkPassword = bool.TryParse(ConfigurationManager.AppSettings["checkPassword"], out checkPassword);

            Utilities.InsertMobileLog(cn, "getCustomersCCData", cn.ToString(), device);

            try
            {

                modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
                modelcontext.ObjectTrackingEnabled = false;
                modelcontext.QueryCacheEnabled = true;

                IEnumerable<CustomersCCData> cdr = modelcontext.ExecuteQuery<CustomersCCData>("CALL sp_customer_ccdata({0})", cn);
                                
                cd = cdr.FirstOrDefault<CustomersCCData>();                    

                return cd;
                               
            }
            catch (Exception ex)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("getCustomersCCData.Exception:  cn: " + cn + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("getCustomersCCData InnerException:  " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                
                return cd;
            }
        }

        public int setTVODCustomerSubscription(string em, string pswd, int device, string dvcnmbr, int lngid)
        {
            int newCustomersID;
            string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;
            CustomerDetails cd = new CustomerDetails();
            try
            {
                System.Net.Mail.MailAddress validemail = new System.Net.Mail.MailAddress(em);
            }
            catch
            {
                return -2;
            }

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
                {
                    CustomerDetailsRow cdrReactivate = cdr.First<CustomerDetailsRow>();
                    if (cdrReactivate.isac == 0)
                    {
                        newCustomersID = SetOLDSVODCustomer(em, pswd, lngid);
                        return newCustomersID;
                    }
                    return -1;
                }
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

            newCustomersID = SetSVODCustomer( em,  pswd,  lngid);

            return newCustomersID ;
            //string[] tvodproductsarray = new string[4];
            //tvodproducts tvodproducts = new tvodproducts();
            ////
            //string[] tvodproductsarrayimages = new string[4];
            //tvodproducts tvodproductsimages = new tvodproducts();

            //IEnumerable<tvodproducts> resultTVODProducts;

            //try
            //{
            //    modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
            //    modelcontext.ObjectTrackingEnabled = false;
            //    modelcontext.QueryCacheEnabled = true;

            //    string encryptedPass = Utilities.BCryptPassword(pswd);
            //    newCustomersID = modelcontext.ExecuteCommand("CALL sp_TVODcustomer_subscription({0},{1},{2})", em, encryptedPass,lngid);

            //    string strSQLTVODProducts = QueriesDB.getTVODAnyoneProducts();
            //    resultTVODProducts = modelcontext.ExecuteQuery<tvodproducts>(strSQLTVODProducts);
            //}
            //catch (Exception ex)
            //{
            //    this._hosteventLog = new System.Diagnostics.EventLog();
            //    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            //    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            //    _hosteventLog.Source = "PlushHTTPSServiceSource";
            //    _hosteventLog.Log = "PlushHTTPSServiceLog";
            //    _hosteventLog.WriteEntry("setTVODCustomerSubscription.Exception: 2 em, pswd: " + em + ", " + pswd + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            //    if (ex.InnerException != null)
            //    {
            //        _hosteventLog.WriteEntry("setTVODCustomerSubscription InnerException: 2 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
            //    }
            //    return 0;
            //}
            //try
            //{
            //    DVdPostMobileApIWS contextBeProd = null;
            //    string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            //    contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));
            //    contextBeProd.ObjectTrackingEnabled = false;
            //    contextBeProd.QueryCacheEnabled = true;


            //    // send email
            //    DataTable dt = new DataTable("customermail");
            //    dt.Columns.Add("customers_firstname", typeof(string));
            //    dt.Columns.Add("customers_lastname", typeof(string));
            //    dt.Columns.Add("customers_name", typeof(string));
            //    dt.Columns.Add("customers_gender", typeof(string));
            //    dt.Columns.Add("products_id1", typeof(string));
            //    dt.Columns.Add("products_id2", typeof(string));
            //    dt.Columns.Add("products_id3", typeof(string));
            //    dt.Columns.Add("products_id4", typeof(string));
            //    dt.Columns.Add("products_id1_name", typeof(string));
            //    dt.Columns.Add("products_id2_name", typeof(string));
            //    dt.Columns.Add("products_id3_name", typeof(string));
            //    dt.Columns.Add("products_id4_name", typeof(string));
            //    dt.Columns.Add("products_id1_img", typeof(string));
            //    dt.Columns.Add("products_id2_img", typeof(string));
            //    dt.Columns.Add("products_id3_img", typeof(string));
            //    dt.Columns.Add("products_id4_img", typeof(string));
            //    dt.Columns.Add("email", typeof(string));
            //    dt.Columns.Add("customers_language", typeof(int));
            //    dt.Columns.Add("Customers_id", typeof(int));

            //    DataRow dr = dt.NewRow();
            //    dr["customers_firstname"] = string.Empty;
            //    dr["customers_lastname"] = string.Empty;
            //    dr["customers_name"] = string.Empty;
            //    dr["customers_gender"] = string.Empty;
            //    dr["products_id1"] = resultTVODProducts.ToArray()[0].products_id;
            //    dr["products_id2"] = resultTVODProducts.ToArray()[1].products_id;
            //    dr["products_id3"] = resultTVODProducts.ToArray()[2].products_id;
            //    dr["products_id4"] = resultTVODProducts.ToArray()[3].products_id;
            //    dr["products_id1_name"] = resultTVODProducts.ToArray()[0].products_name; 
            //    dr["products_id2_name"] = resultTVODProducts.ToArray()[1].products_name; 
            //    dr["products_id3_name"] = resultTVODProducts.ToArray()[2].products_name;
            //    dr["products_id4_name"] = resultTVODProducts.ToArray()[3].products_name;
            //    dr["products_id1_img"] = resultTVODProducts.ToArray()[0].products_image_big; 
            //    dr["products_id2_img"] = resultTVODProducts.ToArray()[1].products_image_big;
            //    dr["products_id3_img"] = resultTVODProducts.ToArray()[2].products_image_big;
            //    dr["products_id4_img"] = resultTVODProducts.ToArray()[3].products_image_big;
            //    dr["email"] = em;
            //    dr["customers_language"] = lngid;
            //    dr["Customers_id"] = newCustomersID;


            //    PlushData.clsConnection.typeEnv = "prod";
            //    PlushBuziness.clsMail.SendMail(dr, PlushBuziness.clsMail.Mail.MAIL_PLUSH_TVOD_TO_ANYONE_WELCOME, true, string.Empty, string.Empty, string.Empty);

            //}
            //catch (Exception ex3)
            //{
            //    this._hosteventLog = new System.Diagnostics.EventLog();
            //    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
            //    ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
            //    _hosteventLog.Source = "PlushHTTPSServiceSource";
            //    _hosteventLog.Log = "PlushHTTPSServiceLog";
            //    _hosteventLog.WriteEntry("setTVODCustomerSubscription.Exception: 3 em, pswd: " + em + ", " + pswd + ", error " + ex3.Message, System.Diagnostics.EventLogEntryType.Error);
            //    if (ex3.InnerException != null)
            //    {
            //        _hosteventLog.WriteEntry("setTVODCustomerSubscription InnerException: 3 " + ex3.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
            //    }
            //    return 0;
            //}

            //return newCustomersID;

        }

        private int SetSVODCustomer(string em, string pswd, int lngid)
        {
            int newCustomersID;
            string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;
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
                newCustomersID = modelcontext.ExecuteCommand("CALL sp_TVODcustomer_subscription({0},{1},{2})", em, encryptedPass, lngid);

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
                _hosteventLog.WriteEntry("SetSVODCustomer.Exception: 2 em, pswd: " + em + ", " + pswd + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("SetSVODCustomer InnerException: 2 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
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
                _hosteventLog.WriteEntry("SetSVODCustomer.Exception: 3 em, pswd: " + em + ", " + pswd + ", error " + ex3.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex3.InnerException != null)
                {
                    _hosteventLog.WriteEntry("SetSVODCustomer InnerException: 3 " + ex3.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                return 0;
            }

            return newCustomersID;
        }

        private int SetOLDSVODCustomer(string em, string pswd, int lngid)
        {
            int newCustomersID;
            string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            DVdPostMobileApIWS modelcontext = null;
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
                newCustomersID = modelcontext.ExecuteCommand("CALL sp_OLDTVODcustomer_subscription({0},{1},{2})", em, encryptedPass, lngid);

                string strSQLTVODProducts = QueriesDB.getTVODAnyoneProducts();
                resultTVODProducts = modelcontext.ExecuteQuery<tvodproducts>(strSQLTVODProducts);
                Utilities.InsertMobileLog(newCustomersID, "SetOLDSVODCustomer 2.2.1 ", "", lngid);
            }
            catch (Exception ex)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("SetOLDSVODCustomer.Exception: 2 em, pswd: " + em + ", " + pswd + ", error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("SetOLDSVODCustomer InnerException: 2 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
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

                Utilities.InsertMobileLog(newCustomersID, "SetOLDSVODCustomer 2.2.2 ", "", lngid);
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
                Utilities.InsertMobileLog(newCustomersID, "SetOLDSVODCustomer 2.2.3 ", "", lngid);

            }
            catch (Exception ex3)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("SetOLDSVODCustomer.Exception: 3 em, pswd: " + em + ", " + pswd + ", error " + ex3.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex3.InnerException != null)
                {
                    _hosteventLog.WriteEntry("SetOLDSVODCustomer InnerException: 3 " + ex3.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
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

                _hosteventLog.WriteEntry("ExceptionAlias Exception: " + ORDERID + ", " + STATUS + ", " + ALIAS + ", " + BRAND + ", " + CN + ", " + CARDNO + ", " + CVC + ", " + ED + ", " + NCERROR + ", " + NCERRORCN + ", " + NCERRORCARDNO + ", " + NCERRORCVC + ", " + NCERRORED + ", " + SHASIGN + "error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
//Ogone alias and payment
        public VodTokenAuthXMLLengs TVODPayAndGetVodTokenAuthXMLAndLngs(int imdb_id, int disk_id, int season_id, string amount, string card_type, string card_no, string card_ed, string card_owner, string card_cvc, int cn, int device)
        {
            bool isSVOD = true;
            bool isFreeMovie = true;
            bool isCurrentMovie = false;
            VodTokenLengs returnVTL = new VodTokenLengs();
            CustomerDetailsRowExtended cd;
            VodTokenAuthXMLLengs vtlReturn = new VodTokenAuthXMLLengs();
            //geolocalisation check 
            string ipaddress = string.Empty;
            string ipcountry;
            string vodUrl;
            bool geoCheck = false;
            bool isParsed = bool.TryParse(ConfigurationManager.AppSettings["GeoCheck"], out geoCheck);

            //vodUrl = ConfigurationManager.AppSettings["VodUrl"];
            Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 0 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
            string notGeoCustomer = ConfigurationManager.AppSettings["NotGeoCustomer"];
            ArrayList notGeoCustomerList = new ArrayList();
            notGeoCustomerList.AddRange(notGeoCustomer.Split(new char[] { ',' }));
            //
            string geoCountries = ConfigurationManager.AppSettings["GeoCountries"];
            ArrayList geoCountriesList = new ArrayList();
            geoCountriesList.AddRange(geoCountries.Split(new char[] { ',' }));

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
                    _hosteventLog.WriteEntry("TVODPayAndGetVodTokenAuthXMLAndLngs.Exception: 4 imdb_id, cn, cntry: " + imdb_id + ", " + cn + ", error: " + ipcountry, System.Diagnostics.EventLogEntryType.Error);

                    vtlReturn.a = "";
                    vtlReturn.t = "4";
                    vtlReturn.authxml = "";

                    return vtlReturn;
                }
            }
            //

            string connstr_mobile_api_ws = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
            string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            DVdPostMobileApIWS contextMobileApiWs = new DVdPostMobileApIWS(new MySqlConnection(connstr_mobile_api_ws));
            DVdPostMobileApIWS contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));

            contextMobileApiWs.ObjectTrackingEnabled = false;
            contextMobileApiWs.QueryCacheEnabled = true;

            IEnumerable<VODChannel> vodch = contextMobileApiWs.ExecuteQuery<VODChannel>("CALL spmovie_vod_products({0},{1},{2},{3})", imdb_id, disk_id, season_id, Utilities.GetClientCoutry());
            Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 0.1 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString() + vodch.ToList()[0].a, device, contextMobileApiWs);

            if (vodch == null || vodch.Count() == 0)
            {
                vtlReturn.a = "";
                vtlReturn.t = "-7";
                vtlReturn.authxml = "";

                return vtlReturn;
            }


            string sqlISSVOD = QueriesDB.getIsSVOD(imdb_id);
            string sqlIsFreeMovie = QueriesDB.getIsFreeMovie(imdb_id);
            IEnumerable<numberresult> svodcount = contextBeProd.ExecuteQuery<numberresult>(sqlISSVOD, null);
            isSVOD = svodcount.First().r > 0;

            IEnumerable<numberresult> freemoviecount = contextBeProd.ExecuteQuery<numberresult>(sqlIsFreeMovie, null);
            isFreeMovie = freemoviecount.First().r > 0;

            isCurrentMovie = isAvailableAsCurrentMovie(contextBeProd, imdb_id, season_id, disk_id, cn);
            Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 1 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
            IEnumerable<CustomerDetailsRowExtended> cdr = contextMobileApiWs.ExecuteQuery<CustomerDetailsRowExtended>("CALL sp_customer_tvod_free_getbyid({0})", cn);
         
            if (cdr.Count() > 0)
            {
                cd = cdr.ToList()[0];
            }
            else
            {
                //return "1"; //no customer
                vtlReturn.a = "";
                vtlReturn.t = "1";
                vtlReturn.authxml = "";

                return vtlReturn;
            }
            //if (!isSVOD && cd.ogreg == 0 && !isFreeMovie && cd.sbst != 6 )
            //{
            //    //return "2"; //not ogone registerd
            //    vtlReturn.a = "";
            //    vtlReturn.t = "2";
            //    vtlReturn.authxml = "";

            //    return vtlReturn;
            //}
            if ((cd.isac == 0))
            {
                //return "3"; //not active
                vtlReturn.a = "";
                vtlReturn.t = "3";
                vtlReturn.authxml = "";

                return vtlReturn;
            }
            if (cd.susp > 0)
            {
                //return "6"; //suspended
                vtlReturn.a = "";
                vtlReturn.t = "6";
                vtlReturn.authxml = "";

                return vtlReturn;
            }
            if (cd.sbst == 6 && isSVOD && !isFreeMovie)
            {
                //return "7";
                vtlReturn.a = "";
                vtlReturn.t = "7";
                vtlReturn.authxml = "";

                return vtlReturn;
            }

            if (cd.tvod_free > 0 )
            {
                Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 2 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
                return getPrivate(imdb_id, disk_id, season_id, cn, device,0);
            }

            if (isCurrentMovie)
            {
                Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 3 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
                return getPrivate(imdb_id, disk_id, season_id, cn, device, 0);
            }

            //if ((cd.pmt.Equals("1")) && ((cd.ocno != null && cd.ocno != card_no) || (cd.octp != null && cd.octp != card_type) || (cd.oexp != null && cd.oexp != card_ed) || (cd.oown != null && cd.oown != card_owner)))
            //{
            //    string returnAlias = CreateOgoneAlias(card_type, card_owner, card_no, cvc, card_ed, cd.cn);
            //    int alias_created = int.Parse(returnAlias);
            //    if (alias_created < 0)
            //    {
            //        vtlReturn.a = "";
            //        vtlReturn.t = alias_created.ToString() ;
            //        vtlReturn.authxml = "";

            //        return vtlReturn;
            //    }
            //}
            //else 
            if (cd.pmt.Equals("0"))
            {
                Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 4 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString() + ", " + card_cvc, device);
                string returnAlias = CreateOgoneAlias(card_type, card_owner, card_no, card_cvc, card_ed, cd.cn);
                int alias_created = int.Parse(returnAlias);
                if (alias_created < 0)
                {
                    vtlReturn.a = "";
                    vtlReturn.t = alias_created.ToString();
                    vtlReturn.authxml = "";

                    return vtlReturn;
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
            Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 5 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString() + ", amount:" + amount, device);
            string returnOgonePayment = CreateOgonePayment(amount, "p" + cd.cn, card_cvc, int.Parse(cd.cn));
            Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 6", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
            int ogone_payment_created = int.Parse(returnOgonePayment);
            if (ogone_payment_created < 0)
            {
                vtlReturn.a = "";
                vtlReturn.t = ogone_payment_created.ToString();
                vtlReturn.authxml = "";
                Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 7 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
                return vtlReturn;
            }
            if (cd.pmt.Equals("0"))
            {
                Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 8 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
                string card_no_covered = CardNumberCover(card_no);
                string sqlCustomerOgone = QueriesDB.getUpdateCustomerOgone(cn, card_owner, card_no_covered, card_ed, card_type);
                int customerUpdated = contextBeProd.ExecuteCommand(sqlCustomerOgone, null);
            }
            Utilities.InsertMobileLog(cn, "TVODPayAndGetVodTokenAuthXMLAndLngs 9 ", imdb_id.ToString() + ", " + disk_id.ToString() + ", " + season_id.ToString(), device);
            return getPrivate(imdb_id, disk_id, season_id, cn, device, (cd.ogreg == 0 && cd.sbst != 6 ? 1 : 0));
        }

        private string CardNumberCover(string number)
        {
                string hiddenString = number.Substring(number.Length - 4).PadLeft(number.Length, 'X');
                return hiddenString;
        }

        private string CreateOgoneAlias(string brand, string customerName, string cardno, string cvc, string ed, string cn)
        {
            DVdPostMobileApIWS contextBeProd = null;
            VodTokenLengs returnVTL = new VodTokenLengs();

            Utilities.InsertMobileLog(int.Parse (cn), "CreateOgoneAlias 1", customerName + ", " + cardno, 8);

            string alias = "p" + cn;

            //string parameters = "?";
            string parametersToHashTmp = string.Empty;
            string shasign = string.Empty;
            string parameterToHash = string.Empty;

            string aliasGatewayURL = ConfigurationManager.AppSettings["AliasGatewayURL"];
            string acceptURL = ConfigurationManager.AppSettings["AcceptAliasURL"];
            string exceptionURL = ConfigurationManager.AppSettings["ExceptionAliasURL"];
            string PSPID = ConfigurationManager.AppSettings["ogone_pspidBE"];
            string passPhrase = ConfigurationManager.AppSettings["ogone_shainpasphrase"];
            string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            aliasorder order = null;

            contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));

            try
            {
                string sqlAliasInsert = QueriesDB.InsertOgoneAliasOrder(customerName, CardNumberCover(cardno), cvc, ed, alias, cn);
                IEnumerable<aliasorder> aliases = contextBeProd.ExecuteQuery<aliasorder>(sqlAliasInsert, null);

                order = aliases.FirstOrDefault();

                if (order == null)
                {                    
                    return "-2";
                }

            }
            catch (Exception ex)
            {
                return "-2";
            }

            //to hash
            parametersToHashTmp += "ACCEPTURL=" + acceptURL;
            parametersToHashTmp += "&ALIAS=" + alias;
            parametersToHashTmp += "&EXCEPTIONURL=" + exceptionURL;
            parametersToHashTmp += "&ORDERID=" + order.returned_number;
            parametersToHashTmp += "&PSPID="+PSPID+"&";
            parameterToHash = parametersToHashTmp.Replace("&", passPhrase);

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
                    data["PSPID"] = PSPID;
                    data["SHASIGN"] = shasign;
                    var response = wb.UploadValues(aliasGatewayURL, "POST", data);

                    Wait();

                    string sqlAliasStatus = QueriesDB.GetOgoneAliasOrderStatus(alias, order.returned_number.ToString());
                    IEnumerable<aliasorder> aliase_status = contextBeProd.ExecuteQuery<aliasorder>(sqlAliasStatus, null);

                    aliasorder order_status = aliase_status.FirstOrDefault();

                    if (order_status.returned_number == 1)
                    {
                        return "-4";
                    }                    
                    return order.returned_number.ToString();
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
                return "-3";
            }
        }

        private string CreateOgonePayment(string amount, string alias, string cvc,int customers_id)
        {
            DVdPostMobileApIWS contextBeProd = null;
            VodTokenLengs returnVTL = new VodTokenLengs();
            string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            string directLinkURL = ConfigurationManager.AppSettings["OrderURL"];
            string PSPID = ConfigurationManager.AppSettings["ogone_pspidBE"];
            string APIUSER = ConfigurationManager.AppSettings["ogone_apiuser"];
            string APIPSWD = ConfigurationManager.AppSettings["ogone_apiuserpswd"];
            string SHAINPASSPHRASE = ConfigurationManager.AppSettings["ogone_shainpasphrase"];
            string SHAOUTPASSPHRASE = ConfigurationManager.AppSettings["ogone_shaoutpasphrase"];
            string shasign = string.Empty;
            string parameterToHash = string.Empty;
            string parametersToHashOriginal = string.Empty;
            Utilities.InsertMobileLog(customers_id, "CreateOgonePayment 1", amount + ", " + alias, 8);
            string amountToPay = string.Empty;

            try
            {
                amountToPay = (decimal.Parse(amount.Replace('.', ',')) * 100).ToString("###");
            }
            catch (Exception e)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("CreateOgonePayment.Exception 0: brand, customerName, cardno, cvc, ed, orderid, alias, cn, parameterToHash, shasign: " + cvc + ", " + amount + ", " + alias + ", " + ", " + parameterToHash + ", " + shasign + ", error " + e.Message, System.Diagnostics.EventLogEntryType.Error);
                if (e.InnerException != null)
                {
                    _hosteventLog.WriteEntry("CreateOgonePayment InnerException 0: " + e.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                return "-5";
            }
            Utilities.InsertMobileLog(customers_id, "CreateOgonePayment 0.1", amount + ", " + amountToPay, 8);
            contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));

            int orderid;
            string sqlABO = string.Empty;
            string sqlOgonePayment = string.Empty;
            //insert abo
            try
            {
            sqlABO = QueriesDB.GetInsertHistoryAbo(customers_id, string.Empty, 6, "OGONE", 37);            
            IEnumerable<aliasorder> abo_idEnumerable = contextBeProd.ExecuteQuery<aliasorder>(sqlABO, null);
            Utilities.InsertMobileLog(customers_id, "CreateOgonePayment 0.2", "", 8);
            int abo_id = abo_idEnumerable.FirstOrDefault().returned_number;
            Utilities.InsertMobileLog(customers_id, "CreateOgonePayment 0.3", abo_id.ToString() , 8);
            //insert payment
            sqlOgonePayment = QueriesDB.CreateOgonePayment(abo_id, PlushData.ClsCustomersData.Payment_Method.OGONE, customers_id, amount);
            IEnumerable<aliasorder> orderidEnumerable = contextBeProd.ExecuteQuery<aliasorder>(sqlOgonePayment, null);
            orderid = orderidEnumerable.FirstOrDefault().returned_number;
            }
            catch (Exception ex)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("CreateOgonePayment.Exception 4: brand, customerName, cardno, cvc, ed, orderid, alias, cn, parameterToHash, shasign: " + cvc + ", "  + ", " + alias + ", " + ", " + parameterToHash + ", " + shasign + ", " + sqlABO + ", "  + sqlOgonePayment + " , error " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("CreateOgonePayment InnerException 4: " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                return "-5";
            }

            //parameters to hash

            parametersToHashOriginal += "ALIAS=" + alias;
            parametersToHashOriginal += "&ALIASUSAGE=pmtorder";
            parametersToHashOriginal += "&AMOUNT=" + amountToPay ;
            parametersToHashOriginal += "&CURRENCY=EUR";
            parametersToHashOriginal += "&CVC=" + cvc;
            //parametersToHashOriginal += "&OPERATION=RES";
            parametersToHashOriginal += "&ORDERID=" + orderid;

            parametersToHashOriginal += "&PSPID=" + PSPID + "&PSWD=" + APIPSWD + "&USERID=" + APIUSER + "&";

            parameterToHash = parametersToHashOriginal.Replace("&", SHAINPASSPHRASE);

            string s = GenerateHash(Encoding.UTF8.GetBytes(parameterToHash));
            shasign = s.ToUpper();

            //parameters
            try
            {
                using (var wb = new WebClient())
                {
                    Utilities.InsertMobileLog(customers_id, "CreateOgonePayment 2 ", amountToPay + ", " + orderid + ", " + alias, 8);
                    var data = new NameValueCollection();
                    data["ALIAS"] = alias;
                    data["ALIASUSAGE"] = "pmtorder";
                    data["AMOUNT"] = amountToPay ;
                    data["CURRENCY"] = "EUR";
                    data["CVC"] = cvc;
                    //data["OPERATION"] = "RES";
                    data["ORDERID"] = orderid.ToString() ;
                    data["PSPID"] = PSPID;
                    data["PSWD"] = APIPSWD;
                    data["SHASIGN"] = shasign;
                    data["USERID"] = APIUSER;

                    byte[] response = wb.UploadValues(directLinkURL, "POST", data);

                    string str = System.Text.Encoding.UTF8.GetString(response);

                    string sqlResponseXML = QueriesDB.getInsertPaymentOgoneWS(orderid, str);
                    int responseTMP = contextBeProd.ExecuteCommand(sqlResponseXML, null);

                    StringReader rdr = new StringReader(str);
                    XDocument xd = XDocument.Load(rdr);

                    Utilities.InsertMobileLog(customers_id, "CreateOgonePayment 3 ", xd.ToString(), 8);                    

                    if (xd.Root.Attribute("STATUS").Value.Equals("9") && xd.Root.Attribute("orderID").Value.Equals(orderid.ToString() ))
                    {
                        string sqlUpadatePaymentStatus = QueriesDB.getUpadatePaymentStatus(orderid,  2);
                        int payment_result = contextBeProd.ExecuteCommand(sqlUpadatePaymentStatus, null);

                        return orderid.ToString() ;
                    }
                    else
                    {
                        string sqlUpadatePaymentStatus = QueriesDB.getUpadatePaymentStatus(orderid, 3);
                        int payment_result = contextBeProd.ExecuteCommand(sqlUpadatePaymentStatus, null);
                        return "-1";
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
                return "-5";
            }
        }

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

        private string AkamaiTokenCreate(string AkamaiTokenDurationInSeconds, string AkamaiTokenKey)
        {

            //CREATE TOKEN
            AkamaiTokenConfig conf = new AkamaiTokenConfig();
            conf.TokenAlgorithm = Algorithm.HMACSHA256;
            conf.Window = long.Parse(AkamaiTokenDurationInSeconds);
            conf.Acl = "/ondemand/*";
            conf.Key = AkamaiTokenKey;
            return AkamaiTokenGenerator.GenerateToken(conf);
        }

        private string AuthXMLCreate(string ipAddress)
        {
            try
            {
                //AuthXML
                AuthXMLGenerator authXmlGenerator = new AuthXMLGenerator();
                string AuthXMLKeyPath = ConfigurationManager.AppSettings["AuthXMLKeyPath"];
                string AuthXMLExpirationTimeInMinutes = ConfigurationManager.AppSettings["AuthXMLExpirationTimeInMinutes"];
                string AuthXMLExpirationAfterFirstPlayInSeconds = ConfigurationManager.AppSettings["AuthXMLExpirationAfterFirstPlayInSeconds"];
                string AuthXMLMinimumSecurityLevel = ConfigurationManager.AppSettings["AuthXMLMinimumSecurityLevel"];

                authXmlGenerator.PrivateKey = AuthXMLKeyPath; // @"D:\Akamai\KeyOS SmoothDRM Deployment KIT\KeyOS RSA Certificate Generator (Keys for PHP and .NET)\4c592c554b7008d5385a5e0e076bcf45.pvk"; // @"C:\drm\PLEASE PUT YOUR KEY NAME HERE.pvk";

                // Optional. IP
                //
                // By setting the IP, you ask the system to check whether the IP license was requested
                // from, and IP in the AuthXML are the same. If they are not, license won't be issued.
                //
                //authXmlGenerator.IP = "127.0.0.1";


                // Optional. KeyID(s)
                //
                // By setting the KeyID, you ask the system to check whether file,
                // license is generated for, has the same KeyID as the one passed in
                // authentication XML. If KeyIDs are different, license won't be issued.
                //
                //authXmlGenerator.KeyIDList.Add("MHkeGJ1WYkqXlPjzcAJlIw==");
                //
                // KeyID can also be specified in GUID format. It will be encoded into Base64 automatically.
                //authXmlGenerator.KeyIDList.Add(new Guid("181e7930-569d-4a62-9794-f8f370026523"));
                //
                // Set different KeyIDs. Might be used if player has a playlist with different encrypted files in it.
                //authXmlGenerator.KeyIDList.Add("MHkeGJ1WYkqXlPjzcAJlIw==")
                //    .Add(new Guid("1acb4010-42e5-d913-b1e8-3580641c03c9"));
                //
                // Example of how to add list of KeyIDs (String)
                //authXmlGenerator.KeyIDList.Add(new List<String>() {
                //    "MHkeGJ1WYkqXlPjzcAJlIw==", "EEDLGuVCE9mx6DWAZBwDyQ==" });
                //
                // List of GUIDs
                //authXmlGenerator.KeyIDList.Add(new List<Guid>() {
                //    new Guid("181e7930-569d-4a62-9794-f8f370026523"), new Guid("1acb4010-42e5-d913-b1e8-3580641c03c9") });


                // Optional. ExternalId. It can't be longer than 40 symbols.
                //authXmlGenerator.ExternalId = "My External ID";


                // AuthXMLExpirationTime. Sets the date and time when authentication XML itself expires.
                //
                // NOTE: Property ExpirationTime was deprecated and replaced with AuthXMLExpirationTime.
                //
                authXmlGenerator.AuthXMLExpirationTime = DateTime.UtcNow.AddMinutes(double.Parse(AuthXMLExpirationTimeInMinutes));


                // Setting license policies

                // Optional. Defines whether license is persistent or not.
                //
                // Asking for a persistent license w/o policies. Persistent license means that license
                // will be stored in a local DRM storage on customer's PC and will be used to unlock
                // the file once it will be opened using KeyOS Player. Non-persistent license means that
                // license will be acquired each time user will open DRM protected file.
                //
                authXmlGenerator.IsPersistent = true;

                // Optional. Policy. BeginDate
                //
                // Property specifies the date in UTC till which the license is not valid.
                // This property is useful for license pre-delivery for future events.
                //
                //authXmlGenerator.BeginDate = DateTime.UtcNow.AddMinutes(5);

                // Optional. Policy. ExpirationDate
                //
                // Date and time when license expires.
                //authXmlGenerator.ExpirationDate = DateTime.UtcNow.AddMinutes(10);

                // Optional. Policy. ExpirationAfterFirstPlay
                //
                // Defines how much longer (in seconds) license will be valid
                // after it was first used to open the content.
                //
                authXmlGenerator.ExpirationAfterFirstPlay = uint.Parse(AuthXMLExpirationAfterFirstPlayInSeconds);


                // Optional. MinimumSecurityLevel (for devices only)
                //
                // Requires license with MinimumSecurityLevel set to 2000,
                // which can be consumed by only devices with production level certificates on them.
                // 2000 is default on the KeyOS license server.
                //
                //authXmlGenerator.MinimumSecurityLevel = 2000;
                //
                // Requires license with MinimumSecurityLevel set to 150,
                // which is meant for devices with test level certificates
                // for testing purposes only.
                //
                authXmlGenerator.MinimumSecurityLevel = 150;// uint.Parse(AuthXMLMinimumSecurityLevel);


                // Optional. Play Rights.
                PlayRight pr = new PlayRight();

                // Optional. Output Protection Levels
                //
                // Valid values: 100, 150, 200, 250, 300
                //pr.OPL.Set(OutputProtectionLevels.CompressedDigitalAudio, 100);
                //
                // Valid values: 100, 150, 200, 250, 300
                //pr.OPL.Set(OutputProtectionLevels.UncompressedDigitalAudio, 100);
                //
                // Valid values: 400, 500
                //pr.OPL.Set(OutputProtectionLevels.CompressedDigitalVideo, 400);
                //
                // Valid values: 100, 250, 270, 300
                //pr.OPL.Set(OutputProtectionLevels.UncompressedDigitalVideo, 100);
                //
                // Valid values: 100, 150, 200
                //pr.OPL.Set(OutputProtectionLevels.AnalogVideo, 100);
                //
                // More usage examples
                //pr.OPL.Set(OutputProtectionLevels.AnalogVideo, 200).Set(OutputProtectionLevels.CompressedDigitalVideo, 500);
                //
                //pr.OPL.Set(new Dictionary<String, Int32>() {
                //    { OutputProtectionLevels.UncompressedDigitalAudio, 300 },
                //    { OutputProtectionLevels.UncompressedDigitalVideo, 270 } });

                // Optional. AnalogVideoExplicit
                //
                // Allowed values:
                //   C3FD11C6-F8B7-4D20-B008-1DB17D61F2DA: 0, 1, 2, 3
                //   2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3: 0, 1, 2, 3
                //   811C5110-46C8-4C6E-8163-C0482A15D47E: 520000
                //   D783A191-E083-4BAF-B2DA-E69F910B3772: 520000
                //
                // Add Id (GUID) with ConfigData
                //pr.AnalogVideoExplicitList.Add(new Guid("C3FD11C6-F8B7-4D20-B008-1DB17D61F2DA"), 0);
                //pr.AnalogVideoExplicitList.Add(new Guid("C3FD11C6-F8B7-4D20-B008-1DB17D61F2DA"), 0).Add(new Guid("2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3"), 0);
                //
                // Add one Id (GUID) with ConfigData's list
                //pr.AnalogVideoExplicitList.Add(
                //    new Guid("C3FD11C6-F8B7-4D20-B008-1DB17D61F2DA"), new List<Int32>() { 1, 2, 3 });
                //
                // Add multiple GUIDs (each with one ConfigData)
                //pr.AnalogVideoExplicitList.Add(new AnalogVideoExplicit.List() {
                //    new AnalogVideoExplicit.Item(new Guid("2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3"), 3),
                //    new AnalogVideoExplicit.Item(new Guid("811C5110-46C8-4C6E-8163-C0482A15D47E"), 520000)
                //});
                //
                // It shows how to add all at once
                //pr.AnalogVideoExplicitList.Add(new Dictionary<Guid, List<Int32>>() {
                //    { new Guid("C3FD11C6-F8B7-4D20-B008-1DB17D61F2DA"), new List<Int32> { 0, 1, 2, 3 } },
                //    { new Guid("2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3"), new List<Int32> { 0, 1, 2, 3 } },
                //    { new Guid("811C5110-46C8-4C6E-8163-C0482A15D47E"), new List<Int32> { 520000 } },
                //    { new Guid("D783A191-E083-4BAF-B2DA-E69F910B3772"), new List<Int32> { 520000 } } });

                // Optional. DigitalAudioExplicit
                //
                // Values can be add by exactly same ways as for AnalogVedioExplicit above.
                // Allowed values: "6D5CFA59-C250-4426-930E-FAC72C8FCFA6: "00", "01", "10", "11".
                //
                //pr.DigitalAudioExplicitList.Add(new Guid("6D5CFA59-C250-4426-930E-FAC72C8FCFA6"), "00");
                //pr.DigitalAudioExplicitList.Add(new Guid("6D5CFA59-C250-4426-930E-FAC72C8FCFA6"), new List<String> { "01", "10", "11" });


                // Optional. Play Enablers
                //
                // 786627D8-C2A6-44BE-8F88-08AE255B01A7
                // The PlayReady Final Product may Pass the video portion of uncompressed decrypted A/V Content to an Unknown Output only if (i) the associated PlayReady License does not contain a Play Enabler Type Object with a Play Enabler Type field value of {B621D91F-EDCC-4035-8D4B-DC71760D43E9}, and (ii) the PlayReady Final Product has attempted to determine the output type using all commercially reasonable technical mechanisms and failed to determine the output type.
                pr.PlayEnablerList.Add(new Guid("786627D8-C2A6-44BE-8F88-08AE255B01A7"));
                //
                // B621D91F-EDCC-4035-8D4B-DC71760D43E9
                // The PlayReady Final Product may Pass the video portion of uncompressed decrypted A/V Content to an Unknown Output only if (i) the Effective Resolution of the video portion of uncompressed decrypted PlayReady content is less than or equal to 520,000 pixels per frame, and (ii) the PlayReady Final Product has attempted to determine the output type using all commercially reasonable technical mechanisms and failed to determine the output type.
                //pr.PlayEnablerList.Add(new Guid("B621D91F-EDCC-4035-8D4B-DC71760D43E9"));
                //
                // D685030B-0F4F-43A6-BBAD-356F1EA0049A
                // The PlayReady Final Product may Export decrypted PlayReady A/V Content to Digital Transmission Content Protection (DTCP).
                //pr.PlayEnablerList.Add(new Guid("D685030B-0F4F-43A6-BBAD-356F1EA0049A"));
                //
                // 002F9772-38A0-43E5-9F79-0F6361DCC62A
                // The PlayReady Final Product may Export decrypted PlayReady A/V Content to Helix.
                //pr.PlayEnablerList.Add(new Guid("002F9772-38A0-43E5-9F79-0F6361DCC62A"));
                //
                // A340C256-0941-4D4C-AD1D-0B6735C0CB24  (Miracast)
                // A PlayReady Final Product may Export decrypted compressed PlayReady A/V Content to a licensed implementation of HDCP 2.0 or newer if the associated PlayReady License contains a Play Enabler Type Object with a Play Enabler Type field value of {A340C256-0941-4D4C-AD1D-0B6735C0CB24} and the Export occurs over Miracast.
                //pr.PlayEnablerList.Add(new Guid("A340C256-0941-4D4C-AD1D-0B6735C0CB24"));
                //
                // 1B4542E3-B5CF-4C99-B3BA-829AF46C92F8  (WiVu)
                // A PlayReady Final Product may Export decrypted compressed PlayReady A/V Content to a licensed implementation of HDCP 2.0 or newer if the associated PlayReady License contains a Play Enabler Type Object with a Play Enabler Type field value of {1B4542E3-B5CF-4C99-B3BA-829AF46C92F8} and the Export occurs over WiVu.
                //pr.PlayEnablerList.Add(new Guid("1B4542E3-B5CF-4C99-B3BA-829AF46C92F8"));
                //
                // 5ABF0F0D-DC29-4B82-9982-FD8E57525BFC (AirPlay)
                // A PlayReady Final Product may Export decrypted compressed PlayReady A/V Content to a licensed implementation of AirPlay if the associated PlayReady License contains a Play Enabler Type Object with a Play Enabler Type field value of {5ABF0F0D-DC29-4B82-9982-FD8E57525BFC }.
                //pr.PlayEnablerList.Add(new Guid("5ABF0F0D-DC29-4B82-9982-FD8E57525BFC"));
                //
                // Add list of PlayEnabler's IDs (GUIDs).
                //pr.PlayEnablerList.Add(new Guid("786627D8-C2A6-44BE-8F88-08AE255B01A7")).Add(new Guid("D685030B-0F4F-43A6-BBAD-356F1EA0049A"));
                //
                //pr.PlayEnablerList.Add(new List<Guid>() {
                //    new Guid("786627D8-C2A6-44BE-8F88-08AE255B01A7"),
                //    //new Guid("B621D91F-EDCC-4035-8D4B-DC71760D43E9"),
                //    new Guid("D685030B-0F4F-43A6-BBAD-356F1EA0049A"),
                //    new Guid("002F9772-38A0-43E5-9F79-0F6361DCC62A")
                //});

                authXmlGenerator.PlayRight = pr;


                // Optional. Custom attributes.
                //
                // May be useful if implementation of license issuing process
                // requires some extra fields in Authentication XML.
                //
                //authXmlGenerator.CustomNodes.Add("SomeCustomField1", "SomeCustomValue1");


                // Generate, sign and Base64-encode authentication XML
                string EncodedAuthXml = authXmlGenerator.EncodeAuthenticationXML(authXmlGenerator.SignAuthenticationXML(authXmlGenerator.GenerateAuthenticationXML()));
                return EncodedAuthXml;
            }
            catch (Exception ex)
            {
                this._hosteventLog = new System.Diagnostics.EventLog();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this._hosteventLog)).EndInit();
                _hosteventLog.Source = "PlushHTTPSServiceSource";
                _hosteventLog.Log = "PlushHTTPSServiceLog";
                _hosteventLog.WriteEntry("AuthXMLCreate.Exception: 2 ip: " + ipAddress + " error: " + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                if (ex.InnerException != null)
                {
                    _hosteventLog.WriteEntry("AuthXMLCreate InnerException: 2 " + ex.InnerException.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                return "0.3";
            }
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

