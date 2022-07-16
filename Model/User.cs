namespace Api_Apotek.Model
{
    public class User
    {
        string nama_lengkap, username, alamat, pasword;
        int id;

        public string Nama_lengkap { get => nama_lengkap; set => nama_lengkap = value; }
        public string Username { get => username; set => username = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Pasword { get => pasword; set => pasword = value; }
        public int Id { get => id; set => id = value; }
    }
}
