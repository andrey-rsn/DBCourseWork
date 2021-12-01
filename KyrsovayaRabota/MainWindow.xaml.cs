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
        AppDbContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            this.CalcList.ItemsSource = _context.UZ.ToDictionary(x=>x.CodeUz,k=>k.NameUz);
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

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.CalcList.Text=="")
            {
                MessageBox.Show("Выберите из списка расчёт, который хотите загрузить", "Внимание!");
            }
            else
            {

                Uzel taskWindow = new Uzel(this.CalcList.Text.Substring(1, this.CalcList.Text.IndexOf(',') - 1));
                taskWindow.Show();
                this.Hide();
            }
        }
    }
}
