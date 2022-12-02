using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.Services;
using System.Collections.ObjectModel;
using System.Linq;
using MyStore.Views;
using System.Xml.Linq;

namespace MyStore.ViewModels
{
    public class DepartamentsListViewModel
    {
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        DepartamentsListWindow DepartamentsListWindow { get; }

        DataService DataService { get; }
        public ObservableCollection<Departament> Departaments { get; set; }
        public DepartamentsListViewModel(IDataService dataService)
        {
            DataService = (DataService)dataService;

            Departaments = DataService.GetDepartamentsList();

            DepartamentsListWindow = new DepartamentsListWindow(this);
            DepartamentsListWindow.ShowDialog();
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return 
                    (addCommand = new RelayCommand((o) =>
                    {
                        Departament vm = new ();
                        if (new DepartamentViewModel(DataService, vm).OpenWindow())
                            DataService.AddDepartament(vm);
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
                      if (selectedItem is not Departament departament) return;

                      Departament vm = new ()
                      {
                          Name = departament.Name,
                      };
                      if (departament?.Manager != null)
                          vm.Manager = (Employee?)DataService.GetEmloyee(departament.Manager.EmployeeId);

                      if (new DepartamentViewModel(DataService, vm).OpenWindow())
                      {
                          departament!.Name = vm.Name;
                          if (vm.Manager != null)
                              departament.Manager = (Employee?)DataService.GetEmloyee(vm.Manager.EmployeeId);

                          DataService.EditDepartament(departament);
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
                      // если ни одного объекта не выделено, выходим
                      if (selectedItem is not Departament departament) return;

                      DataService.DeleteDepartament(departament);
                  }));
            }
        }
    }
}
