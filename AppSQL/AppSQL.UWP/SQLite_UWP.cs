using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppSQL;
using AppSQL.UWP;
using Xamarin.Forms;
using System.IO;
using Windows.Storage;
[assembly: Dependency(typeof(SQLite_UWP))]
namespace AppSQL.UWP
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP()
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
