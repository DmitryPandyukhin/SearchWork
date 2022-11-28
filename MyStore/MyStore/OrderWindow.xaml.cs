using System.Windows;
namespace MyStore
{
    public partial class OrderWindow : Window
    {
        public OrderWindow(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}