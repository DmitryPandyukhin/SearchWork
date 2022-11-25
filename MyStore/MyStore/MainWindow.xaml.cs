using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyStore
{
    public partial class MainWindow : Window
    {
        MyStoreContext db = new MyStoreContext();
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        // при загрузке окна
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // пересоздаем БД
            db.Database.EnsureDeleted();
            // гарантируем, что БД создана
            db.Database.EnsureCreated();
            // Тестовые данные
            SeedData();
        }

        private void SeedData()
        {
            // департаменты
            Departament dep = new()
            {
                Name = "Dep1"
            };
            db.Departaments.Add(dep);
            dep = new()
            {
                Name = "Dep2"
            };
            db.Departaments.Add(dep);
            db.SaveChanges();

            // Сотрудники
            int id = db.Departaments.First().DepartamentId;
            Employee emp = new()
            {
                LastName = "Ivanov",
                FirstName = "Ivan",
                Sex = Sex.мужской,
                BirthDate = new System.DateTime(2021, 1, 1),
                DepartamentId = id
            };
            db.Employees.Add(emp);

            emp = new()
            {
                LastName = "Petrov",
                FirstName = "Petr",
                Sex = Sex.мужской,
                BirthDate = new System.DateTime(2020, 1, 1),
                DepartamentId = id
            };
            db.Employees.Add(emp);
            db.SaveChanges();

            // Заказы
            id = db.Employees.First().EmployeeId;
            Order order = new Order() { Number = 123, ProductName = "Product1", EmployeeId = id };
            db.Orders.Add(order);
            db.SaveChanges();
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            OrdersListWindow OrdersListWindow = new ();
            OrdersListWindow.ShowDialog();
        }
        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            db.Employees.Load();
            ObservableCollection<Employee> employeeList = db.Employees.Local.ToObservableCollection();
            EmployeesListWindow EmployeesWindow = new(employeeList);
            EmployeesWindow.ShowDialog();
        }
        private void Departaments_Click(object sender, RoutedEventArgs e)
        {
            DepartamentsListWindow DepartamentsWindow = new ();
            DepartamentsWindow.ShowDialog();
        }
    }
}