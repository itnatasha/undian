using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Undian
{
    class connectionstring
    {
        public static MySqlConnection getKoneksi()
        {
            String MyConString = "SERVER=localhost;" +
                "DATABASE=undian;" +
                "UID=root;" +
                "PASSWORD=;";
            return new MySqlConnection(MyConString);
        }
    }
}
