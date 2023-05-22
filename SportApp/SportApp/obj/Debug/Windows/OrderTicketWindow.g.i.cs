﻿#pragma checksum "..\..\..\Windows\OrderTicketWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "094075772592FE846BBA9748B48E103FEB905A20C7BDC481C9758FDAC21A0AD3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SportApp.Windows;
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


namespace SportApp.Windows {
    
    
    /// <summary>
    /// OrderTicketWindow
    /// </summary>
    public partial class OrderTicketWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\Windows\OrderTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockOrderNumber;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Windows\OrderTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockOrderCreateDate;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Windows\OrderTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockOrderDeliveryDate;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Windows\OrderTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockPickupPoint;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Windows\OrderTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockOrderGetCode;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Windows\OrderTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridOrderItems;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Windows\OrderTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockTotalCost;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Windows\OrderTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOk;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\Windows\OrderTicketWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSavePDF;
        
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
            System.Uri resourceLocater = new System.Uri("/SportApp;component/windows/orderticketwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\OrderTicketWindow.xaml"
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
            this.TextBlockOrderNumber = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TextBlockOrderCreateDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TextBlockOrderDeliveryDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TextBlockPickupPoint = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TextBlockOrderGetCode = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.DataGridOrderItems = ((System.Windows.Controls.DataGrid)(target));
            
            #line 90 "..\..\..\Windows\OrderTicketWindow.xaml"
            this.DataGridOrderItems.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.DataGridGoodLoadingRow);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBlockTotalCost = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.BtnOk = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\..\Windows\OrderTicketWindow.xaml"
            this.BtnOk.Click += new System.Windows.RoutedEventHandler(this.BtnOk_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnSavePDF = ((System.Windows.Controls.Button)(target));
            
            #line 133 "..\..\..\Windows\OrderTicketWindow.xaml"
            this.BtnSavePDF.Click += new System.Windows.RoutedEventHandler(this.BtnSavePDF_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

