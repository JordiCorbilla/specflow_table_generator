# SpecFlow Table Generator

A small Windows utility for turning SQL Server query results into SpecFlow table syntax.

If your acceptance tests need realistic database-backed examples, this tool lets you run a SQL query, generate a formatted SpecFlow table, and copy it straight into a `.feature` file.

![SpecFlow Table Generator screenshot](https://user-images.githubusercontent.com/7347994/138352081-08b554db-018f-4485-9165-61210ba6035b.png)

## Features

- Generate SpecFlow tables from SQL Server query results.
- Use either a server + database pair or a full SQL Server connection string.
- Copy generated output directly to the clipboard.
- Remember the last server, database, and SQL query between sessions.
- Keep the UI responsive while queries are running.
- Automatically exclude common audit columns from the generated table:
  - `AuditUser`
  - `AuditStartTime`
  - `AuditEndTime`

## Usage

1. Open the application.
2. Enter a SQL Server name and database, or paste a full SQL Server connection string.
3. Enter the SQL query to convert.
4. Click `Run`.
5. Click `Copy Results` and paste the table into your SpecFlow feature file.

The generated date format is:

```text
yyyy-MM-dd HH:mm:ss.fff
```

## Settings

The application remembers the last values you used so you do not need to re-enter them every time.

Saved values:

- Server or connection string
- Database
- SQL query

Settings are stored locally per user:

```text
%LOCALAPPDATA%\SpecFlowTableGenerator\settings.json
```

If the file is missing or cannot be read, the app starts with its default values.

## Requirements

- Windows
- .NET 10 runtime
- Access to a SQL Server database

## Build From Source

Clone the repository and build the solution:

```powershell
dotnet build .\specflow_table_generator\specflow_table_generator.sln
```

Run the app from the build output:

```text
specflow_table_generator\bin\Debug\net10.0-windows7.0\specflow_table_generator.exe
```

## Releases

Prebuilt executables are available from the GitHub releases page:

https://github.com/JordiCorbilla/specflow_table_generator/releases

## License

This project is released under the MIT License. See [LICENSE](LICENSE).
