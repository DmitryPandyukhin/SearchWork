using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MyStore.Models;
using MyStore.Views;
using MyStore.Services;

namespace MyStore.ViewModels
{
    public class OrderViewModel : NotifyPropertyChanged
    {
        RelayCommand? okCommand;
        OrderWindow? OrderWindow { get; set; }

        // данные формы
        public Order Order { get; set; }
        public ObservableCollection<Employee>? Employees { get; set; }

        public OrderViewModel(IDataService dataService, IOrder order)
        {
            Order = (Order)order;
            
            // Справочник сотрудников.
            Employees = dataService.GetEmloyeesList();
        }

        public bool OpenWindow()
        {
            // Открываем окно
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
                Order.Employee = value;

                // Свойство изменено
                OnPropertyChanged("EmployeeItem");
            }
        }

        public string TagsStringEditable
        {
            get { return Order.TagsString ?? ""; }
            set
            {
                if (Order.TagsString == value) return;

                Order.Tags = new();

                // Парсим строку с тегами.
                string[] tags = value.Split(",");
                for (int i = 0; i < tags.Length; i++)
                {
                    Order.Tags.Add(new Tag()
                    {
                        Name = tags[i].Trim(),
                        SortNumber = i
                    });
                }

                // Свойство изменено
                OnPropertyChanged("TagsStringEditable");
            }
        }

        public RelayCommand OkCommand
        {
            get
            {
                return
                  (okCommand = new RelayCommand((o) =>
                  {
                      if (OrderWindow != null)
                          OrderWindow.DialogResult = true;
                  }));
            }
        }
    }
}
