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
    public partial class Form5 : Form
    {
        GelanggangOlahraga GOR;
        Transaksi transaksi;
        int minutes1, seconds1, hours1;
        public Form5()
        {
            InitializeComponent();
            GOR = ClsTransfer.gor;
            transaksi = ClsTransfer.transaksi;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 130);
            timer1.Enabled = false;
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

        public void refresh1()
        {
            string s;
            s = String.Format("{0} ({1})", GOR.lapangan_futsal[0].nama_lapangan, GOR.lapangan_futsal[0].jenis);
            label1.Text = s;
            s = GOR.lapangan_futsal[0].status();
            label3.Text = s;
            if (label3.Text == "Free") label3.ForeColor = Color.Green;
            else label3.ForeColor = Color.Red;
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(GOR.detail_sewafutsal("Lapangan 1"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Futsal lapangan1 = GOR.lapangan_futsal[0];
            FormSewa fs = new FormSewa(lapangan1.tarif);
            fs.ShowDialog();
            bool sah = ClsTransfer.sah;
            if (sah)
            {
                string nama_penyewa = ClsTransfer.nama_penyewa;
                int jam = ClsTransfer.jam;
                long tagihan = ClsTransfer.tagihan;
                GOR.sewa_futsal("Lapangan 1", nama_penyewa, DateTime.Now, jam, tagihan);
                refresh1();
                DateTime selesai = lapangan1.waktu_selesai;
                TimeSpan ts = selesai.Subtract(DateTime.Now);
                hours1 = (int)ts.Hours;
                minutes1 = (int)ts.Minutes; seconds1 = (int)ts.Seconds;
                
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;

                transaksi.tambahtransaksi(nama_penyewa, "Futsal", "Lapangan 1", DateTime.Now, selesai, tagihan);
                timer1.Enabled = true;
                timer1.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Stop")
            {
                timer1.Enabled = false;
                button3.Text = "Resume";
            }
            else if (button3.Text == "Resume")
            {
                timer1.Enabled = true;
                button3.Text = "Stop";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            FormBayar fb = new FormBayar(GOR.detail_sewafutsal("Lapangan 1"));
            fb.ShowDialog();
            GOR.bayar_futsal("Lapangan 1");
            refresh1();
            timer1.Stop();
            timer1.Enabled = false;
            label5.Text = "00"; label6.Text = "00"; label7.Text = "00";
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button3.Text = "Stop";
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(GOR.detail_sewafutsal("Lapangan 1"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Verify if the time didn't pass.
            if ((minutes1 == 0) && (hours1 == 0) && (seconds1 == 0))
            {
                // If the time is over, clear all settings and fields.
                // Also, show the message, notifying that the time is over.
                timer1.Enabled = false;
                MessageBox.Show("Waktu habis");
                label5.Text = "00";
                label6.Text = "00";
                label7.Text = "00";
                FormBayar fb = new FormBayar(GOR.detail_sewafutsal("Lapangan 1"));
                fb.ShowDialog();
                GOR.bayar_futsal("Lapangan 1");
                refresh1();
                timer1.Stop();
                timer1.Enabled = false;
                label5.Text = "00"; label6.Text = "00"; label7.Text = "00";
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else
            {
                // Else continue counting.
                if (seconds1 < 1)
                {
                    seconds1 = 59;
                    if (minutes1 == 0)
                    {
                        minutes1 = 59;
                        if (hours1 != 0)
                            hours1 -= 1;

                    }
                    else
                    {
                        minutes1 -= 1;
                    }
                }
                else
                    seconds1 -= 1;

                label5.Text = hours1.ToString() + " jam";
                label6.Text = minutes1.ToString() + " menit";
                label7.Text = seconds1.ToString() + " detik";
            }
        }

    }
}
