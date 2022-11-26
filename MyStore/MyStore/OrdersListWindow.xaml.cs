using System.Collections.ObjectModel;
using System.Windows;

namespace MyStore
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
