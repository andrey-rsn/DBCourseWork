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
        private Se _se;
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

        public Se(Uzel uzel,SEModelView sEModelView)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _uzel = uzel;
            this.СodeSeTextBox.Text = sEModelView.CodeSE;
            this.NameSeTextBox.Text = sEModelView.NameSE;
            this.PsiPTextBox.Text = sEModelView.PsiP.ToString();
            this.TrTypeCombobox.Text = sEModelView.TrType;
            this.NTextBox.Text=sEModelView.N.ToString();
            this.boTextBox.Text=sEModelView.bo.ToString();
            _det = new Det( sEModelView);
            this.DetLabel.Visibility = Visibility.Visible;
            this.DetDataGrid.Visibility = Visibility.Visible;
            this.AddDetButton.Visibility = Visibility.Hidden;
            this.ChangeDet.Visibility = Visibility.Visible;
            var detS = _context.DET.Where(x => x.CodeDET == sEModelView.CodeDet1 || x.CodeDET == sEModelView.CodeDet2).ToList();
            var sourceList = new List<DETModelView>() { new DETModelView()
            {
                CodeDet1=detS[1].CodeDET,
                CodeDet2=detS[0].CodeDET,
                NameDet1=detS[1].NameDET,
                NameDet2=detS[0].NameDET,
                n1=detS[0].n1,
                n2=detS[0].n2,
                y=detS[0].y

            } };
            this.DetDataGrid.ItemsSource = sourceList;
        }
        public Se(Det det,Se se)
        {
            InitializeComponent();
            _context = new AppDbContext();
            this.NameSeTextBox.Text = se.NameSeTextBox.Text;
            this.СodeSeTextBox.Text = se.СodeSeTextBox.Text;
            this.PsiPTextBox.Text = se.PsiPTextBox.Text;
            this.TrTypeCombobox.Text = se.TrTypeCombobox.Text;
            this.boTextBox.Text = se.boTextBox.Text;
            this.NTextBox.Text = se.NTextBox.Text;
            this.DetLabel.Visibility = Visibility.Visible;
            this.DetDataGrid.Visibility = Visibility.Visible;
            this.AddDetButton.Visibility = Visibility.Hidden;
            this.ChangeDet.Visibility = Visibility.Visible;
            _se = se;
            _uzel = _se._uzel;
            _det = det;
            var detS = _context.DET.Where(x => x.CodeDET == _det.CodeDet1TextBox.Text || x.CodeDET == _det.CodeDet2TextBox.Text).ToList();
            var sourceList = new List<DETModelView>() { new DETModelView()
            {
                CodeDet1=detS[1].CodeDET,
                CodeDet2=detS[0].CodeDET,
                NameDet1=detS[1].NameDET,
                NameDet2=detS[0].NameDET,
                n1=detS[0].n1,
                n2=detS[0].n2,
                y=detS[0].y
               
            } };
            this.DetDataGrid.ItemsSource = sourceList;
        }

        // public Se(Se se, Det det, int m,double h,double q,double Ip,double br,double F_okr,double del_tk,double e,double u,double a_min,double a_max,double a,double a1,double z0,double y,double da1,double b)
        // {
        //     InitializeComponent();
        //     _context = new AppDbContext();
        //     this.NameSeTextBox.Text = se.NameSeTextBox.Text;
        //     this.СodeSeTextBox.Text = se.СodeSeTextBox.Text;
        //     this.PsiPTextBox.Text = se.PsiPTextBox.Text;
        //     this.TrTypeCombobox.Text = se.TrTypeCombobox.Text;
        //     this.boTextBox.Text = se.boTextBox.Text;
        //     this.NTextBox.Text = se.NTextBox.Text;
        //
        //     _det = det;
        //     this.DetLabel.Visibility = Visibility.Visible;
        //     this.DetDataGrid.Visibility = Visibility.Visible;
        //     var detS = _context.DET.Where(x => x.CodeDET == _det.CodeDet1TextBox.Text || x.CodeDET == _det.CodeDet2TextBox.Text).ToList();
        //     var sourceList = new List<DETModelView>() { new DETModelView()
        //     {
        //         CodeDet1=detS[1].CodeDET,
        //         CodeDet2=detS[0].CodeDET,
        //         NameDet1=detS[1].NameDET,
        //         NameDet2=detS[0].NameDET,
        //         a1=detS[0].a1,
        //         b=detS[0].b,
        //         C1=detS[0].C1,
        //         da=detS[0].da,
        //         n1=detS[0].n1,
        //         n2=detS[0].n2,
        //         y=detS[0].y,
        //         z1=detS[0].z1,
        //         z2=detS[0].z2
        //     } };
        //     this.DetDataGrid.ItemsSource = sourceList;
        //     _m = m;
        //     _h=h;
        //     _q=q;
        //     _Ip=Ip;
        //     _br=br;
        //     _F_okr=F_okr;
        //     _del_tk=del_tk;
        //     _e=e;
        //     _u=u;
        //     _a_min=a_min;
        //     _a_max=a_max;
        //     _a=a;
        //     _a1=a1;
        //     _z0=z0;
        //     _y = y;
        //     _da1 = da1;
        //     _b = b;
        // }

        private void AddDetButton_Click(object sender, RoutedEventArgs e)
        {
            
            if(this.PsiPTextBox.Text==""||this.TrTypeCombobox.Text==""||this.boTextBox.Text == ""|| this.NTextBox.Text == ""||this.NameSeTextBox.Text=="")
            {
                MessageBox.Show("Заполните обязательные параметры", "Внимание!");
            }
            else
            {
                Det taskWindow = new Det(this);
                taskWindow.CodeDet1TextBox.Text = Guid.NewGuid().ToString();
                taskWindow.CodeDet2TextBox.Text = Guid.NewGuid().ToString();
                taskWindow.Show();
                this.Hide();
            }
            
        }

        private void SaveSeButton_Click(object sender, RoutedEventArgs e)
        {
            _context = new AppDbContext();
            if (this.PsiPTextBox.Text == "" || this.TrTypeCombobox.Text == "" || this.boTextBox.Text == "" || this.NTextBox.Text == "" || this.NameSeTextBox.Text == ""||this.DetDataGrid.Visibility==Visibility.Hidden)
            {
               if(this.DetDataGrid.Visibility == Visibility.Hidden)
               {
                    MessageBox.Show("Добавьте детали", "Внимание!");
               }
               else 
               MessageBox.Show("Заполните обязательные параметры", "Внимание!");
            }
            else 
            { 
               if(_context.SE.Find(this.СodeSeTextBox.Text)==null)
               { 
                   _context.SE.Add(new SE(){ CodeSE=this.СodeSeTextBox.Text,NameSE=this.NameSeTextBox.Text,a_max=0,a_min=0,a=0,bo=Convert.ToDouble(this.boTextBox.Text),br=0,e=0,F_okr=0,z0=0,h=0,Ip=0,m=0,PsiP=Convert.ToDouble(this.PsiPTextBox.Text),N=Convert.ToDouble(this.NTextBox.Text),q=0,u=0,TrType=this.TrTypeCombobox.Text,del_tk=0,F_pred=0,del=0});
                   _context.Details_In_SESet.Add(new Details_In_SESet() { DETCodeDET= _det.CodeDet1TextBox.Text,SECodeSE=this.СodeSeTextBox.Text });
                   _context.Details_In_SESet.Add(new Details_In_SESet() { DETCodeDET = _det.CodeDet2TextBox.Text, SECodeSE = this.СodeSeTextBox.Text });
                   _context.SaveChanges();
               }
               else
               {
                    SE se = _context.SE.Find(this.СodeSeTextBox.Text);
                    Details_In_SESet details_In_SE1= _context.Details_In_SESet.Where(x=>x.DETCodeDET==_det.CodeDet1TextBox.Text).FirstOrDefault();
                    Details_In_SESet details_In_SE2 = _context.Details_In_SESet.Where(x => x.DETCodeDET == _det.CodeDet2TextBox.Text).FirstOrDefault();
                    se.NameSE = this.NameSeTextBox.Text;
                    se.bo = Convert.ToDouble(this.boTextBox.Text);
                    se.PsiP = Convert.ToDouble(this.PsiPTextBox.Text);
                    se.TrType = this.TrTypeCombobox.Text;
                    se.N = Convert.ToDouble(this.NTextBox.Text);
                    details_In_SE1.DETCodeDET = _det.CodeDet1TextBox.Text;
                    details_In_SE1.SECodeSE = this.СodeSeTextBox.Text;
                    details_In_SE2.DETCodeDET = _det.CodeDet2TextBox.Text;
                    details_In_SE2.SECodeSE = this.СodeSeTextBox.Text;
                    _context.SaveChanges();
                }
            //_context.SE.Add(new SE() { CodeSE = this.СodeSeTextBox.Text, NameSE = this.NameSeTextBox.Text, a_max = 0, a_min = 0, a = 0, bo = Convert.ToDouble(this.boTextBox.Text), br = 0, e = 0, F_okr = 0, z0 = 0, h = 0, Ip = 0, m = 0, PsiP = Convert.ToDouble(this.PsiPTextBox.Text), N = Convert.ToDouble(this.NTextBox.Text), q = 0, u = 0, DET_id = _det.CodeDet2TextBox.Text, TrType = this.TrTypeCombobox.Text, del_tk = 0, F_pred = 0, del = 0 });
            
            Uzel taskWindow=new Uzel(this,_uzel);
            taskWindow.SeDataGrid.Visibility = Visibility.Visible;
            taskWindow.SeLabel.Visibility = Visibility.Visible;
            taskWindow.Show();
            this.Hide();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _uzel.Show();
            this.Hide();
        }

        private void ChangeDet_Click(object sender, RoutedEventArgs e)
        {
            Det taskWindow = new Det(this,_det);
            taskWindow.Show();
            this.Hide();
        }
    }
}
