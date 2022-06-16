using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace bureau_de_change
{
    class classe_cnx
    {
        
       public SqlConnection cnx = new SqlConnection
        (@"Data Source=AITELBACHA-PC\SQL08;Initial Catalog=easy_change;Integrated Security=True");
    }
}
