using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyStore
{
    // Реализация INotifyPropertyChanged позволяет уведомлять систему об изменении значений свойств.
    public class Employee : INotifyPropertyChanged
    {
        public int EmployeeId { get; set; }
        public string? lastName;
        public string? firstName;
        public string? middleName;
        public DateTime birthDate;
        public Sex sex;
        public int? departamentId;

        [Required]
        public string? LastName 
        { 
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        [Required]
        public string? FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string? MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }
        [Required]
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }
        public Sex Sex
        {
            get { return sex; }
            set
            {
                sex = value;
                OnPropertyChanged("Sex");
            }
        }

        // ссылка на отдел: много сотрудников - один отдел
        // это свойство меняется, поэтому также уведомляем об этом систему.
        public int? DepartamentId
        {
            get { return departamentId; }
            set
            {
                departamentId = value;
                OnPropertyChanged("DepartamentId");
            }
        }

        public Departament? Departament { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public enum Sex : int
    {
        неизвестен = 0,
        мужской = 1,
        женский = 2
    }
}
