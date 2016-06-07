using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gedung_Olahraga
{
    abstract class Olahraga
    {
        public string nama_lapangan { set; get; }
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
        public long tarif { set; get; }
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
        public long tarif { set; get; }
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
        public long tarif { set; get; }
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
}
