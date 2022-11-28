using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MyStore
{
    public class EmployeeViewModel
    {
        MyStoreContext db = new();
        public ObservableCollection<Departament> Departaments { get; set; }
        public ObservableCollection<string?> Sexs { get; set; }
        public Employee Employee{ get; set; }
        EmployeeWindow? EmployeeWindow { get; set; }
        RelayCommand? okCommand;
        public EmployeeViewModel(Employee employee) 
        {
            // Загружаем справочник подразделений
            db.Departaments.Load();
            Departaments = db.Departaments.Local.ToObservableCollection();
            // Устанавливаем выбранное подразделение
            employee.Departament = Departaments.FirstOrDefault(d => d.DepartamentId == employee.DepartamentId);

            // Получаем спраочник половой принадлежности.
            Sexs = new (Enum.GetNames(typeof(Sex)));
            Sexs.Insert(0, null);


            // Добавляем в контекст
            Employee = employee;
        }

        // Открываем окно работы с сотрудником
        public bool Open()
        {
            // Передача контекста
            EmployeeWindow = new(this);

            if (EmployeeWindow.ShowDialog() == true)
                return true;
            else
                return false;
        }

        // Работаем со справочником подразделений
        public Departament DepartamentItem
        {
            get { return Employee.Departament!; }
            set
            {
                if (Employee.Departament == value) return;
                Employee.Departament = value;
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
