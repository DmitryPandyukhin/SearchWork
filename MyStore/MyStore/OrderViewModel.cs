using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MyStore
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        MyStoreContext db = new();
        RelayCommand? okCommand;
        public Order Order { get; set; }
        OrderWindow? OrderWindow { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }

        public OrderViewModel(Order order)
        {
            // Загружаем справочник сотрудников
            db.Employees.Load();
            Employees = db.Employees.Local.ToObservableCollection();

            // Получаем выранного сотрудника
            order.Employee = Employees.FirstOrDefault(e => e.EmployeeId == order.EmployeeId);

            // Добавляем в контекст
            Order = order;
        }
        // Открываем окно работы с заказом
        public bool Open()
        {
            // Передача контекста
            OrderWindow = new(this);

            if (OrderWindow.ShowDialog() == true)
                return true;
            else
                return false;
        }

        // Работаем со справочником сотрудников
        public Employee EmployeeItem
        {
            get { return Order.Employee!; }
            set
            {
                if (Order.Employee == value) return;
                Order.Employee = value;
                Order.EmployeeId = value.EmployeeId;

                // Свойство изменено
                OnPropertyChanged("EmployeeItem");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public RelayCommand OkCommand
        {
            get
            {
                return okCommand ??
                  (okCommand = new RelayCommand((o) =>
                  {
                    if (OrderWindow != null)
                        OrderWindow.DialogResult = true;
                  }));
            }
        }
    }
}
