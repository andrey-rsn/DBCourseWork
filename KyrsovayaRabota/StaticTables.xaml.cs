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
    /// Логика взаимодействия для StaticTables.xaml
    /// </summary>
    public partial class StaticTables : Window
    {

        Calculating _calc;
        public StaticTables(Calculating calc)
        {
            InitializeComponent();
            _calc = calc;
            AppDbContext _context=new AppDbContext();
            //calc.StaticTableButton.IsEnabled = false;

            this.Table1DataGrid.ItemsSource = _context.Table_1.ToList();
            //this.Table1DataGrid.Height = this.Table1DataGrid.RowHeight;
           //this.Table1DataGrid.Width = this.Table1DataGrid.RowHeaderWidth;

            this.Table2DataGrid.ItemsSource = _context.Table_2.ToList();
            //this.Table2DataGrid.Height = this.Table2DataGrid.RowHeight;

            this.Table3DataGrid.ItemsSource = _context.Table_3.ToList();
            //this.Table3DataGrid.Height = this.Table3DataGrid.RowHeight;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //_calc.StaticTableButton.IsEnabled = true;
            this.Hide();
        }
    }
}
