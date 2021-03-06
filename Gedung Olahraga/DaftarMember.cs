﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gedung_Olahraga
{
    class DaftarMember
    {
        public static int urutan=101;
        public List<Member> daftar;

        public DaftarMember()
        {
            daftar = new List<Member>();
        }

        public void tambahMember(string ID_member, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin,
            string alamat, string agama, string pekerjaan, DateTime tanggal_join)
        {
            TimeSpan ts = new TimeSpan(365, 0, 0, 0);
            DateTime tanggal_expired = tanggal_join.Add(ts);
            Member baru = new Member(ID_member, nama, tempat_lahir, tanggal_lahir, jenis_kelamin, alamat,agama, pekerjaan, tanggal_join,tanggal_expired);
            daftar.Add(baru);
            urutan++;
        }

        public DataTable tampilMember()
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID Member", typeof(string));
            table.Columns.Add("Nama Lengkap", typeof(string));
            table.Columns.Add("Tempat, Tanggal Lahir", typeof(string));
            table.Columns.Add("Jenis Kelamin", typeof(string));
            table.Columns.Add("Alamat", typeof(string));
            table.Columns.Add("Agama", typeof(string));
            table.Columns.Add("Pekerjaan", typeof(string));
            table.Columns.Add("Tanggal Join", typeof(DateTime));
            table.Columns.Add("Tanggal Expired", typeof(DateTime));

            foreach (Member m in daftar)
            {
                table.Rows.Add(m.ID_member, m.nama, m.tempat_lahir + ", " + m.tanggal_lahir, m.jenis_kelamin, m.alamat, m.agama,
                    m.pekerjaan,m.tanggal_join.ToLongDateString(),m.tanggal_expired.ToLongDateString());
            }
            return table;
        }

        public bool isMember(string kode)
        {
            foreach (Member m in daftar)
            {
                if (kode == m.ID_member)
                {
                    return true; break;
                }
            }
            return false;
        }

        public string namaMember(string kode)
        {
            foreach (Member m in daftar)
            {
                if (kode == m.ID_member)
                {
                    return m.nama;
                    break;
                }
            }
            return "";
        }

        public int cariMember(string kode)
        {
            int c = 0;
            foreach (Member m in daftar)
            {
                if (kode == m.ID_member)
                {
                    return c; break;
                }
                c++;
            }
            return -1;
        }

        public void editMember(int p, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin,
            string alamat, string agama, string pekerjaan)
        {
            daftar[p].nama = nama;
            daftar[p].tempat_lahir = tempat_lahir;
            daftar[p].tanggal_lahir = tanggal_lahir;
            daftar[p].jenis_kelamin = jenis_kelamin;
            daftar[p].alamat = alamat;
            daftar[p].agama = agama;
            daftar[p].pekerjaan = pekerjaan;
        }

        public void perpanjangMember(int p, int bulan)
        {
            TimeSpan ts = new TimeSpan(bulan * 30, 0, 0, 0);
            daftar[p].tanggal_expired = daftar[p].tanggal_expired.Add(ts);
        }
    }
}
