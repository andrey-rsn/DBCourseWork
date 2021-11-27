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
    /// Логика взаимодействия для Se.xaml
    /// </summary>
    public partial class Se : Window
    {
        public Se()
        {
            InitializeComponent();
        }

        private void AddDetButton_Click(object sender, RoutedEventArgs e)
        {
            
            if(this.PsiPTextBox.Text==""||this.TrTypeCombobox.Text==""||this.boTextBox.Text == ""|| this.NTextBox.Text == "")
            {
                MessageBox.Show("Заполните обязательные параметры", "Внимание!");
            }
            else
            {
                Det taskWindow = new Det(this.TrTypeCombobox.Text,(float)Convert.ToDouble(this.PsiPTextBox.Text), (float)Convert.ToDouble(this.NTextBox.Text),(float)Convert.ToDouble(this.boTextBox.Text));
                taskWindow.CodeDet1TextBox.Text = Guid.NewGuid().ToString();
                taskWindow.CodeDet2TextBox.Text = Guid.NewGuid().ToString();
                taskWindow.Show();
                this.Hide();
            }
            
        }
    }
}
