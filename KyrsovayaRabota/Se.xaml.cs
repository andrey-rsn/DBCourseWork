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
        private AppDbContext _context;
        private Det _det;
        public Se()
        {
            InitializeComponent();
        }

        public Se(Se se,Det det)
        {
            InitializeComponent();
            _context=new AppDbContext();
            this.NameSeTextBox.Text = se.NameSeTextBox.Text;
            this.СodeSeTextBox.Text = se.СodeSeTextBox.Text;
            this.PsiPTextBox.Text = se.PsiPTextBox.Text;
            this.TrTypeCombobox.Text = se.TrTypeCombobox.Text;
            this.boTextBox.Text = se.boTextBox.Text;
            this.NTextBox.Text = se.NTextBox.Text;

            _det = det;
            this.DetLabel.IsEnabled = true;
            this.DetDataGrid.IsEnabled = true;
            this.DetDataGrid.DataContext=_context.DET.Where(x=>x.CodeDET==_det.CodeDet1TextBox.Text|| x.CodeDET == _det.CodeDet2TextBox.Text).ToList();
            
        }

        private void AddDetButton_Click(object sender, RoutedEventArgs e)
        {
            
            if(this.PsiPTextBox.Text==""||this.TrTypeCombobox.Text==""||this.boTextBox.Text == ""|| this.NTextBox.Text == ""||this.NameSeTextBox.Text=="")
            {
                MessageBox.Show("Заполните обязательные параметры", "Внимание!");
            }
            else
            {
                Det taskWindow = new Det(this.TrTypeCombobox.Text,(float)Convert.ToDouble(this.PsiPTextBox.Text), (float)Convert.ToDouble(this.NTextBox.Text),(float)Convert.ToDouble(this.boTextBox.Text),this);
                taskWindow.CodeDet1TextBox.Text = Guid.NewGuid().ToString();
                taskWindow.CodeDet2TextBox.Text = Guid.NewGuid().ToString();
                taskWindow.Show();
                this.Hide();
            }
            
        }

        private void SaveSeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.PsiPTextBox.Text == "" || this.TrTypeCombobox.Text == "" || this.boTextBox.Text == "" || this.NTextBox.Text == "" || this.NameSeTextBox.Text == "")
            {
               
                MessageBox.Show("Заполните обязательные параметры", "Внимание!");
            }
        }
    }
}
