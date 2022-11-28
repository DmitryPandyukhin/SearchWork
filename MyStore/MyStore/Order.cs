using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyStore
{
    public class Order : INotifyPropertyChanged
    {
        public int OrderId { get; set; }

        private int number;
        public int Number 
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        private string? productName;
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

        public int? EmployeeId { get; set; }
        // Ссылка на сотрудника
        public Employee? Employee { get; set;}

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
