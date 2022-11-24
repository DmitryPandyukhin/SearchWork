using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
namespace MyStore
{
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        // при загрузке окна
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // пересоздаем БД
            //db.Database.EnsureDeleted();
            // гарантируем, что БД создана
            db.Database.EnsureCreated();

            // Тестовые данные
            //SeedData();

            // загружаем данные из БД
            db.Orders.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Orders.Local.ToObservableCollection();
        }

        private void SeedData()
        {
            Employee emp = new()
            {
                LastName = "Ivanov",
                FirstName = "Ivan",
                Sex = Sex.male,
                BirthDate = new System.DateTime(2021, 1, 1)
            };
            db.Employees.Add(emp);

            emp = new()
            {
                LastName = "Petrov",
                FirstName = "Petr",
                Sex = Sex.male,
                BirthDate = new System.DateTime(2020, 1, 1)
            };
            db.Employees.Add(emp);

            db.SaveChanges();
            int id = db.Employees.First().EmployeeId;

            Order order = new Order() { Number = 123, ProductName = "Product1", EmployeeId = id };
            db.Orders.Add(order);
            db.SaveChanges();
        }

        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            db.Employees.Load();
            ObservableCollection<Employee> list = db.Employees.Local.ToObservableCollection();
            OrderWindow OrderWindow = new OrderWindow(new Order() 
            { 
                Employees = list
            });
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
            Order? order = orderList.SelectedItem as Order;
            // если ни одного объекта не выделено, выходим
            if (order is null) return;
            ObservableCollection<Employee> list = db.Employees.Local.ToObservableCollection();

            OrderWindow OrderWindow = new OrderWindow(new Order
            {
                OrderId = order.OrderId,
                EmployeeId = order.EmployeeId,
                Number = order.Number,
                ProductName = order.ProductName,
                Employees = list
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
                    orderList.Items.Refresh();
                }
            }
        }
        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Order? order = orderList.SelectedItem as Order;
            // если ни одного объекта не выделено, выходим
            if (order is null) return;
            db.Orders.Remove(order);
            db.SaveChanges();
        }
    }
}