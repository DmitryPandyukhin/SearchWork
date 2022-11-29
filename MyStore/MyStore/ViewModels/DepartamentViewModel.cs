using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MyStore.Views;

namespace MyStore.ViewModels
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

        private void PrepareData()
        {
            using (MyStoreContext db = new())
            {
                // Получаем справочник сотрудников
                db.Employees.Load();
                Departament.Employees = db.Employees.Local.ToObservableCollection();
            }

            // Устанавливаем руководителя из списка сотрудников.
            Departament.Manager = Departament.Employees.FirstOrDefault(d => d.EmployeeId == Departament.ManagerId);
        }

        public bool Open()
        {
            PrepareData();

            DepartamentWindow = new DepartamentWindow(this);
            bool dialogResult = DepartamentWindow.ShowDialog() ?? false;

            return dialogResult;
        }

        // Работаем со справочником сотрудников. Получаем или записываем информацию о руководителе
        public Employee ManagerItem
        {
            get { return Departament.Manager!; }
            set
            {
                if (Departament.Manager == value) return;
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
