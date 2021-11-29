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
using System.Windows.Shapes;

namespace KyrsovayaRabota
{
    /// <summary>
    /// Логика взаимодействия для Calculating.xaml
    /// </summary>
    public partial class Calculating : Window
    {
        private Uzel _uzel;
        public Calculating(Uzel uzel)
        {
            InitializeComponent();
            _uzel = uzel;
        }

        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow taskWindow=new MainWindow();
            taskWindow.Show();
            this.Hide();
        }
    }
}
