using Microsoft.EntityFrameworkCore;
using System.Windows;


namespace MyStore
{
    /// <summary>
    /// Логика взаимодействия для EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesListWindow : Window
    {
        MyStoreContext db = new MyStoreContext();
        public EmployeesListWindow()
        {
            InitializeComponent();

            Loaded += EmployeesWindow_Loaded;
        }

        private void EmployeesWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // загружаем данные из БД
            db.Employees.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Employees.Local.ToObservableCollection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow EmployeeWindow = new EmployeeWindow(new Employee());
            if (EmployeeWindow.ShowDialog() == true)
            {
                Employee Employee = EmployeeWindow.Employee;
                db.Employees.Add(Employee);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeesList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;

            EmployeeWindow EmployeeWindow = new EmployeeWindow(new Employee
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                BirthDate = employee.BirthDate,
                Sex = employee.Sex,
                Departament = employee.Departament
            });

            if (EmployeeWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                employee = db.Employees.Find(EmployeeWindow.Employee.EmployeeId);
                if (employee != null)
                {
                    employee.LastName = EmployeeWindow.Employee.LastName;
                    employee.FirstName = EmployeeWindow.Employee.FirstName;
                    employee.MiddleName = EmployeeWindow.Employee.MiddleName;
                    employee.BirthDate = EmployeeWindow.Employee.BirthDate;
                    employee.Sex = EmployeeWindow.Employee.Sex;
                    employee.Departament = EmployeeWindow.Employee.Departament;

                    db.SaveChanges();
                    employeesList.Items.Refresh();
                }
            }
        }

        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Employee? employee = employeesList.SelectedItem as Employee;
            // если ни одного объекта не выделено, выходим
            if (employee is null) return;
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}