﻿#pragma checksum "..\..\..\..\Views\RegistrarAsientoWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "498859B6D5E3F97ECAE481386A4579312CF23D32"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace GlobalLabIII {
    
    
    /// <summary>
    /// RegistrarAsientoWindow
    /// </summary>
    public partial class RegistrarAsientoWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 61 "..\..\..\..\Views\RegistrarAsientoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerFecha;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\Views\RegistrarAsientoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCuenta;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Views\RegistrarAsientoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbMovimiento;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\Views\RegistrarAsientoWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxMonto;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GlobalLabIII;component/views/registrarasientowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\RegistrarAsientoWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.datePickerFecha = ((System.Windows.Controls.DatePicker)(target));
            
            #line 61 "..\..\..\..\Views\RegistrarAsientoWindow.xaml"
            this.datePickerFecha.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.control_fecha);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbCuenta = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.cmbMovimiento = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.textBoxMonto = ((System.Windows.Controls.TextBox)(target));
            
            #line 104 "..\..\..\..\Views\RegistrarAsientoWindow.xaml"
            this.textBoxMonto.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 109 "..\..\..\..\Views\RegistrarAsientoWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnRegistrar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 113 "..\..\..\..\Views\RegistrarAsientoWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnVolver_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

