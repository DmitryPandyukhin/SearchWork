using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.Services;
using MyStore.Views;

namespace MyStore.ViewModels
{
    public class EmployeesListViewModel
    {
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;

        IDataService DataService { get; }

        EmployeesListWindow EmployeesListWindow { get; }
        public ObservableCollection<Employee>? Employees { get; set; }
        public EmployeesListViewModel(IDataService dataService)
        {
            Employees = dataService.GetEmloyeesList();

            this.DataService = dataService;

            EmployeesListWindow = new EmployeesListWindow(this);
            EmployeesListWindow.ShowDialog();
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return 
                  (addCommand = new RelayCommand((o) =>
                  {
                      Employee vm = new() { BirthDate = DateTime.Now };
                      if (new EmployeeViewModel(DataService, vm).OpenWindow())
                      {
                          DataService.AddEmloyee(vm);
                      };
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return 
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      // если ни одного объекта не выделено, выходим
                      if (selectedItem is not Employee employee) return;

                      Employee vm = new()
                      {
                          LastName = employee.LastName,
                          FirstName = employee.FirstName,
                          MiddleName = employee.MiddleName,
                          BirthDate = employee.BirthDate,
                          Sex = employee.Sex,
                      };
                      if (employee.Departament != null)
                          vm.Departament = (Departament?)DataService.GetDepartament(employee.Departament.DepartamentId);

                      if (new EmployeeViewModel(DataService, vm).OpenWindow())
                      {
                          employee.LastName = vm.LastName;
                          employee.FirstName = vm.FirstName;
                          employee.MiddleName = vm.MiddleName;
                          employee.BirthDate = vm.BirthDate;
                          employee.Sex = vm.Sex;
                          if (vm.Departament != null)
                            employee.Departament = (Departament?)DataService.GetDepartament(vm.Departament.DepartamentId);

                          DataService.EditEmloyee(employee);
                      }
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      if (selectedItem is not Employee employee) return;

                      DataService.DeleteEmloyee(employee);
                  }));
            }
        }
    }
}
