using System.Windows;

namespace MyStore
{
    /// <summary>
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public Employee Employee { get; private set; }
        public EmployeeWindow(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
