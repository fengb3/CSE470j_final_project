//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("TrainingApp.View.SettingPage.xaml", "View/SettingPage.xaml", typeof(global::FinalProject.View.SettingPage))]

namespace FinalProject.View {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("View\\SettingPage.xaml")]
    public partial class SettingPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label Units;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Switch UnitsSetting;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::SkiaSharp.Views.Forms.SKCanvasView Planedview;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::SkiaSharp.Views.Forms.SKCanvasView Doneview;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(SettingPage));
            Units = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "Units");
            UnitsSetting = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Switch>(this, "UnitsSetting");
            Planedview = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::SkiaSharp.Views.Forms.SKCanvasView>(this, "Planedview");
            Doneview = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::SkiaSharp.Views.Forms.SKCanvasView>(this, "Doneview");
        }
    }
}