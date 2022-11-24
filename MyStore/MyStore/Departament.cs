using System.Collections.Generic;

namespace MyStore
{
    public class Departament
    {
        public int DepartamentId { get; set; }
        public string? Name { get; set; }
        // ссылка на сотрудника
        public List<Employee> Employees { get; set; }
    }
}
