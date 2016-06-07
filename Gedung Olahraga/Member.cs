using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gedung_Olahraga
{
    class Member
    {
        public string ID_member { set; get; }
        public string nama { set; get; }
        public string tempat_lahir { set; get; }
        public string tanggal_lahir { set; get; }
        public string jenis_kelamin { set; get; }
        public string alamat { set; get; }
        public string agama { set; get; }
        public string pekerjaan { set; get; }
        public DateTime tanggal_join { set; get; }
        public DateTime tanggal_expired { set; get; }

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
