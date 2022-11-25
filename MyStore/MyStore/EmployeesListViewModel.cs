using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace MyStore
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
            db.Employees.Load();
            Employees = db.Employees.Local.ToObservableCollection();
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      EmployeeWindow employeeWindow = new EmployeeWindow(new Employee());
                      if (employeeWindow.ShowDialog() == true)
                      {
                          Employee Employee = employeeWindow.Employee;
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
                          Departament = employee.Departament
                      };

                      EmployeeWindow employeeWindow = new EmployeeWindow(vm);

                      if (employeeWindow.ShowDialog() == true)
                      {
                          employee.LastName = employeeWindow.Employee.LastName;
                          employee.FirstName = employeeWindow.Employee.FirstName;
                          employee.MiddleName = employeeWindow.Employee.MiddleName;
                          employee.BirthDate = employeeWindow.Employee.BirthDate;
                          employee.Sex = employeeWindow.Employee.Sex;
                          employee.Departament = employeeWindow.Employee.Departament;
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
                /*return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      User? user = selectedItem as User;
                      if (user == null) return;
                      db.Users.Remove(user);
                      db.SaveChanges();
                  }));*/
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
