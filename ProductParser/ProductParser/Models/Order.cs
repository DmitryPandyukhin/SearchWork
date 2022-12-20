using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersParser.Models
{
    internal class Order
    {
        public int OrderId { get; set; }
        public int No { get; set; }
        public DateTime Reg_date { get; set; }
        public decimal Sum { get; set; }
        public int UserId { get; set; }
        // Ссылка на пользователя.
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
    internal class Product
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    internal class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        // Ссылка на заказ.
        Order Order { get; set; }
        public int ProductId { get; set; }
        // Ссылка на товар
        Product Product { get; set; }
    }
    internal class User
    {
        public int UserId { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
    }
}
