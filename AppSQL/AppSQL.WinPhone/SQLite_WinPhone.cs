using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppSQL;
using AppSQL.WinPhone;
using Xamarin.Forms;
using System.IO;
using Windows.Storage;
[assembly: Dependency(typeof(SQLite_WinPhone))]
namespace AppSQL.WinPhone
{
    public class SQLite_WinPhone : ISQLite
    {
        public SQLite_WinPhone()
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
