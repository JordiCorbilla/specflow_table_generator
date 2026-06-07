# SpecFlow Table Generator
Simple SpecFlow table generator for SQL Server.

Do you have to generate a lot of SpecFlow tables that are usually part of DB data? Here is a simple utility that will help you generate any table into SpecFlow format so you can just copy-paste them into the spec file.

![image](https://user-images.githubusercontent.com/7347994/138352081-08b554db-018f-4485-9165-61210ba6035b.png)

## What it does

1. Enter a SQL Server name and database, or paste a full SQL Server connection string.
2. Enter the SQL query you want to turn into a SpecFlow table.
3. Run the query and copy the generated table straight to the clipboard.

The app filters the common audit columns `AuditUser`, `AuditStartTime`, and `AuditEndTime` from the generated output.

The executable can be found in the release area: https://github.com/JordiCorbilla/specflow_table_generator/releases.
