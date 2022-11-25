using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;


namespace MyStore
{
    /// <summary>
    /// Логика взаимодействия для EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesListWindow : Window
    {
        public ObservableCollection<Employee> EmployeesList { get; private set; }
        public EmployeesListWindow(ObservableCollection<Employee> employeesList)
        {
            InitializeComponent();
            EmployeesList = employeesList;
            DataContext = EmployeesList;
        }
    }
}