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
        public Uzel(Uzel uzel)
        {
            InitializeComponent();
            _uzel = uzel;
            _seModel = _uzel._seModel;
            this.UzNameTextBox.Text = uzel.UzNameTextBox.Text;
            this.CodeUzTextBox.Text = uzel.CodeUzTextBox.Text;
            this.SeDataGrid.Visibility = Visibility.Visible;
            this.ChangeSeButton.IsEnabled = true;
            this.DeleteSe.IsEnabled = true;
            this.SeDataGrid.ItemsSource = _seModel;
        }
        public Uzel(Se se,Uzel uzel)
        {
            InitializeComponent();
            _uzel = uzel;
            _context = new AppDbContext();
            this.UzNameTextBox.Text = uzel.UzNameTextBox.Text;
            this.CodeUzTextBox.Text = uzel.CodeUzTextBox.Text;
            this.SeDataGrid.Visibility = Visibility.Visible;
            this.ChangeSeButton.IsEnabled=true;
            this.DeleteSe.IsEnabled = true;
            var seSource = _context.SE.Where(x => x.CodeSE == se.СodeSeTextBox.Text).FirstOrDefault();
            var detSource = _context.Details_In_SESet.Where(x => x.SECodeSE == se.СodeSeTextBox.Text).Join(_context.DET,
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
            if (this.UzNameTextBox.Text == "" )
            {

                MessageBox.Show("Заполните обязательные параметры", "Внимание!");
            }
            else
            { 
            Se taskWindow = new Se(this);
            taskWindow.СodeSeTextBox.Text = Guid.NewGuid().ToString();
            taskWindow.СodeSeTextBox.IsReadOnly = true;
            taskWindow.Show();
            Uzel uzelWindow = this;
            uzelWindow.Hide();
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UzNameTextBox.Text == "")
            {
                MessageBox.Show("Заполните обязательные параметры", "Внимание!");
            }
            else if (this.SeDataGrid.Visibility == Visibility.Hidden)
            {
                MessageBox.Show("Добавьте сборочные единицы", "Внимание!");
            }
            else
            {
               // _context = new AppDbContext();
               // List<UZ> uZlist=new List<UZ>();
               // List<Se_In_UzSet> seInUzList = new List<Se_In_UzSet>();
               // for(int i=0;i<_seModel.Count;i++)
               // {
               //     uZlist.Add(new UZ() { CodeUz = this.CodeUzTextBox.Text, NameUz = this.UzNameTextBox.Text,NP=_seModel.Count});
               //     seInUzList.Add(new Se_In_UzSet() {UZCodeUz=this.CodeUzTextBox.Text,SECodeSE=_seModel[i].CodeSE,i=i+1 });
               // }
               // _context.UZ.AddRange(uZlist);
               // _context.Se_In_UzSet.AddRange(seInUzList);
               // _context.SaveChanges();
                Calculating taskWindow = new Calculating(this,_seModel);
                taskWindow.Show();
                this.Hide();
            }
        }

        private void ChangeSeButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.SeDataGrid.SelectedItem==null)
            {
                MessageBox.Show("Выберите в таблице сборочную едницу, которую хотите изменить", "Внимание!");
            }
            else
            {
                SEModelView _seMod = (SEModelView)this.SeDataGrid.SelectedItem;

                Se taskWindow = new Se(this,_seMod );
                this._seModel.RemoveAt(this.SeDataGrid.SelectedIndex);
                taskWindow.Show();
                this.Hide();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow taskWindow=new MainWindow();
            taskWindow.Show();
            this.Hide();
        }

        private void DeleteSe_Click(object sender, RoutedEventArgs e)
        {
            if (this.SeDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите в таблице сборочную едницу, которую хотите удалить", "Внимание!");
            }
            else
            {
                _context=new AppDbContext();

                SEModelView _seMod = (SEModelView)this.SeDataGrid.SelectedItem;

                this._seModel.RemoveAt(this.SeDataGrid.SelectedIndex);
                _context.Details_In_SESet.Remove(_context.Details_In_SESet.Where(x=>x.DETCodeDET==_seMod.CodeDet1).First());
                _context.Details_In_SESet.Remove(_context.Details_In_SESet.Where(x => x.DETCodeDET == _seMod.CodeDet2).First());
                _context.SE.Remove(_context.SE.Find(_seMod.CodeSE));
                _context.DET.Remove(_context.DET.Where(x => x.CodeDET == _seMod.CodeDet1).First());
                _context.DET.Remove(_context.DET.Where(x => x.CodeDET == _seMod.CodeDet2).First());
                _context.SaveChanges();
                if (_seModel.Count==0)
                {
                    this.SeDataGrid.Visibility = Visibility.Hidden;
                    this.SeLabel.Visibility = Visibility.Hidden;
                    this.DeleteSe.IsEnabled = false;
                    this.ChangeSeButton.IsEnabled = false;
                }
                this.SeDataGrid.IsEnabled = false;
                this.SeDataGrid.ItemsSource = _seModel;
                this.SeDataGrid.IsEnabled = true;

            }
        }
    }
}
