using System;
using System.Collections.Generic;
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
        public virtual string EmployeeToString
        {
            get
            {
                return string.Join(" ",
                    Employee?.LastName,
                    Employee?.FirstName,
                    Employee?.MiddleName,
                    Employee?.BirthDate.ToString("dd.MM.yyyy")
                    );
            }
            set { }
        }
        // При добавлении нового заказа необходимо выбирать из списка сотрудников
        public virtual ObservableCollection<Employee>? Employees { get; set; }
    }
}
