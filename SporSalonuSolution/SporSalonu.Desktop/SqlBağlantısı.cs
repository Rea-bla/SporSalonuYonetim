using Microsoft.Data.SqlClient;

namespace SporSalonu.Desktop
{
    public class SqlBaglantisi
    {

        private readonly string adres = @"Data Source=PC\DENEME;Initial Catalog=SporSalonuDB;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;";

        public SqlConnection Baglanti()
        {
            SqlConnection baglan = new SqlConnection(adres);
            return baglan;
        }
    }
}
