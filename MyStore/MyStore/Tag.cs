using System.Collections.Generic;
namespace MyStore
{
    public class Tag
    {
        public int TagId { get; set; }
        public string? Name { get; set; }
        
        // Порядок отображения тегов заказа.
        public int SortNumber { get; set; }
        // ссылка на заказ
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
