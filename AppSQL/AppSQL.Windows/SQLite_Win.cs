using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppSQL;
using AppSQL.Windows;
using Xamarin.Forms;
using System.IO;
using Windows.Storage;

[assembly: Dependency(typeof(SQLite_Win))]
namespace AppSQL.Windows
{
    public class SQLite_Win : ISQLite
    {
        public SQLite_Win()
        {

        }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilname = "pract4.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilname);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}
