using System;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Vue_Core.Models
{
    public class Market2Item
    {
        public int Id { get; set; }
        public byte[] ImgData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }
    }
    public interface IMarket2Repository
    {
        void Create(Market2Item item);
        void Delete(int id);
        Market2Item Get(int id);
        List<Market2Item> GetItems();
        void Update(Market2Item item);
    }
    public class Market2Repo : IMarket2Repository
    {
        string connectionString = null;
        public Market2Repo(string conn)
        {
            connectionString = conn;
        }
        public Market2Item Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Market2Item>("SELECT * FROM Market2TB WHERE Id = @Id", new { Id }).First();
            }
        }
        public List<Market2Item> GetItems()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var toReturn =  db.Query<Market2Item>("SELECT * FROM Market2TB").ToList();
                return toReturn;
            }
        }
        public void Create(Market2Item item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Market2TB (Name, Description, ImgData, Discount) VALUES(@Name, @Description, @ImgData, @Discount)";
                db.Execute(sqlQuery, item);
            }
        }
        public void Update(Market2Item user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Market2TB SET Name = @Name, Description = @Description, ImgData = @ImgData WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Market2TB WHERE Id = @Id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
