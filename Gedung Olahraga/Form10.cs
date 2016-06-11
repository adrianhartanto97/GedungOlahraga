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
    public partial class Form10 : Form
    {
        DaftarMember daftar;
        GelanggangOlahraga GOR;
        bool ismember;
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 130);
            daftar = ClsTransfer.daftar;
            GOR = ClsTransfer.gor;
            ismember = false;
            refresh_harga();
            refresh();
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
            else tagihan = GOR.tempat_fitness[0].tarif;
            textBox3.Text = String.Format("Rp. {0}", tagihan);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { textBox1.Enabled = false; ismember = false; refresh_harga(); button3.Text = "Cek"; button3.Enabled = false; }
            else textBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                DateTime sekarang = DateTime.Now;
                GOR.masukFitness(textBox2.Text, ismember, Convert.ToInt16(textBox4.Text), comboBox1.Text, sekarang);
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
            dgv.DataSource = GOR.tampilPengunjungFitness();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
