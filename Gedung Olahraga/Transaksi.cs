using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gedung_Olahraga
{
    class Transaksi
    {
        struct bayarsewa
        {
            public string nama_penyewa;
            public string cabang_olahraga;
            public string nama_lapangan;
            public DateTime jam_mulai;
            public DateTime jam_selesai;
            public long tagihan;
        }

        List<bayarsewa> transaksi;

        public Transaksi()
        {
            transaksi = new List<bayarsewa>();
        }

        public void tambahtransaksi(string nama_penyewa, string cabang_olahraga, string nama_lapangan, DateTime jam_mulai, DateTime jam_selesai, long tagihan)
        {
            bayarsewa baru = new bayarsewa();
            baru.nama_penyewa = nama_penyewa;
            baru.cabang_olahraga = cabang_olahraga;
            baru.nama_lapangan = nama_lapangan;
            baru.jam_mulai = jam_mulai;
            baru.jam_selesai = jam_selesai;
            baru.tagihan = tagihan;

            transaksi.Add(baru);
        }

        public DataTable tampiltransaksi()
        {
            DataTable table = new DataTable();
            
            table.Columns.Add("Nama Penyewa", typeof(string));
            table.Columns.Add("Olahraga", typeof(string));
            table.Columns.Add("Nama Lapangan", typeof(string));
            table.Columns.Add("Jam Mulai", typeof(DateTime));
            table.Columns.Add("Jam Selesai", typeof(DateTime));
            table.Columns.Add("Tagihan", typeof(long));

            foreach (bayarsewa b in transaksi)
            {
                table.Rows.Add(b.nama_penyewa, b.cabang_olahraga, b.nama_lapangan,b.jam_mulai,b.jam_selesai,b.tagihan);
            }
            return table;
        }

        public DataTable tampiltransaksi(string olahraga)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Nama Penyewa", typeof(string));
            table.Columns.Add("Olahraga", typeof(string));
            table.Columns.Add("Nama Lapangan", typeof(string));
            table.Columns.Add("Jam Mulai", typeof(DateTime));
            table.Columns.Add("Jam Selesai", typeof(DateTime));
            table.Columns.Add("Tagihan", typeof(long));

            foreach (bayarsewa b in transaksi)
            {
                if (b.cabang_olahraga == olahraga)
                    table.Rows.Add(b.nama_penyewa, b.cabang_olahraga, b.nama_lapangan, b.jam_mulai, b.jam_selesai, b.tagihan);
            }
            return table;
        }

        public DataTable tampilnamapenyewa(string nama, string olahraga)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Nama Penyewa", typeof(string));
            table.Columns.Add("Olahraga", typeof(string));
            table.Columns.Add("Nama Lapangan", typeof(string));
            table.Columns.Add("Jam Mulai", typeof(DateTime));
            table.Columns.Add("Jam Selesai", typeof(DateTime));
            table.Columns.Add("Tagihan", typeof(long));

            foreach (bayarsewa b in transaksi)
            {
                if (olahraga == "semua" && substringCocok(b.nama_penyewa, nama))
                    table.Rows.Add(b.nama_penyewa, b.cabang_olahraga, b.nama_lapangan, b.jam_mulai, b.jam_selesai, b.tagihan);
                else if (substringCocok(b.nama_penyewa,nama) && b.cabang_olahraga == olahraga)
                    table.Rows.Add(b.nama_penyewa, b.cabang_olahraga, b.nama_lapangan, b.jam_mulai, b.jam_selesai, b.tagihan);
            }
            return table;
        }

        private bool substringCocok(string sumber, string x)
        {
            sumber = sumber.ToLower();
            x = x.ToLower();
            for (int i = 0; i < sumber.Length; i++)
            {
                for (int j = 1; j <= sumber.Length - i; j++)
                {
                    if (sumber.Substring(i, j) == x)
                    { return true; break; }
                }
            }
            return false;
        }
    }
}
