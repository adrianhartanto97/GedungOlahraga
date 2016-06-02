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
    public partial class FormBayar : Form
    {
        string detail;
        public FormBayar(string detail)
        {
            InitializeComponent();
            this.detail = detail;
        }

        private void FormBayar_Load(object sender, EventArgs e)
        {
            label1.Text = detail;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
