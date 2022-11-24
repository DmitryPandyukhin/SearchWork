using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        // ссылка на отдел: много сотрудников - один отдел
        public int? DepartamentId { get; set; }
        public Departament? Departament { get; set; }
    }
    public enum Sex : int
    {
        неизвестен = 0,
        мужской = 1,
        женский = 2
    }
}
