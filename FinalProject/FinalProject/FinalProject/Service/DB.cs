using FinalProject.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;

namespace FinalProject.Service
{
    class DB
    {
        public static SQLiteConnection conn;

        public static string DBName = "Exercise.db";

        public static void OpenConnection()
        {
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, DBName);
            conn = new SQLiteConnection(fname);
            conn.CreateTable<Exercise>();
            conn.CreateTable<Train>();
            conn.CreateTable<Plan>();
        }

        public static void CreateExercises()
        {
            JsonReader.LoadJson();
            foreach(var e in JsonReader.eList)
            {
                conn.Insert(e);
            }
        }
    }
}
