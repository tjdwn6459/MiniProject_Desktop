using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSMSApp.Model;

namespace WpfSMSApp.Logic
{
    public class DataAccess
    {

        public static List<User> GetUsers()
        {
            List<User> users;

            using (var ctx = new SMSEntities())
            {
                users = ctx.User.ToList();//SELECT * FROM USERS
            }

            return users;
        }

        internal static int SetUser(User user)
        {
            using (var ctx = new SMSEntities())
            {
                ctx.User.AddOrUpdate(user); //AddOrUpdate ->키값이 없으면 insert 있으면 update
                return ctx.SaveChanges(); //commit
            }
        }

        internal static List<Stock> GetStocks()
        {
            List<Stock> stocks;
            using (var ctx = new SMSEntities())
            {
                stocks = ctx.Stock.ToList();
            }
            return stocks;
        }

        public static List<Store> GetStores()
        {
            List<Store> stores;
            using (var ctx = new SMSEntities())
            {
                stores = ctx.Store.ToList();
            }
            return stores;
        }

        public static int SetStore(Store store)
        {
            using (var ctx = new SMSEntities())
            {
                ctx.Store.AddOrUpdate(store); //값이 입력이 되면 데이터베이스에 입력된 개수를 전달해준다
                return ctx.SaveChanges();
            }
        }
    }
}
