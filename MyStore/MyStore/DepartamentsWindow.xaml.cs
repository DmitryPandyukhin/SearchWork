using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace MyStore
{
    /// <summary>
    /// Логика взаимодействия для DepartamentsWindow.xaml
    /// </summary>
    public partial class DepartamentsWindow : Window
    {
        MyStoreContext db = new MyStoreContext();
        public DepartamentsWindow()
        {
            InitializeComponent();

            Loaded += DepartamentsWindow_Loaded;
        }

        private void DepartamentsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // загружаем данные из БД
            db.Departaments.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Departaments.Local.ToObservableCollection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            /*db.Employees.Load();
            ObservableCollection<Employee> list = db.Employees.Local.ToObservableCollection();
            OrderWindow OrderWindow = new OrderWindow(new Order()
            {
                Employees = list
            });
            if (OrderWindow.ShowDialog() == true)
            {
                Order Order = OrderWindow.Order;
                db.Orders.Add(Order);
                db.SaveChanges();
            }*/
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            /*Order? order = orderList.SelectedItem as Order;
            // если ни одного объекта не выделено, выходим
            if (order is null) return;
            ObservableCollection<Employee> list = db.Employees.Local.ToObservableCollection();

            OrderWindow OrderWindow = new OrderWindow(new Order
            {
                OrderId = order.OrderId,
                EmployeeId = order.EmployeeId,
                Number = order.Number,
                ProductName = order.ProductName,
                Employees = list
            });

            if (OrderWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                order = db.Orders.Find(OrderWindow.Order.OrderId);
                if (order != null)
                {
                    order.EmployeeId = OrderWindow.Order.EmployeeId;
                    order.Number = OrderWindow.Order.Number;
                    order.ProductName = OrderWindow.Order.ProductName;
                    db.SaveChanges();
                    orderList.Items.Refresh();
                }*/
        }

        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            /*Order? order = orderList.SelectedItem as Order;
            // если ни одного объекта не выделено, выходим
            if (order is null) return;
            db.Orders.Remove(order);
            db.SaveChanges();*/
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
