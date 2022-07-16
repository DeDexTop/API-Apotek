namespace Api_Apotek.Model
{
    public class Transaksi
    {
        string nama_obat, jenis_obat;
        int id, harga, total;

        public string Nama_obat { get => nama_obat; set => nama_obat = value; }
        public string Jenis_obat { get => jenis_obat; set => jenis_obat = value; }
        public int Id { get => id; set => id = value; }
        public int Harga { get => harga; set => harga = value; }
        public int Total { get => total; set => total = value; }
    }
}
