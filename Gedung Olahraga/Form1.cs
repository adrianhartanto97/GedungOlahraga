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
        Transaksi transaksi;
        DaftarMember daftar;
        List<Panel> p = new List<Panel>();
        public Form1()
        {
            InitializeComponent();
            foreach (Control pa in this.Controls)
            {
                if (pa is Panel)
                {
                    p.Add((Panel)pa);
                }
            }
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
            if (f2!=null)
            {
                foreach (Form form in this.MdiChildren)
                    form.Hide();
                f2.Show();
                f2.refresh1();
                f2.refresh2();
            }

            else if (f2 == null || !f2.IsHandleCreated)
            {
                f2 = new Form2();
                f2.refresh1();
                f2.MdiParent = this;
                f2.Activate();
                f2.Show();
            }
        }

        Form3 f3;
        private void button2_Click(object sender, EventArgs e)
        {
            if (f3!=null)
            {
                foreach (Form form in this.MdiChildren)
                     form.Hide();
                f3.Show();
                f3.refresh1();
            }
            else if (f3 == null || !f3.IsHandleCreated)
            {
                f3 = new Form3();
                f3.MdiParent = this;
                f3.Activate();
                f3.Show();
                f3.BringToFront();
            }        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel2.Location = new Point(0, 27);
            GOR = new GelanggangOlahraga();
            Bulutangkis bulutangkis_satu = new Bulutangkis("Lapangan 1", "Reguler");
            GOR.TambahLapanganBulutangkis(bulutangkis_satu);
            Bulutangkis bulutangkis_dua = new Bulutangkis("Lapangan 2", "Reguler");
            GOR.TambahLapanganBulutangkis(bulutangkis_dua);

            Basket basket_satu = new Basket("Lapangan 1", "Reguler");
            GOR.TambahLapanganBasket(basket_satu);

            Futsal futsal_satu = new Futsal("Lapangan 1" ,"Reguler");
            GOR.TambahLapanganFutsal(futsal_satu);

            Renang anak = new Renang("Pool Anak-anak", "Anak-Anak", 25000, 15, 10, 1);
            GOR.TambahKolamRenang(anak);

            Renang dewasa = new Renang("Pool Dewasa", "Dewasa", 35000, 30, 20, 3);
            GOR.TambahKolamRenang(dewasa);

            Fitness fitness1 = new Fitness("Fitness 1", 50000);
            GOR.TambahFitness(fitness1);

            ClsTransfer.gor = GOR;

            transaksi = new Transaksi();
            ClsTransfer.transaksi = transaksi;

            daftar = new DaftarMember();
            ClsTransfer.daftar = daftar;
        }

        private void olahragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                if (form!=null)
                    form.Hide();

            foreach (Panel pa in p)
            {
                pa.Hide();
            }
            panel1.Show();

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Form4 f4;
        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                if (form != null)
                    form.Hide();

            foreach (Panel pa in p)
            {
                pa.Hide();
            }
            if (f4 != null)
            {
                foreach (Form form in this.MdiChildren)
                    form.Hide();
                f4.Show();
            }

            else if (f4 == null || !f4.IsHandleCreated)
            {
                f4 = new Form4();
                f4.MdiParent = this;
                f4.Activate();
                f4.Show();
            }

        }

        Form5 f5;
        private void button3_Click(object sender, EventArgs e)
        {
            if (f5 != null)
            {
                foreach (Form form in this.MdiChildren)
                    form.Hide();
                f5.Show();
                f5.refresh1();
            }
            else if (f5 == null || !f5.IsHandleCreated)
            {
                f5 = new Form5();
                f5.MdiParent = this;
                f5.Activate();
                f5.Show();
                f5.BringToFront();
            }
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Panel pa in p)
            {
                pa.Hide();
            }
            panel2.Show();

            foreach (Form form in this.MdiChildren)
                if (form != null)
                    form.Hide();
        }

        Form6 f6;
        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                if (form != null)
                    form.Hide();

            f6 = new Form6();
            f6.MdiParent = this;
            f6.Activate();
            f6.Show();
        }

        Form7 f7;
        private void button7_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                if (form != null)
                    form.Hide();

            f7 = new Form7();
            f7.MdiParent = this;
            f7.Activate();
            f7.Show();
        }

        Form8 f8;
        private void button8_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                if (form != null)
                    form.Hide();

            f8 = new Form8();
            f8.MdiParent = this;
            f8.Activate();
            f8.Show();
        }

        Form9 f9;
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Hide();
            f9 = new Form9();
            f9.MdiParent = this;
            f9.Show();
            f9.refresh();
            f9.refresh2();
        }

        Form10 f10;
        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
                form.Hide();
            f10 = new Form10();
            f10.MdiParent = this;
            f10.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "Created by :\n";
            s += "1. Adrian Hartanto [14.111.1537]\n";
            s += "2. William Sumitro [14.111.1821]\n";
            s += "3. Chyntia                [14.111.0817]\n";
            s += "4. Agustini               [14.111.0523]\n";
            s += "5. Kelvin                   [14.111.1308]\n";
            MessageBox.Show(s); 
        }
    }
}
