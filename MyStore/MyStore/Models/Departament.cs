using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MyStore.Models
{
    public class Departament : INotifyPropertyChanged
    {
        public int DepartamentId { get; set; }

        // TODO
        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private int? managerId;
        // Ссылка на руководителя.
        public int? ManagerId { get; set; }
        private Employee? manager;
        [ForeignKey("ManagerId")]
        public Employee? Manager
        {
            get { return manager; }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }
        [InverseProperty("Departament")]
        public virtual ObservableCollection<Employee>? Employees { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
