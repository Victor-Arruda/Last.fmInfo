using Last.fmInfo.Entity;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last.fmInfo.Database
{
    class DB : DataContext
    {
        public static string DBConnectionString = "Data Source = 'isostore:lastfminfoDB.sdf'";

        public DB()
            :base(DBConnectionString)
        { }



        public Table<User> Users
        {
            get { return this.GetTable<User>(); }
        }
    }
}
