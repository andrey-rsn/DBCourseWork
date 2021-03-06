using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyrsovayaRabota.Logic
{
    public static class CalcUzel
    {
        public static void CalcUzelParam (double _N,double _n1,double _n2,string _TrType,double _PsiP,double _bo,double _y,out int _m, out double _h, out double _z1, out double _q, out double _Ip, out double _br, out double _F_okr, out double _C1, out double _da1, out double _b, out double _del_tk, out double _e, out double _u, out double _z2,out double _a, out double _a_min, out double _a_max, out double _a1, out double _z0, out double _F_pred,out double _del,out bool _Dost)
        {
            AppDbContext _context = new AppDbContext();

            _m = 0;
            _h = 0;
            _z1 = 0;
            _q = 0;
            _Ip = 0;
            _br = 0;
            _F_okr = 0;
            _C1 = 0;
            _da1 = 0;
            _b = 0;
            _del_tk = 0;
            _e = 0;
            _u = 0;
            _z2 = 0;
            _a = 0;
            _a_min = 0;
            _a_max = 0;
            _a1 = 0;
            _z0 = 0;
            _F_pred = 0;
            _del = 0;
            
            while (true)
            { 
                int m;
                m = (int)Math.Round(35*(Math.Pow( (_N / _n1),(1.0/3.0))));
                if (m <=0||m<=1||m==8||m>=10)
                {
                    _Dost = false;
                    break;
                }

                if (m==1||m==6||m==9)
                {
                   m++;
                }
                _h = Math.Round(0.6 * m,4);
                if(_TrType.Replace(" ", "")== "1x7")
                {
                    _z1 = _context.Table_2.Where(x => x.m == m && x.n1_l <= _n1 && x.n1_h >= _n1).Select(x => x.z1).FirstOrDefault();
                }
                else
                {
                    _z1 = _context.Table_2.Where(x => x.m == m && x.n1_l <= _n1 && x.n1_h >= _n1 && x.is_suitable == true).Select(x => x.z1).FirstOrDefault();
                }
                if(_z1==0)
                {
                    _Dost = false;
                    break;
                }
            
                _q = _context.Table_1.Where(x => x.m == m && x.TrType == _TrType).Select(x => x.q).FirstOrDefault();
                if(_q==0)
                {
                    _Dost = false;
                    break;
                }
            
                _Ip= _context.Table_1.Where(x => x.m == m && x.TrType == _TrType).Select(x => x.Ip).FirstOrDefault();
                if (_Ip == 0)
                {
                    _Dost = false;
                    break;
                }

                _br =_context.Table_3.Where(x=>x.b>=_PsiP*m).Select(x=>x.b).FirstOrDefault();
                if (_br == 0)
                {
                    _Dost = false;
                    break;
                }

                _F_okr = Math.Round((1.91 * Math.Pow(10, 7) * _N / (_z1 * _n1 * m)),4);
            
                _C1 = Math.Round((0.15 * _F_okr* _Ip * _z1 / _br),4);//
            
                _da1 = Math.Round(m * _z1 - 2 * _bo + _C1,4);//
                 if(_da1<=0)
                {
                    _Dost = false;
                    break;
                }
            
                _b = Math.Round(Math.Sqrt((4 * _h / (_da1 * Math.Round(Math.Cos(_y*Math.PI/180),4)))),4);//
            
                _del_tk = Math.Round((0.45 * _F_okr * _Ip / _br),4);
            
                _e = _context.Table_1.Where(x => x.m == m && x.TrType == _TrType).Select(x => x.e).FirstOrDefault();
                if (_e == 0)
                {
                    _Dost = false;
                    break;
                }

                //_n2 = Convert.ToDouble(this.n2TextBox.Text);//

                _u = Math.Round(_n1 / _n2,4);
            
                _z2 = Math.Round(_z1 * _u);//
            
                _a_min = (0.5 * m * (_z1 + _z2) + 2 * m);
            
                _a_max = (2 * m * (_z1 + _z2));
            
                _a = Math.Round((_a_max + _a_min) / 2,4);
            
                _a1 = Math.Round((180 - (m * (_z2 - _z1) / _a) * 57.3),4);//
            
                _z0 = Math.Round(_z1 * _a1 / 360);
                _m = m;

                _F_pred= Math.Round(((_h * Math.Tan(_y * Math.PI / 180) - 0.5 * _da1 * (_b - Math.Sin(_b * Math.PI / 180)) + _del_tk)*_br)/ ((_e / _z0) + _Ip),4);

                _del = _F_pred - _F_okr;
                if(_del>=0)
                {
                    _Dost = true;
                    break;
                }
                else
                {
                    _Dost = false;
                    break;
                }
            }
        }
    }
}
