
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
        private readonly string _TrType;
        private readonly float _PsiP;
        private readonly float _N;
        private readonly float _bo;
        private float _n1;
        private int _m;
        private float _h;
        private float _z1;
        private float _n2;
        private float _y;
        private float _q;
        private float _Ip;
        private float _br;
        private float _F_okr;
        private float _C1;
        private float _da1;
        private float _b;
        private float _del_tk;
        private float _e;
        private float _u;
        private float _z2;
        private float _a_min;
        private float _a_max;
        private float _a;
        private float _a1;
        private float _z0;
        private float _F_pred;

        public Det(string trType, float psiP, float N, float bo)
        {
            InitializeComponent();
            _TrType = trType;
            _PsiP = psiP;
            _N = N;
            _bo = bo;
            //_context = AppDbContext.getContext();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _context=new AppDbContext();
            _n1 = (float) Convert.ToDouble(this.n1TextBox.Text);
            _n2= (float)Convert.ToDouble(this.n2TextBox.Text);
            _y= (float)Convert.ToDouble(this.yTextBox.Text);
            //_context = new KyrsovayaRabotaDBEntities1();
            
            if (this.yTextBox.Text == ""||this.n1TextBox.Text==""||this.n2TextBox.Text=="")
            {
                MessageBox.Show("Заполните обязятельные параметры", "Внимание!");
            }
            else
            {
                _m = (int)Math.Round(Math.Pow(35 * (_N / _n1),(1/3)));
                if(_m==1)
                {
                    _m = 2;
                }
                _h = 0.6f * _m;
                if(_TrType=="1x7")
                {
                    _z1 = (float)_context.Table_2.Where(x => x.m == _m && x.n1_l <= _n1 && x.n1_h >= _n1).Select(x => x.z1).FirstOrDefault();
                }
                else
                {
                    _z1 = (float)_context.Table_2.Where(x => x.m == _m && x.n1_l <= _n1 && x.n1_h >= _n1 && x.is_suitable == true).Select(x => x.z1).FirstOrDefault();
                }

                _q = (float)_context.Table_1.Where(x => x.m == _m && x.TrType == _TrType).Select(x => x.q).FirstOrDefault();

                _Ip= (float)_context.Table_1.Where(x => x.m == _m && x.TrType == _TrType).Select(x => x.Ip).FirstOrDefault();

                _br=(float)_context.Table_3.Where(x=>x.b>=_PsiP*_m).Select(x=>x.b).FirstOrDefault();

                _F_okr = (float)(1.91 * Math.Pow(10, 7) * _N / (_z1 * _n1 * _m));

                _C1 = (float)(0.15 * _F_okr* _Ip * _z1 / _br);

                _da1 = _m * _z1 - 2 * _bo + _C1;

                _y = 50f;

                _b =(float) Math.Sqrt((4 * _h / (_da1 * Math.Cos(_y))));

                _del_tk = (float)(0.45 * _F_okr * _Ip / _b);

                _e = (float)_context.Table_1.Where(x => x.m == _m && x.TrType == _TrType).Select(x => x.e).FirstOrDefault();

                _n2 = (float)Convert.ToDouble(this.n2TextBox.Text);

                _u = _n1 / _n2;

                _z2 = _z1 * _u;

                _a_min = (float)(0.5 * _m * (_z1 + _z2) + 2 * _m);

                _a_max = (float)(2 * _m * (_z1 + _z2));

                _a = (_a_max + _a_min) / 2;

                _a1 = (float)(180 - (_m * (_z2 - _z1) / _a) * 57.3);

                _z0 = _z1 * _a1 / 360;

                _F_pred= (float)((_h * Math.Tan(_y) - 0.5 * _da1 * (_b - Math.Sin(_b)) + _del_tk)*_b)/ ((_e / _z0) + _Ip);
            }
        }
    }
}
