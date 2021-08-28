using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Dapper;

namespace specflow_table_generator
{
    public partial class SpecFlowTableGenerator : Form
    {
        public SpecFlowTableGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            results.Clear();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                results.AppendText("Please fill in the connection string property!");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                results.AppendText("Please fill in the SQL Query string property!");
                return;
            }

            GetSqlData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            results.Clear();
        }

        private void GetSqlData()
        {
            IEnumerable<IDictionary<string, object>> table;
            using (var connection = new SqlConnection(textBox1.Text))
            {
                connection.Open();
                table = connection.Query(textBox2.Text) as IEnumerable<IDictionary<string, object>>;
            }

            foreach (var row in table)
            {
                //then iterate the columns and get a KeyValuePair for each column
                foreach (var col in row)
                {
                    results.AppendText($"{col.Key} {col.Value}{Environment.NewLine}");
                }
            }
        }
    }
}
