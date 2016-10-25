using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using AppSQL;
using AppSQL.Droid;
using Xamarin.Forms;
using System.IO;


[assembly: Dependency(typeof(SQLite_Android))]
namespace AppSQL.Droid
{
    class SQLite_Android : ISQLite
    {
        public SQLite_Android() 
        {
        }

        public SQLite.SQLiteConnection GetConecction()
        {
            var dbname = "pract4.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbname);
            Console.WriteLine(path);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;

        }

        
    }
}