using Last.fmInfo.Database;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last.fmInfo.Entity
{
    [Table(Name = "Users")]
    public class User
    {
        [Column(IsPrimaryKey=true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column(CanBeNull=false)]
        public string UserName { get; set; }
        [Column(CanBeNull = false)]
        public int CurrentUser { get; set; }
        public string PlayCount { get; set; }
        public string RealName { get; set; }
        public string Country { get; set; }
        public string Age { get; set; }

        private static DB GetDataBase()
        {
            DB db = new DB();
            if (!db.DatabaseExists())
                db.CreateDatabase();
            return db;
        }

        public static void Create(User pUser)
        {
            DB db = GetDataBase();
            db.Users.InsertOnSubmit(pUser);
            db.SubmitChanges();
        }

        public static List<User> Get()
        {
            DB db = GetDataBase();
            var query = from users in db.Users select users;
            List<User> usuarios = new List<User>(query.AsEnumerable());
            return usuarios;
        }

        public static List<User> GetCurrentUser()
        {
            DB db = GetDataBase();
            var query = from users in db.Users where users.CurrentUser == 1 select users;
            List<User> usuarios = new List<User>(query.AsEnumerable());
            return usuarios;
        }

        public static void UpdateCurrentUser(User pUser)
        {
            DB db = GetDataBase();
            var discipline = from users in db.Users where users.CurrentUser == 1select users;
            List<User> usrs = new List<User>(discipline.AsQueryable());

            foreach (User user in usrs)
            {
                user.CurrentUser = 0;
            }

            User usr = (from u in db.Users where u.UserName == pUser.UserName select u).First();
            usr.CurrentUser = 1;
            db.SubmitChanges();
        }
    }
}
