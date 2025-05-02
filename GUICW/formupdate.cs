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
    public partial class formupdate : Form
    {
        DataSet ds;
        //databse connection
        string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
        "Initial Catalog=CWdb;Integrated Security=True";

        public formupdate()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();

                    // Define command to retrieve data
                    string sql = "SELECT * FROM tblBooks";
                    SqlCommand com = new SqlCommand(sql, con);

                    // Use SqlDataAdapter to fetch data
                    SqlDataAdapter dap = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    dap.Fill(ds);

                    // Bind data to DataGridView
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
            
            /* SqlConnection con = new SqlConnection(cs);

             con.Open();

             //define a command with sql statement
             string sql = "SELECT * from tblBooks";
             SqlCommand com = new SqlCommand(sql, con);

             //Access data using data reader method
             SqlDataReader dr = com.ExecuteReader();
             dr.Read();

             // Bind data with controls
             this.txtbid.Text = dr.GetValue(0).ToString();
             this.txtbname.Text = dr.GetValue(1).ToString();
             this.txtauthor.Text = dr.GetValue(2).ToString();
             this.txtprice.Text = dr.GetValue(3).ToString();
             this.numericUpDown1.Text = dr.GetValue(4).ToString();

             // Disconnect from ths sql
             con.Close();*/
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

            // Database connection
            string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
                        "Initial Catalog=CWdb;Integrated Security=True";

            SqlConnection con = null;

            try
            {
                // Initialize and open the connection
                con = new SqlConnection(cs);
                con.Open();

                // Define command
                string sql = "UPDATE tblBooks SET BookName=@bn, Author=@au, Price=@price, Quantity=@quan WHERE BookID=@bid";
                SqlCommand com = new SqlCommand(sql, con);

                // Add parameters
                com.Parameters.AddWithValue("@bid", this.txtbid.Text);
                com.Parameters.AddWithValue("@bn", this.txtbname.Text);
                com.Parameters.AddWithValue("@au", this.txtauthor.Text);
                com.Parameters.AddWithValue("@price", this.txtprice.Text);
                com.Parameters.AddWithValue("@quan", this.numericUpDown1.Value);

                // Execute the command
                int ret = com.ExecuteNonQuery();
                MessageBox.Show("No of records updated: " + ret, "Information");
            }
            catch (SqlException sqlEx)
            {
                // Handle SQL-specific exceptions
                MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed
                if (con != null && con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }

                // Clear input fields regardless of success or failure
                this.txtauthor.Clear();
                this.txtprice.Clear();
                this.txtbid.Clear();
                this.txtbname.Clear();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
