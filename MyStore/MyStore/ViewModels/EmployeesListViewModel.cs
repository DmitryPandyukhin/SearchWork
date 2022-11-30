using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;

namespace MyStore.ViewModels
{
    public class EmployeesListViewModel
    {
        MyStoreContext db = new();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<Employee> Employees { get; set; }
        public EmployeesListViewModel()
        {
            db.Employees
                .Include(e => e.Departament)
                .Load();
            Employees = db.Employees.Local.ToObservableCollection();

            db.Departaments.Load();
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      EmployeeViewModel employeeViewModel = new(
                          new Employee()
                          {
                              BirthDate = DateTime.Now.Date
                          });
                      if (employeeViewModel.Open() == true)
                      {
                          Employee Employee = new()
                          {
                              LastName = employeeViewModel.Employee.LastName,
                              FirstName = employeeViewModel.Employee.FirstName,
                              MiddleName = employeeViewModel.Employee.MiddleName,
                              BirthDate = employeeViewModel.Employee.BirthDate,
                              Sex = employeeViewModel.Employee.Sex,
                              DepartamentId = employeeViewModel.Employee.DepartamentId
                          };

                          db.Employees.Add(Employee);
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
                      Employee? employee = selectedItem as Employee;
                      // если ни одного объекта не выделено, выходим
                      if (employee is null) return;

                      Employee vm = new Employee
                      {
                          EmployeeId = employee.EmployeeId,
                          LastName = employee.LastName,
                          FirstName = employee.FirstName,
                          MiddleName = employee.MiddleName,
                          BirthDate = employee.BirthDate,
                          Sex = employee.Sex,
                          DepartamentId = employee.DepartamentId
                      };

                      EmployeeViewModel employeeViewModel = new(vm);

                      if (employeeViewModel.Open() == true)
                      {
                          employee.LastName = employeeViewModel.Employee.LastName;
                          employee.FirstName = employeeViewModel.Employee.FirstName;
                          employee.MiddleName = employeeViewModel.Employee.MiddleName;
                          employee.BirthDate = employeeViewModel.Employee.BirthDate;
                          employee.Sex = employeeViewModel.Employee.Sex;
                          employee.DepartamentId = employeeViewModel.Employee.DepartamentId;
                          if (employee.DepartamentId != null)
                            employee.Departament = db.Departaments.Local
                                .First(d => d.DepartamentId == employee.DepartamentId);
                          db.Entry(employee).State = EntityState.Modified;
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
                      Employee? employee = selectedItem as Employee;
                      // если ни одного объекта не выделено, выходим
                      if (employee is null) return;
                      db.Employees.Remove(employee);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
