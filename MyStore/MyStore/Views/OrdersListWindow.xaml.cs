using System.Windows;
using MyStore.ViewModels;

namespace MyStore.Views
{
    /// <summary>
    /// Логика взаимодействия для OrdersListWindow.xaml
    /// </summary>
    public partial class OrdersListWindow : Window
    {
        public OrdersListWindow()
        {
            InitializeComponent();
            // Из контекста будем тянуть для привящки Orders
            DataContext = new OrdersListViewModel();
        }
    }
}
