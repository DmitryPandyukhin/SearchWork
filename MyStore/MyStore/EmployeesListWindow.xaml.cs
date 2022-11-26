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
        public EmployeesListWindow()
        {
            InitializeComponent();
            DataContext = new EmployeesListViewModel();
        }
    }
}