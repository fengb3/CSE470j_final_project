using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinalProject.Model;
using FinalProject.Service;

namespace FinalProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DB.OpenConnection();
            MainPage = new View.MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
