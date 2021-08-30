
namespace specflow_table_generator
{
    partial class SpecFlowTableGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecFlowTableGenerator));
            this.panel1 = new System.Windows.Forms.Panel();
            this.logging = new System.Windows.Forms.TextBox();
            this.clear = new System.Windows.Forms.Button();
            this.generate = new System.Windows.Forms.Button();
            this.SqlQuery = new System.Windows.Forms.Label();
            this.sqlText = new System.Windows.Forms.TextBox();
            this.connectionStringText = new System.Windows.Forms.TextBox();
            this.ConnectionString = new System.Windows.Forms.Label();
            this.results = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.logging);
            this.panel1.Controls.Add(this.clear);
            this.panel1.Controls.Add(this.generate);
            this.panel1.Controls.Add(this.SqlQuery);
            this.panel1.Controls.Add(this.sqlText);
            this.panel1.Controls.Add(this.connectionStringText);
            this.panel1.Controls.Add(this.ConnectionString);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1303, 225);
            this.panel1.TabIndex = 0;
            // 
            // logging
            // 
            this.logging.Location = new System.Drawing.Point(928, 43);
            this.logging.Multiline = true;
            this.logging.Name = "logging";
            this.logging.ReadOnly = true;
            this.logging.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logging.Size = new System.Drawing.Size(363, 179);
            this.logging.TabIndex = 7;
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(1040, 14);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(106, 23);
            this.clear.TabIndex = 6;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(928, 14);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(106, 23);
            this.generate.TabIndex = 5;
            this.generate.Text = "Generate";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // SqlQuery
            // 
            this.SqlQuery.AutoSize = true;
            this.SqlQuery.Location = new System.Drawing.Point(12, 46);
            this.SqlQuery.Name = "SqlQuery";
            this.SqlQuery.Size = new System.Drawing.Size(63, 15);
            this.SqlQuery.TabIndex = 4;
            this.SqlQuery.Text = "SQL Query";
            // 
            // sqlText
            // 
            this.sqlText.Location = new System.Drawing.Point(118, 43);
            this.sqlText.Multiline = true;
            this.sqlText.Name = "sqlText";
            this.sqlText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sqlText.Size = new System.Drawing.Size(804, 179);
            this.sqlText.TabIndex = 3;
            this.sqlText.Text = resources.GetString("sqlText.Text");
            this.sqlText.WordWrap = false;
            // 
            // connectionStringText
            // 
            this.connectionStringText.Location = new System.Drawing.Point(118, 14);
            this.connectionStringText.Name = "connectionStringText";
            this.connectionStringText.Size = new System.Drawing.Size(804, 23);
            this.connectionStringText.TabIndex = 2;
            this.connectionStringText.Text = "Data Source=localhost;Initial Catalog=DatingApp;Integrated Security=True";
            // 
            // ConnectionString
            // 
            this.ConnectionString.AutoSize = true;
            this.ConnectionString.Location = new System.Drawing.Point(12, 17);
            this.ConnectionString.Name = "ConnectionString";
            this.ConnectionString.Size = new System.Drawing.Size(100, 15);
            this.ConnectionString.TabIndex = 1;
            this.ConnectionString.Text = "ConnectionString";
            // 
            // results
            // 
            this.results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.results.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.results.Location = new System.Drawing.Point(0, 225);
            this.results.Multiline = true;
            this.results.Name = "results";
            this.results.ReadOnly = true;
            this.results.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.results.Size = new System.Drawing.Size(1303, 570);
            this.results.TabIndex = 4;
            this.results.WordWrap = false;
            // 
            // SpecFlowTableGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 795);
            this.Controls.Add(this.results);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpecFlowTableGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SpeckFlow Table Generator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SqlQuery;
        private System.Windows.Forms.TextBox sqlText;
        private System.Windows.Forms.TextBox connectionStringText;
        private System.Windows.Forms.Label ConnectionString;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.TextBox results;
        private System.Windows.Forms.TextBox logging;
    }
}

