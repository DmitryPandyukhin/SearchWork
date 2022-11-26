using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;

namespace MyStore
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
