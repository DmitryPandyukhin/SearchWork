using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MyStore
{
    // Реализация INotifyPropertyChanged позволяет уведомлять систему об изменении значений свойств.
    public class Employee : INotifyPropertyChanged
    {
        public int EmployeeId { get; set; }

        private string? lastName;
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

        private string? firstName;
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

        private string? middleName;
        public string? MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private DateTime birthDate;
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

        public Sex Sex { get; set; }

        // ссылка на подразделение
        public int? DepartamentId { get; set; }
        public Departament? Departament { get; set; }

        // При отсутствии сеттера поле в БД создано не будет
        public virtual string? FullName
        {
            get => string.Join(" ", lastName, firstName, middleName, birthDate.ToShortDateString());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Employee ShallowCopy()
        {
            return (Employee)this.MemberwiseClone();
        }
    }
}
