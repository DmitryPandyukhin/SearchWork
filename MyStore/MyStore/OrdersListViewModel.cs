using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Markup;

namespace MyStore
{
    public class OrdersListViewModel
    {
        MyStoreContext db = new();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<Order> Orders { get; set; }
        public OrdersListViewModel()
        {
            db.Orders
                .Include(o => o.Employee)
                .Load();
            Orders = db.Orders.Local.ToObservableCollection();
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      OrderViewModel orderViewModel = new (new());
                      if (orderViewModel.Open() == true)
                      {
                          Order order = new()
                          {
                              Number = orderViewModel.Order.Number,
                              ProductName = orderViewModel.Order.ProductName,
                              EmployeeId = orderViewModel.Order?.Employee?.EmployeeId
                          };
                          db.Orders.Add(order);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      Order? order = selectedItem as Order;
                      // если ни одного объекта не выделено, выходим
                      if (order is null) return;

                      Order vm = new()
                      {
                          Number = order.Number,
                          ProductName = order.ProductName,
                          EmployeeId = order.EmployeeId
                      };

                      OrderViewModel orderViewModel = new(vm);
                      if (orderViewModel.Open() == true)
                      {
                          order.Number = orderViewModel.Order.Number;
                          order.ProductName = orderViewModel.Order.ProductName;
                          order.EmployeeId = orderViewModel.Order?.Employee?.EmployeeId;

                          db.Entry(order).State = EntityState.Modified;
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      Order? order = selectedItem as Order;
                      // если ни одного объекта не выделено, выходим
                      if (order is null) return;
                      db.Orders.Remove(order);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
