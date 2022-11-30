using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyStore.ViewModels
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
                .Include(o => o.Tags)
                .Load();
            Orders = db.Orders.Local.ToObservableCollection();

            // Если не загрузить форма не будет обновляться
            db.Employees.Load();
            db.Tags.Load();
        }

        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      OrderViewModel orderViewModel = new(new());
                      if (orderViewModel.Open() == true)
                      {
                          Order order = new()
                          {
                              Number = orderViewModel.Order.Number,
                              ProductName = orderViewModel.Order.ProductName,
                              EmployeeId = orderViewModel.Order?.EmployeeId,
                              Tags = orderViewModel.Order?.Tags
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
                          OrderId = order.OrderId,
                          ProductName = order.ProductName,
                          EmployeeId = order.EmployeeId
                      };

                      OrderViewModel orderViewModel = new(vm);
                      if (orderViewModel.Open() == true)
                      {
                          order.Number = orderViewModel.Order.Number;
                          order.ProductName = orderViewModel.Order.ProductName;
                          order.EmployeeId = orderViewModel.Order?.EmployeeId;
                          if (order.EmployeeId != null)
                              order.Employee = db.Employees.Local.First(e => e.EmployeeId == order.EmployeeId);
                          if (order.Tags?.Count > 0)
                            order.Tags?.Clear();
                          if (orderViewModel.Order?.Tags?.Count > 0)
                              order.Tags = orderViewModel.Order?.Tags;

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
