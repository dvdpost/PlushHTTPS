using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PlushService
{
    public static class QueriesDB
    {
        //private static string dbName = ConfigurationManager.ConnectionStrings["prodDBName"].ConnectionString;
        public static string getVodStreamingInfo(int id)
        {
            string sql = string.Format("SELECT imdb_id, filename, ppv_price FROM streaming_products WHERE id = {0} ", id);

            return sql;
        }
        public static string getIsSOVD(int imdb_id)
        {
            string sql = "select count(*) r from svod_dates where imdb_id = " + imdb_id + " and now() between start_on and end_on ";

                return sql;
        }

        public static string getToken(int imdb_id, int customers_id)
        {
            string tokenDays = ConfigurationManager.AppSettings["TokenLastedInDays"];
            string sql = "select token from tokens where customer_id = " + customers_id + " and imdb_id = " + imdb_id + " and created_at > DATE_ADD(sysdate(), INTERVAL - " + tokenDays + " DAY) ";

            return sql;
        }

        public static string getVOD_CREATE_TOKEN()
        {
            return "select CodeValue as r from generalglobalcode where codetype ='VOD_CREATE_TOKEN'";
        }

        public static string getVOD_ONLINE()
        {
            return "select CodeValue as r from generalglobalcode where codetype ='VOD_ONLINE'";
        }

        public static string getInsertToken(int cn, string token, int imdb_id)
        {
            string sql = string.Format("INSERT INTO tokens (token,created_at,updated_at,customer_id,code,imdb_id,count_ip, is_ppv, ppv_price) VALUES ('{0}', sysdate(), sysdate(), {1}, NULL, {2},2, 0, null) ", token,cn, imdb_id);
            
            return sql;
        }

        public static string getDecreaseCredit(int cn, int decrease)
        {
            string sql = string.Format("UPDATE customers set customers_abo_dvd_credit = customers_abo_dvd_credit - " + decrease + " WHERE customers_id = {0} ",  cn);

            return sql;
        }

         public static string GetLastCreditHistory(int customers_id )
         {
            string sql = "select * from credit_history where customers_id = " + customers_id + " order by id desc limit 1";
            return sql;

         }

        public static string GetOrdersIdCreditHistory(int customers_id , int orders_id )
        {
            string sql = "select credit, quantity_free, quantity_paid, credit_free, credit_paid from credit_history where customers_id = " + customers_id + "  and orders_id = " + orders_id + " order by id desc limit 1 ";
            return sql;
        }

        public static string GetInsertCreditHistory(int credit_free , int customers_id, int? abo_type,int credit )
        {
            string sql;
       
            sql = "insert into credit_history (customers_id , credit_action_id , user_modified,credit_paid , quantity_paid ,  quantity_free , credit_free , orders_id,abo_type )" +
                  " values (" + customers_id + " , " + 12 + " ,  77 , 0, 0, -1, " + credit_free +", null, " + abo_type +" ) ";

            return sql;
        }
        public static string GetProductFromVod(int vodid)
        {
            string sql;

            sql = "SELECT p.products_id FROM streaming_products s JOIN products p on s.imdb_id = p.imdb_id WHERE s.id = " + vodid + " order by p.products_last_modified desc limit 1";

            return sql;
        }

        public static string GetInsertWishList(int prid, int prty, int cn, int wlsrcid)
        {
            string sql = string.Format(" insert into wishlist (customers_id, product_id, rank, priority, date_added, wishlist_type, wishlist_master_id, already_rented, theme_event_id, wishlist_source_id) " +
                                                     " VALUES ({0}, {1}, 0, {2}, sysdate(), 'DVD_NORM', 1, 'NO', 0, {3}) ", cn, prid, prty, wlsrcid);            

            return sql;
        }

        public static string GetProductWishlistExists(int prid, int cn)
        {
            string sql = string.Format("select count(*) as r from wishlist w where w.product_id = {0} and w.customers_id = {1}",prid,cn);
            return sql;
        }

        public static string GetDeleteWishlist(int pdid, int cn)
        {
            string sql = string.Format(" delete from wishlist where customers_id = {0} and product_id = {1} ", cn, pdid);

            return sql;
        }

        public static string GetDeleteVodWishlist(int imdb_id, int cn)
        {
            string sql = string.Format(" delete from vod_wishlists where customer_id = {0} and imdb_id = {1} ", cn, imdb_id);

            return sql;
        }

        public static string GetSetWishlistPriority(int pdid, int cn, int prty)
        {
            string sql = string.Format(" update wishlist set priority = {0} where customers_id = {1}  and product_id = {2} ", prty, cn,  pdid);

            return sql;
        }

        public static string GetUpdateVodOnly(int cn, int ovod)
        {
            string sql = string.Format(" update customer_attributes set only_vod = {0} where customer_id = {1} ", ovod, cn);

            return sql;
        }

        public static string GetInsertMovieSeen(int imdb_id_serie, int disk_id, int season_id, int cn)
        {
            string sql = string.Format(" insert into products_seen  select p.products_id, {0}, sysdate() from products p left join plush_staging.series s on p.products_series_id = s.series_id " +
                " where  p.imdb_id = {1} and p.products_series_number = {2} and s.parent_id = {3} ", cn, imdb_id_serie, disk_id, season_id) ;

            return sql;
        }

        public static string GetInsertMovieUninterested(int imdb_id_serie, int disk_id, int season_id, int cn)
        {
            string sql = string.Format(" insert into products_uninterested (products_id,date,customers_id)  select p.products_id, sysdate(), {0} from products p left join plush_staging.series s on p.products_series_id = s.series_id " +
                " where  p.imdb_id = {1} and p.products_series_number = {2} and ( s.parent_id = {3} or s.parent_id is null) ", cn, imdb_id_serie, disk_id, season_id);

            return sql;
        }

        public static string GetInsertMovieRate(int imdb_id_serie, int disk_id, int season_id, int cn, int rate)
        {
            string sql = string.Format(" insert into products_rating (products_id, products_rating, products_rating_date,customers_id, rating_type, imdb_id, criteo_status)  select p.products_id, {4}, sysdate(), {0}, 'IPHONE', p.imdb_id, 0 from products p left join plush_staging.series s on p.products_series_id = s.series_id " +
                " where  p.imdb_id = {1} and p.products_series_number = {2} and ( s.parent_id = {3} or s.parent_id is null) ", cn, imdb_id_serie, disk_id, season_id, rate);

            return sql;
        }

        public static string GetMovieRateExists(int imdb_id_serie, int disk_id, int season_id, int cn)
        {
            string sql = string.Format(" select count(*) as r from products p left join plush_staging.series s on p.products_series_id = s.series_id " +
                " join products_rating w on p.products_id = w.products_id where  p.imdb_id_serie = {0} and p.products_series_number = {1} and ( s.parent_id = {2} or s.parent_id is null) " +
                " and w.customers_id = {3} ", imdb_id_serie, disk_id, season_id, cn);
            return sql;
        }

        public static string getCodeListCountries()
        {
            string sql = string.Format(" select countries_id as id, countries_name as cntry from products_countries");

            return sql;
        }

        public static string getCodeListLanguage(int lngid)
        {
            string sql = string.Format(" SELECT languages_id as id, languages_description as lng, short as lngshort, short_alpha as shortalpha  FROM products_languages where languagenav_id = {0}", lngid);

            return sql;
        }

        public static string getCodeListTitles(int lngid)
        {
            string sql = string.Format(" SELECT undertitles_id as id, undertitles_description as lng, short as lngshort, short_alpha as shortalpha  FROM products_undertitles where language_id = {0}", lngid);

            return sql;
        }

        public static string getVodToWishList(int imdb_id_serie, int disk_id, int season_id, int cn)
        {
            string sql = string.Format(" insert into vod_wishlists (customer_id, imdb_id, created_at, updated_at) values( {0}, (select imdb_id from products p left join series s on p.products_series_id = s.series_id where p.imdb_id_serie = {1} and p.products_series_number = {2} and( {3} = 0 or s.parent_id ={3} ) limit 1 ), sysdate(), sysdate())", cn, imdb_id_serie, disk_id, season_id);

            return sql;
        }

        public static string getVodWishListExists(int imdb_id, int disk_id, int season_id, int cn)
        {
            string sql = string.Format(" select count(*) from vod_wishlists vw join tokens t on vw.customers_id = t.customers_id and vw.imdb_id = t.imdb_id " +
                " where vw.customer_id = {0} and vw.imdb_id = (select imdb_id from products p left join series s on p.products_series_id = s.series_id where p.imdb_id = {1} " +
                " and p.products_series_number = {2} and( {3} = 0 or s.parent_id ={3} ) limit 1 )", cn, imdb_id, disk_id, season_id);

            return sql;
        }

        public static string getInsertMobileLog(int cn, string method, string parameters, int device)
        {
            string dt = DateTime.Now.ToString("dd-MM-yyyy") + " " + DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes.ToString("D2") + ":" + DateTime.Now.TimeOfDay.Seconds.ToString("D2") + ":" + DateTime.Now.TimeOfDay.Milliseconds.ToString("D3");
            string sql = string.Format("insert into mobile_log (customers_id, method, parameters, device, created, created_system) VALUES ({0}, '{1}', '{2}', {3}, '{4}', sysdate() )", cn, method, parameters, device, dt);

            return sql;
        }

        public static string getSelectMaxIDCreditHistory(int cn)
        {
            
            string sql = string.Format("select max(id) r from credit_history where customers_id = {0} ", cn);

            return sql;
        }


        public static string getInsertMobileApplicationLog(int cn, string method, string parameters, string message, int device)
        {
            string dt = DateTime.Now.ToString("dd-MM-yyyy") + " " + DateTime.Now.TimeOfDay.Hours + ":" + DateTime.Now.TimeOfDay.Minutes.ToString("D2") + ":" + DateTime.Now.TimeOfDay.Seconds.ToString("D2") + ":" + DateTime.Now.TimeOfDay.Milliseconds.ToString("D3");
            string sql = string.Format("insert into mobile_application_log (customers_id, method, parameters, message, device, created) VALUES ({0}, '{1}', '{2}', '{3}', {4}, '{5}')", cn, method, parameters, message, device, dt);

            return sql;
        }

        public static string GetCreditForVod(int imdb_id_serie, int disk_id, int season_id)
        {            
            string sql;

            sql = string.Format("SELECT s.credits as r FROM streaming_products s JOIN products p on s.imdb_id = p.imdb_id " +
                " left join series sr on p.products_series_id = sr.series_id WHERE p.imdb_id_serie = {0} and (0 = {1} or products_series_number = {1}) and (0 = {2} or sr.parent_id = {2} )", imdb_id_serie, disk_id, season_id);

            return sql;
        }
        public static string GetVodCount()
        {
            return "select count(distinct imdb_id) r from streaming_products where source = 'alphanetworks' and status = 'online_test_ok'";
        }

        public static string GetDVDCount()
        {
            return "select count( distinct products_id) r from products where products_type = 'dvd_norm' and products_status = 1 ";
        }
    }
}
