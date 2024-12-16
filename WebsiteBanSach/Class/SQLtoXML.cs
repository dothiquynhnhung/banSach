using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Linq;

namespace WebsiteBanSach.Class
{
    public class SQLtoXML
    {
        private readonly string _connectionString;

        public SQLtoXML(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ExportAllTablesToXML()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    DataTable tables = conn.GetSchema("Tables");
                    var userTables = tables.AsEnumerable()
                                           .Where(row => row["TABLE_TYPE"].ToString() == "BASE TABLE");

                    foreach (DataRow row in userTables)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        string query = $"SELECT * FROM {tableName}";
                        ExportTableToXML(query, tableName);
                    }
                }

                return "Exported all tables to XML successfully!";
            }
            catch (Exception ex)
            {
                return $"Error exporting tables: {ex.Message}";
            }
        }

        private void ExportTableToXML(string query, string tableName)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataSet ds = new DataSet();
                da.Fill(ds, tableName);

                if (ds.Tables[tableName].Rows.Count == 0)
                {
                    Console.WriteLine($"Table {tableName} is empty. Skipping...");
                    return;
                }

                string folderPath = "wwwroot/fileXML";
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    NewLineOnAttributes = false
                };

                using (XmlWriter writer = XmlWriter.Create($"{folderPath}/{tableName}.xml", settings))
                {
                    ds.WriteXml(writer, XmlWriteMode.WriteSchema);
                }

                Console.WriteLine($"Exported table {tableName} to XML successfully.");
            }
        }
    }
}
