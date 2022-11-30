using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyStore.ViewModels
{
    public class DepartamentsListViewModel
    {
        MyStoreContext db = new();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<Departament> Departaments { get; set; }
        public DepartamentsListViewModel()
        {
            db.Departaments
                .Include(d => d.Employees)
                .Load();
            Departaments = db.Departaments.Local.ToObservableCollection();
            db.Employees.Load();
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      DepartamentViewModel departamentViewModel = new(new Departament());
                      if (departamentViewModel.Open() == true)
                      {
                          Departament departament = new()
                          {
                              Name = departamentViewModel.Departament.Name,
                              ManagerId = departamentViewModel.Departament.ManagerId
                          };

                          db.Departaments.Add(departament);
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда редактирования
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      Departament? departament = selectedItem as Departament;
                      // если ни одного объекта не выделено, выходим
                      if (departament is null) return;

                      Departament vm = new Departament
                      {
                          Name = departament.Name,
                          ManagerId = departament.ManagerId
                      };

                      DepartamentViewModel departamentWindow = new(vm);

                      if (departamentWindow.Open() == true)
                      {
                          departament.Name = departamentWindow.Departament.Name;
                          departament.ManagerId = departamentWindow.Departament.ManagerId;
                          departament.Manager = db.Employees.Local.First(e => e.EmployeeId == departament.ManagerId);
                          db.Entry(departament).State = EntityState.Modified;
                          db.SaveChanges();
                      }
                  }));
            }
        }
        // команда удаления
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      Departament? departament = selectedItem as Departament;
                      // если ни одного объекта не выделено, выходим
                      if (departament is null) return;
                      db.Departaments.Remove(departament);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
