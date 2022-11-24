using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyStore
{
    public class Order
    {
        public int OrderId { get; set; }
        public int Number { get; set; }
        [Required]
        public string? ProductName { get; set; }
        // Ссылка на сотрудника
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        // один заказ - много тегов
        public virtual ObservableCollection<Tag>? Tags { get; private set; }
    }
}
