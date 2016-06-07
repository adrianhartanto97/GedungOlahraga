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
    public partial class FormSewa : Form
    {
        long tarif;
        long tagihan;
        bool ismember;
        DaftarMember daftar;
        public FormSewa(long tarif)
        {
            InitializeComponent();
            this.tarif = tarif;
            daftar = ClsTransfer.daftar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClsTransfer.sah = false;
            this.Close();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                ClsTransfer.sah = true;
                ClsTransfer.jam = (int)numericUpDown1.Value;
                ClsTransfer.nama_penyewa = textBox2.Text;
                ClsTransfer.tagihan = tagihan;
                this.Close();
            }
            else
                MessageBox.Show("Data belum valid");
        }

        private void FormSewa_Load(object sender, EventArgs e)
        {
            label5.Text = String.Format("Tarif / jam  = Rp. {0} (non-member)", tarif);
            numericUpDown1.Value = 1;
            tagihan = Convert.ToInt32(numericUpDown1.Value ) * tarif;
            textBox3.Text = String.Format("Rp. {0}", tagihan);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            refresh_harga();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) { textBox1.Enabled = false; ismember = false; refresh_harga(); button3.Text = "Cek"; button3.Enabled = false; }
            else textBox1.Enabled = true;
        }

        private void refresh_harga()
        {
            tagihan = Convert.ToInt32(numericUpDown1.Value) * tarif;
            if (ismember) tagihan = tagihan * 80 / 100;
            textBox3.Text = String.Format("Rp. {0}", tagihan);
            if (ismember)
                textBox3.Text += "  (Member diskon 20%)";
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }
    }
}
