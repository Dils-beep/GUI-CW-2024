namespace GUICW
{
    partial class formdelete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formdelete));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnloadt = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnload = new System.Windows.Forms.Button();
            this.txtbid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.btnloadt);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnload);
            this.panel1.Controls.Add(this.txtbid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 588);
            this.panel1.TabIndex = 0;
            // 
            // btnloadt
            // 
            this.btnloadt.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnloadt.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnloadt.ForeColor = System.Drawing.Color.Brown;
            this.btnloadt.Location = new System.Drawing.Point(473, 403);
            this.btnloadt.Name = "btnloadt";
            this.btnloadt.Size = new System.Drawing.Size(168, 59);
            this.btnloadt.TabIndex = 26;
            this.btnloadt.Text = "Load Data";
            this.btnloadt.UseVisualStyleBackColor = false;
            this.btnloadt.Click += new System.EventHandler(this.btnloadt_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 293);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(401, 270);
            this.dataGridView1.TabIndex = 25;
            // 
            // btnload
            // 
            this.btnload.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnload.ForeColor = System.Drawing.Color.Brown;
            this.btnload.Location = new System.Drawing.Point(401, 188);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(161, 59);
            this.btnload.TabIndex = 2;
            this.btnload.Text = "Delete Book";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // txtbid
            // 
            this.txtbid.Location = new System.Drawing.Point(473, 125);
            this.txtbid.Name = "txtbid";
            this.txtbid.Size = new System.Drawing.Size(100, 26);
            this.txtbid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Pink;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(342, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book ID";
            // 
            // formdelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 588);
            this.Controls.Add(this.panel1);
            this.Name = "formdelete";
            this.Text = "Delete";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbid;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Button btnloadt;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}