using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace MyStore
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
            db.Departaments.Load();
            Departaments = db.Departaments.Local.ToObservableCollection();
        }
        // команда добавления
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      DepartamentWindow departamentWindow = new(new Departament());
                      if (departamentWindow.ShowDialog() == true)
                      {
                          Departament departament = departamentWindow.Departament;
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
                          Name = departament.Name
                      };

                      DepartamentWindow departamentWindow = new DepartamentWindow(vm);

                      if (departamentWindow.ShowDialog() == true)
                      {
                          departament.Name = departamentWindow.Departament.Name;
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
