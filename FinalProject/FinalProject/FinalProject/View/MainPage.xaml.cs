using FinalProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            /* load exercise in sqlite */
            if (!Preferences.ContainsKey("ExerciseLoaded"))
            {
                Preferences.Set("ExerciseLoaded", true);
                DB.CreateExercises();
            }

            if(!Preferences.Get("ExerciseLoaded", true))
            {
                DB.CreateExercises();
            }

            NavigationPage navigationPage1 = new NavigationPage(new ExercisePage());
            navigationPage1.IconImageSource = "gym.png";
            navigationPage1.Title = "Exercise";

            NavigationPage navigationPage2 = new NavigationPage(new PlanPage());
            navigationPage2.IconImageSource = "document.png";
            navigationPage2.Title = "Plan";

            NavigationPage navigationPage3 = new NavigationPage(new SettingPage());
            navigationPage3.IconImageSource = "settings.png";
            navigationPage3.Title = "Setting";

            /* add tabs */
            this.Children.Add(navigationPage1);
            this.Children.Add(navigationPage2);
            this.Children.Add(navigationPage3);
        }
    }
}