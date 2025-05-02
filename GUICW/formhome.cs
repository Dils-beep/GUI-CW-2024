using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICW
{
    public partial class formhome : Form
    {
        public formhome()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formadd add = new formadd();
            add.MdiParent = this;
            add.Show();
        }

        private void updateBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formupdate upd = new formupdate();
            upd.MdiParent = this;
            upd.Show();
        }

        private void deleteBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formdelete dlt= new formdelete();
            dlt.MdiParent = this;
            dlt.Show();

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formorder ord = new formorder();
            ord.MdiParent = this;
            ord.Show();
        }

        private void logOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formlogin formlogin = new formlogin();
            formlogin.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
