using FinalProject.Model;
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
    public partial class PlanDetailPage : ContentPage
    {
        public List<Train> TheTable = DB.conn.Table<Train>().ToList();
        public Plan toadyPlan;


        public PlanDetailPage()
        {
            InitializeComponent();
            SetPreference();
        }

        public void SetPreference()
        {
            if (Preferences.Get("IsKG", true))
            {
                wLabel.Text = "Weight(kg)";
            }
            else
            {
                wLabel.Text = "Weight(lb)";
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            toadyPlan = BindingContext as Plan;
            trainList.ItemsSource = GetTodayTrain();
         }

        public List<Train> GetTodayTrain()
        {
            var TrainIDS = toadyPlan.Trains.Split(',');
            List<Train> trains = new List<Train>();
            foreach(var id in TrainIDS)
            {
                var currTrain = TheTable.Where(x => x.ID == Int32.Parse(id)).ToList()[0];
                trains.Add(currTrain);
            }
            return trains;
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(sender != null)
            {
                var checkBox = sender as CheckBox;
                var currTrain = checkBox.BindingContext as Train;
                currTrain.IsDone = checkBox.IsChecked;
                DB.conn.Update(currTrain);
            }
        }

        async void trainList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var ThisTrain = e.Item as Train;

                var ExerciseTable = DB.conn.Table<Exercise>().ToList();

                var ThisExercise = ExerciseTable.Where(x => x.ID == ThisTrain.ExerciseID).ToList()[0];

                await Navigation.PushAsync(new ExerciseDetailPage
                {
                    BindingContext = ThisExercise,
                    Title = ThisExercise.Name
                });
            }
        }
    }
}