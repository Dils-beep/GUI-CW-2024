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
    public partial class formorder : Form
    {
        public formorder()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if txttot.Text is a valid number before converting
            decimal TotalAmount;
            if (decimal.TryParse(this.txtbill.Text, out TotalAmount))
            {
                //connection
                string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
                         "Initial Catalog=CWdb;Integrated Security=True";
                SqlConnection con = new SqlConnection(cs);
                con.Open();

                //command
                string sql = "INSERT INTO tblOrder(OrderID, OrderDate, CustomerName, TotalAmount) VALUES (@oid, @odate, @cname, @tot)";
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddWithValue("@oid", Convert.ToInt32(this.txtoid.Text));
                com.Parameters.AddWithValue("@odate", this.dateTimePicker1.Value);  // Assuming dtpick is a DateTimePicker
                com.Parameters.AddWithValue("@cname", this.txtcname.Text);
                com.Parameters.AddWithValue("@tot", txtbill);  // Using validated decimal value

                //execute
                int ret = com.ExecuteNonQuery();
                MessageBox.Show("Number of records inserted: " + ret, "Information");

                //disconnect
                con.Close();
            }
            else
            {
                // Display a message if the total amount is invalid
                MessageBox.Show("Please enter a valid numeric value for the total amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnadord_Click(object sender, EventArgs e)
        {
            //connection
            string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
                         "Initial Catalog=CWdb;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //command
            string sql = "INSERT INTO tblOrderDetails1(orderid, bookname,bookprice, quantity, totalprice) " +
                "VALUES (@oid, @bname, @bprice ,@bqty, @btot)";
            SqlCommand com = new SqlCommand(sql, con);

            if (!int.TryParse(this.txtoid.Text, out int orderID))
            {
                MessageBox.Show("Please enter a valid numeric Order ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            com.Parameters.AddWithValue("@oid", orderID);

            com.Parameters.AddWithValue("@bname", this.comboBox1.Text);
            com.Parameters.AddWithValue("@bprice", this.txtprice.Text);
            com.Parameters.AddWithValue("@bqty", this.numericUpDown1.Value);
            double tot = Convert.ToDouble(this.txtprice.Text) * Convert.ToDouble(this.numericUpDown1.Value);
            com.Parameters.AddWithValue("@btot", tot);

            //execute
            int ret = com.ExecuteNonQuery();
            MessageBox.Show("Number of records inserted: " + ret, "Information");

            //load data to grid view1
            string sql2 = "SELECT * FROM tblOrderDetails1 WHERE orderid = @oid";
            SqlCommand com2 = new SqlCommand(sql2, con);
            com2.Parameters.AddWithValue("@oid", this.txtoid.Text);

            //data apdaptor
            SqlDataAdapter dap = new SqlDataAdapter(com2);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            this.dataGridView1.DataSource = ds.Tables[0];

            double sum = 0.00;
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                sum += Convert.ToInt32(this.dataGridView1.Rows[i].Cells[4].Value);
            }
            this.txtbill.Text = sum.ToString("N2");

            //disconnect
            con.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
                          "Initial Catalog=CWdb;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            // command
            string sql = "SELECT Price FROM tblBooks WHERE BookName = @bname;";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@bname", this.comboBox1.Text);

            // access data
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read()) // Check if there is data
            {
                this.txtprice.Text = dr.GetValue(0).ToString();
            }
            else
            {
                MessageBox.Show("No price found for the selected book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // disconnect
            con.Close();

        }

        private void formorder_Load(object sender, EventArgs e)
        {
            //connection
            string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
                           "Initial Catalog=CWdb;Integrated Security=True"; ;
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //command
            string sql = "SELECT BookName FROM tblBooks";
            SqlCommand com = new SqlCommand(sql, con);

            // access data
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr.GetValue(0));
            }

            //disconnect
            con.Close();


        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            // create connection
            string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
                        "Initial Catalog=CWdb;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            //define command with sql statement
            string sql = "SELECT * FROM tblOrder WHERE sid = @txtsearch"; //get data where search
            SqlCommand com = new SqlCommand(sql, con);

            //take parameter search text box
            com.Parameters.AddWithValue("@txtsearch", txtsearch.Text);

            //access data using data reader
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                //bind data with controls
                this.txtoid.Text            = dr.GetValue(0).ToString();
                this.comboBox1.Text         = dr.GetValue(1).ToString();
                this.txtprice.Text           = dr.GetValue(2).ToString();
                this.numericUpDown1.Text    = dr.GetValue(3).ToString();

            }
            else
            {
                MessageBox.Show("invalid search key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //disconnect from SQL source
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtoid.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            this.comboBox1.Text = this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            this.txtprice.Text = this.dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            this.numericUpDown1.Text = this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
