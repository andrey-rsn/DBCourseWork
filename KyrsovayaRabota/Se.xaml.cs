using KyrsovayaRabota.Data;
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
        private Uzel _uzel;
        public Se(Uzel uzel)
        {
            InitializeComponent();
            _uzel = uzel;
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
            this.DetLabel.Visibility = Visibility.Visible;
            this.DetDataGrid.Visibility = Visibility.Visible;
            var detS= _context.DET.Where(x => x.CodeDET == _det.CodeDet1TextBox.Text || x.CodeDET == _det.CodeDet2TextBox.Text).ToList();
            var sourceList = new List<DETModelView>() { new DETModelView() 
            { 
                CodeDet1=detS[1].CodeDET,
                CodeDet2=detS[0].CodeDET,
                NameDet1=detS[1].NameDET,
                NameDet2=detS[0].NameDET,
                a1=detS[0].a1,
                b=detS[0].b,
                C1=detS[0].C1,
                da=detS[0].da,
                n1=detS[0].n1,
                n2=detS[0].n2,
                y=detS[0].y,
                z1=detS[0].z1,
                z2=detS[0].z2 
            } };
            this.DetDataGrid.ItemsSource = sourceList;
            
        }

        private void AddDetButton_Click(object sender, RoutedEventArgs e)
        {
            
            if(this.PsiPTextBox.Text==""||this.TrTypeCombobox.Text==""||this.boTextBox.Text == ""|| this.NTextBox.Text == ""||this.NameSeTextBox.Text=="")
            {
                MessageBox.Show("Заполните обязательные параметры", "Внимание!");
            }
            else
            {
                Det taskWindow = new Det(this.TrTypeCombobox.Text,Convert.ToDouble(this.PsiPTextBox.Text), Convert.ToDouble(this.NTextBox.Text),Convert.ToDouble(this.boTextBox.Text),this);
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _uzel.Show();
            this.Hide();
        }
    }
}
