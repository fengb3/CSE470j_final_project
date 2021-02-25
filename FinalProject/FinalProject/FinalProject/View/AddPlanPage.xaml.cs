using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinalProject.Model;
using FinalProject.Service;
using Xamarin.Essentials;

namespace FinalProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlanPage : ContentPage
    {

        public List<Exercise> TheTable = DB.conn.Table<Exercise>().ToList();

        public AddPlanPage()
        {
            InitializeComponent();
            GetAllItemSource();
            GetPickerItemSource();
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
            exder.IsExpanded = true;
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

        private void ExerciseList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            exder.IsExpanded = false;
            if(e.Item != null)
            {
                var ThisExercise = e.Item as Exercise;

                var ThisTrain = new Train
                {
                    ExerciseID = ThisExercise.ID,
                };

                DB.conn.Insert(ThisTrain);

                List<Train> Temp = GetSelectedItem();

                Temp.Add(ThisTrain);
                SelectedExercise.ItemsSource = Temp;
            }
        }

        private void X_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;

            var currentItem = btn.BindingContext as Train;

            var temp = GetSelectedItem();

            temp.Remove(currentItem);

            SelectedExercise.ItemsSource = temp;

            DB.conn.Delete(currentItem);
        }

        private void Reps_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;

            var currItem = entry.BindingContext as Train;

            var temp = GetSelectedItem();

            var Found = temp.FirstOrDefault(x => x.ID == currItem.ID);

            try
            {
                Found.Reps = Int32.Parse(entry.Text);
            }
            catch
            {
                Found.Reps = 0;
            }

            DB.conn.Update(Found);
        }

        private void Weight_Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;

            var currItem = entry.BindingContext as Train;

            var temp = GetSelectedItem();

            var Found = temp.FirstOrDefault(x => x.ID == currItem.ID);

            try
            {
                if(Preferences.Get("IsKG", true))
                {
                    Found.Weight = Train.KGtoLB(float.Parse(entry.Text));
                }
                else
                {
                    Found.Weight = float.Parse(entry.Text);
                }
                
            }
            catch
            {
                Found.Weight = 0;
            }

            DB.conn.Update(Found);
        }

        private List<Train> GetSelectedItem()
        {
            List<Train> Temp;

            if (SelectedExercise.ItemsSource == null)
            {
                Temp = new List<Train>();
            }
            else
            {
                Temp = SelectedExercise.ItemsSource.Cast<Train>().ToList();
            }

            return Temp;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var selected = GetSelectedItem();

            if(selected.Count == 0)
            {
                Navigation.PopModalAsync();
                return;
            }

            var newPlan = new Plan
            {
                DatePerformed = SelectedDate.Date,
            };

            foreach(Train t in selected)
            {
                newPlan.AddTrain(t);
            }

            DB.conn.Insert(newPlan);
            Navigation.PopModalAsync();

        }

        private void Groups_Entry_Unfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;

            var currItem = entry.BindingContext as Train;

            var temp = GetSelectedItem();

            var Found = temp.FirstOrDefault(x => x.ID == currItem.ID);

            try
            {
                Found.Groups = Int32.Parse(entry.Text);
            }
            catch
            {
                Found.Groups = 0;
            }

            DB.conn.Update(Found);
        }

        private void CataLog_Focused(object sender, FocusEventArgs e)
        {
            exder.IsExpanded = true;
        }
    }
}