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
        public static string getIsSVOD(int imdb_id)
        {
            string sql = "select count(*) r from svod_dates where imdb_id = " + imdb_id + " and now() between start_on and end_on ";

                return sql;
        }

        public static string getIsFreeMovie(int imdb_id)
        {
            string sql = "select count(*) r from svod_dates where imdb_id = " + imdb_id + " and now() between start_on and end_on and kind = 'PREPAID_ALL' and now() between prepaid_start_on and prepaid_end_on ";

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

        public static string getTVODAnyoneProducts()
        {
            string sql = "select x.products_id, " +
"(select products_name from `plush_production`.`products_description` pd where pd.products_id = x.products_id and language_id = 1 limit 1) as products_name, " +
"(select products_image_big  from `plush_production`.`products_description` pd where pd.products_id = x.products_id and language_id = 1 limit 1) as products_image_big " + 
" FROM ( SELECT `products`.`products_id` FROM `plush_production`.`products`  INNER JOIN `plush_production`.`lists` ON `lists`.`product_id` = `products`.`products_id` INNER JOIN `plush_production`.`streaming_products` ON `streaming_products`.`imdb_id` = `products`.`imdb_id` AND streaming_products.available = 1 and streaming_products.country ='BE' and streaming_products.status = 'online_test_ok' and ((streaming_products.available_from <= date(now()) and streaming_products.expire_at >= date(now())) or (streaming_products.available_backcatalogue_from <= date(now()) and streaming_products.expire_backcatalogue_at >= date(now()))) WHERE (lists.en = 1) group by lists.id ORDER BY lists.id desc LIMIT 4) x";

            return sql;
        }

        public static string UpdateAlias(string ALIAS, string BRAND, string CARDNO, string CN, string CVC, string ED, string NCERROR, string NCERRORCN, string NCERRORCARDNO, string NCERRORCVC, string NCERRORED, string ORDERID, string SHASIGN, string STATUS)
        {
            return string.Format("update plush_staging.ogone_alias_order_ws " +
                                    " set updated_at = now(), alias_status = {0}, ncerror='{1}', ncerrorcn='{2}', ncerrorcardno={3}, ncerrorcvc='{4}', ncerrored={5} " +
                                    " where order_id = {6} and alias = '{7}' ", STATUS , NCERROR, NCERRORCN, NCERRORCARDNO, NCERRORCVC, NCERRORED, ORDERID, ALIAS );
        }

        public static string getTVODAnyoneProductsImages(string products_ids)
        {
            string sql = "select cast(group_concat(products_image_big) as char(100)) as tvodproductslst products_description where products_id in (" + products_ids + ")";

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

        public static string GetIsTVOD(int in_imdb_id)
        {
            return string.Format("select count(*) r from plush_production.svod_dates where imdb_id = {0} and now() between start_on and end_on", in_imdb_id);
        }

        public static string GetDirectorSlug(int vod_id)
        {
            string sql;

            sql = string.Format("SELECT slug FROM streaming_products s JOIN products p on s.imdb_id = p.imdb_id " +
                " left join directors d on p.products_directors_id = d.directors_id WHERE s.id = {0} ", vod_id);

            return sql;
        }

        public static string GetDirectorSlugAndMovieRating(int vod_id, int? lng_id = 1)
        {
            string sql;

            sql = string.Format("SELECT if(isnull(d.slug),'', d.slug) slug, if(isnull(d.directors_name),'', d.directors_name) directors_name, p.products_year, p.imdb_id, pd.products_name, pd.products_description, pd.products_image_big, cast((cast((p.rating_users/if(p.rating_count = 0,1,p.rating_count))*2 AS SIGNED)/2) as decimal(2,1)) rate FROM streaming_products s JOIN products p on s.imdb_id = p.imdb_id " +
                " join products_description pd on pd.products_id = p.products_id and pd.language_id = {1} left join directors d on p.products_directors_id = d.directors_id WHERE s.id = {0}  group by 1,2 limit 1 ", vod_id, lng_id);

            return sql;
        }

        //
        public static string InsertOgoneAliasOrder(string customerName, string cardno, string cvc, string ed, string alias, string cn)
        {
            return string.Format("insert into plush_staging.ogone_alias_order_ws( alias, card_owner, card_number, card_cvc, card_ed, created_at, updated_at) " +
               " values('{0}','{1}','{2}','{3}','{4}',now(),now()); select LAST_INSERT_ID() returned_number ;", alias, cn, cardno, cvc, ed);

        }

        //public static string UpdateOgoneAliasOrder(string order_status, int order_id, string alias, string )
        //{
        //    return string.Format("insert into plush_staging.ogone_alias_order_ws( alias, card_owner, card_number, card_cvc, card_ed, created_at, updated_at) " +
        //       " values('{0}','{1}','{2}','{3}','{4}',1,null,now(),now()); select LAST_INSERT_ID() order_id ;", alias, cn, cardno, cvc, ed);

        //}

        public static string GetOgoneAliasOrderStatus(string alias, string orderid)
        {
            return string.Format("select alias_status returned_number from plush_staging.ogone_alias_order_ws where alias = '{0}' and order_id = {1} ", alias, orderid);

        }

        public static string CreateOgonePayment(int abo_id, PlushData.ClsCustomersData.Payment_Method method, int customers_id, string price)
        {
            string sql;
            sql = "insert into plush_staging.payment ";
            sql += " (id ,date_added, payment_method, abo_id , customers_id , amount , payment_status , batch_id ,user_modified , last_modified) ";
            sql += " values (null,now(),'" + method + "'," + abo_id + "," + customers_id + "," + price + ", 1, null,77 " + ",now()); select LAST_INSERT_ID() returned_number ;";

            return sql;
        }

        public static string getUpadatePaymentStatus(int orderid)
        {
            string sql;
            sql = "update plush_staging.payment set payment_status = 2, last_modified = now() where id = " + orderid;

            return sql;
        }

        public static string GetInsertHistoryAbo(int customers_id, string code_id, int product_id, string type_payment, int actionCode)
        {
            string sql;
            if (code_id == "")
                code_id = "null";

            sql = "insert into plush_staging.abo(Customerid ,code_id, Action , Date , product_id, payment_method, comment) " +
                    " values(" + customers_id + "," + code_id + "," + actionCode + ", now(), '" + product_id + "', '" + type_payment + "','' ); select LAST_INSERT_ID() returned_number ;";

            return sql;
        }

        public static string getUpdateCustomerOgone(int cn, string customerName, string cardno, string ed, string card_type)
        {
            string sql = string.Format("update customers set customers_abo_payment_method = 1, ogone_card_type = '{0}',  ogone_card_no = '{1}', ogone_exp_date = '{2}', ogone_owner = '{3}' " +
                            " where customers_id = {4}", card_type, cardno, ed,customerName, cn);

            return sql;
        }

        public static string getInsertPaymentOgoneWS(int order_id, string responseXML)
        {
            return "insert into plush_staging.payment_ogone_ws( order_id, response_xml) values(" + order_id + ",'" + responseXML + "')";
        }
    }
}
