using System.Windows;
namespace MyStore
{
    public partial class OrderWindow : Window
    {
        public Order Order { get; private set; }
        public OrderWindow(Order order)
        {
            InitializeComponent();
            Order = order;
            DataContext = Order;
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}