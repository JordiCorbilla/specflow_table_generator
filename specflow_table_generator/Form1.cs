using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Microsoft.Data.SqlClient;
using table.lib;

namespace specflow_table_generator
{
    public partial class SpecFlowTableGenerator : Form
    {
        private readonly Timer settingsSaveTimer;
        private bool isLoadingSettings;

        public SpecFlowTableGenerator()
        {
            InitializeComponent();
            settingsSaveTimer = new Timer { Interval = 750 };
            settingsSaveTimer.Tick += SettingsSaveTimer_Tick;
            LoadUserSettings();
            TrackSettingsChanges();
        }

        private async void Generate_Click(object sender, EventArgs e)
        {
            results.Clear();
            logging.Clear();
            if (string.IsNullOrWhiteSpace(connectionStringText.Text))
            {
                Log("Please enter a SQL Server name or a full connection string.");
                return;
            }

            if (string.IsNullOrWhiteSpace(sqlText.Text))
            {
                Log("Please enter a SQL query.");
                return;
            }

            SetRunningState(true);
            try
            {
                await GetSqlDataAsync();
            }
            finally
            {
                SetRunningState(false);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            results.Clear();
            logging.Clear();
            copyResults.Enabled = false;
        }

        private async Task GetSqlDataAsync()
        {
            var st = Stopwatch.StartNew();
            try
            {
                List<IDictionary<string, object>> table;
                using (var connection = new SqlConnection(BuildConnectionString()))
                {
                    await connection.OpenAsync();
                    var rows = await connection.QueryAsync(sqlText.Text);
                    table = rows.Cast<IDictionary<string, object>>().ToList();
                }

                var result = DbTable.Add(table, new Options
                {
                    DateFormat = "yyyy-MM-dd HH:mm:ss.fff"
                }).FilterColumns(new[] { "AuditUser", "AuditStartTime", "AuditEndTime" }).ToSpecFlowString();
                results.AppendText(result);
                st.Stop();
                Log($"Success: {table.Count} row(s) generated in {st.ElapsedMilliseconds}ms.");
            }
            catch (Exception ex)
            {
                st.Stop();
                Log($"Failure after {st.ElapsedMilliseconds}ms.");
                Log(ex.Message);
                if (ex.InnerException != null)
                {
                    Log(ex.InnerException.Message);
                }
            }
        }

        private string BuildConnectionString()
        {
            var serverOrConnectionString = connectionStringText.Text.Trim();
            var database = databaseText.Text.Trim();

            if (LooksLikeConnectionString(serverOrConnectionString))
            {
                var builder = new SqlConnectionStringBuilder(serverOrConnectionString);
                if (string.IsNullOrWhiteSpace(builder.InitialCatalog) && !string.IsNullOrWhiteSpace(database))
                {
                    builder.InitialCatalog = database;
                }

                if (string.IsNullOrWhiteSpace(builder.InitialCatalog))
                {
                    throw new InvalidOperationException("The connection string needs an Initial Catalog, or enter a database name.");
                }

                return builder.ConnectionString;
            }

            if (string.IsNullOrWhiteSpace(database))
            {
                throw new InvalidOperationException("Please enter a database name.");
            }

            return new SqlConnectionStringBuilder
            {
                DataSource = serverOrConnectionString,
                InitialCatalog = database,
                IntegratedSecurity = true,
                TrustServerCertificate = true
            }.ConnectionString;
        }

        private static bool LooksLikeConnectionString(string value)
        {
            return value.Contains("=") && value.Contains(";");
        }

        private void SetRunningState(bool isRunning)
        {
            generate.Enabled = !isRunning;
            button1.Enabled = !isRunning;
            clear.Enabled = !isRunning;
            copyResults.Enabled = !isRunning && results.TextLength > 0;
            Cursor = isRunning ? Cursors.WaitCursor : Cursors.Default;
            generate.Text = isRunning ? "Running..." : "Run";
        }

        private void Log(string message)
        {
            logging.AppendText($"{DateTime.UtcNow:u} UTC - {message}{Environment.NewLine}");
        }

        private void LoadUserSettings()
        {
            isLoadingSettings = true;
            try
            {
                var settings = UserSettings.Load();
                if (settings == null)
                {
                    return;
                }

                connectionStringText.Text = settings.ServerOrConnectionString ?? connectionStringText.Text;
                databaseText.Text = settings.Database ?? databaseText.Text;
                sqlText.Text = settings.SqlQuery ?? sqlText.Text;
            }
            finally
            {
                isLoadingSettings = false;
            }
        }

        private void TrackSettingsChanges()
        {
            connectionStringText.TextChanged += (_, _) => ScheduleSettingsSave();
            databaseText.TextChanged += (_, _) => ScheduleSettingsSave();
            sqlText.TextChanged += (_, _) => ScheduleSettingsSave();
        }

        private void ScheduleSettingsSave()
        {
            if (isLoadingSettings)
            {
                return;
            }

            settingsSaveTimer.Stop();
            settingsSaveTimer.Start();
        }

        private void SettingsSaveTimer_Tick(object sender, EventArgs e)
        {
            settingsSaveTimer.Stop();
            SaveUserSettings();
        }

        private void SaveUserSettings()
        {
            try
            {
                new UserSettings
                {
                    ServerOrConnectionString = connectionStringText.Text,
                    Database = databaseText.Text,
                    SqlQuery = sqlText.Text
                }.Save();
            }
            catch (Exception ex)
            {
                Log($"Unable to save settings: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            settingsSaveTimer.Stop();
            SaveUserSettings();
            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlText.Clear();
        }

        private void CopyResults_Click(object sender, EventArgs e)
        {
            if (results.TextLength == 0)
            {
                Log("There are no generated results to copy.");
                return;
            }

            Clipboard.SetText(results.Text);
            Log("Generated table copied to the clipboard.");
        }
    }
}
