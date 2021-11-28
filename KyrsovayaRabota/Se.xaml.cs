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
        private int _m;
        private double _h;
        private double _q;
        private double _Ip;
        private double _br;
        private double _F_okr;
        private double _del_tk;
        private double _e;
        private double _u;
        private double _a_min;
        private double _a_max;
        private double _a;
        private double _a1;
        private double _z0;
        private double _F_pred;
        private double _y;
        private double _b;
        private double _da1;
        private double _del;
        public Se(Uzel uzel)
        {
            InitializeComponent();
            _uzel = uzel;
        }

        public Se(Se se, Det det, int m,double h,double q,double Ip,double br,double F_okr,double del_tk,double e,double u,double a_min,double a_max,double a,double a1,double z0,double y,double da1,double b)
        {
            InitializeComponent();
            _context = new AppDbContext();
            this.NameSeTextBox.Text = se.NameSeTextBox.Text;
            this.СodeSeTextBox.Text = se.СodeSeTextBox.Text;
            this.PsiPTextBox.Text = se.PsiPTextBox.Text;
            this.TrTypeCombobox.Text = se.TrTypeCombobox.Text;
            this.boTextBox.Text = se.boTextBox.Text;
            this.NTextBox.Text = se.NTextBox.Text;

            _det = det;
            this.DetLabel.Visibility = Visibility.Visible;
            this.DetDataGrid.Visibility = Visibility.Visible;
            var detS = _context.DET.Where(x => x.CodeDET == _det.CodeDet1TextBox.Text || x.CodeDET == _det.CodeDet2TextBox.Text).ToList();
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
            _m = m;
            _h=h;
            _q=q;
            _Ip=Ip;
            _br=br;
            _F_okr=F_okr;
            _del_tk=del_tk;
            _e=e;
            _u=u;
            _a_min=a_min;
            _a_max=a_max;
            _a=a;
            _a1=a1;
            _z0=z0;
            _y = y;
            _da1 = da1;
            _b = b;
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
            _context = new AppDbContext();
            if (this.PsiPTextBox.Text == "" || this.TrTypeCombobox.Text == "" || this.boTextBox.Text == "" || this.NTextBox.Text == "" || this.NameSeTextBox.Text == "")
            {
               
                MessageBox.Show("Заполните обязательные параметры", "Внимание!");
            }
            _F_pred = Math.Round(((_h * Math.Tan(_y) - 0.5 * _da1 * (_b - Math.Sin(_b)) + _del_tk) * _b) / ((_e / _z0) + _Ip),4);
            _del = _F_pred - _F_okr;
            _context.SE.Add(new SE(){ CodeSE=this.СodeSeTextBox.Text,NameSE=this.NameSeTextBox.Text,a_max=_a_max,a_min=_a_min,a=_a,bo=Convert.ToDouble(this.boTextBox.Text),br=_br,e=_e,F_okr=_F_okr,z0=_z0,h=_h,Ip=_Ip,m=_m,PsiP=Convert.ToDouble(this.PsiPTextBox.Text),N=Convert.ToDouble(this.NTextBox.Text),q=_q,u=_u,DET_id=_det.CodeDet1TextBox.Text,TrType=this.TrTypeCombobox.Text,del_tk=_del_tk,F_pred=_F_pred,del=_del});
            _context.SE.Add(new SE() { CodeSE = this.СodeSeTextBox.Text, NameSE = this.NameSeTextBox.Text, a_max = _a_max, a_min = _a_min, a = _a, bo = Convert.ToDouble(this.boTextBox.Text), br = _br, e = _e, F_okr = _F_okr, z0 = _z0, h = _h, Ip = _Ip, m = _m, PsiP = Convert.ToDouble(this.PsiPTextBox.Text), N = Convert.ToDouble(this.NTextBox.Text), q = _q, u = _u, DET_id = _det.CodeDet2TextBox.Text, TrType = this.TrTypeCombobox.Text, del_tk = _del_tk, F_pred = _F_pred, del = _del });
            _context.SaveChanges();
            //UZ taskWindow=new UZ(this,);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _uzel.Show();
            this.Hide();
        }

        private void ChangeDet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
