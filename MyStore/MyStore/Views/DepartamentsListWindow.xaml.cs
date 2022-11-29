using System.Windows;
using MyStore.ViewModels;

namespace MyStore.Views
{
    /// <summary>
    /// Логика взаимодействия для DepartamentsWindow.xaml
    /// </summary>
    public partial class DepartamentsListWindow : Window
    {
        public DepartamentsListWindow()
        {
            InitializeComponent();
            DataContext = new DepartamentsListViewModel();
        }
    }
}
