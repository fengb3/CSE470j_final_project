using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinalProject.Service;
using FinalProject.Model;
using System.Collections.Generic;

namespace FinalProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {

        public List<Exercise> TheTable = DB.conn.Table<Exercise>().ToList();

        public ExercisePage()
        {
            InitializeComponent();
            GetAllItemSource();
            GetPickerItemSource();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAllItemSource();
            fliter();
        }

        public void GetAllItemSource()
        {
            ExerciseList.ItemsSource = TheTable;
        }

        public void GetPickerItemSource()
        {
            CataLog.ItemsSource = TheTable.Select(x => x.Catalog).Distinct().ToList();
            Equipment.ItemsSource = TheTable.Select(X => X.Equipment).Distinct().ToList();
            Mechanics.ItemsSource = TheTable.Select(X => X.Mechanics).Distinct().ToList();
        }

        private void SelectedIndexChanged(object sender, System.EventArgs e)
        {
            fliter();
        }

        public void fliter()
        {
            ExerciseList.ItemsSource = TheTable; // intital the exercise list

            var Cata_selected = (CataLog.SelectedItem ?? "").ToString();
            var Equi_selected = (Equipment.SelectedItem ?? "").ToString();
            var Mech_selected = (Mechanics.SelectedItem ?? "").ToString();

            if (Cata_selected != "")
            {
                var TempTable = ExerciseList.ItemsSource.Cast<Exercise>().ToList();
                ExerciseList.ItemsSource = TempTable.Where(x => x.Catalog == Cata_selected);
            }

            if (Equi_selected != "")
            {
                var TempTable = ExerciseList.ItemsSource.Cast<Exercise>().ToList();
                ExerciseList.ItemsSource = TempTable.Where(x => x.Equipment == Equi_selected);
            }

            if (Mech_selected != "")
            {
                var TempTable = ExerciseList.ItemsSource.Cast<Exercise>().ToList();
                ExerciseList.ItemsSource = TempTable.Where(x => x.Mechanics == Mech_selected);
            }
        }

        async void ExerciseList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item != null)
            {
                var ThisExercise = e.Item as Exercise;

                await Navigation.PushAsync(new ExerciseDetailPage
                {
                    BindingContext = ThisExercise,
                    Title = ThisExercise.Name
                }) ;
            }
        }
    }
}