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
    
    public partial class Form1 : Form
    {
        GelanggangOlahraga GOR;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult pilihan = MessageBox.Show("Apakah Anda yakin untuk keluar ? ", "Konfirmasi", MessageBoxButtons.YesNo);
            if (pilihan == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;
        }

        Form2 f2;
        private void button1_Click(object sender, EventArgs e)
        {
            //foreach (Form form in this.MdiChildren)
             //   form.Hide();
            if (f2 == null || !f2.IsHandleCreated)
            {
                f2 = new Form2();
                f2.refresh1();
                f2.MdiParent = this;
                f2.Activate();
                f2.Show();
            }
            else
            {
                foreach (Form form in this.MdiChildren)
                    form.Hide();
                f2.Show();
                f2.refresh1();
            }
        }

        Form3 f3;
        private void button2_Click(object sender, EventArgs e)
        {
            //foreach (Form form in this.MdiChildren)
            //    form.Hide();
            if (f3 == null || !f3.IsHandleCreated)
            {
                f3 = new Form3();
                f3.MdiParent = this;
                f3.Activate();
                f3.Show();
                f3.BringToFront();
            }
            else
            {
                foreach (Form form in this.MdiChildren)
                     form.Hide();
                f3.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GOR = new GelanggangOlahraga();
            Bulutangkis satu = new Bulutangkis("Lapangan 1", "Reguler");
            GOR.TambahLapanganBulutangkis(satu);
            Bulutangkis dua = new Bulutangkis("Lapangan 2", "Reguler");
            GOR.TambahLapanganBulutangkis(dua);

            ClsTransfer.gor = GOR;
        }
    }
}
