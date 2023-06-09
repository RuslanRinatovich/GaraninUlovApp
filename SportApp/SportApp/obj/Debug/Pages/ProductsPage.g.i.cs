﻿#pragma checksum "..\..\..\Pages\ProductsPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E01FDB658BA566F136BD61F4EBA59E7E0ADDAD9B78297460C82758E2424D67F7"
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
    /// ProductsPage
    /// </summary>
    public partial class ProductsPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBoxSearch;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboDiscont;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSort;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridGood;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockCount;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCategory;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnUnitType;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSupplier;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnManufacturer;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\Pages\ProductsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAdd;
        
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
            System.Uri resourceLocater = new System.Uri("/SportApp;component/pages/productspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ProductsPage.xaml"
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
            
            #line 9 "..\..\..\Pages\ProductsPage.xaml"
            ((SportApp.Pages.ProductsPage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.PageIsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBoxSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\Pages\ProductsPage.xaml"
            this.TBoxSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TBoxSearchTextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ComboDiscont = ((System.Windows.Controls.ComboBox)(target));
            
            #line 26 "..\..\..\Pages\ProductsPage.xaml"
            this.ComboDiscont.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboSortSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ComboSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\Pages\ProductsPage.xaml"
            this.ComboSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboSortSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataGridGood = ((System.Windows.Controls.DataGrid)(target));
            
            #line 49 "..\..\..\Pages\ProductsPage.xaml"
            this.DataGridGood.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.DataGridGoodLoadingRow);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TextBlockCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.BtnCategory = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\Pages\ProductsPage.xaml"
            this.BtnCategory.Click += new System.Windows.RoutedEventHandler(this.BtnCategory_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnUnitType = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\Pages\ProductsPage.xaml"
            this.BtnUnitType.Click += new System.Windows.RoutedEventHandler(this.BtnUnitType_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BtnSupplier = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\Pages\ProductsPage.xaml"
            this.BtnSupplier.Click += new System.Windows.RoutedEventHandler(this.BtnSupplier_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.BtnManufacturer = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\Pages\ProductsPage.xaml"
            this.BtnManufacturer.Click += new System.Windows.RoutedEventHandler(this.BtnManufacturer_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.BtnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\..\Pages\ProductsPage.xaml"
            this.BtnAdd.Click += new System.Windows.RoutedEventHandler(this.BtnAddClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 68 "..\..\..\Pages\ProductsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClick);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 75 "..\..\..\Pages\ProductsPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnDelete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

