using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_DataAccess.Controllers
{
    public abstract class Connection{

        public string ConnectionString = "Server=mssqlstud.fhict.local;Database=dbi503708;User Id=dbi503708;Password=dbi123;";

        public static SqlConnection connection;
        protected Connection()
        {
            connection = new SqlConnection(ConnectionString);
        }
    }
}
