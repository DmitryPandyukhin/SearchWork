using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MyStore
{
    public class MainViewModel
    {
        
        MyStoreContext db;

        RelayCommand? openOrdersCommand;
        RelayCommand? openEmployeesCommand;
        RelayCommand? openDepartamentsCommand;

        public MainViewModel()
        {
            db = new MyStoreContext();
            // пересоздаем БД
            //db.Database.EnsureDeleted();
            // гарантируем, что БД создана
            db.Database.EnsureCreated();
            // Тестовые данные
            //SeedData();
        }

        public RelayCommand OpenOrdersCommand
        {
            get
            {
                return openOrdersCommand ??
                  (openOrdersCommand = new RelayCommand((o) =>
                  {
                      new OrdersListWindow().ShowDialog();
                  }));
            }
        }
        public RelayCommand OpenEmployeesCommand
        {
            get
            {
                return openEmployeesCommand ??
                  (openEmployeesCommand = new RelayCommand((o) =>
                  {
                      new EmployeesListWindow().ShowDialog();
                  }));
            }
        }

        public RelayCommand OpenDepartamentsCommand
        {
            get
            {
                return openDepartamentsCommand ??
                  (openDepartamentsCommand = new RelayCommand((o) =>
                  {
                      new DepartamentsListWindow().ShowDialog();
                  }));
            }
        }

        private void SeedData()
        {
            // департаменты
            Departament dep1 = new() { Name = "Dep1" };
            Departament dep2 = new() { Name = "Dep2" };
            db.Departaments.AddRange(dep1, dep2);
            db.SaveChanges();

            // Сотрудники
            int id = db.Departaments.First().DepartamentId;
            Employee emp1 = new() { LastName = "Ivanov", FirstName = "Ivan", Sex = Sex.мужской, BirthDate = new System.DateTime(2021, 1, 1), DepartamentId = id };
            Employee emp2 = new() { LastName = "Petrov", FirstName = "Petr", Sex = Sex.мужской, BirthDate = new System.DateTime(2020, 1, 1), DepartamentId = id };
            db.Employees.AddRange(emp1, emp2);
            db.SaveChanges();

            // Заказы
            id = db.Employees.First().EmployeeId;
            Order order = new Order() { Number = 123, ProductName = "Product1", EmployeeId = id };
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}
