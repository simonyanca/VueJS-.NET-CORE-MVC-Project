using System;
using Dapper;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Vue_Core.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte[] ImgData { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public string Description { get; set; }
    }
    public interface ICartItemRepo
    {
        void Create(CartItem item);
        void Delete(int id);
        CartItem Get(int id);
        List<CartItem> GetItems(int UserId);
    }
    public class CartItemRepo : ICartItemRepo
    {
        string connectionString = null;
        public CartItemRepo(string conn)
        {
            connectionString = conn;
        }
        public CartItem Get(int Id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<CartItem>("SELECT * FROM Market1TB WHERE Id = @Id", new { Id }).First();
            }
        }
        public List<CartItem> GetItems(int UserId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var toReturn =  db.Query<CartItem>("SELECT * FROM Market1TB where UserId = @UserId").ToList();
                return toReturn;
            }
        }
        public void Create(CartItem item)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Market1TB (Name, Description, ImgData) VALUES(@Name, @Description, @ImgData)";
                db.Execute(sqlQuery, item);
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
