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
    public partial class Form4 : Form
    {
        Transaksi transaksi;
        DataTable dt = new DataTable();
        public Form4()
        {
            InitializeComponent();
            transaksi = ClsTransfer.transaksi;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 3);
            radioButton1.Checked = true;
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

        public void refresh()
        {
            dgv.Rows.Clear();
            if (dt !=null && dt.Rows.Count > 0)
            {
                int c = 0;
                foreach (DataRow r in dt.Rows)
                {
                    dgv.Rows.Add();
                    dgv[0, c].Value = r[0].ToString();
                    dgv[1, c].Value = r[1].ToString();
                    dgv[2, c].Value = r[2].ToString();
                    dgv[3, c].Value = r[3].ToString();
                    dgv[4, c].Value = r[4].ToString();
                    dgv[5, c].Value = "Rp " + r[5].ToString();
                    c++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                dt = transaksi.tampiltransaksi();
            else if (radioButton2.Checked)
                dt = transaksi.tampiltransaksi("Bulutangkis");
            else if (radioButton3.Checked)
                dt = transaksi.tampiltransaksi("Basket");
            else if (radioButton4.Checked)
                dt = transaksi.tampiltransaksi("Futsal");
            else
                dt = null;
            
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ol="semua";
            if (radioButton1.Checked)
                ol = "semua";
            else if (radioButton2.Checked)
                ol = "Bulutangkis";
            else if (radioButton3.Checked)
                ol = "Basket";
            else if (radioButton4.Checked)
                ol = "Futsal";


            if (textBox1.Text != "")
                dt = transaksi.tampilnamapenyewa(textBox1.Text,ol);

            refresh();
        }
    }
}
