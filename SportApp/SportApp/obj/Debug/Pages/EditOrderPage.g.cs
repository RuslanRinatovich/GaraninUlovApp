﻿#pragma checksum "..\..\..\Pages\EditOrderPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CDEA54DB73B08D28D5357713FD5FF4BD15483176ED16ACCF44E1C40A41B5509F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SportApp.Pages;
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


namespace SportApp.Pages {
    
    
    /// <summary>
    /// EditOrderPage
    /// </summary>
    public partial class EditOrderPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Pages\EditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockOrderNumber;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\EditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboStatus;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\EditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockOrderCreateDate;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\EditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockOrderDeliveryDate;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Pages\EditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockPickupPoint;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Pages\EditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockOrderGetCode;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Pages\EditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridOrderItems;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Pages\EditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockTotalCost;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\Pages\EditOrderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSaveStatus;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\Pages\EditOrderPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/SportApp;component/pages/editorderpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\EditOrderPage.xaml"
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
            this.ComboStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.TextBlockOrderCreateDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.TextBlockOrderDeliveryDate = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TextBlockPickupPoint = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TextBlockOrderGetCode = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.DataGridOrderItems = ((System.Windows.Controls.DataGrid)(target));
            
            #line 90 "..\..\..\Pages\EditOrderPage.xaml"
            this.DataGridOrderItems.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.DataGridGoodLoadingRow);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TextBlockTotalCost = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.BtnSaveStatus = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\Pages\EditOrderPage.xaml"
            this.BtnSaveStatus.Click += new System.Windows.RoutedEventHandler(this.BtnSaveStatus_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnSavePDF = ((System.Windows.Controls.Button)(target));
            
            #line 131 "..\..\..\Pages\EditOrderPage.xaml"
            this.BtnSavePDF.Click += new System.Windows.RoutedEventHandler(this.BtnSavePDF_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

