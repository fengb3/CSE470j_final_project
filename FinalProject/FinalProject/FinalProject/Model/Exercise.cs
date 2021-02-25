using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Essentials;

namespace FinalProject.Model
{
    [Table("exercise")]
    public class Exercise
    {
        // Catalog,Url,Name,Equipment,Target,Utility,Mechanics,Force,Preparation,Execution,Comment
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Catalog { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Equipment { get; set; }

        public string Target { get; set; }

        public string Utility { get; set; }

        public string Mechanics { get; set; }

        public string Force { get; set; }

        public string Preparation { get; set; }

        public string Execution { get; set; }

        public string Comment { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Target);
        }

    }
}
