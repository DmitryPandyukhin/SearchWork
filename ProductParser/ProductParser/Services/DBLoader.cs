using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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

                // Добавляем в БД
                var users = ordersList.
                //db.Users.AddRange


                /*User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                // добавляем их в бд
                db.Users.AddRange(user1, user2);
                db.SaveChanges();*/
            }
        }
    }
}
