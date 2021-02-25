using FinalProject.Model;
using FinalProject.Service;
using SkiaSharp;
using SkiaSharp.Views.Forms;
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
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();

            if (!Preferences.ContainsKey("IsKG"))
                Preferences.Set("IsKG", true);

            UnitsSetting.IsToggled = Preferences.Get("IsKG", true);
            Units.Text = Preferences.Get("IsKG", true) ? "Units(Kg)" : "Units(Lb)";
        }

        private void UnitsSetting_Toggled(object sender, ToggledEventArgs e)
        {
            Preferences.Set("IsKG", UnitsSetting.IsToggled);
            Units.Text = UnitsSetting.IsToggled ? "Units(Kg)" : "Units(Lb)";
        }

        private void Planedview_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Color = Color.LightCoral.ToSKColor(),
            };

            var items = GetItems();
            var infoList = new List<int>();

            foreach (PlanList pList in items)
            {
                var NumCount = 0;
                foreach (Plan p in pList)
                {
                    NumCount += p.Count;
                }
                infoList.Add(NumCount);
            }

            for (int i = 0; i < infoList.Count; i++)
            {
                var left = (float)info.Width * i / (infoList.Count);
                var top = info.Height * infoList[i] / infoList.Max();
                canvas.DrawRect(left, top, info.Width / infoList.Count, info.Height, paint);
            }
        }

        private void Doneview_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {

        }

        private List<PlanList> GetItems()
        {
            var TheTable = DB.conn.Table<Plan>().OrderBy(x => x.DatePerformed).ToList();
            if (TheTable.Count != 0)
            {
                var start = TheTable.First().DatePerformed;
                var end = TheTable.Last().DatePerformed;
                var ListOfPlanList = new List<PlanList>();

                for (var currWeek = getWeek(start); currWeek <= getWeek(end); currWeek = currWeek.AddDays(7))
                {
                    var currWeekList = new PlanList { FirstDayOfWeek = currWeek };
                    foreach (var plan in TheTable.Where(x => x.DatePerformed >= currWeek && x.DatePerformed < currWeek.AddDays(7)))
                    {
                        currWeekList.Add(plan);
                    }

                    if (currWeekList.Count > 0)
                        ListOfPlanList.Add(currWeekList);
                }

                return ListOfPlanList;
            }
            else
                return new List<PlanList>();
        }

        public static DateTime getWeek(DateTime date)
        {
            return date.AddDays(-(int)date.DayOfWeek);
        }

    }
}