using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace UWPAssignment.Utils
{
    public class SQLiteUtil
    {
        private const string DatabaseName = "members.db";

        private static SQLiteUtil _instance;
        public SQLiteConnection Connection { get; }

        public static SQLiteUtil GetIntances()
        {
            if (_instance == null)
            {
                _instance = new SQLiteUtil();
            }
            return _instance;
        }

        private SQLiteUtil()
        {
            Connection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Members (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Id INT( 50 ),FirstName VARCHAR( 140 ),
                        LastName VARCHAR( 140 ),Avatar VARCHAR( 140 ),Phone VARCHAR( 140 ),Address VARCHAR( 140 ),Introduction VARCHAR( 140 ),
                        Gender INT( 50 ),Birthday VARCHAR( 140 ),Email VARCHAR( 140 ),Password VARCHAR( 140 ),);";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
        }

    }
}
