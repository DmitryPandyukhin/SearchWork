using System.Windows;

namespace MyStore
{
    /// <summary>
    /// Логика взаимодействия для DepartamentWindow.xaml
    /// </summary>
    public partial class DepartamentWindow : Window
    {
        public Departament Departament { get; private set; }
        public DepartamentWindow(Departament departament)
        {
            InitializeComponent();
            Departament = departament;
            DataContext = Departament;
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
