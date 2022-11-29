using System.Windows;
using MyStore.ViewModels;


namespace MyStore.Views
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