using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using WebsiteBanSach.Class;

namespace WebsiteBanSach.Controllers
{
    public class SQLToXMLController : Controller
    {
        private readonly string _connectionString = "Server=DESKTOP-D6HVN2B;Database=dbBanSach;Integrated Security=true;";

        public IActionResult ExportAllTables()
        {
            SQLtoXML sqlToXML = new SQLtoXML(_connectionString);
            string result = sqlToXML.ExportAllTablesToXML();

            return Content(result);
        }
    }
}
