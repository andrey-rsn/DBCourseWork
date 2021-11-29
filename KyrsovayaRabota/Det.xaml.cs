
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
    /// Логика взаимодействия для Det.xaml
    /// </summary>
    public partial class Det : Window
    {
        private AppDbContext _context;
        private Se _se;
        //private readonly string _TrType;
        //private readonly double _PsiP;
        //private readonly double _N;
        //private readonly double _bo;
        private double _n1;
        //private int _m;
        //private double _h;
        //private double _z1;
        private double _n2;
        private double _y;
        //private double _q;
        //private double _Ip;
        //private double _br;
        //private double _F_okr;
        //private double _C1;
        //private double _da1;
        //private double _b;
        //private double _del_tk;
        //private double _e;
        //private double _u;
        //private double _z2;
        //private double _a_min;
        //private double _a_max;
        //private double _a;
        //private double _a1;
        //private double _z0;
        //private double _F_pred;
        private string _CodeDet1;
        private string _NameDet1;
        private string _CodeDet2;
        private string _NameDet2;
        //private string _CodeSe;
        //private string _NameSe;

        public Det(SEModelView sEModelView)
        {
            InitializeComponent();
            this.n1TextBox.Text = sEModelView.n1.ToString();
            this.n2TextBox.Text = sEModelView.n2.ToString();
            this.yTextBox.Text = sEModelView.y.ToString();
            this.CodeDet1TextBox.Text = sEModelView.CodeDet1.ToString();
            this.CodeDet2TextBox.Text = sEModelView.CodeDet2.ToString();
            this.NameDet1TextBox.Text = sEModelView.NameDet1.ToString();
            this.NameDet2TextBox.Text = sEModelView.NameDet2.ToString();
        }
        public Det(Se se)
        {
            InitializeComponent();
            // _TrType = trType;
            // _PsiP = psiP;
            // _N = N;
            // _bo = bo;
            // _se = se;
            //_CodeSe = CodeSe;
            //_NameSe = NameSe;
            //_context = AppDbContext.getContext();
            _se = se;
        }
        
        public Det(Se se,Det det)
        {
            InitializeComponent();
            this.n1TextBox.Text = det.n1TextBox.Text;
            this.n2TextBox.Text = det.n2TextBox.Text;
            this.yTextBox.Text = det.yTextBox.Text;
            this.CodeDet1TextBox.Text = det.CodeDet1TextBox.Text;
            this.CodeDet2TextBox.Text = det.CodeDet2TextBox.Text;
            this.NameDet1TextBox.Text = det.NameDet1TextBox.Text;
            this.NameDet2TextBox.Text = det.NameDet2TextBox.Text;
            _se = se;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _context=new AppDbContext();

            if (this.n1TextBox.Text==""||this.n2TextBox.Text==""||!Double.TryParse(this.n1TextBox.Text,out var a)|| !Double.TryParse(this.n2TextBox.Text, out var b))
            {
                if((!Double.TryParse(this.n1TextBox.Text, out var c)  || !Double.TryParse(this.n2TextBox.Text, out var d))&&(!int.TryParse(this.n1TextBox.Text, out var w) || !int.TryParse(this.n2TextBox.Text, out var f)))
                {
                    MessageBox.Show("Параметры заполнены неверно", "Внимание!");
                }
                else 
                {
                    MessageBox.Show("Заполните обязятельные параметры", "Внимание!");
                }
                
            }
            else
            {
                _n1 = Convert.ToDouble(this.n1TextBox.Text);//
                _n2 = Convert.ToDouble(this.n2TextBox.Text);//
                _y = 50;
                _CodeDet1 = this.CodeDet1TextBox.Text;
                _CodeDet2 = this.CodeDet2TextBox.Text;
                _NameDet1 = this.NameDet1TextBox.Text;
                _NameDet2 = this.NameDet2TextBox.Text;

                if (_context.DET.Find(_CodeDet1)==null)
                { 
                _context.DET.Add(new DET { CodeDET = _CodeDet1, a1 = 0, b = 0, C1 = 0, da = 0, n1 = _n1, n2 = _n2, NameDET = _NameDet1, y = _y, z1 = 0, z2 = 0 });
                
                _context.DET.Add(new DET { CodeDET = _CodeDet2, a1 = 0, b = 0, C1 = 0, da = 0, n1 = _n1, n2 = _n2, NameDET = _NameDet2, y = _y, z1 = 0, z2 = 0 });
                }
                else
                {
                    var detail1 = _context.DET.Find(_CodeDet1);
                    var detail2 = _context.DET.Find(_CodeDet2);
                    detail1.n1 = _n1;
                    detail1.n2 = _n2;
                    detail1.NameDET = _NameDet1;
                    detail1.y = _y;
                    detail2.n1 = _n1;
                    detail2.n2 = _n2;
                    detail2.NameDET = _NameDet2;
                    detail2.y = _y;
                }
                _context.SaveChanges();

                // Se taskWindow = new Se(_se,this, _m, _h, _q, _Ip, _br, _F_okr, _del_tk, _e, _u,_a_min, _a_max, _a, _a1, _z0,_y,_da1,_b);
                Se taskWindow = new Se(this,_se);
                taskWindow.AddDetButton.Visibility=Visibility.Hidden;
                taskWindow.ChangeDet.Visibility=Visibility.Visible;
                taskWindow.Show();
                this.Hide();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            _se.Show();
            this.Hide();
        }
    }
}
