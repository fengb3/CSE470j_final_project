//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("TrainingApp.View.ExerciseDetailPage.xaml", "View/ExerciseDetailPage.xaml", typeof(global::FinalProject.View.ExerciseDetailPage))]

namespace FinalProject.View {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("View\\ExerciseDetailPage.xaml")]
    public partial class ExerciseDetailPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.WebView Web;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ActivityIndicator Loading;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(ExerciseDetailPage));
            Web = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.WebView>(this, "Web");
            Loading = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ActivityIndicator>(this, "Loading");
        }
    }
}
