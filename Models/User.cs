using System;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Vue_Core.Models
{
    public class User
    {
        public User(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public interface IUserRepository
    {
        void Create(string Login, string Password);
        bool ifExists(string Login, string Password);
    }
    public class UserRepo: IUserRepository
    {
        string connectionString = null;
        public UserRepo(string conn)
        {
            connectionString = conn;
        }
        public void Create(string Login, string Password)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery1 = "INSERT INTO UserTB (Login,Password) VALUES(@Login,@Password)";
                User user = new User(Login, Password);
                var result = db.Execute(sqlQuery1, user);
            }
        }
        public bool ifExists(string Login, string Password)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
               var Ifexists = db.ExecuteScalar<bool>("select count(1) from UserTB where Login=@Login and Password = @Password",new { Login = Login, Password = Password });
               return Ifexists;
            }
        }
    }
}
