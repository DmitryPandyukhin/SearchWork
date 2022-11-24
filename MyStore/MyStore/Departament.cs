using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyStore
{
    public class Departament
    {
        public int DepartamentId { get; set; }
        public string? Name { get; set; }
        // связь с сотрудниками: один отдел - много сотрудников
        public virtual ObservableCollection<Employee>? Employees { get; private set; }
    }
}
