using System.Collections.Generic;

namespace MyStore.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        // TODO
        public string? Name { get; set; }
        // Порядок отображения тегов заказа.
        public int SortNumber { get; set; }

        // ссылка на заказ
        public int OrderId { get; set; }
        // TODO
        public Order Order { get; set; }
    }
}
