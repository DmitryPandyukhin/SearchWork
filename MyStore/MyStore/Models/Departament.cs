using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
    public interface IDepartament
    {
        public int DepartamentId { get; set; }
        public string Name { get; set; }
    }
    public class Departament : IDepartament
    {
        public int DepartamentId { get; set; }
        public string Name { get; set; } = "";

        // Ссылка на руководителя.
        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }

        [InverseProperty("Departament")]
        public virtual ObservableCollection<Employee>? Employees { get; set; }
    }
}
