﻿using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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
            //db.Database.EnsureDeleted();
            // гарантируем, что БД создана
            db.Database.EnsureCreated();
            // Тестовые данные
            //SeedData();
        }

        private void SeedData()
        {
            // департаменты
            Departament dep1 = new(){ Name = "Dep1" };
            Departament dep2 = new(){ Name = "Dep2" };
            db.Departaments.AddRange(dep1, dep2);
            db.SaveChanges();

            // Сотрудники
            int id = db.Departaments.First().DepartamentId;
            Employee emp1 = new(){ LastName = "Ivanov", FirstName = "Ivan", Sex = Sex.мужской, BirthDate = new System.DateTime(2021, 1, 1), DepartamentId = id };
            Employee emp2 = new(){ LastName = "Petrov", FirstName = "Petr", Sex = Sex.мужской, BirthDate = new System.DateTime(2020, 1, 1), DepartamentId = id };
            db.Employees.AddRange(emp1, emp2);
            db.SaveChanges();

            // Заказы
            id = db.Employees.First().EmployeeId;
            Order order = new Order() { Number = 123, ProductName = "Product1", EmployeeId = id };
            db.Orders.Add(order);
            db.SaveChanges();
        }
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            new OrdersListWindow().ShowDialog();
        }
        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            new EmployeesListWindow().ShowDialog();
        }
        private void Departaments_Click(object sender, RoutedEventArgs e)
        {
            new DepartamentsListWindow().ShowDialog();
        }
    }
}