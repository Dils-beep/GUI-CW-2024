using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICW
{
    public partial class formlogin : Form
    {

        public formlogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            //databse connection
            string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
            "Initial Catalog=CWdb;Integrated Security=True";

            //new sql connection
            SqlConnection conn = new SqlConnection(cs);

            //open connection
            conn.Open();


            //query to check data match
            string sql = "SELECT * FROM tblUsers WHERE username = @Username  AND password =@Password";

            //sql command with query
            SqlCommand com = new SqlCommand(sql, conn);

            //add parameters
            com.Parameters.AddWithValue("@Username", this.txtuname.Text);
            com.Parameters.AddWithValue("@Password", this.txtpswd.Text);


            //access data using data reader method
            SqlDataReader dr = com.ExecuteReader();

            //if user entered data match the data in the table
            if (dr.Read() == true)
            {
                formhome home = new formhome();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error");
            }

            //disconnect from server
            conn.Close();
            this.txtuname.Clear();
            this.txtpswd.Clear();

        }
    }
}
