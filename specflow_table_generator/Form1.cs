using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using Dapper;
using table.lib;

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
            textBox3.Clear();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox3.AppendText($"Please fill in the connection string property!{Environment.NewLine}");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox3.AppendText($"Please fill in the SQL Query string property!{Environment.NewLine}");
                return;
            }

            GetSqlData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            results.Clear();
            textBox3.Clear();
        }

        private void GetSqlData()
        {
            var st = Stopwatch.StartNew();
            try
            {
                IEnumerable<IDictionary<string, object>> table;
                using (var connection = new SqlConnection(textBox1.Text))
                {
                    connection.Open();
                    table = connection.Query(textBox2.Text) as IEnumerable<IDictionary<string, object>>;
                }

                var result = DbTable.Add(table).ToSpecFlowString();
                results.AppendText(result);
                st.Stop();
                textBox3.AppendText($"Success in {st.ElapsedMilliseconds}{Environment.NewLine}ms");
            }
            catch (Exception ex)
            {
                st.Stop();
                textBox3.AppendText($"Failure in {st.ElapsedMilliseconds}{Environment.NewLine}ms");
                textBox3.AppendText($"{ex.Message}{Environment.NewLine}");
                if (ex.InnerException != null)
                    textBox3.AppendText($"{ex.InnerException.Message}{Environment.NewLine}");
            }
        }
    }
}
