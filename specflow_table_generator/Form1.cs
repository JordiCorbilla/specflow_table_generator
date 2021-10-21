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

        private void Generate_Click(object sender, EventArgs e)
        {
            results.Clear();
            logging.Clear();
            if (string.IsNullOrEmpty(connectionStringText.Text))
            {
                logging.AppendText($"Please fill in the connection string property!{Environment.NewLine}");
                return;
            }
            if (string.IsNullOrEmpty(sqlText.Text))
            {
                logging.AppendText($"Please fill in the SQL Query string property!{Environment.NewLine}");
                return;
            }

            GetSqlData();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            results.Clear();
            logging.Clear();
        }

        private void GetSqlData()
        {
            var st = Stopwatch.StartNew();
            try
            {
                IEnumerable<IDictionary<string, object>> table;
                using (var connection = new SqlConnection(connectionStringText.Text))
                {
                    connection.Open();
                    table = connection.Query(sqlText.Text) as IEnumerable<IDictionary<string, object>>;
                }

                var result = DbTable.Add(table, new Options
                {
                    DateFormat = "yyyy-MM-dd HH:mm:ss.fff"
                }).ToSpecFlowString();
                results.AppendText(result);
                st.Stop();
                logging.AppendText($"Success in {st.ElapsedMilliseconds}ms{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                st.Stop();
                logging.AppendText($"Failure in {st.ElapsedMilliseconds}ms{Environment.NewLine}");
                logging.AppendText($"{ex.Message}{Environment.NewLine}");
                if (ex.InnerException != null)
                    logging.AppendText($"{ex.InnerException.Message}{Environment.NewLine}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlText.Clear();
        }
    }
}
