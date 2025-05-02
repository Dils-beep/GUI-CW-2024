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
    public partial class formdelete : Form
    {
        public formdelete()
        {
            InitializeComponent();
        }

        // create connection
        string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
            "Initial Catalog=CWdb;Integrated Security=True";
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
        private void btnload_Click(object sender, EventArgs e)
        {
            // Create connection
            string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
                        "Initial Catalog=CWdb;Integrated Security=True";

            SqlConnection con = null;

            try
            {
                con = new SqlConnection(cs);
                con.Open();

                // Define a command
                string sql = "DELETE FROM tblBooks WHERE BookID=@bid";
                SqlCommand com = new SqlCommand(sql, con);

                // Add parameter
                com.Parameters.AddWithValue("@bid", this.txtbid.Text);

                // Confirm deletion with the user
                DialogResult msgret = MessageBox.Show("ARE YOU SURE TO DELETE THIS RECORD?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (msgret == DialogResult.Yes)
                {
                    // Execute the command
                    int ret = com.ExecuteNonQuery();

                    // Provide feedback
                    if (ret > 0)
                    {
                        MessageBox.Show("No of records Deleted: " + ret, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No record was found with the given Book ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
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

                // Clear the input field for Book ID
                this.txtbid.Clear();
            }


        }

        private void btnloadt_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
