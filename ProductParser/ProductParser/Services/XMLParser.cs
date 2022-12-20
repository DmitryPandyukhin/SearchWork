﻿using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using OrdersParser.Models;
using System.Globalization;
using System.Xml.Linq;

namespace OrdersParser.Services
{
    internal static class XMLParser
    {
        public static List<Order>? LoadOrders()
        {
            XDocument xdoc = XDocument.Load("orders.xml");
            // получаем корневой узел
            XElement? orders = xdoc.Element("orders");

            IFormatProvider cultureInfo = new CultureInfo("en-US");

            if (orders is not null)
            {
                List<Order> ordersList = new List<Order>();
                // проходим по всем элементам order
                foreach (XElement orderElement in orders.Elements("order"))
                {
                    Order order = new Order();
                    XElement? temp;

                    temp = orderElement.Element("no");
                    if (temp is not null)
                    {
                        order.No = int.Parse(temp.Value);
                    }

                    temp = orderElement.Element("reg_date");
                    if (temp is not null)
                    {
                        order.Reg_date = DateTime.Parse(temp.Value);
                    }

                    temp = orderElement.Element("sum");
                    if (temp is not null)
                    {
                        order.Sum = decimal.Parse(temp.Value, cultureInfo);
                    }

                    order.Products = new();

                    // проходим по всем элементам product
                    foreach (XElement productElement in orderElement.Elements("product"))
                    {
                        Product product = new();

                        temp = productElement.Element("quantity");
                        if (temp is not null)
                        {
                            product.Quantity = int.Parse(temp.Value);
                        }

                        temp = productElement.Element("name");
                        if (temp is not null)
                        {
                            product.Name = temp.Value;
                        }

                        temp = productElement.Element("price");
                        if (temp is not null)
                        {
                            product.Price = decimal.Parse(temp.Value, cultureInfo);
                        }

                        order.Products.Add(product);
                    }

                    XElement? userElement = orderElement.Element("user");
                    if (userElement is not null)
                    {
                        order.User = new();

                        temp = userElement.Element("fio");
                        if (temp is not null)
                        {
                            order.User.FIO = temp.Value;
                        }

                        temp = userElement.Element("email");
                        if (temp is not null)
                        {
                            order.User.Email = temp.Value;
                        }
                    }

                    ordersList.Add(order);
                }

                return ordersList;
            }

            return null;
        }
    }
}
