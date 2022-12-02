using System.Collections.ObjectModel;
using System.Linq;

namespace MyStore.Models
{
    public interface IOrder
    {
        int OrderId { get; set; }
        int Number { get; set; }
        string? ProductName { get; set; }
    }
    public class Order : NotifyPropertyChanged, IOrder
    {
        public int OrderId { get; set; }
        public int Number { get; set; }
        public string? ProductName { get; set; }

        public int? EmployeeId { get; set; }
        // Ссылка на сотрудника
        public Employee? Employee { get; set; }

        // один заказ - много тегов
        public virtual ObservableCollection<Tag>? Tags { get; set; }

        // Для отображения в списке заказов.
        public string? TagsString
        {
            get
            {
                var tags = Tags?.Select(t => t.Name)?.ToList();

                string? tagsString = null;
                if (tags != null)
                    tagsString = string.Join(", ", tags!);

                return tagsString;
            }
        }
    }
}
