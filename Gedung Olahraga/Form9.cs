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
    public partial class Form9 : Form
    {
        bool ismember;
        bool ismember2;
        DaftarMember daftar;
        GelanggangOlahraga GOR;
        int index;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 130);
            daftar = ClsTransfer.daftar;
            GOR = ClsTransfer.gor;
            radioButton1.Checked = true;
            ismember = false; ismember2 = false;
            refresh_harga();
            radioButton3.Checked = true;
            refresh_harga2();
            refresh(); refresh2();
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


        private void button3_Click(object sender, EventArgs e)
        {
            daftar = ClsTransfer.daftar;
            if (button3.Text == "Cek")
            {
                if (daftar.isMember(textBox1.Text))
                {
                    ismember = true; refresh_harga();
                    textBox2.Text = daftar.namaMember(textBox1.Text);
                    int p = daftar.cariMember(textBox1.Text);
                    string jns = daftar.daftar[p].jenis_kelamin;
                    if (jns == "Laki-laki") comboBox1.SelectedIndex = 0;
                    else comboBox1.SelectedIndex = 1;
                    MessageBox.Show("Terdaftar sebagai member ", "Cek Member", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    button3.Text = "Ubah";
                    textBox1.Enabled = false;
                }
                else
                    MessageBox.Show("Tidak terdaftar sebagai member", "Cek Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ismember = false; refresh_harga();
                textBox1.Enabled = true;
                button3.Text = "Cek";
            }
        }

        private void refresh_harga()
        {
            long tagihan;
            if (ismember) tagihan = 0;
            else tagihan = GOR.kolam_renang[0].tarif;
            textBox3.Text = String.Format("Rp. {0}", tagihan);
        }

        private void refresh_harga2()
        {
            long tagihan;
            if (ismember2) tagihan = 0;
            else tagihan = GOR.kolam_renang[1].tarif;
            textBox6.Text = String.Format("Rp. {0}", tagihan);
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { textBox1.Enabled = false; ismember = false; refresh_harga(); button3.Text = "Cek"; button3.Enabled = false; }
            else textBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                DateTime sekarang = DateTime.Now;
                GOR.masukRenangAnak(textBox2.Text, ismember, Convert.ToInt16(textBox4.Text), comboBox1.Text,sekarang);
                radioButton2.Checked = true;
                textBox2.Text = ""; textBox4.Text = ""; textBox1.Text = "";
                comboBox1.SelectedIndex = 0;
                MessageBox.Show("Pengunjung berhasil masuk !!");
                refresh();
            }
            else
                MessageBox.Show("Data belum lengkap !!");
        }

        public void refresh()
        {
            int p = GOR.cari_kolamrenang("Pool Anak-anak");
            dgv.DataSource = GOR.tampilPengunjungRenang(p);
        }

        public void refresh2()
        {
            int p = GOR.cari_kolamrenang("Pool Dewasa");
            dgv2.DataSource = GOR.tampilPengunjungRenang(p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            daftar = ClsTransfer.daftar;
            if (button6.Text == "Cek")
            {
                if (daftar.isMember(textBox8.Text))
                {
                    ismember2 = true; refresh_harga2();
                    textBox7.Text = daftar.namaMember(textBox8.Text);
                    int p = daftar.cariMember(textBox8.Text);
                    string jns = daftar.daftar[p].jenis_kelamin;
                    if (jns == "Laki-laki") comboBox2.SelectedIndex = 0;
                    else comboBox2.SelectedIndex = 1;
                    MessageBox.Show("Terdaftar sebagai member ", "Cek Member", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    button6.Text = "Ubah";
                    textBox8.Enabled = false;
                }
                else
                    MessageBox.Show("Tidak terdaftar sebagai member", "Cek Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ismember2 = false; refresh_harga2();
                textBox8.Enabled = true;
                button6.Text = "Cek";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button6.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked) { textBox8.Enabled = false; ismember2 = false; refresh_harga2(); button6.Text = "Cek"; }
            else textBox8.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox5.Text != "" && comboBox2.Text != "")
            {
                DateTime sekarang = DateTime.Now;
                GOR.masukRenangDewasa(textBox7.Text, ismember2, Convert.ToInt16(textBox5.Text), comboBox2.Text, sekarang);
                radioButton4.Checked = true;
                textBox7.Text = ""; textBox5.Text = ""; textBox8.Text = "";
                comboBox2.SelectedIndex = 0;
                MessageBox.Show("Pengunjung berhasil masuk !!");
                refresh2();
            }
            else
                MessageBox.Show("Data belum lengkap !!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refresh2();
        }
    }
}
