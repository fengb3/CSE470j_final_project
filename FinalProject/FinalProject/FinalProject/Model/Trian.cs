using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using Xamarin.Essentials;
using FinalProject.Service;
using System.Linq;
using Xamarin.Essentials;
 
namespace FinalProject.Model
{
    [Table("train")]
    public class Train
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ExerciseID { get; set; }
        public int Reps { get; set; }
        public int Groups { get; set; }
        public float Weight { get; set; }
        public TimeSpan Duration { get; set; }
        public float Distance { get; set; }
        public bool IsDone { get; set; }

        public string GetReps
        {
            get
            {
                return string.Format("{0}", Reps);
            }
        }

        public string GetWeight
        {
            get
            {
                if (Preferences.Get("IsKG", true))
                {
                    return string.Format("{0:0.0}", LBtoKG(Weight));
                }
                else
                {
                    return string.Format("{0:0.0}", Weight);
                }
                
            }
        }

        public string GetExerciseName
        {
            get
            {
                return DB.conn.Table<Exercise>().ToList().Where(x => x.ID == ExerciseID).ToList().First().Name;
            }
        }

        public static float LBtoKG(float lb)
        {
            return lb / 2.2046f;
        }

        public static float KGtoLB(float kg)
        {
            return kg * 2.2046f;
        }


    }

    [Table("plan")]
    public class Plan
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime DatePerformed { get; set; }
        public String Trains { get; set; }

        public void AddTrain(Train t)
        {
            if(Trains == null)
            {
                Trains = "" + t.ID;
            }
            else
            {
                Trains += ("," + t.ID);
            }
        }
        public string GetWeek
        {
            get
            {
                return DatePerformed.ToString("dddd");
            }
        }
        public int Count
        {
            get
            {
                var TrainsArr = Trains.Split(',');
                return TrainsArr.Length;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", DatePerformed.ToString("yy/MMM/dd"));
        }
    }

    public class PlanList : List<Plan>
    {
        public DateTime FirstDayOfWeek { get; set; }
        public List<Plan> Plans => this;

        public string GetMonth
        {
            get
            {
                return FirstDayOfWeek.ToString("yyy MMM");
            }
        }
        
        public int WeekOfMonth
        {
            get
            {
                DateTime FirstMonthDay = new DateTime(FirstDayOfWeek.Year, FirstDayOfWeek.Month, 1);
                DateTime FirstMonthMonday = FirstMonthDay.AddDays((DayOfWeek.Monday + 7 - FirstMonthDay.DayOfWeek) % 7);
                if (FirstMonthMonday > FirstDayOfWeek)
                {
                    FirstMonthDay = FirstMonthDay.AddMonths(-1);
                    FirstMonthMonday = FirstMonthDay.AddDays((DayOfWeek.Monday + 7 - FirstMonthDay.DayOfWeek) % 7);
                }
                return (FirstDayOfWeek - FirstMonthMonday).Days / 7 + 1;
            }
        }
    }
}
