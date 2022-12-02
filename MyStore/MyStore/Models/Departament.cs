using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
    public interface IDepartament
    {
        public int DepartamentId { get; set; }
        public string Name { get; set; }
    }
    public class Departament : NotifyPropertyChanged, IDepartament
    {
        public int DepartamentId { get; set; }
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged("Name");
            }
        }

        // Ссылка на руководителя.
        public int? ManagerId { get; set; }
        Employee? manager;
        public Employee? Manager
        {
            get { return manager; }
            set
            {
                if (manager == value) return;
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        [InverseProperty("Departament")]
        public virtual ObservableCollection<Employee>? Employees { get; set; }
    }
}
