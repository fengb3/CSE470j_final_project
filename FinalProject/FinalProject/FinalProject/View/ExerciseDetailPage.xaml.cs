using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinalProject.Model;

namespace FinalProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDetailPage : ContentPage
    {
        public ExerciseDetailPage()
        {
            InitializeComponent();
           
        }

        private void Web_Navigated(object sender, WebNavigatedEventArgs e)
        {
            Web.Eval("var rect = document.getElementById(\"videoid\").getBoundingClientRect();window.scrollTo(0, rect.top)");
            Web.IsVisible = true;
            Loading.IsRunning = false;
        }
    }
}