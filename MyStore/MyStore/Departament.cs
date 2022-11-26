using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyStore
{
    public class Departament : INotifyPropertyChanged
    {
        public string? name;
        public int DepartamentId { get; set; }
        public string? Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        // связь с сотрудниками: один отдел - много сотрудников
        public virtual ObservableCollection<Employee>? Employees { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
