using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibrarySystem.Data
{
    class Connection
    {
        private string db; //db name
        private string server; // server name
        private string user;
        private string password;
        private bool security;
        private static Connection con = null;

        private Connection()
        {
            this.db = "biblioteca";
            this.server = "LAPTOP-SUN"; // change this name
            this.user = "sa";
            this.password = "";
            this.security = true;
        }

        public SqlConnection createConnection()
        {
            SqlConnection myString = new SqlConnection();

            try
            {
                myString.ConnectionString = "Server=" + this.server + "; Database=" + this.db + ";";
                if (this.security)
                {
                    myString.ConnectionString = myString.ConnectionString + "Integrated Security = SSPI";
                }
                else
                {
                    myString.ConnectionString = myString.ConnectionString + "User Id =" + this.user + "; Password =" + this.password;
                }
            }
            catch (Exception e)
            {
                myString = null;
                throw e;
            }

            return myString;
        }

        public static Connection getInstance()
        {
            if (con == null)
            {
                con = new Connection();
            }

            return con;
        }
    }
}
