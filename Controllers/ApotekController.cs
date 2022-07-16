using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;

namespace Api_Apotek.Controllers
{
    public class ApotekController : Controller
    {
        public static string url = "Server=localhost;Database=apotek;Uid=;Pwd=;";
        MySqlConnection con = new MySqlConnection(url);

        [HttpGet]
        [Route("GetData")]
        public object Get()
        {
            try
            {
                con.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM tb_obat", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    return Ok(JsonConvert.SerializeObject(dt));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("InsertData")]
        [Consumes("application/x-www-form-urlencoded")]
        public object Insert([FromForm] Model.Transaksi transaksi)
        {
            try
            {
                con.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO tb_transaksi VALUES ('" + transaksi.Nama_obat + "', '" + transaksi.Jenis_obat + "', '" + transaksi.Harga + "', '" + transaksi.Total + "')", con);
                com.ExecuteNonQuery();

                return Ok("Transaksi Berhasil");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Login")]
        [Consumes("application/x-www-form-urlencoded")]
        public object Login([FromForm] string username, [FromForm] string password)
        {
            try
            {
                con.Open();
                if(username == null || password == null)
                {
                    return BadRequest();
                }
                else
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter("SELECT nama_lengkap, token FROM tb_user WHERE username = '" + username + "' AND password = '" + password + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                        return Ok(JsonConvert.SerializeObject(dt));
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("Register")]
        [Consumes("application/x-www-form-urlencoded")]
        public object Register([FromForm] string nama_lengkap, [FromForm] string username, [FromForm] string alamat, [FromForm] string password)
        {
            try
            {
                con.Open();
                if (nama_lengkap == null || username == null || password == null || alamat == null)
                {
                    return BadRequest();
                }
                else
                {
                    Function function = new Function();
                    MySqlCommand com = new MySqlCommand("INSERT INTO MsAdmin VALUES (@token, '" + nama_lengkap + "', '" + username + "', '" + alamat + "', '" + password + "')", con);
                    com.Parameters.AddWithValue("@token", function.GenerateToken());
                    com.ExecuteNonQuery();

                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
