using System;
using System.Collections.Generic;
using System.Text;

namespace RealmApp3
{
    public class DBcon
    {
        private string connection = "server=localhost;port=3306;username=root;password=root;database=mydb2";

        public string getConnection()
        {
            return connection;
        }
    }
}
