using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyStore
{
    public class DepartamentViewModel
    {
        public Departament Departament { get; set; }
        DepartamentWindow? DepartamentWindow { get; set; }
        RelayCommand? okCommand;
        public DepartamentViewModel(Departament departament)
        {
            Departament = departament;
        }

        public bool Open()
        {
            bool dialogResult;
            using (MyStoreContext db = new MyStoreContext())
            {
                // Получаем справочник сотрудников
                db.Employees.Load();
                Departament.Employees = db.Employees.Local.ToObservableCollection();

                // Устанавливаем руководителя из списка сотрудников.
                Departament.Manager = Departament.Employees.FirstOrDefault(d => d.EmployeeId == Departament.ManagerId);
                
                // Передача контекста
                DepartamentWindow = new(this);

                dialogResult = DepartamentWindow.ShowDialog() ?? false;
            }

            return dialogResult;
        }

        // Работаем со справочником сотрудников. Получаем или записываем информацию о руководителе
        public Employee ManagerItem
        {
            get { return Departament.Manager!; }
            set
            {
                if (Departament.Manager == value) return;
                Departament.Manager = value;
                Departament.ManagerId = value.EmployeeId;
                OnPropertyChanged("ManagerItem");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public RelayCommand OkCommand
        {
            get
            {
                return okCommand ??
                  (okCommand = new RelayCommand((o) =>
                  {
                      if (DepartamentWindow != null)
                          DepartamentWindow.DialogResult = true;
                  }));
            }
        }
    }
}
