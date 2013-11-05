using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Data;
using System.ServiceModel;
using System.Data.Entity;
using System.Configuration;
using MySql;
using MySql.Data.MySqlClient;
using MySql.Data;
using DbLinq.Factory;
using System.Collections;
using CountryLookupProj;

namespace PlushService
{
    public enum ActionId
    {
        ABOPROCESS = 1,
        PROCESSIN = 2,
        DELETEORDER = 3,
        FREERECONDUCTION = 4,
        RECONDUCTION = 5,
        FREEUPGRADE = 6,
        INIT = 7,
        MANUAL_CREDIT = 8,
        PROMO_COMBINED = 9,
        KDO = 10,
        MANUAL_ASSIGN = 11,
        VOD = 12,
        VOD_MORE_IP = 13,
        LONGTIME_DVD = 14
    }

    public class numberresult
    {
       public int r;
    }    

    class Utilities
    {

        public static bool wrongPass(string passClient,string passServer)
        {
            return !BCrypt.CheckPassword(passClient, passServer);
                //code = GenerateCode()
                //'sql = PlushData.ClsCustomersData.GetUpdatePassWord(_CurrentCustomerID, PlushBuziness.ClsCustomers.MD5Encrypt(code))
                //'sql = PlushData.ClsCustomersData.GetUpdatePassWord(_CurrentCustomerID, HashPassword(code, GenerateSalt()))

            //if (passServer.Contains(':'))
            //{
            //    string[] passwithsalt = passServer.Split(':');


            //    passClient = passwithsalt[1] + passClient;
            //    return MD5Encrypt(passClient) != passwithsalt[0];
            //}
            //else
            //{
            //    return MD5Encrypt(passClient) != passServer;
            //}

        }
        public static string MD5Encrypt(string str)
        {

            System.Security.Cryptography.MD5CryptoServiceProvider md5;
            Byte[] bytValue;
            Byte[] bytHash;
            string strOutput = string.Empty;
            int i;


            md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            bytValue = System.Text.Encoding.UTF8.GetBytes(str);


            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();

            for (i = 0; i < bytHash.Length; i++)
            {
                strOutput += bytHash[i].ToString("x").PadLeft(2, '0');
            }

            return strOutput;
        }

        public static string GetInsertCreditHistory(int customerRemainingCredit, int customers_id, int? abo_type, int quantity) 
        {               
            int? credit_free ;
            int? quantity_free=0 ;
            int? credit_paid=0 ;
            int? quantity_paid=0 ;
            DVdPostMobileApIWS contextBeProd = null;

            
            string connstr_prod = ConfigurationManager.ConnectionStrings["prod-WRITE"].ConnectionString;
            InsertMobileApplicationLog(customers_id, "GetInsertCreditHistory customerRemainingCredit, quantity 1: " + connstr_prod, customerRemainingCredit.ToString() + quantity.ToString(), "", -1);  
            contextBeProd = new DVdPostMobileApIWS(new MySqlConnection(connstr_prod));

            string sqlmax = QueriesDB.getSelectMaxIDCreditHistory(customers_id);
            IEnumerable<numberresult> res = contextBeProd.ExecuteQuery<numberresult>(sqlmax);
            numberresult max = res.FirstOrDefault<numberresult>();
            int maxID = max.r;

            var x = from creditHistory in contextBeProd.CreditHistory
                    where creditHistory.ID == maxID                    
                    select creditHistory;
            CreditHistory ch = x.SingleOrDefault();               
            
            if (ch == null) 
            {
                credit_free = 0;
                credit_paid  = 0;
            }
            else
            {
                credit_free = ch.CreditFree + ch.QuantityFree ;
                credit_paid = ch.CreditPaid  + ch.QuantityPaid ;                
            }

            InsertMobileApplicationLog(customers_id, "GetInsertCreditHistory credit_free, credit_paid, ch.ID, ch.CreditPaid, ch.QuantityPaid, ch.CreditFree, ch.QuantityFree, 2: ", credit_free.ToString() + ", " + credit_paid.ToString() + ", " + ch.ID.ToString() + ", " + ch.CreditPaid.ToString() + ", " + ch.QuantityPaid.ToString() + ", " + ch.CreditFree.ToString() + ", " + ch.QuantityFree.ToString(), "", -1);  

            if (credit_free >= quantity)
            {
                 quantity_free = quantity ;
                 quantity_paid = 0;
            }
            else if (credit_free + customerRemainingCredit >= quantity)
            {
                 quantity_paid = quantity - credit_free ;
                 quantity_free = credit_free ;
            }
            else if (customerRemainingCredit >= quantity)
            {
             quantity_free = 0;
             quantity_paid = quantity;
            }

           string  sql = string.Format ("insert into credit_history (customers_id , credit_action_id , user_modified,credit_paid , quantity_paid ,  quantity_free , credit_free , orders_id,abo_type )" +
                  " values ({0}, 12, 77, {1}, {2}, {3}, {4}, null, {5} )", customers_id, credit_paid, (-1) * quantity_paid, (-1) * quantity_free, credit_free, abo_type);
           
            return sql;
    }
        
