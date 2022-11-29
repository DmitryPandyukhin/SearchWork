using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MyStore.Models;
using MyStore.Views;

namespace MyStore.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        RelayCommand? okCommand;
        public Order Order { get; set; }
        OrderWindow? OrderWindow { get; set; }
        public ObservableCollection<Employee>? Employees { get; set; }

        public OrderViewModel(Order order)
        {
            Order = order;
        }

        private void PrepareData()
        {
            using (MyStoreContext db = new())
            {
                // Загружаем справочник сотрудников
                db.Employees.Load();
                Employees = db.Employees.Local.ToObservableCollection();

                // Устанавливаем сотрудника
                Order.Employee = Employees.Where(e => e.EmployeeId == Order.EmployeeId).FirstOrDefault();

                // Получаем теги
                db.Tags.Where(t => t.OrderId == Order.OrderId).Load();
                Order.Tags = db.Tags.Local.ToObservableCollection();
            }
        }

        // Открываем окно работы с заказом
        public bool Open()
        {
            PrepareData();

            OrderWindow = new OrderWindow(this);
            bool dialogResult = OrderWindow.ShowDialog() ?? false;

            return dialogResult;
        }

        // Работаем со справочником сотрудников
        public Employee EmployeeItem
        {
            get { return Order.Employee!; }
            set
            {
                if (Order.Employee == value) return;
                Order.EmployeeId = value.EmployeeId;

                // Свойство изменено
                OnPropertyChanged("EmployeeItem");
            }
        }

        // Работаем с тегами
        public string TagsStringEditable
        {
            get { return Order.TagsString ?? ""; }
            set
            {
                Order.Tags = new();
                if (Order.TagsString == value || value?.Trim() == "" || value == null) return;

                string[] tags = value.Split(";");
                for (int i = 0; i < tags.Length; i++)
                {
                    Order.Tags.Add(new Tag()
                    {
                        Name = tags[i].Trim(),
                        SortNumber = i
                    });
                }

                // Свойство изменено
                OnPropertyChanged("TagsString2");
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
