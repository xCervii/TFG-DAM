
using Microsoft.Data.SqlClient;

namespace ControlPadelClub.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestDBconnection("Server=DESKTOP-FDGPIRU\\SQLEXPRESS;Database=BBDD_Padel;Trusted_Connection=True;Encrypt=False;");
        }

        public static void TestDBconnection(string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                Console.WriteLine("Connection is just opened!");
                System.Threading.Thread.Sleep(10000);
                conn.Close();
            }
        }
    }
}