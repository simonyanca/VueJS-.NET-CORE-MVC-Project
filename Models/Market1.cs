using System;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Vue_Core.Models
{
    public class Market1Item
    {
        public int Id { get; set; }
        public byte[] Img { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public interface IMarket1Repository
    {
        void Create(Market1Item item);
        void Delete(int id);
        Market1Item Get(int id);
        List<Market1Item> GetItems();
        void Update(Market1Item item);
    }
    public class Market1Repo : IMarket1Repository
    {
        string connectionString = null;
        public Market1Repo(string conn)
        {
            connectionString = conn;
        }
        public Market1Item Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Market1Item>("SELECT * FROM Market1TB WHERE Id = @Id", new { Id }).First();
            }
        }
        public List<Market1Item> GetItems()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Market1Item>("SELECT * FROM Market1TB").ToList();
            }
        }
        public void Create(Market1Item item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Market1TB (Name, Description, Img) VALUES(@Name, @Description, @Img)";
                db.Execute(sqlQuery, item);
                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }
        public void Update(Market1Item user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Market1TB SET Name = @Name, Description = @Description, Img = @Img WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Market1TB WHERE Id = @Id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
