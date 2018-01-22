using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PoIS_Rent_a_Car
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
              SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
              builder.DataSource = @"KATIC\SQLEXPRESS";
              builder.InitialCatalog = @"Rent-a-car";
              builder.IntegratedSecurity = true;
              string konek = builder.ToString();
              SqlConnection konekcija = new SqlConnection(konek);
              return konekcija;
            
        }
    }   
}
