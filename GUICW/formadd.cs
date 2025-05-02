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
    public partial class formadd : Form
    {
        //databse connection
        string cs = "Data Source=DESKTOP-04R8BVD\\SQLEXPRESS01;" +
        "Initial Catalog=CWdb;Integrated Security=True";

        public formadd()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbname.Text) ||
       string.IsNullOrWhiteSpace(txtauthor.Text) ||
       string.IsNullOrWhiteSpace(txtprice.Text) ||
       string.IsNullOrWhiteSpace(numericUpDown1.Text))
            {
                MessageBox.Show("All fields are required. Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate numeric inputs
            if (!decimal.TryParse(txtprice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid numeric value for Price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(numericUpDown1.Text, out int quantity))
            {
                MessageBox.Show("Please enter a valid integer value for Quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Database operation
            using (SqlConnection conn = new SqlConnection(cs))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tblBooks (BookName, Author, Price, Quantity) VALUES (@BookName, @Author, @Price, @Quantity)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@BookName", txtbname.Text);
                    cmd.Parameters.AddWithValue("@Author", txtauthor.Text);
                    cmd.Parameters.AddWithValue("@Price", price); // Use parsed value
                    cmd.Parameters.AddWithValue("@Quantity", quantity); // Use parsed value

                    // Execute query
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException sqlEx)
                {
                    // Handle SQL-specific errors
                    MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Handle general exceptions
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
    }

        
    
}
