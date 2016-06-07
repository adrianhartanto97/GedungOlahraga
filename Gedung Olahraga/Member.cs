using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gedung_Olahraga
{
    class Member
    {
        public string ID_member;
        public string nama;
        public string tempat_lahir;
        public string tanggal_lahir;
        public string jenis_kelamin;
        public string alamat;
        public string agama;
        public string pekerjaan;
        public DateTime tanggal_join;
        public DateTime tanggal_expired;

        public Member(string ID_member, string nama, string tempat_lahir, string tanggal_lahir, string jenis_kelamin,
            string alamat, string agama, string pekerjaan, DateTime tanggal_join, DateTime tanggal_expired)
        {
            this.ID_member = ID_member;
            this.nama = nama;
            this.tempat_lahir = tempat_lahir;
            this.tanggal_lahir = tanggal_lahir;
            this.jenis_kelamin = jenis_kelamin;
            this.alamat = alamat;
            this.agama = agama;
            this.pekerjaan = pekerjaan;
            this.tanggal_join = tanggal_join;
            this.tanggal_expired = tanggal_expired;
        }
    }
}
