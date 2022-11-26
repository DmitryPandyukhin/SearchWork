using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

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
            db.Orders.Load();
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
                      OrderWindow orderWindow = new (new Order());
                      if (orderWindow.ShowDialog() == true)
                      {
                          Order order = orderWindow.Order;
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

                      Order vm = new Order
                      {
                          Number = order.Number,
                          ProductName = order.ProductName,
                          EmployeeId = order.EmployeeId
                      };

                      OrderWindow orderWindow = new (vm);

                      if (orderWindow.ShowDialog() == true)
                      {
                          order.Number = orderWindow.Order.Number;
                          order.ProductName = orderWindow.Order.ProductName;
                          order.EmployeeId = orderWindow.Order.EmployeeId;

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
