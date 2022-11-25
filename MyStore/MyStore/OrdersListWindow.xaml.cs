using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyStore
{
    /// <summary>
    /// Логика взаимодействия для OrdersListWindow.xaml
    /// </summary>
    public partial class OrdersListWindow : Window
    {
        MyStoreContext db = new MyStoreContext();
        public OrdersListWindow()
        {
            InitializeComponent();

            Loaded += OrdersListWindow_Loaded;
        }

        private void OrdersListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // загружаем данные из БД
            db.Orders.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Orders.Local.ToObservableCollection();
        }
        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            db.Employees.Load();

            OrderWindow OrderWindow = new OrderWindow(new Order());
            if (OrderWindow.ShowDialog() == true)
            {
                Order Order = OrderWindow.Order;
                db.Orders.Add(Order);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Order? order = ordersList.SelectedItem as Order;
            // если ни одного объекта не выделено, выходим
            if (order is null) return;
            ObservableCollection<Employee> list = db.Employees.Local.ToObservableCollection();

            OrderWindow OrderWindow = new OrderWindow(new Order
            {
                OrderId = order.OrderId,
                EmployeeId = order.EmployeeId,
                Number = order.Number,
                ProductName = order.ProductName
            });

            if (OrderWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                order = db.Orders.Find(OrderWindow.Order.OrderId);
                if (order != null)
                {
                    order.EmployeeId = OrderWindow.Order.EmployeeId;
                    order.Number = OrderWindow.Order.Number;
                    order.ProductName = OrderWindow.Order.ProductName;
                    db.SaveChanges();
                    ordersList.Items.Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Order? order = ordersList.SelectedItem as Order;
            // если ни одного объекта не выделено, выходим
            if (order is null) return;
            db.Orders.Remove(order);
            db.SaveChanges();
        }
    }
}
