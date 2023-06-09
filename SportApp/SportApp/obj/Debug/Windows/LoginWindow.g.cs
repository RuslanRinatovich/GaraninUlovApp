﻿#pragma checksum "..\..\..\Windows\LoginWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8A29414C7DD7499D328BE376AB4D3655327C7C3DD8FA10788E878978AC93B9C8"
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
    /// LoginWindow
    /// </summary>
    public partial class LoginWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition RowCaptcha1;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition RowCaptcha2;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbLogin;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TbPass;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbCaptcha;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageCaptcha;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRenewCaptcha;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOk;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancel;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGuestMode;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\Windows\LoginWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlockTime;
        
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
            System.Uri resourceLocater = new System.Uri("/SportApp;component/windows/loginwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\LoginWindow.xaml"
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
            
            #line 11 "..\..\..\Windows\LoginWindow.xaml"
            ((SportApp.Windows.LoginWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.WindowClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RowCaptcha1 = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 3:
            this.RowCaptcha2 = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            this.TbLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TbPass = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 6:
            this.TbCaptcha = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ImageCaptcha = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.BtnRenewCaptcha = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Windows\LoginWindow.xaml"
            this.BtnRenewCaptcha.Click += new System.Windows.RoutedEventHandler(this.BtnRenewCaptcha_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BtnOk = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\Windows\LoginWindow.xaml"
            this.BtnOk.Click += new System.Windows.RoutedEventHandler(this.BtnOkClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\Windows\LoginWindow.xaml"
            this.BtnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancelClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BtnGuestMode = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\Windows\LoginWindow.xaml"
            this.BtnGuestMode.Click += new System.Windows.RoutedEventHandler(this.BtnGuestMode_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.TextBlockTime = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

