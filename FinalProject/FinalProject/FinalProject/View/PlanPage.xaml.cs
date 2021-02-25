using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinalProject.Service;
using FinalProject.Model;

namespace FinalProject.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanPage : ContentPage
    {

        public List<Plan> TheTable = DB.conn.Table<Plan>().ToList();

        public PlanPage()
        {
            InitializeComponent();
            GetItemSource();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetItemSource();
        }

        private void GetItemSource()
        {
            TheTable = DB.conn.Table<Plan>().OrderBy(x => x.DatePerformed).ToList();
            if(TheTable.Count != 0)
            {
                var start = TheTable.First().DatePerformed;
                var end = TheTable.Last().DatePerformed;
                var ListOfPlanList = new List<PlanList>();

                for(var currWeek = getWeek(start); currWeek <= getWeek(end); currWeek = currWeek.AddDays(7))
                {
                    var currWeekList = new PlanList { FirstDayOfWeek = currWeek };
                    foreach(var plan in TheTable.Where(x => x.DatePerformed >= currWeek && x.DatePerformed < currWeek.AddDays(7)))
                    {
                        currWeekList.Add(plan);
                    }

                    if (currWeekList.Count > 0)
                        ListOfPlanList.Add(currWeekList);
                }

                PlanList.ItemsSource = ListOfPlanList;
            }
  
        }

        public static DateTime getWeek(DateTime date)
        {
            return date.AddDays(-(int)date.DayOfWeek);
        }

        async void AddBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddPlanPage
            {
                Title = "Add Plan"
            });
        }

        async void PlanList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var ThisPlan = e.Item as Plan;

                await Navigation.PushAsync(new PlanDetailPage
                {
                    BindingContext = ThisPlan,
                    Title = ThisPlan.DatePerformed.ToString("MMM dd dddd")
                }); 
            }
        }
    }
}