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
    /// Логика взаимодействия для Uzel.xaml
    /// </summary>
    public partial class Uzel : Window
    {
        public Uzel()
        {
            InitializeComponent();
        }

        private void AddSeButton_Click(object sender, RoutedEventArgs e)
        {
            Se taskWindow = new Se(this);
            taskWindow.СodeSeTextBox.Text = Guid.NewGuid().ToString();
            taskWindow.СodeSeTextBox.IsReadOnly = true;
            taskWindow.Show();
            Uzel uzelWindow = this;
            uzelWindow.Hide();
        }
    }
}
