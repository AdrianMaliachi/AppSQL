using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppSQL;
using AppSQL.iOS;
using Xamarin.Forms;
using System.IO;
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;

[assembly: Dependency(typeof(SQLite_IOS))]
namespace AppSQL.iOS
{
    class SQLite_IOS : ISQLite
    {
        public SQLite_IOS()
        {


        }

        public SQLite.SQLiteConnection GetConnection()
        {
            var dbname = "pract4.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, dbname);
            Console.WriteLine(path);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }

    }
}