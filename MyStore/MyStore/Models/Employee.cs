using System;

namespace MyStore.Models
{
    public interface IEmployee
    {
        int EmployeeId { get; set; }
        string? LastName { get; set; }
        string? FirstName { get; set; }
        string? MiddleName { get; set; }
        DateTime BirthDate { get; set; }
        Sex Sex { get; set; }
    }
    public class Employee : IEmployee
    {
        public int EmployeeId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }

        public string? FullName
        {
            get
            {
                return string.Join(" ", LastName, FirstName, MiddleName, BirthDate.ToShortDateString());
            }
        }

        // ссылка на подразделение
        public int? DepartamentId { get; set; }
        public Departament? Departament { get; set; }
    }
}
