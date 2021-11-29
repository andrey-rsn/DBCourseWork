using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KyrsovayaRabota
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private KyrsovayaRabotaDBEntities1 _context;
        public MainWindow()
        {
            InitializeComponent();
            //_context=KyrsovayaRabotaDBEntities1.getContext();
        }
      // public static KyrsovayaRabotaDBEntities1 _context;
      //
      // public static KyrsovayaRabotaDBEntities1 getContext()
      // {
      //     if (_context == null)
      //         _context = new KyrsovayaRabotaDBEntities1();
      //     return _context;
      // }
      //
        private void Button1_Click_1(object sender, RoutedEventArgs e)
        {
           // var a = new UZ { CodeUz = Guid.NewGuid().ToString(), NameUz = "uzel1", i = 3, NP = 14 };
            //_context.UZ.Add(a);
            //DataGrid1.ItemsSource =  _context.Table_1.ToList();
          // _context.SaveChanges();
        }

        private void GoToUzButton_Click(object sender, RoutedEventArgs e)
        {
            Uzel taskWindow = new Uzel();
            taskWindow.CodeUzTextBox.Text = Guid.NewGuid().ToString();
            taskWindow.CodeUzTextBox.IsReadOnly = true;
            taskWindow.Show();
            MainWindow mainWindow = this;
            mainWindow.Hide();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
