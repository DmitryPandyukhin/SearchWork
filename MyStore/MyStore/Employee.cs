using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyStore
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        // Ссылка не подразделение
        public List<Departament>? Departaments { get; set; }
        //public virtual ObservableCollection<Order> Orders { get; private set; }
        public virtual string EmployeeToString1
        {
            get
            {
                return string.Join(" ",
                    LastName,
                    FirstName,
                    MiddleName,
                    BirthDate.ToString("dd.MM.yyyy")
                    );
            }
            set { }
        }
    }
    public enum Sex : int
    {
        unknown = 0,
        male = 1,
        female = 2
    }
}
