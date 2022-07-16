using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace Api_Apotek
{
    public class Function
    {
        public static string url = @"Data Source=localhost;Initial Catalog=resto_android;Integrated Security=True";
        MySqlConnection con = new MySqlConnection(url);
        public DataRowCollection GetData(string query)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(query, url);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt.Rows;
        }

        public string GenerateToken()
        {
            byte xorConstant = 0x53;

            byte[] data = Encoding.UTF8.GetBytes(DateTime.Now.Millisecond.ToString());
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(data[i] ^ xorConstant);
            }
            string result = Convert.ToBase64String(data)[..4];
            return result.Trim();
        }
    }
}
