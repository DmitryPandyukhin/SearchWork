using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyStore
{
    public class Order : INotifyPropertyChanged
    {
        public int number;
        public string? productName;
        public int? employeeId;
        public int OrderId { get; set; }
        public int Number 
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
        [Required]
        public string? ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }
        // Ссылка на сотрудника
        public int? EmployeeId
        {
            get { return employeeId; }
            set
            {
                employeeId = value;
                OnPropertyChanged("EmployeeId");
            }
        }
        public Employee? Employee { get; set; }
        // один заказ - много тегов
        public virtual ObservableCollection<Tag>? Tags { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
