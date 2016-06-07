using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Gedung_Olahraga
{
    public partial class Form2 : Form
    {
        GelanggangOlahraga GOR;
        Transaksi transaksi;
        int minutes1,seconds1,hours1;
        int minutes2, seconds2, hours2;
        int waktu = 0;
        public Form2()
        {
            InitializeComponent();
            GOR = ClsTransfer.gor;
            transaksi = ClsTransfer.transaksi;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 130);
            refresh1();
            refresh2();
            timer3.Enabled = true;
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
            Bulutangkis lapangan1 = GOR.lapangan_bulutangkis[0];
            FormSewa fs = new FormSewa(lapangan1.tarif);
            fs.ShowDialog();
            bool sah = ClsTransfer.sah;
            if (sah)
            {
                string nama_penyewa = ClsTransfer.nama_penyewa;
                int jam = ClsTransfer.jam;
                long tagihan = ClsTransfer.tagihan;
                GOR.sewa_bulutangkis("Lapangan 1", nama_penyewa, DateTime.Now, jam, tagihan);
                refresh1();
                DateTime selesai = lapangan1.waktu_selesai;

                TimeSpan ts = selesai.Subtract(DateTime.Now);
                hours1 = ts.Hours;
                minutes1 = ts.Minutes; seconds1 = ts.Seconds;
                timer1.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;

                transaksi.tambahtransaksi(nama_penyewa, "Bulutangkis", "Lapangan 1", DateTime.Now, selesai, tagihan);
            }       
        }

        public void refresh1()
        {
            string s;
            s = String.Format("{0} ({1})", GOR.lapangan_bulutangkis[0].nama_lapangan, GOR.lapangan_bulutangkis[0].jenis);
            label1.Text = s;
            s = GOR.lapangan_bulutangkis[0].status();
            label3.Text = s;
            if (label3.Text== "Free" ) label3.ForeColor = Color.Green;
            else label3.ForeColor = Color.Red;
        }

        public void refresh2()
        {
            string s;
            s = String.Format("{0} ({1})", GOR.lapangan_bulutangkis[1].nama_lapangan, GOR.lapangan_bulutangkis[1].jenis);
            label14.Text = s;
            s = GOR.lapangan_bulutangkis[1].status();
            label12.Text = s;
            if (label12.Text == "Free") label12.ForeColor = Color.Green;
            else label12.ForeColor = Color.Red;
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
                FormBayar fb = new FormBayar(GOR.detail_sewabulutangkis("Lapangan 1"));
                fb.ShowDialog();
                GOR.bayar_bulutangkis("Lapangan 1");
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
                // Display the current values of hours, minutes and seconds in
                // the corresponding fields.
                label5.Text = hours1.ToString() + " jam";
                label6.Text = minutes1.ToString() + " menit";
                label7.Text = seconds1.ToString() + " detik";
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(GOR.detail_sewabulutangkis("Lapangan 1"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
             timer1.Stop();
            FormBayar fb = new FormBayar(GOR.detail_sewabulutangkis("Lapangan 1"));
            fb.ShowDialog();
            GOR.bayar_bulutangkis("Lapangan 1");
            refresh1();
            timer1.Stop();
            timer1.Enabled = false;
            label5.Text = "00"; label6.Text = "00"; label7.Text = "00";
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button3.Text = "Stop";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bulutangkis lapangan2 = GOR.lapangan_bulutangkis[1];
            FormSewa fs = new FormSewa(lapangan2.tarif);
            fs.ShowDialog();
            bool sah = ClsTransfer.sah;
            if (sah)
            {
                string nama_penyewa = ClsTransfer.nama_penyewa;
                int jam = ClsTransfer.jam;
                long tagihan = ClsTransfer.tagihan;
                GOR.sewa_bulutangkis("Lapangan 2", nama_penyewa, DateTime.Now, jam, tagihan);
                refresh2();
                DateTime selesai = lapangan2.waktu_selesai;

                TimeSpan ts = selesai.Subtract(DateTime.Now);
                hours2 = ts.Hours;
                minutes2 = ts.Minutes; seconds2 = ts.Seconds;
                timer2.Enabled = true;
                button4.Enabled = false;
                button6.Enabled = true;
                button5.Enabled = true;

                transaksi.tambahtransaksi(nama_penyewa, "Bulutangkis", "Lapangan 2", DateTime.Now, selesai, tagihan);
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Verify if the time didn't pass.
            if ((minutes2 == 0) && (hours2 == 0) && (seconds2 == 0))
            {
                // If the time is over, clear all settings and fields.
                // Also, show the message, notifying that the time is over.
                timer2.Enabled = false;
                MessageBox.Show("Waktu habis");
                label10.Text = "00"; label9.Text = "00"; label8.Text = "00";
                FormBayar fb = new FormBayar(GOR.detail_sewabulutangkis("Lapangan 2"));
                fb.ShowDialog();
                GOR.bayar_bulutangkis("Lapangan 2");
                refresh2();
                timer2.Stop();
                timer2.Enabled = false;
                
                button4.Enabled = true;
                button6.Enabled = false;
            }
            else
            {
                // Else continue counting.
                if (seconds2 < 1)
                {
                    seconds2 = 59;
                    if (minutes2 == 0)
                    {
                        minutes2 = 59;
                        if (hours2 != 0)
                            hours2 -= 1;

                    }
                    else
                    {
                        minutes2 -= 1;
                    }
                }
                else
                    seconds2 -= 1;
                // Display the current values of hours, minutes and seconds in
                // the corresponding fields.
                label10.Text = hours2.ToString() + " jam";
                label9.Text = minutes2.ToString() + " menit";
                label8.Text = seconds2.ToString() + " detik";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(GOR.detail_sewabulutangkis("Lapangan 2"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Stop")
            {
                timer2.Enabled = false;
                button5.Text = "Resume";
            }
            else if (button5.Text == "Resume")
            {
                timer2.Enabled = true;
                button5.Text = "Stop";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            FormBayar fb = new FormBayar(GOR.detail_sewabulutangkis("Lapangan 2"));
            fb.ShowDialog();
            GOR.bayar_bulutangkis("Lapangan 2");
            refresh2();
            timer2.Stop();
            timer2.Enabled = false;
            label10.Text = "00"; label9.Text = "00"; label8.Text = "00";
            button4.Enabled = true;
            button6.Enabled = false;
            button5.Enabled = false;
            button5.Text = "Stop";
        }

        int c=0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            string x;
            if (waktu % 20 == 0)
            { 
                x = "badminton_"+(c+1).ToString();
                object o = Properties.Resources.ResourceManager.GetObject(x);
                this.BackgroundImage = (Image)o;
                
                c++;
                c%=5;
            }
            waktu++;
        }
    }
}
