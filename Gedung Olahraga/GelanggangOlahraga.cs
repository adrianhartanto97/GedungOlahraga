using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gedung_Olahraga
{
    class GelanggangOlahraga
    {
        public List<Bulutangkis> lapangan_bulutangkis;

        public GelanggangOlahraga()
        {
            lapangan_bulutangkis = new List<Bulutangkis>();
        }

        public void TambahLapanganBulutangkis(Bulutangkis baru)
        {
            lapangan_bulutangkis.Add(baru);
        }

        public int cari_lapanganBulutangkis(string lapangan)
        {
            int p = -1; int c = 0;
            foreach (Bulutangkis b in lapangan_bulutangkis)
            {
                if (lapangan == b.nama_lapangan) { p = c; break; }
                c++;
            }
            return p;
        }

        public void sewa_bulutangkis(string lapangan, string nama_penyewa, DateTime mulai, int jam, long tagihan)
        {
            int p = cari_lapanganBulutangkis(lapangan);

            lapangan_bulutangkis[p].nama_penyewa = nama_penyewa;
            lapangan_bulutangkis[p].waktu_mulai = mulai;
            TimeSpan ts = new TimeSpan(jam,0,0);
            DateTime temp = mulai.Add(ts);
            lapangan_bulutangkis[p].waktu_selesai = temp;
            lapangan_bulutangkis[p].tersedia = false;
            lapangan_bulutangkis[p].tagihan = tagihan;
        }

        public string detail_sewabulutangkis(string lapangan)
        {
            string s = "";
            int p = cari_lapanganBulutangkis(lapangan);
            s += String.Format("Detail {0} : \n", lapangan);
            s += String.Format("Tarif / jam (non-member) = Rp. {0}\n", lapangan_bulutangkis[p].tarif);
            s += String.Format("NB : Member diskon 20%\n\n");
            if (!lapangan_bulutangkis[p].tersedia)
            {
                s += String.Format("Nama  penyewa : {0}\n",lapangan_bulutangkis[p].nama_penyewa);
                s += String.Format("Waktu mulai   : {0}\n", lapangan_bulutangkis[p].waktu_mulai);
                s += String.Format("Waktu selesai : {0}\n", lapangan_bulutangkis[p].waktu_selesai);
                s += String.Format("Tagihan       : Rp. {0}\n", lapangan_bulutangkis[p].tagihan);
            }
            return s;
        }

        public void bayar_bulutangkis(string lapangan)
        {
            int p = cari_lapanganBulutangkis(lapangan);
            lapangan_bulutangkis[p].tersedia = true;
        }
    }
}
