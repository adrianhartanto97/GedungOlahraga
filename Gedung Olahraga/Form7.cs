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
    public partial class Form7 : Form
    {

        DaftarMember daftar;
        public Form7()
        {
            InitializeComponent();
            daftar = ClsTransfer.daftar;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 130);
            dataGridView1.DataSource = daftar.tampilMember();
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
            dataGridView1.DataSource = daftar.tampilMember();
        }
    }
}
