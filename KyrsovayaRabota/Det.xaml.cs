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
        private readonly string _TrType;
        private readonly float _PsiP;
        private readonly float _N;
        private readonly float _bo;
        public Det(string trType, float psiP, float n, float bo)
        {
            InitializeComponent();
            _TrType = trType;
            _PsiP = psiP;
            _N = n;
            _bo = bo;
        }

    }
}
