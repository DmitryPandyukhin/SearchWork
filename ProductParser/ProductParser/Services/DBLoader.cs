using OrdersParser.Models;

namespace OrdersParser.Services
{
    internal static class DBLoader
    {
        internal static void LoadToDB(List<Order> ordersList)
        {
            using (MSSQLContext db = new MSSQLContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                // детализация заказа
                List<OrderDetail> orderDetailsList = new List<OrderDetail>();

                // контроль уникальности пользователей
                foreach (var order in ordersList)
                {
                    order.UserId = db.Users.First(u => u.FIO == order.User.FIO)?.UserId ?? 0;
                    if (order.UserId != 0)
                        order.User = null!;



                    // контроль уникальности товаров м
                    // заполнение детализации заказа
                    foreach (var product in order.Products)
                    {
                        OrderDetail orderDetail = new()
                        {
                            Order = order
                        };

                        int Product_id = db.Products.First(p => p.Name == product.Name).ProductId;
                        if (Product_id != 0)
                        {
                            orderDetail.ProductId = Product_id;
                            order.Products.Remove(product);
                        }
                        else
                        {
                            orderDetail.Product = product;
                        }

                        orderDetailsList.Add(orderDetail);
                    }
                }


                db.Orders.AddRange(ordersList);
                db.SaveChanges();

                db.OrderDetails.AddRange(orderDetailsList);
                db.SaveChanges();

                /*User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                // добавляем их в бд
                db.Users.AddRange(user1, user2);
                db.SaveChanges();*/
            }
        }
    }
}
