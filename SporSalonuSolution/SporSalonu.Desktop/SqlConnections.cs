using Microsoft.Data.SqlClient;

namespace SporSalonu.Desktop
{
    public class SqlBaglantisi
    {

        private readonly string adres = @"Data Source=127.0.0.1,1435;Initial Catalog=SporSalonuDB;User ID=sa;Password=Admin123!;TrustServerCertificate=True;";

        public SqlConnection Baglanti()
        {
            SqlConnection baglan = new SqlConnection(adres);
            return baglan;
        }
    }
}