        public class Token
        {
            public string token { get; set; }
        }
        //public class CreditHistory
        //{
        //    public int credit  { get; set; }
        //    public int quantity_free  { get; set; }
        //    public int quantity_paid  { get; set; }
        //    public int credit_free  { get; set; }
        //    public int credit_paid { get; set; }
        //}

        public static void InsertMobileLog(int cn, string method, string parameters, int device, DVdPostMobileApIWS context)
        {
            try
            {
                string sql = QueriesDB.getInsertMobileLog(cn, method, parameters, device);
                context.ExecuteCommand(sql);
            }
            catch
            {
            }
        }

        public static void InsertMobileLog(int cn, string method, string parameters, int device)
        {
            try
            {
                string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
                DVdPostMobileApIWS modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
                string sql = QueriesDB.getInsertMobileLog(cn, method, parameters, device);
                modelcontext.ExecuteCommand(sql);
            }
            catch
            {
            }
        }

        public static int InsertMobileApplicationLog(int cn, string method, string parameters, string error_message, int device)
        {
            try
            {
                string connstr = ConfigurationManager.ConnectionStrings["mobileapiws"].ConnectionString;
                DVdPostMobileApIWS modelcontext = new DVdPostMobileApIWS(new MySqlConnection(connstr));
                string sql = QueriesDB.getInsertMobileApplicationLog(cn, method, parameters, error_message, device);
                modelcontext.ExecuteCommand(sql);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static bool IsVodEnabledForThisIP(string ip)
        {
            bool geoCheck = false;
            bool isParsed = bool.TryParse(ConfigurationManager.AppSettings["GeoCheck"], out geoCheck);
            
            string notGeoCustomer = ConfigurationManager.AppSettings["NotGeoCustomer"];
            ArrayList notGeoCustomerList = new ArrayList();
            notGeoCustomerList.AddRange(notGeoCustomer.Split(new char[] { ',' }));
            //
            string geoCountries = ConfigurationManager.AppSettings["GeoCountries"];
            ArrayList geoCountriesList = new ArrayList();
            geoCountriesList.AddRange(geoCountries.Split(new char[] { ',' }));
            //
            string filePath = ConfigurationManager.AppSettings["countryFilePath"];

            CountryLookup cl = new CountryLookup(filePath);
            string ooutput = cl.lookupCountryCode(ip);

            if (!geoCountries.Contains(ooutput))
                return false;
            else
                return true;
        }

        public static string GetClientCoutry()
        {
            OperationContext context = OperationContext.Current;
            System.ServiceModel.Channels.MessageProperties prop = context.IncomingMessageProperties;
            System.ServiceModel.Channels.RemoteEndpointMessageProperty endpoint =
            prop[System.ServiceModel.Channels.RemoteEndpointMessageProperty.Name] as System.ServiceModel.Channels.RemoteEndpointMessageProperty;
            string ip = endpoint.Address;

            string filePath = ConfigurationManager.AppSettings["countryFilePath"];

            CountryLookup cl = new CountryLookup(filePath);
            return  cl.lookupCountryCode(ip);            
        }
     
    }
 
}
