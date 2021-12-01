using KyrsovayaRabota.Data;
using KyrsovayaRabota.Logic;
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
        private AppDbContext _context;
        private List<SEModelView> _seModel;
        private List<UzelModelView> _uzelModel;
        private Calculating _calc;
        private readonly string _TrType;
        private readonly double _PsiP;
        private readonly double _N;
        private readonly double _bo;
        private double _n1;
        private int _m;
        private double _h;
        private double _z1;
        private double _n2;
        private double _y;
        private double _q;
        private double _Ip;
        private double _br;
        private double _F_okr;
        private double _C1;
        private double _da1;
        private double _b;
        private double _del_tk;
        private double _e;
        private double _u;
        private double _z2;
        private double _a_min;
        private double _a_max;
        private double _a;
        private double _a1;
        private double _z0;
        private double _F_pred;
        private string _CodeDet1;
        private string _NameDet1;
        private string _CodeDet2;
        private string _NameDet2;
        private string _CodeSe;
        private string _NameSe;
        private double _del;
        private bool _Dost;
        private string _DostStr;

        public Calculating(Uzel uzel,List<SEModelView> seModel)
        {
            InitializeComponent();
            _uzel = uzel;
            _context=new AppDbContext();
            _seModel = seModel;
            _uzelModel= new List<UzelModelView>();
            for(int i=0;i<_seModel.Count;i++)
            {
                CalcUzel.CalcUzelParam(_seModel[i].N, _seModel[i].n1, _seModel[i].n2, _seModel[i].TrType, _seModel[i].PsiP, _seModel[i].bo, _seModel[i].y, out _m, out _h, out _z1, out _q, out _Ip, out _br, out _F_okr, out _C1, out _da1, out _b, out _del_tk, out _e, out _u, out _z2, out _a, out _a_min, out _a_max, out _a1, out _z0, out _F_pred,out _del,out _Dost);
                if(_Dost)
                {
                    _DostStr = "Расчёт достоверен";
                }
                else
                {
                    _DostStr = "Расчёт недостоверен";
                }
                
                _uzelModel.Add(new UzelModelView() { CodeDet1= _seModel[i].CodeDet1,CodeDet2= _seModel[i].CodeDet2,NameDet1= _seModel[i].NameDet1,NameDet2= _seModel[i].NameDet2,NameSe= _seModel[i].NameSE,CodeSe= _seModel[i].CodeSE,CodeUz=_uzel.CodeUzTextBox.Text,NameUz=_uzel.UzNameTextBox.Text,a=_a,a1=_a1,a_max=_a_max,a_min=_a_min,b=_b,bo= _seModel[i].bo,PsiP= _seModel[i].PsiP,TrType= _seModel[i].TrType,N= _seModel[i].N,y= _seModel[i].y,n1= _seModel[i].n1, n2=_seModel[i].n2,br=_br,C1=_C1,da1=_da1,del=_del,del_tk=_del_tk,e=_e,F_okr=_F_okr,F_pred=_F_pred,h=_h,i=i,Ip=_Ip,m=_m,NP=_seModel.Count,q=_q,u=_u,z0=_z0,z1=_z1,z2=_z2 ,Dost= _DostStr });
            }
            this.UzDataGrid.ItemsSource = _uzelModel;
        }
       // public Calculating(Calculating calc)
       // {
       //     InitializeComponent();
       //     _calc = calc;
       //     _calc.
       //     _uzel = _calc._uzel;
       //     _seModel = _calc._seModel;
       //     _uzelModel = _calc._uzelModel;
       //     this.UzDataGrid.ItemsSource = _uzelModel;
       // }

        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow taskWindow=new MainWindow();
            taskWindow.Show();
            this.Hide();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool uzIsAdded=false;
            _context = new AppDbContext();
            var uzEntity = _context.UZ.Find(_uzelModel[0].CodeUz);
            for(int k=0;k<_uzelModel.Count;k++)
            {
                
                var codeSeThis = _uzelModel[k].CodeSe;
                var codeUzThis = _uzelModel[k].CodeUz;
                var res = _context.Se_In_UzSet.Where(x => x.SECodeSE == codeSeThis && x.UZCodeUz == codeUzThis).FirstOrDefault();
                if(res == null)
                {
                    if(uzEntity==null&& uzIsAdded==false)
                    {
                        _context.UZ.Add(new UZ() { CodeUz=_uzelModel[k].CodeUz,NameUz=_uzelModel[k].NameUz,NP=_uzelModel[k].NP}); 
                        uzIsAdded=true;
                    }
                    _context.Se_In_UzSet.Add(new Se_In_UzSet() { SECodeSE=_uzelModel[k].CodeSe,UZCodeUz=_uzelModel[k].CodeUz,i=_uzelModel[k].i});
                    _context.SaveChanges();
                }
               //else
               //{
               //    //var uzRes = _context.UZ.Where(x => x.CodeUz == codeUzThis).FirstOrDefault();
               //    //uzRes.NameUz = _uzelModel[k].NameUz;
               //    //uzRes.NP = _uzelModel[k].NP;
               //    
               //}
                
            }
            MessageBox.Show("Расчёт успешно сохранён в базе данных");


        }

        private void StaticTableButton_Click(object sender, RoutedEventArgs e)
        {
            StaticTables taskWindow=new StaticTables(this);
            taskWindow.Show();
            

        }

        private void BackToUzParamsButton_Click(object sender, RoutedEventArgs e)
        {
            Uzel taskWindow = new Uzel(_uzel);
            taskWindow.Show();
            this.Hide();
        }

        private void OtchetButton_Click(object sender, RoutedEventArgs e)
        {
            Analysis taskWindow = new Analysis();
            taskWindow.Show();
        }
    }
}
