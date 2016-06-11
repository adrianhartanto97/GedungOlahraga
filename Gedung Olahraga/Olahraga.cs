using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Gedung_Olahraga
{
    abstract class Olahraga
    {
        public string nama_lapangan { set; get; }
        public long tarif { set; get; }
        public Olahraga(string nama)
        {
            nama_lapangan = nama;
        }
    }

    class Bulutangkis : Olahraga
    {
        public string nama_penyewa { set; get; }
        public string jenis
        {
            set {
                jenis_lapangan = value;
                if (value == "Reguler") tarif = 50000;
                else if (value == "VIP") tarif = 100000;
            }
            get
            { return jenis_lapangan; }
        }
        string jenis_lapangan;
        public long tagihan { set; get; }
        public DateTime waktu_mulai { set; get; }
        public DateTime waktu_selesai { set; get; }
        public bool tersedia { set; get; }

        public Bulutangkis(string nama_lapangan, string jenis)
            :base(nama_lapangan)
        {
            this.jenis = jenis;
            tersedia = true;
        }

        public string status()
        {
            if (tersedia) return "Free";
            else return "Rented";
        }
    }

    class Basket : Olahraga
    {
        public string nama_penyewa { set; get; }
        public string jenis
        {
            set
            {
                jenis_lapangan = value;
                if (value == "Reguler") tarif = 70000;
                else if (value == "VIP") tarif = 140000;
            }
            get
            { return jenis_lapangan; }
        }
        string jenis_lapangan;
        public long tagihan { set; get; }
        public DateTime waktu_mulai { set; get; }
        public DateTime waktu_selesai { set; get; }
        public bool tersedia { set; get; }

        public Basket(string nama_lapangan, string jenis)
            :base(nama_lapangan)
        {
            this.jenis = jenis;
            tersedia = true;
        }

        public string status()
        {
            if (tersedia) return "Free";
            else return "Rented";
        }
    }

    class Futsal : Olahraga
    { 
        public string nama_penyewa { set; get; }
        public string jenis
        {
            set
            {
                jenis_lapangan = value;
                if (value == "Reguler") tarif = 60000;
                else if (value == "VIP") tarif = 120000;
            }
            get
            { return jenis_lapangan; }
        }
        string jenis_lapangan;
        public long tagihan { set; get; }
        public DateTime waktu_mulai { set; get; }
        public DateTime waktu_selesai { set; get; }
        public bool tersedia { set; get; }

        public Futsal(string nama_lapangan, string jenis)
            :base(nama_lapangan)
        {
            this.jenis = jenis;
            tersedia = true;
        }

        public string status()
        {
            if (tersedia) return "Free";
            else return "Rented";
        }
    }


    class Renang : Olahraga
    {
        public static int urutan_masuk = 1;
        public struct dim
        {
            public int panjang;
            public int lebar;
            public int tinggi;
        }

        public struct Pengunjung
        {
            public int urutan;
            public string nama;
            public bool member;
            public int umur;
            public string jenis_kelamin;
            public DateTime waktu_masuk;
        }

        public dim dimensi { set; get; }
        public string kategori { set; get; }
        public List<Pengunjung> history_lengkap;

        public Renang(string nama_kolam, string kategori, long tarif, int panjang, int lebar, int tinggi)
            : base(nama_kolam)
        {
            this.tarif = tarif;
            this.kategori = kategori;
            dim baru = new dim();
            baru.panjang = panjang;
            baru.lebar = lebar;
            baru.tinggi = tinggi;
            this.dimensi = baru;
            history_lengkap = new List<Pengunjung>();
        }

        public void tambah_pengunjung(string nama, bool member, int umur, string jenis_kelamin, DateTime masuk)
        {
            Pengunjung baru = new Pengunjung();
            baru.urutan = urutan_masuk;
            baru.nama = nama;
            baru.member = member;
            baru.umur = umur;
            baru.jenis_kelamin = jenis_kelamin;
            baru.waktu_masuk = masuk;
            urutan_masuk++;

            history_lengkap.Add(baru);
        }

        public DataTable tampilPengunjung()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Urutan", typeof(int));
            table.Columns.Add("Nama Pengunjung", typeof(string));
            table.Columns.Add("Member", typeof(string));
            table.Columns.Add("Umur", typeof(int));
            table.Columns.Add("Jenis Kelamin", typeof(string));
            table.Columns.Add("Waktu Masuk", typeof(DateTime));

            foreach (Pengunjung p in history_lengkap)
            {
                table.Rows.Add(p.urutan, p.nama,p.member?"Ya":"Tidak", p.umur, p.jenis_kelamin,p.waktu_masuk);
            }

            return table;
        }
    }

    class Fitness : Olahraga
    {
        public static int urutan_masuk = 1;

        public struct Pengunjung
        {
            public int urutan;
            public string nama;
            public bool member;
            public int umur;
            public string jenis_kelamin;
            public DateTime waktu_masuk;
        }

        public List<Pengunjung> history_lengkap;

        public Fitness(string nama_fitness, long tarif)
            : base(nama_fitness)
        {
            this.tarif = tarif;
            history_lengkap = new List<Pengunjung>();
        }

        public void tambah_pengunjung(string nama,  bool member, int umur, string jenis_kelamin, DateTime masuk)
        {
            Pengunjung baru = new Pengunjung();
            baru.urutan = urutan_masuk;
            baru.nama = nama;
            baru.member = member;
            baru.umur = umur;
            baru.jenis_kelamin = jenis_kelamin;
            baru.waktu_masuk = masuk;
            urutan_masuk++;

            history_lengkap.Add(baru);
        }

        public DataTable tampilPengunjung()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Urutan", typeof(int));
            table.Columns.Add("Nama Pengunjung", typeof(string));
            table.Columns.Add("Member", typeof(string));
            table.Columns.Add("Umur", typeof(int));
            table.Columns.Add("Jenis Kelamin", typeof(string));
            table.Columns.Add("Waktu Masuk", typeof(DateTime));

            foreach (Pengunjung p in history_lengkap)
            {
                table.Rows.Add(p.urutan, p.nama,p.member?"Ya":"Tidak", p.umur, p.jenis_kelamin, p.waktu_masuk);
            }

            return table;
        }
    }
}
