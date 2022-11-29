using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MyStore.Models;

namespace MyStore.ViewModels
{
    public class EmployeeViewModel
    {
        public ObservableCollection<Departament>? Departaments { get; set; }
        public ObservableCollection<string?>? Sexs { get; set; }
        public Employee Employee { get; set; }
        EmployeeWindow? EmployeeWindow { get; set; }
        RelayCommand? okCommand;
        public EmployeeViewModel(Employee employee)
        {
            Employee = employee;
        }

        private void PrepareData()
        {
            using (MyStoreContext db = new())
            {
                // Загружаем справочник подразделений
                db.Departaments.Load();
                Departaments = db.Departaments.Local.ToObservableCollection();
            }

            // Устанавливаем выбранное подразделение
            Employee.Departament = Departaments.FirstOrDefault(d => d.DepartamentId == Employee.DepartamentId);

            // Получаем справочник половой принадлежности.
            Sexs = new(Enum.GetNames(typeof(Sex)));
            Sexs.Insert(0, null);
        }

        // Открываем окно работы с сотрудником
        public bool Open()
        {
            PrepareData();

            // Передача контекста
            EmployeeWindow = new EmployeeWindow(this);
            bool dialogResult = EmployeeWindow.ShowDialog() ?? false;

            return dialogResult;
        }

        // Работаем со справочником подразделений
        public Departament DepartamentItem
        {
            get { return Employee.Departament!; }
            set
            {
                if (Employee.Departament == value) return;
                Employee.DepartamentId = value.DepartamentId;
                OnPropertyChanged("DepartamentItem");
            }
        }

        // Работаем со справочником половой принадлежности
        public string SexItem
        {
            get { return Employee.Sex.ToString()!; }
            set
            {
                if (Employee.Sex.ToString() == value) return;
                Enum.TryParse(value, out Sex sex);
                Employee.Sex = sex;
                OnPropertyChanged("SexItem");
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
                      if (EmployeeWindow != null)
                          EmployeeWindow.DialogResult = true;
                  }));
            }
        }
    }
}
