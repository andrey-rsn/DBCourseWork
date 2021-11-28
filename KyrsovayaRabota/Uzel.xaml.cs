﻿using KyrsovayaRabota.Data;
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
    /// Логика взаимодействия для Uzel.xaml
    /// </summary>
    public partial class Uzel : Window
    {
        private List<SEModelView> _seModel;
        private AppDbContext _context;
        private Uzel _uzel;
        public Uzel()
        {
            InitializeComponent();
        }
        public Uzel(Se se,Uzel uzel)
        {
            InitializeComponent();
            _uzel = uzel;
            _context = new AppDbContext();
            this.UzNameTextBox.Text = uzel.UzNameTextBox.Text;
            this.CodeUzTextBox.Text = uzel.CodeUzTextBox.Text;
            var seSource = _context.SE.Where(x => x.CodeSE == se.СodeSeTextBox.Text).FirstOrDefault();
            var detSource = _context.Details_In_SESet.Join(_context.DET,
                          p => p.DETCodeDET,
                          t => t.CodeDET,
                          (p,t)=>new {CodeDet=t.CodeDET,NameDet=t.NameDET,y=t.y,n1=t.n1,n2=t.n2}
                          ).ToList();
            _seModel = _uzel._seModel;
            if(_seModel==null)
            {
                _seModel=new List<SEModelView>() { new SEModelView() {CodeDet1=detSource[0].CodeDet,NameDet1=detSource[0].NameDet, CodeDet2 = detSource[1].CodeDet, NameDet2 = detSource[1].NameDet,CodeSE=seSource.CodeSE,NameSE=seSource.NameSE,bo=seSource.bo,N=seSource.N,n1=detSource[0].n1,n2=detSource[0].n2,PsiP=seSource.PsiP,TrType=seSource.TrType,y=detSource[0].y } };
                this.SeDataGrid.ItemsSource = _seModel;
            }
            else
            {
                _seModel.Add(new SEModelView() { CodeDet1 = detSource[0].CodeDet, NameDet1 = detSource[0].NameDet, CodeDet2 = detSource[1].CodeDet, NameDet2 = detSource[1].NameDet, CodeSE = seSource.CodeSE, NameSE = seSource.NameSE, bo = seSource.bo, N = seSource.N, n1 = detSource[0].n1, n2 = detSource[0].n2, PsiP = seSource.PsiP, TrType = seSource.TrType, y = detSource[0].y });
                this.SeDataGrid.ItemsSource = _seModel;
            }
        }

        private void AddSeButton_Click(object sender, RoutedEventArgs e)
        {
            Se taskWindow = new Se(this);
            taskWindow.СodeSeTextBox.Text = Guid.NewGuid().ToString();
            taskWindow.СodeSeTextBox.IsReadOnly = true;
            taskWindow.Show();
            Uzel uzelWindow = this;
            uzelWindow.Hide();
        }
    }
}
