﻿#pragma checksum "..\..\Calculating.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7657CF0C98E7D67CBEB2FC8F913CD6A3E6355379E204CC33BEE18EBF1BD2C96E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KyrsovayaRabota;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace KyrsovayaRabota {
    
    
    /// <summary>
    /// Calculating
    /// </summary>
    public partial class Calculating : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Calculating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid UzDataGrid;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Calculating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UzLabel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Calculating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackToMenuButton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Calculating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Calculating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackToUzParamsButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Calculating.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StaticTableButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KyrsovayaRabota;component/calculating.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Calculating.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UzDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.UzLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.BackToMenuButton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Calculating.xaml"
            this.BackToMenuButton.Click += new System.Windows.RoutedEventHandler(this.BackToMenuButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Calculating.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BackToUzParamsButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Calculating.xaml"
            this.BackToUzParamsButton.Click += new System.Windows.RoutedEventHandler(this.BackToUzParamsButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StaticTableButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Calculating.xaml"
            this.StaticTableButton.Click += new System.Windows.RoutedEventHandler(this.StaticTableButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

