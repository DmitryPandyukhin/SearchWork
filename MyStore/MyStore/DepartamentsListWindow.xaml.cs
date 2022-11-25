using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace MyStore
{
    /// <summary>
    /// Логика взаимодействия для DepartamentsWindow.xaml
    /// </summary>
    public partial class DepartamentsListWindow : Window
    {
        MyStoreContext db = new MyStoreContext();
        public DepartamentsListWindow()
        {
            InitializeComponent();

            Loaded += DepartamentsWindow_Loaded;
        }

        private void DepartamentsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // загружаем данные из БД
            db.Departaments.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Departaments.Local.ToObservableCollection();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            db.Employees.Load();

            DepartamentWindow DepartamentWindow = new DepartamentWindow(new Departament());
            if (DepartamentWindow.ShowDialog() == true)
            {
                Departament Departament = DepartamentWindow.Departament;
                db.Departaments.Add(Departament);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Departament? departament = departamentList.SelectedItem as Departament;
            // если ни одного объекта не выделено, выходим
            if (departament is null) return;

            DepartamentWindow DepartamentWindow = new DepartamentWindow(new Departament
            {
                DepartamentId = departament.DepartamentId,
                Name = departament.Name
            });

            if (DepartamentWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                departament = db.Departaments.Find(DepartamentWindow.Departament.DepartamentId);
                if (departament != null)
                {
                    departament.Name = DepartamentWindow.Departament.Name;

                    db.SaveChanges();
                    departamentList.Items.Refresh();
                }
            }
        }

        // удаление
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Departament? departament = departamentList.SelectedItem as Departament;
            // если ни одного объекта не выделено, выходим
            if (departament is null) return;
            db.Departaments.Remove(departament);
            db.SaveChanges();
        }

        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
