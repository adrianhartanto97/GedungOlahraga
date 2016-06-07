using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gedung_Olahraga
{
    public partial class Form6 : Form
    {
        List<TextBox> t = new List<TextBox>();

        DaftarMember daftar;
        public Form6()
        {
            InitializeComponent();
            foreach (Control pa in this.Controls)
            {
                if (pa is TextBox)
                {
                    t.Add((TextBox)pa);
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            daftar = ClsTransfer.daftar;
            this.Location = new Point(0, 130);
            comboBox1.SelectedIndex = 0;
            textBox1.Text = DaftarMember.urutan.ToString();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 161;
            const int WM_SYSCOMMAND = 274;
            const int HTCAPTION = 2;
            const int SC_MOVE = 61456;

            if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MOVE))
            {
                return;
            }

            if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32() == HTCAPTION))
            {
                return;
            }

            base.WndProc(ref m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool sah = true;
            foreach (TextBox x in t)
            {
                if (x.Text == "") { sah = false; break; }
            }

            if (!sah)
                MessageBox.Show("Data belum lengkap!");
            else
            {
                string id = textBox1.Text;
                string nama = textBox2.Text;
                string tempat = textBox3.Text;
                string tanggal = textBox4.Text;
                string jenis_kelamin = comboBox1.Text;
                string alamat = textBox5.Text;
                string agama = textBox6.Text;
                string pekerjaan = textBox7.Text;

                daftar.tambahMember(id, nama, tempat, tanggal, jenis_kelamin, alamat, agama, pekerjaan, DateTime.Now);
                MessageBox.Show("Member baru berhasil di-Register !!");

                foreach (TextBox x in t)
                    x.Text = "";
                textBox1.Text = DaftarMember.urutan.ToString();
            }
        }
    }
}
