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
        private KyrsovayaRabotaDBEntities1 _context;
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
        
        public Det(string trType, float psiP, float N, float bo)
        {
            InitializeComponent();
            _TrType = trType;
            _PsiP = psiP;
            _N = N;
            _bo = bo;
            _context = KyrsovayaRabotaDBEntities1.getContext();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
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
                    //_z1 = (float)
                    //var a=_context.Table_2.Where(x => x.m == _m && x.n1_l <= _n1 && x.n1_h >= _n1);
                    var a = _context.Table_1.Where(x => x.m == 2).FirstOrDefault();
                }
                else
                {
                    _z1 = (float)_context.Table_2.Where(x => x.m == _m && x.n1_l <= _n1 && x.n1_h >= _n1 && x.is_suitable == true).Select(x => x.z1).FirstOrDefault();
                }
                

            }
        }
    }
}
