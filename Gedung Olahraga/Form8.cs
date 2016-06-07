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
    public partial class Form8 : Form
    {
        DaftarMember daftar;
        List<TextBox> t = new List<TextBox>();
        int index;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 130);
            daftar = ClsTransfer.daftar;

            foreach (Control pa in this.Controls)
            {
                if (pa is TextBox)
                {
                    t.Add((TextBox)pa);
                }
            }
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
            if (textBox1.Text != "")
            {
                index = daftar.cariMember(textBox1.Text);
                if (index == -1)
                { MessageBox.Show("Member tidak ditemukan !!"); }
                else
                {
                    textBox1.Enabled = false;
                    button1.Enabled = false;
                    panel1.Visible = true;
                    panel2.Visible = true;
                    comboBox2.SelectedIndex = 0;
                    textBox2.Text = daftar.daftar[index].nama;
                    textBox3.Text = daftar.daftar[index].tempat_lahir;
                    textBox4.Text = daftar.daftar[index].tanggal_lahir;
                    if (daftar.daftar[index].jenis_kelamin == "Laki-laki")
                        comboBox1.SelectedIndex = 0;
                    else
                        comboBox1.SelectedIndex = 1;
                    textBox5.Text = daftar.daftar[index].alamat;
                    textBox6.Text = daftar.daftar[index].agama;
                    textBox7.Text = daftar.daftar[index].pekerjaan;
                }
            }
            else
            { MessageBox.Show("Mohon isi ID Member"); }
        }

        private void button2_Click(object sender, EventArgs e)
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
                string nama = textBox2.Text;
                string tempat = textBox3.Text;
                string tanggal = textBox4.Text;
                string jenis_kelamin = comboBox1.Text;
                string alamat = textBox5.Text;
                string agama = textBox6.Text;
                string pekerjaan = textBox7.Text;

                daftar.editMember(index, nama, tempat, tanggal, jenis_kelamin, alamat, agama, pekerjaan);
                MessageBox.Show("Data Member berhasil di-Edit!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
                daftar.perpanjangMember(index, 6);
            else if (comboBox2.SelectedIndex == 1)
                daftar.perpanjangMember(index, 9);
            else if (comboBox2.SelectedIndex == 2)
                daftar.perpanjangMember(index, 12);
            MessageBox.Show("Keanggotaan Member berhasil diperpanjang !!");
            //MessageBox.Show(daftar.daftar[index].tanggal_expired.ToShortDateString());
        }
    }
}
